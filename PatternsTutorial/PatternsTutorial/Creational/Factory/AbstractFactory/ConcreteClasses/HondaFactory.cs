using PatternsTutorial.Creational.Factory.AbstractFactory.AbstractClasses;

namespace PatternsTutorial.Creational.Factory.AbstractFactory.ConcreteClasses
{
    public class HondaFactory:CarFactory
    {
        public override Car ManufactureCar()
        {
            return new HondaCar();
        }
    }
}