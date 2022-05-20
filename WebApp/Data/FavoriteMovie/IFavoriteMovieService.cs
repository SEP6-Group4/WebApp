﻿using WebApp.Models;

namespace WebApp.Data.FavoriteMovie
{
    public interface IFavoriteMovieService
    {
        Task AddFavoriteMovie(int userID, int movieID);
        Task<MovieList> GetFavoriteMoviesByID(int userID);
        Task<bool> GetIsFavoriteMovieByID(int userID, int movieID);
        Task RemoveFavoriteMovieByID(int userID, int movieID);
        Task<int> GetFavoriteMovieCount(int movieID);
        Task<List<IdCount>> GetFavoriteMoviesByAgeGroup(int ageGroup);
    }
}
