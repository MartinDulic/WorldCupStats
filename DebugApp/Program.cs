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

internal class Program
{
    private static void Main()
    {

		try
		{
            DataFactory.FavouriteSettings.FavouritePlayers.ToList().ForEach(player =>
            {
                Console.WriteLine("player:" + player.ToString());
            });

        }
        catch (Exception)
		{

            throw;
			
		}

    }
}