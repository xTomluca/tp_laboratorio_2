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

namespace MiCalculadora
{
	public partial class LaCalculadora : Form
	{
		public LaCalculadora()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			Limpiar();
		}
		private void Limpiar()
		{
			this.txtNumero1.Text = string.Empty;
			this.txtNumero2.Text = string.Empty;
			this.lblResultado.Text = string.Empty;
			this.cmbOperador.Text = string.Empty;
		}
		private static double Operar(string numStr1, string numStr2, string operador)
		{
			Entidades.Calculadora calc = new Calculadora();
			Entidades.Numero num1 = new Numero(numStr1);
			Entidades.Numero num2 = new Numero(numStr2);

			return calc.Operar(num1, num2, operador);			
		}

		private void btnOperar_Click(object sender, EventArgs e)
		{
			lblResultado.Text=Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnConvertirADecimal_Click(object sender, EventArgs e)
		{
			if (lblResultado.Text != null)
			{
				Entidades.Numero resultado = new Numero();
				lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);
			}
		}
		private void btnConvertirABinario_Click(object sender, EventArgs e)
		{
			if (lblResultado.Text != null)
			{
				Entidades.Numero resultado = new Numero();
				lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);
			}
		}
	}
}