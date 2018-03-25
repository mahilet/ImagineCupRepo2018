using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using API.Models;

namespace API.Results {
    public class FoundResourceActionResult: IHttpActionResult {

        private readonly HttpRequestMessage request;
        private readonly User user;

        public FoundResourceActionResult(HttpRequestMessage request, User user) {
            this.request = request;
            this.user = user;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}