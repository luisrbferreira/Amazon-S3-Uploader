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
            this.lblNotificacoes = new System.Windows.Forms.Label();
            this.txtNotificacoes = new System.Windows.Forms.TextBox();
            this.txtFlash = new System.Windows.Forms.TextBox();
            this.fileSystemWatcherFlash = new System.IO.FileSystemWatcher();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherFlash)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotificacoes
            // 
            this.lblNotificacoes.AutoSize = true;
            this.lblNotificacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificacoes.Location = new System.Drawing.Point(12, 79);
            this.lblNotificacoes.Name = "lblNotificacoes";
            this.lblNotificacoes.Size = new System.Drawing.Size(82, 13);
            this.lblNotificacoes.TabIndex = 0;
            this.lblNotificacoes.Text = "Notificações:";
            // 
            // txtNotificacoes
            // 
            this.txtNotificacoes.Location = new System.Drawing.Point(13, 95);
            this.txtNotificacoes.Multiline = true;
            this.txtNotificacoes.Name = "txtNotificacoes";
            this.txtNotificacoes.ReadOnly = true;
            this.txtNotificacoes.Size = new System.Drawing.Size(259, 154);
            this.txtNotificacoes.TabIndex = 1;
            // 
            // txtFlash
            // 
            this.txtFlash.Location = new System.Drawing.Point(13, 13);
            this.txtFlash.Name = "txtFlash";
            this.txtFlash.ReadOnly = true;
            this.txtFlash.Size = new System.Drawing.Size(81, 20);
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
            this.txtFiltro.Location = new System.Drawing.Point(13, 40);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.ReadOnly = true;
            this.txtFiltro.Size = new System.Drawing.Size(81, 20);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.Text = "*.mp4";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.txtFlash);
            this.Controls.Add(this.txtNotificacoes);
            this.Controls.Add(this.lblNotificacoes);
            this.Name = "frmPrincipal";
            this.Text = "FormPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherFlash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotificacoes;
        private System.Windows.Forms.TextBox txtNotificacoes;
        private System.Windows.Forms.TextBox txtFlash;
        private System.IO.FileSystemWatcher fileSystemWatcherFlash;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}