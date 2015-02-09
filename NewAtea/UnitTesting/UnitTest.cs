using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewAtea.Models;
using NewAtea.Repository;


namespace UnitTesting
{
    [TestClass]
    public class UnitTest
    {

        private IRepository<ConsoleMessage> Repository;

        [TestMethod]
        public void GetMessages()
        {
            var list = new List<ConsoleMessage>();
            list = Repository.GetAll().ToList();
            foreach (var msg in list)
            {
                Trace.TraceInformation(msg.ConsoleMsg);
            }
   
        }

        //[TestMethod]
        //public void Insert(ConsoleMessage msg)
        //{
        //    msg = new ConsoleMessage             }
        //        {
        //            ConsoleMsg = "Hej",
        //            Date = DateTime.Now
        //        };
                
        //    if (repository.Insert(msg) > 0){}
            
        //}

    }
}
