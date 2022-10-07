using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelAgancyPro.Models;

namespace TravelAgancyPro.Classes.StartupAuth
{
    public static class UsersStartup
    {
        public static void createRolesandUsers()
        {

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists(TravelAgancyPro.Models.RoleName.Admin))
            {
             

                // first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = TravelAgancyPro.Models.RoleName.Admin;
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website 
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Admin@mail.com";


                string userPWD = "7nJ4oq7@f*Dg";

                var chkUser = UserManager.Create(user, userPWD);
                //add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var resultl = UserManager.AddToRole(user.Id, TravelAgancyPro.Models.RoleName.Admin);
                }
            }


            // creating Creating Trainer role

            if (!roleManager.RoleExists(TravelAgancyPro.Models.RoleName.User))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = TravelAgancyPro.Models.RoleName.User;
                roleManager.Create(role);
            }
            // creating Creating Manager role 
            if (!roleManager.RoleExists(TravelAgancyPro.Models.RoleName.Manger))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = TravelAgancyPro.Models.RoleName.Manger;
                roleManager.Create(role);

            }
        }
    }
}