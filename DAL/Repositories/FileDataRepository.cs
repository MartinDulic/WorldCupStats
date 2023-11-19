using DAL.Model;
using DAL.Repositories.Interfaces;
using DAL.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FileDataRepository : IDataRepository
    {
        private const string FOLDER_PATH = @"..\..\..\..\DAL\Resources\data";
        private const string MEN_PATH = @"\men";
        private const string WOMEN_PATH = @"\women";
        private const string MEN_RESULTS = FOLDER_PATH + MEN_PATH + @"\matches.json";
        private const string MEN_TEAMS = FOLDER_PATH + MEN_PATH + @"\results.json";
        private const string WOMEN_RESULTS = FOLDER_PATH + WOMEN_PATH + @"\matches.json";
        private const string WOMEN_TEAMS = FOLDER_PATH + WOMEN_PATH + @"\results.json";


        public ISet<MatchData> GetAllManMatchData() => Utils.ReadJsonFile<ISet<MatchData>>(MEN_RESULTS);

        public ISet<CountryTeam> GetAllMenCountryTeamData() => Utils.ReadJsonFile<ISet<CountryTeam>>(MEN_TEAMS);

        public ISet<MatchData> GetAllWomanMatchData() => Utils.ReadJsonFile<ISet<MatchData>>(WOMEN_RESULTS);

        public ISet<CountryTeam> GetAllWomenCountryTeamData() => Utils.ReadJsonFile<ISet<CountryTeam>>(WOMEN_TEAMS);


        public ISet<MatchData> GetManMatchDataByCountry(string countryCode)
        {
            var data =GetAllManMatchData();
            ISet<MatchData> countryData = new HashSet<MatchData>();

            foreach (MatchData matchData in data)
            {

                if (matchData.HomeTeam.Code == countryCode || matchData.AwayTeam.Code == countryCode)
                {
                
                    countryData.Add(matchData);
                    
                }
            }
            
            return countryData;
        }

        public ISet<MatchData> GetWomanMatchDataByCountry(string countryCode)
        {
            var data = GetAllWomanMatchData();
            ISet<MatchData> countryData = new HashSet<MatchData>();

            foreach (MatchData matchData in data)
            {

                if (matchData.HomeTeam.Code == countryCode || matchData.AwayTeam.Code == countryCode)
                {

                    countryData.Add(matchData);

                }
            }

            return countryData;
        }
    }
}
