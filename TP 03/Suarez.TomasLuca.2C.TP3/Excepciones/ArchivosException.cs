using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Metodo
        /// <summary>
        /// Excepcion Arachivo
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        public ArchivosException(string  message) : base(message)
        {

        }
        /// <summary>
        /// Excepcion Archivo
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        /// <param name="innerException">InnerExcepcion</param>
        public ArchivosException(string message, Exception innerException) : base(message,innerException)
        {

        }
        #endregion
    }
}
