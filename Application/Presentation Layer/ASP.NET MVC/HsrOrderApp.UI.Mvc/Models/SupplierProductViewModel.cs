using AutoMapper;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.Mvc.Controllers.Base;
using System.Collections.Generic;

namespace HsrOrderApp.UI.Mvc.Models
{
    public class SupplierProductViewModel : ListViewModelBase<SupplierProductDTO>
    {
        public SupplierProductViewModel() { }
        public SupplierProductViewModel(List<SupplierProductDTO> list) { Items = list; }

        public List<SupplierProductDTO> ItemsToDelete { get; } = new List<SupplierProductDTO>();

        public ControllerAction LatestSupplierProductAction { get; set; }

        public bool IsReadOnly { get; set; }
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        public void ApplyFormAttributes(SupplierProductDTO source)
        {
            Mapper.CreateMap<SupplierProductDTO, SupplierProductDTO>().ForAllMembers(opt => opt.Ignore());
            Mapper.CreateMap<SupplierProductDTO, SupplierProductDTO>()
                .ForMember(dest => dest.AverageLeadTime, map => map.MapFrom(src => src.AverageLeadTime));
                //.ForMember(dest => dest.AddressLine2, map => map.MapFrom(src => src.AddressLine2))
                //.ForMember(dest => dest.PostalCode, map => map.MapFrom(src => src.PostalCode))
                //.ForMember(dest => dest.City, map => map.MapFrom(src => src.City))
                //.ForMember(dest => dest.Phone, map => map.MapFrom(src => src.Phone))
                //.ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email));

            Mapper.Map(source, SelectedItem);
        }
    }
}





