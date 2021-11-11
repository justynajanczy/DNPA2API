using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IFileAdapter adultsService;

        public AdultsController(IFileAdapter adultsService)
        {
            this.adultsService = adultsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultsService.GetAdults();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adult>> GetAdult(int id)
        {
            try
            {
                Adult adult = await adultsService.Get(id);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult(Adult adult)
        {
            try
            {
                Adult added = await adultsService.AddAdultAsync(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdult(int id)
        {
            Adult adultToRemove = await adultsService.Get(id);
            if (adultToRemove == null)
            {
                return NotFound();
            }

            await adultsService.RemoveAdult(adultToRemove.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Adult>> UpdateAdult(Adult adult)
        {
            Adult adultToUpdate = await adultsService.Get(adult.Id);
            if (adultToUpdate.Equals(null))
                return NotFound($"Adult with id {adult.Id} not found");
            return await adultsService.UpdateAdult(adult);
            
        }
    }
}   