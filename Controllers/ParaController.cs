using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ParaController : Controller
    {
        public IParaRepository ParaRepo { get; set; }

        public ParaController(IParaRepository _repo)
        {
            ParaRepo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPara()
        {
            var paraList = await ParaRepo.GetAllPara();
            return Ok(paraList);
        }

        [HttpGet("getAllParaLeft")]
        public async Task<IActionResult> GetAllParaLeft()
        {
            var paraList = await ParaRepo.GetAllParaLeft();
            return Ok(paraList);
        }

        [HttpGet("getAllParaRight")]
        public async Task<IActionResult> GetAllParaRight()
        {
            var item = await ParaRepo.GetAllParaRight();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("removeAllParaRight")]
        public IActionResult RemoveAllParaRight()
        {
              ParaRepo.RemoveAllParaRight();          
            return Ok("success");
        }


        [HttpGet("updateParaLeft")]
        public IActionResult UpdateParaLeft()
        {
            ParaRepo.UpdateParaLeft();
            return Ok("success");
        }

        [Route("paraRight")]
        [HttpPost]
        public IActionResult Create([FromBody] PostParaRight postParaRight)
        {
            if (postParaRight == null)
            {
                return BadRequest();
            }

            ParaRepo.RemoveAllParaRight();
            
            foreach (int i in postParaRight.paraIds)
            {
                ParaRepo.AddParaRight(i);
            }
            ParaRepo.UpdateParaLeft();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    await ParaRepo.Delete(Convert.ToInt32(id));
        //    return NoContent();
        //}
    }
}
