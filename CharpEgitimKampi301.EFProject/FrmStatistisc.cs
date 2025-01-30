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
    public partial class FrmStatistisc : Form
    {
        public FrmStatistisc()
        {
            InitializeComponent();
        }

        private void lblLokasyonSayısı_Click(object sender, EventArgs e)
        {

        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistisc_Load(object sender, EventArgs e)
        {
            lblLokasyonSayisi.Text = db.Location.Count().ToString();
            label3.Text = db.Location.Sum(x => x.Capacity).ToString();
            label5.Text = db.Guide.Count().ToString();
            label7.Text = db.Location.Average(x => x.Capacity).ToString();
            label9.Text = db.Location.Average(x => x.Price).ToString();
            int lastCountryId = db.Location.Max(x => x.LocationId);
            label11.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(x => x.Country).FirstOrDefault();
            var capacityKapadokya = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault();
            label13.Text = capacityKapadokya.ToString();
            label15.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            /*var romaRehber = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
             label17.Text=db.Guide.Where(x=>x.GuideId==romaRehber).Select(y=>y.GuideName).FirstOrDefault().ToString();*/
            var maxCapacity = db.Location.Max(x => x.Capacity);
            label19.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();
            var maxprice = db.Location.Max(x => x.Price);
            label21.Text=db.Location.Where(x=>x.Price==maxprice).Select(y=>y.City).FirstOrDefault().ToString();
            
            var aysegüllocation=db.Location.Where(x=>x.GuideId==2).Count().ToString();
            label23.Text=aysegüllocation.ToString();

        }
    }
}
