using PatternsTutorial.Factory.AbstractFactory.AbstractClasses;

namespace PatternsTutorial.Factory.AbstractFactory.ConcreteClasses
{
    public class BmwFactory:CarFactory
    {
        public override Car ManufactureCar()
        {
            return new BmwCar();
        }
    }
}