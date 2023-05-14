using Microsoft.AspNetCore.Mvc;

namespace Lesson_33.Controllers
{
    public class HomeController : Controller
    {
        public string Hello() => "Hello All";

        public string Index() => "Index methods";

        public string AB(int a, int b)
        {
            return $"Result: {a + b}";
        }
    }
}
