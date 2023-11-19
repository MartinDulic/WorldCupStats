using DAL.Model;
using DAL.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Settings
{
    public class AppSettings
    {
        
        public RepoType RepositoryType { get; set; }
        public Language Language { get; set; }
        public SelectedChampionship SelectedChampionship { get; set; }
        public Resolution Resolution { get; set; }
        

    }
}
