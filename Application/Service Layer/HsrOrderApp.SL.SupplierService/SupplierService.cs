using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HsrOrderApp.SharedLibraries.ServiceInterfaces;
using System.ServiceModel.Activation;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses;
using HsrOrderApp.BL.BusinessComponents;
using System.Web;
using HsrOrderApp.BL.BusinessComponents.DependencyInjection;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.BL.DtoAdapters;
using HsrOrderApp.SL.AdminService;
using System.Threading;
using HsrOrderApp.BL.DTOAdapters;

namespace SL.SupplierService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    class SupplierService
    {
        public SupplierService()
        {
            Thread.CurrentPrincipal = HttpContext.Current.User;
        }

        public GetSupplierResponse GetSupplier()
        {
            throw new NotImplementedException();
        }

        public StoreSupplierResponse StoreSupplier(StoreSupplierRequest request)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new FaultException<NotAuthenticatedFault>(new NotAuthenticatedFault());
            StoreSupplierResponse response = new StoreSupplierResponse();
            SupplierBusinessComponent bc = DependencyInjectionHelper.GetSupplierBusinessComponent();
            Supplier supplier = SupplierAdapter.DtoToSupplier(request.Supplier);
            response.SupplierId = bc.StoreSupplier(supplier);

            return response;
        }
    }
}
