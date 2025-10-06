using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PrashantApi.Application.DTOs.JobEntry;
using PrashantApi.Application.Feature.JobEntry.Commands;
using PrashantApi.Domain.Entities.JobEntry;

namespace PrashantApi.Application.Interfaces.JobEntry.Mapping
{
    public class JobEntryProfile : Profile
    {
        public JobEntryProfile()
        {
            CreateMap<AddJobEntryCommand, JobEntryDto>();
            CreateMap<UpdateJobEntryCommand, JobEntryDto>();

            CreateMap<JobEntryDto, JobEntryModel>();
            CreateMap<JobEntryModel, JobEntryDto>();
        }
    }
}
