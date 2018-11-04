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
        #region Atributos
        List<Alumno> alumnos;
        EClases clase;
        Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Getter y Setter de Lista de Alumnos
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
        /// Getter y Setter de Clase
        /// </summary>
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

        /// <summary>
        /// Getter y Setter Instructor(Profesor)
        /// </summary>
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
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="clase">Clase de la Jornada</param>
        /// <param name="instructor">Profesor de la Jornada</param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Verifica si Alumno no pertenece a la Jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True = No pertenece, caso contrario False</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Verifica si Alumno pertenece a la Jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True = Pertenece, caso contrario False</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno aux in j.Alumnos)
            {
                if (aux == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega Alumno a Jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a Agregar</param>
        /// <returns>Jornada con alumno agregado, caso contrario Excepcion</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                throw new AlumnoRepetidoException("Error, el alumno ya se encuentra en la Jornada");
            else
                j.Alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// Muestra datos de la Jornada
        /// </summary>
        /// <returns>Datos de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();      /// "->" SE AGREGO PARA DISTINGIR 
            stringBuilder.AppendFormat("->CLASE: {0}\n", this.Clase);/// EL TIPO DE PERSONA QUE ES
            stringBuilder.AppendFormat("->PROFESOR: \n{0}", this.Instructor.ToString());
            foreach (Alumno aux in this.Alumnos)
            {
                stringBuilder.AppendLine("->ALUMNO:");
                stringBuilder.AppendLine(aux.ToString());
            }
            stringBuilder.AppendFormat("<----------------------------------------------------->");
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Guarda Jornada en Archivo
        /// </summary>
        /// <param name="jornada">Jornada a Guardar</param>
        /// <returns>True = Guardado con exito, caso contrario Excepcion</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = "Jornada.txt";
            bool retorno = false;
            retorno = texto.Guardar(path, jornada.ToString());
            return retorno;
        }

        /// <summary>
        /// Lee Jornada desde Archivo
        /// </summary>
        /// <returns>Jornada leida, caso contrario Excepcion</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string path = "Jornada.txt";
            string leido = "";
            texto.Leer(path, out leido);
            return leido;
        }
        #endregion
    }
}
