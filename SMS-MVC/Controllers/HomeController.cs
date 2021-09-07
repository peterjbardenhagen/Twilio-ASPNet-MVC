using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SMS_MVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Index";
			return View();
		}

		public ActionResult PostStatus()
		{
			try {
				// Log the date created, message id and status
				var dateCreated = DateTime.Now.ToString();
				var smsSid = Request["MessageSid"];
                var messageStatus = Request["MessageStatus"];
                var logMessage = $"\"{dateCreated}\", \"{smsSid}\", \"{messageStatus}\"";

                // Write the text to a a file named "log.txt".
                System.IO.File.AppendAllText(Path.Combine(@"c:\logs", "log.txt"), logMessage + Environment.NewLine);
				ViewBag.Message = logMessage;
			}
			catch (Exception ex)
			{
				try
				{
					// Display error
					ViewBag.Message = "Message sending failed:" + ex.ToString();

					// Write the error to a a file named "log.txt".
					System.IO.File.AppendAllText(Path.Combine(@"c:\logs", "error.txt"), ex.ToString());
				}
				catch { }
			}
			return Content(ViewBag.Message);
		}
		
		public ActionResult Status()
		{
			var fileContents = System.IO.File.ReadLines(@"c:\logs\log.txt").Last();
			ViewBag.Message = "The latest update is " + fileContents;
			return View();
		}

		public ActionResult GetStatus()
		{
			var fileContents = System.IO.File.ReadLines(@"c:\logs\log.txt").Last();
			var message = "The latest update is " + fileContents;
			return Content(message);
		}
	}
}