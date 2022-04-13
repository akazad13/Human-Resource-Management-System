using HRMS.Application.Common.Interfaces;
using HRMS.Application.Common.Utilities;
using HRMS.Application.DTOs.Account;
using MediatR;

namespace HRMS.Application.Commands
{
    public class UserAuthCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserAuthCommandHandler : IRequestHandler<UserAuthCommand, AuthResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly IHelper _helper;
        public UserAuthCommandHandler(
               IIdentityService identityService,
               IHelper helper
        )
        {
            _identityService = identityService;
            _helper = helper;
        }
        public async Task<AuthResponse> Handle(UserAuthCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.AuthenticateUser(request.Email, request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException($"Invalid Credentials for '{request.Email}'.");
            }

            var response = new AuthResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                JWToken = await _helper.GenerateJwtToken(user)
            };

            return response;
        }
    }
}
