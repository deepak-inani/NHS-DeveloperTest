using AutoMapper;
using NHSHealthCareSolution.Core.ViewModel;
using NHSHealthCareSolution.Persistence;

namespace NHSHealthCareSolution
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientViewModel>();
            Mapper.CreateMap<Patient, PatientFormViewModel>();
            Mapper.CreateMap<PatientFormViewModel, Patient>();

        }
    }
}