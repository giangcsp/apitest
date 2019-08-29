using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.property;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Repos.repo
{
    public class ARepo : AInterface
    {
        private Pcontext context;
        private JsonSerializerSettings jsonsettings;
        public ARepo(Pcontext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
            this.jsonsettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            };
        }
        public JsonResult getAll()
        {
            var addresses = this.context.Address
                .Include(a => a.People)
                .ToList();
            return new JsonResult(addresses);
        }

        public JsonResult getID(int id)
        {
            var addresses = this.context.Address
                .Include(a => a.People);
            Address address = context.Address.Find(id);
            context.Entry(address).Collection(c => c.People).Load();
            return new JsonResult(address);
        }

        public string Put(int id, string addr)
        {
            this.context.Add(new Address
            {
                ID = id,
                ADDR = addr

            });
            this.context.SaveChanges();
            return "done";
        }

        public string Post(int id, string addr)
        {
            
            this.context.Add(new Address
            {
                ID = id,
                ADDR = addr
            });
            this.context.SaveChanges();
            return "done";
        }
        public void Delete(int id)
        {
            
            var addresses = this.context.Address;
            var chosenA = new Address
            {
                ID = id
            };
            addresses.Remove(chosenA);
            this.context.SaveChanges();
        }
    }
}
