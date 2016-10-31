namespace Presentacion
{
    partial class Inicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ciclo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_nombreCiclo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.date_InicioCiclo = new System.Windows.Forms.DateTimePicker();
            this.date_FinCiclo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_primaria = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_secuntaria_a = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_secundaria_b = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_pre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_principal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciclo:";
            // 
            // cb_ciclo
            // 
            this.cb_ciclo.FormattingEnabled = true;
            this.cb_ciclo.Location = new System.Drawing.Point(70, 67);
            this.cb_ciclo.Name = "cb_ciclo";
            this.cb_ciclo.Size = new System.Drawing.Size(167, 21);
            this.cb_ciclo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_pre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tb_secundaria_b);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_secuntaria_a);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_primaria);
            this.groupBox1.Controls.Add(this.date_FinCiclo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.date_InicioCiclo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_nombreCiclo);
            this.groupBox1.Location = new System.Drawing.Point(13, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 307);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del Ciclo";
            // 
            // tb_nombreCiclo
            // 
            this.tb_nombreCiclo.Location = new System.Drawing.Point(57, 42);
            this.tb_nombreCiclo.Name = "tb_nombreCiclo";
            this.tb_nombreCiclo.Size = new System.Drawing.Size(167, 20);
            this.tb_nombreCiclo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Inicio:";
            // 
            // date_InicioCiclo
            // 
            this.date_InicioCiclo.Location = new System.Drawing.Point(57, 89);
            this.date_InicioCiclo.Name = "date_InicioCiclo";
            this.date_InicioCiclo.Size = new System.Drawing.Size(169, 20);
            this.date_InicioCiclo.TabIndex = 5;
            // 
            // date_FinCiclo
            // 
            this.date_FinCiclo.Location = new System.Drawing.Point(55, 137);
            this.date_FinCiclo.Name = "date_FinCiclo";
            this.date_FinCiclo.Size = new System.Drawing.Size(169, 20);
            this.date_FinCiclo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Primaria";
            // 
            // tb_primaria
            // 
            this.tb_primaria.Location = new System.Drawing.Point(55, 197);
            this.tb_primaria.Name = "tb_primaria";
            this.tb_primaria.Size = new System.Drawing.Size(69, 20);
            this.tb_primaria.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Secundaria 1° y 2°";
            // 
            // tb_secuntaria_a
            // 
            this.tb_secuntaria_a.Location = new System.Drawing.Point(55, 223);
            this.tb_secuntaria_a.Name = "tb_secuntaria_a";
            this.tb_secuntaria_a.Size = new System.Drawing.Size(69, 20);
            this.tb_secuntaria_a.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Secundaria 3°, 4° y 5°";
            // 
            // tb_secundaria_b
            // 
            this.tb_secundaria_b.Location = new System.Drawing.Point(55, 249);
            this.tb_secundaria_b.Name = "tb_secundaria_b";
            this.tb_secundaria_b.Size = new System.Drawing.Size(69, 20);
            this.tb_secundaria_b.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(130, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Pre-Universitario";
            // 
            // tb_pre
            // 
            this.tb_pre.Location = new System.Drawing.Point(55, 275);
            this.tb_pre.Name = "tb_pre";
            this.tb_pre.Size = new System.Drawing.Size(69, 20);
            this.tb_pre.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Costos por Niveles:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Bienvenido ";
            // 
            // btn_principal
            // 
            this.btn_principal.Location = new System.Drawing.Point(112, 421);
            this.btn_principal.Name = "btn_principal";
            this.btn_principal.Size = new System.Drawing.Size(75, 23);
            this.btn_principal.TabIndex = 4;
            this.btn_principal.Text = "INGRESAR";
            this.btn_principal.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 456);
            this.Controls.Add(this.btn_principal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb_ciclo);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.Text = "Sistema Informático Jonh Neper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_ciclo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_pre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_secundaria_b;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_secuntaria_a;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_primaria;
        private System.Windows.Forms.DateTimePicker date_FinCiclo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_InicioCiclo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nombreCiclo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_principal;
    }
}

