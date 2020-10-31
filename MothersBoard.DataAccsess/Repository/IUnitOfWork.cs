using MothersBoard.DataAccsess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MothersBoard.DataAccess.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Product { get; }
        ISP_Call SP_Call { get; }
    }
}
