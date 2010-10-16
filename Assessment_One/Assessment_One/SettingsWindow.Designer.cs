namespace Assessment_One
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chooseBankAccountsFilePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bankAccountFilePathTextBox = new System.Windows.Forms.TextBox();
            this.chooseStockItemsFilePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stockItemsFilePathTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chooseBankAccountsFilePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bankAccountFilePathTextBox);
            this.groupBox1.Controls.Add(this.chooseStockItemsFilePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stockItemsFilePathTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File paths";
            // 
            // chooseBankAccountsFilePath
            // 
            this.chooseBankAccountsFilePath.Location = new System.Drawing.Point(292, 44);
            this.chooseBankAccountsFilePath.Name = "chooseBankAccountsFilePath";
            this.chooseBankAccountsFilePath.Size = new System.Drawing.Size(75, 23);
            this.chooseBankAccountsFilePath.TabIndex = 5;
            this.chooseBankAccountsFilePath.Text = "Choose";
            this.chooseBankAccountsFilePath.UseVisualStyleBackColor = true;
            this.chooseBankAccountsFilePath.Click += new System.EventHandler(this.chooseBankAccountsFilePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bank Accounts:";
            // 
            // bankAccountFilePathTextBox
            // 
            this.bankAccountFilePathTextBox.Location = new System.Drawing.Point(96, 46);
            this.bankAccountFilePathTextBox.Name = "bankAccountFilePathTextBox";
            this.bankAccountFilePathTextBox.Size = new System.Drawing.Size(190, 20);
            this.bankAccountFilePathTextBox.TabIndex = 3;
            // 
            // chooseStockItemsFilePath
            // 
            this.chooseStockItemsFilePath.Location = new System.Drawing.Point(292, 17);
            this.chooseStockItemsFilePath.Name = "chooseStockItemsFilePath";
            this.chooseStockItemsFilePath.Size = new System.Drawing.Size(75, 23);
            this.chooseStockItemsFilePath.TabIndex = 2;
            this.chooseStockItemsFilePath.Text = "Choose";
            this.chooseStockItemsFilePath.UseVisualStyleBackColor = true;
            this.chooseStockItemsFilePath.Click += new System.EventHandler(this.chooseStockItemsFilePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stock Items:";
            // 
            // stockItemsFilePathTextBox
            // 
            this.stockItemsFilePathTextBox.Location = new System.Drawing.Point(96, 19);
            this.stockItemsFilePathTextBox.Name = "stockItemsFilePathTextBox";
            this.stockItemsFilePathTextBox.Size = new System.Drawing.Size(190, 20);
            this.stockItemsFilePathTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(304, 98);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(223, 98);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 130);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.Text = "SettingsWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button chooseBankAccountsFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bankAccountFilePathTextBox;
        private System.Windows.Forms.Button chooseStockItemsFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stockItemsFilePathTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}