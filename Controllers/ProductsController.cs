using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyNetCore.Models;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Milo" },
        new Product { Id = 2, Name = "Tim Tams" }
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
      
        _logger.LogInformation("Writing to log file with INFORMATION severity level.");
    
        _logger.LogDebug("Writing to log file with DEBUG severity level."); 
    
        _logger.LogWarning("Writing to log file with WARNING severity level.");
    
        _logger.LogError("Writing to log file with ERROR severity level.");
    
        _logger.LogCritical("Writing to log file with CRITICAL severity level.");
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products.Find(x => x.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
}

