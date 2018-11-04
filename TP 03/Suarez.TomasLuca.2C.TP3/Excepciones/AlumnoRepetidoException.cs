using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Metodo
        /// <summary>
        /// Excepcion Alumno Repetido
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public AlumnoRepetidoException(string message) : base(message)
        {

        }
        #endregion
    }
}
