using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
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
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno aux in j.Alumnos)
            {
                if (aux == a)
                    return true;
            }
            return false;
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                throw new AlumnoRepetidoException("Error, el alumno ya se encuentra en la Jornada");
            else
                j.Alumnos.Add(a);
            return j;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("-->Clase: {0}\n", this.Clase);
            stringBuilder.AppendFormat("->Profesor: {0}\n", this.Instructor);
            foreach (Alumno aux in this.Alumnos)
            {
                stringBuilder.AppendLine(aux.ToString());
            }

            return stringBuilder.ToString();
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = "text.txt";
            bool retorno = false;
            retorno = texto.Guardar(path, jornada.ToString());
            return retorno;
        }
        public static string Leer()
        {
            Texto texto = new Texto();
            string path = "text.txt";
            string leido = "";
            texto.Leer(path, out leido);
            return leido;
        }
    }
}
