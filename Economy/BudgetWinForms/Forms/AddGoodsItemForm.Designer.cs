﻿namespace BudgetWinForms
{
    partial class AddGoodsItemForm
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
            this.addGoodsCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.addGoodsUnitOfMeasureComboBox = new System.Windows.Forms.ComboBox();
            this.addGoodsItemTextBox = new System.Windows.Forms.TextBox();
            this.addGoodsItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addGoodsCategoryComboBox
            // 
            this.addGoodsCategoryComboBox.FormattingEnabled = true;
            this.addGoodsCategoryComboBox.Location = new System.Drawing.Point(13, 13);
            this.addGoodsCategoryComboBox.Name = "addGoodsCategoryComboBox";
            this.addGoodsCategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.addGoodsCategoryComboBox.TabIndex = 0;
            this.addGoodsCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.addGoodsCategoryComboBoxSelectedIndexChanged);
            // 
            // addGoodsUnitOfMeasureComboBox
            // 
            this.addGoodsUnitOfMeasureComboBox.FormattingEnabled = true;
            this.addGoodsUnitOfMeasureComboBox.Location = new System.Drawing.Point(13, 41);
            this.addGoodsUnitOfMeasureComboBox.Name = "addGoodsUnitOfMeasureComboBox";
            this.addGoodsUnitOfMeasureComboBox.Size = new System.Drawing.Size(121, 21);
            this.addGoodsUnitOfMeasureComboBox.TabIndex = 1;
            this.addGoodsUnitOfMeasureComboBox.SelectedIndexChanged += new System.EventHandler(this.AddGoodsUnitOfMeasureComboBoxSelectedIndexChanged);
            // 
            // addGoodsItemTextBox
            // 
            this.addGoodsItemTextBox.Location = new System.Drawing.Point(13, 81);
            this.addGoodsItemTextBox.Name = "addGoodsItemTextBox";
            this.addGoodsItemTextBox.Size = new System.Drawing.Size(121, 20);
            this.addGoodsItemTextBox.TabIndex = 2;
            // 
            // addGoodsItemButton
            // 
            this.addGoodsItemButton.Location = new System.Drawing.Point(58, 108);
            this.addGoodsItemButton.Name = "addGoodsItemButton";
            this.addGoodsItemButton.Size = new System.Drawing.Size(75, 23);
            this.addGoodsItemButton.TabIndex = 3;
            this.addGoodsItemButton.Text = "Ok";
            this.addGoodsItemButton.UseVisualStyleBackColor = true;
            this.addGoodsItemButton.Click += new System.EventHandler(this.addGoodsItemButtonClick);
            // 
            // AddGoodsItemForm
            // 
            this.AcceptButton = this.addGoodsItemButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addGoodsItemButton);
            this.Controls.Add(this.addGoodsItemTextBox);
            this.Controls.Add(this.addGoodsUnitOfMeasureComboBox);
            this.Controls.Add(this.addGoodsCategoryComboBox);
            this.Name = "AddGoodsItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox addGoodsCategoryComboBox;
        private System.Windows.Forms.ComboBox addGoodsUnitOfMeasureComboBox;
        private System.Windows.Forms.TextBox addGoodsItemTextBox;
        private System.Windows.Forms.Button addGoodsItemButton;
    }
}