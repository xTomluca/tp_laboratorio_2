using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Metodo de extension, guarda datos en TXT
        /// </summary>
        /// <param name="texto">Texto a escribir</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>True si se guarda con exito, Excepcion caso contrario</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter writer = new StreamWriter(string.Format("{0}\\{1}",Environment.GetFolderPath(Environment.SpecialFolder.Desktop),archivo), true);
            writer.WriteLine(texto);
            writer.Close();
            return true;
        }
    }
}
