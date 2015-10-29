using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetWinForms
{
    public partial class PurchaseForm : Form
    {
        public int IdPurchase { get; private set; }

        #region Constructors

        public PurchaseForm()
        {
            InitializeComponent();
            UpdateComboBox();
            UpdateDataGrid();
        }

        #endregion
        #region Metods

        private void UpdateComboBox()
        {
            using (var db = new BudgetModel())
            {
                var sources = db.Sources.ToList();
                foreach(var source in sources)
                {
                    var item = new ListBoxItem(source.Id, source.Name);
                    purchaseComboBox.Items.Add(item);
                }
                purchaseComboBox.Text = "Выберите источник";
            }
        }
        
        private void UpdateDataGrid()
        {
            purchaseDataGridView.Rows.Clear();
            using (var db = new BudgetModel())
            {
                var purchases = db.Purchases.ToList();
                var renameButton = new DataGridViewButtonCell();
                var removeButton = new DataGridViewButtonCell();
                foreach (var purchase in purchases)
                    purchaseDataGridView.Rows.Add(
                        purchase.Id,
                        purchase.DateTime, 
                        purchase.Source.Name, 
                        renameButton, 
                        removeButton
                    );
            }
        }

        #endregion
        #region Events Handlers

        private void purchaseButtonClick(object sender, EventArgs e)
        {
            using (var db = new BudgetModel())
            {
                var purchase = new Purchase();
                purchase.DateTime = purchaseDateTimePicker.Value;
                var selectedSource = purchaseComboBox.SelectedItem as ListBoxItem;
                if (selectedSource == null)
                {
                    MessageBox.Show("Выберите источник");
                    return;
                }
                purchase.Source = db.Sources.Find(selectedSource.Id);
                db.Purchases.Add(purchase);
                db.SaveChanges();
                IdPurchase = purchase.Id;
                ChekItemForm chekItemForm = new ChekItemForm(IdPurchase);
                if (chekItemForm.ShowDialog(this) == DialogResult.OK)
                    UpdateDataGrid();
                else
                {
                    db.Purchases.Remove(purchase);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
        }

        private void purchaseDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 3)
            {
                IdPurchase = (int)(purchaseDataGridView[0, e.RowIndex].Value);
                ChekItemForm chekItemForm = new ChekItemForm(IdPurchase);
                chekItemForm.ShowDialog(this);
            }
            else if(e.ColumnIndex == 4)
            {
                var res = MessageBox.Show("Удалить?", "Удаление элемента", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) return;
                else
                {
                    IdPurchase = (int)(purchaseDataGridView[0, e.RowIndex].Value);
                    using (var db = new BudgetModel())
                    {
                        var removePurchase = db.Purchases.Find(IdPurchase);
                        var removeChekItems = db.Purchases.Find(IdPurchase).ChekItems.ToList();
                        foreach (var removeChekItem in removeChekItems)
                            db.ChekItems.Remove(removeChekItem);
                        db.Purchases.Remove(removePurchase);
                        db.SaveChanges();
                    }
                }
            }
            UpdateDataGrid();
        }

        #endregion
    }
}
