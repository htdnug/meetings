namespace UnitTesting
{
    public class Car
    {
        public Car()
        {
        }

        public Car(Car car)
        {
            this.Color = car.Color;
            this.Make = car.Make;
        }

        public string Color { get; set; }

        public string Make { get; set; }
    }
}
