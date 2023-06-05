using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Library
{
    public interface ICharacterBuild
    {
        ICharacterBuild SetHeight(double height);
        ICharacterBuild SetStructure(string structure);
        ICharacterBuild SetHairColor(string color);
        ICharacterBuild SetEyeColor(string color);
        ICharacterBuild SetClothing(string clothing);
        ICharacterBuild SetInventory(List<string> inventory);
        ICharacterBuild SetGun(string gun);
    }
    
    public class Hero
    {
        public double Height { get; set; }
        public string Structure { get; set; }
        public string HairColor { get; set;}
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; }
        public string Gun { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine("Hero's info:");
            Console.WriteLine($"Height: {Height} m");
            Console.WriteLine($"Build: {Structure}");
            Console.WriteLine($"Hair color: {HairColor}");
            Console.WriteLine($"Eye color: {EyeColor}");
            Console.WriteLine($"Clothing: {Clothing}");
            Console.WriteLine($"Inventory: {String.Join(',', Inventory.ToArray())}");
        }
    }
    public class Enemy
    {
        public double Height { get; set; }
        public string Structure { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; }
        public string Gun { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine("Enemy's info:");
            Console.WriteLine($"Height: {Height} m");
            Console.WriteLine($"Build: {Structure}");
            Console.WriteLine($"Hair color: {HairColor}");
            Console.WriteLine($"Eye color: {EyeColor}");
            Console.WriteLine($"Clothing: {Clothing}");
            Console.WriteLine($"Inventory: {String.Join(',',Inventory.ToArray())}");
        }
    }


    public class HeroBuilder : ICharacterBuild
    {
        private Hero _hero = new Hero();

        public ICharacterBuild SetClothing(string clothing)
        {
            _hero.Clothing = clothing;
            return this;
        }

        public ICharacterBuild SetEyeColor(string color)
        {
            _hero.EyeColor = color;
            return this;
        }

        public ICharacterBuild SetGun(string gun)
        {
           _hero.Gun = gun;
            return this;
        }

        public ICharacterBuild SetHairColor(string color)
        {
            _hero.HairColor = color;
            return this;
        }

        public ICharacterBuild SetHeight(double height)
        {
            _hero.Height = height;
            return this;
        }

        public ICharacterBuild SetInventory(List<string> inventory)
        {
            _hero.Inventory = inventory;
            return this;
        }

        public ICharacterBuild SetStructure(string structure)
        {
            _hero.Structure = structure;
            return this;
        }
        public Hero GetResult()
        {
            return _hero;
        }
    }
    public class EnemyBuilder : ICharacterBuild
    {
        private Enemy _enemy = new Enemy();

        public ICharacterBuild SetClothing(string clothing)
        {
            _enemy.Clothing = clothing;
            return this;
        }

        public ICharacterBuild SetEyeColor(string color)
        {
            _enemy.EyeColor = color;
            return this;
        }

        public ICharacterBuild SetGun(string gun)
        {
            _enemy.Gun = gun;
            return this;
        }

        public ICharacterBuild SetHairColor(string color)
        {
            _enemy.HairColor= color;
            return this;
        }

        public ICharacterBuild SetHeight(double height)
        {
            _enemy.Height = height;
            return this;
        }

        public ICharacterBuild SetInventory(List<string> inventory)
        {
            _enemy.Inventory = inventory;
            return this;
        }

        public ICharacterBuild SetStructure(string structure)
        {
            _enemy.Structure = structure;
            return this;
        }
        public Enemy GetResult()
        {
            return _enemy;
        }
    }
    public class CharacterDirector
    {
        private readonly ICharacterBuild _build;
        public CharacterDirector(ICharacterBuild build)
        {
            _build = build;
        }

        public void Build(double heighg, string structure, string? heirColor = null, string? eyeColor = null, string? clothing = null, List<string>? inventory = null, string? gun = null)
        {
            _build
             .SetHeight(heighg)
             .SetStructure(structure);
            if(heirColor != null)
            {
                _build.SetHairColor(heirColor);
            }
            if(eyeColor != null)
            {
                _build.SetEyeColor(eyeColor);
            }
            if(clothing != null)
            {
                _build.SetClothing(clothing);
            }
            if(inventory != null)
            {
                _build.SetInventory(inventory);
            }
            if(gun != null)
            {
                _build.SetGun(gun);
            }
        }
    }
}
