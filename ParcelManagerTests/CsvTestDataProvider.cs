using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelManagerTests
{
    public static class CsvTestDataProvider
    {
        public static IEnumerable<TestCaseData> GetValidParcelNumbers()
        {
            var readContent = File.ReadAllLines("C:\\Unisys Training\\ParcelManagerTests\\SampleValidParcelNumbers.txt");
            foreach (var line in readContent)
            {
                var parcelNumber = line;
                yield return new TestCaseData(parcelNumber);
            }
        }

        public static IEnumerable<TestCaseData> GetInvalidParcelNumbers()
        {
            var readContent = File.ReadAllLines("C:\\Unisys Training\\ParcelManagerTests\\SampleInvalidParcelNumbers.txt");
            foreach (var line in readContent)
            {
                var parcelNumber = line;
                yield return new TestCaseData(parcelNumber);
            }
        }

        public static IEnumerable<TestCaseData> GetMergedDataSet()
        {
            var readContent = File.ReadAllLines("C:\\Unisys Training\\ParcelManagerTests\\ConsolidatedTestData.txt");
            foreach (var line in readContent)
            {
                // ABC123,True
                var lineData = line.Split(",");

                var parcelNumber = lineData[0];
                var expectedResult = bool.Parse(lineData[1].Trim());

                yield return new TestCaseData(parcelNumber).Returns(expectedResult);
            }
        }
    }
}
