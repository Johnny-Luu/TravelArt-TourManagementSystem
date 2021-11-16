using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FireSharp;
using FireSharp.Config;
using FireSharp.Extensions;
using Models;
using Newtonsoft.Json;

namespace DAL
{
    public class TourDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;

        public async Task<List<TourModel>> GetAllTour()
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.GetAsync("Tour");
            var data = result.ResultAs<List<TourModel>>();

            return data;
        }
        
        public async void PushTour(TourModel tour)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            await _client.SetAsync("Tour/" + tour.Id, tour);
        }
    }
}