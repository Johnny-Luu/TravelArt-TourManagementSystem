using System.Collections.Generic;
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
            var data = result.ResultAs<List<DestinationModel>>();

            return data;
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
    }
}