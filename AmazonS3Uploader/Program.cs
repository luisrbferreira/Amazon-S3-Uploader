using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace AmazonS3Uploader
{
    class Program
    {
        static string bucketName = "teste-alba";
        static string keyName = "canada";
        static string filePath = "D:\\Pictures\\canada.jpg";

        static IAmazonS3 client;

        public static void Main(string[] args)
        {
            Amazon.Util.ProfileManager.RegisterProfile("profileName", "AccessKeyId", "secretKey");

            using (client = new AmazonS3Client(Amazon.RegionEndpoint.SAEast1))
            {
                Console.WriteLine("Uploading an object");
                WritingAnObject();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void WritingAnObject()
        {
            try
            {
                //PutObjectRequest putRequest1 = new PutObjectRequest
                //{
                //    BucketName = bucketName,
                //    Key = keyName,
                //    ContentBody = "sample text"
                //};

                //PutObjectResponse response1 = client.PutObject(putRequest1);

                // 2. Put object-set ContentType and add metadata.
                PutObjectRequest putRequest2 = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = filePath,
                    ContentType = "image/jpeg"
                };
                putRequest2.Metadata.Add("x-amz-meta-title", "someTitle");

                PutObjectResponse response2 = client.PutObject(putRequest2);

            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    Console.WriteLine("Check the provided AWS Credentials.");
                    Console.WriteLine(
                        "For service sign up go to http://aws.amazon.com/s3");
                }
                else
                {
                    Console.WriteLine(
                        "Error occurred. Message:'{0}' when writing an object"
                        , amazonS3Exception.Message);
                }
            }
        }
    }
}