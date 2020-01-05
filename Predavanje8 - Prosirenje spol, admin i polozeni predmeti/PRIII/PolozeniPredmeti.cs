using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIII
{
    public partial class PolozeniPredmeti : Form
    {
        private Korisnik korisnik;

        public PolozeniPredmeti()
        {
            InitializeComponent();
        }

        public PolozeniPredmeti(Korisnik korisnik):this()
        {
            this.korisnik = korisnik;
        }

        private void PolozeniPredmeti_Load(object sender, EventArgs e)
        {
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
            LoadData();

            cmbPredmeti.DataSource = DBInMemory.NPP2018;
        }

        void LoadData()
        {
            dgvPolozeniPredmeti.DataSource = null;

            if (korisnik.Polozeni.Count > 0)
                dgvPolozeniPredmeti.DataSource = korisnik.Polozeni;
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            try
            {
                PolozeniPredmet polozeniPredmet = new PolozeniPredmet();
                polozeniPredmet.Id = korisnik.Polozeni.Count + 1;
                polozeniPredmet.Ocjena = int.Parse(txtOcjena.Text);
                polozeniPredmet.Predmet = cmbPredmeti.SelectedItem as Predmet;
                polozeniPredmet.DatumPolaganja = dtDatum.Value;

                korisnik.Polozeni.Add(polozeniPredmet);
                MessageBox.Show("Predmet je uspješno dodan");

                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Vrijednosti nisu validne.");
            }
            
        }
    }
}
