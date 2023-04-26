using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;

        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)

        {
            var validator = new CreateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

            return leaveType.Id;

        }
    }
}
