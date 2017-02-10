using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class ConditionDetailViewModel : DetailViewModelBase<SupplierProductDTO>
    {
        private string _estimatedDeliveryTime;
        private IList<ProductDTO> _products;

        public ConditionDetailViewModel(SupplierProductDTO orderDetail, bool isNew)
            : base(orderDetail, isNew)
        {
            this.DisplayName = Strings.ConditionDetailViewModel_DisplayName;
        }

        public int ProductId
        {
            get { return this.Model.ProductId; }
            set
            {
                if (this.Model.ProductId != value)
                {
                    SendPropertyChanging("ProductId");
                    ProductDTO pdto = Products.First(p => p.Id == value);
                    this.Model.ProductId = value;
                    this.Model.ProductName = pdto.Name;
                    SendPropertyChanged("ProductId");
                }
            }
        }

        // TODO: Mit anderer statischer Ressource lösen?
        public IList<ProductDTO> Products
        {
            get
            {
                if (_products == null)
                    _products = Service.GetAllProducts();
                return _products;
            }
        }
    }
}
