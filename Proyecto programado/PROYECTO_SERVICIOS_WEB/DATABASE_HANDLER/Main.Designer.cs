namespace DATABASE_HANDLER
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_crear_registros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_crear_registros
            // 
            this.button_crear_registros.Location = new System.Drawing.Point(25, 32);
            this.button_crear_registros.Name = "button_crear_registros";
            this.button_crear_registros.Size = new System.Drawing.Size(164, 23);
            this.button_crear_registros.TabIndex = 0;
            this.button_crear_registros.Text = "INIT de registros iniciales";
            this.button_crear_registros.UseVisualStyleBackColor = true;
            this.button_crear_registros.Click += new System.EventHandler(this.button_crear_registros_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 84);
            this.Controls.Add(this.button_crear_registros);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_crear_registros;
    }
}