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
        string liczbaWprowadzana;
        string wszystkieDziałaniaBezLiczbyWprowadzanej;
        string poprzednioKlikniętyZnakDziałania;
        bool liczbaZostałaOstatnioWpisana;

        decimal wynik;


        public MainWindow()
        {
            usuńWszysko();
            InitializeComponent();
        }

        private void usuńWszysko()
        {
            liczbaWprowadzana = "0";
            wszystkieDziałaniaBezLiczbyWprowadzanej = "";
            poprzednioKlikniętyZnakDziałania = "";
            wynik = 0.0m;
            liczbaZostałaOstatnioWpisana = false;
        }

        private bool jestMiejsce()
        {
            if (liczbaWprowadzana.Length > 20)
                return false;
            return true;
        }

        private bool jestPrzecinek()
        {
            if (liczbaWprowadzana.Contains(","))
                return true;
            return false;
        }

        private bool jestPusto()
        {
            if (liczbaWprowadzana.Length == 0)
                return true;
            return false;
        }

        private void wyświetlLiczbęWprowadzaną()
        {
            wyświetlacz.Text = liczbaWprowadzana;
        }

        private void wyświetlWynik()
        {
            wyświetlacz.Text = wynik.ToString();
        }

        private void wyświetlDziałanie()
        {
            if (liczbaZostałaOstatnioWpisana)
            {
                działanie.Text = wszystkieDziałaniaBezLiczbyWprowadzanej + liczbaWprowadzana;
            }
            else
            {
                działanie.Text = wszystkieDziałaniaBezLiczbyWprowadzanej;
            }
        }

        private void wykonajOstatnieDziałanie()
        {
            if (poprzednioKlikniętyZnakDziałania == "+")
            {
                wynik = wynik + decimal.Parse(liczbaWprowadzana);
            }
            else if (poprzednioKlikniętyZnakDziałania == "-")
            {
                wynik = wynik - decimal.Parse(liczbaWprowadzana);
            }
            else if (poprzednioKlikniętyZnakDziałania == "")
            {
                wynik = decimal.Parse(liczbaWprowadzana);
            }
            wszystkieDziałaniaBezLiczbyWprowadzanej = wszystkieDziałaniaBezLiczbyWprowadzanej + liczbaWprowadzana;
            wyświetlWynik();
        }

        private void cyferka_Click(object sender, RoutedEventArgs e)
        {
            string cyferkaLubPrzecinek = ((Button)sender).Content.ToString();
            if (poprzednioKlikniętyZnakDziałania == "=")
            {
                wszystkieDziałaniaBezLiczbyWprowadzanej = "";
                poprzednioKlikniętyZnakDziałania = "";
            }
            if (jestMiejsce())
            {
                if (liczbaWprowadzana == "0" && cyferkaLubPrzecinek != ",")
                {
                    liczbaWprowadzana = "";
                }

                liczbaWprowadzana = liczbaWprowadzana + cyferkaLubPrzecinek;
                liczbaZostałaOstatnioWpisana = true;
            }
            wyświetlLiczbęWprowadzaną();
            wyświetlDziałanie();
        }

        private void przecinek_Click(object sender, RoutedEventArgs e)
        {
            if (!jestPrzecinek())
            {
                if (jestPusto())
                {
                    liczbaWprowadzana = "0";
                }
                cyferka_Click(sender, e);
            }
        }

        private void plusLubMinus_Click(object sender, RoutedEventArgs e)
        {
            string znakDziałania = ((Button)sender).Content.ToString();
            if (liczbaZostałaOstatnioWpisana)
            {
                wykonajOstatnieDziałanie();

                wszystkieDziałaniaBezLiczbyWprowadzanej = wszystkieDziałaniaBezLiczbyWprowadzanej + znakDziałania;

                liczbaWprowadzana = "0";
                poprzednioKlikniętyZnakDziałania = znakDziałania;
                liczbaZostałaOstatnioWpisana = false;
            }
            else if (poprzednioKlikniętyZnakDziałania == "=")
            {
                wszystkieDziałaniaBezLiczbyWprowadzanej = wszystkieDziałaniaBezLiczbyWprowadzanej + znakDziałania;

                poprzednioKlikniętyZnakDziałania = znakDziałania;
            }
            wyświetlDziałanie();
        }

        private void równaq_Click(object sender, RoutedEventArgs e)
        {
            if (poprzednioKlikniętyZnakDziałania != "=")
            {
                wykonajOstatnieDziałanie();
            }

            liczbaZostałaOstatnioWpisana = false;
            wyświetlDziałanie();

            //wszystkieDziałaniaBezLiczbyWprowadzanej = "";

            poprzednioKlikniętyZnakDziałania = "=";
            liczbaWprowadzana = "0";
        }

        private void usuń_Click(object sender, RoutedEventArgs e)
        {

            if (!jestPusto())
            {
                liczbaWprowadzana = liczbaWprowadzana.Substring(0, liczbaWprowadzana.Length - 1);
                if (jestPusto())
                {
                    liczbaWprowadzana = "0";
                }
            }
            wyświetlLiczbęWprowadzaną();
            wyświetlDziałanie();
        }

        private void usuńWszystko_Click(object sender, RoutedEventArgs e)
        {
            usuńWszysko();
            wyświetlLiczbęWprowadzaną();
            wyświetlDziałanie();
        }

    }
}
