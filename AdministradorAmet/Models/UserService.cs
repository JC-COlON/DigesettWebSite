using System.Collections.Generic;

namespace AdministradorAmet.Models
{
    public class UserService
    {
        List<User> users = new List<User>()
        {
           
        
        new User(){ Cedula="40234047229",Name="Junior",LastName="Colon",Gender="Masculino",Role="Administrador",NoAgente=""},
        new User(){ Cedula="00000000001",Name="Alex",LastName="Colon",Gender="Masculino",Role="Agente",NoAgente="0001"},
        new User(){ Cedula="00000000002",Name="Sandra",LastName="Colon",Gender="Femenino",Role="Ciudadano",NoAgente=""},
        new User(){ Cedula="00000000003",Name="Edgar",LastName="Mercado",Gender="Masculino",Role="Agente",NoAgente="0002"},
        new User(){ Cedula="00000000004",Name="Mom",LastName="Colon",Gender="Masculino",Role="Ciudadano",NoAgente=""},
        new User(){ Cedula="00000000005",Name="Lucila",LastName="Reyes",Gender="Femenino",Role="Ciudadano",NoAgente=""}

        };
        public async Task<List<User>> UserList()
        {
            return await Task.FromResult(users);
        }
       
    }
}
