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
        
        public async Task<TourModel> GetTourbyID(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);

            var result = await _client.GetAsync("Tour/" + id);
            var data = result.ResultAs<TourModel>();
            return data;

        }
        
        public async void PushTour(TourModel tour)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            await _client.SetAsync("Tour/" + tour.Id, tour);
        }

        public async Task<string> InitID()
        {
            var tourList = await GetAllTour();
            var id = 0;
            
            if (tourList != null)
            {
                id = tourList.Count;
            }
            return id.ToString();
        }

        public async Task<bool> CheckDuplicate(TourModel tour)
        {
            var tourList = await GetAllTour();
            var result = false;
            
            if (tourList != null)
            {
                if (tourList.Any(item => item.Name == tour.Name || item.Description == tour.Description || item.Price == tour.Price || item.Profit == tour.Profit))
                {
                    result = true;
                }
            }
            
            return result;
        }
    }
}