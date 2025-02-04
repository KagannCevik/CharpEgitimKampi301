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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if(db.Users.Where(x=>x.UserName==TxtUserName.Text&&x.Password==txtUserPassword.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Giriş Başarılı","Giriş",MessageBoxButtons.OK,MessageBoxIcon.Information);
                FrmBanks fr=new FrmBanks();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }
          
        }
    }
}
