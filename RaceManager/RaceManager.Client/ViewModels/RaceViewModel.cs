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
            Races = new ObservableCollection<Race>(RaceConverter.Instance.Convert(_raceServiceClient.GetAll()));
        }
    }
}