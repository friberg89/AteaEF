using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using NewAtea.Models;
using NewAtea.Repository;

namespace NewAtea.ApiControllers
{
    public class CMContext : DbContext
    {
        public DbSet<ConsoleMessage> ConsoleMessages { get; set; }
    }

    public class ConsoleMessageController : ApiController
    {
        private static readonly CMContext _ctx = new CMContext();
        
        private Repository<ConsoleMessage> consoleMessages = new Repository<ConsoleMessage>(_ctx);

        public List<ConsoleMessage> GetAllMessages()
        {
            return consoleMessages.GetAll().OrderByDescending(x=>x.Date).ToList();
        }

        public void Postmessage(ConsoleMessage consoleMessage)
        {
            consoleMessages.Insert(consoleMessage);
            _ctx.SaveChanges();
        }

    }
}
