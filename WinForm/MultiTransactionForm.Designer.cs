namespace WinForm
{
    partial class MultiTransactionForm
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
            this.TxListTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GetTxListFromFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BuildFileFromMultiButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // TxListTextBox
            // 
            this.TxListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TxListTextBox.Location = new System.Drawing.Point(21, 33);
            this.TxListTextBox.Multiline = true;
            this.TxListTextBox.Name = "TxListTextBox";
            this.TxListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxListTextBox.Size = new System.Drawing.Size(452, 574);
            this.TxListTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of Transactions";
            // 
            // GetTxListFromFileButton
            // 
            this.GetTxListFromFileButton.Location = new System.Drawing.Point(358, 9);
            this.GetTxListFromFileButton.Name = "GetTxListFromFileButton";
            this.GetTxListFromFileButton.Size = new System.Drawing.Size(115, 23);
            this.GetTxListFromFileButton.TabIndex = 2;
            this.GetTxListFromFileButton.Text = "Populate from File";
            this.GetTxListFromFileButton.UseVisualStyleBackColor = true;
            this.GetTxListFromFileButton.Click += new System.EventHandler(this.GetTxListFromFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BuildFileFromMultiButton
            // 
            this.BuildFileFromMultiButton.Location = new System.Drawing.Point(546, 14);
            this.BuildFileFromMultiButton.Name = "BuildFileFromMultiButton";
            this.BuildFileFromMultiButton.Size = new System.Drawing.Size(151, 23);
            this.BuildFileFromMultiButton.TabIndex = 3;
            this.BuildFileFromMultiButton.Text = "Build file from Transactions";
            this.BuildFileFromMultiButton.UseVisualStyleBackColor = true;
            this.BuildFileFromMultiButton.Click += new System.EventHandler(this.BuildFileFromMultiButton_Click);
            // 
            // MultiTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 619);
            this.Controls.Add(this.BuildFileFromMultiButton);
            this.Controls.Add(this.GetTxListFromFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxListTextBox);
            this.Name = "MultiTransactionForm";
            this.Text = "MultiTransactionForm";
            this.Load += new System.EventHandler(this.MultiTransactionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxListTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GetTxListFromFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BuildFileFromMultiButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}