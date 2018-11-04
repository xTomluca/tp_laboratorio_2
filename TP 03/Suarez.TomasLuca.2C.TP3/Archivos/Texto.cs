using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        /// <summary>
        /// Guardar Archivo de Texto
        /// </summary>
        /// <param name="archivo">Path del archivo a Guardar</param>
        /// <param name="datos">Datos a Guardar</param>
        /// <returns>True = Archivo guardado, caso contrario Excepcion</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(archivo);
                writer.Write(datos);
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al Guardar Archivo");
            }
            finally
            {
                 writer.Close();
            }
            return true;
        }

        /// <summary>
        /// Lee Archivo
        /// </summary>
        /// <param name="archivo">Path archivo a Leer</param>
        /// <param name="datos">Datos leidos de archivo</param>
        /// <returns>True = Leido correctamente, caso contrario Excepcion</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
            }

            catch(Exception)
            {
                throw new ArchivosException("Error al Leer Archivo");
            }

            reader.Close(); // SAQUE EL CLOSE DEL FINALLY 
                            // SI EL PATH ES ERRONEO EL CLOSE LANZA EXCEPCION NULLREFERENCE
                            // LA CUAL NO ES CONTROLADA
            return true ;
        }
        #endregion
    }
}
