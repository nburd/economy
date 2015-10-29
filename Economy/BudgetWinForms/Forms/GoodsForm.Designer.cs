namespace BudgetWinForms
{
    partial class GoodsForm
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
            this.components = new System.ComponentModel.Container();
            this.goodsItemComboBox = new System.Windows.Forms.ComboBox();
            this.goodsItemListBox = new System.Windows.Forms.ListBox();
            this.goodsItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodsItemAddButton = new System.Windows.Forms.Button();
            this.goodsItemContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // goodsItemComboBox
            // 
            this.goodsItemComboBox.FormattingEnabled = true;
            this.goodsItemComboBox.Location = new System.Drawing.Point(13, 13);
            this.goodsItemComboBox.Name = "goodsItemComboBox";
            this.goodsItemComboBox.Size = new System.Drawing.Size(168, 21);
            this.goodsItemComboBox.TabIndex = 0;
            this.goodsItemComboBox.SelectedIndexChanged += new System.EventHandler(this.goodsItemComboBoxSelectedIndexChanged);
            // 
            // goodsItemListBox
            // 
            this.goodsItemListBox.ContextMenuStrip = this.goodsItemContextMenuStrip;
            this.goodsItemListBox.FormattingEnabled = true;
            this.goodsItemListBox.Location = new System.Drawing.Point(13, 41);
            this.goodsItemListBox.Name = "goodsItemListBox";
            this.goodsItemListBox.Size = new System.Drawing.Size(178, 212);
            this.goodsItemListBox.TabIndex = 1;
            // 
            // goodsItemContextMenuStrip
            // 
            this.goodsItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.goodsItemContextMenuStrip.Name = "purchaseContextMenuStrip";
            this.goodsItemContextMenuStrip.Size = new System.Drawing.Size(129, 48);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItemClick);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // goodsItemAddButton
            // 
            this.goodsItemAddButton.Location = new System.Drawing.Point(12, 268);
            this.goodsItemAddButton.Name = "goodsItemAddButton";
            this.goodsItemAddButton.Size = new System.Drawing.Size(75, 23);
            this.goodsItemAddButton.TabIndex = 2;
            this.goodsItemAddButton.Text = "Добавить";
            this.goodsItemAddButton.UseVisualStyleBackColor = true;
            this.goodsItemAddButton.Click += new System.EventHandler(this.goodsItemAddButtonClick);
            // 
            // GoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 395);
            this.Controls.Add(this.goodsItemAddButton);
            this.Controls.Add(this.goodsItemListBox);
            this.Controls.Add(this.goodsItemComboBox);
            this.Name = "GoodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Товары";
            this.goodsItemContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox goodsItemComboBox;
        private System.Windows.Forms.ListBox goodsItemListBox;
        private System.Windows.Forms.Button goodsItemAddButton;
        private System.Windows.Forms.ContextMenuStrip goodsItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}