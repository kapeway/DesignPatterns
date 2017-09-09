using NUnit.Framework;
using PatternsTutorial.Creational.Factory.AbstractFactory.ConcreteClasses;

namespace PatternsTutorialTests.Creational
{
    [TestFixture]
    public class AbstractFactoryTest
    {
        [Test]
        public void BmwFactory_ManufactureBmwCar()
        {
            var sut = new BmwFactory();
            var result = sut.ManufactureCar();
            Assert.That(result.Name, Is.EqualTo("BMW"));
        }
        [Test]
        public void HondaFactory_ManufactureHondaCar()
        {
            var sut = new HondaFactory();
            var result = sut.ManufactureCar();
            Assert.That(result.Name, Is.EqualTo("Honda"));
        }
    }
}
