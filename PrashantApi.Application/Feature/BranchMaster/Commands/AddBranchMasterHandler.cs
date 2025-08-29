using AutoMapper;
using MediatR;
using PrashantApi.Application.Interfaces.BranchMaster;
using PrashantApi.Domain.Entities.BranchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Application.Feature.BranchMaster.Commands
{
    public class AddBranchMasterHandler : IRequestHandler<AddBranchMasterCommand, int>
    {
        private readonly IBranchMasterRepository _repo;
        private readonly IMapper _mapper;

        public AddBranchMasterHandler(IBranchMasterRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddBranchMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BranchMasterModel>(request);
            var newId = await _repo.AddAsync(entity);

            return newId;
        }
    }
}
