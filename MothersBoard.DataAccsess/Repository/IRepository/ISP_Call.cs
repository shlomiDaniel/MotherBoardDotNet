using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MothersBoard.DataAccsess.Repository.IRepository
{
    public interface ISP_Call: IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters parameters = null);
        void Execute(string procedureName, DynamicParameters parameters = null);
        T OneRecord<T>(string procedureName, DynamicParameters parameters = null);
        IEnumerable<T> List<T>(string procedureName, DynamicParameters parameters = null);
    }
}
