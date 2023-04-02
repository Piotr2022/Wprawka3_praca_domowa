using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RokPrzestepnyApp.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;


namespace RokPrzestepnyApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Uzytkownik uzytkownik { get; set; }

        public List<string> lista = new List<string>();

        public string? Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
             
        }

        public IActionResult OnPost()
        {
            var data = HttpContext.Session.GetString("Lista");

            if (data != null)
            {
                lista = JsonConvert.DeserializeObject<List<string>>(data);
            }

            if (ModelState.IsValid)
            {
                Message = uzytkownik.get_Message();

                string newData = uzytkownik.Imie + ", " + uzytkownik.Rok + " - ";

                if (uzytkownik.czy_Przestepny() == true)
                {
                    newData += "rok przestępny";
                } else
                {
                    newData += "rok nieprzestępny";
                }

                lista.Add(newData);

                HttpContext.Session.SetString("Lista", JsonConvert.SerializeObject(lista));
            }
            return Page();
        }
    }
}