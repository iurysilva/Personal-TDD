using ProjetoTesteTdd.API.Models;
using ProjetoTesteTdd.API.Service;
using Moq;
using ProjetoTesteTdd.API.Interfaces;

namespace ProjetoTesteTdd.Test
{
    public class UnitTest1
    {
        private readonly ClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepository;

        public UnitTest1()
        {
            _clientRepository= new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepository.Object);
        }

        [Fact(DisplayName = "Should be inserted in the database passing the correct entry objct")]
        public void Test1()
        {
            //ARRANGE
            var client = new ClientEntry
            {
                Name = "iuryzin22",
                Age = 23,
                Cpf = "Segredo :)"
            };

            //ACT
            ClientResponse sut = _clientService.SaveClient(client);


            //ACCEPT
            Assert.NotNull(sut);
            Assert.Equal(client.Name, sut.Name);            
            Assert.Equal(client.Age, sut.Age);
            Assert.Equal(client.Cpf, sut.Cpf);
        }

        [Fact(DisplayName = "Should not pass a null object")]
        public void test2()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _clientService.SaveClient(null));
            Assert.Equal("client", exception.ParamName);
        }

        [Fact(DisplayName = "Should save client in the database")]
        public void test3()
        {
            //ARRANGE
            Client savedClient = null;

            var client = new ClientEntry
            {
                Name = "iuryzin22",
                Age = 23,
                Cpf = "Segredo :)"
            };

            _clientRepository.Setup(x => x.SaveClient(It.IsAny<Client>()))
                .Callback<Client>((client) => savedClient = client);

            //ACT
            ClientResponse sut = _clientService.SaveClient(client);

            //ACCEPT
            Assert.NotNull(sut);
            Assert.Equal(client.Name, savedClient.Name);
            Assert.Equal(client.Age, savedClient.Age);
            Assert.Equal(client.Cpf, savedClient.Cpf);

        }  
    }
}