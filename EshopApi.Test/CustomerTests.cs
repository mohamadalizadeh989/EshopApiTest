using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore.Storage;

namespace EshopApi.Test
{
    [TestClass]
    public class CustomerTests
    {
        private HttpClient _client;

        public CustomerTests()
        {
            var server=new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void CustomerGetAllTest()
        {

            var request=new HttpRequestMessage(new HttpMethod("Get"),"/Api/Customers");
            var response = _client.SendAsync(request).Result;
            
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        }

    }
}
