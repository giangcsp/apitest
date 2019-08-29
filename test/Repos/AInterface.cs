using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repos
{
     public interface AInterface
    {
        JsonResult getAll();
        JsonResult getID(int id);
        string Post(int id, string addr);
        string Put(int id, string addr);
        void Delete(int id);
    }
}
