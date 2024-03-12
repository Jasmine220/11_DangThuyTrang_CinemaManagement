﻿using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly HttpClient client = null;
        private string CheckoutApiUrl = "";
        public CheckoutController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CheckoutApiUrl = "https://localhost:7230/api/Checkout";
        }
        public async Task<IActionResult> Ticket(int id)
        {
            HttpResponseMessage response = await client.GetAsync(CheckoutApiUrl + "/" + id);

            Ticket ticket = new Ticket();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                ticket = JsonSerializer.Deserialize<Ticket>(strData, options);
            }
            return View(ticket);
        }
    }
}
