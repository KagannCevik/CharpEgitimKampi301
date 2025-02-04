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
    public partial class FrmBanksProcess : Form
    {
        public FrmBanksProcess()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        void BankProcessList()
        {
            var BankProcessList = db.BankProcesses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.Amount,
                x.ProcessDate,
                x.BankId
            }).ToList();
            dataGridView1.DataSource = BankProcessList;
        }
        //Combobax Banka Getirme İşlemi
        void BankGet()
        {
            var values = db.Banks.Select(x => new
            {
                x.BankId,
                x.BankTitle
            }).ToList();
            cmbBanks.DisplayMember = "BankTitle"; // Kullanıcıya gözükecek alan
            cmbBanks.ValueMember = "BankId"; // ID'yi saklayacak alan
            cmbBanks.DataSource = values;
        }
        private void FrmBanksProcess_Load(object sender, EventArgs e)
        {
            BankProcessList();
            BankGet();

        }

        private void btnBankProcessList_Click(object sender, EventArgs e)
        {
            BankProcessList();
        }
        void clear()
        {
            txtBankProcessId.Clear();
            txtBankProcessAmount.Clear();
            txtBankProcessDescription.Clear();
            mskBankProcessDate.Clear();
            cmbType.SelectedIndex = -1;
            cmbBanks.SelectedIndex = -1;

        }
        private void btnBankProcessCrate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBankProcessId.Text);
                var updateValue = db.BankProcesses.Find(id);
                var description = txtBankProcessDescription.Text;
                DateTime date = DateTime.Parse(mskBankProcessDate.Text);
                var amount = decimal.Parse(txtBankProcessAmount.Text);
                string type = cmbType.Text;
                int bankId = Convert.ToInt32(cmbBanks.SelectedValue); // Banka ID'sini al
                db.SaveChanges();
                MessageBox.Show("İşlem Başarılı Bir Şekilde Güncellendi", "Banka İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankProcessList();
                clear();


            }
            catch (Exception)
            {
                MessageBox.Show("Id değerini kontrol ediniz");

            }

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBankProcessDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBankProcessId.Text);
                var deletedValue = db.BankProcesses.Find(id);
                db.BankProcesses.Remove(deletedValue);
                db.SaveChanges();
                MessageBox.Show("İşlem Başarılı Bir Şekilde Silindi", "Banka İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankProcessList();
                clear();


            }
            catch (Exception)
            {

                MessageBox.Show("Id değerini kontrol ediniz");
            }
        }

        private void btnBankProcessUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBankProcessId.Text);
                var updateValue = db.BankProcesses.Find(id);
                var description = txtBankProcessDescription.Text;
                DateTime date = DateTime.Parse(mskBankProcessDate.Text);
                var amount = decimal.Parse(txtBankProcessAmount.Text);
                string type = cmbType.Text;
                int bankId = Convert.ToInt32(cmbBanks.SelectedValue); // Banka ID'sini al
                updateValue.Description = description;
                updateValue.Amount = amount;
                updateValue.ProcessDate = date;
                updateValue.BankId = bankId;
                updateValue.ProcessType = type;
                db.SaveChanges();
                MessageBox.Show("İşlem Başarılı Bir Şekilde Güncellendi", "Banka İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankProcessList();
                clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Id değerini kontrol ediniz");

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
            FrmBilling fr = new FrmBilling();
            fr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashBoard fr = new FrmDashBoard();
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
