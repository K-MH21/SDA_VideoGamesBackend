//This Controller will do:
//1-Create Console
//2-update Console
//3-get Console by id
//4-get all Consoles
//5-delete Console by id

using System.Collections.Generic;
using System.Linq;
using FusionTech.src.Entity;
using Microsoft.AspNetCore.Mvc;
using sda_3_online_Backend_Teamwork.src.Service;
using FusionTech.Service.Console;
using static sda_3_online_Backend_Teamwork.src.DTO.ConsoleDTO;

namespace FusionTech.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConsoleController : ControllerBase
    {
       protected readonly  IConsoleService _consoleService;

        public ConsoleController(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }


        //1-Create Console:
        [HttpPost]
        public async Task<ActionResult<ReadConsoleDTO>> CreateOneAsync(CreatConsoleDTO createDTO)
        {
            var consoleCreated = await _consoleService.CreateOneAsync(createDTO);
            return Created($"api/v1/Console/{consoleCreated.ConsoleName}", consoleCreated);
        }

        //2-update Console
        [HttpPut("{id}")]
        
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, UpdateConsoleDTO consoleName)
        {
            var foundconsole = await _consoleService.GetIdAsync(id);
            if (foundconsole == null)
            {
                return false;
            }

            return Ok(foundconsole);
        }

        //3-get Console by id
        [HttpGet("{id}")]
    
        public async Task<ActionResult<ReadConsoleDTO>> GetIdAsync(Guid id)
        {
            var foundcosole = await _consoleService.GetIdAsync(id);
            return Ok(foundcosole);
        }

        //4-get all Consoles
        [HttpGet]
       public async Task<ActionResult<ReadConsoleDTO>> GetAllAsync()
        {
            var Listconsole = await _consoleService.GetAllAsync();
            return Ok(Listconsole );
        }

    
        //5-delete Console by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteId(Guid id)
        {
            var foundConsole = await _consoleService.GetIdAsync(id);

            // if not fount
            if (foundConsole == null)
            {
                return NotFound();
            }
            //if found
            await  _consoleService.DeleteIdAsync(foundConsole.ConsoleId);
            return NoContent();
        }
    }
}
