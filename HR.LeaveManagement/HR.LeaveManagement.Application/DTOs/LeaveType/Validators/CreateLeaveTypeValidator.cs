using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeValidator :AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
