using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarıyla Eklendi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var removevalue = db.Guide.Find(id);
            db.Guide.Remove(removevalue);
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarıyla Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var updatevalue = db.Guide.Find(id);
            updatevalue.GuideName = txtName.Text;
            updatevalue.GuideSurname= txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarıyla Güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var GetById=db.Guide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = GetById;
            db.SaveChanges();
        }
    }
}
