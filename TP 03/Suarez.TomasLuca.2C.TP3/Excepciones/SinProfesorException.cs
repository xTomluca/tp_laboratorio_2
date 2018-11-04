using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Metodo
        /// <summary>
        /// Excepcion Sin Profesor
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        public SinProfesorException(string message) : base(message)
        {

        }
        #endregion
    }
}
