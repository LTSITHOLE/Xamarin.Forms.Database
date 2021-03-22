using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Database.Global
{
    /// <summary>
    /// Class to Define Configuration attributes
    /// </summary>
    public static class ServerConfiguration
    {
        /// <summary>
        /// Database URL from Firebase Console
        /// </summary>
        public static string FirebaseDatabaseURL { get; set; }

        /// <summary>
        /// Storage URL from Firebase Console
        /// </summary>
        public static string FirebaseStorageURL { get; set; }

        /// <summary>
        /// Web Key from Firebase Console
        /// </summary>
        public static string FirebaseAuthKey { get; set; }
    }
}
