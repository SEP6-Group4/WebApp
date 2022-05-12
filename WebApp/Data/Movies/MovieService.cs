﻿using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Movies
{
    public class MovieService : IMovieService
    {
        //string url = "http://webapi-sep6-dev.us-east-1.elasticbeanstalk.com/movie";
        string url = "https://localhost:7176/movie";
        HttpClient client;
        private int movieId = 0;

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

        public async Task<Credit> GetCreditsByMovieId(int movieId)
        {
            string message = await client.GetStringAsync(url + "/" + movieId + "/credits");
            Credit result = JsonSerializer.Deserialize<Credit>(message);
            return result;
        }

        public int GetMovieId()
        {
            return movieId;
        }

        public void SetMovieId(int id)
        {
            movieId = id;
        }
    }
}
