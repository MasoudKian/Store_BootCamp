using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class AccountInfoController : Controller
    {
        #region Constructor

        private readonly IUserPanelService _userPanelService;
        public AccountInfoController(IUserPanelService userPanelService)
        {
            _userPanelService = userPanelService;
        }

        #endregion

        [HttpGet("Profile")]
        public IActionResult Profile()
        {
           var user = _userPanelService.GetInformationUser(User.Identity.Name);
            return View(user);
        }
    }
}
