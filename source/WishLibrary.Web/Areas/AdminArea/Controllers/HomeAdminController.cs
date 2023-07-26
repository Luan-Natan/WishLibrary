using Microsoft.AspNetCore.Mvc;

namespace WishLibrary.Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class HomeAdminController : Controller
    {
        #region #Views

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
