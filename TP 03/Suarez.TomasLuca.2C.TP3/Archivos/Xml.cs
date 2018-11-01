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
    class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            bool retorno = true;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(writer, datos);
            }
            catch(Exception e)
            {
                retorno = false;
                throw new ArchivosException("Error al Guardar XML", e.InnerException);
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;
            bool retorno = true;
            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(reader);
            }
            catch(Exception e)
            {
                retorno = false;
                throw new ArchivosException("Error al Leer XML", e.InnerException);
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
