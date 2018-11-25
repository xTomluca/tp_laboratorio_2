namespace FrmPpal
{
    partial class FrmPpal
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstadoIngresado = new System.Windows.Forms.Label();
            this.lblEstadoEnViaje = new System.Windows.Forms.Label();
            this.lblEstadoEntregado = new System.Windows.Forms.Label();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lstEstadoIngresado = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEstadoIngresado);
            this.groupBox1.Controls.Add(this.lblEstadoEnViaje);
            this.groupBox1.Controls.Add(this.lblEstadoEntregado);
            this.groupBox1.Controls.Add(this.lstEstadoEntregado);
            this.groupBox1.Controls.Add(this.lstEstadoEnViaje);
            this.groupBox1.Controls.Add(this.lstEstadoIngresado);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estados Paquetes";
            // 
            // lblEstadoIngresado
            // 
            this.lblEstadoIngresado.AutoSize = true;
            this.lblEstadoIngresado.Location = new System.Drawing.Point(13, 34);
            this.lblEstadoIngresado.Name = "lblEstadoIngresado";
            this.lblEstadoIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblEstadoIngresado.TabIndex = 5;
            this.lblEstadoIngresado.Text = "Ingresado";
            // 
            // lblEstadoEnViaje
            // 
            this.lblEstadoEnViaje.AutoSize = true;
            this.lblEstadoEnViaje.Location = new System.Drawing.Point(271, 34);
            this.lblEstadoEnViaje.Name = "lblEstadoEnViaje";
            this.lblEstadoEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEstadoEnViaje.TabIndex = 4;
            this.lblEstadoEnViaje.Text = "En Viaje";
            // 
            // lblEstadoEntregado
            // 
            this.lblEstadoEntregado.AutoSize = true;
            this.lblEstadoEntregado.Location = new System.Drawing.Point(531, 34);
            this.lblEstadoEntregado.Name = "lblEstadoEntregado";
            this.lblEstadoEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEstadoEntregado.TabIndex = 3;
            this.lblEstadoEntregado.Text = "Entregado";
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.ContextMenuStrip = this.contextMenuStrip1;
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(534, 59);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(227, 225);
            this.lstEstadoEntregado.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // lstEstadoEnViaje
            // 
            this.lstEstadoEnViaje.FormattingEnabled = true;
            this.lstEstadoEnViaje.Location = new System.Drawing.Point(274, 59);
            this.lstEstadoEnViaje.Name = "lstEstadoEnViaje";
            this.lstEstadoEnViaje.Size = new System.Drawing.Size(227, 225);
            this.lstEstadoEnViaje.TabIndex = 1;
            // 
            // lstEstadoIngresado
            // 
            this.lstEstadoIngresado.FormattingEnabled = true;
            this.lstEstadoIngresado.Location = new System.Drawing.Point(16, 59);
            this.lstEstadoIngresado.Name = "lstEstadoIngresado";
            this.lstEstadoIngresado.Size = new System.Drawing.Size(227, 225);
            this.lstEstadoIngresado.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.mtxtTrackingID);
            this.groupBox2.Controls.Add(this.lblTrackingID);
            this.groupBox2.Controls.Add(this.btnMostrarTodos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Location = new System.Drawing.Point(532, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paquete";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(156, 47);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(94, 20);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(13, 47);
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(128, 20);
            this.mtxtTrackingID.TabIndex = 4;
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(11, 25);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 3;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(157, 97);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(93, 20);
            this.btnMostrarTodos.TabIndex = 2;
            this.btnMostrarTodos.Text = "Mostrar Todo";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(13, 97);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(128, 20);
            this.txtDireccion.TabIndex = 0;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Enabled = false;
            this.rtbMostrar.Location = new System.Drawing.Point(12, 312);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(501, 126);
            this.rtbMostrar.TabIndex = 2;
            this.rtbMostrar.Text = "";
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por TomasLuca.Suarez.2C";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstadoIngresado;
        private System.Windows.Forms.Label lblEstadoEnViaje;
        private System.Windows.Forms.Label lblEstadoEntregado;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.ListBox lstEstadoEnViaje;
        private System.Windows.Forms.ListBox lstEstadoIngresado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

