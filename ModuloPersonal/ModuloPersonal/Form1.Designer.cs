﻿namespace ModuloPersonal
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.habitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeHabitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reservacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarReservacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleFolioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeHabitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservacionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habitacionToolStripMenuItem,
            this.reservacionesToolStripMenuItem,
            this.folioToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // habitacionToolStripMenuItem
            // 
            this.habitacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDeHabitacionesToolStripMenuItem,
            this.habitacionesToolStripMenuItem1});
            this.habitacionToolStripMenuItem.Name = "habitacionToolStripMenuItem";
            this.habitacionToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.habitacionToolStripMenuItem.Text = "Habitaciones";
            this.habitacionToolStripMenuItem.Click += new System.EventHandler(this.habitacionToolStripMenuItem_Click);
            // 
            // tiposDeHabitacionesToolStripMenuItem
            // 
            this.tiposDeHabitacionesToolStripMenuItem.Name = "tiposDeHabitacionesToolStripMenuItem";
            this.tiposDeHabitacionesToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.tiposDeHabitacionesToolStripMenuItem.Text = "Tipos de habitaciones";
            this.tiposDeHabitacionesToolStripMenuItem.Click += new System.EventHandler(this.tiposDeHabitacionesToolStripMenuItem_Click);
            // 
            // habitacionesToolStripMenuItem1
            // 
            this.habitacionesToolStripMenuItem1.Name = "habitacionesToolStripMenuItem1";
            this.habitacionesToolStripMenuItem1.Size = new System.Drawing.Size(229, 26);
            this.habitacionesToolStripMenuItem1.Text = "Detalle habitaciones";
            this.habitacionesToolStripMenuItem1.Click += new System.EventHandler(this.habitacionesToolStripMenuItem1_Click);
            // 
            // reservacionesToolStripMenuItem
            // 
            this.reservacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarReservacionToolStripMenuItem});
            this.reservacionesToolStripMenuItem.Name = "reservacionesToolStripMenuItem";
            this.reservacionesToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.reservacionesToolStripMenuItem.Text = "Reservaciones";
            this.reservacionesToolStripMenuItem.Click += new System.EventHandler(this.reservacionesToolStripMenuItem_Click);
            // 
            // realizarReservacionToolStripMenuItem
            // 
            this.realizarReservacionToolStripMenuItem.Name = "realizarReservacionToolStripMenuItem";
            this.realizarReservacionToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.realizarReservacionToolStripMenuItem.Text = "Realizar reservacion";
            this.realizarReservacionToolStripMenuItem.Click += new System.EventHandler(this.realizarReservacionToolStripMenuItem_Click);
            // 
            // folioToolStripMenuItem
            // 
            this.folioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoToolStripMenuItem,
            this.detalleFolioToolStripMenuItem});
            this.folioToolStripMenuItem.Name = "folioToolStripMenuItem";
            this.folioToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.folioToolStripMenuItem.Text = "Folio";
            this.folioToolStripMenuItem.Click += new System.EventHandler(this.folioToolStripMenuItem_Click);
            // 
            // ingresoToolStripMenuItem
            // 
            this.ingresoToolStripMenuItem.Name = "ingresoToolStripMenuItem";
            this.ingresoToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.ingresoToolStripMenuItem.Text = "Ingreso";
            this.ingresoToolStripMenuItem.Click += new System.EventHandler(this.ingresoToolStripMenuItem_Click);
            // 
            // detalleFolioToolStripMenuItem
            // 
            this.detalleFolioToolStripMenuItem.Name = "detalleFolioToolStripMenuItem";
            this.detalleFolioToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.detalleFolioToolStripMenuItem.Text = "Detalle folio";
            this.detalleFolioToolStripMenuItem.Click += new System.EventHandler(this.detalleFolioToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDeHabitacionToolStripMenuItem,
            this.habitacionesToolStripMenuItem,
            this.reservacionesToolStripMenuItem1,
            this.folioToolStripMenuItem1});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // tiposDeHabitacionToolStripMenuItem
            // 
            this.tiposDeHabitacionToolStripMenuItem.Name = "tiposDeHabitacionToolStripMenuItem";
            this.tiposDeHabitacionToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.tiposDeHabitacionToolStripMenuItem.Text = "Tipos de habitacion";
            this.tiposDeHabitacionToolStripMenuItem.Click += new System.EventHandler(this.tiposDeHabitacionToolStripMenuItem_Click);
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones";
            this.habitacionesToolStripMenuItem.Click += new System.EventHandler(this.habitacionesToolStripMenuItem_Click);
            // 
            // reservacionesToolStripMenuItem1
            // 
            this.reservacionesToolStripMenuItem1.Name = "reservacionesToolStripMenuItem1";
            this.reservacionesToolStripMenuItem1.Size = new System.Drawing.Size(215, 26);
            this.reservacionesToolStripMenuItem1.Text = "Reservaciones";
            this.reservacionesToolStripMenuItem1.Click += new System.EventHandler(this.reservacionesToolStripMenuItem1_Click);
            // 
            // folioToolStripMenuItem1
            // 
            this.folioToolStripMenuItem1.Name = "folioToolStripMenuItem1";
            this.folioToolStripMenuItem1.Size = new System.Drawing.Size(215, 26);
            this.folioToolStripMenuItem1.Text = "Folio";
            this.folioToolStripMenuItem1.Click += new System.EventHandler(this.folioToolStripMenuItem1_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 499);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalleFolioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarReservacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservacionesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem folioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiposDeHabitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeHabitacionToolStripMenuItem;
    }
}

