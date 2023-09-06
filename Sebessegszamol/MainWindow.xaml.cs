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

namespace Sebessegszamol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> kapacitas = new Dictionary<string, int> {
                {"kB", 1},
                {"MB", 1000 },
                {"GB", 1000000},
                {"TB", 1000000000 },
            };
        Dictionary<string, int> sebesseg = new Dictionary<string, int>
            {
                {"Mbitps", 1 },
                {"MBps", 8 },
                {"Gbitps", 1000 },
                {"GBps", 8000 }
            };
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in kapacitas)
            {
                cbKapacitas.Items.Add(item.Key);
            }
            cbKapacitas.SelectedIndex = 0;
            
            foreach (var item in sebesseg)
            {
                cbSebesseg.Items.Add(item.Key);
            }
            cbSebesseg.SelectedIndex = 0;
        }

        private string formazIdot(double bevitel)
        {
            TimeSpan ts = TimeSpan.FromSeconds(bevitel);
            string formazott = $"{ts.Seconds} másodperc";
            if (Math.Floor(ts.TotalMinutes) > 0) { formazott = $"{ts.Minutes} perc {formazott}"; }
            if (Math.Floor(ts.TotalHours) > 0) { formazott = $"{ts.Hours} óra {formazott}"; }
            if (Math.Floor(ts.TotalDays) > 0) { formazott = $"{ts.Days} nap {formazott}"; }
            return formazott;
        }

        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            if (tbKapacitas.Text.Length > 0)
            {
                try
                {
                    double a = double.Parse(tbKapacitas.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nem szám volt megadva");
                    tbKapacitas.Focus();
                    return;
                }
                lbEredmeny.Content = formazIdot((double.Parse(tbKapacitas.Text) * kapacitas[cbKapacitas.SelectedItem.ToString()]) / (sliSebesseg.Value * sebesseg[cbSebesseg.SelectedItem.ToString()])/1000);
            }

        }

    }
}
