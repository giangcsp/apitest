using NUnit.Framework;
using WebApplication1.property;
using WebApplication1.Repos.repo;
using System.Net.Http;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Tests
{
    public class Tests
    {
        private static readonly HttpClient client = new HttpClient();
        private Pcontext context;
        private ARepo repo;
        private JsonSerializerSettings jsonsettings;
        [SetUp]
        public void Setup()
        {
            context = new Pcontext();
            repo = new ARepo(context);
            jsonsettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            };
        }

        [Test]
        public void Test1()
        {
            try
            {
                repo.Post(69, "Nha Tho So 17");
                repo.Post(17, "Nha Tho So 69");


            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }


            
        }


        [Test]
        public void Test2()
        {
            repo.getID(69);
            if (repo.getID(17).Value.GetType().ToString() != "WebApplication1.property.Address")
            {
                Assert.Fail(repo.getID(17).Value.GetType().ToString());
            }
        }

        [Test]
        public void Test3()
        {
            repo.Delete(69);
            repo.Delete(17);
            List<Address> list = new List<Address> { };
            var result = repo.getAll();
            Console.WriteLine(result);
        }

        [Test]
        public void Test4()
        {

        }
    }
}
