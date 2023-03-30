using System.Collections.Generic;
using testFinalAPI.Contracts;
using testFinalAPI.Models;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace testFinalAPI.Repositories
{
    public class ActorRepository : IActorRepository
    {

        const string JSON_PATH = @"C:\Users\I40265\source\repos\testFinalAPI\testFinalAPI\Resources\Actores.json";

        private string GetActorsFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }

        private void UpdateActor(List<Actor> actores)
        {
            var actoresJson = JsonConvert.SerializeObject(actores, Formatting.Indented);
            File.WriteAllText(JSON_PATH, actoresJson);
        }

        public void AddActor(Actor actor)
        {
            var actores = GetActors();
            var existeActor = actores.Exists(a => a.Id == actor.Id);
            if (existeActor)
                {
                    throw new Exception("Ya existe un autor con ese id");
                }
            actores.Add(actor);
            UpdateActor(actores);
        }

        public void DeleteActor(int id)
        {
            var actores = GetActors();
            var actor = actores.FirstOrDefault(a => a.Id == id);
            if (actor == null)
            {
                throw new Exception("No se encontró ningún actor con ese id");
            }
            actores.Remove(actor);
            UpdateActor(actores);
        }

        public Actor GetActorById(int id)
        {
            var actores = GetActors();
            var actor = actores.FirstOrDefault(a => a.Id == id);
            return actor;
        }

        public List<Actor> GetActors()
        {
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List<Actor> actores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);
                return actores;
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public void UpdateActor(Actor actorActualizado)
        {
            var actores = GetActors();
            var actor = actores.FirstOrDefault(a => a.Id == actorActualizado.Id);
            if (actor == null)
            {
                throw new Exception("No se encontró ningún actor con ese id");
            }
            actores[actores.IndexOf(actor)] = actorActualizado;
            UpdateActor(actores);
        }
    }
}
