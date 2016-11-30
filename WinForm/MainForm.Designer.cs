namespace WinForm
{
    partial class MainForm
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
            this.ReadmeButton = new System.Windows.Forms.Button();
            this.SingleTransactionButton = new System.Windows.Forms.Button();
            this.MultiTransactionButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadmeButton
            // 
            this.ReadmeButton.Location = new System.Drawing.Point(32, 80);
            this.ReadmeButton.Name = "ReadmeButton";
            this.ReadmeButton.Size = new System.Drawing.Size(143, 23);
            this.ReadmeButton.TabIndex = 0;
            this.ReadmeButton.Text = "View Readme";
            this.ReadmeButton.UseVisualStyleBackColor = true;
            this.ReadmeButton.Click += new System.EventHandler(this.ReadmeButton_Click);
            // 
            // SingleTransactionButton
            // 
            this.SingleTransactionButton.Location = new System.Drawing.Point(32, 22);
            this.SingleTransactionButton.Name = "SingleTransactionButton";
            this.SingleTransactionButton.Size = new System.Drawing.Size(143, 23);
            this.SingleTransactionButton.TabIndex = 1;
            this.SingleTransactionButton.Text = "Single Transaction Viewer";
            this.SingleTransactionButton.UseVisualStyleBackColor = true;
            this.SingleTransactionButton.Click += new System.EventHandler(this.SingleTransactionButton_Click);
            // 
            // MultiTransactionButton
            // 
            this.MultiTransactionButton.Location = new System.Drawing.Point(32, 51);
            this.MultiTransactionButton.Name = "MultiTransactionButton";
            this.MultiTransactionButton.Size = new System.Drawing.Size(143, 23);
            this.MultiTransactionButton.TabIndex = 2;
            this.MultiTransactionButton.Text = "Multi Transaction Viewer";
            this.MultiTransactionButton.UseVisualStyleBackColor = true;
            this.MultiTransactionButton.Click += new System.EventHandler(this.MultiTransactionButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(32, 109);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(143, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 192);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MultiTransactionButton);
            this.Controls.Add(this.SingleTransactionButton);
            this.Controls.Add(this.ReadmeButton);
            this.Name = "MainForm";
            this.Text = "Block Chain Scanner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadmeButton;
        private System.Windows.Forms.Button SingleTransactionButton;
        private System.Windows.Forms.Button MultiTransactionButton;
        private System.Windows.Forms.Button ExitButton;
    }
}