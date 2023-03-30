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

        [HttpGet("GetActors")]
        public ActionResult<List<Actor>> Get()
        {
            return _actorRepository.GetActors();
        }

        [HttpGet("GetActorById/id")]
        public ActionResult<Actor> GetActorById(int id)
        {
            return _actorRepository.GetActorById(id);
        }

        [HttpPost("/DeleteActor/id")]
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

        [HttpPost("AddActor")]
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

        [HttpPost("UpdateActor/Actor")]
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
