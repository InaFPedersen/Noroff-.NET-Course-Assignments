using AutoMapper;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.CommentDTO;
namespace Tidsbanken_Backend.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<Comment, CreateCommentDTO>();

            CreateMap<UpdateCommentDTO, Comment>();
            CreateMap<Comment, UpdateCommentDTO>();

            CreateMap<ReadCommentDTO, Comment>();
            CreateMap<Comment, ReadCommentDTO>();
        }
    }
}
