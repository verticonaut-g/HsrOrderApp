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
            SupplierViewModel vm = new SupplierViewModel(item, false);

            return View(vm);
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
            var vm = GetViewModelFromTempData<SupplierViewModel>() ?? new SupplierViewModel(new SupplierDTO(), true);
            vm.DisplayName = Strings.SupplierViewModel_DisplayName;
            vm.ApplyFormAttributes(vmChanged.Model);

            return StoreEntity(vm, redirectButton);
        }

        protected ActionResult DisplayDetails(SupplierDTO item)
        {
            var vm = GetViewModelFromTempData<SupplierViewModel>() ?? new SupplierViewModel();
            vm.DisplayName = Strings.SupplierViewModel_DisplayName;
            vm.Model = item;

            // Finish Action
            StoreViewModelToTempData(vm);
            return View(vm);
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
                    //RemoveViewModelFromTempData<AddressViewModel>(typeof(AddressController).FullName);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }

            // Finish Action without saving
            StoreViewModelToTempData(vm);
            //StoreViewModelToTempData(vm.Addresses, typeof(AddressController).FullName);

            if (persist)
                return View(vm);
            else
                return Redirect(redirectButton);
        }

    }
}

