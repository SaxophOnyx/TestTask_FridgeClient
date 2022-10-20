using AutoMapper;
using FridgeClient.FridgeAPI.DataTransferObjects.Request;
using FridgeClient.ViewModels.Entities;

namespace FridgeAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateInput();
            CreateOutput();
        }


        private void CreateInput()
        {
            CreateMap<FridgeModelToReturn, FridgeModelViewModel>();
            CreateMap<FridgeToReturn, FridgeViewModel>();
            CreateMap<StoredProductToReturn, StoredProductViewModel>();
            CreateMap<ProductToReturn, ProductViewModel>();
            CreateMap<ProductToReturn, StoredProductViewModel>().ForMember(st => st.ProductId, opt => opt.MapFrom(p => p.Id))
                                                                .ForMember(st => st.ProductName, opt => opt.MapFrom(p => p.Name));
            CreateMap<StoredProductToReturn, StoredProductViewModel>().ForMember(st => st.ProductId, opt => opt.MapFrom(p => p.ProductId))
                                                                      .ForMember(st => st.ProductName, opt => opt.MapFrom(p => p.ProductName))
                                                                      .ForMember(st => st.Id, opt => opt.MapFrom(p => p.Id));
            CreateMap<StoredProductViewModel, StoredProductToCreate>().ForMember(st => st.ProductId, opt => opt.MapFrom(p => p.ProductId))
                                                                      .ForMember(st => st.Quantity, opt => opt.MapFrom(p => p.Quantity));
            CreateMap<StoredProductViewModel, StoredProductToUpdate>().ForMember(p => p.Quantity, opt => opt.MapFrom(vm => vm.Quantity))
                                                                      .ForMember(p => p.Id, opt => opt.MapFrom(vm => vm.Id));
        }

        private void CreateOutput()
        {

        }
    }
}
