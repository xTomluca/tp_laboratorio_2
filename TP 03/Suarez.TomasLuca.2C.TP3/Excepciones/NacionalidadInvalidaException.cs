using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Metodo
        /// <summary>
        /// Nacionalidad Invalida
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
        #endregion
    }
}
