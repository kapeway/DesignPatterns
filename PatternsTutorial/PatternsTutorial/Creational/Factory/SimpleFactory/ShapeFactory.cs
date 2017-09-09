namespace PatternsTutorial.Creational.Factory.SimpleFactory
{
    public class ShapeFactory
    {
        private static ShapeFactory _instance { get; set; }
        private static object syncLock=new object();

        public static ShapeFactory GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    _instance = new ShapeFactory();
                }
            }
            return _instance;
        }

        public IShape CreateShape(string shapeName)
        {
            switch (shapeName)
            {
                case "Circle":
                    return new Circle();
                case "Rectangle":
                    return new Rectangle();
                case "Square":
                    return new Square();
                default:
                    return null;
            }
        }
    }
}