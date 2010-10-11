namespace Assessment_One
{
    partial class StockItemView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.stockItemActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.placeOrderButton = new System.Windows.Forms.Button();
            this.orderLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.stockItemInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.reqStockLabel = new System.Windows.Forms.Label();
            this.currStockLabel = new System.Windows.Forms.Label();
            this.supplierNameLabel = new System.Windows.Forms.Label();
            this.stockNameLabel = new System.Windows.Forms.Label();
            this.stockCodeLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.reqStockTextBox = new System.Windows.Forms.TextBox();
            this.currStockTextBox = new System.Windows.Forms.TextBox();
            this.supplierNameTextBox = new System.Windows.Forms.TextBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.stockCodeTextBox = new System.Windows.Forms.TextBox();
            this.stockItemActionsGroupBox.SuspendLayout();
            this.stockItemInformationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockItemActionsGroupBox
            // 
            this.stockItemActionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockItemActionsGroupBox.Controls.Add(this.richTextBox1);
            this.stockItemActionsGroupBox.Controls.Add(this.quantityTextBox);
            this.stockItemActionsGroupBox.Controls.Add(this.placeOrderButton);
            this.stockItemActionsGroupBox.Controls.Add(this.orderLabel);
            this.stockItemActionsGroupBox.Location = new System.Drawing.Point(3, 201);
            this.stockItemActionsGroupBox.Name = "stockItemActionsGroupBox";
            this.stockItemActionsGroupBox.Size = new System.Drawing.Size(353, 100);
            this.stockItemActionsGroupBox.TabIndex = 7;
            this.stockItemActionsGroupBox.TabStop = false;
            this.stockItemActionsGroupBox.Text = "Actions";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(32, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(315, 46);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "To place an order choose a valid bank account from the left-side and enter the qu" +
                "antity to be ordered.\n";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quantityTextBox.Location = new System.Drawing.Point(101, 71);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(165, 20);
            this.quantityTextBox.TabIndex = 2;
            this.quantityTextBox.Text = "Quantity\r\n";
            // 
            // placeOrderButton
            // 
            this.placeOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.placeOrderButton.Location = new System.Drawing.Point(272, 71);
            this.placeOrderButton.Name = "placeOrderButton";
            this.placeOrderButton.Size = new System.Drawing.Size(75, 23);
            this.placeOrderButton.TabIndex = 1;
            this.placeOrderButton.Text = "Place Order";
            this.placeOrderButton.UseVisualStyleBackColor = true;
            // 
            // orderLabel
            // 
            this.orderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(29, 74);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(66, 13);
            this.orderLabel.TabIndex = 0;
            this.orderLabel.Text = "Place Order:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(281, 306);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(200, 306);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // stockItemInformationGroupBox
            // 
            this.stockItemInformationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockItemInformationGroupBox.AutoSize = true;
            this.stockItemInformationGroupBox.Controls.Add(this.priceLabel);
            this.stockItemInformationGroupBox.Controls.Add(this.reqStockLabel);
            this.stockItemInformationGroupBox.Controls.Add(this.currStockLabel);
            this.stockItemInformationGroupBox.Controls.Add(this.supplierNameLabel);
            this.stockItemInformationGroupBox.Controls.Add(this.stockNameLabel);
            this.stockItemInformationGroupBox.Controls.Add(this.stockCodeLabel);
            this.stockItemInformationGroupBox.Controls.Add(this.priceTextBox);
            this.stockItemInformationGroupBox.Controls.Add(this.reqStockTextBox);
            this.stockItemInformationGroupBox.Controls.Add(this.currStockTextBox);
            this.stockItemInformationGroupBox.Controls.Add(this.supplierNameTextBox);
            this.stockItemInformationGroupBox.Controls.Add(this.itemNameTextBox);
            this.stockItemInformationGroupBox.Controls.Add(this.stockCodeTextBox);
            this.stockItemInformationGroupBox.Location = new System.Drawing.Point(3, 3);
            this.stockItemInformationGroupBox.Name = "stockItemInformationGroupBox";
            this.stockItemInformationGroupBox.Size = new System.Drawing.Size(353, 191);
            this.stockItemInformationGroupBox.TabIndex = 4;
            this.stockItemInformationGroupBox.TabStop = false;
            this.stockItemInformationGroupBox.Text = "Stock Item Information";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(61, 162);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(34, 13);
            this.priceLabel.TabIndex = 11;
            this.priceLabel.Text = "Price:";
            // 
            // reqStockLabel
            // 
            this.reqStockLabel.AutoSize = true;
            this.reqStockLabel.Location = new System.Drawing.Point(11, 135);
            this.reqStockLabel.Name = "reqStockLabel";
            this.reqStockLabel.Size = new System.Drawing.Size(84, 13);
            this.reqStockLabel.TabIndex = 10;
            this.reqStockLabel.Text = "Required Stock:";
            // 
            // currStockLabel
            // 
            this.currStockLabel.AutoSize = true;
            this.currStockLabel.Location = new System.Drawing.Point(20, 108);
            this.currStockLabel.Name = "currStockLabel";
            this.currStockLabel.Size = new System.Drawing.Size(75, 13);
            this.currStockLabel.TabIndex = 9;
            this.currStockLabel.Text = "Current Stock:";
            // 
            // supplierNameLabel
            // 
            this.supplierNameLabel.AutoSize = true;
            this.supplierNameLabel.Location = new System.Drawing.Point(16, 81);
            this.supplierNameLabel.Name = "supplierNameLabel";
            this.supplierNameLabel.Size = new System.Drawing.Size(79, 13);
            this.supplierNameLabel.TabIndex = 8;
            this.supplierNameLabel.Text = "Supplier Name:";
            // 
            // stockNameLabel
            // 
            this.stockNameLabel.AutoSize = true;
            this.stockNameLabel.Location = new System.Drawing.Point(57, 54);
            this.stockNameLabel.Name = "stockNameLabel";
            this.stockNameLabel.Size = new System.Drawing.Size(38, 13);
            this.stockNameLabel.TabIndex = 7;
            this.stockNameLabel.Text = "Name:";
            // 
            // stockCodeLabel
            // 
            this.stockCodeLabel.AutoSize = true;
            this.stockCodeLabel.Location = new System.Drawing.Point(33, 27);
            this.stockCodeLabel.Name = "stockCodeLabel";
            this.stockCodeLabel.Size = new System.Drawing.Size(62, 13);
            this.stockCodeLabel.TabIndex = 6;
            this.stockCodeLabel.Text = "Stockcode:";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.priceTextBox.Location = new System.Drawing.Point(101, 159);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(206, 20);
            this.priceTextBox.TabIndex = 5;
            // 
            // reqStockTextBox
            // 
            this.reqStockTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reqStockTextBox.Location = new System.Drawing.Point(101, 132);
            this.reqStockTextBox.Name = "reqStockTextBox";
            this.reqStockTextBox.Size = new System.Drawing.Size(206, 20);
            this.reqStockTextBox.TabIndex = 4;
            // 
            // currStockTextBox
            // 
            this.currStockTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.currStockTextBox.Location = new System.Drawing.Point(101, 105);
            this.currStockTextBox.Name = "currStockTextBox";
            this.currStockTextBox.Size = new System.Drawing.Size(206, 20);
            this.currStockTextBox.TabIndex = 3;
            // 
            // supplierNameTextBox
            // 
            this.supplierNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierNameTextBox.Location = new System.Drawing.Point(101, 78);
            this.supplierNameTextBox.Name = "supplierNameTextBox";
            this.supplierNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.supplierNameTextBox.TabIndex = 2;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemNameTextBox.Location = new System.Drawing.Point(101, 51);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.itemNameTextBox.TabIndex = 1;
            // 
            // stockCodeTextBox
            // 
            this.stockCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockCodeTextBox.Location = new System.Drawing.Point(101, 24);
            this.stockCodeTextBox.Name = "stockCodeTextBox";
            this.stockCodeTextBox.Size = new System.Drawing.Size(206, 20);
            this.stockCodeTextBox.TabIndex = 0;
            // 
            // StockItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stockItemActionsGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.stockItemInformationGroupBox);
            this.Name = "StockItemView";
            this.Size = new System.Drawing.Size(359, 335);
            this.stockItemActionsGroupBox.ResumeLayout(false);
            this.stockItemActionsGroupBox.PerformLayout();
            this.stockItemInformationGroupBox.ResumeLayout(false);
            this.stockItemInformationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox stockItemActionsGroupBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Button placeOrderButton;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox stockItemInformationGroupBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label reqStockLabel;
        private System.Windows.Forms.Label currStockLabel;
        private System.Windows.Forms.Label supplierNameLabel;
        private System.Windows.Forms.Label stockNameLabel;
        private System.Windows.Forms.Label stockCodeLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox reqStockTextBox;
        private System.Windows.Forms.TextBox currStockTextBox;
        private System.Windows.Forms.TextBox supplierNameTextBox;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox stockCodeTextBox;

    }
}
