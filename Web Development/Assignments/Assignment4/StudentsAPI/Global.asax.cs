using StudentsAPI.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace StudentsAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataLayer dataLayer = new DataLayer();
            if (dataLayer.TestConnection())
            {
                // SQL Server connection is successful
                System.Diagnostics.Debug.WriteLine("Succesful while testing the connection string connection");
                GlobalConfiguration.Configure(WebApiConfig.Register);
            }
            else
            {
                // SQL Server connection failed
                System.Diagnostics.Debug.WriteLine("Error while testing the connection string connection");
            }
        }

    }
}
