using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace M6HW3RazorPages.Interfaces
{
    public interface IUser
    {
        public ViewResult Create();
        public ViewResult List();
        public ActionResult Update(int id);
        public ActionResult Delete(int id);
    }
}
