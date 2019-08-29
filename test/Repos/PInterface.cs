using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Repos
{
    public interface PInterface
    {
        JsonResult getAllP();
        JsonResult getIDP(int id);
        void PostP(int id, string pname, int addid);
        void PutP(int id, string pname, int addid);
        void DeleteP(int id);
        
    }
}
