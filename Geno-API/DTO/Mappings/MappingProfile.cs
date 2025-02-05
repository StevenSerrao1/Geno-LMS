using AutoMapper;
using Geno_API.DTO.DTOUpdates;

namespace Geno_API.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping Structure for this project;
            // DTORequest -> Entity
            // DTOUpdate -> Entity
            // Entity -> DTOResponse

            #region AdminDTO Mappings

            // MAP ADMIN-REQUEST-DTO TO ADMIN-ENTITY
            CreateMap<AdminDTORequest, Admin>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CreatedCourses, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedCourses, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedLessons, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedLessons, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedQuizzes, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedQuizzes, opt => opt.Ignore())
                .ForMember(dest => dest.Students, opt => opt.Ignore());

            // MAP ADMIN-UPDATE-DTO TO ADMIN-ENTITY
            CreateMap<AdminDTOUpdate, Admin>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CreatedCourses, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedCourses, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedLessons, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedLessons, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedQuizzes, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedQuizzes, opt => opt.Ignore())
                .ForMember(dest => dest.Students, opt => opt.Ignore());

            // MAP ADMIN-ENTITY TO ADMIN-RESPONSE-DTO
            CreateMap<Admin, AdminDTOResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.AdminName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => src.DateJoined.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.CreatedCourseNames, opt => opt.MapFrom(src => src.CreatedCourses.Select(c => c.Title).ToList()))
                .ForMember(dest => dest.UpdatedCourseNames, opt => opt.MapFrom(src => src.UpdatedCourses.Select(c => c.Title).ToList()))
                .ForMember(dest => dest.CreatedLessonNames, opt => opt.MapFrom(src => src.CreatedLessons.Select(l => l.LessonName).ToList()))
                .ForMember(dest => dest.UpdatedLessonNames, opt => opt.MapFrom(src => src.UpdatedLessons.Select(l => l.LessonName).ToList()))
                .ForMember(dest => dest.CreatedQuizNames, opt => opt.MapFrom(src => src.CreatedQuizzes.Select(q => q.QuizName).ToList()))
                .ForMember(dest => dest.UpdatedQuizNames, opt => opt.MapFrom(src => src.UpdatedQuizzes.Select(q => q.QuizName).ToList()))
                .ForMember(dest => dest.StudentNames, opt => opt.MapFrom(src => src.Students.Select(s => s.FullName)));

            #endregion

            #region StudentDTO Mappings

            CreateMap<StudentDTORequest, Student>();

            #endregion

        }

    }
}
