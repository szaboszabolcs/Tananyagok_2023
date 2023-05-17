using BalatonCLI;
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

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<char> adoKategoriak = new List<char>() { 'A', 'B', 'C' };
        List<BalatonCLI.Record> adatok = BalatonCLI.BalatonCLI.AdatokBeolvasasa();
        public MainWindow()
        {
            InitializeComponent();
            cmb_AdoSavok.ItemsSource = adoKategoriak;
            cmb_AdoSavok.SelectedIndex = 0;
            dtg_Adatok.ItemsSource = adatok;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adatok[dtg_Adatok.SelectedIndex].Adosav = char.Parse(cmb_AdoSavok.Text);
            dtg_Adatok.Items.Refresh();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("modositottadatok.txt");
                foreach (var item in adatok)
                {
                    writer.WriteLine($"{item.Adoszam} {item.Nev} {item.Hazszam} {item.Adosav} {item.Alapterulet}");
                }
                writer.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
