using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.BL.DTOAdapters.Helper;
using HsrOrderApp.BL.BusinessComponents;
using HsrOrderApp.SharedLibraries.SharedEnums;
using HsrOrderApp.BL.DomainModel.HelperObjects;
using HsrOrderApp.SharedLibraries.DTO.Base;
using HsrOrderApp.BL.DtoAdapters;

namespace HsrOrderApp.BL.DTOAdapters
{
    public class SupplierAdapter
    {
        #region SupplierToDTO

        public static IList<SupplierListDTO> SuppliersToDtos(IQueryable<Supplier> suppliers)
        {
            IQueryable<SupplierListDTO> supplierListDTOs = from c in suppliers
                                                           select new SupplierListDTO()
                                                           {
                                                               Id = c.SupplierId,
                                                               Name = c.Name,
                                                               AccountNumber = c.AccountNumber,
                                                               CreditRating = (CreditRating)c.CreditRating,
                                                               PreferredSupplierFlag = c.PreferredSupplierFlag,
                                                               ActiveFlag = c.ActiveFlag
                                                           };
            return supplierListDTOs.ToList();
        }


        public static SupplierDTO SupplierToDto(Supplier p)
        {
            SupplierDTO dto = new SupplierDTO()
            {
                Id = p.SupplierId,
                Name = p.Name,
                AccountNumber = p.AccountNumber,
                CreditRating = (CreditRating)p.CreditRating,
                PreferredSupplierFlag = p.PreferredSupplierFlag,
                ActiveFlag = p.ActiveFlag,
                PurchasingWebServiceURL = p.PurchasingWebServiceURL,
                Version = p.Version,
                SupplierProduct = SupplierProductToDtos(p.SupplierProduct)
            };

            return dto;
        }

        public static IList<SupplierProductDTO> SupplierProductToDtos(IQueryable<SupplierProduct> SuplierProducts)
        {
            IQueryable<SupplierProductDTO> supplierProducDTOs = from c in SuplierProducts
                                                                select SupplierProductToDto(c);
            return supplierProducDTOs.ToList();
        }

        public static SupplierProductDTO SupplierProductToDto(SupplierProduct c)
        {
            SupplierProductDTO dto = new SupplierProductDTO()
            {
                Id = c.ConditionId,
                AverageLeadTime = c.AverageLeadTimeInDays,
                LastReceiptCost = c.LastReceiptCost,
                LastReceiptDate = c.LastReceiptDate,
                MaxOrderQuantity = c.MaxOrderQuantity,
                MinOrderQuantity = c.MinOrderQuantity,
                StandardPrice = c.StandardPrice,
                ProductId = c.Product.ProductId,
                ProductName = c.Product.Name,
                Version = c.Version
            };
            return dto;
        }

        #endregion

        #region DTOToSupplier

        public static Supplier DtoToSupplier(SupplierDTO dto)
        {
            Supplier supplier = new Supplier()
            {
                SupplierId = dto.Id,
                Name = dto.Name,
                AccountNumber = dto.AccountNumber,
                CreditRating = (int)dto.CreditRating,
                PreferredSupplierFlag = dto.PreferredSupplierFlag,
                ActiveFlag = dto.ActiveFlag,
                PurchasingWebServiceURL = dto.PurchasingWebServiceURL,
                Version = dto.Version
            };
            ValidationHelper.Validate(supplier);
            return supplier;
        }

        
        public static IEnumerable<ChangeItem> GetChangeItems(SupplierDTO dto, Supplier supplier)
        {
            IEnumerable<ChangeItem> changeItems = from c in dto.Changes
                                                  select
                                                      new ChangeItem(c.ChangeType,
                                                                     DtoChildToBusinessChild(c.Object,
                                                                                             supplier));
            return changeItems;
        }

        private static DomainObject DtoChildToBusinessChild(DTOVersionObject dto, Supplier supplier)
        {
            if (dto is AddressDTO)
            {
                return AddressAdapter.DtoToAddress((AddressDTO)dto);
            }
            else if (dto is SupplierProductDTO)
            {
                return DtoToSupplierProduct((SupplierProductDTO)dto, supplier);
            }
            return null;
        }

        public static SupplierProduct DtoToSupplierProduct(SupplierProductDTO dto, Supplier supplier)
        {
            SupplierProduct supplierProduct = new SupplierProduct
            {
                ConditionId = dto.Id,
                AverageLeadTimeInDays = dto.AverageLeadTime,
                LastReceiptCost = dto.LastReceiptCost,
                LastReceiptDate = dto.LastReceiptDate,
                MaxOrderQuantity = dto.MaxOrderQuantity,
                MinOrderQuantity = dto.MinOrderQuantity,
                StandardPrice = dto.StandardPrice,
                Supplier = supplier,
                Version = dto.Version,
                Product = new Product { ProductId = dto.ProductId }
            };

            ValidationHelper.Validate(supplierProduct);
            return supplierProduct;
        }

        #endregion

    }
}
