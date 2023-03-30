using TestAPI.Models;

namespace TestAPI.Contracts
{
    public interface IActorRepository
    {


        List<Actor> GetActors();
        Actor GetActorById(int id);
        void AddActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(int id);
    }
}
