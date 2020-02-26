# Connect a .net application to Postgress from Cloud Run 


## Prerequisites

0.  **Follow the set-up instructions in [the documentation](https://cloud.google.com/dotnet/docs/setup).**
  
1.  Enable APIs for your project.
    [Click here](https://console.cloud.google.com/flows/enableapi?apiid=sqladmin.googleapis.com&showconfirmation=true)
    to visit Cloud Platform Console and enable the Google Cloud SQL API.

2.  Install the [Google Cloud SDK](https://cloud.google.com/sdk/).  The Google Cloud SDK
    is required to deploy .NET applications to App Engine.

3.  Install the [.NET Core SDK, version 2.0](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.5-download.md)
    or newer.

4.  [Create a second generation Google Cloud SQL instance](
    https://cloud.google.com/sql/docs/postgres/create-instance).

6.  Under the instance's "USERS" tab, create a new user. Note the "User name" and "Password".

7.  Create a new database in your Google Cloud SQL instance.
    
    1.  List your database instances in [Cloud Cloud Console](
        https://console.cloud.google.com/sql/instances/).
    
    2.  Click your Instance Id to see Instance details.

    3.  Click DATABASES.

    4.  Click **Create database**.

    2.  For **Database name**, enter `votes`.

    3.  Click **CREATE**.

8.  Clone the repo


9.  Cloud Run (fully managed) uses a service account to authorize your connections to Cloud SQL. This service account must have the correct IAM permissions to successfully connect. Unless otherwise configured, the default service account is in the format PROJECT_NUMBER-compute@developer.gserviceaccount.com. Assign to this service account the --role roles/cloudsql.client


10. Containerizing the app and uploading it to Container Registry

        gcloud builds submit --tag gcr.io/[PROJECT_ID]/quickstart-image
        
11. Deploy the service to Cloud Run        
     
       gcloud run deploy run-mysql --image gcr.io/[PROJECT_ID]/quickstart-image
        
12. Configure the service for use of Cloud Run and Cloud SQL proxi
 
           gcloud run services update run-mysql --add-cloudsql-instances INSTANCE CONNECTION NAME
       
           
    
