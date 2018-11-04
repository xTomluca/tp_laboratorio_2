using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
namespace Test
{
    [TestClass]
    public class TestValorNull
    {
        /// <summary>
        /// Verifica que los valores no sean null
        /// </summary>
        [TestMethod]
        public void ValoresNull()
        {
            Universidad universidad = new Universidad();
            Profesor p1 = new Profesor(1, "Profesor", "Uno", "12345678", Profesor.ENacionalidad.Argentino);
            Alumno a1 = new Alumno(2, "Alumno", "Uno", "95555555", Profesor.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(p1);
            Assert.IsNotNull(a1);
        }
    }
}
