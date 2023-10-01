using Microsoft.AspNetCore.SignalR;
using SignalrDashboard.Models;
using SignalrDashboard.Repositories;

namespace SignalrDashboard.Hubs
{
    public class DashboardHub:Hub
    {
        private UserDetailsRepository udRepo;
        public DashboardHub()
        {
            udRepo = new UserDetailsRepository();
        }
        public void AddUserDetails(string deviceType, string os, string browser)
        {
            Console.WriteLine("devicetype,browser,os::::::::::::::");
            Console.WriteLine(deviceType);
            Console.WriteLine(os);
            Console.WriteLine(browser);

            UserDetails ud = new UserDetails();
            ud.DeviceType = deviceType;
            ud.Os = os;
            ud.Browser = browser;

            udRepo.AddUserDetailsInRepo(ud);

            Clients.All.SendAsync("UserAdded", UserDetailsRepository.totalUsers);
            Clients.All.SendAsync("BrowserDetails", udRepo.GetBrowserData());
            Clients.All.SendAsync("OsDetails", udRepo.GetOsData());
            Clients.All.SendAsync("DeviceDetails", udRepo.GetDeviceData());

        }
        public void AddAction()
        {
            udRepo.AddActionInRepo();
            Clients.All.SendAsync("ActionAdded", UserDetailsRepository.totalActions);
        }
    }
}
