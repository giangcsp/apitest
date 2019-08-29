using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication1.property
{
    public class Address
    {
        public string ADDR
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }
        public List<Person> People
        {
            get;
            set;
        }
        public JsonResult getInfo(Pcontext context)
        {
            context.Entry(this).Collection(c => c.People).Load();
            return new JsonResult(this, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            });
        }
        public void addPerson(Person person, Pcontext context)
        {
            context.Entry(this).Collection(c => c.People).Load();
            People.Add(person);
            context.SaveChanges();
        }
        public void removePerson(int id, Pcontext context)
        {
            context.Entry(this).Collection(c => c.People).Load();
            Person chosenPerson = new Person
            {
                ID = id
            };
            People.Remove(chosenPerson);
            context.SaveChanges();
        }

        public JsonResult getP(Pcontext context)
        {
            context.Entry(this).Collection(c => c.People).Load();
            return new JsonResult(People);
        }

        public Person getP(Pcontext context, int id)
        {
            context.Entry(this).Collection(c => c.People).Load();
            foreach (Person person in this.People)
            {
                if (id == person.ID)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
