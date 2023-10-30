using FBTarjetas.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBTarjetas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly AplicationDbContext _conetxt;
        public TarjetaController(AplicationDbContext context)
        {
            _conetxt = context;
        }


        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                var listtarjetas = await _conetxt.ANGULAR.ToListAsync();
                return Ok(listtarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {

            try
            {
                _conetxt.Add(tarjeta);
                await _conetxt.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(int id, [FromBody] TarjetaCredito tarjeta)
        {

            try
            {
                if (id != tarjeta.id )
                {
                    return NotFound();
                }
                else
                {
                    _conetxt.Update(tarjeta);
                    await _conetxt.SaveChangesAsync();
                    return Ok(new { message = "La tarjeta fue actualizada" });
                }
            }
            catch(Exception EX)
            {
                return BadRequest(EX.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {

            try
            {
                var tarjeta = await _conetxt.ANGULAR.FindAsync(id);
                if (tarjeta == null)
                {
                  return NotFound();
                }
                else
                {
                    _conetxt.ANGULAR.Remove(tarjeta);
                    await _conetxt.SaveChangesAsync();
                    return Ok(new { message = "La tarjeta fue eliminada con exito" });
                }

            }
            catch(Exception EX)
            {
                return BadRequest(EX.Message);
            }
        }
    }
}
