using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ebay.api.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/ebay")]
    public class EbayProductController : ApiController
    {
        // GET api/values
        [Route("findItems")]
        [HttpGet]
        public HttpResponseMessage FindItems(string keywords)
        {
            // FindItemsAdvancedRequest request = new FindItemsAdvancedRequest();
            //// request.keywords = keyword.Text;
            // if (request.keywords == null)            
            //     request.keywords = keywords;

            // // Call the service
            // FindingServicePortTypeClient client;
            // string appID = System.Configuration.ConfigurationManager.AppSettings["AppID"];
            // string findingServerAddress = System.Configuration.ConfigurationManager.AppSettings["FindingServerAddress"];

            // APIManager.Core.Configuration.ClientConfig config = new APIManager.Core.Configuration.ClientConfig();
            // // Initialize service end-point configration
            // config.EndPointAddress = findingServerAddress;

            // // set eBay developer account AppID
            // config.ApplicationId = appID;

            // // Create a service client
            // client = FindingServiceClientFactory.getServiceClient(config);
            // FindItemsAdvancedResponse response = client.findItemsAdvanced(request);
            // return response;
            string response;
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");//
                response = client.DownloadString("https://svcs.ebay.com/services/search/FindingService/v1?SECURITY-APPNAME=TomasRoy-EbayAppl-PRD-b7a9d82e9-f7d94c41&OPERATION-NAME=findItemsByKeywords&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&keywords=iPhone");
            }
            return Request.CreateErrorResponse(HttpStatusCode.OK, response);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
