using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUDController.Interfaces
{
    public interface ICRUD
    {
        public ViewResult Create();
        public ViewResult List();
        public ActionResult Update(int id);
        public ActionResult Delete(int id);
    }
}
