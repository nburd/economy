namespace BudgetWinForms
{
    partial class ChekItemForm
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
            this.chekItemDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rename = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chekCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.chekGoodsListBox = new System.Windows.Forms.ListBox();
            this.chekPriceTextBox = new System.Windows.Forms.TextBox();
            this.chekQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chekAddButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chekItemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // chekItemDataGridView
            // 
            this.chekItemDataGridView.AllowUserToAddRows = false;
            this.chekItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chekItemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Category,
            this.GoodsItem,
            this.Price,
            this.Quantity,
            this.Rename,
            this.Remove});
            this.chekItemDataGridView.Location = new System.Drawing.Point(12, 246);
            this.chekItemDataGridView.Name = "chekItemDataGridView";
            this.chekItemDataGridView.Size = new System.Drawing.Size(646, 134);
            this.chekItemDataGridView.TabIndex = 0;
            this.chekItemDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.chekItemDataGridView_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Category
            // 
            this.Category.HeaderText = "Категории";
            this.Category.Name = "Category";
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GoodsItem
            // 
            this.GoodsItem.HeaderText = "Товары";
            this.GoodsItem.Name = "GoodsItem";
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена ";
            this.Price.Name = "Price";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Количество";
            this.Quantity.Name = "Quantity";
            // 
            // Rename
            // 
            this.Rename.HeaderText = "Изменить";
            this.Rename.Name = "Rename";
            this.Rename.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rename.Text = "Изменить";
            this.Rename.UseColumnTextForButtonValue = true;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Удалить";
            this.Remove.Name = "Remove";
            this.Remove.Text = "Удалить";
            this.Remove.UseColumnTextForButtonValue = true;
            // 
            // chekCategoryComboBox
            // 
            this.chekCategoryComboBox.FormattingEnabled = true;
            this.chekCategoryComboBox.Location = new System.Drawing.Point(13, 13);
            this.chekCategoryComboBox.Name = "chekCategoryComboBox";
            this.chekCategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.chekCategoryComboBox.TabIndex = 1;
            this.chekCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.chekCategoryComboBox_SelectedIndexChanged);
            // 
            // chekGoodsListBox
            // 
            this.chekGoodsListBox.FormattingEnabled = true;
            this.chekGoodsListBox.Location = new System.Drawing.Point(140, 12);
            this.chekGoodsListBox.Name = "chekGoodsListBox";
            this.chekGoodsListBox.Size = new System.Drawing.Size(136, 186);
            this.chekGoodsListBox.TabIndex = 2;
            // 
            // chekPriceTextBox
            // 
            this.chekPriceTextBox.Location = new System.Drawing.Point(357, 44);
            this.chekPriceTextBox.Name = "chekPriceTextBox";
            this.chekPriceTextBox.Size = new System.Drawing.Size(121, 20);
            this.chekPriceTextBox.TabIndex = 3;
            // 
            // chekQuantityTextBox
            // 
            this.chekQuantityTextBox.Location = new System.Drawing.Point(357, 71);
            this.chekQuantityTextBox.Name = "chekQuantityTextBox";
            this.chekQuantityTextBox.Size = new System.Drawing.Size(121, 20);
            this.chekQuantityTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Цена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество";
            // 
            // chekAddButton
            // 
            this.chekAddButton.Location = new System.Drawing.Point(357, 217);
            this.chekAddButton.Name = "chekAddButton";
            this.chekAddButton.Size = new System.Drawing.Size(75, 23);
            this.chekAddButton.TabIndex = 7;
            this.chekAddButton.Text = "Добавить";
            this.chekAddButton.UseVisualStyleBackColor = true;
            this.chekAddButton.Click += new System.EventHandler(this.chekAddButton_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(513, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(438, 217);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ChekItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 514);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chekAddButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chekQuantityTextBox);
            this.Controls.Add(this.chekPriceTextBox);
            this.Controls.Add(this.chekGoodsListBox);
            this.Controls.Add(this.chekCategoryComboBox);
            this.Controls.Add(this.chekItemDataGridView);
            this.Name = "ChekItemForm";
            this.Text = "CheckItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.chekItemDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView chekItemDataGridView;
        private System.Windows.Forms.ComboBox chekCategoryComboBox;
        private System.Windows.Forms.ListBox chekGoodsListBox;
        private System.Windows.Forms.TextBox chekPriceTextBox;
        private System.Windows.Forms.TextBox chekQuantityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chekAddButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewButtonColumn Rename;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.Button saveButton;
    }
}