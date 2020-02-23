using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class SoundController : Controller
    {
        private readonly ISoundService _soundService;
        public SoundController(ISoundService soundService)
        {
            _soundService = soundService;
        }


        [HttpGet]
        public IActionResult VolumeUp()
        {
            string consoleMsg = $"Api/{nameof(SoundController)}/{nameof(VolumeUp)}: ";
            Console.WriteLine($"{consoleMsg} Get into!");
            int result = default;
            try
            {
                result = _soundService.VolumeUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{consoleMsg} Exception : {ex.Message}");
                return new JsonResult (new BadRequestObjectResult(ex.Message));
            }

            Console.WriteLine($"{consoleMsg} Get out!");
            return new JsonResult(new OkObjectResult(result));
        }

        [HttpGet]
        public IActionResult VolumeDown()
        {
            string consoleMsg = $"Api/{nameof(SoundController)}/{nameof(VolumeDown)}: ";
            Console.WriteLine($"{consoleMsg} Get into!");
            int result = default;
            try
            {
                result = _soundService.VolumeDown();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{consoleMsg} Exception : {ex.Message}");
                return new JsonResult(new BadRequestObjectResult(ex.Message));
            }

            Console.WriteLine($"{consoleMsg} Get out!");
            return new JsonResult(new OkObjectResult(result));
        } 

        [HttpGet]
        public IActionResult Mute()
        {
            string consoleMsg = $"Api/{nameof(SoundController)}/{nameof(Mute)}: ";
            Console.WriteLine($"{consoleMsg} Get into!");
            bool result = default;
            try
            {
                result = _soundService.Mute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{consoleMsg} Exception : {ex.Message}");
                return new JsonResult(new BadRequestObjectResult(ex.Message));
            }

            Console.WriteLine($"{consoleMsg} Get out!");
            return new JsonResult(new OkObjectResult(result));
        }


        [HttpGet]
        public IActionResult CheckConnection()
        {
            string result = "Connected!";
            return new JsonResult(new OkObjectResult(result));
        }
        [HttpGet]
        public IActionResult CheckConnection2()
        {
            string result = "Connected!";
            return new OkObjectResult(result);
        }        [HttpGet]
        public IActionResult CheckConnection3()
        {
            string result = "Connected!";
            return new JsonResult(result);
        }
    }
}
