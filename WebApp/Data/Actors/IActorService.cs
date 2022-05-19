using WebApp.Models;

namespace WebApp.Data.Actors
{
    public interface IActorService
    {
        Task<Actor> GetActorByID(int id);
        Task<MovieCredit> GetMovieCreditsByActorId(int actorId);
        void SetActorId(int id);
        int GetActorId();
    }
}
