using AutoMapper;

namespace Chinook.WebApi.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Models.Employee, ViewModels.Employee>();
        }
    }
}
