
namespace TiendawebAPI.Models
{
    public class ActualizarClienteRequest
    {
        public string Nit { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
