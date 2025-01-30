using CharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CharpEgitimKampi301.EntiyLayer.Concrete;
using CharpEgitimKampi301BusinessLayer;
using CharpEgitimKampi301BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CatogoryManager(new EFCategoryDal());
            InitializeComponent();
        }

   

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Kayıt Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var deletedValues=_categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme Başarılı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtCategoryId.Text);
            var values=_categoryService.TGetById(id);
            dataGridView1 .DataSource = values; 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*Category category=new Category();
            int updateId=int.Parse(txtCategoryId.Text);
            var updatedValue = _categoryService.TGetById(updatedValue);*/

        }
    }
}
