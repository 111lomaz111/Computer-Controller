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
    public class SoundController
    {
        private readonly ISoundService _soundService;
        public SoundController(ISoundService soundService)
        {
            _soundService = soundService;
        }


        [HttpGet]
        public IActionResult VolumeUp()
        {
            string response;
            try
            {
                response = _soundService.VolumeUp().ToString();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return new JsonResult(response);
        }

        [HttpGet]
        public IActionResult VolumeDown()
        {
            string response;
            try
            {
                response = _soundService.VolumeDown().ToString();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return new JsonResult(response);
        } 

        [HttpGet]
        public IActionResult Mute()
        {
            string response;
            try
            {
                response = _soundService.Mute().ToString();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return new JsonResult(response);
        } 
    }
}
