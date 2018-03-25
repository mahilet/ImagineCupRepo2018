using API.Models;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SwaggerExamples {
    /// <summary>
    /// Generates Sample Request for Swagger UI Testing
    /// </summary>
    public class TaskControllerPostExample: IExamplesProvider {

        /// <summary>
        /// Returns the example request
        /// </summary>
        /// <returns>A HTTP request example for testing API endpoints using Swagger UI</returns>
        public object GetExamples() {
            return new TaskConfig {
                Name = "Task 1",
                Description = "Task 1 Description",
            };
        }
    }
}