using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    [DataContract]
    public class GetSupplierRequest : RequestType
    {
        [DataMember]
        [RangeValidator(0, RangeBoundaryType.Exclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public override int Id { get { return base.Id; } set { base.Id = value; } }
    }
}
