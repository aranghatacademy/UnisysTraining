using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParcelManager;

namespace ParcelManagerTests
{
    public class ParcelDeliveryUpdateTests
    {
        private ParcelService _parcelService;
        private Mock<IParcelRepository> mockRepository;
        private Mock<EmailService> mockEmailService;

        [SetUp]
        public void Setup()
        {
             mockRepository = new Mock<IParcelRepository>();
            mockEmailService = new Mock<EmailService>();
            _parcelService = new ParcelService(mockRepository.Object, mockEmailService.Object);
        }

        [Test]
        public void UpdateParcelDElivery_InvalidPArcelNumber_ReturnsFalse()
        {
            var parcelNumber = "BLR1234";

            //Act
            var result = _parcelService.MarkParcelAsDelivered(parcelNumber);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateParcelDelivery_ValidParcelNumber_ReturnsTrue()
        {
            // Arrange
            var parcelNumber = "BLR123";
            mockRepository.Setup(x => x.UpdateParcelStatus(It.IsAny<string>(), "Delivered")).Returns(true);

            //Act
            var result = _parcelService.MarkParcelAsDelivered(parcelNumber);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void UpdateParcelDelivery_ParcelNumberNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            var parcelNumber = "BLR123";
            mockRepository.Setup(x => x.UpdateParcelStatus(It.Is<string>(d =>  d == parcelNumber), "Delivered"))
                                                            .Throws(new KeyNotFoundException());
            //Act
            var result = _parcelService.MarkParcelAsDelivered(parcelNumber);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GetAllParcels_AllParcels_ReturnsListParcels()
        {
            mockRepository.Setup(x => x.GetParcels()).Returns(new Dictionary<string, string>
            {
                { "BLR123", "In Transit" },
                { "BLR456", "Delivered" },
                { "BLR789", "In Transit" }
                
            });

            var parcels = _parcelService.GetParcels();

            Assert.That(parcels, Is.Not.Null);
            Assert.That(parcels.Count, Is.GreaterThan(0));
        }

        [Test]
        public void UpdateParcelDelivery_ShouldSendEmail_ReturnsVoid()
        {
            var parcelNumber = "BLR123";
            //Mock the parcel Exist
            mockRepository.Setup(x => x.UpdateParcelStatus(It.Is<string>(d => d == parcelNumber), "Delivered")).Returns(true);
            
            //Update the parcel as delivered
            _parcelService.MarkParcelAsDelivered(parcelNumber);

            //mockEmailService.Object.SentEmail("test", "test");
            //Assert that the email service was called
            mockEmailService.Verify(x => x.SentEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
    }
}
