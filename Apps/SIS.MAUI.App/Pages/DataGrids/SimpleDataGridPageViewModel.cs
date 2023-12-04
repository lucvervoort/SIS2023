using DotNurse.Injector.Attributes;
using SIS.Domain.Interfaces;
using System.ComponentModel;

namespace UraniumApp.Pages.DataGrids;
public class SimpleDataGridPageViewModel : BindableObject
{
	static Random random = new();
	public List<Student> Items { get; } = new();

	[InjectService] public ISISTeacherRepository TeacherRepository { get; private set; }

	public SimpleDataGridPageViewModel()
	{
		for (int i = 0; i < 10; i++)
		{
			Items.Add(new Student
			{
				Id = i,
				Name = "Person " + i,
				Age = random.Next(14, 85),
			});
		}
    }
	public class Student
	{
		[DisplayName("Identity Number")]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
