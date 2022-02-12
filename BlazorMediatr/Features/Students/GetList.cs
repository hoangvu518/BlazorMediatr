


namespace MediatrExample.Features.Student
{
    public static class GetList
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
                var students = _db.Students.Select(x => new StudentDto(x.Id, x.Name)).ToList();
                var data = new Result(students);
                var result = await Task.FromResult(data);
                return result;
            }
        }
    }

}
