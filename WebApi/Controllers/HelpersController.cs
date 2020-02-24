using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class HelpersController : Controller
    {

        [HttpGet]
        public IActionResult GetAllDevices ()
        {
            string consoleMsg = $"Api/{nameof(SoundController)}/{nameof(GetAllDevices)}: ";
            Console.WriteLine($"{consoleMsg} Get into!");
            string aoe;
            try
            {
                aoe = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{consoleMsg} Exception : {ex.Message}");
                return new JsonResult(new BadRequestObjectResult(ex.Message));
            }

            Console.WriteLine($"{consoleMsg} Get out!");

            return new JsonResult(new OkObjectResult(aoe));
        }

    }
}
