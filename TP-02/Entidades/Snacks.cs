using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region "Contructor"
        /// <summary>
        /// Constructor de objeto "Snacks"
        /// </summary>
        /// <param name="marca">Marca del Snacks</param>
        /// <param name="patente">Codigo de barra</param>
        /// <param name="color">Color de packaging</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region "Getter"
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region "Metodo"

        /// <summary>
        /// Publica datos del producto
        /// </summary>
        /// <returns>Datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
