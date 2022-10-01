using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Common
{
  public class Game
  {
    //readonly byte[] buffer = new byte[4096];

    public Game(Action<string> debugHelper)
    {
      DebugHelper = debugHelper;
    }

    private Action<string> DebugHelper { get; }
    public string HostName { get; set; }
    public string ClientName { get; set; }
    public Weapon OpponentSelected { get; private set; } = Weapon.None;

    private Weapon selectedWeapon = Weapon.None;

    public async Task StartServerAsync()
    {
      TcpListener listener = new TcpListener(IPAddress.Any, 9999);
      try
      {
        listener.Start();

        DebugHelper($"Waiting for connection from client...");
        using TcpClient handler = await listener.AcceptTcpClientAsync();
        await using NetworkStream stream = handler.GetStream();
        DebugHelper($"{ClientName} connected...");
        Net net = new Net(stream);
        var message = $"Connected to server";
        await net.SendAsync(new MessageObject(message, HostName));
        DebugHelper($">>>\"{message}");
        MessageObject messageFromClient = await net.ReceiveAsync();
        ClientName = messageFromClient.Name;
        DebugHelper($"<<<{messageFromClient.Message}");

        while (true)
        {
          selectedWeapon = Weapon.None;

          while (selectedWeapon == Weapon.None)
          {
            await Task.Delay(100);
          }
          DebugHelper($"{HostName} played {selectedWeapon}");

          MessageObject messageFromClient2 = await net.ReceiveAsync();
          ClientName = messageFromClient2.Name;
          OpponentSelected = messageFromClient2.SelectedWeapon;
          DebugHelper($"{messageFromClient2.Name} played {OpponentSelected}");

          bool hostWins = false;
          if (selectedWeapon == OpponentSelected)
          {
            DebugHelper($"tied, try again.");
            await net.SendAsync(new MessageObject
            {
              Message = $"tied, try again.",
              Result = Result.Tied,
              Name = HostName,
              SelectedWeapon = selectedWeapon
            });
            continue;
          }
          else
          {
            hostWins = (OpponentSelected - selectedWeapon + 3) % 3 == 1;
            DebugHelper($"{HostName} {(hostWins ? "win" : "lose")}!");
            await net.SendAsync(new MessageObject
            {
              MessageType = MessageType.Result,
              Name = HostName,
              Result = hostWins ? Result.HostWins : Result.ClientWins,
              SelectedWeapon = selectedWeapon
            });
            //break;// afbryd forbindelsen med break,
            continue;// eller fortsæt med continue
          }
        }
      }
      catch (Exception e)
      {
        DebugHelper(e.Message);
      }
      finally
      {
        listener.Stop();
      }
    }

    public async Task StartClientAsync(IPAddress ipAddress)
    {
      try
      {
        using TcpClient client = new();

        DebugHelper($"Trying to connect to {ipAddress}");
        Task connectTask = client.ConnectAsync(ipAddress, 9999);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Task cancelTask = Task.Delay(2500);
        await await Task.WhenAny(connectTask, cancelTask);
        if (cancelTask.IsCompleted)
        {
          sw.Stop();
          DebugHelper($"Failed to connect!");
          DebugHelper($"Failed in {sw.ElapsedMilliseconds}ms");
          return;
        }
        DebugHelper($"Connected to Host");
        sw.Stop();
        DebugHelper($"Connected in {sw.ElapsedMilliseconds}ms");
        var stream = client.GetStream();
        Net net = new Net(stream);
        var messageFromServer = await net.ReceiveAsync();
        HostName = messageFromServer.Name;
        DebugHelper($"From server: {messageFromServer.Message}");

        var message = $"Hi from {ClientName}!";
        await net.SendAsync(new MessageObject(message, ClientName));

        while (true)
        {
          selectedWeapon = Weapon.None;
          while (selectedWeapon == Weapon.None)
          {
            await Task.Delay(100);
          }
          DebugHelper($"{ClientName} played {selectedWeapon}");
          await net.SendAsync(new MessageObject
          {
            Name = ClientName,
            MessageType = MessageType.PlayedTurn,
            SelectedWeapon = selectedWeapon
          });

          // Get result, we are so exited!!!
          var objFromServer = await net.ReceiveAsync();

          OpponentSelected = objFromServer.SelectedWeapon;
          DebugHelper($"{objFromServer.Name} played {OpponentSelected}");
          if (objFromServer.Result == Result.Tied)
          {
            DebugHelper($"We tied, try again.");
            continue;
          }
          else
          {
            DebugHelper($"{ClientName} {(objFromServer.Result == Result.HostWins ? "lose" : "win")}!");
            //break;// afbryd forbindelsen med break,
            continue;// eller fortsæt med continue
          }
        }
      }
      catch (SocketException ex)
      {
        DebugHelper(ex.Message);
      }
    }

    public void PlayerSelected(Weapon weapon)
    {
      selectedWeapon = weapon;
    }

    public async Task<Weapon> GetOpponentSelectionAsync()
    {
      while (OpponentSelected == Weapon.None)
      {
        await Task.Delay(100);
      }
      return OpponentSelected;
    }
  }
}