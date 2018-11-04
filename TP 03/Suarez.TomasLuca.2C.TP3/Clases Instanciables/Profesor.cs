using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        Queue<EClases> clasesDelDia;
        static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id">ID Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre, apellido,dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Carga Random de Clases
        /// </summary>
        void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(3));
            System.Threading.Thread.Sleep(600);
            this.clasesDelDia.Enqueue((EClases)random.Next(3));
        }

        /// <summary>
        /// Muestra datos del Profesor 
        /// </summary>
        /// <returns>Datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Muestra que dicta el Profesor
        /// </summary>
        /// <returns>Clases que dicta el Profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (EClases c in this.clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hace publico Datos del Profesor
        /// </summary>
        /// <returns>Datos del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Profesor desigual a Clase si no dicta esta
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns>TRUE Profesor NO da esta Clase | FALSE Da esta clase</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Profesor igual a Clase si dicta esta
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns>TRUE Profesor da esta Clase | FALSE No da esta clase</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
                return true;
            return false;
        }
        #endregion
    }
}
