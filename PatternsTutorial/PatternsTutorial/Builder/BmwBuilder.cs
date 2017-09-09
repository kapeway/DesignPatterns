namespace PatternsTutorial.Builder
{
    public class BmwBuilder
    {
        private string Engine { get; set; }
        private string Door { get; set; }
        private bool IsGpsEnabled { get; set; }

        public BmwBuilder FixEngine(string engine)
        {
            this.Engine = engine;
            return this;
        }

        public BmwBuilder FixDoor(string door)
        {
            this.Door = door;
            return this;
        }

        public BmwBuilder AddGps(bool isGpsEnabled)
        {
            this.IsGpsEnabled = isGpsEnabled;
            return this;
        }

        public BmwCar Create()
        {
            if(string.IsNullOrWhiteSpace(Engine) && string.IsNullOrWhiteSpace(Door) && IsGpsEnabled==false)
                return new BmwCar();
            return new BmwCar {Engine = Engine, Door = Door, IsGpsEnabled = IsGpsEnabled};
        }
    }
}