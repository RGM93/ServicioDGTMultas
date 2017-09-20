using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunDGTMultas
{
    public class DatosPuntos
    {
        public int dni;
        public int puntosActuales;

        public DatosPuntos(int dni, int puntosActuales)
        {
            this.dni = dni;
            this.puntosActuales = puntosActuales;
        }

        public int getDni() { return dni; }
        public int getPuntosActuales() { return puntosActuales; }
        public void setDni(int dni) { this.dni = dni; }
        public void setPuntosActuales(int puntosActuales) { this.puntosActuales = puntosActuales; }
    }
}
