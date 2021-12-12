﻿using System.Collections.Generic;
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
        
        public async Task<TourGroupModel> GetTourGroupByID(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);

            var result = await _client.GetAsync("TourGroup/" + id);
            var data = result.ResultAs<TourGroupModel>();
            return data;
        }

        public async Task<bool> RemoveTourismFromList(string tourGroupId, string customerId)
        {
            var tourGroup = await GetTourGroupByID(tourGroupId);
            var customerList = tourGroup.CustomerList;
            var customerArray = customerList.Split(',');
            var newCustomerList = "";
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (customerArray[i] != customerId)
                {
                    newCustomerList += customerArray[i] + ",";
                }
            }
            newCustomerList = newCustomerList.TrimEnd(',');
            
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.UpdateAsync("TourGroup/" + tourGroupId, new { CustomerList = newCustomerList });
            var response = result.ResultAs<TourGroupModel>();
            return response != null;
        }
        
        public async Task<bool> AddTourismToList(string tourGroupId, string customerId)
        {
            var tourGroup = await GetTourGroupByID(tourGroupId);
            var newCustomerList = "";
            if (!string.IsNullOrEmpty(tourGroup.CustomerList))
            {
                newCustomerList = tourGroup.CustomerList + "," + customerId;
            }
            else
            {
                newCustomerList = customerId;
            }

            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.UpdateAsync("TourGroup/" + tourGroupId, new { CustomerList = newCustomerList });
            var response = result.ResultAs<TourGroupModel>();
            return response != null;
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