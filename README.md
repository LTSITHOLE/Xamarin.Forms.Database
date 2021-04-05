# Xamarin.Forms.Database
GET started with Firebase Database,Authentication and Storage intergration  in xamarin forms.Intergrate firebase into your application using our ready-made Library.

Getting Started

Step 1

Get Authentication/web key,storage url and Database url from firebase console.

Step 2

initiallize Keys and URL's ,you can only configure service you want to use.

Xamarin.Forms.Database.Global.ServerConfiguration.FirebasebaseDatabaseURL="Your Firebase Database URL";
Xamarin.Forms.Database.Global.ServerConfiguration.FirebasebaseStorageURL="Your Firebase Database URL";
Xamarin.Forms.Database.Global.ServerConfiguration.FirebasebaseAuthKey="Web Key from project settings in firebase console";


Step 3

Consume The services.Make sure you include namespaces

Database

variable =new Database<object>("TableName");

E.G
var db=new Database<Product>("Products");

Storage

variable =new Storage("TableName");

E.G
var db=new Storage("Products");


MIT License.
Copyrights@ 2021 Herbs Technology
