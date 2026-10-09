
using Microsoft.AspNetCore.Mvc;
using TiendawebAPI.Models;

namespace TiendawebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly TiendaPooContext _context;

        public ClientesController(TiendaPooContext ctx)
        {
            _context = ctx;
        }

        // 1. Listar todos los clientes
        [HttpGet("ListarUsuarios")]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            return _context.Clientes.ToList();
        }

        // 2. Buscar un cliente por su ID
        [HttpGet("ObtenerUsuario/{id}")]
        public ActionResult<Cliente> ObtenerUsuario(int id)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
            {
                return NotFound("No se encontró el cliente.");
            }

            return Ok(cliente);
        }

        // 3. Registrar un cliente
        [HttpPost("CrearCliente")]
        public ActionResult<Cliente> CrearCliente(
            [FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest(
                    "Debes enviar los datos del cliente.");
            }

            cliente.IdCliente = 0;
            cliente.Facturas = new List<Factura>();

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }

        // 4. Actualizar un cliente
        [HttpPut("ActualizarCliente/{id}")]
        public ActionResult<Cliente> ActualizarCliente(
            int id,
            [FromBody] ActualizarClienteRequest solicitud)
        {
            var clienteExistente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == id);

            if (clienteExistente == null)
            {
                return NotFound(
                    "No se encontró el cliente.");
            }

            clienteExistente.Nit = solicitud.Nit;
            clienteExistente.Nombre = solicitud.Nombre;
            clienteExistente.Apellidos = solicitud.Apellidos;
            clienteExistente.Email = solicitud.Email;

            _context.SaveChanges();

            return Ok(clienteExistente);
        }

        // 5. Eliminar un cliente
        [HttpDelete("EliminarCliente/{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
            {
                return NotFound(
                    "No se encontró el cliente.");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok(
                "Cliente eliminado correctamente.");
        }
    }
} 