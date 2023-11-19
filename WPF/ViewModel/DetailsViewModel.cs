using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModel;

namespace WPF.ViewModels
{
    internal class DetailsViewModel : ViewModelBase
    {
        public DetailsViewModel(CountryTeam team)
        {
            country = team.CountryName;
            countryCode = team.FifaCode;
            played = (int)team.GamesPlayed;
            wins = (int)team.Wins;
            losses = (int)team.Losses;
            draws = (int)team.Draws;
            goalsScored = (int)team.GoalsFor;
            goalsTaken = (int)team.GoalsAgainst;
            goalDifference = (int)team.GoalDifferential;
        }
        
        private string country;
        public string Country { get => country; }

        private string countryCode;
        public string CountryCode { get => countryCode; }

        private int played;
        public int Played { get => played;  }

        private int wins;
        public int Wins { get => wins; }

        private int losses;
        public int Losses { get => losses; }

        private int draws;
        public int Draws { get => draws; }

        private int goalsScored;
        public int GoalsScored { get => goalsScored; }

        private int goalsTaken;
        public int GoalsTaken { get => goalsTaken; }

        private int goalDifference;
        public int GoalDifference { get => goalDifference; }
    }
}
