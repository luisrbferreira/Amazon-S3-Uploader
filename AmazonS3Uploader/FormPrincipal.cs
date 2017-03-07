using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonS3Uploader
{
    public partial class frmPrincipal : Form
    {
        static string existingBucketName = "teste-alba";       
        private string delimiter = "/";
        private string subFolderFlash = "Flash";

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

        private void Upload(string filePath)
        {
            try
            {
                Amazon.Util.ProfileManager.RegisterProfile("Luis Ferreira", "keyId", "secretKey");

                TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.SAEast1));

                // Specify advanced settings/options.
                TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = string.Concat(existingBucketName, delimiter, subFolderFlash),
                    FilePath = filePath,
                    StorageClass = S3StorageClass.ReducedRedundancy,
                    PartSize = 6291456, // 6 MB.
                    CannedACL = S3CannedACL.PublicRead
                };

                fileTransferUtility.Upload(fileTransferUtilityRequest);

                txtNotificacoes.Text = "Upload do arquivo completo";
            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
            }
        }

        private void fileSystemWatcherFlash_Created(object sender, FileSystemEventArgs e)
        {
            Upload("D:\\Flash\\" + e.Name);
        }
    }
}