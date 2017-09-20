using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunDGTMultas
{
    public class DatosVehiculo
    {
        public int dni;
        public String matricula;

        public DatosVehiculo(int dni, String matricula)
        {
            this.dni = dni;
            this.matricula = matricula;
        }

        public int getDni() { return dni; }
        public String getMatricula() { return matricula; }
        public void setDni(int dni) { this.dni = dni; }
        public void setMatricula(String matricula) { this.matricula = matricula; }
    }
}
