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
using System.Windows.Shapes;
using ServicioDGTMultas;

namespace InterfazGrafica
{
    public partial class MainWindows2 : Window
    {
        ServicioMultas s = null;
        public MainWindows2(ServicioMultas s)
        {
            InitializeComponent();
            pM.Visibility = System.Windows.Visibility.Hidden;
            qM.Visibility = System.Windows.Visibility.Hidden;
            aV.Visibility = System.Windows.Visibility.Hidden;
            bV.Visibility = System.Windows.Visibility.Hidden;
            this.s = s;
        }

        private void ponerMultaBoton(object sender, RoutedEventArgs e)
        {
            pM.Visibility = System.Windows.Visibility.Visible;
            qM.Visibility = System.Windows.Visibility.Hidden;
            aV.Visibility = System.Windows.Visibility.Hidden;
            bV.Visibility = System.Windows.Visibility.Hidden;
        }

        private void quitarMultaBoton(object sender, RoutedEventArgs e)
        {
            pM.Visibility = System.Windows.Visibility.Hidden;
            qM.Visibility = System.Windows.Visibility.Visible;
            aV.Visibility = System.Windows.Visibility.Hidden;
            bV.Visibility = System.Windows.Visibility.Hidden;
        }

        private void altaVehiculoBoton(object sender, RoutedEventArgs e)
        {
            pM.Visibility = System.Windows.Visibility.Hidden;
            qM.Visibility = System.Windows.Visibility.Hidden;
            aV.Visibility = System.Windows.Visibility.Visible;
            bV.Visibility = System.Windows.Visibility.Hidden;
        }

        private void bajaVehiculoBoton(object sender, RoutedEventArgs e)
        {
            pM.Visibility = System.Windows.Visibility.Hidden;
            qM.Visibility = System.Windows.Visibility.Hidden;
            aV.Visibility = System.Windows.Visibility.Hidden;
            bV.Visibility = System.Windows.Visibility.Visible;
        }

        private void volverBoton(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow(s);
            m.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void botonMultar(object sender, RoutedEventArgs e)
        {
            String m, f; int p;
            m = Convert.ToString(boxM1.Text); f = Convert.ToString(boxF1.Text); p = Convert.ToInt32(boxP1.Text);
            s.PonerMulta(m, f, p);
        }

        private void botonQuitar(object sender, RoutedEventArgs e)
        {
            String m, f;
            m = Convert.ToString(boxM2.Text); f = Convert.ToString(boxF2.Text);
            s.QuitarMulta(m, f);
        }

        private void botonAlta(object sender, RoutedEventArgs e)
        {
            int d; String m;
            d = Convert.ToInt32(boxD3.Text); m = Convert.ToString(boxM3.Text);
            s.AltaVehiculo(d, m);
        }

        private void botonBaja(object sender, RoutedEventArgs e)
        {
            int d; String m;
            d = Convert.ToInt32(boxD4.Text); m = Convert.ToString(boxM4.Text);
            s.BajaVehiculo(d, m);
        }


    }
}
