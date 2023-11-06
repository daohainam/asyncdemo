namespace WindowsFormsApp1
{
    partial class Form1
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
            this.cmdLaggedButton = new System.Windows.Forms.Button();
            this.cmdInterThreadError = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.Label();
            this.cmdAsync = new System.Windows.Forms.Button();
            this.cmdUsingInvoke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdLaggedButton
            // 
            this.cmdLaggedButton.BackColor = System.Drawing.Color.Yellow;
            this.cmdLaggedButton.Location = new System.Drawing.Point(27, 80);
            this.cmdLaggedButton.Name = "cmdLaggedButton";
            this.cmdLaggedButton.Size = new System.Drawing.Size(244, 54);
            this.cmdLaggedButton.TabIndex = 0;
            this.cmdLaggedButton.Text = "Lagged button";
            this.cmdLaggedButton.UseVisualStyleBackColor = false;
            this.cmdLaggedButton.Click += new System.EventHandler(this.cmdLaggedButton_Click);
            // 
            // cmdInterThreadError
            // 
            this.cmdInterThreadError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cmdInterThreadError.Location = new System.Drawing.Point(27, 140);
            this.cmdInterThreadError.Name = "cmdInterThreadError";
            this.cmdInterThreadError.Size = new System.Drawing.Size(244, 54);
            this.cmdInterThreadError.TabIndex = 1;
            this.cmdInterThreadError.Text = "Inter-thread error button";
            this.cmdInterThreadError.UseVisualStyleBackColor = false;
            this.cmdInterThreadError.Click += new System.EventHandler(this.cmdInterThreadError_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Location = new System.Drawing.Point(27, 13);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(64, 16);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Text = "Message";
            // 
            // cmdAsync
            // 
            this.cmdAsync.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdAsync.Location = new System.Drawing.Point(27, 260);
            this.cmdAsync.Name = "cmdAsync";
            this.cmdAsync.Size = new System.Drawing.Size(244, 54);
            this.cmdAsync.TabIndex = 3;
            this.cmdAsync.Text = "Async button";
            this.cmdAsync.UseVisualStyleBackColor = false;
            this.cmdAsync.Click += new System.EventHandler(this.cmdAsync_ClickAsync);
            // 
            // cmdUsingInvoke
            // 
            this.cmdUsingInvoke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmdUsingInvoke.Location = new System.Drawing.Point(27, 200);
            this.cmdUsingInvoke.Name = "cmdUsingInvoke";
            this.cmdUsingInvoke.Size = new System.Drawing.Size(244, 54);
            this.cmdUsingInvoke.TabIndex = 4;
            this.cmdUsingInvoke.Text = "Using Invoke button";
            this.cmdUsingInvoke.UseVisualStyleBackColor = false;
            this.cmdUsingInvoke.Click += new System.EventHandler(this.cmdUsingInvoke_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 338);
            this.Controls.Add(this.cmdUsingInvoke);
            this.Controls.Add(this.cmdAsync);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cmdInterThreadError);
            this.Controls.Add(this.cmdLaggedButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLaggedButton;
        private System.Windows.Forms.Button cmdInterThreadError;
        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.Button cmdAsync;
        private System.Windows.Forms.Button cmdUsingInvoke;
    }
}

