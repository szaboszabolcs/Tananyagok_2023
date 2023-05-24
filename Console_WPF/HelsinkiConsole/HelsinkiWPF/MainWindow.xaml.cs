using Helsinki_1952;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HelsinkiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Helsinki_1952.Eredmenyek> adatok = Helsinki_1952.helsinki1952.AdatokBeolvasasa();
        public MainWindow()
        {
            InitializeComponent();
            dtg.ItemsSource = adatok;
        }

        private void Diszkvalifikál_Button_Click(object sender, RoutedEventArgs e)
        {
            adatok.RemoveAt(dtg.SelectedIndex);
            dtg.Items.Refresh();
            MessageBox.Show(dtg.SelectedIndex.ToString());
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("helsinki2.txt");
            foreach (Helsinki_1952.Eredmenyek eredmenyek in adatok)
            {
                writer.WriteLine($"{eredmenyek.Helyezes} {eredmenyek.VersenySzam} {eredmenyek.SportoloSzama} {eredmenyek.Pontszam}");
            }
            writer.Close();
            MessageBox.Show("Sikeres mentés!");
        }        
    }
}