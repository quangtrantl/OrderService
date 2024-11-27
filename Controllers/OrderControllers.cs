using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OrderService.Models;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private static List<Order> orders = new List<Order>();

    [HttpPost]
    public ActionResult AddOrder(Order order)
    {
        orders.Add(order);
        return Ok(order);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return Ok(orders);
    }
	private readonly HttpClient _httpClient;

    public OrderController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5000/api/User/{userId}");
        if (response.IsSuccessStatusCode)
        {
            var user = await response.Content.ReadAsStringAsync();
            return Ok(user);
        }
        return NotFound();
    }

    [HttpGet("book/{bookId}")]
    public async Task<IActionResult> GetBookById(int bookId)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5001/api/Book/{bookId}");
        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadAsStringAsync();
            return Ok(book);
        }
        return NotFound();
    }

}
