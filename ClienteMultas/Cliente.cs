using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using ComunDGTMultas;

namespace ServicioDGTMultas
{
    class Cliente
    {
        public static String menuGestion() 
        {
            String op = "";

            Console.WriteLine("\n****************************"); 
            Console.WriteLine("**");
            Console.WriteLine("** 1 - Identificación"); 
            Console.WriteLine("** 2 - Consultar Puntos"); 
            Console.WriteLine("** 3 - Consultar Multas"); 
            Console.WriteLine("** 4 - Salir"); 
            Console.WriteLine("**");
            Console.Write("** Elige Opcion: ");
            op = Console.ReadLine();

            return op;
        }
    
        public static String menuConsulta()
        {
            String op = "";

            Console.WriteLine("\n****************************"); 
            Console.WriteLine("**");
            Console.WriteLine("** 1 - Poner Multa"); 
            Console.WriteLine("** 2 - Quitar Multa"); 
            Console.WriteLine("** 3 - Alta de un Vehículo"); 
            Console.WriteLine("** 4 - Baja de un Vehículo");
            Console.WriteLine("** 5 - Salir"); 
            Console.WriteLine("**");
            Console.Write("** Elige Opcion: ");
            op = Console.ReadLine();
        
            return op;
        }

        static void Main(string[] args)
        {
            List<string> Lista = new List<string>();
            ChannelServices.RegisterChannel(new TcpChannel(), false);
            ServicioMultas s = (ServicioMultas)Activator.GetObject(typeof(ServicioMultas), "tcp://localhost:12345/ServicioDGTMultas");
            //RemotingConfiguration.Configure("ClienteMultas.exe.config", false);
            //ServicioMultas s = new ServicioMultas();
            
            String op = "", op2 = "";
            String dni = "", puntos = "";
            int result = 0; 
            String id = "", matricula = "", fecha = "";
            LinkedList<DatosSancion> resultLL = new LinkedList<DatosSancion>();

            do {
                op = menuGestion(); 
                switch(op) {
                    case "1":
                        Console.Write("Deme la matricula para identificarle: "); id = Console.ReadLine();
                        result = s.Identificacion(id);
                        if (result == 1) {
                            Console.WriteLine("");
                            Console.WriteLine("¡Bienvenido Agente!");

                            do {
                                op2 = menuConsulta();
                                switch (op2) {
                                    case "1":
                                        Console.WriteLine("Deme los datos de la sanción.");
                                        Console.Write("Matricula: "); matricula = Console.ReadLine();
                                        Console.Write("Fecha: "); fecha = Console.ReadLine();
                                        Console.Write("Puntos a Retirar: ");  puntos = Console.ReadLine();
                                            

                                        result = s.PonerMulta(matricula, fecha, int.Parse(puntos));

                                        if (result == 1) Console.WriteLine("¡Multa realizada correctamente!");
                                        else Console.WriteLine("No se encuentra ese vehículo dado de alta.");

                                        break;
                                    case "2":
                                        Console.WriteLine("Deme los datos de la sanción.");
                                        Console.Write("Matricula: "); matricula = Console.ReadLine();
                                        Console.Write("Fecha: "); fecha = Console.ReadLine();

                                        result = s.QuitarMulta(matricula, fecha);

                                        if (result == 1) Console.WriteLine("¡Multa retirada correctamente!");
                                        else Console.WriteLine("No se encuentra ese vehículo dado de alta.");

                                        break;
                                    case "3":
                                        Console.WriteLine("Deme los datos del usuario y su matrícula.");
                                        Console.Write("Dni: "); dni = Console.ReadLine();
                                        Console.Write("Matricula: "); matricula = Console.ReadLine();

                                        int d = int.Parse(dni);
                                        result = s.AltaVehiculo(d, matricula);

                                        if (result == 1) Console.WriteLine("¡Vehículo dado de alta!");
                                        else Console.WriteLine("El vehículo ya estaba dado de alta.");

                                        break;
                                    case "4":
                                        Console.WriteLine("Deme los datos del usuario y su matrícula.");
                                        Console.Write("Dni: "); dni = Console.ReadLine();
                                        Console.Write("Matricula: "); matricula = Console.ReadLine();

                                        result = s.BajaVehiculo(int.Parse(dni), matricula);

                                        if (result == 1) Console.WriteLine("¡Vehículo dado de baja!");
                                        else Console.WriteLine("El vehículo no está dado de alta o tiene multas pendientes.");

                                        break;
                                }
                            } while (!op2.Equals("5"));
                        }

                        else Console.WriteLine("La matrícula no concuerda.");

                        break;

                    case "2":
                        Console.WriteLine("Deme los datos del usuario y su matrícula.");
                        Console.Write("Dni: "); dni = Console.ReadLine();
                        Console.Write("Matricula: "); matricula = Console.ReadLine();

                        result = s.ComprobarPuntos(int.Parse(dni), matricula);

                        if (result != -1) {
                            if (result == 1) Console.WriteLine("Puntos del usuario: 15");
                            else Console.WriteLine("Puntos del usuario: " + result);
                        }

                        break;

                    case "3":
                        Console.WriteLine("Deme los datos del usuario y su matrícula.");
                        Console.Write("Dni: "); dni = Console.ReadLine();
                        Console.Write("Matricula: "); matricula = Console.ReadLine();

                        resultLL = s.ComprobarMultas(int.Parse(dni), matricula);

                        if (resultLL != null){
                            Console.WriteLine("Comprobación de multas: \n");
                            Console.WriteLine("Numero de Multas: " + resultLL.Count);
                            Console.WriteLine("Listado de multas");
                            for (int i = 0; i < resultLL.Count; i++) {
                                Console.WriteLine(resultLL.ElementAt(i).getMatricula() + " - " 
                                    + resultLL.ElementAt(i).getFecha() + " - " + resultLL.ElementAt(i).getPuntos());
                            }


                        }

                        break;
                }
            } while(!op.Equals("4"));
        }
    }
}
