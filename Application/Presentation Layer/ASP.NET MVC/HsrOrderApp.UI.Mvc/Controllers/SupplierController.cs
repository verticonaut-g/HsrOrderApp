using HsrOrderApp.UI.Mvc.Controllers.Base;
using HsrOrderApp.UI.Mvc.Helpers;
using HsrOrderApp.UI.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.Mvc.Resources;

namespace HsrOrderApp.UI.Mvc.Controllers
{
    [CustomAuthorize(RequiredPermissions = new UserPermission[] { UserPermission.ADMIN, UserPermission.STAFF })]
    public class SupplierController : HsrOrderAppController
    {
        // GET: Supplier
        public ActionResult Index()
        {
            var vm = GetViewModelFromTempData<SupplierListViewModel>() ?? new SupplierListViewModel();
            vm.DisplayName = Strings.SupplierViewModel_DisplayName;
            vm.Items = Service.GetAllSuppliers().ToList();
            vm.SelectedItem = vm.Items.FirstOrDefault();

            // Finish Action
            StoreViewModelToTempData(vm);
            return View(vm);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            SupplierDTO item = Service.GetSupplierById(id);

            return DisplayDetails(item);
        }
        
        // GET: Customer/Create
        public ActionResult Create()
        {
            SupplierDTO item = new SupplierDTO();
            return DisplayDetails(item);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(SupplierViewModel vmChanged, string redirectButton)
        {
            var vm = GetViewModelFromTempData<SupplierViewModel>() ?? new SupplierViewModel(new SupplierDTO(), null, true);
            vm.DisplayName = Strings.SupplierViewModel_DisplayName;
            vm.ApplyFormAttributes(vmChanged.Model);

            return StoreEntity(vm, redirectButton);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            var vm = GetViewModelFromTempData<SupplierViewModel>();
            bool needsRefresh = NeedsRefresh(vm, id);

            if (needsRefresh)
            {
                RemoveViewModelFromTempData<SupplierViewModel>();
                RemoveViewModelFromTempData<SupplierProductViewModel>(typeof(SupplierProductController).FullName);

                SupplierDTO item = Service.GetSupplierById(id);
                return DisplayDetails(item);
            }

            return DisplayDetails(vm.Model);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(SupplierViewModel vmChanged, string redirectButton)
        {
            var vm = GetViewModelFromTempData<SupplierViewModel>();

            vm.ApplyFormAttributes(vmChanged.Model);

            return StoreEntity(vm, redirectButton);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Service.DeleteSupplier(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }
            return RedirectToAction("Index");
        }

        protected ActionResult DisplayDetails(SupplierDTO item)
        {
            var vm = GetViewModelFromTempData<SupplierViewModel>() ?? new SupplierViewModel(item, null, false);
            vm.DisplayName = "Supplier";
            vm.Model = item;
            vm.IsNew = item.Id <= 0;

            RefreshSupplierProductViewModel(vm, item);

            // Marks child entity changes in SupplierViewModel
            MarkSupplierProductChanges(vm);

            // Finish Action
            StoreViewModelToTempData(vm);
            //StoreViewModelToTempData(vm.SupplierProduct, typeof(AddressController).FullName);
            return View(vm);

        }

        private void RefreshSupplierProductViewModel(SupplierViewModel vm, SupplierDTO item)
        {
            var vmAddress = GetViewModelFromTempData<SupplierProductViewModel>(typeof(AddressController).FullName);

            if (vmAddress != null && vmAddress.LatestSupplierProductAction != ControllerAction.None)
            {
                vm.SupplierProducts = vmAddress;
            }
            else
            {
                vm.SupplierProducts = new SupplierProductViewModel(item.SupplierProducts.ToList());
            }

            vm.SupplierProducts.IsReadOnly = CurrentActionName == "Details";
            vm.SupplierProducts.ReturnController = CurrentControllerName;
            vm.SupplierProducts.ReturnAction = CurrentActionName;
            vm.SupplierProducts.ReturnId = CurrentParameterId;
        }

        private void MarkSupplierProductChanges(SupplierViewModel vm)
        {
            switch (vm.SupplierProducts.LatestSupplierProductAction)
            {
                case ControllerAction.Create:
                    foreach (var ins in vm.SupplierProducts.Items.Where(i => i.Id <= 0))
                        vm.Model.MarkChildForInsertion(ins);
                    break;
                case ControllerAction.Edit:
                    if (!string.IsNullOrEmpty(ReferrerParameterId))
                        vm.Model.MarkChildForUpdate(vm.SupplierProducts.SelectedItem);
                    break;
                case ControllerAction.Delete:
                    foreach (var del in vm.SupplierProducts.ItemsToDelete)
                        vm.Model.MarkChildForDeletion(del);
                    break;
            }
        }

        protected ActionResult StoreEntity(SupplierViewModel vm, string redirectButton)
        {
            bool persist = string.IsNullOrEmpty(redirectButton);
            try
            {
                if (ModelState.IsValid && persist)
                {
                    Service.StoreSupplier(vm.Model);

                    // Finish Action and go back to Index
                    RemoveViewModelFromTempData<SupplierViewModel>();
                    //RemoveViewModelFromTempData<AddressViewModel>(typeof(SupplierProductController).FullName);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }

            // Finish Action without saving
            StoreViewModelToTempData(vm);
            //StoreViewModelToTempData(vm.Addresses, typeof(SupplierProductController).FullName);

            if (persist)
                return View(vm);
            else
                return Redirect(redirectButton);
        }

        private bool NeedsRefresh(SupplierViewModel vm, int id)
        {
            // True when Id changed
            if (vm?.Model?.Id != id) return true;

            // True when coming from other Controller
            if (ReferrerControllerName == "Supplier" && ReferrerActionName != "Index") return false;
            if (ReferrerControllerName == "SupplierProduct") return false;
            return true;
        }

    }
}

