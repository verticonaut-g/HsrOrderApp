using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel.HelperObjects;

namespace HsrOrderApp.BL.DomainModel
{
    public class Supplier : DomainObject
    {

        public Supplier()
        {
            this.SupplierId = default(int);
            this.Name = string.Empty;
            this.AccountNumber = string.Empty;
            this.CreditRating = default(int);
            this.PreferredSupplierFlag = true;
            this.ActiveFlag = true;
            this.PurchasingWebServiceURL = string.Empty;
            this.SupplierProduct = new List<SupplierProduct>().AsQueryable();
        }

        public IQueryable<SupplierProduct> SupplierProduct { get; set; }

        public int SupplierId { get; set; }
        [StringLengthValidator(1, 150)]
        public string Name { get; set; }
        [StringLengthValidator(1, 50)]
        public string AccountNumber { get; set; }

        public int CreditRating { get; set; }
        public bool PreferredSupplierFlag { get; set; }
        public bool ActiveFlag { get; set; }
        [StringLengthValidator(1, 256)]
        public string PurchasingWebServiceURL { get; set; }
    }
}
