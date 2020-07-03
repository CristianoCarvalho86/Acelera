namespace Editor
{
    partial class FrmEditor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.txtArrquivo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.gridHeader = new System.Windows.Forms.DataGridView();
            this.gridFooter = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFooter)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1086, 477);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(769, 25);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(75, 23);
            this.btnCarregar.TabIndex = 1;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // txtArrquivo
            // 
            this.txtArrquivo.Location = new System.Drawing.Point(12, 27);
            this.txtArrquivo.Name = "txtArrquivo";
            this.txtArrquivo.Size = new System.Drawing.Size(650, 20);
            this.txtArrquivo.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(679, 24);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 3;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // gridHeader
            // 
            this.gridHeader.AllowUserToAddRows = false;
            this.gridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHeader.Location = new System.Drawing.Point(12, 81);
            this.gridHeader.Name = "gridHeader";
            this.gridHeader.Size = new System.Drawing.Size(1086, 55);
            this.gridHeader.TabIndex = 4;
            this.gridHeader.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHeader_CellValueChanged);
            // 
            // gridFooter
            // 
            this.gridFooter.AllowUserToAddRows = false;
            this.gridFooter.AllowUserToDeleteRows = false;
            this.gridFooter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFooter.Location = new System.Drawing.Point(12, 657);
            this.gridFooter.Name = "gridFooter";
            this.gridFooter.Size = new System.Drawing.Size(1086, 55);
            this.gridFooter.TabIndex = 5;
            this.gridFooter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFooter_CellValueChanged);
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 781);
            this.Controls.Add(this.gridFooter);
            this.Controls.Add(this.gridHeader);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.txtArrquivo);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmEditor";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFooter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.TextBox txtArrquivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.DataGridView gridHeader;
        private System.Windows.Forms.DataGridView gridFooter;
    }
}

