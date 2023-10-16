using SIS.Domain;

namespace SISTests
{
    public class TeacherTests
    {
        // This is a "dummy" test - only serves as a project example to get started
        [Fact]
        public void TeacherCreate()
        {
            var teacher = new Teacher { FirstName = "Luc", LastName = "Vervoort "};
            Assert.Equal("Luc", teacher.FirstName);
            Assert.Equal("Vervoort", teacher.LastName);
        }
    }
}