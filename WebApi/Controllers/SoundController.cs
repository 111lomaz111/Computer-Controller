using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Helpers;
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

        [HttpPut]
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

        [HttpPut("{value:int}")]
        public IActionResult ChangeVolumeByValue(int value)
        {
            string consoleMsg = $"Api/{nameof(SoundController)}/{nameof(ChangeVolumeByValue)}: ";
            Console.WriteLine($"{consoleMsg} Get into!");

            bool isSuccess = default;
            try
            {
                isSuccess = _soundService.ChangeByValue(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{consoleMsg} Exception : {ex.Message}");
                return new JsonResult(new BadRequestObjectResult(ex.Message));
            }

            Console.WriteLine($"{consoleMsg} Get out!, IsSuccess: {isSuccess}");
            if (isSuccess)
            {
                return new JsonResult(new OkResult());
            }
            else{
                return new JsonResult(new BadRequestResult());
            }
        }


        [HttpGet]
        public IActionResult CheckConnection()
        {
            string consoleMsg = $"Api/{nameof(SoundController)}/{nameof(CheckConnection)}: ";
            Console.WriteLine($"{consoleMsg} Get into!");

            string result = "Connected!";

            Console.WriteLine($"{consoleMsg} Get out!");
            return new JsonResult(new OkObjectResult(result));
        }
    }
}
