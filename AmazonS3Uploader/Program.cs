using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Windows.Forms;
using AmazonS3Uploader;

namespace s3.amazon.com.docsamples
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPrincipal());
        }
    }
}