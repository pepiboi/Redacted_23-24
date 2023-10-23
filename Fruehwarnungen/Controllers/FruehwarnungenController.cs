using Fruehwarnungen.Dtos;
using Fruehwarnungen.Services;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Net;

namespace Fruehwarnungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FruehwarnungenController : ControllerBase
    {
        private FruehwarnungenService _fs;

        public FruehwarnungenController(FruehwarnungenService fs)
        {
            _fs = fs;
        }

        [HttpGet("Klassen")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public ActionResult<string> GetKlassen()
        {
            try
            {
                var list = _fs.GetClazzes();
                if (list.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(list);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Faecher/{clazz}")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public ActionResult<string> GetFaecherByClazz(string clazz)
        {
            try
            {
                var list = _fs.GetFaecher(clazz);
                if (list.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Personen/{clazz}")]
        [ProducesResponseType(typeof(List<PersonDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public ActionResult<PersonDto> GetPersonenByClazz(string clazz)
        {
            try
            {
                var list = _fs.GetPersons(clazz);
                if (list.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Username")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public ActionResult<string> GetLoggedInUserName()
        {
            try
            {
                return Ok(_fs.GetCurrentUserName());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostFruehwarnung")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public ActionResult PostFruehwarnung(PostDto post)
        {
            if (_fs.PostFruehwarnung(post))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
