using System;
using webchat.Models;
using MongoDB.Bson;

namespace webchat.DTO.Requests
{
    public class UpdateRequestMessage : IRequestMessage
    {
        public UpdateRequestMessage() { }
        public UpdateRequestMessage(string from, string to, string date, string message)
        {
            this.from = from;
            this.to = to;
            this.date = date;
            this.message = message;
        }
        public string from { get; set; }
        public string to { get; set; }
        public string date { get; set; }
        public string message { get; set; }
    }
}