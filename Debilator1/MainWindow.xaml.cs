using System.Windows;
using System.Windows.Controls;

// C#

namespace Debilator1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string liczba_wprowadzana;
        string aktualne_działanie;
        string poprzednio_kliknięty_znak;

        decimal wynik;
//        decimal wartość;

        public MainWindow()
        {
            liczba_wprowadzana = "0";
            aktualne_działanie = "";
            poprzednio_kliknięty_znak = "";
            wynik = 0.0m;
            InitializeComponent();
        }

        private bool czy_jest_miejsce()
        {
            if (liczba_wprowadzana.Length > 20)
                return false;
            return true;
        }

        private bool czy_jest_przecinek()
        {
            if (liczba_wprowadzana.Contains(","))
                return true;
            return false;
        }

        private bool czy_jest_pusto()
        {
            if (liczba_wprowadzana.Length == 0)
                return true;
            return false;
        }

        private void wyświetl_liczbę_wprowadzaną()
        {
            wyświetlacz.Text = liczba_wprowadzana;
        }

        private void wyświetl_wynik()
        {
            wyświetlacz.Text = wynik.ToString();
        }

        private void wyświetl_działanie()
        {
            działanie.Text = aktualne_działanie;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var cyferka = ((Button)sender).Content.ToString();
            if (czy_jest_miejsce())
            {
                aktualne_działanie = aktualne_działanie + cyferka;
                wyświetl_działanie();
                if (liczba_wprowadzana == "0")
                {
                    liczba_wprowadzana = cyferka;
                }
                else
                {
                    liczba_wprowadzana = liczba_wprowadzana + cyferka;
                }
            }
            wyświetl_liczbę_wprowadzaną();
        }

        private void wykonaj_ostatnie_działanie()
        {
            if (poprzednio_kliknięty_znak == "+")
            {
                wynik = wynik + decimal.Parse(liczba_wprowadzana);
            }
            else
            {
                wynik = decimal.Parse(liczba_wprowadzana);
            }
            poprzednio_kliknięty_znak = "";
            wyświetl_wynik();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            wykonaj_ostatnie_działanie();

            // aktualne_działanie = aktualne_działanie + liczba_wprowadzana + "+";
            aktualne_działanie = aktualne_działanie + "+";
            wyświetl_działanie();

            liczba_wprowadzana = "0";
            poprzednio_kliknięty_znak = "+";
        }

        private void równaq_Click(object sender, RoutedEventArgs e)
        {
            wykonaj_ostatnie_działanie();

            // aktualne_działanie = aktualne_działanie + liczba_wprowadzana;
            wyświetl_działanie();

            aktualne_działanie = "";

            liczba_wprowadzana = "0";
        }

        private void przecinek_Click(object sender, RoutedEventArgs e)
        {
            if (czy_jest_miejsce() && !czy_jest_przecinek())
            {
                if (czy_jest_pusto())
                {
                    liczba_wprowadzana = "0";
                }
                liczba_wprowadzana = liczba_wprowadzana + ",";
            }
            wyświetl_liczbę_wprowadzaną();
        }

        private void usuń_Click(object sender, RoutedEventArgs e)
        {

            if (!czy_jest_pusto())
            {
                liczba_wprowadzana = liczba_wprowadzana.Substring(0, liczba_wprowadzana.Length - 1);
                if (czy_jest_pusto())
                {
                    liczba_wprowadzana = "0";
                }
            }
            wyświetl_liczbę_wprowadzaną();
        }
    }
}
