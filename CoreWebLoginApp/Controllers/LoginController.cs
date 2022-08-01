using Microsoft.AspNetCore.Mvc;

namespace CoreWebLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://randomuser.me/api/"),
                    Headers ={
                { "X-RapidAPI-Key", "SIGN-UP-FOR-KEY" },
                { "X-RapidAPI-Host", "random-user-generator1.p.rapidapi.com" },
            },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            catch (Exception e)
            {
            }
            return View();
        }

    }
}
