using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;
using YukikaHub.UI.Wrapper;
using Xunit;
using Moq;

namespace YukikaHub.Tests.Wrapper_Tests
{
    public class TicketWrapperTests
    {
        private TicketWrapper _ticketWrapper;

        public TicketWrapperTests()
        {
            _ticketWrapper = new TicketWrapper(new Ticket());
        }

        [Theory]
        [MemberData(nameof(GetDatesBeforeToday))]
        public void TicketShouldNotBeBeforeToday(DateTime date)
        {
            _ticketWrapper.Date = date;
            var errors = _ticketWrapper.GetErrors(nameof(_ticketWrapper.Date));
            var enumerator = errors.GetEnumerator();

            enumerator.MoveNext();
            Assert.NotNull(enumerator.Current);
        }


        public static IEnumerable<object[]> GetDatesBeforeToday()
        {
            yield return new object[] { DateTime.Today.AddMinutes(-1)};
            yield return new object[] { DateTime.Today.AddDays(-22) };
            yield return new object[] { DateTime.Today.AddMonths(-1) };
        }
    }
}
