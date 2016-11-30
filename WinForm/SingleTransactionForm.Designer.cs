namespace WinForm
{
    partial class SingleTransactionForm
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
            this.TxTextBox = new System.Windows.Forms.TextBox();
            this.DecodeTXButton = new System.Windows.Forms.Button();
            this.TXOutputTextBox = new System.Windows.Forms.TextBox();
            this.TxPropTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DecodeGetFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // TxTextBox
            // 
            this.TxTextBox.Location = new System.Drawing.Point(12, 23);
            this.TxTextBox.Name = "TxTextBox";
            this.TxTextBox.Size = new System.Drawing.Size(519, 20);
            this.TxTextBox.TabIndex = 0;
            // 
            // DecodeTXButton
            // 
            this.DecodeTXButton.Location = new System.Drawing.Point(537, 23);
            this.DecodeTXButton.Name = "DecodeTXButton";
            this.DecodeTXButton.Size = new System.Drawing.Size(75, 23);
            this.DecodeTXButton.TabIndex = 1;
            this.DecodeTXButton.Text = "Decode";
            this.DecodeTXButton.UseVisualStyleBackColor = true;
            this.DecodeTXButton.Click += new System.EventHandler(this.DecodeTXButton_Click);
            // 
            // TXOutputTextBox
            // 
            this.TXOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXOutputTextBox.Location = new System.Drawing.Point(12, 99);
            this.TXOutputTextBox.Multiline = true;
            this.TXOutputTextBox.Name = "TXOutputTextBox";
            this.TXOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TXOutputTextBox.Size = new System.Drawing.Size(665, 475);
            this.TXOutputTextBox.TabIndex = 2;
            // 
            // TxPropTextBox
            // 
            this.TxPropTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxPropTextBox.Location = new System.Drawing.Point(694, 99);
            this.TxPropTextBox.Multiline = true;
            this.TxPropTextBox.Name = "TxPropTextBox";
            this.TxPropTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxPropTextBox.Size = new System.Drawing.Size(292, 475);
            this.TxPropTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transaction Properties";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Transaction Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Transaction ID";
            // 
            // DecodeGetFileButton
            // 
            this.DecodeGetFileButton.Location = new System.Drawing.Point(618, 23);
            this.DecodeGetFileButton.Name = "DecodeGetFileButton";
            this.DecodeGetFileButton.Size = new System.Drawing.Size(138, 23);
            this.DecodeGetFileButton.TabIndex = 11;
            this.DecodeGetFileButton.Text = "Decode and Get File";
            this.DecodeGetFileButton.UseVisualStyleBackColor = true;
            this.DecodeGetFileButton.Click += new System.EventHandler(this.DecodeGetFileButton_Click);
            // 
            // SingleTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 586);
            this.Controls.Add(this.DecodeGetFileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxPropTextBox);
            this.Controls.Add(this.TXOutputTextBox);
            this.Controls.Add(this.DecodeTXButton);
            this.Controls.Add(this.TxTextBox);
            this.Name = "SingleTransactionForm";
            this.Text = "Block Chain Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxTextBox;
        private System.Windows.Forms.Button DecodeTXButton;
        private System.Windows.Forms.TextBox TXOutputTextBox;
        private System.Windows.Forms.TextBox TxPropTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DecodeGetFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

