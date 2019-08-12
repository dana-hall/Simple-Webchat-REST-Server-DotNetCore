using System;
using System.Collections.Generic;
using webchat.DTO.Requests;
using webchat.DTO.Responses;
using webchat.DTO.Helpers;
using webchat.Models;
using MongoDB.Bson;

namespace webchat.DTO.Responses
{
    public class UpdateResponseMessage : IResponseMessage
    {
        public UpdateResponseMessage()
        {
        }
        public UpdateResponseMessage(Enum status, ObjectId id, UpdateRequestMessage req, Object mongoResult)
        {
            this.id = id;
            this.request = req;
            if (mongoResult == null)
            {
                this.result = new Result(Status.OPERATION.UPDATE, Status.STATUS.NOT_FOUND, 0, mongoResult);
            }
            else
            {
                this.result = new Result(Status.OPERATION.UPDATE, status, 1, mongoResult);
            }
        }
        public ObjectId id { get; set; }
        public UpdateRequestMessage request { get; set; }
        public Result result { get; set; }
    }
}