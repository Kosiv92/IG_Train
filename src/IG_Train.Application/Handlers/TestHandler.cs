using MediatR;

namespace IG_Train.Application.Handlers
{
    public class TestHandler : IRequestHandler<TestRequest, TestResponse>
    {
        Task<TestResponse> IRequestHandler<TestRequest, TestResponse>.Handle(TestRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
