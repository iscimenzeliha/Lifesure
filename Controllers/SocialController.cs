using Proje7MVC.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class SocialController : Controller
    {
        private readonly LinkedinService _linkedinService = new LinkedinService();

        // Ajax ile çağrılacak action
        public async Task<ActionResult> GetLinkedinFollowers()
        {
            string username = "lifesure-group-ltd"; // LinkedIn public ID
            int followers = await _linkedinService.GetFollowerCountAsync(username);
            return Content(followers.ToString());
        }
    }
}
