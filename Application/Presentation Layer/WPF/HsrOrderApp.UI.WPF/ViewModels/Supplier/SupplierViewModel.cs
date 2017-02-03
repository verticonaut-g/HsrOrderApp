using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class SupplierViewModel : ListViewModelBase<SupplierListDTO>
    {
        protected override void LoadData()
        {
            this.DisplayName = Strings.SupplierViewModel_DisplayName;
            IList<SupplierListDTO> suppliers = Service.GetAllSuppliers();
            foreach (SupplierListDTO supplier in suppliers)
                Items.Add(supplier);
        }

        protected override void New()
        {
            //CustomerDTO newCustomer = new CustomerDTO();
            //CustomerDetailViewModel detailModelView = new CustomerDetailViewModel(newCustomer, true);
            //if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            //{
            //    Load();
            //    SelectedItem = Items.SingleOrDefault(dto => dto.Id == newCustomer.Id);
            //}
        }

        protected override void Delete()
        {
            Service.DeleteSupplier(SelectedItem.Id);
            Load();
        }

        protected override void Edit()
        {
            //CustomerDTO selectedDto = Service.GetCustomerById(SelectedItem.Id);
            //CustomerDetailViewModel detailModelView = new CustomerDetailViewModel(selectedDto, false);
            //if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            //{
            //    Load();
            //    SelectedItem = Items.SingleOrDefault(dto => dto.Id == selectedDto.Id);
            //}
        }
    }
}
