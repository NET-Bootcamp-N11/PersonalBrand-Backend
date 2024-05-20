using MediatR;
using Moq;
using PersonalBrand.Application.UseCases.IdentitieCases.Commands;
using PersonalBrand.Application.UseCases.IdentitieCases.Handlers.CommandHandlers;
using PersonalBrand.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalBrandTest1
{
    public class UnitTest1
    {
        private readonly Mock<IMediator> _mediator;
        private readonly CreateUserCommandHandler _createUser;
        public UnitTest1()
        {
            _mediator = new Mock<IMediator>();
            _createUser = new CreateUserCommandHandler(_mediator.Object);
        }

        [Fact]
        public async void TestRegister()
        {
            var command = new CreateUserCommand()
            {
                FirstName = "Pablo",
                LastName = "Eskobar",
                PhoneNumber = "1234567890",
                UserName = "Test",
                Email = "eskobar@pab.lo",
                Password = "PabloEskobar"


            };
            var expresult = new ResponseModel
            {
                Message = "Yaratildi",
                IsSuccess = true,
                StatusCode = 201
            };
            _mediator.Setup(m => m.Send(It.IsAny<IRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Unit());

            var result = await _createUser.Handle(command, new CancellationToken()); 
            Assert.IsType<Unit>(result);
        }
    }
}