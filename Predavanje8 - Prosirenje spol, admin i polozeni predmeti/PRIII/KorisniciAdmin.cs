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
    public partial class KorisniciAdmin : Form
    {
        public KorisniciAdmin()
        {
            InitializeComponent();
        }

        private void KorisniciAdmin_Load(object sender, EventArgs e)
        {
            dgvKorisnici.AutoGenerateColumns = false;

            if (DBInMemory.registrovaniKorisnici.Count > 0)
                dgvKorisnici.DataSource = DBInMemory.registrovaniKorisnici;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            SignUp registracija = new SignUp();

            if (registracija.ShowDialog() == DialogResult.OK)
                DataUpdate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Korisnik> filtrirano =
                DBInMemory.registrovaniKorisnici.Where
                    (korisnik => korisnik.Ime.ToLower().Contains(txtPretraga.Text) ||
                    korisnik.Prezime.ToLower().Contains(txtPretraga.Text)).ToList();

            DataUpdate(filtrirano);
        }

        private void DataUpdate(List<Korisnik> korisnici = null)
        {
            dgvKorisnici.DataSource = null;
            dgvKorisnici.DataSource = korisnici ?? DBInMemory.registrovaniKorisnici;
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvKorisnici.SelectedRows.Count > 0)
            {
                Korisnik korisnik = dgvKorisnici.SelectedRows[0].DataBoundItem as Korisnik;

                if (korisnik != null)
                {
                    Form forma = null;

                    if (e.ColumnIndex == 5)
                        forma = new PolozeniPredmeti(korisnik);
                    else
                        forma = new SignUp(korisnik);

                    forma.ShowDialog();
                    DataUpdate();
                }
            }
        }
    }
}
