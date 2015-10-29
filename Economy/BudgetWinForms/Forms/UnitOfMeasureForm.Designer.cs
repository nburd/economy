namespace BudgetWinForms
{
    partial class UnitOfMeasureForm
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
            this.unitOfMeasureListBox = new System.Windows.Forms.ListBox();
            this.unitOfMeasureContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitOfMeasureAddButton = new System.Windows.Forms.Button();
            this.unitOfMeasureContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // unitOfMeasureListBox
            // 
            this.unitOfMeasureListBox.ContextMenuStrip = this.unitOfMeasureContextMenuStrip;
            this.unitOfMeasureListBox.FormattingEnabled = true;
            this.unitOfMeasureListBox.Location = new System.Drawing.Point(13, 13);
            this.unitOfMeasureListBox.Name = "unitOfMeasureListBox";
            this.unitOfMeasureListBox.Size = new System.Drawing.Size(188, 173);
            this.unitOfMeasureListBox.TabIndex = 0;
            // 
            // unitOfMeasureContextMenuStrip
            // 
            this.unitOfMeasureContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.unitOfMeasureContextMenuStrip.Name = "unitOfMeasureContextMenuStrip";
            this.unitOfMeasureContextMenuStrip.Size = new System.Drawing.Size(129, 48);
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
            // unitOfMeasureAddButton
            // 
            this.unitOfMeasureAddButton.Location = new System.Drawing.Point(13, 193);
            this.unitOfMeasureAddButton.Name = "unitOfMeasureAddButton";
            this.unitOfMeasureAddButton.Size = new System.Drawing.Size(75, 23);
            this.unitOfMeasureAddButton.TabIndex = 1;
            this.unitOfMeasureAddButton.Text = "Добавить";
            this.unitOfMeasureAddButton.UseVisualStyleBackColor = true;
            this.unitOfMeasureAddButton.Click += new System.EventHandler(this.unitOfMeasureAddButtonClick);
            // 
            // UnitOfMeasureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.unitOfMeasureAddButton);
            this.Controls.Add(this.unitOfMeasureListBox);
            this.Name = "UnitOfMeasureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Единицы измерения";
            this.unitOfMeasureContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox unitOfMeasureListBox;
        private System.Windows.Forms.Button unitOfMeasureAddButton;
        private System.Windows.Forms.ContextMenuStrip unitOfMeasureContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}