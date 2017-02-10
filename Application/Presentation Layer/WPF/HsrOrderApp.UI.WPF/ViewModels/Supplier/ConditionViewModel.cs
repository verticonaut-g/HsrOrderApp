using HsrOrderApp.UI.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.PresentationLogic;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class ConditionViewModel : ListViewModelBase<SupplierProductDTO>
    {
        public ConditionViewModel(SupplierDTO order)
     : base(order)
        {
        }

        protected override void LoadData()
        {
            foreach (SupplierProductDTO orderDetail in ((SupplierDTO)ParentObject).SupplierProduct)
                Items.Add(orderDetail); 
        }

        protected override void New()
        {
            SupplierProductDTO newSupplierCondition = new SupplierProductDTO();
            ConditionDetailViewModel detailModelView = new ConditionDetailViewModel(newSupplierCondition, true);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                ParentObject.MarkChildForInsertion(newSupplierCondition);
                Items.Add(newSupplierCondition);
                SelectedItem = newSupplierCondition;
            }
        }

        protected override void Delete()
        {
            ParentObject.MarkChildForDeletion(SelectedItem);
            Items.Remove(SelectedItem);
        }

        protected override void Edit()
        {
            SupplierProductDTO editCondition = SelectedItem.Clone();
            ConditionDetailViewModel detailModelView = new ConditionDetailViewModel(editCondition, false);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                int index = Items.IndexOf(SelectedItem);
                Items.Remove(SelectedItem);
                Items.Insert(index, editCondition);
                SelectedItem = editCondition;
                ParentObject.MarkChildForUpdate(editCondition);
            }
        }
    }
}
