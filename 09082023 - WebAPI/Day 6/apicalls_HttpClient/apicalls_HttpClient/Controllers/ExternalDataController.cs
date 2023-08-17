using apicalls_HttpClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace apicalls_HttpClient.Controllers
{
    public class ExternalDataController : Controller
    {
        CommentDetails commentObj = new CommentDetails(); //we should use DI instead, we will learn about it tomorrow;

        public IActionResult Comments()
        {
            ViewBag.userComments = commentObj.GetComments();
            return View();
        }
    }
}
