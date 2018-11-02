using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        /*Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) y Jornadas.
             Se accederá a una Jornada específica a través de un indexador.*/
        List<Alumno> alumnos;
        List<Jornada> jornadas;
        List<Profesor> profesores;

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
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }
        Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                this.jornadas[i] = value;
            }
        }
        public Universidad()
        {

        }
        public static bool Guardar(Universidad uni)
        {
            string path = "Universidad.xml";
            Xml<Universidad> xml = new Xml<Universidad>(); ;
            try
            {
                xml.Guardar(path, uni);
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException("Error al Guardar Universidad XML",e);
            }
            return true;

        }
        public static Universidad Leer()
        {
            string path = "Universidad.xml";
            Universidad aux = null;
            Xml<Universidad> xml= new Xml<Universidad>();
            try
            {
                xml.Leer(path, out aux);
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException("Error al Leer Universidad XML", e);
            }
            return aux;
        }

        private static string MostrarDatos(Universidad uni)

        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Jornada aux in uni.jornadas)
            {
                stringBuilder.AppendLine(aux.ToString());
            }
            return stringBuilder.ToString();
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /* Un Universidad será igual a un Alumno si el mismo está inscripto en él.
         Un Universidad será igual a un Profesor si el mismo está dando clases en él.
         Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la
        toman (todos los que coincidan en su campo ClaseQueToma).
         Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente
        cargados.
         La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        Sino, lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no
        pueda dar la clase.
         MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante
        ToString.
         Leer de clase retornará un Universidad con todos los datos previamente serializados.*/

    }
}
