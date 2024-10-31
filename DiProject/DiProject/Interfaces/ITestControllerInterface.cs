using DiProject.Models;

namespace DiProject.Interfaces
{
	public interface ITestControllerInterface
	{
		public string GetData(Guid Id);

		public void SetData(DataModel data);

		public void DeleteData(Guid Id);
	}
}
