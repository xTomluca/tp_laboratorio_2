using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        #region "Constructor"

        /// <summary>
        /// Constructor de objeto Producto
        /// </summary>
        /// <param name="patente">Codigo de barra</param>
        /// <param name="marca">Marca de Producto</param>
        /// <param name="color">Color Packaging</param>
        public Producto(string patente, EMarca marca,ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region "Getter"
        /// <summary>
        /// Retornara Cantidad de Calorias
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }
        #endregion

        #region "Metodo"
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Datos del producto: This aplicando sobrecarga String</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Sobrecarga"
        /// <summary>
        /// Genera String con datos del producto
        /// </summary>
        /// <param name="p">Objeto tipo Producto</param>

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="p1">Objeto de Clase "Producto" a comparar</param>
        /// <param name="p2">Objeto de Clase "Producto" a comparar</param>
        /// <returns>True = Productos iguales || False = Productos desiguales</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            if (p1.codigoDeBarras == p2.codigoDeBarras)
                return true;
            return false;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="p1">Objeto de Clase "Producto" a comparar</param>
        /// <param name="p2">Objeto de Clase "Producto" a comparar</param>
        /// <returns>True = Productos desiguales || False = Productos iguales</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1.codigoDeBarras == p2.codigoDeBarras);
        }
        #endregion
    }
}
