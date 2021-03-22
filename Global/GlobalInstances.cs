using Firebase.Database;
using Firebase.Storage;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Database.Global
{
    /// <summary>
    /// Class for Global Instances
    /// </summary>
    public static class GlobalInstance
    {
        /// <summary>
        ///  Database Client
        /// </summary>
        public static FirebaseClient DatabaseClient { get; set; } = new FirebaseClient(ServerConfiguration.FirebaseDatabaseURL);

        /// <summary>
        /// Storage Client
        /// </summary>
        public static FirebaseStorage StorageClient { get; set; } = new FirebaseStorage(ServerConfiguration.FirebaseStorageURL);

        /// <summary>
        /// Authentication Provider
        /// </summary>
        public static FirebaseAuthProvider AuthProvider { get; set; } = new FirebaseAuthProvider(new FirebaseConfig(ServerConfiguration.FirebaseAuthKey));
    }
}
