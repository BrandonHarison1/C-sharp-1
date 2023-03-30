using Almacen_API.Contracts;
using Almacen_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Almacen_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RopaController : ControllerBase
    {
        private readonly IRopaRepository _ropaRepository;
        public RopaController(IRopaRepository ropaRepository) => _ropaRepository = ropaRepository;

        [HttpGet("GetRopa")]
        public ActionResult<List<Ropa>> Get()
        {
            return _ropaRepository.GetRopas();
        }

        [HttpPost("AddArticle")]
        public ActionResult AddArticle(Ropa ropa)
        {
            try
            {
                _ropaRepository.AddArticle(ropa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddArticleStock")]
        public ActionResult AddArticleStock(int id, int cantidad)
        {
            try
            {
                _ropaRepository.AddArticleStock(id, cantidad);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("RemoveArticleStock")]
        public ActionResult RemoveArticleStock(int id, int cantidad)
        {
            try
            {
                _ropaRepository.RemoveArticleStock(id, cantidad);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("No se encontro ningun articulo con ese id"))
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
