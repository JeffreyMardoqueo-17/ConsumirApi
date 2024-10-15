using ConsumirApi_jsonplaceholder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace ConsumirApi_jsonplaceholder.Controllers
{
    public class JsonplaceholderController : Controller
    {
        private readonly HttpClient _httpClient;
        private string _url = "https://jsonplaceholder.typicode.com/todos/";

        //inyeccion de dependecnias
        public JsonplaceholderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: JsonplaceholderController
        public async Task<ActionResult> Index()
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await _httpClient.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta
                string data = await response.Content.ReadAsStringAsync();

                // Pasar los datos a la vista
                ViewBag.Data = data;

                return View();
            }
            else
            {
                // Manejar error
                ViewBag.Error = "No se pudo consumir la API";
                return View("Error");
            }
        }

        // GET: JsonplaceholderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JsonplaceholderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JsonplaceholderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JsonplaceholderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JsonplaceholderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JsonplaceholderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JsonplaceholderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
