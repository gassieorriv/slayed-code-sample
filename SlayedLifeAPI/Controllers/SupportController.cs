using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlayedLifeCore;
using SlayedLifeCore.Support;
using SlayedLifeModels.Support;
using System;
using System.Threading.Tasks;

namespace SlayedLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportNoteService supportNoteService;
        private readonly IMapper mapper;
        public SupportController(ISupportNoteService supportNoteService, IMapper mapper)
        {
            this.supportNoteService = supportNoteService;
            this.mapper = mapper;
        }

        [HttpPost("user/note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> Twitter(SupportNoteDto supportNoteDto)
        {
            try
            {
                var supportNote = mapper.Map<SupportNote>(supportNoteDto);
                await supportNoteService.CreateAppUserSupportNote(supportNote);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
