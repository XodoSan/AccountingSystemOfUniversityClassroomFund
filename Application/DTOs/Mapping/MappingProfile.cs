using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using System.Security.Cryptography;

namespace Application.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<RoomDTO, Room>()
                .ForMember(dst => dst.SubdivisionName,
                opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dst => dst.UniversityName,
                opt => opt.MapFrom(ConfigStorage.currentUniversityName))
                .ForMember(dst => dst.Purpose,
                opt => opt.MapFrom(src => Enum.Parse(typeof(Purpose), src.Purpose)))
                .ForMember(dst => dst.RoomType,
                opt => opt.MapFrom(src => Enum.Parse(typeof(RoomType), src.RoomType)));
            this.CreateMap<Room, RoomDTO>();
            this.CreateMap<SubdivisionDTO, Subdivision>();
            this.CreateMap<Subdivision, SubdivisionDTO>();
        }
    }
}
