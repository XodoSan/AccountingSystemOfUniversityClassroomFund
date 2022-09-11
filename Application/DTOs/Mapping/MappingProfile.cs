using AutoMapper;
using Domain.Constants;
using Domain.Entities;

namespace Application.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<RoomDTO, Room>()
                .ForMember(dst => dst.SubdivisionName,
                opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dst => dst.Purpose,
                opt => opt.MapFrom(src => Enum.Parse(typeof(Purpose), src.Purpose)))
                .ForMember(dst => dst.RoomType,
                opt => opt.MapFrom(src => Enum.Parse(typeof(RoomType), src.RoomType)))
                .ForMember(dst => dst.RoomEquipment, opt => opt.NullSubstitute(null))
                .ReverseMap();

            this.CreateMap<SubdivisionDTO, Subdivision>()
                .ForMember(dst => dst.IncomingWorkers, opt => opt.NullSubstitute(null))
                .ForMember(dst => dst.IncomingRooms, opt => opt.NullSubstitute(null))
                .ReverseMap();

            this.CreateMap<UniversityBuildingDTO, UniversityBuilding>()
                .ForMember(dst => dst.IncomingRooms, opt => opt.NullSubstitute(null))
                .ReverseMap();
        }
    }
}
