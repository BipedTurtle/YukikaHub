using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YukikaHub.Model;
using YukikaHub.UI.Wrapper;
using Moq.Protected;
using Moq;
using System.Collections;

namespace YukikaHub.Tests.Wrapper_Tests
{
    public class AlbumWrapperTests
    {
        private AlbumWrapper _albumWrapper;

        public AlbumWrapperTests()
        {
            _albumWrapper = new AlbumWrapper(new Album());
        }

        [Theory]
        [MemberData(nameof(GetInvalidDates))]
        public void AlbumReleasedBeforeKikasBirthDate_ShouldYieldValidationError(DateTime released)
        {
            _albumWrapper.Released = released;
            var errors = _albumWrapper.GetErrors(nameof(_albumWrapper.Released));

            int count = 0;
            foreach (var error in errors) {
                count++;
                break;
            }

            Assert.True(count > 0);
        }

        public static IEnumerable<object[]> GetInvalidDates()
        {
            yield return new object[] { new DateTime(1993, 2, 15) };
            yield return new object[] { new DateTime(1800, 1, 1) };
            yield return new object[] { new DateTime(1991, 3, 3) };
        }
    }
}
