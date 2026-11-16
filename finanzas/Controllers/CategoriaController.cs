using finanzas.Data;
using finanzas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace finanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CategoriaController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategorias()
        {
            try
            {
                return Ok(await _context.Categorias.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las categorías.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound(new { message = "Categoría no encontrada." });
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener la categoría.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear la categoría.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest(new { message = "El ID de la categoría no coincide." });
                }

                var categoriaExistente = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id);
                if (categoriaExistente == null) return NotFound(new { message = "Categoría no encontrada." });

                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Tipo = categoria.Tipo;
                categoriaExistente.Activo = categoria.Activo;
                categoriaExistente.CategoriaPadreId = categoria.CategoriaPadreId;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al actualizar la categoría.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id);
                if (categoria == null) return NotFound(new { message = "Categoría no encontrada." });

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al eliminar la categoría.", error = ex.Message });
            }
        }
    }
}
