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

internal class Program
{
    private static void Main()
    {

		try
		{

			IDataRepository repository = RepositoryFactory.GetDataRepository();
            foreach(var item in repository.GetAllManMatchData())
			{
				Console.WriteLine(item.ToString());
			}

        }
        catch (Exception e)
		{

			Console.WriteLine(e.Message);
			
		}

    }
}