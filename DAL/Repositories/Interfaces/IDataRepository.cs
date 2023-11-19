using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IDataRepository
    {
        public ISet<MatchData> GetAllManMatchData();
        public ISet<MatchData> GetManMatchDataByCountry(string countryCode);
        public ISet<CountryTeam> GetAllMenCountryTeamData();
        public ISet<MatchData> GetAllWomanMatchData();
        public ISet<MatchData> GetWomanMatchDataByCountry(string countryCode);
        public ISet<CountryTeam> GetAllWomenCountryTeamData();

    }
}
