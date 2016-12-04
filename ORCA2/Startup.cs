using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using ORCA2.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(ORCA2.Startup))]
namespace ORCA2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createAdmin();
        }

        private void createAdmin()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            var user = new ApplicationUser();
            user.UserName = "admin@orca.com";
            user.Email = "admin@orca.com";

            string userPWD = "password";

            var chkUser = UserManager.Create(user, userPWD);
            
        }
    }
}
