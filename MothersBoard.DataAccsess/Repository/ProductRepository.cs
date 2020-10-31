using MothersBoard.DataAccess.Data;
using MothersBoard.Models;
using MothersBoard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MothersBoard.DataAccess.Repository
{
    class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            this._db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = this._db.Products.FirstOrDefault(p => p.Id == product.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = product.Name;
                objFromDb.ImgPath = product.ImgPath;
                objFromDb.ImgPathCompanyLogo = product.ImgPathCompanyLogo;
                objFromDb.Description = product.Description;
                objFromDb.Category = product.Category;
                objFromDb.NumberOfStar = product.NumberOfStar;
                this._db.SaveChanges();

            }
           
         
        }
    }
}
