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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        void categoriesList()
        {
            try
            {
                var List1 = db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();
                dataGridView1.DataSource = List1;
            }
            catch (Exception)
            {

                MessageBox.Show("Listele Hatası");
            }
        }
        void Clear()
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
           categoriesList();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var List=db.Categories.Select(x=>new { x.CategoryId, x.CategoryName }).ToList();
            dataGridView1.DataSource = List;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text != "")
                {
                    var categoryName = txtCategoryName.Text;
                    Categories category = new Categories();
                    category.CategoryName = categoryName;
                    db.Categories.Add(category);
                    db.SaveChanges();
                    MessageBox.Show("Kategori Başarılı Bir Şekilde Eklendi", "Kategori", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    categoriesList();
                    Clear();
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Category Adını doğru giriniz");
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(txtCategoryId.Text);
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarılı Bir Şekilde Silindi", "Kategori", MessageBoxButtons.OK, MessageBoxIcon.Information);
                categoriesList();
                Clear();

            }
            catch (Exception)
            {

                MessageBox.Show("Category Id doğru giriniz");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(txtCategoryId.Text);
                var category = db.Categories.Find(id);
                category.CategoryName = txtCategoryName.Text;
                db.SaveChanges();
                MessageBox.Show("Kategori Başarılı Bir Şekilde Güncellendi", "Kategori", MessageBoxButtons.OK, MessageBoxIcon.Information);
                categoriesList();
                Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Category Id Ve Adını doğru giriniz");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks fr= new FrmBanks();
            fr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling fr = new FrmBilling();
            fr.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashBoard frm= new FrmDashBoard();
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
