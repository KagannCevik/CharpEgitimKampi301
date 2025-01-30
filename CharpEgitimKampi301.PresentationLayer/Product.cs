using CharpEgitimKampi301.DataAccessLayer.EntityFramework;
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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        ProductManager productManager = new ProductManager(new EFProductDal());

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = productManager.TGetAll();
            dataGridView1.DataSource = values;
        }
    }
}
