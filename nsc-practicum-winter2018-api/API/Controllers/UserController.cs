using System.Collections.Generic;
//using API.Models;
using System.Threading.Tasks;
using Microsoft.Net.Http;
using System.Web.Http;
using API.Dal;
using API.Models;

namespace API.Controllers
{
    /// <summary>
    /// Defines API Endpoints for User Resources
    /// </summary> 
    [Route("api/[controller]")]
    public class UserController : ApiController
    {      
       //Summary
       //injecting UserDal
       //Summary
        private readonly UserDal _userDal;

        ///<Summary>
        /// constructor to create instance of an injected userdal class
        ///</Summary>
        public UserController()
        {
            _userDal = new UserDal(); 
        }

        ///<Summary>
        /// get operation to get all users
        ///</Summary>
        // GET api/users 
        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userDal.GetAllUsers();
        }

        
        ///<Summary>
        /// get operation to get a single
        ///</Summary>
        // GET api/users/5
        [System.Web.Http.HttpGet]
        public async Task<User> Get(string id)
        {
            return await _userDal.GetUser(id) ?? new User();
        }

        


        ///<Summary>
        /// post operation to post a user
        ///</Summary>
        // POST api/users
        [System.Web.Http.HttpPost]
        public async void Post([System.Web.Http.FromBody]User user)
        {
            await _userDal.AddUser(user);
        }

        ///<Summary>
        /// put operation to update a user
        ///</Summary>
        // PUT api/users/5
        [System.Web.Http.HttpPut]
        public async void Put(string id, [System.Web.Http.FromBody]User user)
        {
           await _userDal.UpdateUser(id, user);
        }

        ///<Summary>
        /// delete operation to delete a user
        ///</Summary>
        // DELETE api/users/5
        [System.Web.Http.HttpDelete]
        public async  void Delete(string id)
        {
            await _userDal.RemoveUser(id);
        }


        ////public UserController(User user)
        ////{
        ////    _user = user;
        ////}

        //////public UserController() {
        //////    this.userRepository = new UserRepository();
        //////}

        ///// <summary>
        ///// Creates a new user
        ///// </summary>

        ///// <param name="user">The user to create.</param>
        ///// <response code="201">Success! User record has been created.</response>
        ///// <response code="400">Bad request.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpPost]
        ////[Route("user/")]
        ////[SwaggerOperation("UserPost")]
        ////public virtual CreatedResourceActionResult Post([FromBody]User user)
        ////{
        ////    var id = new Guid();
        ////    return new CreatedResourceActionResult(
        ////        Request,
        ////        Url.Link("DefaultApi", new { controller = "User", id = id })
        ////        );
        ////}

        ////[HttpPost]
        //public Task<User> Post([FromBody]User user)
        //{
        //    return _userDal.Create(user);
        //}


        ///// <summary>
        ///// Retrieves a user by id
        ///// </summary>
        ///// <remarks>A User object</remarks>
        ///// <param name="id">id of the user to retrieve</param>
        ///// <response code="200">A User object.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpGet]
        //[Route("user/{id}")]
        //[SwaggerOperation("UserIdGet")]
        //[SwaggerResponse(HttpStatusCode.OK, Type=typeof(User))]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        ////public virtual FoundResourceActionResult Get(string id) {
        ////    return new FoundResourceActionResult(Request, new User("Rick", "Sanchez", _user.TypeEnum.ManagerEnum));
        ////}

        ///// <summary>
        ///// Returns all employees assigned to this manager
        ///// </summary>

        ///// <param name="id">id of the user to retrieve</param>
        ///// <response code="200">Success! User has been found.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpGet]
        //[Route("user/{id}/employees")]
        //[SwaggerOperation("UserIdEmployeesGet")]
        //[SwaggerResponse(HttpStatusCode.OK, Type = typeof(User))]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        //public virtual FoundResourceActionResult GetEmployees(string id) {
        //    string exampleJson = null;

        //    //var example = exampleJson != null
        //    //? JsonConvert.DeserializeObject<List<string>>(exampleJson)
        //    //: default(List<string>);
        //    //return new FoundResourceActionResult(Request, new User("Rick", "Sanchez", Models.User.TypeEnum.ManagerEnum));

        //    //var example = exampleJson != null
        //    //? JsonConvert.DeserializeObject<List<string>>(exampleJson)
        //    //: default(List<string>);
        //    //return new FoundResourceActionResult(Request, new User("Rick", "Sanchez", User.TypeEnum.ManagerEnum));
        //}

        ///// <summary>
        ///// Deletes an existing user
        ///// </summary>
        ///// <remarks>Deletes an existing user as denoted by the path-specified id</remarks>
        ///// <param name="id">id of user to delete</param>
        //[SwaggerResponse(HttpStatusCode.OK)]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        //[HttpDelete]
        //[Route("user/{id}")]
        //[SwaggerOperation("UserIdDelete")]
        //public virtual void Delete(string id) {
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Unnassigns an employee from a manager
        ///// </summary>

        ///// <param name="id">id of user</param>
        ///// <param name="task">id of the user</param>
        ///// <response code="200">Success! User record has been removed.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented</response>
        //[HttpDelete]
        //[Route("user/{id}/employees")]
        //[SwaggerOperation("UserIdEmployeesDelete")]
        //public virtual void UnassignEmployee(string id, [FromBody]string task) {
        //    throw new NotImplementedException();
        //}



        ///// <summary>
        ///// Assigns an employee to a manager
        ///// </summary>

        ///// <param name="id">id of the manager</param>
        ///// <param name="task">id of the employee</param>
        ///// <response code="201">Success! Employee has been assigned a new manager.</response>
        ///// <response code="400">Bad request.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpPost]
        //[Route("user/{id}/employees")]
        //[SwaggerOperation("UserIdEmployeesPost")]
        //public virtual void AssignEmployee(string id, [FromBody]string task) {
        //    throw new NotImplementedException();
        //}


        ///// <summary>
        ///// Updates an existing user
        ///// </summary>
        ///// <remarks>Updates the user record associated with the path-specified id</remarks>
        ///// <param name="id">id of the user object to update</param>
        ///// <param name="user"></param>
        ///// <response code="201">Success! User record has been updated.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented</response>
        //[HttpPut]
        //[Route("user/{id}")]
        //[SwaggerOperation("UserIdPut")]
        //public virtual void Update(string id, [FromBody]User user) {
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Deletes a completed task
        ///// </summary>

        ///// <param name="id">id of user</param>
        ///// <param name="task">id of the task</param>
        ///// <response code="200">Success! User record has been removed.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented</response>
        //[HttpDelete]
        //[Route("user/{id}/tasks")]
        //[SwaggerOperation("UserIdTasksDelete")]
        //public virtual void DeleteTask(string id, [FromBody]string task) {
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Returns all completed tasks
        ///// </summary>

        ///// <param name="id">id of the user to retrieve</param>
        ///// <response code="200">Success! User has been found.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpGet]
        //[Route("user/{id}/tasks")]
        //[SwaggerOperation("UserIdTasksGet")]
        //[SwaggerResponse(HttpStatusCode.OK, Type = typeof(User))]
        //[SwaggerResponse(HttpStatusCode.BadRequest)]
        //[SwaggerResponse(HttpStatusCode.Unauthorized)]
        //[SwaggerResponse(HttpStatusCode.Forbidden)]
        //[SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[SwaggerResponse(HttpStatusCode.NotImplemented)]
        //public virtual FoundResourceActionResult GetTasks(string id) {
        //    throw new NotImplementedException();
        //    //string exampleJson = null;
        //    //var example = exampleJson != null
        //    //? JsonConvert.DeserializeObject<List<string>>(exampleJson)
        //    //: default(List<string>);
        //    //return new ObjectResult(example);
        //}

        ///// <summary>
        ///// Adds a completed task
        ///// </summary>

        ///// <param name="id">id of the user</param>
        ///// <param name="task">id of the completed task</param>
        ///// <response code="201">Success! User task record has been created.</response>
        ///// <response code="400">Bad request.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpPost]
        //[Route("user/{id}/tasks")]
        //[SwaggerOperation("UserIdTasksPost")]
        //public virtual void AddTask(string id, [FromBody]string task) {
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Unassigns a user workflow
        ///// </summary>

        ///// <param name="id">The uid</param>
        ///// <response code="200">Success! User has been unassigned workflow.</response>
        ///// <response code="400">Bad request. User not found.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented</response>
        //[HttpDelete]
        //[Route("user/{id}/workflow")]
        //[SwaggerOperation("UserIdWorkflowDelete")]
        //public virtual void DeleteWorkflow(string id) {
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Assigns a user to a workflow
        ///// </summary>

        ///// <param name="id">The uid</param>
        ///// <param name="workflow">The workflow id</param>
        ///// <response code="201">Success! User has been assigned to workflow.</response>
        ///// <response code="400">Bad request.</response>
        ///// <response code="401">Authorization information is missing or invalid.</response>
        ///// <response code="403">Operation not authorized.</response>
        ///// <response code="500">Internal server error.</response>
        ///// <response code="501">Service not yet implemented.</response>
        //[HttpPost]
        //[Route("user/{id}/workflow")]
        //[SwaggerOperation("UserIdWorkflowPost")]
        //public virtual void AddWorkflow(string id, [FromBody]string workflow) {
        //    throw new NotImplementedException();
        //}
    }
}
