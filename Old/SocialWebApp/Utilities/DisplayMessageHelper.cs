using Microsoft.AspNetCore.Mvc;

namespace SocialWebApp.Utilities
{
	public class DisplayMessageHelper
	{
		public static string? GetOrSetSuccessMeesage(Controller controller, bool isSet, string message)
		{
			if (isSet)
			{
				controller.TempData["InfoMessage"] = message;
			}
			return controller.TempData["InfoMessage"]?.ToString();
		}

		public static string? GetOrSetErrorMeesage(Controller controller, bool isSet, string message)
		{
			if (isSet)
			{
				controller.TempData["ErrorMessage"] = message;
			}
			return controller.TempData["ErrorMessage"]?.ToString();
		}
	}
}
