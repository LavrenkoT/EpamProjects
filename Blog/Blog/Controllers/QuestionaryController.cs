using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class QuestionaryController : Controller
    {
        [AcceptVerbs("POST", "GET")]
        public ActionResult Action(QuestionaryModel questionary)
        {
            questionary.Sports = questionary.Sports
                .Where(x => !string.Equals(x, bool.FalseString, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (Request.HttpMethod == HttpMethod.Post.ToString()) {
                ////create model in database;
            }

            return PartialView("View", questionary);
        }
    }
}