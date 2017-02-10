#region
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using HsrOrderApp.SharedLibraries.DTO.Base;
using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.SharedEnums;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion


namespace HsrOrderApp.SharedLibraries.DTO
{
    [DataContract]
    public class SupplierDTO : DTOParentObject
    {
        private string _name;
        private string _accountNumber;
        private int _creditRating;
        private bool _preferredSupplierFlag;
        private bool _activeFlag;
        private string _purchasingWebServiceURL;
        private IList<SupplierProductDTO> _supplierProducts;

        public SupplierDTO()
        {
            this.Name = string.Empty;
            this.AccountNumber = string.Empty;
            this.CreditRating = default(int);
            this.PreferredSupplierFlag = true;
            this.ActiveFlag = true;
            this.PurchasingWebServiceURL = string.Empty;
            this.SupplierProducts = new List<SupplierProductDTO>();
        }

        [DataMember]
        [StringLengthValidator(1, 150)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    this._name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 50)]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value != _accountNumber)
                {
                    this._accountNumber = value;
                    OnPropertyChanged(() => AccountNumber);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 256)]
        public string PurchasingWebServiceURL
        {
            get { return _purchasingWebServiceURL; }
            set
            {
                if (value != _purchasingWebServiceURL)
                {
                    this._purchasingWebServiceURL = value;
                    OnPropertyChanged(() => PurchasingWebServiceURL);
                }
            }
        }

        [DataMember]
        public bool PreferredSupplierFlag
        {
            get { return _preferredSupplierFlag; }
            set
            {
                if (value != _preferredSupplierFlag)
                {
                    this._preferredSupplierFlag = value;
                    OnPropertyChanged(() => PreferredSupplierFlag);
                }
            }
        }

        [DataMember]
        public bool ActiveFlag
        {
            get { return _activeFlag; }
            set
            {
                if (value != _activeFlag)
                {
                    this._activeFlag = value;
                    OnPropertyChanged(() => ActiveFlag);
                }
            }
        }

        [DataMember]
        public CreditRating CreditRating
        {
            get { return (CreditRating)_creditRating; }
            set { _creditRating = (int)value; }
        }

        [DataMember]
        [ObjectCollectionValidator(typeof(SupplierProductDTO))]
        public IList<SupplierProductDTO> SupplierProducts
        {
            get { return _supplierProducts; }
            set
            {
                if (value != _supplierProducts)
                {
                    this._supplierProducts = value;
                    OnPropertyChanged(() => SupplierProducts);
                }
            }
        }
    }
}
