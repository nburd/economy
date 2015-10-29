namespace BudgetWinForms
{
    partial class SourceForm
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
            this.sourcesListBox = new System.Windows.Forms.ListBox();
            this.sourceContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceAddButton = new System.Windows.Forms.Button();
            this.sourceContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourcesListBox
            // 
            this.sourcesListBox.ContextMenuStrip = this.sourceContextMenuStrip;
            this.sourcesListBox.FormattingEnabled = true;
            this.sourcesListBox.Location = new System.Drawing.Point(13, 13);
            this.sourcesListBox.Name = "sourcesListBox";
            this.sourcesListBox.Size = new System.Drawing.Size(184, 186);
            this.sourcesListBox.TabIndex = 0;
            // 
            // sourceContextMenuStrip
            // 
            this.sourceContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.sourceContextMenuStrip.Name = "sourceContextMenuStrip";
            this.sourceContextMenuStrip.Size = new System.Drawing.Size(129, 48);
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
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // sourceAddButton
            // 
            this.sourceAddButton.Location = new System.Drawing.Point(13, 206);
            this.sourceAddButton.Name = "sourceAddButton";
            this.sourceAddButton.Size = new System.Drawing.Size(75, 23);
            this.sourceAddButton.TabIndex = 1;
            this.sourceAddButton.Text = "Добавить";
            this.sourceAddButton.UseVisualStyleBackColor = true;
            this.sourceAddButton.Click += new System.EventHandler(this.sourceAddButtonClick);
            // 
            // SourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sourceAddButton);
            this.Controls.Add(this.sourcesListBox);
            this.Name = "SourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Источники";
            this.sourceContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox sourcesListBox;
        private System.Windows.Forms.Button sourceAddButton;
        private System.Windows.Forms.ContextMenuStrip sourceContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}