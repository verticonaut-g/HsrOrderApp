﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    [DataContract]
    public class StoreSupplierResponse : ResponseType
    {
        [DataMember]
        [RangeValidator(1, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int SupplierId { get; set; }
    }
}
