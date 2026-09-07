using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crmLead.Models; 

namespace crm_net8.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class LeadController : ControllerBase
{
    private readonly CrmDbContext _context; 
    private readonly ILogger<LeadController> _logger;

    public LeadController(CrmDbContext context, ILogger<LeadController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // 1. GET: api/Lead (Obtener todos los leads)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
    {
        // Cambiado a minúscula '.id' en el ordenamiento opcional o directo a la lista
        return await _context.Leads.OrderByDescending(l => l.id).ToListAsync();
    }

    // 2. GET: api/Lead/5 (Obtener un lead por su id)
    [HttpGet("{id}")]
    public async Task<ActionResult<Lead>> GetLead(int id)
    {
        var lead = await _context.Leads.FindAsync(id);

        if (lead == null)
        {
            return NotFound(new { mensaje = $"No se encontró el lead con id {id}" });
        }

        return lead;
    }

    // 3. POST: api/Lead (Crear un nuevo lead)
    [HttpPost]
    public async Task<ActionResult<Lead>> PostLead(Lead lead)
    {
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        // Usamos lead.id en minúscula
        return CreatedAtAction(nameof(GetLead), new { id = lead.id }, lead);
    }

    // 4. PUT: api/Lead/5 (Actualizar un lead existente)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLead(int id, Lead lead)
    {
        // Validación usando tu propiedad 'id' en minúscula
        if (id != lead.id)
        {
            return BadRequest(new { mensaje = "El id del parámetro no coincide con el id del objeto enviado" });
        }

        _context.Entry(lead).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Leads.Any(e => e.id == id))
            {
                return NotFound(new { mensaje = $"El lead con id {id} ya no existe" });
            }
            throw;
        }

        return NoContent();
    }

    // 5. DELETE: api/Lead/5 (Eliminar un lead)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLead(int id)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead == null)
        {
            return NotFound(new { mensaje = $"No se encontró el lead con id {id}" });
        }

        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
