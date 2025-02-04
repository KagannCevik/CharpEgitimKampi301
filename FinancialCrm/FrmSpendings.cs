using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        void spendingList()
        {
            var value = db.Spendings.Select(x => new
            {
                x.SpendingId,
                x.SpendingTitle,
                x.SpendingAmount,
                x.SpendingDate,
                x.CategoryId,
            }).ToList();
            dataGridView1.DataSource = value;
        }
        void clear()
        {
            txtSpendingId.Clear();
            txtSpendingAmount.Clear();
            txtSpendingTitle.Clear();
            cmbSpendingCategory.SelectedIndex = -1;
        }   
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            spendingList();
            //Category Combobox getirme 
            var valueCategory = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            cmbSpendingCategory.DisplayMember = "CategoryName";
            cmbSpendingCategory.ValueMember = "CategoryId";
            cmbSpendingCategory.DataSource = valueCategory;

        }

        private void btnSpendingCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtSpendingTitle.Text;
                decimal amount = Convert.ToDecimal(txtSpendingAmount.Text);
                DateTime date = dtpSpendingDate.Value;
                int categoryId = Convert.ToInt32(cmbSpendingCategory.SelectedValue);
                Spendings spending = new Spendings();
                spending.SpendingTitle = title;
                spending.SpendingAmount = amount;
                spending.SpendingDate = date;
                spending.CategoryId = categoryId;
                db.Spendings.Add(spending);
                db.SaveChanges();
                MessageBox.Show("Gider Başarıyla Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                spendingList();
                clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Değerleri Kontrol Edin");
            }

        }

        private void btnSpendingDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtSpendingId.Text);
                var removeValue = db.Spendings.Find(id);
                db.Spendings.Remove(removeValue);
                db.SaveChanges();
                MessageBox.Show("Gider Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                spendingList();
                clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Id Kontrol Edin");
            }

        }

        private void btnSpendingUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtSpendingId.Text);
                var updateValue = db.Spendings.Find(id);
                updateValue.SpendingTitle = txtSpendingTitle.Text;
                updateValue.SpendingAmount = Convert.ToDecimal(txtSpendingAmount.Text);
                updateValue.SpendingDate = dtpSpendingDate.Value;
                updateValue.CategoryId = Convert.ToInt32(cmbSpendingCategory.SelectedValue);
                db.SaveChanges();
                MessageBox.Show("Gider Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                spendingList();
                clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgileri Kontrol Edin");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks fr = new FrmBanks();
            fr.Show();
            this.Hide();

        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanksProcess frm = new FrmBanksProcess();
            frm.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashBoard frm = new FrmDashBoard();
            frm.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
