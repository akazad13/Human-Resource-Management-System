using HRMS.Application.Common.Interfaces;
using HRMS.Application.DTOs.Account;
using MediatR;

namespace HRMS.Application.Commands
{
    public class CreateUserCommand : IRequest<SignupResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, SignupResponse>
    {
        private readonly IIdentityService _identityService;
        public CreateUserCommandHandler(IIdentityService identityService)                         
        {
            _identityService = identityService;
        }
        public async Task<SignupResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.IsUserExist(request.Email);
            if (response == true)
            {
                throw new Exception("There is already an user registered with this email!");
            }

            var result = await _identityService.CreateUserAsync(request.FirstName, request.LastName, request.Email, request.Password);

            if (result.Succeeded)
            {
                return new SignupResponse
                {
                    Succeeded = result.Succeeded,
                    Messages = (string[])Array.Empty<object>()
                };
            }
            return new SignupResponse
            {
                Succeeded = result.Succeeded,
                Messages = result.Errors
            };
        }
    }
}
