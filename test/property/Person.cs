namespace WebApplication1.property
{
    public class Person
    {
        private Pcontext context = new Pcontext();
        public int ID
        {
            get;
            set;
        }
        public string PNAME
        {
            get;
            set;
        }
        public virtual Address add
        {
            get;
            set;
        }
        public int addid { get; set; }

        public void changeAdd(Address ad)
        {
            ad.People.Add(new Person
            {
                ID = this.ID,
                PNAME = this.PNAME,
                add = ad
            });
            this.add.removePerson(this.ID, this.context);
        }
        
    }
}
