using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API.Results {

    /// <summary>
    /// A content created response object 
    /// </summary>
    public class CreatedResourceActionResult: IHttpActionResult {

        private HttpRequestMessage request;
        private string location;
        private string responsePhrase;

        /// <summary>
        /// Default Created Content Response Contstructor
        /// </summary>
        /// <param name="request">The received request</param>
        /// <param name="location">Where the request originated within the API</param>
        public CreatedResourceActionResult(HttpRequestMessage request, string location) {
            this.request = request;
            this.location = location;
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <remarks>Allows a response to be created using a custom message.</remarks>
        /// <param name="request">The received request</param>
        /// <param name="location">Where the request originated within the API</param>
        /// <param name="responsePhrase">A custom response code reason phrase.</param>
        public CreatedResourceActionResult(HttpRequestMessage request, string location, string responsePhrase) : this(request, location) {
            this.responsePhrase = responsePhrase;
        }



        /// <summary>
        /// Asynch Response Message for Creating Resources
        /// </summary>
        /// <remarks>If object is created using 3 param constructor, the string passed as reasonPhrase will be used as the response phrase</remarks>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            var response = request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(location);
            if(responsePhrase != null) {
                response.ReasonPhrase = responsePhrase;
            } else {
                response.ReasonPhrase = "Success! Resource has been created.";
            }
            return Task.FromResult(response);
        }
    }
}