namespace AdministradorAmet.Models
{
    public class FilterModels
    {
      
            public int? TicketId { get; set; }
            public string? Identification { get; set; } // Cedula
            public string? Name { get; set; } // Nombre
            public string? LastName { get; set; } // Apellido
            public string? Zone { get; set; }
            public int? VehicleTypeId { get; set; } // TipoVehiculoId
            public string? LicensePlate { get; set; } // PlacaVehiculo
            public string? Brand { get; set; } // Marca
            public string? Model { get; set; } // Modelo
            public int? ViolatedArticle { get; set; } // ArticuloInfringidoId
            public string? IncidentLocation { get; set; } // LugarHecho
            public string? AgentNumber { get; set; } // NoAgente
            public int? AgentId { get; set; }
            public string? Status { get; set; } // Estado
            public int? Hidden { get; set; }
            public DateTime? FechaInicio { get; set; }
            public DateTime? FechaFin { get; set; }
        

    }

    public class VehicleType
    {
        public string Name { get; set; }
    }

    public class Articulo
    {
        public string ArticleNum { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class Agente
    {
        public string Name { get; set; } // Nombre del agente
        public string LastName { get; set; } // Apellido del agente
    }

}
