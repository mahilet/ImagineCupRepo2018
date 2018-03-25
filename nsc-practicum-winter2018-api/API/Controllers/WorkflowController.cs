using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Web.Http;
using API.Models;
using System.Net.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class WorkflowController : ApiController
    {
        

        public WorkflowController() {
            
        }

        /// <summary>
        /// Deletes an existing workflow
        /// </summary>

        /// <param name="id">id of workflow to delete</param>
        /// <response code="200">Success! Workflow has been deleted.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authorization information is missing or invalid.</response>
        /// <response code="403">Operation not authorized.</response>
        /// <response code="500">Internal server error.</response>
        /// <response code="501">Service not yet implemented.</response>
        [HttpDelete]
        [Route("workflow/{id}")]
        //[SwaggerOperation("WorkflowIdDelete")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        public virtual void WorkflowIdDelete(string id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// retrieves a workflow by id
        /// </summary>

        /// <param name="id">id of workflow to get</param>
        /// <response code="200">Success! Workflow has been found.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authorization information is missing or invalid.</response>
        /// <response code="403">Operation not authorized.</response>
        /// <response code="500">Internal server error.</response>
        /// <response code="501">Service not yet implemented.workflow</response>
        [HttpGet]
        [Route("workflow/{id}")]
        
        //[SwaggerOperation("WorkflowIdGet")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        public HttpResponseMessage WorkflowIdGet(string id) {
            
            // hardcode default name of workflow to return
            // TODO:  update this to dynamically return workflow from name passed in as parameter.
            id = "CloudOffshoreExternal.js";
            string text = GetWorkflow(id);
            // Return as json response
            var resp = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(text, System.Text.Encoding.UTF8, "application/json") };
            return resp;

        }

        /// <summary>
        /// Updates an existing workflow
        /// </summary>

        /// <param name="id">id of workflow to amend</param>
        /// <param name="workflow">workflow object</param>
        /// <response code="201">Success! Workflow has been updated.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authorization information is missing or invalid.</response>
        /// <response code="403">Operation not authorized.</response>
        /// <response code="500">Internal server error.</response>
        /// <response code="501">Service not yet implemented.</response>
        [HttpPut]
        [Route("workflow/{id}")]
        //[SwaggerOperation("WorkflowIdPut")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        public virtual void Update(string id, [FromBody]Workflow workflow) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new workflow
        /// </summary>

        /// <param name="workflow">Adds a single workflow</param>
        /// <response code="201">Success! Workflow has been created.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authorization information is missing or invalid.</response>
        /// <response code="403">Operation not authorized.</response>
        /// <response code="500">Internal server error.</response>
        /// <response code="501">Service not yet implemented.</response>
        [HttpPost]
        [Route("workflow")]
        //[SwaggerOperation("WorkflowPost")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        public virtual void Post([FromBody]Workflow workflow) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// retrieves list of all workflow names
        /// </summary>

        /// <response code="200">Success! Workflows have been found.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authorization information is missing or invalid.</response>
        /// <response code="403">Operation not authorized.</response>
        /// <response code="500">Internal server error.</response>
        /// <response code="501">Service not yet implemented.workflow</response>
        [HttpGet]
        [Route("workflow")]

        //[SwaggerOperation("WorkflowGet")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        public HttpResponseMessage WorkflowGet()
        {
            var listOfFileNames = GetWorkflowNames();
            // Convert list to json and return as response
            var resp = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(listOfFileNames), System.Text.Encoding.UTF8, "application/json") };
            return resp;
        }

        /// <summary>
        /// Retrieves a reference to the container within Azure storage account which contains the workflows.
        /// </summary>
        public static CloudBlobContainer GetWorkflowContainer()
        {
            //Retrieves a connection string from configuration file and returns a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the service client to retrieve containers and blobs stored in Blob storage.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container from configuration file.
            return blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("WorkflowStorageContainerName"));
        }

        /// <summary>
        /// Retrieves a list of workflows from the workflow Azure storage container.
        /// </summary>
        public static List<string> GetWorkflowNames()
        {
            var container = GetWorkflowContainer();
            var blobs = container.ListBlobs(useFlatBlobListing: true);
            var listOfFileNames = new List<string>();

            foreach (var blob in blobs)
            {
                var blobFileName = blob.Uri.Segments.Last();
                listOfFileNames.Add(blobFileName);
            }
            return listOfFileNames;
        }

        /// <summary>
        /// Download workflow from Azure storage using DownloadToStream method.
        /// </summary>
        public static string GetWorkflow(string id)
        {
            // Retrieve a reference to a container.
            var container = GetWorkflowContainer();
            // Retrieve reference to a blob with name "id"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(id);

            // Download blob using DownloadToStream method.
            string text;
            using (var memoryStream = new MemoryStream())
            {
                blockBlob.DownloadToStream(memoryStream);
                text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return text;
        }

    }
}
