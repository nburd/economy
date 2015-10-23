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

        public PurchaseForm()
        {
            InitializeComponent();
            UpdateComboBox();
            UpdateDataGrid();
        }

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
                    purchaseDataGridView.Rows.Add(purchase.Id,purchase.DateTime, purchase.Source.Name, renameButton, removeButton);
            }
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            using (var db = new BudgetModel())
            {
                var purchase = new Purchase();
                purchase.DateTime = purchaseDateTimePicker.Value;
                var selectedSource = purchaseComboBox.SelectedItem as ListBoxItem;
                purchase.Source = db.Sources.Find(selectedSource.Id);
                db.Purchases.Add(purchase);
                db.SaveChanges();
                IdPurchase = purchase.Id;
                ChekItemForm chekItemForm = new ChekItemForm(IdPurchase);
                chekItemForm.ShowDialog(this);
                UpdateDataGrid();
            }
        }

        private void purchaseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                IdPurchase = (int)(purchaseDataGridView[0, e.RowIndex].Value);
                ChekItemForm chekItemForm = new ChekItemForm(IdPurchase);
                chekItemForm.ShowDialog(this);
            }
            else if(e.ColumnIndex == 4)
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
            UpdateDataGrid();
        }
    }
}
