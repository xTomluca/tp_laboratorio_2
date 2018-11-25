using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace Test_Unitarios
{
    [TestClass]
    public class Test_Unitarios
    {
        /// <summary>
        // Verifica que la lista de paquetes este instanciada
        /// </summary>
        [TestMethod]
        public void Lista_de_paquetes()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Paquete repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesRepetidos()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Cochabamba 1750", "10301030");
            //Paquete repetidos
            Paquete paquete2 = new Paquete("Cochabamba 2000", "10301030");
            correo += paquete1;
            correo += paquete2;
        }
    }
}
