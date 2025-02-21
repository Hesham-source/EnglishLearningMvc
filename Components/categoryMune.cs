using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishLearning.Data;
using EnglishLearning.Models.Identity;
using EnglishLearning.Models.Identity.Repositery;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EnglishLearning.Components
{
    [ViewComponent(Name = "categoryMune")]
    public class categoryMune : ViewComponent
    {
        private readonly IRepositery repositery;
        private readonly ApplicationDbContext context;

        public categoryMune(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clamidentity = (ClaimsIdentity)this.User.Identity;
            var clams = clamidentity.FindFirst(ClaimTypes.NameIdentifier);
            var data = await context.ApplicationUsers.FirstOrDefaultAsync(x=>x.Id== clams.Value);
            ApplicationUser model = new ApplicationUser()
            {
                Name = data.Name,
                picture = data.picture,
            };
            return View(model);
        }
    }
}
