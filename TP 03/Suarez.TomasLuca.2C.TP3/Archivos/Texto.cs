﻿using System;
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
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(archivo);
                writer.Write(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al Guardar Archivo", e);
            }
            finally
            {
                writer.Close();
            }

            return true;
        }
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
            }
            catch(Exception e)
            {
                throw new ArchivosException("Error al Leer Archivo", e);
            }
            finally
            {
                reader.Close();
            }
            return true ;
        }
    }
}
