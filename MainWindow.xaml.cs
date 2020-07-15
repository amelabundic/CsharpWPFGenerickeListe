using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CsharpWPFKolekcija113
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Trkac> listaTrkaca = new List<Trkac>();

        public MainWindow()
        {
            InitializeComponent();
        }

       public void Stampaj()
        {
            TextBox1.Clear();

            foreach (Trkac t in listaTrkaca)
            {
                TextBox1.AppendText(t.ToString());
            }
        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            TextBoxIme.Clear();
            TextBoxPrezime.Clear();
            TextBoxBrojPobijeda.Clear();
            TextBoxDrzava.Clear();

        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxIme.Text))
            {
                MessageBox.Show("Unesite ime");
                TextBoxIme.Focus();
                return false;
            }
            if (TextBoxIme.Text.Trim().Length <2)
            {
                MessageBox.Show("Polje ime mora imati bar dva karaktera");
                TextBoxIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxPrezime.Text))
            {
                MessageBox.Show("Unesite prezime");
                TextBoxPrezime.Focus();
                return false;
            }
            if (TextBoxPrezime.Text.Trim().Length < 2)
            {
                MessageBox.Show("Polje prezime mora imati bar dva karaktera");
                TextBoxPrezime.Focus();
                return false;
            }
            int broj;
            if (!int.TryParse(TextBoxBrojPobijeda.Text,out broj))
            {
                MessageBox.Show("Morate unijeti broj");
                TextBoxBrojPobijeda.Clear();
                TextBoxBrojPobijeda.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxDrzava.Text))
            {
                MessageBox.Show("Unesite drzavu");
                TextBoxDrzava.Focus();
                return false;
            }
            if (TextBoxDrzava.Text.Trim().Length < 2)
            {
                MessageBox.Show("Polje drzava mora imati bar dva karaktera");
                TextBoxDrzava.Focus();
                return false;
            }
            return true;
        }

        private string VelikoPrvoSlovo(string s)
        {
            s = s.Trim().ToLower();

            if (s.Length > 1)
            {
            
                
                return s.Substring(0, 1).ToUpper() + s.Substring(1);
            }
            else
            {
                return "";
            }
        }

        private Trkac KreirajTrkaca()
        {
            if (Validacija())
            {
                int id = Trkac.brojTrkaca + 1;
                string ime = VelikoPrvoSlovo(TextBoxIme.Text);
                string prezime = VelikoPrvoSlovo(TextBoxPrezime.Text);
                int brojPobijeda = int.Parse(TextBoxBrojPobijeda.Text);
                string drzava = VelikoPrvoSlovo(TextBoxDrzava.Text);

                Trkac t1 = new Trkac { Id = id, Ime = ime, Prezime = prezime, BrojPobijeda = brojPobijeda, Drzava = drzava };
                return t1;
                

            }
            return null;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Trkac t1 = new Trkac{
             Id = 1, Ime="Pera",Prezime="Peric",
                BrojPobijeda = 4,
                Drzava ="BiH"
            };

            Trkac t2 = new Trkac
            {
                Id = 2,
                Ime = "Nera",
                Prezime = "Neric",
                BrojPobijeda = 5,
                Drzava = "BiH"
            };

            Trkac t3 = new Trkac
            {
                Id = 3,
                Ime = "Zera",
                Prezime = "Zeric",
                BrojPobijeda = 3,
                Drzava = "BiH"
            };
            listaTrkaca.Add(t1);
            listaTrkaca.Add(t2);
            listaTrkaca.Add(t3);

            Stampaj();
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            Trkac t = KreirajTrkaca();

            if (t !=null)
            {
                listaTrkaca.Add(t);
                Stampaj();
                Resetuj();
                TextBoxIme.Focus();
            }
        }

        private int VratiIndex()
        {
            int a;

            if (!int.TryParse(TextBoxIndex.Text,out a))
            {
                return -2;
            }
            if (a >=0 && a< listaTrkaca.Count)
            {
                return a;
            }
            return -1;
        }

        private void ButtonPronadji_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
            int indeks = VratiIndex();

            if (indeks == -2)
            {
                MessageBox.Show("Niste unijeli broj");
            }
            else if (indeks == -1)
            {
                MessageBox.Show("Pogresan indeks");
            }
            else
            {
                Trkac t = listaTrkaca[indeks];

                TextBoxId.Text = t.Id.ToString();
                TextBoxIme.Text = t.Ime;
                TextBoxPrezime.Text = t.Prezime;
                TextBoxBrojPobijeda.Text = t.BrojPobijeda.ToString();
                TextBoxDrzava.Text = t.Drzava;
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
            int indeks = VratiIndex();

            if (indeks == -2)
            {
                MessageBox.Show("Niste unijeli broj");
            }
            else if (indeks == -1)
            {
                MessageBox.Show("Pogresan indeks");
            }
            else
            {
                listaTrkaca.RemoveAt(indeks);
                Stampaj();
               
            }
        }

       

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            int indeks = VratiIndex();

            if (indeks == -2)
            {
                MessageBox.Show("Niste unijeli broj");
            }
            else if (indeks == -1)
            {
                MessageBox.Show("Pogresan indeks");
            }
            else
            {
                Trkac t = listaTrkaca[indeks];

                if (Validacija())
                {
                    t.Ime = VelikoPrvoSlovo(TextBoxIme.Text);
                    t.Prezime = VelikoPrvoSlovo(TextBoxPrezime.Text);
                    t.BrojPobijeda = int.Parse(TextBoxBrojPobijeda.Text);
                    t.Drzava = VelikoPrvoSlovo(TextBoxDrzava.Text);

                    Stampaj();
                }
            }
        }
    }
}
