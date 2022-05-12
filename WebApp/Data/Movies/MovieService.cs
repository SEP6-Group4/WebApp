﻿using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Movies
{
    public class MovieService : IMovieService
    {
        //string url = "http://webapi-sep6-dev.us-east-1.elasticbeanstalk.com/movie";
        string url = "https://localhost:7176/movie";
        HttpClient client;

        public MovieService()
        {
            client = new HttpClient();
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            string message = await client.GetStringAsync(url + "/" + id);
            Movie result = JsonSerializer.Deserialize<Movie>(message);
            return result;
        }

        public async Task<MovieList> GetMovies(int page)
        {
            string message = await client.GetStringAsync(url + "?page=" + page);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }
    }
}