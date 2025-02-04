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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        void BillingList()
        {
            var BillList = db.Bills.ToList();
            dataGridView1.DataSource = BillList;
        }
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            BillingList();
            txtBillId.Focus();
        }
        void Clear()
        {
            txtBillId.Clear();
            txtBillMount.Clear();
            txtBillPeriod.Clear();
            txtBillTitle.Clear();
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtBillTitle.Text;
                decimal amount = decimal.Parse(txtBillMount.Text);
                string period = txtBillPeriod.Text;
                Bills bill = new Bills();
                bill.BillTitle = title;
                bill.BillAmount = amount;
                bill.BillPeriod = period;
                db.Bills.Add(bill);
                MessageBox.Show("Ödeme Başarılı Bir Şekilde Eklendi", "Ödeme&Farutalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.SaveChanges();
                Clear();
                BillingList();
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgileri Eksiksiz Doldurduğunuzdan Emin Olun.");
                
            }
           

        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            BillingList();
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            try
            {
                int billId = int.Parse(txtBillId.Text);
                var removaValue = db.Bills.Find(billId);
                db.Bills.Remove(removaValue);
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi","Fatura Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.SaveChanges();
                Clear();
                BillingList();

            }
            catch (Exception)
            {
                MessageBox.Show("Id Doğru Girdiğinizden Emin Olun");
                
            }
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBillId.Text);
                var updateValue = db.Bills.Find(id);
                updateValue.BillTitle = txtBillTitle.Text;
                updateValue.BillAmount = decimal.Parse(txtBillMount.Text);
                updateValue.BillPeriod = txtBillPeriod.Text;
                db.SaveChanges();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi", "Fatura Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                BillingList();
                

            }
            catch (Exception)
            {
                MessageBox.Show("Bilgileri Eksiksiz Doldurduğunuzdan Emin Olun.");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks fr = new FrmBanks();
            fr.Show();
            this.Hide();
        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashBoard fr = new FrmDashBoard();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanksProcess fr = new FrmBanksProcess();
            fr.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSpendings fr = new FrmSpendings();
            fr.Show();
            this.Hide();
        }
    }
}
