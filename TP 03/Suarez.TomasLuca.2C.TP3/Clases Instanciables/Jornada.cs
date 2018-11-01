using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;
namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        EClases clase;
        Profesor instructor;
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public 
    }
}
