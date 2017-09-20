using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDGTMultas
{
    class Servidor
    {
        static void Main(string[] args)
        {
            /*ChannelServices.RegisterChannel(new TcpChannel(12345), false);
            Console.WriteLine("Registrando el servicio de la DGT Remota...");
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServicioMultas), "ServicioDGTMultas", WellKnownObjectMode.Singleton);*/
            RemotingConfiguration.Configure("ServidorMultas.exe.config", false);

            Console.WriteLine("Esperando llamadas Remotas...");
            Console.WriteLine("Pulsa Enter para Salir..");
            Console.ReadLine();

        }
    }
}
