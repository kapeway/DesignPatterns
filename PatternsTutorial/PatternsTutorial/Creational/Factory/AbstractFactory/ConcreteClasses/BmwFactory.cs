using PatternsTutorial.Creational.Factory.AbstractFactory.AbstractClasses;

namespace PatternsTutorial.Creational.Factory.AbstractFactory.ConcreteClasses
{
    public class BmwFactory:CarFactory
    {
        public override Car ManufactureCar()
        {
            return new BmwCar();
        }
    }
}