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
    public partial class SignUp : Form
    {
        private Korisnik korisnik;
        private bool Edit { get; set; }

        private string GenerisiLozinku()
        {
            int duzina = 7;
            string tekst = string.Empty;
            string dozvoljeni = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ1!23#4$5%6&7/8(9)0";

            Random rand = new Random();

            while (tekst.Length < duzina)
            {
                int lokacija = rand.Next(0, dozvoljeni.Length);
                tekst += dozvoljeni[lokacija];
            }

            return tekst;
        }
        public SignUp()
        {
            InitializeComponent();
            korisnik = new Korisnik();

            txtLozinka.Text = GenerisiLozinku();

            cmbSpol.DataSource = DBInMemory.Spolovi;
        }

        public SignUp(Korisnik korisnik):this()
        {
            this.korisnik = korisnik;
            UcitajVrijednosti();

            Edit = true;
        }
        private void UcitajVrijednosti()
        {
            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtKorisnickoIme.Text = korisnik.KorisnickoIme;
            txtLozinka.Text = korisnik.Lozinka;
            cmbSpol.SelectedItem = korisnik.Spol;
            cbAdmin.Checked = korisnik.Admin;
            pbxSlikaKorisnika.Image = korisnik.Slika;
        }

        private bool Validiraj()
        {
            return Validator.ObaveznoPolje(txtIme, err, Validator.msgObaveznoPolje) &&
                Validator.ObaveznoPolje(txtPrezime, err, Validator.msgObaveznoPolje) &&
                Validator.ObaveznoPolje(pbxSlikaKorisnika, err, Validator.msgObaveznaSlika) &&
                Validator.ObaveznoPolje(cmbSpol, err, Validator.msgPredefinisanaVrijednost);
        }
        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            if(Validiraj())
            {
                korisnik.Ime = txtIme.Text;
                korisnik.Prezime = txtPrezime.Text;
                korisnik.KorisnickoIme = txtKorisnickoIme.Text;
                korisnik.Lozinka = txtLozinka.Text;
                korisnik.Slika = pbxSlikaKorisnika.Image;
                korisnik.Spol = cmbSpol.SelectedItem.ToString();
                korisnik.Admin = cbAdmin.Checked;

                if(!Edit)
                {
                    korisnik.ID = DBInMemory.registrovaniKorisnici.Count + 1;

                    DBInMemory.registrovaniKorisnici.Add(korisnik);

                    MessageBox.Show("Podaci uspješno dodani");
                }
                else
                    MessageBox.Show("Podaci uspješno editovani");

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            txtKorisnickoIme.Text = $"{txtIme.Text.ToLower()}.{txtPrezime.Text.ToLower()}";
        }
        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            txtKorisnickoIme.Text = $"{txtIme.Text.ToLower()}.{txtPrezime.Text.ToLower()}";
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            try
            {
                if(ofdSlika.ShowDialog() == DialogResult.OK)
                {
                    string putanja = ofdSlika.FileName;

                    Image slika = Image.FromFile(putanja);
                    pbxSlikaKorisnika.Image = slika;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            char prazan = new char();

            if (txtLozinka.PasswordChar == prazan)
                txtLozinka.PasswordChar = '*';
            else
                txtLozinka.PasswordChar = prazan;
        }
    }
}
