using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MothersBoard.DataAccess.Data;
using MothersBoard.DataAccsess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MothersBoard.DataAccess.Repository
{
    class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";
        public SP_Call(ApplicationDbContext db)
        {
            this._db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            this._db.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            };
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            };
        }

        public Tuple<IEnumerable<T1> , IEnumerable<T2>>List<T1,T2>(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var res = SqlMapper.QueryMultiple(sqlCon, procedureName, parameters, commandType: CommandType.StoredProcedure);
                var item1 = res.Read<T1>().ToList();
                var item2 = res.Read<T2>().ToList();
                if(item1!=null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
                
            };
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var value= sqlCon.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            };
        }

        public T Single<T>(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, parameters, commandType: CommandType.StoredProcedure), typeof(T));
            };
        }
    }
}
