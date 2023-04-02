using System.ComponentModel.DataAnnotations;

namespace RokPrzestepnyApp.Model
{
    public class Uzytkownik
    {
        [Required(ErrorMessage ="Pole jest obowiązkowe"), Range(1899,2022, ErrorMessage = "Oczekiwana wartość z zakresu {1} i {2}.")]
        public int? Rok { set; get; }


        [Required(ErrorMessage = "Pole jest obowiązkowe"), MaxLength(100, ErrorMessage = "Wprowadzone imię musi mieć co najwyżej {1} znaków")]
        public string? Imie { set; get; }



        public string on_Czy_Ona()
        {
            if (this.Imie[this.Imie.Length - 1] == 'a')
            {
                return " urodziła";
            }
            else
            {
                return " urodził";
            }
        }


        public bool czy_Przestepny()
        {
            if ((this.Rok % 4 == 0 && this.Rok % 100 != 0) || this.Rok % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string get_Message()
        {
            string on_czy_ona = on_Czy_Ona();
            if (czy_Przestepny() == true)
            {
                return this.Imie + on_czy_ona + " się w " + this.Rok + " roku. To był rok przestępny.";
            } else
            {
                return this.Imie + on_czy_ona + " się w " + this.Rok + " roku. To nie był rok przestępny.";
            }
        }
    }

}
