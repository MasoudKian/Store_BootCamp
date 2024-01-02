using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.ViewComponents
{
	#region SiteHeader 

	public class SiteHeader : ViewComponent
	{
		public SiteHeader() { }

		public async Task<IViewComponentResult> InvokeAsync()
		{
            return await Task.FromResult((IViewComponentResult)View("SiteHeader"));
        }
	}

    #endregion

    #region SiteFooter 

    public class SiteFooter : ViewComponent
    {
        public SiteFooter() { }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("SiteFooter"));
        }
    }

    #endregion
}
