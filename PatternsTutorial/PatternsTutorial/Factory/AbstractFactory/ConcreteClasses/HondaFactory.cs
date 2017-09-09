using PatternsTutorial.Factory.AbstractFactory.AbstractClasses;

namespace PatternsTutorial.Factory.AbstractFactory.ConcreteClasses
{
    public class HondaFactory:CarFactory
    {
        public override Car ManufactureCar()
        {
            return new HondaCar();
        }
    }
}