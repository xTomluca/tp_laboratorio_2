using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Universitario por defecto
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor Universitario con Parametros
        /// </summary>
        /// <param name="legajo">Legajo del Universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescritura del metodo Equals para comparar Universitarios
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True = Son Universitarios iguales, caso contrario = False</returns>
        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType() && (((Universitario)obj).legajo == this.legajo || (this.DNI==((Universitario)obj).DNI)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Muestra los datos del Universitario
        /// </summary>
        /// <returns>Datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO: {0}\n", this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si son universitarios distintos
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>True = Son universitarios distintos, caso contrario False</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        /// <summary>
        /// Verifica si son universitarios iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>True = Son universitarios iguales, caso contrario False</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Firma metodo Participar en Clase
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
