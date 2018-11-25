using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        /// <summary>
        /// Constructor formulario
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// Genera nuevo paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformaEstado += this.paq_InformaEstado;
            p.BaseSql += this.errorBaseDato;
            try
            {
                this.correo += p;
            }
            catch(TrackingIdRepetidoException exc)
            {
                MessageBox.Show(exc.Message);
            }
            this.ActualizarEstado();
            this.mtxtTrackingID.Clear();
            this.txtDireccion.Clear();
        }

        /// <summary>
        /// Manejador de evento, en caso de error en la base de datos muestra mensaje
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        private void errorBaseDato(object obj, EventArgs args)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(errorBaseDato);
                this.Invoke(d, new object[] { obj, args });
            }
            else
            {
                MessageBox.Show("Error al guardar en BASE DE DATOS");
            }
        }

        /// <summary>
        /// Manejador de evento Informar estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender,EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }

        /// <summary>
        /// Agrega elementos a ListBox segun su estado
        /// </summary>
        private void ActualizarEstado()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach(Paquete p in this.correo.Paquetes)
            {
                switch(p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }
        }

        /// <summary>
        /// Finaliza los hilos, al cierre del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra los datos del elemento y lo guarda en archivo de texto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento">Paquete seleccionado</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(elemento is null))
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    elemento.MostrarDatos(elemento).Guardar("salida.txt");
                }
                catch(Exception)
                {
                    MessageBox.Show("Error al guardar TXT");
                }
            }
        }

        /// <summary>
        /// Muestra todos los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra paquete seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);

        }
    }
}
