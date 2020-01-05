using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIII
{
    class Validator
    {
        public static string msgObaveznoPolje = "Polje je obavezno";
        public static string msgObaveznaSlika = "Slika je obavezna";
        public static string msgPredefinisanaVrijednost = "Obavezno je koristiti jednu od predefinisanih vrijednosti";

        public static bool ObaveznoPolje(Control control, ErrorProvider err, string msg)
        {
            bool validno = true;

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
                validno = false;
            else if (control is ComboBox && (control as ComboBox).SelectedIndex == -1)
                validno = false;
            else if (control is PictureBox && (control as PictureBox).Image == null)
                validno = false;

            if(!validno)
            {
                err.SetError(control, msg);
                return false;
            }

            err.Clear();
            return true;
        }
    }
}
