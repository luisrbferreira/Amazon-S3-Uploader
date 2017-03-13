using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AmazonS3Uploader
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void MonitorarFlash()
        {
            FileSystemWatcher fswFlash = this.fileSystemWatcherFlash;

            //Caminho da pasta a ser monitorada
            fswFlash.Path = txtFlash.Text;

            //Tipo de filtro a ser considerado
            fswFlash.Filter = txtFiltro.Text;

            //Atributos que irão disparar eventos
            fswFlash.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;

            //Permitir o monitoramento
            fswFlash.EnableRaisingEvents = true;

            //Incluir monitoramento de SubDiretórios
            fswFlash.IncludeSubdirectories = true;

            //Classe WaitForChangedResults, passando o FSW com o método WaitForChanged e o
            //parâmetro de modificações que ele irá aguardar, que no caso são todas
            WaitForChangedResult wrc = fswFlash.WaitForChanged(WatcherChangeTypes.All, 10000);
        }

        private void MonitorarHttp()
        {
            FileSystemWatcher fswHttp = this.fileSystemWatcherHttp;

            //Caminho da pasta a ser monitorada
            fswHttp.Path = txtFlash.Text;

            //Tipo de filtro a ser considerado
            fswHttp.Filter = txtFiltro.Text;

            //Atributos que irão disparar eventos
            fswHttp.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;

            //Permitir o monitoramento
            fswHttp.EnableRaisingEvents = true;

            //Incluir monitoramento de SubDiretórios
            fswHttp.IncludeSubdirectories = true;

            //Classe WaitForChangedResults, passando o FSW com o método WaitForChanged e o
            //parâmetro de modificações que ele irá aguardar, que no caso são todas
            WaitForChangedResult wrc = fswHttp.WaitForChanged(WatcherChangeTypes.All, 10000);
        }

        private void FazerUploadAssync(string subFolder, string fileName, string filePath, WatcherChangeTypes type)
        {
            AmazonS3Uploader.Delegates.Upload_ExclusaoDelegate caller = new AmazonS3Uploader.Delegates.Upload_ExclusaoDelegate(this.FazerUpload);
            caller.BeginInvoke(subFolder, fileName, filePath, type, null, null);
        }

        private void ExclusaoAssync(string subFolder, string fileName, string filePath, WatcherChangeTypes type)
        {
            AmazonS3Uploader.Delegates.Upload_ExclusaoDelegate caller = new AmazonS3Uploader.Delegates.Upload_ExclusaoDelegate(this.ExcluirArquivo);
            caller.BeginInvoke(subFolder, fileName, filePath, type, null, null);
        }

        private void RenomeacaoAssync(string oldName, string subFolder, string fileName, string filePath, WatcherChangeTypes type)
        {
            AmazonS3Uploader.Delegates.RenomeacaoDelegate caller = new AmazonS3Uploader.Delegates.RenomeacaoDelegate(this.RenomearArquivo);
            caller.BeginInvoke(oldName, subFolder, fileName, filePath, type, null, null);
        }

        private void ShowText(string text)
        {
            if (txtNotificacoes.InvokeRequired)
            {
                AmazonS3Uploader.Delegates.ShowTextDelegate textDelegate = new AmazonS3Uploader.Delegates.ShowTextDelegate(ShowText);

                txtNotificacoes.Invoke(textDelegate, text);
            }

            else
            {
                txtNotificacoes.AppendText(text);
            }
        }

        private void FazerUpload(string subFolder, string fileName, string filePath, WatcherChangeTypes type)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Criado em: {0} {1}", filePath, Environment.NewLine);

            Informacoes(fileName, type);

            sb.AppendFormat("Transferindo o arquivo {0} para o servidor, aguarde...{1}", fileName, Environment.NewLine);

            ShowText(sb.ToString());

            bool mustRepeat = true;

            try
            {
                while (mustRepeat)
                {
                    Thread.Sleep(240000);

                    Application.DoEvents();

                    AmazonS3 s3 = new AmazonS3(this.ShowText, subFolder, fileName, filePath);

                    s3.UploadFile();

                    mustRepeat = false;
                }
            }
            catch (Exception ex)
            {
                ShowText(ex.Message);
            }
        }

        private void ExcluirArquivo(string subFolder, string fileName, string filePath, WatcherChangeTypes type)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Localizado em: {0} {1}", filePath, Environment.NewLine);

            Informacoes(fileName, type);

            sb.AppendFormat("Excluindo o arquivo {0} do servidor, aguarde...{1}", fileName, Environment.NewLine);

            ShowText(sb.ToString());

            bool mustRepeat = true;

            try
            {
                while (mustRepeat)
                {
                    Thread.Sleep(10000);

                    Application.DoEvents();

                    AmazonS3 s3 = new AmazonS3(this.ShowText, subFolder, fileName, filePath);

                    s3.DeleteFile();

                    mustRepeat = false;
                }
            }
            catch (Exception ex)
            {
                ShowText(ex.Message);
            }
        }

        private void RenomearArquivo(string oldName, string subFolder, string fileName, string filePath, WatcherChangeTypes type)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Localizado em: {0} {1}", filePath, Environment.NewLine);

            Informacoes(fileName, type);

            sb.AppendFormat("Renomeando o arquivo {0} no servidor, aguarde...{1}", oldName, Environment.NewLine);

            ShowText(sb.ToString());

            bool mustRepeat = true;

            try
            {
                while (mustRepeat)
                {
                    Thread.Sleep(10000);

                    Application.DoEvents();

                    AmazonS3 s3 = new AmazonS3(this.ShowText, subFolder, fileName, filePath);

                    s3.RenameFile(oldName);

                    mustRepeat = false;
                }
            }
            catch (Exception ex)
            {
                ShowText(ex.Message);
            }
        }

        private void Informacoes(string fileName, WatcherChangeTypes type)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("--------------------------------------------------------------------------------------------------------------------------------------------------{0}Evento: {1} {2}", Environment.NewLine, type, Environment.NewLine);

            sb.AppendFormat("Nome: {0} {1}", fileName, Environment.NewLine);

            ShowText(sb.ToString());
        }

        private void fileSystemWatcherFlash_Created(object sender, FileSystemEventArgs e)
        {
            string subFolder = "Flash";

            this.FazerUploadAssync(subFolder, e.Name, e.FullPath, e.ChangeType);
        }

        private void fileSystemWatcherFlash_Deleted(object sender, FileSystemEventArgs e)
        {
            string subFolder = "Flash";

            this.ExclusaoAssync(subFolder, e.Name, e.FullPath, e.ChangeType);
        }

        private void fileSystemWatcherFlash_Renamed(object sender, RenamedEventArgs e)
        {
            string subFolder = "Flash";

            this.RenomeacaoAssync(e.OldName, subFolder, e.Name, e.FullPath, e.ChangeType);
        }

        private void fileSystemWatcherHttp_Created(object sender, FileSystemEventArgs e)
        {
            string subFolder = "Http";

            this.FazerUploadAssync(subFolder, e.Name, e.FullPath, e.ChangeType);
        }

        private void fileSystemWatcherHttp_Deleted(object sender, FileSystemEventArgs e)
        {
            string subFolder = "Http";

            this.ExclusaoAssync(subFolder, e.Name, e.FullPath, e.ChangeType);
        }

        private void fileSystemWatcherHttp_Renamed(object sender, RenamedEventArgs e)
        {
            string subFolder = "Http";

            this.RenomeacaoAssync(e.OldName, subFolder, e.Name, e.FullPath, e.ChangeType);
        }
    }
}