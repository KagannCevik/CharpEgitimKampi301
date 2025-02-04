﻿using FinancialCrm.Models;
using System.Linq;
using System.Windows.Forms;
namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, System.EventArgs e)
        {
            //Ziraat Bankası Balance
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(
                x => x.BankBalance).FirstOrDefault();
            //Vakıfbank Balance
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıfbank").Select(
                x => x.BankBalance).FirstOrDefault();
            //İş Bankası Balance
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(
                x => x.BankBalance).FirstOrDefault();
            //Balance Tutarları Gösterim 
            lblZiraatBankBalance.Text = ziraatBankBalance + " ₺";
            lblVakifbankBalance.Text = vakifBankBalance + " ₺"; ;
            lblisBankasiBalance.Text = isBankBalance + " ₺"; ;

            //BankProcess Son 5 İşlem
            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text=bankProcess1.Description+" " + bankProcess1.Amount + " ₺"+" "+bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " ₺" + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " ₺" + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " ₺" + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " ₺" + " " + bankProcess5.ProcessDate;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            FrmBilling fr1 = new FrmBilling();
            fr1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            FrmDashBoard fr = new FrmDashBoard();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            FrmBanksProcess fr = new FrmBanksProcess();
            fr.Show();
            this.Hide();

        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            FrmSpendings fr = new FrmSpendings();
            fr.Show();
            this.Hide();
        }
    }
}
