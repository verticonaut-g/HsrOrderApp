using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel;

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

            supplier.SupplierProduct = AdaptSupplierProducs(c.SupplierProducts, supplier);
            return supplier;
        }

        internal static IQueryable<BL.DomainModel.SupplierProduct> AdaptSupplierProducs(EntityCollection<SupplierProduct> supplierProductCollection, BL.DomainModel.Supplier supplier)
        {
            if (supplierProductCollection.IsLoaded == false)
                return null;

            var conditions = from c in supplierProductCollection.AsEnumerable()
                             select AdaptSupplierProduc(c, supplier);
            return conditions.AsQueryable();
        }

        internal static BL.DomainModel.SupplierProduct AdaptSupplierProduc(SupplierProduct c, BL.DomainModel.Supplier s)
        {
            return new BL.DomainModel.SupplierProduct()
            {
                ConditionId = c.SupplierProductId,
                AverageLeadTimeInDays = c.AverageLeadTime,
                LastReceiptCost = c.LastReceiptCode,
                LastReceiptDate = c.LastReceiptDate,
                MaxOrderQuantity = c.MaxOrderQty.HasValue ? c.MaxOrderQty.Value : 0,
                MinOrderQuantity = c.MinOrderQty ,
                StandardPrice = c.StandardPrice,
                Supplier = s,
                Product = ProductAdapter.AdaptProduct(c.ProductReference),
                Version = c.Version.ToUlong(),
            };
        }
    }
}
