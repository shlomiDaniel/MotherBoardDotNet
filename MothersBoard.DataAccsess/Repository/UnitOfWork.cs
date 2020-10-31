using MothersBoard.DataAccess.Data;
using MothersBoard.DataAccsess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MothersBoard.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
        }
      public  IProductRepository Product { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            this._db.SaveChanges();
        }
    }
}
