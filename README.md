# Xamarin.Forms.Database
GET started with Firebase Database,Authentication and Storage intergration  in xamarin forms.Intergrate firebase into your application using our ready-to-use Library.

# Getting Started
Make sure you include namespace. 

using Xamarin.Forms.Database.Global;

## Step 1
Get Authentication/web key, storage url and Database url from firebase console.

## Step 2
Initialize Keys and URL’s, you can only configure service you want to use.

Global.ServerConfiguration.FirebasebaseDatabaseURL="Your Firebase Database URL";

Global.ServerConfiguration.FirebasebaseStorageURL="Your Firebase Database URL";

Global.ServerConfiguration.FirebasebaseAuthKey="Web Key from project settings in firebase console";


## Step 3
Consume The services.	

### Database

variable =new Database<object>("TableName");

E.G
var db=new Database<Product>("Products");

### Storage

variable =new Storage("TableName");

E.G
var db=new Storage("Products");

### Authentication
Make sure you enable authentication method you want to use from firebase console.
Use Auth provider below 
  
Global.GlobalInstance.AuthProvider

  
# License 

MIT License.
  
Copyrights@ 2021 LT SITHOLE

