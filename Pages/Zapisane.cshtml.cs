using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RokPrzestepnyApp.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RokPrzestepnyApp.Pages
{
    public class ZapisaneModel : PageModel
    {
        [BindProperty]
        public List<string> lista { get; set; }


        public void OnGet()
        {
            var data = HttpContext.Session.GetString("Lista");

            if (data != null)
                lista = JsonConvert.DeserializeObject<List<string>>(data);
        }
    }
}
