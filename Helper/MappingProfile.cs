using AutoMapper;
using Send_and_track.DTO;
using Send_and_track.models;

namespace Send_and_track.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EMailDTO, Email>();
            CreateMap<AttachmentDTO, Attachment>();
            CreateMap<attachmentforsaveDTO, Attachment>();

        }
    }
}