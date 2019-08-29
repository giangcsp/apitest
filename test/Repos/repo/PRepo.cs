using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using WebApplication1.property;
namespace WebApplication1.Repos.repo
{
    public class PRepo : PInterface
    {
        private Pcontext context;
        private JsonSerializerSettings jsonsettings;
        public PRepo(Pcontext context)
        {
            this.context = context;
            jsonsettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            };
        }
        public JsonResult getAllP()
        {
            var addresses = this.context.Address
                .Include(a => a.People)
                .ToList();
            
            return new JsonResult(addresses, jsonsettings);
        }

        public JsonResult getIDP(int id)
        {
            var addresses = this.context.Address.Include(a => a.People).ToList();
            foreach (Address address in addresses)
            {
                context.Address.Include(c => c.People).ToList();
                var p = address.getP(this.context, id);
                if (p != null)
                {
                    return new JsonResult(p, jsonsettings);
                }
            }
            return null;
        }

        public void PostP(int id, string pname, int addid)
        {
                var addresses = this.context.Address
                    .Include(a => a.People)
                    .ToList();
                foreach (var address in addresses)
                {
                    if (address.ID == addid)
                    {
                        address.addPerson(new Person
                        {
                            ID = id,
                            PNAME = pname,
                            add = address,
                            addid = address.ID
                        }, this.context);
                    }
                }
                this.context.SaveChanges();

        }

        public void PutP(int id, string pname, int addid) => PostP(id, pname, addid);

        public void DeleteP(int id)
        {
            var addresses = this.context.Address;
            foreach (var address in addresses)
            {
                address.removePerson(id, this.context);
            }
            this.context.SaveChanges();
        }
    }
}
