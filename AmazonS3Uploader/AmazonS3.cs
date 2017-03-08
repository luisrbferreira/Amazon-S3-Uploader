using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Windows.Forms;

namespace AmazonS3Uploader
{
    public class AmazonS3
    {
        private string bucketName = "teste-alba"; //Nome do balde no Amazon S3
        private string delimiter = "/";
        private string subFolder; //Nome da sub pasta dentro do balde
        private string fileName; //Nome do arquivo que vai ser feito o upload
        private string filePath; //Caminho local do arquivo

        private Delegates.ShowTextDelegate showTextCallback;

        public AmazonS3(string subFolder, string fileName, string filePath)
        {
            this.subFolder = subFolder;
            this.fileName = fileName;
            this.filePath = filePath;
        }

        public AmazonS3(AmazonS3Uploader.Delegates.ShowTextDelegate showTextCallback, string subFolder, string fileName, string filePath)
            : this(subFolder, fileName, filePath)
        {
            this.showTextCallback = showTextCallback;
        }

        public string SubFolder
        {
            get { return this.subFolder; }
            set { this.subFolder = value; }
        }

        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }

        public void Upload()
        {
            try
            {
                Amazon.Util.ProfileManager.RegisterProfile("Luis Ferreira", "keyId", "secretKey");

                TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.SAEast1));

                // Specify advanced settings/options.
                TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = string.Concat(bucketName, delimiter, subFolder),
                    FilePath = filePath,
                    StorageClass = S3StorageClass.ReducedRedundancy,
                    PartSize = 6291456, // 6 MB.
                    CannedACL = S3CannedACL.PublicRead
                };

                fileTransferUtility.Upload(fileTransferUtilityRequest);

                string message = string.Format("-------------------------------------------------------------------------------------------------------------------------------------------------{0}Upload do arquivo {1} feito com Sucesso!{2}", Environment.NewLine, fileName, Environment.NewLine);

                if (this.showTextCallback == null)
                {
                    MessageBox.Show(message);
                }
                else
                {
                    this.showTextCallback(message);
                }
            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
            }
        }
    }
}
