namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_enviar = new Button();
            textBox1 = new TextBox();
            btn_connect = new Button();
            btn_diconnect = new Button();
            SuspendLayout();
            // 
            // btn_enviar
            // 
            btn_enviar.Location = new Point(508, 122);
            btn_enviar.Name = "btn_enviar";
            btn_enviar.Size = new Size(63, 52);
            btn_enviar.TabIndex = 0;
            btn_enviar.Text = "Send";
            btn_enviar.UseVisualStyleBackColor = true;
            btn_enviar.Click += btn_enviar_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(307, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(195, 23);
            textBox1.TabIndex = 1;
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(97, 44);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(75, 23);
            btn_connect.TabIndex = 2;
            btn_connect.Text = "Conect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_diconnect
            // 
            btn_diconnect.Location = new Point(97, 296);
            btn_diconnect.Name = "btn_diconnect";
            btn_diconnect.Size = new Size(75, 23);
            btn_diconnect.TabIndex = 3;
            btn_diconnect.Text = "Disconnect";
            btn_diconnect.UseVisualStyleBackColor = true;
            btn_diconnect.Click += btn_diconnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_diconnect);
            Controls.Add(btn_connect);
            Controls.Add(textBox1);
            Controls.Add(btn_enviar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_enviar;
        private TextBox textBox1;
        private Button btn_connect;
        private Button btn_diconnect;
    }
}
