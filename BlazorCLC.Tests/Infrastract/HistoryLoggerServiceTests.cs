using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using BlazorCLC.Services;
using BlazorCLC.Infrastract;
using System.Threading.Tasks;

namespace BlazorCLC.Tests.Infrastract
{
    [TestFixture]
    public class HistoryLoggerServiceTests
    {

        private Mock<HistoryLoggerContext> context = new Mock<HistoryLoggerContext>();
        private HistoryPointRepository sut;

        [SetUp]
        public void SetUp()
        {
            sut = new HistoryPointRepository(context.Object);
        }
    }
}
