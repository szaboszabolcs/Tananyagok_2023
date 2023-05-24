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

namespace SuperBowlGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static char irany = 'j';
        static Dictionary<string, int> RomaiArab = new Dictionary<string, int> { { "I", 1 }, { "II", 2 }, { "III", 3 }, { "IV", 4 }, { "V", 5 }, { "VI", 6 }, { "VII", 7 }, { "VIII", 8 }, { "IX", 9 }, { "X", 10 } };
        static Dictionary<int,string> ArabRomai = new Dictionary<int,string> { { 1, "I"}, { 2, "II" }, { 3, "III" }, { 4, "IV" }, { 5, "V" }, { 6, "VI" }, { 7, "VII" }, { 8, "VIII" }, { 9, "IX" }, { 10, "X" } };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Irany_Click(object sender, RoutedEventArgs e)
        {
            txb_ArabSzam.Text = "";
            txb_RomaiSzam.Text = "";
            if (irany == 'b')
            {
                irany = 'j';
                btn_Irany.Content = "  --->  ";
                txb_ArabSzam.IsEnabled = false;
                txb_RomaiSzam.IsEnabled = true;
            }
            else
            {
                irany = 'b';
                btn_Irany.Content = "  <---  ";
                txb_ArabSzam.IsEnabled = true;
                txb_RomaiSzam.IsEnabled = false;
            }
        }

        private void btn_Atvalt_Click(object sender, RoutedEventArgs e)
        {
            if (irany == 'j')
            {
                try
                {
                    int szam = int.Parse(txb_RomaiSzam.Text);
                    txb_ArabSzam.Text = "Hiba!";
                }
                catch 
                {
                    if (RomaiArab.ContainsKey(txb_RomaiSzam.Text.ToUpper()))
                    {
                        txb_ArabSzam.Text = RomaiArab[txb_RomaiSzam.Text.ToUpper()].ToString();
                    }
                    else
                    {
                        txb_ArabSzam.Text = "Hiba!";
                    }
                }
            }
            else
            {
                int szam;
                if (int.TryParse(txb_ArabSzam.Text, out szam))
                {
                    if (ArabRomai.ContainsKey(szam))
                    {
                        txb_RomaiSzam.Text = ArabRomai[int.Parse(txb_ArabSzam.Text)].ToString();
                    }
                    else
                    {
                        txb_RomaiSzam.Text = "Hiba!";
                    }
                }
                else
                {
                    txb_RomaiSzam.Text = "Hiba!";
                }
            }
        }
    }
}
