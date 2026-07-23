using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
	[HttpGet]
	public IActionResult ObtenerProductos()
	{
		var productos = new[]
		{
			new
			{
				Id = 1,
				Nombre = "Laptop Gamer",
				Precio = 7500.50,
				Categoria = "Tecnología"
			},
			new
			{
				Id = 2,
				Nombre = "Smartphone X",
				Precio = 4200.00,
				Categoria = "Tecnología"
			},
			new
			{
				Id = 3,
				Nombre = "Auriculares Bluetooth",
				Precio = 350.75,
				Categoria = "Accesorios"
			},
			new
			{
				Id = 4,
				Nombre = "Monitor 24 pulgadas",
				Precio = 1800.00,
				Categoria = "Tecnología"
			},
			new
			{
				Id = 5,
				Nombre = "Teclado Mecánico",
				Precio = 450.00,
				Categoria = "Accesorios"
			}
		};
		return Ok(productos);
	}

	[HttpGet("{id}")]
	public IActionResult ObtenerProductoPorId(int id)
	{
		var producto = new
		{
			Id = id,
			Nombre = "Producto Ejemplo",
			Precio = 999.99,
			Categoria = "General"
		};
		return Ok(producto);
	}
}
