using Newtonsoft.Json;

namespace PatternsTutorial.Builder
{
    public class BmwCar
    {
        public BmwCar()
        {
            Engine = "ordinary engine";
            Door = "four door";
            IsGpsEnabled = false;
        }
        public string Engine { get; set; }
        public string Door { get; set; }
        public bool IsGpsEnabled { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BmwCar) obj);
        }

        protected bool Equals(BmwCar other)
        {
            return string.Equals(Engine, other.Engine) && string.Equals(Door, other.Door) && IsGpsEnabled == other.IsGpsEnabled;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Engine != null ? Engine.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Door != null ? Door.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsGpsEnabled.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}