using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Walking_Tour_API.UI.Models.DTO;
using Walking_Tour_API.UI.Models.ViewModel;

namespace Walking_Tour_API.UI.Controllers
{
	public class RegionsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly HttpClient _client;
		public RegionsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_client = _httpClientFactory.CreateClient("myclient");
		}
		public async Task<IActionResult> Index()
		{
			var response = await _client.GetAsync("/api/v1/Regions?pageNumber=1&pageSize=20");
			string jsonData = await response.Content.ReadAsStringAsync();
			var regions = JsonConvert.DeserializeObject<IEnumerable<RegionDTO>>(jsonData);
			return View(regions);
		}

		public IActionResult Add()
		{
			return View();
		}
        
        [HttpPost]
        public async Task<IActionResult> Add(AddRegionVM regionVM)
        {
            var result = await _client.PostAsJsonAsync("/api/v1/Regions", regionVM);
			if (result.IsSuccessStatusCode)
			{
                return RedirectToAction("Index", "Regions");
            }
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _client.GetAsync("/api/v1/Regions/" + id);
            string jsonData = await response.Content.ReadAsStringAsync();
            var regions = JsonConvert.DeserializeObject<RegionDTO>(jsonData);
            return View(regions);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO regionDTO)
		{
            var result = await _client.PutAsJsonAsync("/api/v1/Regions/Update/" + regionDTO.Id, regionDTO);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDTO regionDTO)
        {
            var result = await _client.DeleteAsync("/api/v1/Regions/" + regionDTO.Id);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View("Edit");
        }
    }
}
