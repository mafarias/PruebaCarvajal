using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Contexts;
using ApiRest.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext context;

        public UsuarioController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            try
            {
                return context.Usuario.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault(u => u.Id == id);
                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Usuario producto)
        {
            try
            {
                context.Usuario.Add(producto);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw ex;
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Usuario usuario)
        {
            try
            {
                if (usuario.Id == id)
                {
                    context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
                throw ex;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault(u => u.Id == id);
                if (usuario != null)
                {
                    context.Usuario.Remove(usuario);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw ex;
            }
        }
    }
}
