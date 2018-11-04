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
        #region Enumerado
        /// <summary>
        /// Enumerado Clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        List<Alumno> alumnos;
        List<Jornada> jornadas;
        List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Getter y setter lista de Alumnos
        /// </summary>
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
        /// <summary>
        /// Getter y setter lista de Instructores(profesores)
        /// </summary>
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
        /// <summary>
        /// Getter y setter lista de Jornadas
        /// </summary>
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
        #endregion

        #region Indexador
        /// <summary>
        /// Indexador getter y setter de jornada
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>Jornada en Indice deseado</returns>
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
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Universidad
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda en XML Datos de Universidad
        /// </summary>
        /// <param name="uni">Universidad a Guardar</param>
        /// <returns>Guardado = True, caso contrario Excepcion</returns>
        public static bool Guardar(Universidad uni)
        {
            string path = "Universidad.xml";
            Xml<Universidad> xml = new Xml<Universidad>(); ;
            xml.Guardar(path, uni);
            return true;

        }
        /// <summary>
        /// Lee desde XML la Universidad Guardada
        /// </summary>
        /// <returns>Devuelve Universidad, en caso de error una Excepcion</returns>
        public static Universidad Leer()
        {
            string path = "Universidad.xml";
            Universidad aux = null;
            Xml<Universidad> xml= new Xml<Universidad>();
            xml.Leer(path, out aux);
            return aux;
        }
        /// <summary>
        /// Muestra los Datos de la Universidad
        /// </summary>
        /// <param name="uni">Universidad a mostrar</param>
        /// <returns>Retorna String con datos de la Universidad</returns>
        private static string MostrarDatos(Universidad uni)

        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Jornada aux in uni.jornadas)
            {
                stringBuilder.AppendLine(aux.ToString());
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Hace visible los datos de la Universidad
        /// </summary>
        /// <returns>Retorna datos de la Universidad</returns>
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

        /// <summary>
        /// Agrega una nueva Clase, generando una nueva Jornada
        /// (con su respectivo Profesor y Alumnos que tomen esa clase)
        /// </summary>
        /// <param name="g">Universidad a cargar</param>
        /// <param name="clase">Clase deseada</param>
        /// <returns></returns>
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
        /// <summary>
        /// Agrega Alumno a la Universidad
        /// </summary>
        /// <param name="u">Universidad donde agregar Alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna Universidad con Alumno nuevo, caso contrario Excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException("Alumno repetido, ya se encuentra inscripto en la Universidad");
            else
                u.Alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la Universidad
        /// </summary>
        /// <param name="u">Universidad donde agregar Profesor</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>Retorna Universidad</returns>
        public static Universidad operator+(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }
    }
    #endregion
}
