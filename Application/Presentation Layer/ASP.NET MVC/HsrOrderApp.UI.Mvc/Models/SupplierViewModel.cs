﻿using AutoMapper;
using HsrOrderApp.SharedLibraries.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HsrOrderApp.UI.Mvc.Models
{
    public class SupplierListViewModel : ListViewModelBase<SupplierListDTO>
    {
        public SupplierListViewModel() { }
        public SupplierListViewModel(List<SupplierListDTO> list) { Items = list; }
    }
    public class SupplierViewModel : DetailViewModelBase<SupplierDTO>
    {
        public SupplierViewModel() { }
        public SupplierViewModel(SupplierDTO model, SupplierProductViewModel supplierProducts, bool isNew) : base(model, isNew)
        {
            _supplierProducts = supplierProducts;
        }

        private SupplierProductViewModel _supplierProducts;
        public SupplierProductViewModel SupplierProducts
        {
            get
            {
                if (_supplierProducts != null)
                {
                    _supplierProducts.Items = Model.SupplierProducts.ToList();
                }
                return _supplierProducts;
            }
            set
            {
                _supplierProducts = value;
                Model.SupplierProducts = _supplierProducts.Items;
            }
        }

        public void ApplyFormAttributes(SupplierDTO source)
        {
            Mapper.CreateMap<SupplierDTO, SupplierDTO>().ForAllMembers(opt => opt.Ignore());
            Mapper.CreateMap<SupplierDTO, SupplierDTO>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.AccountNumber, map => map.MapFrom(src => src.AccountNumber))
                .ForMember(dest => dest.CreditRating, map => map.MapFrom(src => src.CreditRating))
                .ForMember(dest => dest.PreferredSupplierFlag, map => map.MapFrom(src => src.PreferredSupplierFlag))
                .ForMember(dest => dest.ActiveFlag, map => map.MapFrom(src => src.ActiveFlag))
                .ForMember(dest => dest.PurchasingWebServiceURL, map => map.MapFrom(src => src.PurchasingWebServiceURL));


            Mapper.Map(source, Model);
        }
    }
}
