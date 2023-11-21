using System.Net;
using DAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using System.Configuration;
using System.ComponentModel;
using DAL.Model.Enums;
using System.Reflection.Metadata;
using System.Drawing.Printing;

internal class Program
{
    private static void Main()
    {

        var r = RepositoryFactory.GetDataRepository();
        var data = r.GetAllManMatchData();
    }

}