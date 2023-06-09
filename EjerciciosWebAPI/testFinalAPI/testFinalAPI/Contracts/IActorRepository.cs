﻿using System.Collections.Generic;
using testFinalAPI.Models;

namespace testFinalAPI.Contracts
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
