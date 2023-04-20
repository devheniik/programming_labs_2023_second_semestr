using System;
using System.Collections.Generic;

namespace Stones
{
    public abstract class Stone
    {
        private string _name;
        private double _caratWeight;
        private double _pricePerCarat;
        private double _transparency;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double CaratWeight
        {
            get { return _caratWeight; }
            set { _caratWeight = value; }
        }

        public double PricePerCarat
        {
            get { return _pricePerCarat; }
            set { _pricePerCarat = value; }
        }

        public double Transparency
        {
            get { return _transparency; }
            set { _transparency = value; }
        }

        public Stone(string name, double caratWeight, double pricePerCarat, double transparency)
        {
            _name = name;
            _caratWeight = caratWeight;
            _pricePerCarat = pricePerCarat;
            _transparency = transparency;
        }

        public virtual double CalculateCost()
        {
            return _caratWeight * _pricePerCarat * 1;
        }

        public abstract string GetStoneType();
    }

    public class PreciousStone : Stone
    {
        public PreciousStone(string name, double caratWeight, double pricePerCarat, double transparency)
            : base(name, caratWeight, pricePerCarat, transparency)
        {
        }

        public override string GetStoneType()
        {
            return "Precious";
        }
    }

    public class SemiPreciousStone : Stone
    {
        public SemiPreciousStone(string name, double caratWeight, double pricePerCarat, double transparency)
            : base(name, caratWeight, pricePerCarat, transparency)
        {
        }

        public override string GetStoneType()
        {
            return "Semi-Precious";
        }
        
        public override double CalculateCost()
        {
            return base.CalculateCost() * 0.5;
        }
    }

    public class Necklace
    {
        private List<Stone> _stones;

        public Necklace()
        {
            _stones = new List<Stone>();
        }
        
        public List<Stone> Stones { get { return _stones; } }

        public void AddStone(Stone stone)
        {
            _stones.Add(stone);
        }

        public double CalculateTotalWeight()
        {
            double totalWeight = 0;

            foreach (Stone stone in _stones)
            {
                totalWeight += stone.CaratWeight;
            }

            return totalWeight;
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;

            foreach (Stone stone in _stones)
            {
                totalCost += stone.CalculateCost();
            }

            return totalCost;
        }

        public void SortByValue()
        {
            _stones.Sort((a, b) => a.CalculateCost().CompareTo(b.CalculateCost()));
        }

        public List<Stone> FindStonesByTransparency(double minTransparency, double maxTransparency)
        {
            List<Stone> matchingStones = new List<Stone>();

            foreach (Stone stone in _stones)
            {
                    if (stone.Transparency >= minTransparency && stone.Transparency <= maxTransparency)
                    {
                        matchingStones.Add(stone);
                    }
            }

            return matchingStones;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PreciousStone diamond = new PreciousStone("Diamond", 2.5, 10000, 4);
            PreciousStone emerald = new PreciousStone("Emerald", 1.8, 5000, 5);
            SemiPreciousStone amethyst = new SemiPreciousStone("Amethyst", 3.2, 4000, 6);
            SemiPreciousStone topaz = new SemiPreciousStone("Topaz", 2.7, 3500, 9);

            Necklace necklace = new Necklace();

            necklace.AddStone(diamond);
            necklace.AddStone(emerald);
            necklace.AddStone(amethyst);
            necklace.AddStone(topaz);

            Console.WriteLine("Necklace Information:");
            Console.WriteLine("---------------------");

            Console.WriteLine("Total Weight: {0} carats", necklace.CalculateTotalWeight());
            Console.WriteLine("Total Cost: ${0:N2}", necklace.CalculateTotalCost());

            necklace.SortByValue();

            Console.WriteLine("\nSorted Stones:");
            foreach (Stone stone in necklace.Stones)
            {
                Console.WriteLine("{0}: {1}, cost: ${2}, transparency: {3}", stone.Name, stone.CaratWeight, stone.CalculateCost(), stone.Transparency);
            }

            Console.WriteLine("\nPrecious Stones with Transparency between 4 - 8:");
            List<Stone> matchingStones = necklace.FindStonesByTransparency(4, 8);

            foreach (Stone stone in matchingStones)
            {
                Console.WriteLine("{0}: {1}, cost: ${2}, transparency: {3}", stone.Name, stone.CaratWeight, stone.CalculateCost(), stone.Transparency);
            }

            Console.ReadLine();
        }
    }
}