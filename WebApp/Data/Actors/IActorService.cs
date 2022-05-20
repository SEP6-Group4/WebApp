using WebApp.Models;

namespace WebApp.Data.Actors
{
    public interface IActorService
    {
        Task<Actor> GetActorByID(int id);
        Task<MovieCredit> GetMovieCreditsByActorId(int actorId);
        Task<ActorList> GetPopularActors(int page);
        void SetActorId(int id);
        int GetActorId();
        Task<ActorList> GetActorsBySearch(int page, string query);
    }
}
