using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetById
{
    public class GetByIdUserOtpQueryHandler : IRequestHandler<GetByIdUserOtpQuery, ErrorOr<GetByIdUserOtpQueryResult>>
    {
        private readonly IUserOtpRepository _userOtpRepository;

        public GetByIdUserOtpQueryHandler(IUserOtpRepository userOtpRepository)
        {
            _userOtpRepository = userOtpRepository;
        }

        public async Task<ErrorOr<GetByIdUserOtpQueryResult>> Handle(GetByIdUserOtpQuery request, CancellationToken cancellationToken)
        {
            var data = await _userOtpRepository.GetByIdAsync(request.Id);

            return data.Adapt<GetByIdUserOtpQueryResult>();
        }
    }
}  