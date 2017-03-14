using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.IO;
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
        static IAmazonS3 client;

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

        public void UploadFile()
        {
            try
            {
                Amazon.Util.ProfileManager.RegisterProfile("Luis Ferreira", "keyID", "secretKey");

                TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.SAEast1));

                //Specify advanced settings / options.
                TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = string.Concat(bucketName, delimiter, subFolder),
                    FilePath = filePath,
                    StorageClass = S3StorageClass.ReducedRedundancy,
                    PartSize = 6291456, // 6 MB.
                    CannedACL = S3CannedACL.PublicRead
                };

                fileTransferUtilityRequest.UploadProgressEvent +=
                    new EventHandler<UploadProgressArgs>
                    (fileTransferUtilityRequest_UploadPartProgressEvent);

                fileTransferUtility.UploadAsync(fileTransferUtilityRequest);
            }
            catch (AmazonS3Exception s3Exception)
            {
                string message = string.Format("-------------------------------------------------------------------------------------------------------------------------------------------------{0}Erro ao tentar fazer o upload do arquivo{1}: {2}\r\n\r\n{3}{4}", Environment.NewLine, s3Exception.Message, s3Exception.StackTrace, Environment.NewLine);

                if (this.showTextCallback == null)
                {
                    MessageBox.Show(s3Exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    this.showTextCallback(message);
                }
            }
        }

        private void fileTransferUtilityRequest_UploadPartProgressEvent(object sender, UploadProgressArgs e)
        {
            if (e.TransferredBytes == e.TotalBytes)
            {
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
        }

        public void DeleteFile()
        {
            using (client = new AmazonS3Client(Amazon.RegionEndpoint.SAEast1))
            {
                DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = string.Concat(bucketName, delimiter, subFolder),
                    Key = fileName
                };

                try
                {
                    client.DeleteObject(deleteObjectRequest);

                    string message = string.Format("-------------------------------------------------------------------------------------------------------------------------------------------------{0}Arquivo {1} deletado com Sucesso!{2}", Environment.NewLine, fileName, Environment.NewLine);

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
                    string message = string.Format("-------------------------------------------------------------------------------------------------------------------------------------------------{0}Erro ao tentar fazer o upload do arquivo{1}: {2}\r\n\r\n{3}{4}", Environment.NewLine, s3Exception.Message, s3Exception.StackTrace, Environment.NewLine);

                    if (this.showTextCallback == null)
                    {
                        MessageBox.Show(s3Exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        this.showTextCallback(message);
                    }
                }
            }
        }

        public void RenameFile(string name)
        {
            using (client = new AmazonS3Client(Amazon.RegionEndpoint.SAEast1))
            {
                try
                {
                    CopyObjectRequest request = new CopyObjectRequest
                    {
                        SourceBucket = string.Concat(bucketName, delimiter, subFolder),
                        SourceKey = name,
                        DestinationBucket = string.Concat(bucketName, delimiter, subFolder),
                        DestinationKey = fileName,
                        StorageClass = S3StorageClass.ReducedRedundancy
                    };
                    CopyObjectResponse response = client.CopyObject(request);

                    DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = string.Concat(bucketName, delimiter, subFolder),
                        Key = name
                    };

                    client.DeleteObject(deleteObjectRequest);

                    string message = string.Format("-------------------------------------------------------------------------------------------------------------------------------------------------{0}Arquivo {1} renomeado com sucesso para {2}{3}", Environment.NewLine, name, fileName, Environment.NewLine);

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
                    string message = string.Format("-------------------------------------------------------------------------------------------------------------------------------------------------{0}Erro ao tentar fazer o upload do arquivo{1}: {2}\r\n\r\n{3}{4}", Environment.NewLine, s3Exception.Message, s3Exception.StackTrace, Environment.NewLine);

                    if (this.showTextCallback == null)
                    {
                        MessageBox.Show(s3Exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        this.showTextCallback(message);
                    }
                }
            }
        }
    }
}