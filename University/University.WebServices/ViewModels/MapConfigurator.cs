namespace University.WebServices
{
    using AutoMapper;
    using AutoMapper.Configuration;
    using System;
    using University.Domain;
    using University.WebServices.ViewModels;

    internal class MapConfigurator
    {
        public IMapper CreateMapper() => this.GetConfiguration().CreateMapper();

        internal MapperConfiguration GetConfiguration()
        {
            var configurationExpression = new MapperConfigurationExpression();
            this.CreateMaps(configurationExpression);
            return new MapperConfiguration(configurationExpression);
        }

        internal void CreateMaps(MapperConfigurationExpression expression)
        {
            expression.CreateMapFromTeacherToTeacherDto();
            expression.CreateMapFromTeacherToTeacherViewModel();
        }
    }

    internal static class MappingConfigurationExpressionExtension
    {
        public static void CreateMapFromTeacherToTeacherDto(this IProfileExpression expression)
        {
            expression.CreateMap<Teacher, TeacherDto>()
                .ForMember(
                    d => d.FirstName,
                    opt => opt.MapFrom(s => GetValueSafety(s.Name, n => n.FirstName)))
                .ForMember(
                    d => d.MiddleName,
                    opt => opt.MapFrom(s => GetValueSafety(s.Name, n => n.MiddleName)))
                .ForMember(
                    d => d.LastName,
                    opt => opt.MapFrom(s => GetValueSafety(s.Name, n => n.LastName)));
        }

        private static TResult GetValueSafety<TInput, TResult>(TInput target, Func<TInput, TResult> getter)
        {
            return target is null || getter is null ? default : getter.Invoke(target);
        }

        public static void CreateMapFromTeacherToTeacherViewModel(this IProfileExpression expression)
        {
            expression.CreateMap<Teacher, TeacherViewModel>()
                .ForMember(
                    d => d.FullName,
                    opt => opt.MapFrom(s => s.Name.FullName));
        }
    }
}
