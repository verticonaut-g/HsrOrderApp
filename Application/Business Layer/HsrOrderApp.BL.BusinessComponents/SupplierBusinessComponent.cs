using HsrOrderApp.BL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using HsrOrderApp.DAL.Data.Repositories;
using HsrOrderApp.SharedLibraries.SharedEnums;

namespace HsrOrderApp.BL.BusinessComponents
{
    public class SupplierBusinessComponent
    {
        private ISupplierRepository rep;

        public SupplierBusinessComponent()
        {
        }

        public SupplierBusinessComponent(ISupplierRepository unitOfWork)
        {
            this.rep = unitOfWork;
        }


        public ISupplierRepository Repository
        {
            get { return this.rep; }
            set { this.rep = value; }
        }

        public Supplier GetCustomerById(int supplierId)
        {
            Supplier supplier = rep.GetById(supplierId);
            return supplier;
        }


        public int StoreSupplier(Supplier supplier /*, IEnumerable<ChangeItem> changeItems*/)
        {
            int supplierId = default(int);
            using (TransactionScope transaction = new TransactionScope())
            {
                supplierId = rep.SaveSupplier(supplier);
             
                transaction.Complete();
            }

            return supplierId;
        }
    }
}
