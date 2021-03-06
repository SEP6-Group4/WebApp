using WebApp.Models;

namespace WebApp.Data.FavouriteActor
{
    public interface IFavouriteActorService
    {
        Task AddActorToFavourite(int userId, int actorId);

        Task RemoveActorFromFavourite(int userId, int actorId);

        Task<List<int>> GetFavouriteActorIds(int userId);
        Task<List<Actor>> GetFavouriteActorsByEmail(string email);
    }
}
