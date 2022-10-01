namespace WinGame
{
  partial class ClientForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(5, 85);
      this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(512, 47);
      this.label1.TabIndex = 1;
      this.label1.Text = "IP Of Host";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.Color.DimGray;
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.textBox1.ForeColor = System.Drawing.Color.Orange;
      this.textBox1.Location = new System.Drawing.Point(5, 137);
      this.textBox1.Margin = new System.Windows.Forms.Padding(0);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(512, 31);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
      this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
      // 
      // textBox2
      // 
      this.textBox2.BackColor = System.Drawing.Color.DimGray;
      this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.textBox2.ForeColor = System.Drawing.Color.Orange;
      this.textBox2.Location = new System.Drawing.Point(5, 54);
      this.textBox2.Margin = new System.Windows.Forms.Padding(0);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(512, 31);
      this.textBox2.TabIndex = 0;
      this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(5, 5);
      this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(512, 44);
      this.label2.TabIndex = 2;
      this.label2.Text = "Your Name";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ClientForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(522, 173);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ClientForm";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Client";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
    }
}