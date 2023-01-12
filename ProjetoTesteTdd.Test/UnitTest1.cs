using ProjetoTesteTdd.API.Models;
using ProjetoTesteTdd.API.Service;

namespace ProjetoTesteTdd.Test
{
    public class UnitTest1
    {
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

            var clientService = new ClientService();

            //ACT
            ClientResponse sut = clientService.SaveClient(client);


            //ACCEPT
            Assert.NotNull(sut);
            Assert.Equal(client.Name, sut.Name);            
            Assert.Equal(client.Age, sut.Age);
            Assert.Equal(client.Cpf, sut.Cpf);
        }

        [Fact(DisplayName = "Should not pass a null object")]
        public void test2()
        {
            var clientService = new ClientService();
            var exception = Assert.Throws<ArgumentNullException>(() => clientService.SaveClient(null));
            Assert.Equal("client", exception.ParamName);
        }
    }
}