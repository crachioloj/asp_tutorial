using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      Mapper.CreateMap<Customer, CustomerDto>();
      Mapper.CreateMap<Movie, MovieDto>();
      Mapper.CreateMap<MembershipType, MembershipTypeDto>();
      Mapper.CreateMap<Genre, GenreDto>();
      Mapper.CreateMap<Rental, RentalDto>();

      Mapper.CreateMap<CustomerDto, Customer>()
        .ForMember(c => c.Id, opt => opt.Ignore());

      Mapper.CreateMap<MovieDto, Movie>()
        .ForMember(c => c.Id, opt => opt.Ignore());

      Mapper.CreateMap<MembershipTypeDto, MembershipType>()
        .ForMember(c => c.Id, opt => opt.Ignore());

      Mapper.CreateMap<GenreDto, Genre>()
        .ForMember(c => c.Id, opt => opt.Ignore());

      Mapper.CreateMap<RentalDto, Rental>()
        .ForMember(r => r.Id, o => o.Ignore());
    }
  }
}