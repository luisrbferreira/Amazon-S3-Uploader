namespace AmazonS3Uploader
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.lblNotificacoes = new System.Windows.Forms.Label();
            this.txtNotificacoes = new System.Windows.Forms.TextBox();
            this.txtFlash = new System.Windows.Forms.TextBox();
            this.fileSystemWatcherFlash = new System.IO.FileSystemWatcher();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.txtHttp = new System.Windows.Forms.TextBox();
            this.fileSystemWatcherHttp = new System.IO.FileSystemWatcher();
            this.gpbPastasMonitoradas = new System.Windows.Forms.GroupBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.pcbConectta = new System.Windows.Forms.PictureBox();
            this.gpbInformacoesServidor = new System.Windows.Forms.GroupBox();
            this.lblBucketName = new System.Windows.Forms.Label();
            this.txtBucketName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherFlash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherHttp)).BeginInit();
            this.gpbPastasMonitoradas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbConectta)).BeginInit();
            this.gpbInformacoesServidor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNotificacoes
            // 
            this.lblNotificacoes.AutoSize = true;
            this.lblNotificacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificacoes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotificacoes.Location = new System.Drawing.Point(10, 93);
            this.lblNotificacoes.Name = "lblNotificacoes";
            this.lblNotificacoes.Size = new System.Drawing.Size(82, 13);
            this.lblNotificacoes.TabIndex = 0;
            this.lblNotificacoes.Text = "Notificações:";
            // 
            // txtNotificacoes
            // 
            this.txtNotificacoes.Location = new System.Drawing.Point(13, 109);
            this.txtNotificacoes.Multiline = true;
            this.txtNotificacoes.Name = "txtNotificacoes";
            this.txtNotificacoes.ReadOnly = true;
            this.txtNotificacoes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotificacoes.Size = new System.Drawing.Size(469, 289);
            this.txtNotificacoes.TabIndex = 1;
            // 
            // txtFlash
            // 
            this.txtFlash.Location = new System.Drawing.Point(61, 36);
            this.txtFlash.Name = "txtFlash";
            this.txtFlash.ReadOnly = true;
            this.txtFlash.Size = new System.Drawing.Size(93, 23);
            this.txtFlash.TabIndex = 2;
            this.txtFlash.Text = "D:\\Flash";
            // 
            // fileSystemWatcherFlash
            // 
            this.fileSystemWatcherFlash.EnableRaisingEvents = true;
            this.fileSystemWatcherFlash.Filter = "*.mp4";
            this.fileSystemWatcherFlash.Path = "D:\\Flash";
            this.fileSystemWatcherFlash.SynchronizingObject = this;
            this.fileSystemWatcherFlash.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherFlash_Created);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(110, 98);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.ReadOnly = true;
            this.txtFiltro.Size = new System.Drawing.Size(43, 23);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.Text = "*.mp4";
            // 
            // txtHttp
            // 
            this.txtHttp.Location = new System.Drawing.Point(61, 65);
            this.txtHttp.Name = "txtHttp";
            this.txtHttp.ReadOnly = true;
            this.txtHttp.Size = new System.Drawing.Size(93, 23);
            this.txtHttp.TabIndex = 4;
            this.txtHttp.Text = "D:\\Http";
            // 
            // fileSystemWatcherHttp
            // 
            this.fileSystemWatcherHttp.EnableRaisingEvents = true;
            this.fileSystemWatcherHttp.Filter = "*.mp4";
            this.fileSystemWatcherHttp.Path = "D:\\Http";
            this.fileSystemWatcherHttp.SynchronizingObject = this;
            this.fileSystemWatcherHttp.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherHttp_Created);
            // 
            // gpbPastasMonitoradas
            // 
            this.gpbPastasMonitoradas.Controls.Add(this.lblFiltro);
            this.gpbPastasMonitoradas.Controls.Add(this.txtFiltro);
            this.gpbPastasMonitoradas.Controls.Add(this.txtFlash);
            this.gpbPastasMonitoradas.Controls.Add(this.txtHttp);
            this.gpbPastasMonitoradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbPastasMonitoradas.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.gpbPastasMonitoradas.Location = new System.Drawing.Point(493, 12);
            this.gpbPastasMonitoradas.Name = "gpbPastasMonitoradas";
            this.gpbPastasMonitoradas.Size = new System.Drawing.Size(206, 160);
            this.gpbPastasMonitoradas.TabIndex = 5;
            this.gpbPastasMonitoradas.TabStop = false;
            this.gpbPastasMonitoradas.Text = "Pastas Monitoradas";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFiltro.Location = new System.Drawing.Point(61, 101);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(43, 17);
            this.lblFiltro.TabIndex = 6;
            this.lblFiltro.Text = "Filtro:";
            // 
            // pcbConectta
            // 
            this.pcbConectta.Image = ((System.Drawing.Image)(resources.GetObject("pcbConectta.Image")));
            this.pcbConectta.Location = new System.Drawing.Point(12, 12);
            this.pcbConectta.Name = "pcbConectta";
            this.pcbConectta.Size = new System.Drawing.Size(471, 70);
            this.pcbConectta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbConectta.TabIndex = 6;
            this.pcbConectta.TabStop = false;
            // 
            // gpbInformacoesServidor
            // 
            this.gpbInformacoesServidor.Controls.Add(this.txtBucketName);
            this.gpbInformacoesServidor.Controls.Add(this.lblBucketName);
            this.gpbInformacoesServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInformacoesServidor.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.gpbInformacoesServidor.Location = new System.Drawing.Point(493, 178);
            this.gpbInformacoesServidor.Name = "gpbInformacoesServidor";
            this.gpbInformacoesServidor.Size = new System.Drawing.Size(206, 220);
            this.gpbInformacoesServidor.TabIndex = 7;
            this.gpbInformacoesServidor.TabStop = false;
            this.gpbInformacoesServidor.Text = "Informações Amazon S3";
            // 
            // lblBucketName
            // 
            this.lblBucketName.AutoSize = true;
            this.lblBucketName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBucketName.Location = new System.Drawing.Point(6, 32);
            this.lblBucketName.Name = "lblBucketName";
            this.lblBucketName.Size = new System.Drawing.Size(92, 17);
            this.lblBucketName.TabIndex = 0;
            this.lblBucketName.Text = "BucketName:";
            // 
            // txtBucketName
            // 
            this.txtBucketName.Location = new System.Drawing.Point(99, 29);
            this.txtBucketName.Name = "txtBucketName";
            this.txtBucketName.ReadOnly = true;
            this.txtBucketName.Size = new System.Drawing.Size(100, 23);
            this.txtBucketName.TabIndex = 1;
            this.txtBucketName.Text = "teste-alba";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 410);
            this.Controls.Add(this.gpbInformacoesServidor);
            this.Controls.Add(this.pcbConectta);
            this.Controls.Add(this.gpbPastasMonitoradas);
            this.Controls.Add(this.txtNotificacoes);
            this.Controls.Add(this.lblNotificacoes);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Monitoramento e Upload";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherFlash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherHttp)).EndInit();
            this.gpbPastasMonitoradas.ResumeLayout(false);
            this.gpbPastasMonitoradas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbConectta)).EndInit();
            this.gpbInformacoesServidor.ResumeLayout(false);
            this.gpbInformacoesServidor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotificacoes;
        private System.Windows.Forms.TextBox txtNotificacoes;
        private System.Windows.Forms.TextBox txtFlash;
        private System.IO.FileSystemWatcher fileSystemWatcherFlash;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TextBox txtHttp;
        private System.IO.FileSystemWatcher fileSystemWatcherHttp;
        private System.Windows.Forms.PictureBox pcbConectta;
        private System.Windows.Forms.GroupBox gpbPastasMonitoradas;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.GroupBox gpbInformacoesServidor;
        private System.Windows.Forms.TextBox txtBucketName;
        private System.Windows.Forms.Label lblBucketName;
    }
}