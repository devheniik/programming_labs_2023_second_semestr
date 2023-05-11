
namespace Programm
{
    public abstract class Vessel
    {
        public int Speed { get; set; }
        public abstract int CarryingCapacity { get; }
        public abstract string FuelType { get; }

        public void Move()
        {
            Console.WriteLine("Moving at {0} knots...", Speed);
        }
        
        public void Info()
        {
            Console.WriteLine("This vessel can carry {0} tons and uses {1} as fuel.", CarryingCapacity,
                FuelType);

        }
    }

    public class CargoShip : Vessel
    {
        public override int CarryingCapacity
        {
            get { return 5000; }
        }

        public override string FuelType
        {
            get { return "Diesel"; }
        }
    }

    public class Tanker : Vessel
    {
        public override int CarryingCapacity
        {
            get { return 10000; }
        }

        public override string FuelType
        {
            get { return "Heavy Fuel Oil"; }
        }
    }

    public class ContainerCarrier : Vessel
    {
        public override int CarryingCapacity
        {
            get { return 2000; }
        }

        public override string FuelType
        {
            get { return "LNG"; }
        }
    }

    public class Boat : Vessel
    {
        public override int CarryingCapacity
        {
            get { return 10; }
        }

        public override string FuelType
        {
            get { return "Gasoline"; }
        }
    }

    public class Canoe : Vessel
    {
        public override int CarryingCapacity
        {
            get { return 1; }
        }

        public override string FuelType
        {
            get { return "Muscle Power"; }
        }
    }

// Example usage
    class Program
    {
        static void Main(string[] args)
        {
            Vessel myVessel = new CargoShip();
            myVessel.Speed = 20;
            myVessel.Move();
            myVessel.Info();

            myVessel = new Canoe();
            myVessel.Speed = 5;
            myVessel.Move();
            myVessel.Info();
        }
    }
}
