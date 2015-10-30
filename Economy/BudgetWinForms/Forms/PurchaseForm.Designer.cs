namespace BudgetWinForms
{
    partial class PurchaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseForm));
            this.purchaseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.purchaseComboBox = new System.Windows.Forms.ComboBox();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.purchaseDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rename = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // purchaseDateTimePicker
            // 
            this.purchaseDateTimePicker.Location = new System.Drawing.Point(96, 33);
            this.purchaseDateTimePicker.MaximumSize = new System.Drawing.Size(180, 20);
            this.purchaseDateTimePicker.MinimumSize = new System.Drawing.Size(180, 20);
            this.purchaseDateTimePicker.Name = "purchaseDateTimePicker";
            this.purchaseDateTimePicker.Size = new System.Drawing.Size(180, 20);
            this.purchaseDateTimePicker.TabIndex = 0;
            // 
            // purchaseComboBox
            // 
            this.purchaseComboBox.FormattingEnabled = true;
            this.purchaseComboBox.Location = new System.Drawing.Point(295, 32);
            this.purchaseComboBox.MaximumSize = new System.Drawing.Size(180, 0);
            this.purchaseComboBox.MinimumSize = new System.Drawing.Size(180, 0);
            this.purchaseComboBox.Name = "purchaseComboBox";
            this.purchaseComboBox.Size = new System.Drawing.Size(180, 21);
            this.purchaseComboBox.TabIndex = 1;
            // 
            // purchaseButton
            // 
            this.purchaseButton.Location = new System.Drawing.Point(228, 69);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(123, 23);
            this.purchaseButton.TabIndex = 2;
            this.purchaseButton.Text = "Внести позиции";
            this.purchaseButton.UseVisualStyleBackColor = true;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButtonClick);
            // 
            // purchaseDataGridView
            // 
            this.purchaseDataGridView.AllowUserToAddRows = false;
            this.purchaseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchaseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Date,
            this.Source,
            this.Rename,
            this.Remove});
            this.purchaseDataGridView.Location = new System.Drawing.Point(12, 134);
            this.purchaseDataGridView.Name = "purchaseDataGridView";
            this.purchaseDataGridView.Size = new System.Drawing.Size(545, 199);
            this.purchaseDataGridView.TabIndex = 3;
            this.purchaseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchaseDataGridViewCellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 150;
            // 
            // Source
            // 
            this.Source.HeaderText = "Источник";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 150;
            // 
            // Rename
            // 
            this.Rename.HeaderText = "Изменить";
            this.Rename.Name = "Rename";
            this.Rename.ReadOnly = true;
            this.Rename.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rename.Text = "Изменить";
            this.Rename.UseColumnTextForButtonValue = true;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Удалить";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove.Text = "Удалить";
            this.Remove.UseColumnTextForButtonValue = true;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(558, 345);
            this.Controls.Add(this.purchaseDataGridView);
            this.Controls.Add(this.purchaseButton);
            this.Controls.Add(this.purchaseComboBox);
            this.Controls.Add(this.purchaseDateTimePicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Покупки";
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker purchaseDateTimePicker;
        private System.Windows.Forms.ComboBox purchaseComboBox;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.DataGridView purchaseDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewButtonColumn Rename;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}