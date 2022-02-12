namespace BlazorMediatr.Features.Students
{
    public static class MyException
    {
        public record Query : IRequest<Result>
        {
        }
        public record Result(List<StudentDto>? Students)
        {
        }
        public record StudentDto(int Id, string Name);
        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly AppDb _db;

            public Handler(AppDb db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Query query, CancellationToken token)
            {
                throw new NotImplementedException();
            }
        }
    }
}