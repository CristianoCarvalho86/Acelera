namespace Editor
{
    partial class LinhaFiltro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPropriedade = new System.Windows.Forms.Label();
            this.txtValorPropriedade = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // lblPropriedade
            // 
            this.lblPropriedade.AutoSize = true;
            this.lblPropriedade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropriedade.Location = new System.Drawing.Point(4, 5);
            this.lblPropriedade.Name = "lblPropriedade";
            this.lblPropriedade.Size = new System.Drawing.Size(46, 18);
            this.lblPropriedade.TabIndex = 0;
            this.lblPropriedade.Text = "label1";
            // 
            // txtValorPropriedade
            // 
            this.txtValorPropriedade.Location = new System.Drawing.Point(324, 3);
            this.txtValorPropriedade.Name = "txtValorPropriedade";
            this.txtValorPropriedade.Size = new System.Drawing.Size(276, 20);
            this.txtValorPropriedade.TabIndex = 1;
            this.txtValorPropriedade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorPropriedade_KeyDown);
            this.txtValorPropriedade.Leave += new System.EventHandler(this.txtValorPropriedade_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LinhaFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtValorPropriedade);
            this.Controls.Add(this.lblPropriedade);
            this.Name = "LinhaFiltro";
            this.Size = new System.Drawing.Size(603, 27);
            this.Load += new System.EventHandler(this.LinhaFiltro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPropriedade;
        private System.Windows.Forms.TextBox txtValorPropriedade;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
