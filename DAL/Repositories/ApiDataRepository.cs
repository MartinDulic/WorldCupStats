using DAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ApiDataRepository : IDataRepository
    {
        private const string URLBASE = "https://worldcup-vua.nullbit.hr";
        private const string MEN_RESULTS = URLBASE + "/men/teams/results";
        private const string MEN_MATCHES = URLBASE + "/men/matches";
        private const string MEN_MATCHES_COUNTRY = URLBASE + "/men/matches/country?fifa_code=";
        private const string WOMEN_RESULTS = URLBASE + "/women/teams/results";
        private const string WOMEN_MATCHES = URLBASE + "/women/matches";
        private const string WOMEN_MATCHES_COUNTRY = URLBASE + "/women/matches/country?fifa_code=";
        public ISet<MatchData> GetAllManMatchData() => Utils.GetJsonObjectFromUrl<HashSet<MatchData>>(MEN_MATCHES);
        public ISet<CountryTeam> GetAllMenCountryTeamData() => Utils.GetJsonObjectFromUrl<HashSet<CountryTeam>>(MEN_RESULTS);
        public ISet<MatchData> GetManMatchDataByCountry(string countryCode) => Utils.GetJsonObjectFromUrl<HashSet<MatchData>>(MEN_MATCHES_COUNTRY + countryCode);
        public ISet<MatchData> GetAllWomanMatchData() => Utils.GetJsonObjectFromUrl<HashSet<MatchData>>(WOMEN_MATCHES);
        public ISet<CountryTeam> GetAllWomenCountryTeamData() => Utils.GetJsonObjectFromUrl<HashSet<CountryTeam>>(WOMEN_RESULTS);
        public ISet<MatchData> GetWomanMatchDataByCountry(string countryCode) => Utils.GetJsonObjectFromUrl<HashSet<MatchData>>(WOMEN_MATCHES_COUNTRY + countryCode);

    }
}
