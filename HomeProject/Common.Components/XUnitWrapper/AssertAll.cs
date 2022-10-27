using Xunit.Sdk;

namespace Common.Components.XUnitWrapper
{
    public class AssertAll
    {
        public static void Check(params Action[] assertions)
        {
            var errorMessages = new List<string>();

            foreach (var action in assertions)
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    errorMessages.Add(ex.Message);
                }
            }

            if (errorMessages.Count == 0)
            {
                return;
            }

            string errorMessageString = string.Join(Environment.NewLine, errorMessages);

            throw new XunitException($"The following conditions failed: {Environment.NewLine}{errorMessageString}");
        }
    }
}
