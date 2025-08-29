using AutoMapper;
using MediatR;
using PrashantApi.Application.DTOs.BranchMaster;
using PrashantApi.Application.Interfaces.BranchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.BranchMaster.Queries
{
    public class GetBranchByIdHandler : IRequestHandler<GetBranchByIdQuery, BranchMasterDto?>
    {
        private readonly IBranchMasterRepository _repo;
        private readonly IMapper _mapper;

        public GetBranchByIdHandler(IBranchMasterRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BranchMasterDto?> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<BranchMasterDto?>(branch);
        }
    }
}
