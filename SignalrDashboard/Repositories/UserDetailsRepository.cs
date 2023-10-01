using SignalrDashboard.Models;

namespace SignalrDashboard.Repositories
{
    public class UserDetailsRepository
    {
        public static List<UserDetails> _usersDetails = new List<UserDetails>();  
        public static int totalUsers = 0;
        public static int totalActions = 0;

        /*public UserDetailsRepository() 
        {
            _usersDetails=new List<UserDetails>();
        }*/
        public void AddUserDetailsInRepo(UserDetails ud)
        {
            Console.WriteLine("------ in repo ------");

            Console.WriteLine(ud.DeviceType);
            Console.WriteLine(ud.Os);
            Console.WriteLine(ud.Browser);

            
            totalUsers++;

            _usersDetails.Add(ud);
            Console.WriteLine("list count "+ _usersDetails.Count);
        }
        public void AddActionInRepo()
        {
            totalActions++;
            Console.WriteLine("total clicks: " + totalActions);
        }

        public (int, int) GetGeneralData()
        {
            return (totalUsers, totalActions);
        }
        public List<UserGraphData> GetBrowserData()
        {
            Console.WriteLine("get br data:::::; ****: " + _usersDetails.Count);
            List<UserGraphData> browserData = new List<UserGraphData>();

            var distinctBrowserTypes = _usersDetails
            .GroupBy(num => num.Browser)
            .Select(group => new { Value = group.Key, Count = group.Count() })
            .ToList();

            foreach (var item in distinctBrowserTypes)
            {
                UserGraphData gd=new UserGraphData();
                gd.Value= item.Value;
                gd.Count = item.Count;
                browserData.Add(gd);

                Console.WriteLine($"Value: {item.Value}, Count: {item.Count}");
            }
            return browserData;
        }
        public List<UserGraphData> GetDeviceData()
        {
            Console.WriteLine("get br data:::::; ****: " + _usersDetails.Count);
            List<UserGraphData> deviceData = new List<UserGraphData>();

            var distinctDeviceTypes = _usersDetails
            .GroupBy(num => num.DeviceType)
            .Select(group => new { Value = group.Key, Count = group.Count() })
            .ToList();

            foreach (var item in distinctDeviceTypes)
            {
                UserGraphData gd = new UserGraphData();
                gd.Value = item.Value;
                gd.Count = item.Count;
                deviceData.Add(gd);

                Console.WriteLine($"Value: {item.Value}, Count: {item.Count}");
            }
            return deviceData;
        }
        public List<UserGraphData> GetOsData()
        {
            Console.WriteLine("get br data:::::; ****: " + _usersDetails.Count);
            List<UserGraphData> osData = new List<UserGraphData>();

            var distinctOsTypes = _usersDetails
            .GroupBy(num => num.Os)
            .Select(group => new { Value = group.Key, Count = group.Count() })
            .ToList();

            foreach (var item in distinctOsTypes)
            {
                UserGraphData gd = new UserGraphData();
                gd.Value = item.Value;
                gd.Count = item.Count;
                osData.Add(gd);

                Console.WriteLine($"Value: {item.Value}, Count: {item.Count}");
            }
            return osData;
        }
    }
}
