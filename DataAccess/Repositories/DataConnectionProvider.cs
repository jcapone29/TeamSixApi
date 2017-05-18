using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;

namespace DataAccess.Repositories
{
  public class DataConnectionProvider
    {
        public static IMongoClient GetMongoClient()
        {
            return new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ToString());
        }
    }
}
