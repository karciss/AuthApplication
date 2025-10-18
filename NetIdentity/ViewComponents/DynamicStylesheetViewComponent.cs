using Microsoft.AspNetCore.Mvc;
using NetIdentity.Services;
using System.Threading.Tasks;

namespace NetIdentity.ViewComponents
{
    public class DynamicStylesheetViewComponent : ViewComponent
    {
        private readonly UserService _userService;

        public DynamicStylesheetViewComponent(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genero = await _userService.GetUserGenderAsync(HttpContext.User);
            
            var cssFile = genero.ToLower() switch
            {
                "masculino" => "genero-masculino.css",
                "femenino" => "genero-femenino.css",
                _ => "genero-otro.css"
            };

            return View(model: cssFile);
        }
    }
}