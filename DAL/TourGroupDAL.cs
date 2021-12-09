using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using FireSharp;

namespace DAL
{
    public class TourGroupDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;

        public async Task<List<TourGroupModel>> GetAllTourGroup()
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);

            var result = await _client.GetAsync("TourGroup");
            var data = result.ResultAs<List<TourGroupModel>>();

            return data;
        }
        
        public async void PushTourGroup(TourGroupModel tourGroup)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config); 
            await _client.SetAsync("TourGroup/" + tourGroup.Id, tourGroup);
        }
        
        public async Task<string> InitID()
        {
            var hotelList = await GetAllTourGroup();
            var id = 0;
            
            if (hotelList != null)
            {
                id = hotelList.Count;
            }
            
            return id.ToString();
        }
    }
}