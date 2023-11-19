using DAL.Repositories;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Resources;
using DAL.Model.Enums;
using System.Threading;
using System.Globalization;
using System.Windows.Markup;
using DAL.Model;

namespace WPF.ViewModel
{
    internal class NationalTeamViewModel : ViewModelBase
    {
        public NationalTeamViewModel()
        {
            ChangeCulture();
        }

        private void ChangeCulture()
        {
            
            if (true)
            {
                CultureInfo newCulture = new CultureInfo("hr-HR");
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;
                
            }
            else
            {
                CultureInfo newCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;
               
            }

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name)));
        }

        public string Title 
        {
            get
            {
                //return rm.GetString("Title");
                return "Statistics";
            }
        
        }
        public ObservableCollection<string> Countries
        {
            get
            {
                var countryStrings = new ObservableCollection<string>();
                foreach (var countryTeam in DataFactory.CountryTeams)
                {
                    countryStrings.Add(countryTeam.ToString());
                }
                return countryStrings;
            }
        }

        
        public int SelectedIndexCountry
        {
            get
            {
                if (DataFactory.FavouriteSettings.FavouriteTeam != null)
                {
                    return Countries.IndexOf(DataFactory.FavouriteSettings.FavouriteTeam.ToString());
                }
                return 0;
            }
            set
            {
                var settings = DataFactory.FavouriteSettings;
                settings.FavouriteTeam = DataFactory.CountryTeams.First(t => t.ToString()==Countries.ElementAt(value));
                DataFactory.FavouriteSettings = settings;
                
                OnPropertyChanged(nameof(SelectedIndexCountry));
            }
        }


        public int OpponentSelectedIndex { get; set; } = 0;

        public MatchData SelectedMatch
        {
            get
            {
                var matchData = DataFactory.MatchDataForSelectedCountry;
                var opponentString = Opponents.ElementAt(OpponentSelectedIndex).ToString();
                string[] countryData = opponentString.Split('(');
                string countryName = countryData[0].Substring(0, countryData[0].LastIndexOf(' '));
                foreach (var match in matchData)
                {
                    if (match.AwayTeamCountry == countryName || match.HomeTeamCountry == countryName)
                    {
                        return match;
                    }
                }
                throw new Exception("nationalTeamViewModel: no such match");
            }
        }

        public ObservableCollection<string> Opponents
        { 
            get 
            {
                var opponents = new ObservableCollection<string>();
                var matches = DataFactory.MatchDataForSelectedCountry;
                foreach (var match in matches)
                {
                    if (match.HomeTeam.ToString() == Countries.ElementAt(SelectedIndexCountry))
                    {
                        opponents.Add(match.AwayTeam.ToString());
                    } else if (match.AwayTeam.ToString() == Countries.ElementAt(SelectedIndexCountry))
                    {
                        opponents.Add(match.HomeTeam.ToString());
                    }
                }
                return opponents;
            }
        }

        private static string RESULT = "Result: ";
        private string result = RESULT;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = RESULT + value;
                OnPropertyChanged(nameof(Result));
            }
        }

        internal void UpdateOpponents()
        {
            OnPropertyChanged(nameof(Opponents));
        }

        internal void UpdateResult(int selectedIndex)
        {

            var match = DataFactory.MatchDataForSelectedCountry.ToList().First(
                m => m.HomeTeam.ToString() == Opponents.ElementAt(selectedIndex) || m.AwayTeam.ToString() == Opponents.ElementAt(selectedIndex));
            if (match != null)
            {
                if (match.HomeTeam.ToString().Equals(Countries.ElementAt(SelectedIndexCountry)))
                {
                    Result = match.HomeTeam.Goals + ":" + match.AwayTeam.Goals;
                } else
                {
                    Result =  match.AwayTeam.Goals + ":" + match.HomeTeam.Goals;
                }
            }

        }
    }

}
