using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Library
{
    public abstract class ClothingFactory
    {
        public abstract Shirt CreateShirt();
        public abstract Shoes CreateShoes();
        public abstract Hat CreateHat();
    }

    public abstract class Shirt{}
    public abstract class Shoes{}
    public abstract class Hat{}
    public class MenShirt : Shirt{ }
    public class MenShoes : Shoes{}
    public class MenHat : Hat{}
    public class WomenShirt : Shirt{}
    public class WomenShoes : Shoes{}
    public class WomenHat : Hat{}
    public class ChildrenShirt : Shirt{}
    public class ChildrenShoes : Shoes{}
    public class ChildrenHat : Hat{}
    public class MenClothingFactory : ClothingFactory
    {
        public override Hat CreateHat()
        {
            return new MenHat();
        }

        public override Shirt CreateShirt()
        {
           return new MenShirt();
        }

        public override Shoes CreateShoes()
        {
            return new MenShoes();
        }
    }
    public class WomenClothingFactory : ClothingFactory
    {
        public override Hat CreateHat()
        {
            return new WomenHat();
        }

        public override Shirt CreateShirt()
        {
           return new WomenShirt();
        }

        public override Shoes CreateShoes()
        {
            return new WomenShoes();
        }
    }
    public class ChildrenClothingFactory : ClothingFactory
    {
        public override Hat CreateHat()
        {
            return new ChildrenHat();
        }

        public override Shirt CreateShirt()
        {
            return new ChildrenShirt();
        }

        public override Shoes CreateShoes()
        {
            return new ChildrenShoes();
        }
    }
    public class Client
    {
        private ClothingFactory _factory;
        public Client(ClothingFactory clothingFactory)
        {
            _factory = clothingFactory;
        }
        public void MakeOrder()
        {
            Shirt shirt = _factory.CreateShirt();
            Shoes shoes = _factory.CreateShoes();
            Hat hat = _factory.CreateHat();

            Console.WriteLine($"Shirt: {shirt.GetType().Name}");
            Console.WriteLine($"Shoes: {shoes.GetType().Name}");
            Console.WriteLine($"Hat: {hat.GetType().Name}");
        }
    }
}
