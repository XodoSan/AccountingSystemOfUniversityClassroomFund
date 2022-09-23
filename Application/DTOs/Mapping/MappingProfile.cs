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
                .ForMember(dst => dst.Number, 
                opt => opt.MapFrom(src => Convert.ToInt32(src.Number)))
                .ForMember(dst => dst.Capacity, 
                opt => opt.MapFrom(src => Convert.ToInt32(src.Capacity)))
                .ForMember(dst => dst.Area, 
                opt => opt.MapFrom(src => Convert.ToInt32(src.Area)))
                .ForMember(dst => dst.Floor, 
                opt => opt.MapFrom(src => Convert.ToInt32(src.Floor)))
                .ForMember(dst => dst.SubdivisionName,
                opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dst => dst.Purpose,
                opt => opt.MapFrom(src => Enum.Parse(typeof(Purpose), src.Purpose)))
                .ForMember(dst => dst.RoomType,
                opt => opt.MapFrom(src => Enum.Parse(typeof(RoomType), src.RoomType)))
                .ForMember(dst => dst.RoomEquipment, opt => opt.NullSubstitute(null));

            this.CreateMap<SubdivisionDTO, Subdivision>()
                .ForMember(dst => dst.IncomingWorkers, opt => opt.NullSubstitute(null))
                .ForMember(dst => dst.IncomingRooms, opt => opt.NullSubstitute(null));

            this.CreateMap<UniversityBuildingDTO, UniversityBuilding>()
                .ForMember(dst => dst.IncomingRooms, opt => opt.NullSubstitute(null))
                .ForMember(dst => dst.IncomingSubdivisions, opt => opt.NullSubstitute(null));

            this.CreateMap<EquipmentCategoryDTO, EquipmentCategory>()
                .ForMember(dst => dst.CurrentCategoryEquipments, opt => opt.NullSubstitute(null));

            this.CreateMap<EquipmentDTO, Equipment>()
                .ForPath(dst => dst.FinanciallyResponsiblePerson.Id, opt => opt.Ignore())
                .ForPath(dst => dst.WhereUsed.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Category, opt => opt.Ignore());

            this.CreateMap<UsageDTO, Usage>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .AfterMap((src, dst) => dst.Purpose = (Purpose)Enum.Parse(typeof(Purpose), src.Purpose));

            this.CreateMap<WorkerDTO, Worker>()
                .ForMember(dst => dst.CurrentWorkerEquipments, opt => opt.NullSubstitute(null));

            this.CreateMap<EquipmentMovementHistory, EquipmentMovementHistoryDTO>();

            this.CreateMap<EquipmentFinanciallyResponsiblePersonChangeHistory, 
                EquipmentFinanciallyResponsiblePersonChangeHistoryDTO>();
        }
    }
}