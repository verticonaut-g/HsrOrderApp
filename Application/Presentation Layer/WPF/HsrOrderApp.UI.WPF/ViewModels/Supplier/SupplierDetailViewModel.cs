using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses;
using HsrOrderApp.UI.WPF.ViewModels.Base;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.Converters;
using HsrOrderApp.SharedLibraries.SharedEnums;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class SupplierDetailViewModel : DetailViewModelBase<SupplierDTO>
    {
        public SupplierDetailViewModel(SupplierDTO customer, bool isNew) : base(customer, isNew)
        {
            this.DisplayName = Strings.SupplierDetailViewModel_DisplayName;
        }

        protected override void SaveData()
        {
            Service.StoreSupplier(Model);
            SaveCommandExecuted();
        }

        private List<NameValueItem> _creditRatings = null;

        public List<NameValueItem> CreditRatings
        {
            get
            {
                if (_creditRatings == null)
                {
                    _creditRatings = new List<NameValueItem>();
                    _creditRatings.Add(new NameValueItem(CreditRating.Superior, Strings.CreditRating_Superior));
                    _creditRatings.Add(new NameValueItem(CreditRating.Excellent, Strings.CreditRating_Excellent));
                    _creditRatings.Add(new NameValueItem(CreditRating.AboveAverage, Strings.CreditRating_AboveAverage));
                    _creditRatings.Add(new NameValueItem(CreditRating.Average, Strings.CreditRating_Average));
                    _creditRatings.Add(new NameValueItem(CreditRating.BelowAverage, Strings.CreditRating_BelowAverage));
                }
                return _creditRatings;
            }
        }
    }
}
