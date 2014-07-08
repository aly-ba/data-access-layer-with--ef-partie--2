using System.Data.Services;
using System.Data.Services.Common;
using SalesModel.DataLayer;

namespace WcfDataService
{
    public class WcfDataService : DataService< SalesModelContext >
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
           //DEMOWARE ...not following security guidance :) 
             config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
             config.SetEntitySetAccessRule("Customers",EntitySetRights.All);
             //config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
             config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }
}
