namespace BudgetWinForms
{
    partial class CategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.categoriesListBox = new System.Windows.Forms.ListBox();
            this.categoryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryAddButton = new System.Windows.Forms.Button();
            this.categoryContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoriesListBox
            // 
            this.categoriesListBox.ContextMenuStrip = this.categoryContextMenuStrip;
            this.categoriesListBox.FormattingEnabled = true;
            this.categoriesListBox.Location = new System.Drawing.Point(34, 12);
            this.categoriesListBox.MaximumSize = new System.Drawing.Size(220, 290);
            this.categoriesListBox.MinimumSize = new System.Drawing.Size(220, 290);
            this.categoriesListBox.Name = "categoriesListBox";
            this.categoriesListBox.Size = new System.Drawing.Size(220, 290);
            this.categoriesListBox.TabIndex = 0;
            // 
            // categoryContextMenuStrip
            // 
            this.categoryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.categoryContextMenuStrip.Name = "categoryContextMenuStrip";
            this.categoryContextMenuStrip.Size = new System.Drawing.Size(129, 48);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItemClick);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItemClick);
            // 
            // categoryAddButton
            // 
            this.categoryAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryAddButton.Location = new System.Drawing.Point(179, 326);
            this.categoryAddButton.Name = "categoryAddButton";
            this.categoryAddButton.Size = new System.Drawing.Size(75, 23);
            this.categoryAddButton.TabIndex = 1;
            this.categoryAddButton.Text = "Добавить";
            this.categoryAddButton.UseVisualStyleBackColor = true;
            this.categoryAddButton.Click += new System.EventHandler(this.categoryAddButtonClick);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.categoryAddButton);
            this.Controls.Add(this.categoriesListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 400);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Категории";
            this.categoryContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox categoriesListBox;
        private System.Windows.Forms.Button categoryAddButton;
        private System.Windows.Forms.ContextMenuStrip categoryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}