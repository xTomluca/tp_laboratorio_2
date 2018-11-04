using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Metodo
        /// <summary>
        /// Excepcion DNI INVALIDO
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        public DniInvalidoException(string message) : base(message)
        {

        }
        #endregion
    }
}
