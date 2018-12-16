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

            return PartialView("Task2Result",generator.GetRandomNumbersWithFixedSum(from, to, sum));
        }

        public IActionResult Task3(string inputString)
        {
            ViewData["TaskText"] = "Написать метод, который в качестве входных данных принимает массив букв " +
                "английского алфавита по порядку и возвращает пропущенную букву в массиве. Пример: ['a', 'b', 'c', 'd', 'f']-> " +
                "'e'['O', 'Q', 'R', 'S']-> 'P'.";
                        
            return View();
        }

        public IActionResult Task3Result(string inputString)
        {
            if(String.IsNullOrWhiteSpace(inputString))
            {
                return BadRequest("Входная трока не может быть пустой");
            }
            string result = String.Empty;
            var counter = new CharactersCounter();
            try
            {
                if (counter.TryGetMissedCharacter(inputString.ToCharArray(), out var missedCharacter))
                {
                    result += "Пропущенная буква: " + missedCharacter;
                }
                else
                {
                    result = "Пропущенная буква не найдена";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                result = "Входная строка не должна содержать символов кроме букв английского алфавита";
            }
            return Ok(result);
        }

        public IActionResult Task4()
        {
            ViewData["TaskText"] = "Даны два числовых массива, необходимо написать LINQ - выражение, которое " +
                "выдаст коллекцию из двух полей, где одно поле -это пересечение элементов массива, а другое поле - его квадрат.";            

            return View();
        }

        public IActionResult Task4Result(
            [ModelBinder(typeof(IntArrayModelBinder))] IEnumerable<int> firstCollection,
            [ModelBinder(typeof(IntArrayModelBinder))] IEnumerable<int> secondCollection)
        {

            var numProcessor = new NumericCollectionsProcessor();
            var result = numProcessor.GetIntersectionsAndSquares(firstCollection, secondCollection);
            return PartialView(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
