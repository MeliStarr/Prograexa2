using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendApi.Models;

namespace BackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductoController(AppDbContext context)
    {
        _context = context;
    }

    //get
    [HttpGet]
    public async Task<IActionResult> ObtenerProductos()
    {
        var lista = await _context.Productos.ToListAsync();
        return Ok(lista);
    }
    [HttpGet("{id}")]
    public IActionResult ObtenerProductoPorId(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto == null) return NotFound(new { mensaje = "No existe ese producto" });
        return Ok(producto);
    }
    //
    [HttpGet("buscar")]
    public async Task<IActionResult> Buscar(string nombre)
    {
        var productos = await _context.Productos
            .Where(p => p.Nombre.Contains(nombre))
            .ToListAsync();

        return Ok(productos); 
    }
    //post
    [HttpPost]
    public IActionResult RegistrarProducto([FromBody] Producto producto)
    {
        _context.Productos.Add(producto);
        _context.SaveChanges();
        return Ok(new { mensaje = "Producto guardado con éxito", producto });
    }
//put
    [HttpPut("{id}")]
    public IActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
    {
        var producto = _context.Productos.Find(id);
        if (producto == null) return NotFound(new { mensaje = "No existe ese producto" });

        producto.Nombre = productoActualizado.Nombre;
        producto.Precio = productoActualizado.Precio;
        producto.Categoria = productoActualizado.Categoria;
        _context.SaveChanges();
        return Ok(new { mensaje = "Producto actualizado", producto });
    }

    //delete
    [HttpDelete("{id}")]
    public IActionResult EliminarProducto(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto == null) return NotFound(new { mensaje = "No existe ese producto" });

        _context.Productos.Remove(producto);
        _context.SaveChanges();
        return Ok(new { mensaje = "Producto eliminado" });
    }
}