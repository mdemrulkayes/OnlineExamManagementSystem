using api.oems.Controllers;
using api.oems.Controllers.Resources.CategoriesInInstitutes;
using api.oems.Controllers.Resources.Category;
using api.oems.Controllers.Resources.Chapters;
using api.oems.Controllers.Resources.Institutes;
using api.oems.Controllers.Resources.MemberShip;
using api.oems.Controllers.Resources.QuestionAnswers;
using api.oems.Controllers.Resources.QuestionOptions;
using api.oems.Controllers.Resources.Questions;
using api.oems.Controllers.Resources.QuestionSets;
using api.oems.Controllers.Resources.Subjects;
using api.oems.Controllers.Resources.Tutor.District;
using api.oems.Controllers.Resources.Tutor.TutorArea;
using api.oems.Controllers.Resources.UserJoinRequest;
using api.oems.Core.Models;
using api.oems.Core.Models.Tutor;
using AutoMapper;

namespace api.oems.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resources Mapping Start
            CreateMap<Institute, InstituteResources>().ForMember(i => i.User,
                opt => opt.MapFrom(ins => new ApplicationUser()
                {
                    Id = ins.User.Id,
                    Email = ins.User.Email,
                    FirstName = ins.User.FirstName,
                    LastName = ins.User.LastName,
                    Address = ins.User.Address,
                    ProfilePictureUrl = ins.User.ProfilePictureUrl
                }));

            CreateMap<Category, CategoryResources>();
            CreateMap<CategoriesInInstitute, CategoriesInInstituteResources>();

            CreateMap<Subject, SubjectResources>().ForMember(s => s.Category, opt => opt.MapFrom(category => new Category()
            {
                Id = category.Category.Id,
                CategoryName = category.Category.CategoryName,
                IsDeleted = category.Category.IsDeleted
            }));
            CreateMap<Chapter, ChapterResources>();
            CreateMap<UserInstituteJoinRequest, UserInstituteJoinRequestResources>();
            CreateMap<QuestionSet, QuestionsSetController>();
            CreateMap<Question, QuestionResources>();
            CreateMap<QuestionOption, QuestionOptionResources>();
            CreateMap<QuestionAnswers, QuestionAnswersResources>();
            CreateMap<QuestionAnswersMark, QuestionAnswersMarkResources>();
            CreateMap<MembershipDetail, MembershipDetailsResources>();
            CreateMap<TutorDistrict, TutorDistrictResources>();
            CreateMap<TutorArea, TutorAreaResources>().ForMember(x => x.District, opt => opt.MapFrom(district => new TutorDistrict()
            {
                Id = district.District.Id,
                DistrictName = district.District.DistrictName,
                IsActive = district.District.IsActive,
                IsDeleted = district.District.IsDeleted
            }));

            //Domain to API Resources Mapping End


            //API Resources to Domain Mapping Start
            CreateMap<SaveInstituteResources, Institute>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<SaveCategoryResources, Category>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<SaveCategoriesInInstituteResources, CategoriesInInstitute>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<SaveSubjectResources, Subject>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<SaveChapterResources, Chapter>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<SaveUserInstituteJoinRequestResources, UserInstituteJoinRequest>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<SaveQuestionSetResources, QuestionSet>().ForMember(q => q.Id, opt => opt.Ignore());
            CreateMap<SaveQuestionResources, Question>().ForMember(w => w.Id, opt => opt.Ignore());
            CreateMap<SaveQuestionOptionResources, QuestionOption>().ForMember(sq => sq.Id, opt => opt.Ignore());
            CreateMap<SaveQuestionAnswersResources, QuestionAnswers>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SaveQuestionAnswersMarkResources, QuestionAnswersMark>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SaveMembershipDetailsResources, MembershipDetail>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SaveTutorDistrictResources, TutorDistrict>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SaveTutorAreaResources, TutorArea>().ForMember(x => x.Id, opt => opt.Ignore());

            //API Resources to Domain Mapping End
        }
    }
}
