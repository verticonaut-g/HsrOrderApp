using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.BL.DomainModel.SpecialCases;
using HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Data;
using HsrOrderApp.DAL.Data.Repositories;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories
{
    public class SupplierRepository : RepositoryBase, ISupplierRepository
    {
        public SupplierRepository(HsrOrderAppEntities db)
            : base(db)
        {
        }

        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public SupplierRepository() : base()
        {
        }

        public void DeleteSupplier(int id)
        {
            Supplier cu = db.Suppliers.First(c => c.SupplierId == id);
            if (cu != null)
            {
                db.DeleteObject(cu);
                db.SaveChanges();
            }
        }

        public IQueryable<BL.DomainModel.Supplier> GetAll()
        {
            var suppliers = from c in this.db.Suppliers.AsEnumerable()
                           select SupplierAdapter.AdaptSupplier(c);

            return suppliers.AsQueryable();
        }

        public BL.DomainModel.Supplier GetById(int id)
        {
            try
            {
                var suppliers = from c in this.db.Suppliers.AsEnumerable()
                               where c.SupplierId == id
                               select SupplierAdapter.AdaptSupplier(c);

                return suppliers.First();
            }
            catch (ArgumentNullException ex)
            {
                if (ExceptionPolicy.HandleException(ex, "DA Policy")) throw;
                return new MissingSupplier();
            }
        }

        public int SaveSupplier(BL.DomainModel.Supplier supplier)
        {
            try
            {
                string setname = "Supplier";
                Supplier dbSupplier;

                bool isNew = false;
                if (supplier.SupplierId== default(int) || supplier.SupplierId <= 0)
                {
                    isNew = true;
                    dbSupplier = new Supplier();
                }
                else
                {
                    dbSupplier = new Supplier() { SupplierId = supplier.SupplierId, Version = supplier.Version.ToTimestamp() };
                    dbSupplier.EntityKey = db.CreateEntityKey(setname, dbSupplier);
                    db.AttachTo(setname, dbSupplier);
                }
                dbSupplier.Name = supplier.Name;
                dbSupplier.AccountNumber = supplier.AccountNumber;
                dbSupplier.CreditRating = supplier.CreditRating;
                dbSupplier.PreferredSupplierFlag = supplier.PreferredSupplierFlag;
                dbSupplier.ActiveFlag = supplier.ActiveFlag;
                dbSupplier.PurchasingWebServiceURL = supplier.PurchasingWebServiceURL;

                if (isNew)
                {
                    db.AddToSuppliers(dbSupplier);
                }
                db.SaveChanges();
                supplier.SupplierId = dbSupplier.SupplierId;
                return dbSupplier.SupplierId;
            }
            catch (OptimisticConcurrencyException ex)
            {
                if (ExceptionPolicy.HandleException(ex, "DA Policy")) throw;
                return default(int);
            }
        }
    }
}
