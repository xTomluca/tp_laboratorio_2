using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Clases_Abstractas;
using Excepciones;
namespace Test
{

    [TestClass]
    public class TestNumerico
    {
        /// <summary>
        /// Chequea DNI bien validado
        /// </summary>
        [TestMethod]
        public void ValidarNumero()
        {
            int numEsperado = 12345677;
            string numero = "12345677";
            Alumno alumno = new Alumno(1, "Jorge", "Test", numero, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            alumno.StringToDNI = numero;
            Assert.AreEqual(numEsperado, alumno.DNI);

        }
        /// <summary>
        /// Se testea DNI invalido, contiene letra
        /// </summary>
        [TestMethod]
        public void DniInvalido()
        {
            string dniInvalido = "1235467b";
            Alumno alumno = new Alumno(1, "Jorge", "Test", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            try
            {
                alumno.StringToDNI = dniInvalido;
            }
            catch(DniInvalidoException)
            {
                Assert.AreNotEqual(dniInvalido, alumno.DNI);
            }

        }
        /// <summary>
        /// DNI supera cantidad Maxima permitida
        /// </summary>
        [TestMethod]
        public void CantidadMaxDni()
        {
            string dniInvalido = "1235467123";
            Alumno alumno = new Alumno(1, "Jorge", "Test", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            try
            {
                alumno.StringToDNI = dniInvalido;
            }
            catch (DniInvalidoException)
            {
                Assert.AreEqual(12345678, alumno.DNI);
            }

        }
    }
}
