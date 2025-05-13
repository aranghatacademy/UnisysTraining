using NUnit.Framework;
using ParcelManager;

namespace ParcelManagerTests
{
    public class ParcelServiceTests
    {

        private ParcelService _parcelService;

        [SetUp]
        public void SetUpTests()
        {
            _parcelService = new ParcelService(null,null);
        }

        [Test]
        public void IsValidParcelNumber_ValidParcelNumber_ReturnsTrue()
        {
            // Arrange
            var parcelNumber = "BLR123";

            //Act
            var result = _parcelService.IsValidParcelNumber(parcelNumber);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidParcelNumber_InvalidParcelNumber_ReturnsFalse()
        {
            // Arrange
            var parcelNumber = "BLR1234";
            //Act
            var result = _parcelService.IsValidParcelNumber(parcelNumber);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidParcelNumber_ValidLowerCaseParcelNumber_ReturnsTrue()
        {
            // Arrange
            var parcelNumber = "blr123";

            //Act
            var result = _parcelService.IsValidParcelNumber(parcelNumber);

            //Assert
            Assert.That(result, Is.True);
        }

        /*[TestCase("BLR123")]
        [TestCase("blr123")]
        [TestCase("BlR123")]
        [TestCase("bLR123")]
        [TestCase("bLR456")]
        [TestCase("BLR456")]
        [TestCase("BlR456 ")]
        [TestCase(" bLR456")]*/
        [TestCaseSource(typeof(CsvTestDataProvider), nameof(CsvTestDataProvider.GetValidParcelNumbers))]
        public void IsValidParcelNumber_DiffCaseParcelNumber_ReturnsTrue(string parcelNumber)
        {
            //Act
            var result = _parcelService.IsValidParcelNumber(parcelNumber);

            //Assert
            Assert.That(result, Is.True);
        }

        [TestCaseSource(typeof(CsvTestDataProvider), nameof(CsvTestDataProvider.GetInvalidParcelNumbers))]
        public void IsValidParcelNumber_InvalidParcelNumbers_ReturnsFalse(string parcelNumber)
        {
            //Act
            var result = _parcelService.IsValidParcelNumber(parcelNumber);

            //Assert
            Assert.That(result, Is.False);
        }

        [TestCaseSource(typeof(CsvTestDataProvider), nameof(CsvTestDataProvider.GetMergedDataSet))]
        public bool IsValidParcelNumber_ConsolidatedParcelNumbers_ReturnsResult(string parcelNumber)
        {
            //Act
            var result = _parcelService.IsValidParcelNumber(parcelNumber);
            return result;
        }

        [Test]
        public void IsValidParcelNumber_EmptyParcelNumber_ThrowsArgumentNullException()
        {
            //Assert that if we pass null value we are expected to get a ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => _parcelService.IsValidParcelNumber(null));
        }

        [Test]
        public void IsValidParcelNumber_NonEmptyParcelNumber_DoesNotThrowArgumentNullException()
        {
            //Assert that if we pass a non-empty string we are not expected to get a ArgumentNullException
            Assert.DoesNotThrow(() => _parcelService.IsValidParcelNumber("BLR123"));
        }

        [Test]
        public void IsValidParcelNumber_LongParcelNumberAbove20_ThrowsInvalidOperationException()
        {
            //Assert that if we pass a string with length greater than 20 we are expected to get a InvalidOperationException
            Assert.Throws<InvalidOperationException>(() => _parcelService.IsValidParcelNumber("BLR12345678901234567890")
                                            , "Parcel Number is too long");
        }

        [TearDown]
        public void TearDownTests()
        {
            
        }
    }
}