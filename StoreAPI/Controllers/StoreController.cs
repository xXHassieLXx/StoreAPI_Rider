using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Models.Entities;
using Wkhtmltopdf.NetCore;

namespace StoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController :ControllerBase
{
    private readonly IGeneratePdf _generatePdf;
    private readonly StoreDbContext _context;
    

    public StoreController(IGeneratePdf generatePdf, StoreDbContext context)
    {
        _generatePdf = generatePdf;
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllStores()
    {
        var stores = await _context.Store.ToListAsync();
        return Ok(stores);
    }
    

    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GetStorePdf(int id)
    {
        var store = await _context.Store
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == id);
        var result = await _generatePdf.GetPdf(
            "Templates/StoreTemplate.cshtml",
            store
            );
        return result;
    }
}