using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Database.Global;

namespace Xamarin.Forms.Database.Models
{
    /// <summary>
    /// class to manage storage
    /// </summary>

    public class Storage
    {
        /// <summary>
        /// Hold Table Names
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tableName">passed table name</param>
        public Storage(string tableName = null)
        {
            //initialize attributes
            TableName = tableName;
        }

        /// <summary>
        /// Upload the file to  storage
        /// </summary>
        /// <param name="fileStream">actual stream</param>
        /// <param name="fileName">file name</param>
        /// <returns></returns>

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            try
            {
                //upload file
                var FileUrl = await GlobalInstance.StorageClient
                               .Child(TableName)
                               .Child(fileName)
                               .PutAsync(fileStream);

                //return file url
                return await Task.FromResult(FileUrl);
            }
            catch (Exception)
            {
                //return empty string
                return await Task.FromResult(string.Empty);
            }
        }

        /// <summary>
        /// Get File from storage
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns></returns>

        public async Task<string> GetFile(string fileName)
        {

            try
            {
                //upload file
                var FileUrl = await GlobalInstance.StorageClient
                               .Child(TableName)
                               .Child(fileName)
                               .GetDownloadUrlAsync();

                //return file url
                return await Task.FromResult(FileUrl);
            }
            catch (Exception)
            {
                //return empty string
                return await Task.FromResult(string.Empty);
            }

        }

        /// <summary>
        /// Delete file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public async Task<bool> DeleteFile(string fileName)
        {

            try
            {
                //upload file
                await GlobalInstance.StorageClient
                               .Child(TableName)
                               .Child(fileName)
                               .DeleteAsync();

                //return file url
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                //return empty string
                return await Task.FromResult(false);
            }


        }

    }
}
