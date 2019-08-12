using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webchat.DAO;
using webchat.Service;
using webchat.DTO.Requests;
using webchat.DTO.Responses;
using webchat.Models;

///////////////////////////////////////////////////////////////////////////////////////
// References:
// https://medium.com/@vworri/building-a-net-core-2-api-with-linux-c53d80f1460b
// https://www.c-sharpcorner.com/article/routing-in-restful-apis-using-net-core/
// https://medium.freecodecamp.org/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28
// https://medium.com/@pielegacy/an-in-depth-guide-into-a-ridiculously-simple-api-using-net-core-8f5edd427b0
// https://www.codementor.io/pmbanugo/working-with-mongodb-in-net-1-basics-g4frivcvz
// https://www.codementor.io/pmbanugo/working-with-mongodb-in-net-2-retrieving-mrlbeanm5
// https://www.codementor.io/pmbanugo/working-with-mongodb-in-net-part-3-skip-sort-limit-and-projections-oqfwncyka
// https://www.csharpcodi.com/csharp-examples/MongoDB.Driver.IMongoCollection.DeleteMany(MongoDB.Driver.FilterDefinition,%20MongoDB.Driver.DeleteOptions,%20System.Threading.CancellationToken)/
// https://www.dotnetcurry.com/aspnet-mvc/1267/using-mongodb-nosql-database-with-aspnet-webapi-core
///////////////////////////////////////////////////////////////////////////////////////

namespace webchat.Controllers
{
    // [Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class WebChatController : ControllerBase
    {
        private readonly IWebChatService service;

        public WebChatController(IWebChatService service)
        {
            this.service = service;
        }

        // POST webchat/create
        [HttpPost("create")]
        public ActionResult<CreateResponseMessage> Post([FromBody] CreateRequestMessage req)
        {
            return service.createMessage(req);
        }

        // DELETE webchat/delete
        // [HttpPost("delete")]
        [HttpDelete("delete")]
        public ActionResult<DeleteResponseMessage> Delete([FromBody] DeleteRequestMessage req)
        {
            return service.deleteMessages(req);
        }

        // POST webchat/delete
        //[HttpDelete("delete")]
        [HttpPost("delete")]
        public ActionResult<DeleteResponseMessage> Post([FromBody] DeleteRequestMessage req)
        {
            return service.deleteMessages(req);
        }

        [HttpPost("update/{id}")]
        public ActionResult<UpdateResponseMessage> Post(String id, [FromBody] UpdateRequestMessage req)
        {
            return service.updateMessage(id, req);
        }

        [HttpPut("update/{id}")]
        public ActionResult<UpdateResponseMessage> Put(String id, [FromBody] UpdateRequestMessage req)
        {
            return service.updateMessage(id, req);
        }

        // GET webchat/read/all/Dana
        [HttpGet("read/all/{user}")]
        public ActionResult<ReadResponseMessage> GetAll(string user)
        {
            return service.fetchUserMessages(user);
        }

        // GET webchat/read/from/Dana
        [HttpGet("read/from/{user}")]
        public ActionResult<ReadResponseMessage> GetFrom(string user)
        {
            return service.fetchMessagesFromUser(user);
        }

        // GET webchat/read/from/Dana/to/Joel
        [HttpGet("read/from/{fromUser}/to/{toUser}")]
        public ActionResult<ReadResponseMessage> Get(string fromUser, string toUser)
        {
            return service.fetchMessagesFromUserToUser(fromUser, toUser);
        }

        // GET webchat/read
        [HttpGet("read")]
        public ActionResult<ReadResponseMessage> Get()
        {
            return service.fetchAllMessages();
        }
    }
}
