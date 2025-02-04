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
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;
        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            //Toplam Bakiye Hesaplama İşlemi;
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺";

            //Son Gelen Banka İşlemi
            var lastBankProcessAmount=db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=>y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + " ₺";

            //Chart1 Kodları
            var bankData = db.Banks.Select(x =>new 
            {
                x.BankTitle,
                x.BankBalance
                
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach(var item in bankData)
            {
               series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //Char2 Kodları
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            foreach(var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Faturaların Sırayla Gösterilmesi İşlemi;
            count++;
            if (count % 4 == 2)
            {
                var electricPrice = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle1.Text = "Elektrik Faturası";
                lblBillAmount.Text = electricPrice.ToString() + " ₺";

            }

            if (count % 4 == 3)
            {
                var dogalgazPrice = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle1.Text = "Doğalgaz Faturası ";
                lblBillAmount.Text = dogalgazPrice.ToString() + " ₺";

            }
            if (count % 4 == 0)
            {
                var suPrice = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle1.Text = "Su Faturası";
                lblBillAmount.Text = suPrice.ToString() + " ₺";

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling fr1 = new FrmBilling();
            fr1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks banks = new FrmBanks();
            banks.Show();
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
