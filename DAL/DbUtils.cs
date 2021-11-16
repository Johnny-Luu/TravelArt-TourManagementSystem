using FireSharp.Config;

namespace DAL
{
    public class DbUtils
    {
        public DbUtils() { }

        public FirebaseConfig CreateConnection()
        {
            FirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "5aMjR8wrQJcGiDAXVcA4BmosFR8vLYZSh5QKJVSk",
                BasePath = "https://tourmanagementsystem-57929-default-rtdb.asia-southeast1.firebasedatabase.app/"
            };
            return config;
        }
    }
}