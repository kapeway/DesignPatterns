using NUnit.Framework;
using PatternsTutorial.Builder;

namespace PatternsTutorialTests
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void BmwBuilder_x6_BuildsBmwx6()
        {
            var sut = new BmwBuilder();
            var result = sut.FixEngine("x6 v8 engine").FixDoor("x6 2 door").AddGps(true).Create();
            Assert.That(result,Is.EqualTo(new BmwCar{Engine = "x6 v8 engine",Door = "x6 2 door" ,IsGpsEnabled = true}));
        }
        [Test]
        public void BmwBuilder_WithoutModificationCreate_BuildsOdrinaryBmw()
        {
            var sut = new BmwBuilder();
            var result = sut.Create();
            Assert.That(result, Is.EqualTo(new BmwCar { Engine = "ordinary engine", Door = "four door", IsGpsEnabled = false }));
        }

    }
}
