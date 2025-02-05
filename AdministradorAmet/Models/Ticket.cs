namespace AdministradorAmet.Models
{
    public class Ticket
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
        public Article Articulo { get; set; }
        public Agent Agente { get; set; }
        public string Status { get; set; }
    }

    public class VehicleTypee
    {
        public string Name { get; set; }
    }

    public class Article
    {
        public string ArticleNum { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class Agent
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
