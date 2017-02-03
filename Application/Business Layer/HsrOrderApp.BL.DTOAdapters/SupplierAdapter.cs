using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.BL.DTOAdapters.Helper;
using HsrOrderApp.BL.BusinessComponents;
using HsrOrderApp.SharedLibraries.SharedEnums;

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
                Version = p.Version
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

        #endregion

    }
}
