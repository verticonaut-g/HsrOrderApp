using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.SharedLibraries.DTO.Base;
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using HsrOrderApp.SharedLibraries.SharedEnums;

namespace HsrOrderApp.SharedLibraries.DTO
{
    public class SupplierListDTO : DTOBase
    {
        public SupplierListDTO()
        {
            this.AccountNumber = string.Empty;
            this.Name = string.Empty;
            this.CreditRating = SharedEnums.CreditRating.Average;
            this.PreferredSupplierFlag = false;
            this.ActiveFlag = false;
        }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public CreditRating CreditRating { get; set; }

        [DataMember]
        public bool PreferredSupplierFlag { get; set; }

        [DataMember]
        public bool ActiveFlag { get; set; }
    }
}
