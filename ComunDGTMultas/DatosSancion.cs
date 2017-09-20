using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunDGTMultas
{
    [Serializable]
    public class DatosSancion
    {
        public String matricula;
        public String fecha;
        public int puntos;

        public DatosSancion(String matricula, String fecha, int puntos)
        {
            this.matricula = matricula;
            this.fecha = fecha;
            this.puntos = puntos;
        }

        public String getMatricula() { return matricula; }
        public String getFecha() { return fecha; }
        public int getPuntos() { return puntos; }

        public void setMatricula(String matricula) { this.matricula = matricula; }
        public void setFecha(String fecha) { this.fecha = fecha; }
        public void setPuntos(int puntos) { this.puntos = puntos; }

        public string Matricula{
            get { return matricula; }
            set { matricula = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
    }

    
}
