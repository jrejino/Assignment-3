using System;
using System.IO;
using System.Linq;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimDb;

namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"{VatsimDbHepler.DATA_DIR}");

            using(var db = new VatsimDbContext())
            {

                var _pilots = db.Pilots.Select(p => p).ToList();
                Console.WriteLine($"The number of pilots records is: {_pilots.Count} ");
                
            //Longest Logged on
                var pilotLongestLogin = 
                    from p in _pilots
                    orderby _pilots.Max(p => p.TimeLogon)
                    select p.Realname;
                Console.WriteLine($"1) The pilot who has been logged on the longest is: {pilotLongestLogin.Max()}");
            
                var controller = db.Controllers.Select(c => c).ToList();
                var controllerLongestLogin = 
                      from c in controller
                      orderby controller.Max(c => c.TimeLogon)
                      select c.Cid;
                Console.WriteLine($"2) The controller who has been logged on the longest is: {controllerLongestLogin.Max()}");
                
                var departures = db.Flights.Select(f => f).ToList();
                var mostdepartures =
                        from f in departures
                        orderby departures.Max(f => f.PlannedDepairport)
                        select f.PlannedDepairport;
                Console.WriteLine($"3) The airport with the most departures is: {mostdepartures.Max()}");

                var arrivals = db.Flights.Select(f => f).ToList();
                var mostarrivals = 
                        from f in arrivals
                        orderby arrivals.Max(f => f.PlannedDestairport)
                        select f.PlannedDestairport;
                Console.WriteLine($"4) The airport with the most arrivals is: {mostarrivals.Max()}");

                var altitude = db.Positions.Select(s => s).ToList();
                var highestalt = 
                        from s in altitude
                        orderby altitude.Max(s => s.Altitude)
                        select s.Realname;
                Console.WriteLine($"5) The pilot flying the highest is : {highestalt.Max()}");

                
                
                
                var aircraft = db.Flights.Select(f => f).ToList();
                var mostaircraftused = 
                        from f in aircraft
                        orderby aircraft.Max(f => f.PlannedAircraft)
                        select f.PlannedAircraft;
                Console.WriteLine($"7) Most type of aircraft used : {mostaircraftused.Max()}");




            }
        }
    }
}