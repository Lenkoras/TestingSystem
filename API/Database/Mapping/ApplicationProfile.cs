using AutoMapper;
using Database.Models;
using Shared.Models;

namespace Database.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<QuestionAnswer, QuestionAnswerShort>();
            CreateMap<TestQuestion, TestQuestionShort>();
            CreateMap<Test, UserTestShort>();
        }
    }
}
