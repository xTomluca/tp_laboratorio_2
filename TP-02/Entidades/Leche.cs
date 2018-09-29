using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        /// <summary>
        /// Enumerado tipos de Leche
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }

        private ETipo tipo;

        #region "Constructores"
        /// <summary>
        /// Constructor de objeto "Leche"
        /// </summary>
        /// <param name="marca">Marca de Leche</param>
        /// <param name="patente">Codigo de barra</param>
        /// <param name="color">Color packaging</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor de objeto "Leche"
        /// </summary>
        /// <param name="marca">Marca de Leche</param>
        /// <param name="patente">Codigo de barra</param>
        /// <param name="color">Color packaging</param>
        /// <param name="tipo">Tipo de Leche</param>
        public Leche(EMarca marca,string patente, ConsoleColor color, ETipo tipo) 
            : this(marca,patente,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Getter"
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region "Metodo"
        /// <summary>
        /// Publica los datos del producto
        /// </summary>
        /// <returns>Datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
