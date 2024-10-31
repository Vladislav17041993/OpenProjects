using DiProject.Interfaces;
using DiProject.Models;

namespace DiProject.Controllers
{
	public class TestControllerOne : ITestControllerInterface
	{
		public void DeleteData(Guid Id)
		{
			throw new NotImplementedException();
		}

		public string GetData(Guid Id)
		{
			throw new NotImplementedException();
		}

		public void SetData(DataModel data)
		{
			throw new NotImplementedException();
		}
	}
}
