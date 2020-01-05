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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private bool Validiraj()
        {
            return Validator.ObaveznoPolje(txtKorisnickoIme, err, Validator.msgObaveznoPolje) &&
                Validator.ObaveznoPolje(txtLozinka, err, Validator.msgObaveznoPolje);
        }
        private void btnPrijava_Click(object sender, EventArgs e)
        { 
            if (Validiraj())
            {
                foreach (var korisnik in DBInMemory.registrovaniKorisnici)
                {

                    if (korisnik.KorisnickoIme == txtKorisnickoIme.Text && korisnik.Lozinka == txtLozinka.Text)
                    {
                        
                        MessageBox.Show($"Dobrodošao/la {korisnik.KorisnickoIme}");

                        return;
                    }
                }

                MessageBox.Show("Podaci nisu validni.");
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

        //private void label4_Click(object sender, EventArgs e)
        //{
        //    SignUp registracija = new SignUp();
        //    registracija.ShowDialog();
        //}

        //private void label5_Click(object sender, EventArgs e)
        //{
        //    KorisniciAdmin adminMode = new KorisniciAdmin();
        //    adminMode.ShowDialog();
        //}

    }
}
