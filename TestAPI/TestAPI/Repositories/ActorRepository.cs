using Newtonsoft.Json;
using TestAPI.Contracts;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class ActorRepository : IActorRepository
    {
        const string JSON_PATH = @"C:\Users\I40265\source\repos\TestAPI\TestAPI\Resources\Actores.json";

        public void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public Actor GetActorById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Actor> GetActors()
        {
            try
            {
                var actoresFromFile = GetActorFromFile();
                List<Actor> actores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);
                return actores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        private String GetActorFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }
    }
}
