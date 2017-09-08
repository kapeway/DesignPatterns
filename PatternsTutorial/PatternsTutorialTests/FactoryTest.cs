using NUnit.Framework;
using PatternsTutorial.Factory;

namespace PatternsTutorialTests
{
    [TestFixture]
    class FactoryTest
    {
        [TestCase("Circle")]
        [TestCase("Square")]
        [TestCase("Rectangle")]
        public void CreateCircle_ShapeFactory_ReturnsCircle(string shape)
        {
            var shapeFactory = ShapeFactory.GetInstance();
            var sut = shapeFactory.CreateShape(shape);
            Assert.That(sut.Draw(),Is.EqualTo($"I am a {shape}"));
        }
    }
}
