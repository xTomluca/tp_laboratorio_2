using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// Guarda archivo
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Dato a Guardar</param>
        /// <returns>True = Guardado corectamente, caso contrario Excepcion</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee archivo
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>True = Leido correctamente, caso contrario Excepcion</returns>
        bool Leer(string archivo, out T datos);
        #endregion
    }
}
