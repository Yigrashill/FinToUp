using Application.Features.Finance.Queries;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles;

public class FinanceProfile : Profile
{
    public FinanceProfile()
    {
        CreateMap<FinanceDTO, Finance>().ReverseMap();   
    }
}