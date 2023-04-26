using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocatorDtoValidator:AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocatorDtoValidator(ILeaveTypeRepository leaveTypeRepository)           
            {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
        }

    }
}
