using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// Guarda archivo XML
        /// </summary>
        /// <param name="archivo">Path del archivo a Guardar</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>True = Guardado correctamente, caso contrario Excepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
            }
            catch(Exception e)
            {
                throw new ArchivosException("Error al Guardar XML", e);
            }
            finally
            {
                writer.Close();
            }
            return true;
        }

        /// <summary>
        /// Lee archivo
        /// </summary>
        /// <param name="archivo">Path de archivo a Leer</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>True = Leido correctamente, caso contrario Excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;
            try
            {
                reader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
            }
            catch(Exception e)
            {
                throw new ArchivosException("Error al Leer XML", e);
            }
            reader.Close(); // SAQUE EL CLOSE DEL FINALLY 
                            // SI EL PATH ES ERRONEO EL CLOSE LANZA EXCEPCION NULLREFERENCE
                            // LA CUAL NO ES CONTROLADA
            return true;
        }
        #endregion
    }
}
