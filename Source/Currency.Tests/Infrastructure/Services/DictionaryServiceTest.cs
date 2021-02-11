using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Ondato.Domain.Dtos;
using Ondato.Infrastructure.IRepositories;
using Ondato.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using static Ondato.Domain.Dtos.AppSettingsDto;

namespace Ondato.Tests.Infrastructure.Services
{
    public class DictionaryServiceTest
    {
        private Mock<DictionaryService> serviceMock;
        private Mock<IDictionaryRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IDictionaryRepository>();
            var appSettings = new Mock<IOptions<AppSettingsDto>>();
            appSettings.Setup(s => s.Value.ExpirationPeriod).Returns(new ExpirationPeriodDto { Days = 1, Hours = 0, Minutes = 0, Seconds = 0 });
            serviceMock = new Mock<DictionaryService>( repositoryMock.Object, appSettings.Object);
            serviceMock.CallBase = true;
        }

        [Test]
        public async Task Create()
        {
            var service = serviceMock.Object;
            await service.Create(It.IsAny<string>())
                .ConfigureAwait(false);
            repositoryMock.Verify(m => m.Create(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task Append()
        {
            var service = serviceMock.Object;
            await service.Append(It.IsAny<string>(),"For bytes")
                .ConfigureAwait(false);
            repositoryMock.Verify(m => m.Append(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once);
        }

        [Test]
        public async Task Delete()
        {
            var service = serviceMock.Object;
            await service.Delete(It.IsAny<string>())
                .ConfigureAwait(false);
            repositoryMock.Verify(m => m.Delete(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task Get()
        {
            var service = serviceMock.Object;
            await service.Get(It.IsAny<string>())
                .ConfigureAwait(false);
            repositoryMock.Verify(m => m.Get(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task DeleteExpired()
        {
            var service = serviceMock.Object;
            await service.DeleteExpired()
                .ConfigureAwait(false);
            repositoryMock.Verify(m => m.Delete(It.IsAny<DateTime>()), Times.Once);
        }
    }
}
