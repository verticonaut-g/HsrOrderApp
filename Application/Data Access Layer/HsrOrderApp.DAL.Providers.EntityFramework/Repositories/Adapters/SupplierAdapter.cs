using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters
{
    internal static class SupplierAdapter
    {

        internal static BL.DomainModel.Supplier AdaptSupplier(EntityReference<Supplier> p)
        {
            if (p.Value == null)
                return null;
            return AdaptSupplier(p.Value);
        }

        internal static BL.DomainModel.Supplier AdaptSupplier(Supplier c)
        {
            BL.DomainModel.Supplier supplier = new BL.DomainModel.Supplier()
            {
                SupplierId = c.SupplierId,
                Name = c.Name,
                AccountNumber = c.AccountNumber,
                CreditRating = c.CreditRating,
                PreferredSupplierFlag = c.PreferredSupplierFlag,
                ActiveFlag = c.ActiveFlag,
                PurchasingWebServiceURL = c.PurchasingWebServiceURL,
                Version = c.Version.ToUlong(),
            };
            return supplier;
        }
    }
}
