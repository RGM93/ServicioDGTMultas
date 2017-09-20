using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunDGTMultas;
using System.Collections;

namespace ServicioDGTMultas
{
    public class ServicioMultas:MarshalByRefObject
    {
        bool activarCargarDatos = true;

        List<DatosVehiculo> vehiculos = new List<DatosVehiculo>();
        List<DatosSancion> sanciones = new List<DatosSancion>();
        List<DatosPuntos> puntos = new List<DatosPuntos>();
        LinkedList<DatosSancion> ListadoMultas = new LinkedList<DatosSancion>();

        public void cargarDatos()
        {
            // Carga de Datos de Vehículos
            DatosVehiculo u = new DatosVehiculo(49089310, "0016FYP");
            vehiculos.Add(u);

            // Carga de Puntos de Usuarios
            DatosPuntos p = new DatosPuntos(49089310, 13);
            puntos.Add(p);

            // Carga de Sanciones de Usuarios
            DatosSancion s = new DatosSancion("0016FYP", "11/05/2017", 3);
            sanciones.Add(s);
        }

        public void mostrarDatos()
        {
            Console.WriteLine("Usuarios");

            for (int i = 0; i < vehiculos.Count; i++)
			{
			 Console.WriteLine(vehiculos[i].getDni() + " - " + vehiculos[i].getMatricula());
			}

            Console.WriteLine("Puntos");

            for (int i = 0; i < puntos.Count; i++) {
                Console.WriteLine(puntos[i].getDni() + " - " + puntos[i].getPuntosActuales());
            }

            Console.WriteLine("Sanciones");

            for (int i = 0; i < sanciones.Count; i++) {
               Console.WriteLine(sanciones[i].getMatricula() + " - " + sanciones[i].getFecha() + " - " + sanciones[i].getPuntos());
            }

            Console.WriteLine("");
        }


        // Busca un vehículo en la lista "vehiculos"
        int buscarVehiculo(int pos, int dni, String matricula)
        {
            int resultado = -1;
            bool encontrado = false;

            while(pos < vehiculos.Count && encontrado == false)
            {
                if(dni == vehiculos[pos].getDni() && (matricula.Equals(vehiculos[pos].getMatricula())))
                {
                    resultado = pos;
                    encontrado = true;
                }
                
                else pos++;
            }

            if(!encontrado) Console.WriteLine("No se ha encontrado el vehículo.\n");

            return resultado;
        }

        // Busca una multa de un vehículo en la lista "sanciones"
        int buscarSancion(int pos, String matricula, String fecha)
        {
            int resultado = -1;
            bool encontrado = false;

            while(pos < sanciones.Count && encontrado == false)
            {
                if(matricula.Equals(sanciones[pos].getMatricula()) && fecha.Equals(sanciones[pos].getFecha()))
                {
                    resultado = pos;
                    encontrado = true;
                }

                else pos++;
            }

            if(!encontrado) Console.WriteLine("No se ha encontrado el vehículo.\n");

            return resultado;
        }

        // Busca la matrícula en la lista "vehiculos"
        int buscarMatricula(int pos, String matricula)
        {
            int resultado = -1;
            bool encontrado = false;

            while(pos < vehiculos.Count && encontrado == false)
            {
                if(matricula.Equals(vehiculos[pos].getMatricula()))
                {
                    resultado = pos;
                    encontrado = true;
                }

                else pos++;
            }

            if(!encontrado) Console.WriteLine("No se ha encontrado la matricula.\n");

            return resultado;
        }

        // Busca la matrícula en la lista "sanciones"
        int buscarMatricula2(int pos, String matricula)
        {
            int resultado = -1;
            bool encontrado = false;

            while(pos < sanciones.Count && encontrado == false)
            {
                if(matricula.Equals(sanciones[pos].getMatricula()))
                {
                    resultado = pos;
                    encontrado = true;
                }

                else pos++;
            }

            if(!encontrado) Console.WriteLine("No se ha encontrado la matricula.\n");

            return resultado;
        }

        public int ComprobarPuntos(int Dni, String Matricula)
        {
            int result = -1;
            int pos = buscarVehiculo(0, Dni, Matricula);

	        if (pos != -1 && pos != -1) 
	        {
                result = puntos[pos].puntosActuales;
		
	        }
        
            return result;
        }

        public LinkedList<DatosSancion> ComprobarMultas(int Dni, String Matricula)
        {
            int pos = buscarVehiculo(0, Dni, Matricula); 

	        if (pos != -1)
            {
                for (int i = 0; i < sanciones.Count; i++) 
                {
                    if (Matricula.Equals(sanciones[i].getMatricula())) 
                    {
                        DatosSancion s = new DatosSancion(sanciones[i].getMatricula(), sanciones[i].getFecha(), sanciones[i].getPuntos());
                        ListadoMultas.AddLast(s);
                    }
                }
            }
            
            return ListadoMultas;
        }

        public int Identificacion(String Password)
        {
            int result = -1;

            Console.WriteLine("\nCargando datos...\n");
        
	        if (activarCargarDatos == true) 
            {
                activarCargarDatos = false;
                cargarDatos();
	        } 
        
	        mostrarDatos();

	        if (Password.Equals("541293AGP")) 
            {
                result = 1;
	        }
	
	        return result;
        
        }
 
        public int PonerMulta(String Matricula, String Fecha, int Puntos)
        {
            int result = -1;
	        int pos = buscarSancion(0, Matricula, Fecha);
	        int pos2 = buscarMatricula(0, Matricula);

	        if (pos == -1 && pos2 != -1) 
            {
                sanciones.Add(new DatosSancion(Matricula, Fecha, Puntos));
                puntos[pos2].setPuntosActuales(puntos[pos2].getPuntosActuales() - Puntos);

                if (puntos[pos2].getPuntosActuales() < 0)
                {
                    puntos[pos2].setPuntosActuales(0);
                }

                mostrarDatos();
                result = 1;
            }
        
            else Console.WriteLine("Numero de sanciones maximas alcanzadas.\n");

	        return result;
        }

        public int QuitarMulta(String Matricula, String Fecha)
        {
            int result = -1;
	        int pos = buscarSancion(0, Matricula, Fecha);
	        int pos2 = buscarMatricula(0, Matricula);

	        if (pos != -1 && pos2 != -1)
	        {
                int p = sanciones[pos].getPuntos();
                sanciones.RemoveAt(pos);
                puntos[pos2].setPuntosActuales(puntos[pos2].puntosActuales + p);

		        if(puntos[pos2].puntosActuales > 15)
		        {
                    puntos[pos2].puntosActuales = 15;
		        }

		        mostrarDatos();
		        result = 1;
	        }
        
	        return result;
        }

        public int AltaVehiculo(int Dni, String Matricula)
        {
            int result = -1;
	        int pos = buscarMatricula(0, Matricula);

	        if (pos == -1) 
	        {	
                DatosVehiculo u = new DatosVehiculo(Dni, Matricula);
                DatosPuntos p = new DatosPuntos(Dni, 15);
                vehiculos.Add(u);
                puntos.Add(p);

                result = 1;
                mostrarDatos();
	        }
	
	        return result;
        }

        public int BajaVehiculo(int Dni, String Matricula)
        {
            int result = -1;
            int pos = buscarVehiculo(0, Dni, Matricula);
            int pos2 = buscarMatricula2(0, Matricula);

            if (pos != -1 && pos2 == -1)
            {
                vehiculos.RemoveAt(pos);
                puntos.RemoveAt(pos);

                mostrarDatos();
                result = 1;
            }

            return result;
        }
    }
}