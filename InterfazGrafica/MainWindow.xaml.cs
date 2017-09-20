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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServicioDGTMultas;
using ComunDGTMultas;

namespace InterfazGrafica
{
    public partial class MainWindow : Window
    {
        
        public ServicioMultas s = null;

        public MainWindow()
        {
            InitializeComponent();
            id.Visibility = System.Windows.Visibility.Hidden;
            cP.Visibility = System.Windows.Visibility.Hidden;
            cM.Visibility = System.Windows.Visibility.Hidden;
            resultado.Visibility = System.Windows.Visibility.Hidden;
            Tabla.Visibility = System.Windows.Visibility.Hidden;
            nPuntos.Visibility = System.Windows.Visibility.Hidden;
            //ChannelServices.RegisterChannel(new TcpChannel(), false);
            //this.s = (ServicioMultas)Activator.GetObject(typeof(ServicioMultas), "tcp://localhost:12345/ServicioMultas");
            RemotingConfiguration.Configure("InterfazGrafica.exe.config", false);
            s = new ServicioMultas();
        }

        public MainWindow(ServicioMultas s){
            InitializeComponent();
            id.Visibility = System.Windows.Visibility.Hidden;
            cP.Visibility = System.Windows.Visibility.Hidden;
            cM.Visibility = System.Windows.Visibility.Hidden;
            resultado.Visibility = System.Windows.Visibility.Hidden;
            Tabla.Visibility = System.Windows.Visibility.Hidden;
            nPuntos.Visibility = System.Windows.Visibility.Hidden;
            this.s = s;
        }

        private void identificacionBoton(object sender, RoutedEventArgs e)
        {
            cP.Visibility = System.Windows.Visibility.Hidden;
            cM.Visibility = System.Windows.Visibility.Hidden;
            id.Visibility = System.Windows.Visibility.Visible;
            resultado.Visibility = System.Windows.Visibility.Hidden;
            Tabla.Visibility = System.Windows.Visibility.Hidden;
            nPuntos.Visibility = System.Windows.Visibility.Hidden;
        }

        private void comprobarPuntosBoton(object sender, RoutedEventArgs e)
        {
            cM.Visibility = System.Windows.Visibility.Hidden;
            id.Visibility = System.Windows.Visibility.Hidden;
            cP.Visibility = System.Windows.Visibility.Visible;
            resultado.Visibility = System.Windows.Visibility.Hidden;
            Tabla.Visibility = System.Windows.Visibility.Hidden;
            nPuntos.Visibility = System.Windows.Visibility.Hidden;
        }

        private void comprobarMultasBoton(object sender, RoutedEventArgs e)
        {
            id.Visibility = System.Windows.Visibility.Hidden;
            cP.Visibility = System.Windows.Visibility.Hidden;
            cM.Visibility = System.Windows.Visibility.Visible;
            resultado.Visibility = System.Windows.Visibility.Hidden;
            Tabla.Visibility = System.Windows.Visibility.Hidden;
            nPuntos.Visibility = System.Windows.Visibility.Hidden;
        }


        private void salir(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void comprobarIdentificacionBoton(object sender, RoutedEventArgs e)
        {
            MainWindows2 m;
            String idP = "";
            idP = Convert.ToString(boxMatricula.Text);
            int result = 0;
            result = s.Identificacion(idP);

            if (result == 1)
            {
                m = new MainWindows2(s);
                m.Visibility = System.Windows.Visibility.Visible;
                this.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void comprobarPuntosBoton2(object sender, RoutedEventArgs e)
        {
            int d; String m;
            d = Convert.ToInt32(boxDP.Text); m = Convert.ToString(boxMP.Text);

            int result = s.ComprobarPuntos(d, m);

            if (result != -1)
            {
                cP.Visibility = System.Windows.Visibility.Hidden;
                resultado.Visibility = System.Windows.Visibility.Visible;
                t.Text = Convert.ToString(result);
                //t.Visibility = System.Windows.Visibility.Visible;
;           }
        }

        private void comprobarMultasBoton2(object sender, RoutedEventArgs e)
        {
            LinkedList<DatosSancion> ds = null;
            String m; int d;
            m = Convert.ToString(boxMP2.Text);
            d = Convert.ToInt32(boxDP2.Text);
            ds = s.ComprobarMultas(d, m);

            if (ds.Count != 0)
            {
                Tabla.ItemsSource = ds;
                nPuntos.Text = "Numero de Multas: " + Convert.ToString(ds.Count);
                
            }

            Tabla.Visibility = System.Windows.Visibility.Visible;
            nPuntos.Visibility = System.Windows.Visibility.Visible;
            id.Visibility = System.Windows.Visibility.Hidden;
            cP.Visibility = System.Windows.Visibility.Hidden;
            cM.Visibility = System.Windows.Visibility.Hidden;
            resultado.Visibility = System.Windows.Visibility.Hidden;


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
