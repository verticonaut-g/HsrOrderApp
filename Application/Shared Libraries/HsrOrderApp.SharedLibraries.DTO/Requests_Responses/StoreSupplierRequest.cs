using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    [DataContract]
    public class StoreSupplierRequest : RequestType
    {
        [DataMember]
        [ObjectValidator]
        public SupplierDTO Supplier { get; set; }
    }
}
