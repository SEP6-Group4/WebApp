﻿using WebApp.Models;

namespace WebApp.Data.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByID(int id);
        Task<MovieList> GetMovies(int page);
    }
}
