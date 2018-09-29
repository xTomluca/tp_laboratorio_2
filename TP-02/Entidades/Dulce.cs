using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region "Constructores"
        /// <summary>
        /// Constructor de objeto "Dulce"
        /// </summary>
        /// <param name="marca">Marca del Dulce</param>
        /// <param name="patente">Codigo de barra</param>
        /// <param name="color">Color packaging</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color) 
            : base(patente,marca,color)
        {
        }
        #endregion

        #region "Getter"
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
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

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
