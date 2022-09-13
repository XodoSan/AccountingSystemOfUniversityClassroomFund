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
                .ForMember(dst => dst.RoomEquipment, opt => opt.NullSubstitute(null));

            this.CreateMap<SubdivisionDTO, Subdivision>()
                .ForMember(dst => dst.IncomingWorkers, opt => opt.NullSubstitute(null))
                .ForMember(dst => dst.IncomingRooms, opt => opt.NullSubstitute(null));

            this.CreateMap<UniversityBuildingDTO, UniversityBuilding>()
                .ForMember(dst => dst.IncomingRooms, opt => opt.NullSubstitute(null))
                .ForMember(dst => dst.IncomingSubdivisions, opt => opt.NullSubstitute(null));

            this.CreateMap<EquipmentCategoryDTO, EquipmentCategory>()
                .ForMember(dst => dst.EquipmentAmount, opt => opt.NullSubstitute(null))
                .ForMember(dst => dst.CurrentCategoryEquipments, opt => opt.NullSubstitute(null));

            this.CreateMap<EquipmentDTO, Equipment>()
                .AfterMap((src, dst) => dst.WhereUsed.EquipmentInventoryNumber = src.InventoryNumber)
                .AfterMap((src, dst) => dst.FinanciallyResponsiblePerson.EquipmentInventoryNumber = src.InventoryNumber)
                .AfterMap((src, dst) => dst.WhereUsed.Purpose = (Purpose)Enum.Parse(typeof(Purpose), src.WhereUsed.Purpose))
                .ForMember(dst => dst.EquipmentCategoryName,
                opt => opt.MapFrom(src => src.Category.Name));

            this.CreateMap<UsageDTO, Usage>();
            this.CreateMap<WorkerDTO, Worker>()
                .ForMember(dst => dst.EquipmentInventoryNumber, opt => opt.NullSubstitute(null));
        }
    }
}