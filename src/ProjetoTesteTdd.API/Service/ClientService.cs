using ProjetoTesteTdd.API.Models;

namespace ProjetoTesteTdd.API.Service
{
    public class ClientService
    {
        public ClientResponse SaveClient(ClientEntry? client)
        {

            if (client == null) throw new ArgumentNullException(nameof(client));

            return new ClientResponse
            {
                Name = client.Name,
                Age = client.Age,
                Cpf = client.Cpf,
            };
        }
    }
}
