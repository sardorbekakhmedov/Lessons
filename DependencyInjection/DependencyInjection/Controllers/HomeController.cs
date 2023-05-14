using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DependencyInjection.Repository;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public QuestionRepository QuestionRepository;
        public UserRepository UserRepository;

        public HomeController(QuestionRepository questionRepository, UserRepository userRepository)
        {
            QuestionRepository = questionRepository;
            UserRepository = userRepository;

            Console.WriteLine("Home controller is working\n\n");
        }
     
        public IActionResult Index()
        {
            return View();
        }

    }
}