using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    [DataContract]
    [KnownType(typeof(SupplierDTO))]
    public class GetSupplierResponse
    {
        public GetSupplierResponse()
        {
            this.Supplier = new SupplierDTO();
        }

        [DataMember]
        [ObjectValidator]
        public SupplierDTO Supplier { get; set; }
    }
}
