namespace NMS.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class NumberController : Controller
    {
        // GET: Number
        public ActionResult Index()
        {
            return View();
        }
    }
}