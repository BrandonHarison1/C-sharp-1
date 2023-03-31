using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testFinalAPI.Contracts;
using testFinalAPI.Models;
using System;
using System.Net.PeerToPeer.Collaboration;

namespace testFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public ActionResult<List<Actor>> Get()
        {
            try
            {
                _actorRepository.GetActors();
                return Ok();
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> GetActorById(int id)
        {
            return _actorRepository.GetActorById(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<Actor> DeleteActor(int id)
        {
            try
            {
                _actorRepository.DeleteActor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateActor(Actor actor)
        {
            try
            {
                _actorRepository.AddActor(actor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateActor(Actor actor)
        {
            try
            {
                    _actorRepository.UpdateActor(actor);
                    return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
