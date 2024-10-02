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
            cmdCallAwait = new Button();
            cmdCallThread = new Button();
            cmdCallConfigureAwaitFalse = new Button();
            txtResult = new TextBox();
            cmdCallResult = new Button();
            SuspendLayout();
            // 
            // cmdCallAwait
            // 
            cmdCallAwait.BackColor = Color.FromArgb(192, 255, 192);
            cmdCallAwait.Location = new Point(37, 53);
            cmdCallAwait.Name = "cmdCallAwait";
            cmdCallAwait.Size = new Size(275, 29);
            cmdCallAwait.TabIndex = 0;
            cmdCallAwait.Text = "Call using await";
            cmdCallAwait.UseVisualStyleBackColor = false;
            cmdCallAwait.Click += cmdCallAwait_Click;
            // 
            // cmdCallThread
            // 
            cmdCallThread.BackColor = Color.FromArgb(255, 192, 192);
            cmdCallThread.Location = new Point(37, 164);
            cmdCallThread.Name = "cmdCallThread";
            cmdCallThread.Size = new Size(275, 29);
            cmdCallThread.TabIndex = 1;
            cmdCallThread.Text = "Call using thread";
            cmdCallThread.UseVisualStyleBackColor = false;
            cmdCallThread.Click += cmdCallThread_Click;
            // 
            // cmdCallConfigureAwaitFalse
            // 
            cmdCallConfigureAwaitFalse.BackColor = Color.FromArgb(255, 192, 192);
            cmdCallConfigureAwaitFalse.Location = new Point(37, 109);
            cmdCallConfigureAwaitFalse.Name = "cmdCallConfigureAwaitFalse";
            cmdCallConfigureAwaitFalse.Size = new Size(275, 29);
            cmdCallConfigureAwaitFalse.TabIndex = 2;
            cmdCallConfigureAwaitFalse.Text = "Call using ConfigureAwait(false)";
            cmdCallConfigureAwaitFalse.UseVisualStyleBackColor = false;
            cmdCallConfigureAwaitFalse.Click += cmdCallConfigureAwaitFalse_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(348, 59);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(226, 192);
            txtResult.TabIndex = 3;
            // 
            // cmdCallResult
            // 
            cmdCallResult.BackColor = Color.FromArgb(255, 192, 192);
            cmdCallResult.Location = new Point(37, 222);
            cmdCallResult.Name = "cmdCallResult";
            cmdCallResult.Size = new Size(275, 29);
            cmdCallResult.TabIndex = 4;
            cmdCallResult.Text = "Call using Result";
            cmdCallResult.UseVisualStyleBackColor = false;
            cmdCallResult.Click += cmdCallResult_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 296);
            Controls.Add(cmdCallResult);
            Controls.Add(txtResult);
            Controls.Add(cmdCallConfigureAwaitFalse);
            Controls.Add(cmdCallThread);
            Controls.Add(cmdCallAwait);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdCallAwait;
        private Button cmdCallThread;
        private Button cmdCallConfigureAwaitFalse;
        private TextBox txtResult;
        private Button cmdCallResult;
    }
}
