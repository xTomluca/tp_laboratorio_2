using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using Archivos;
namespace Test
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Se intentan agregar alumnos repetidosd, se espera AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ExcepcionAlumnoRepetido()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Mario", "Alberto", "12345678", Alumno.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(1, "Mario", "Duplicado", "12345678", Alumno.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            universidad += alumno;
            universidad += alumno2;
        }
        /// <summary>
        /// Se intenta abrir archivo inexistente se espera ArchivosException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ExcepcionArchivo()
        {
            string ubicacionErronea = "PathErroneo.txt";
            string textoLeido = "";
            Texto texto = new Texto();
            texto.Leer(ubicacionErronea, out textoLeido);
        }

        /// <summary>
        /// Se intenta buscar un profesor para clase, se espera SinProfesorException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ExcepcionSinProfesor()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Mario", "Alberto", "12345678", Alumno.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(2, "Marcelo", "Dos", "56781234", Alumno.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            universidad += alumno;
            universidad += alumno2;
            universidad += Universidad.EClases.Laboratorio;
        }

    }
}
