
Car car = new Car();
car.City = "New-york";
car.Show();

Vehicle vehicle = car;
vehicle.Show();


abstract class Vehicle  // Not new object
{
    private readonly Car car;
    public string Name;
    public string Year;
    protected string Color;  //  <\/< =============

    protected abstract void Show1();
    public virtual void Show() { }

}

class Car : Vehicle  //  Sealed not inheritance
{
    public string City;

    protected override void Show1()  // sealed
    {
        Console.WriteLine($" Car:  {City}: {Color}");
    }

    class Shevrolet1 : Car
    {
        public override void Show()  // Not is working
        {
            Console.WriteLine($" Shevrolet:  {Color}");
        }
        class Shevrolet2 : Car
        {
            public override void Show()  // Not is working
            {
                Console.WriteLine($" Shevrolet:  {Color}");
            }
        }
    }
}


class Shevrole3 : Car
{
    public override void Show()  // Not is working
    {
        Console.WriteLine($" Shevrolet:  {Color}");
    }
}