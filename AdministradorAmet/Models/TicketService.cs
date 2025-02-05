using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace AdministradorAmet.Models
{
    
    public class TicketService
    {
        private readonly HttpClient _httpClient;

        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _httpClient.GetFromJsonAsync<Ticket>($"https://localhost:7277/api/Ticket/{ticketId}");
        }
    }

    public class Multas
    {
        public int TicketId { get; set; }
        public string Zone { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public VehicleType VehicleType { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string IncidentLocation { get; set; }
        public string Observations { get; set; }
        public string AgentNumber { get; set; }
        public DateTime TicketDate { get; set; }
        public Articulo Articulo { get; set; }
        public Agente Agente { get; set; }
    }

    public class vehiculos
    {
        public string Name { get; set; }
    }

    public class Articulos
    {
        public string ArticleNum { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class Agentes
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

}
