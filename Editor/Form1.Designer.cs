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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditor));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.txtArrquivo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.gridHeader = new System.Windows.Forms.DataGridView();
            this.gridFooter = new System.Windows.Forms.DataGridView();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerCarregar = new System.ComponentModel.BackgroundWorker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnCopiarLinha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 173);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1086, 462);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
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
            this.gridHeader.BackgroundColor = System.Drawing.Color.White;
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
            this.gridFooter.BackgroundColor = System.Drawing.Color.White;
            this.gridFooter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFooter.Location = new System.Drawing.Point(12, 657);
            this.gridFooter.Name = "gridFooter";
            this.gridFooter.Size = new System.Drawing.Size(1086, 55);
            this.gridFooter.TabIndex = 5;
            this.gridFooter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFooter_CellValueChanged);
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(460, 299);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(161, 156);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 6;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // backgroundWorkerCarregar
            // 
            this.backgroundWorkerCarregar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCarregar_DoWork);
            this.backgroundWorkerCarregar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCarregar_RunWorkerCompleted);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(859, 25);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Location = new System.Drawing.Point(681, 139);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(135, 32);
            this.btnAddRow.TabIndex = 8;
            this.btnAddRow.Text = "Adicionar Linha";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRow.Location = new System.Drawing.Point(822, 139);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(135, 32);
            this.btnRemoveRow.TabIndex = 9;
            this.btnRemoveRow.Text = "Remover Linha";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnCopiarLinha
            // 
            this.btnCopiarLinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiarLinha.Location = new System.Drawing.Point(963, 139);
            this.btnCopiarLinha.Name = "btnCopiarLinha";
            this.btnCopiarLinha.Size = new System.Drawing.Size(135, 32);
            this.btnCopiarLinha.TabIndex = 10;
            this.btnCopiarLinha.Text = "Copiar Linha";
            this.btnCopiarLinha.UseVisualStyleBackColor = true;
            this.btnCopiarLinha.Click += new System.EventHandler(this.btnCopiarLinha_Click);
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 781);
            this.Controls.Add(this.btnCopiarLinha);
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picLoading);
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
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
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
        private System.Windows.Forms.PictureBox picLoading;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCarregar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnCopiarLinha;
    }
}

