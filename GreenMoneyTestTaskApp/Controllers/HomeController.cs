using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreenMoneyTestTaskApp.Models;
using GreenMoneyTestTask;

namespace GreenMoneyTestTaskApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Task1()
        {
            ViewData["TaskText"] = "Написать код, который выведет числа от 0 до 127 по порядку. Вместо чисел, кратных 3 - " +
                "выводить текст 'Green', вместо чисел, кратных 5 – 'Money', вместо кратных и 3 и 5 – 'GreenMoney'.";
            var fizzBuzz = new FizzBuzz();
            var from = 0;
            var to = 127;
            var fizz = "Green";
            var buzz = "Money";

            return View(fizzBuzz.GetFizzBuzz(from, to, fizz, buzz));
        }

        public IActionResult Task2()
        {
            ViewData["TaskText"] = "Сгенерировать последовательность случайных чисел, чей размер не превышает 0.6 и " +
                "не меньше 0, и сумма чисел равна 1";           

            return View();
        }
        [HttpGet]
        public IActionResult Task2Result()
        {           
            var generator = new RandomNumsGenerator();
            var from = 0.0;
            var to = 0.6;
            var sum = 1;

            return PartialView(generator.GetRandomNumbersWithFixedSum(from, to, sum));
        }

        public IActionResult Task3()
        {
            ViewData["TaskText"] = "Сгенерировать последовательность случайных чисел, чей размер не превышает 0.6 и " +
                "не меньше 0, и сумма чисел равна 1";
            var generator = new RandomNumsGenerator();
            var from = 0.0;
            var to = 0.6;
            var sum = 1;

            return View(generator.GetRandomNumbersWithFixedSum(from, to, sum));
        }

        public IActionResult Task4()
        {
            ViewData["TaskText"] = "Написать метод, который в качестве входных данных принимает массив букв " +
                "английского алфавита по порядку и возвращает пропущенную букву в массиве. Пример: ['a', 'b', 'c', 'd', 'f']-> 'e'['O', 'Q', 'R', 'S']-> 'P'.";

            var charCounter = new CharactersCounter();
            var from = 0.0;
            var to = 0.6;
            var sum = 1;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
