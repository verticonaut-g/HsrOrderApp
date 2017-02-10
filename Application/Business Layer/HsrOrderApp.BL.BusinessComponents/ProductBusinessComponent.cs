#region

using System.Linq;
using System.Transactions;
using HsrOrderApp.BL.BusinessComponents.DependencyInjection;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Data.Repositories;
using HsrOrderApp.SharedLibraries.SharedEnums;
using System.Collections.Generic;

#endregion

namespace HsrOrderApp.BL.BusinessComponents
{
    public class ProductBusinessComponent
    {
        private IProductRepository rep;

        public ProductBusinessComponent()
        {
        }

        public ProductBusinessComponent(IProductRepository unitOfWork)
        {
            this.rep = unitOfWork;
        }

        #region CRUD Operations

        public Product GetProductById(int productId)
        {
            Product product = rep.GetById(productId);
            return product;
        }


        public IQueryable<Product> GetProductsByCriteria(ProductSearchType searchType, string category, string productName)
        {
            IQueryable<Product> products = null;

            switch (searchType)
            {
                case ProductSearchType.None:
                    products = rep.GetAll();
                    break;
                case ProductSearchType.ByCategory:
                    products = rep.GetAll().Where(cu => cu.Category == category);
                    break;
                case ProductSearchType.ByName:
                    products = rep.GetAll().Where(cu => cu.Name == productName);
                    break;
            }

            return products;
        }

        public int StoreProduct(Product product)
        {
            int productId = default(int);
            using (TransactionScope transaction = new TransactionScope())
            {
                productId = rep.SaveProduct(product);
                transaction.Complete();
            }

            return productId;
        }

        public void DeleteProduct(int productId)
        {
            rep.DeleteProduct(productId);
        }

        #endregion

        public IProductRepository Repository
        {
            get { return this.rep; }
            set { this.rep = value; }
        }

        public void GetEstimatedDeliveryTime(int productId, out int unitsAvailable, out int estimatedDeliveryTimeInDays)
        {
            OrderBusinessComponent orderBC = DependencyInjectionHelper.GetOrderBusinessComponent();
            SupplierBusinessComponent supplierBC = DependencyInjectionHelper.GetSupplierBusinessComponent();
            Product product = rep.GetById(productId);

            int unitsOrdered = orderBC.GetAllOrderDetails()
                .Where(od => od.Product.ProductId == product.ProductId)
                .Sum(od => od.QuantityInUnits);

            unitsAvailable = product.UnitsOnStock - unitsOrdered;
            if ((unitsAvailable) < 0) 
                unitsAvailable = 0;

            estimatedDeliveryTimeInDays = -1;
            IQueryable<Supplier> defaultSuppliers = supplierBC.GetSuppliersByCriteria(SupplierSearchType.None, null, 0);
            foreach (Supplier supplier in defaultSuppliers)
            {
                if (supplier.ActiveFlag && supplier.PreferredSupplierFlag)
                {
                    Supplier supplierWithCondition = supplierBC.GetSupplierById(supplier.SupplierId);
                    SupplierProduct supProd = supplierWithCondition.SupplierProduct.FirstOrDefault(c => c.Product.ProductId == productId);
                    if (supProd != null)
                    {
                        estimatedDeliveryTimeInDays = supProd.AverageLeadTimeInDays;
                        return;
                    }
                }
            }
        }
    }
}