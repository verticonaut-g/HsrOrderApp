using System;
using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.BL.DomainModel;

namespace HsrOrderApp.DAL.Data.Repositories
{ 
    public interface ISupplierRepository
    {
        IQueryable<Supplier> GetAll();
        Supplier GetById(int id);

        int SaveSupplier(Supplier product);

        void DeleteSupplier(int id);
    }
}
