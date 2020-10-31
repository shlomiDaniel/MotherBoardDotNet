using MothersBoard.DataAccsess.Migrations;
using MothersBoard.Models;
using MothersBoard.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MothersBoard.DataAccess.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product p);
    }
}
