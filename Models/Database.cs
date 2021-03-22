using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Database.Global;

namespace Xamarin.Forms.Database.Models
{
    public class Database<T>
    {
        /// <summary>
        /// Hold Table Names
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Hold collection of Type T
        /// </summary>
        public List<T> Collection { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tableName">passed table name</param>
        public Database(string tableName = null)
        {
            //initialize attributes
            TableName = tableName;
            Collection = new List<T>();

            //Execute Initialization
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private async void Init()
        {
            try
            {
                //get collection from database
                var list = await GlobalInstance.DatabaseClient.Child(TableName).OnceAsync<T>();

                //fill collection
                foreach (var item in list)
                {
                    Collection.Add(item.Object);
                }
            }
            catch (Exception)
            {

                Collection = new List<T>();
            }
        }

        /// <summary>
        /// checks the objects in the database
        /// </summary>
        /// <param name="obj">object to be checked</param>
        /// <returns></returns>
        public async Task<string> ObjectExist(T obj)
        {
            try
            {
                //get collection from database
                var list = await GlobalInstance.DatabaseClient.Child(TableName).OnceAsync<T>();

                //search for the object
                var res = list.Where(u => u.Object.Equals(obj)).FirstOrDefault();

                //return result
                if (res.Object == null)
                    return await Task.FromResult(res.Key);
                else
                    return await Task.FromResult(res.Key);
            }
            catch (Exception)
            {
                //return false
                return await Task.FromResult(string.Empty);
            }
        }

        /// <summary>
        /// create object on the databse
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<bool> CreateOrUpdateObject(T obj)
        {
            //check object
            var key = await ObjectExist(obj);

            try
            {
                //create or update instance
                if (string.IsNullOrEmpty(key))
                {
                    //create instance
                    await GlobalInstance.DatabaseClient.Child(TableName).PostAsync(obj);
                }
                else
                {
                    //update instance
                    await GlobalInstance.DatabaseClient.Child(TableName).Child(key).PutAsync(obj);
                }

                //return result
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                //return false
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// delete objects on database
        /// </summary>
        /// <param name="obj">object to be deleted</param>
        /// <returns></returns>
        public async Task<bool> DeleteObject(T obj)
        {
            //check object
            var key = await ObjectExist(obj);

            try
            {
                //Delete instance
                await GlobalInstance.DatabaseClient.Child(TableName).Child(key).DeleteAsync();

                //return result
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                //return false
                return await Task.FromResult(false);
            }
        }

    }
}
