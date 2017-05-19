﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class MapRepository
    {
        private readonly string _connectionString;

        public MapRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<MapModel> GetMapModels()
        {
            IEnumerable<MapModel> results = null;
            using (IDbConnection db = new SqlConnection(_connectionString))

            {

                string sqlQuery = @"SELECT * FROM tbl_route";

                results = db.Query<MapModel>(sqlQuery).ToList();



            }
            return results;
        }
    }
}