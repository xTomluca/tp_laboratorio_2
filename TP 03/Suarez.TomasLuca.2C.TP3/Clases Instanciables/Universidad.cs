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
        public Jornada this[int i]
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
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        /// <summary>
        /// Guarda en XML Datos de Universidad
        /// </summary>
        /// <param name="uni">Universidad a Guardar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Alumno es igual a Universidad si esta inscripto en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>TRUE Alumno inscripto | FALSE NO inscripto</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno aux in g.alumnos)
            {
                if (aux == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Alumno es desigual a Universidad si no esta inscripto en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>TRUE Alumno NO inscripto | FALSE Inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Universidad es Igual a Profesor si este ultimo da clases en ella
        /// </summary>
        /// <param name="g">Universidad a analizar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>TRUE Profesor da clases | FALSE NO da clases</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor aux in g.profesores)
            {
                if (aux == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Universidad es Desigual a Profesor si este ultimo NO da clases en ella
        /// </summary>
        /// <param name="g">Universidad a analizar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>TRUE Profesor NO da clases | FALSE Da clases</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Busca 1er Profesor en la Universidad que dicte Clase especificada
        /// </summary>
        /// <param name="u">Universidad a analizar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna profesor que dicte la clase | Caso contrario Excepción</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor aux in u.profesores)
            {
                if (aux == clase)
                    return aux;
            }
            throw new SinProfesorException("No se encontro profesor para la clase");
        }

        /// <summary>
        /// Busca 1er Profesor en Universidad que no dicte la clase especificada
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna profesor que no dicte la clase | Caso contrario Excepción</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor aux in u.profesores)
            {
                if (aux != clase)
                    return aux;
            }
            throw new SinProfesorException("No se encontro profesor incapaz de dar clase");
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor= g == clase; 

            jornada = new Jornada(clase, profesor);
            foreach(Alumno aux in g.Alumnos)
            {
                if (aux == clase)
                {
                    jornada = jornada + aux;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException("Alumno repetido, ya se encuentra inscripto en la Universidad");
            else
                u.Alumnos.Add(a);
            return u;
        }
        public static Universidad operator+(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }


            /*
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
