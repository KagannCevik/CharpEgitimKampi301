﻿using System;
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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        void List()
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }
        void Clear()
        {
            txtCity.Clear();
            txtCountry.Clear();
            txtDayNight.Clear();
            txtId.Clear();
            txtPrice.Clear();

            nudCapacity.Value = int.Parse("0");
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                Fullname = x.GuideName + " " + x.GuideSurname,
                x.GuideId

            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            List();
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var valueremove = db.Location.Find(id);
            db.Location.Remove(valueremove);
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarıyla Silindi");
            List();
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtId.Text);
            var updatavalue=db.Location.Find(id);
            updatavalue.DayNight = txtDayNight.Text;
            updatavalue.Country= txtCountry.Text;
            updatavalue.City= txtCity.Text;
            updatavalue.DayNight= txtDayNight.Text;
            updatavalue.Price= decimal.Parse(txtPrice.Text);
            updatavalue.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            Clear();
            List();


        }
    }
}
