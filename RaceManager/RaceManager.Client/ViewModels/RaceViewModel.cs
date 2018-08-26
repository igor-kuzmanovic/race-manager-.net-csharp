using RaceManager.Client.Models;
using RaceManager.Client.Models.Converters;
using RaceManager.Client.RaceService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.ViewModels
{
    class RaceViewModel
    {
        private readonly RaceServiceClient _raceServiceClient;

        public RaceViewModel()
        {
            _raceServiceClient = new RaceServiceClient();
            LoadRaces();
        }

        public ObservableCollection<Race> Races { get; set; }

        private void LoadRaces()
        {
            //Races = new ObservableCollection<Race>(RaceConverter.Instance.Convert(_raceServiceClient.GetAll()));

            var races = new List<Race>()
            {
                new Race()
                {
                    Id = 0,
                    EventDate = new DateTime(2018, 8, 8),
                    EventLocation = "Race Location 1",
                },
                new Race()
                {
                    Id = 1,
                    EventDate = new DateTime(2017, 7, 7),
                    EventLocation = "Race Location 2",
                },
                new Race()
                {
                    Id = 2,
                    EventDate = new DateTime(2016, 6, 6),
                    EventLocation = "Race Location 3",
                }
            };

            Races = new ObservableCollection<Race>(races);
        }
    }
}