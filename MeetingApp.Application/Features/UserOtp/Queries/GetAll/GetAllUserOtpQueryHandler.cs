using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetAll
{
    public class GetAllUserOtpQueryHandler : IRequestHandler<GetAllUserOtpQuery, ErrorOr<List<GetAllUserOtpQueryResult>>>
    {
        private readonly IUserOtpRepository _userOtpRepository;

        public GetAllUserOtpQueryHandler(IUserOtpRepository userOtpRepository)
        {
            _userOtpRepository = userOtpRepository;
        }

        public async Task<ErrorOr<List<GetAllUserOtpQueryResult>>> Handle(GetAllUserOtpQuery request, CancellationToken cancellationToken)
        {
            var data = ToString(); //await _userOtpRepository.GetAll(request.DataFilter);

            return data.Adapt<List<GetAllUserOtpQueryResult>>();
        }
    }
}        