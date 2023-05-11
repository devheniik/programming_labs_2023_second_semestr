namespace Programm
{
    public interface IVessel
    {
        int Speed { get; set; }
        int CarryingCapacity { get; }
        string FuelType { get; }
        void Move();
        void Info();
    }

    public class CargoShip : IVessel
    {
        public int Speed { get; set; }

        public int CarryingCapacity
        {
            get { return 5000; }
        }

        public string FuelType
        {
            get { return "Diesel"; }
        }

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

    public class Tanker : IVessel
    {
        public int Speed { get; set; }

        public int CarryingCapacity
        {
            get { return 10000; }
        }

        public string FuelType
        {
            get { return "Heavy Fuel Oil"; }
        }

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

    public class ContainerCarrier : IVessel
    {
        public int Speed { get; set; }

        public int CarryingCapacity
        {
            get { return 2000; }
        }

        public string FuelType
        {
            get { return "LNG"; }
        }

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

    public class Boat : IVessel
    {
        public int Speed { get; set; }

        public int CarryingCapacity
        {
            get { return 10; }
        }

        public string FuelType
        {
            get { return "Gasoline"; }
        }

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

    public class Canoe : IVessel
    {
        public int Speed { get; set; }

        public int CarryingCapacity
        {
            get { return 1; }
        }

        public string FuelType
        {
            get { return "Muscle Power"; }
        }

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

// Example usage
    class Program
    {
        static void Main(string[] args)
        {
            IVessel myVessel = new CargoShip();
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