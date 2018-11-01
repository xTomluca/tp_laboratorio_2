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
                return j;
            else
            {
                j.Alumnos.Add(a);
                return j;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Clase: {0}", this.Clase);
            stringBuilder.AppendFormat("Profesor: {0}", this.Instructor);
            foreach (Alumno aux in this.Alumnos)
            {
                stringBuilder.AppendLine(aux.ToString());
            }

            return stringBuilder.ToString();
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = string.Format("{0}/text.txt",Environment.CurrentDirectory);
            bool retorno = false;
            try
            {
                retorno = texto.Guardar(path, jornada.ToString());
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException("Error al Guardar en Jornada", e.InnerException);
            }
            return retorno;
        }
        public string Leer()
        {
            Texto texto = new Texto();
            string path = string.Format("{0}/text.txt", Environment.CurrentDirectory);
            string leido = "";
            try
            {
                texto.Leer(path, out leido);
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException("Error al Leer en Jornada", e.InnerException);
            }
            return leido;
        }
    }
}
