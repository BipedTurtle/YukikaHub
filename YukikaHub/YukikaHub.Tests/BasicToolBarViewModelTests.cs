using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.UI.ViewModels;
using Xunit;
using Moq;
using Prism.Events;
using YukikaHub.UI.Settings;

namespace YukikaHub.Tests
{
    public class BasicToolBarViewModelTests
    {
        private BasicToolbarViewModel _basicToolbarVm;

        public BasicToolBarViewModelTests()
        {
            var eventAggregatorMock = new Mock<IEventAggregator>();
            _basicToolbarVm = new BasicToolbarViewModel(eventAggregatorMock.Object);
        }

        [Theory]
        [InlineData("True")]
        [InlineData("False")]
        public void TogglingDevModeInToolBar_ShouldTurnApplicationSettingsDevMode_OnAndOff(string toggleDevMode)
        {
            _basicToolbarVm.SwitchDevModeCommand.Execute(toggleDevMode);

            if (toggleDevMode == "True")
                Assert.True(ApplicationSettings.Instance.IsDevMode);
            else if (toggleDevMode == "False")
                Assert.False(ApplicationSettings.Instance.IsDevMode);
        }

        [Theory]
        [InlineData("Pikachu")]
        [InlineData("NeitherTrueNorFalse")]
        [InlineData("Truu")]
        public void WhenGivenWrongStringValue_SwitchDevModeCommand_ThrowsArgumentException(string toggleDevMode)
        {
            Assert.Throws<ArgumentException>(() => _basicToolbarVm.SwitchDevModeCommand.Execute(toggleDevMode));
        }
    }
}