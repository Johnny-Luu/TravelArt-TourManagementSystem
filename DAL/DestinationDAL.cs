using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using FireSharp;
using Models;

namespace DAL
{
    public class DestinationDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;
        
        public async Task<List<DestinationModel>> GetAllDestination()
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.GetAsync("Destination");
            var list = result.ResultAs<List<DestinationModel>>();
            
            if(list == null)
            {
                return new List<DestinationModel>();
            }
            
            // find all destination with id != -1
            var data = list.FindAll(x => x.Id != "-1");
            return data;
        }
        
        public async Task<DestinationModel> GetDestinationbyID(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);

            var result = await _client.GetAsync("Destination/" + id);
            var data = result.ResultAs<DestinationModel>();
            return data;

        }
        
        public async Task<bool> ExistReference(string id)
        {
            var tourDAL = new TourDAL();
            var tourList = await tourDAL.GetAllTour();
            return tourList.Any(tour => tour.DestinationIds.Contains(id));
        }
        
        public async void DeleteDestination(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            await _client.UpdateAsync("Destination/" + id, new { Id = "-1" });
        }
        
        public async void PushDestination(DestinationModel destination)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            await _client.SetAsync("Destination/" + destination.Id, destination);
        }
        
        public async Task<List<DestinationModel>> GetDestinationByProvince(string province)
        {
            var destinationList = await GetAllDestination();
            var destinationByProvince = new List<DestinationModel>();
            foreach (var item in destinationList)
            {
                if (item.Province == province)
                {
                    destinationByProvince.Add(item);
                }
            }
            return destinationByProvince;
        }
        
        public async Task<string> InitID()
        {
            var destinationList = await GetAllDestination();
            var id = 0;

            if (destinationList != null)
            {
                id = destinationList.Count;
            }
            
            return id.ToString();
        }
        
        public async Task<bool> CheckDuplicate(DestinationModel destination)
        {
            var destinationList = await GetAllDestination();
            var result = false;
            
            if (destinationList != null)
            {
                if (destinationList.Any(item => item.Name == destination.Name || item.Description == destination.Description || item.Province == destination.Province))
                {
                    result = true;
                }
            }
            
            return result;
        }
    }
}