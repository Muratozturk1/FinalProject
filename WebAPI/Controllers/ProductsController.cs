using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController] // bu olaya attribute diyoruz . attribute bir class ile ilgili bilgi verme onu imzalamak demektir.
// yani prodcutscontroller aslında bir apicontrollerdır o yüzden kendini ona göre yapılandır demek. route ise bize nasıl
// istekte bulunacaklar onunla ilgili
// route bu isteği yaparken insanlar bize nasıl ulaşssın
public class ProductsController : ControllerBase
{
    //IoC -- İnversion of Control 
    IProductService _productService;
    public ProductsController(IProductService productService )
    {
        _productService = productService;
    }
    [HttpGet("getall")]
    public IActionResult GetAll() 
    {


        
        var result = _productService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPost("add")]
    public IActionResult Add(Product product) 
    {
        var result = _productService.Add(product);
        if (result.Success) 
        {
            return Ok(result);        
        }
        return BadRequest(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id) 
    {
        var result = _productService.GetById(id);
        if(result.Success) 
        {
            return Ok(result);
        }
        return BadRequest(result);
    
    }
}
