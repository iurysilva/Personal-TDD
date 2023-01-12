using ProjetoTesteTdd.API.Interfaces;
using ProjetoTesteTdd.API.Models;

namespace ProjetoTesteTdd.API.Service
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public ClientResponse SaveClient(ClientEntry? client)
        {

            if (client == null) throw new ArgumentNullException(nameof(client));

            _clientRepository.SaveClient(new Client
            {
                Name = client.Name,
                Age = client.Age,
                Cpf = client.Cpf,
            });

            return new ClientResponse
            {
                Name = client.Name,
                Age = client.Age,
                Cpf = client.Cpf,
            };
        }
    }
}
