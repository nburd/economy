namespace BudgetWinForms
{
    partial class AddItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemForm));
            this.addItemTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addItemTextBox
            // 
            this.addItemTextBox.Location = new System.Drawing.Point(24, 36);
            this.addItemTextBox.Name = "addItemTextBox";
            this.addItemTextBox.Size = new System.Drawing.Size(180, 20);
            this.addItemTextBox.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(156, 80);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(48, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AddItemForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 161);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.addItemTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(830, 360);
            this.MaximumSize = new System.Drawing.Size(250, 200);
            this.MinimumSize = new System.Drawing.Size(250, 200);
            this.Name = "AddItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Добавление элемента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addItemTextBox;
        private System.Windows.Forms.Button OkButton;
    }
}