namespace MiCalculadora
{
	partial class LaCalculadora
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaCalculadora));
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.btnOperar = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnConvertirABinario = new System.Windows.Forms.Button();
			this.btnConvertirADecimal = new System.Windows.Forms.Button();
			this.cmbOperador = new System.Windows.Forms.ComboBox();
			this.txtNumero2 = new System.Windows.Forms.TextBox();
			this.txtNumero1 = new System.Windows.Forms.TextBox();
			this.lblResultado = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Default;
			resources.ApplyResources(this.btnLimpiar, "btnLimpiar");
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.UseVisualStyleBackColor = true;
			this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
			// 
			// btnOperar
			// 
			resources.ApplyResources(this.btnOperar, "btnOperar");
			this.btnOperar.Name = "btnOperar";
			this.btnOperar.UseVisualStyleBackColor = true;
			this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
			// 
			// btnCerrar
			// 
			resources.ApplyResources(this.btnCerrar, "btnCerrar");
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnConvertirABinario
			// 
			resources.ApplyResources(this.btnConvertirABinario, "btnConvertirABinario");
			this.btnConvertirABinario.Name = "btnConvertirABinario";
			this.btnConvertirABinario.UseVisualStyleBackColor = true;
			this.btnConvertirABinario.Click += new System.EventHandler(this.btnConvertirABinario_Click);
			// 
			// btnConvertirADecimal
			// 
			resources.ApplyResources(this.btnConvertirADecimal, "btnConvertirADecimal");
			this.btnConvertirADecimal.Name = "btnConvertirADecimal";
			this.btnConvertirADecimal.UseVisualStyleBackColor = true;
			this.btnConvertirADecimal.Click += new System.EventHandler(this.btnConvertirADecimal_Click);
			// 
			// cmbOperador
			// 
			this.cmbOperador.FormattingEnabled = true;
			this.cmbOperador.Items.AddRange(new object[] {
            resources.GetString("cmbOperador.Items"),
            resources.GetString("cmbOperador.Items1"),
            resources.GetString("cmbOperador.Items2"),
            resources.GetString("cmbOperador.Items3")});
			resources.ApplyResources(this.cmbOperador, "cmbOperador");
			this.cmbOperador.Name = "cmbOperador";
			// 
			// txtNumero2
			// 
			resources.ApplyResources(this.txtNumero2, "txtNumero2");
			this.txtNumero2.Name = "txtNumero2";
			// 
			// txtNumero1
			// 
			resources.ApplyResources(this.txtNumero1, "txtNumero1");
			this.txtNumero1.Name = "txtNumero1";
			// 
			// lblResultado
			// 
			resources.ApplyResources(this.lblResultado, "lblResultado");
			this.lblResultado.Name = "lblResultado";
			// 
			// LaCalculadora
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblResultado);
			this.Controls.Add(this.txtNumero1);
			this.Controls.Add(this.txtNumero2);
			this.Controls.Add(this.cmbOperador);
			this.Controls.Add(this.btnConvertirADecimal);
			this.Controls.Add(this.btnConvertirABinario);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.btnOperar);
			this.Controls.Add(this.btnLimpiar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LaCalculadora";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.Button btnOperar;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Button btnConvertirABinario;
		private System.Windows.Forms.Button btnConvertirADecimal;
		private System.Windows.Forms.ComboBox cmbOperador;
		private System.Windows.Forms.TextBox txtNumero2;
		private System.Windows.Forms.TextBox txtNumero1;
		private System.Windows.Forms.Label lblResultado;
	}
}

