namespace BlazorMediatr
{
    public class AppDb
    {
        public AppDb()
        {
            Students = new List<Student>();
            SeedData();
        }
        public List<Student> Students { get; set; }

        private void SeedData()
        {
            Students.AddRange(new List<Student>()
            {
                new Student(1, "Tam"),
                new Student(2, "Hoang"),
                new Student(3, "Hue"),
            });
        }
    }

    public class Student
    {
        public Student(int id, string name)
        {
            Id = id;
            Name = name;

        }
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
