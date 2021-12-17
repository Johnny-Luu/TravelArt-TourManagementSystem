using System;
using FunctionLibrary;
using NUnit.Framework;
using static System.DateTime;

namespace TestTourManagement
{
    public class TestAddingTourGroups
    {
       
        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","2","Tran Linh Khue L","20", 1,2,true)]
        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","2","Tran Linh Khue L","20", 2,1,false)]
       
        [TestCase("","2","Da Lat","1","Pham Hoai B","2","Tran Linh Khue L","20", 1,2,false)]
        [TestCase("Tour Group Name","","Da Lat","1","Pham Hoai B","2","Tran Linh Khue L","20", 1,2,false)]
        [TestCase("Tour Group Name","2","","1","Pham Hoai B","2","Tran Linh Khue L","20", 1,2,false)]
        [TestCase("Tour Group Name","2","Da Lat","","Pham Hoai B","2","Tran Linh Khue L","20", 1,2,false)]
        [TestCase("Tour Group Name","2","Da Lat","1","","2","Tran Linh Khue L","20", 1,2,false)]
        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","","Tran Linh Khue L","20", 1,2,false)]
        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","2","","20", 1,2,false)]
        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","2","Tran Linh Khue L","", 1,2,false)]

        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","2","Tran Linh Khue L","-1", 1,2,false)]
        [TestCase("Tour Group Name","2","Da Lat","1","Pham Hoai B","1","Pham Hoai Bao","20", 1,2,false)]

        public void TestAddingTourGroup(string name,string tourId,string tourName,string tourLeaderId,string tourLeaderName,string tourDeputyId,string tourDeputyName,string slot, int _startDate,int _endDate,bool result)
        {
            var day1 =new DateTime(20, 11, 20)  ;
            var day2 =new DateTime(20, 11, 21)  ;
            DateTime startDate = (_startDate==1?day1:day2);
            DateTime endDate = (_endDate==1?day1:day2);
            Assert.AreEqual(result, AddingTourGroup.isAddAble(name,tourId,tourName,tourLeaderId,tourLeaderName,tourDeputyId,tourDeputyName,slot,startDate,endDate));
            

        }
    }
}