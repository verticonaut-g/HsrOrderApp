using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.SharedLibraries.DTO.Base;
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace HsrOrderApp.SharedLibraries.DTO
{
    public class SupplierListDTO : DTOBase
    {

        private string _name;
        private string _accountNumber;
        private int _creatingRating;
        private bool _preferredSupplierFlag;
        private bool _activeFlag;
        private string _purchasingWebServiceURL;

        public SupplierListDTO()
        {
            this.Name = string.Empty;
            this.AccountNumber = string.Empty;
            this.CreatingRating = default(int);
            this.PreferredSupplierFlag = true;
            this.ActiveFlag = true;
            this.PurchasingWebServiceURL = string.Empty;
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
        [RangeValidator(0, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int CreatingRating
        {
            get { return _creatingRating; }
            set
            {
                if (value != _creatingRating)
                {
                    this._creatingRating = value;
                    OnPropertyChanged(() => CreatingRating);
                }
            }
        }

    }
}
