using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HsrOrderApp.SharedLibraries.DTO.Base;
using HsrOrderApp.SharedLibraries.SharedEnums;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace HsrOrderApp.SharedLibraries.DTO
{
    class SupplierProductDTO : DTOParentObject
    {
        private int _averageLeadTime;
        private decimal _standardPrice;
        private decimal _lastReceiptCost;
        private DateTime _lastReceiptDate;
        private int _minOrderQty;
        private int _maxOrderQty;

        public SupplierProductDTO()
        {
            //this.Name = string.Empty;
            //this.AccountNumber = string.Empty;
            //this.CreditRating = default(int);
            //this.PreferredSupplierFlag = true;
            //this.ActiveFlag = true;
            //this.PurchasingWebServiceURL = string.Empty;

    }

        [DataMember]
        public int AverageLeadTime
        {
            get { return _averageLeadTime; }
            set
            {
                if (value != _averageLeadTime)
                {
                    this._averageLeadTime = value;
                    OnPropertyChanged(() => AverageLeadTime);
                }
            }
        }

        [DataMember]
        public decimal StandardPrice
        {
            get { return _standardPrice; }
            set
            {
                if (value != _standardPrice)
                {
                    this._standardPrice = value;
                    OnPropertyChanged(() => StandardPrice);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 256)]
        public decimal LastReceiptCost
        {
            get { return _lastReceiptCost; }
            set
            {
                if (value != _lastReceiptCost)
                {
                    this._lastReceiptCost = value;
                    OnPropertyChanged(() => LastReceiptCost);
                }
            }
        }

        [DataMember]
        public DateTime LastReceiptDate
        {
            get { return _lastReceiptDate; }
            set
            {
                if (value != _lastReceiptDate)
                {
                    this._lastReceiptDate = value;
                    OnPropertyChanged(() => LastReceiptDate);
                }
            }
        }

        [DataMember]
        public int MinOrderQty
        {
            get { return _minOrderQty; }
            set
            {
                if (value != _minOrderQty)
                {
                    this._minOrderQty = value;
                    OnPropertyChanged(() => MinOrderQty);
                }
            }
        }

        [DataMember]
        public int MaxOrderQty
        {
            get { return _maxOrderQty; }
            set
            {
                if (value != _maxOrderQty)
                {
                    this._maxOrderQty = value;
                    OnPropertyChanged(() => MaxOrderQty);
                }
            }
        }
    }
}
