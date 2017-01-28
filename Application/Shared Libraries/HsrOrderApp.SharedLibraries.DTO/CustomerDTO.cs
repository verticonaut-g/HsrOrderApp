#region

using System.Collections.Generic;
using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.SharedLibraries.DTO
{
    [DataContract]
    public class CustomerDTO : DTOParentObject
    {
        private IList<AddressDTO> _addresses;
        private string _firstName;
        private string _name;
        private string _anrede;

        public CustomerDTO()
        {
            this.Name = string.Empty;
            this.FirstName = string.Empty;
            this.Anrede = string.Empty;
            this.Addresses = new List<AddressDTO>();
        }

        [DataMember]
        [StringLengthValidator(1, 50)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    this._name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 150)]
        public string Anrede
        {
            get { return _anrede; }
            set
            {
                if (value != _anrede)
                {
                    this._anrede = value;
                    OnPropertyChanged(() => Anrede);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 50)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    this._firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        [DataMember]
        [ObjectCollectionValidator(typeof (AddressDTO))]
        public IList<AddressDTO> Addresses
        {
            get { return _addresses; }
            set
            {
                if (value != _addresses)
                {
                    this._addresses = value;
                    OnPropertyChanged(() => Addresses);
                }
            }
        }
    }
}