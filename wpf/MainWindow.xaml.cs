using DolgozatCLI;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DolgozatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Dolgozat> dolgozatok = new List<Dolgozat>();
        public MainWindow()
        {
            InitializeComponent();
            string path = "dolgozat.txt";
            var beolvasas = File.ReadAllLines(path).Skip(1);

            foreach (var sor in beolvasas)
            {
                string[] elvalasztas = sor.Split(";");

                string nev = elvalasztas[0];
                int kor = int.Parse(elvalasztas[1]);
                int pontszam = int.Parse(elvalasztas[2]);

                dolgozatok.Add(new Dolgozat(nev, kor, pontszam));
            }

            tabla.ItemsSource = dolgozatok;
        }

        private void hozzaadas(object sender, RoutedEventArgs e)
        {
            string nev = nevmezo.Text;
            int kor = int.Parse(kormezo.Text);
            int pont = int.Parse(pontmezo.Text);
            dolgozatok.Add(new(nev, kor, pont));
            tabla.Items.Refresh();
        }

        private void mentes(object sender, RoutedEventArgs e)
        {
            string path = "dolgozat.txt";
            string formatum = "Név;Életkor;Pontszám\n";
            foreach (var item in dolgozatok)
            {
                formatum += $"{item.nev};{item.kor};{item.pontszam}\n";
            }

            try
            {
                File.WriteAllText(path, formatum);
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba: {ex.Message}");
            }
        }
    }
}