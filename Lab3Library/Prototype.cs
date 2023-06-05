using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Library
{
    public class Virus : ICloneable
    {
        protected int _weight { get; set; }
        protected int _age { get; set; }
        protected string _name { get; set; }
        protected string _type { get; set; }
        private List<Virus> _children { get; set; } = new List<Virus>();
        public Virus(int weight, int age, string name, string type)
        {
            _weight = weight;
            _age = age;
            _name = name;
            _type = type;
        }
        public Virus(int weight, int age, string name, string type, List<Virus> children)
        {
            _weight = weight;
            _age = age;
            _name = name;
            _children = children;
            _type= type;
        }

        public void AddChild<T> (T child) where T : Virus
        {
            _children.Add(child);
        }
        public void RemoveChild<T>(T child) where T : Virus
        {
            if (_children.Any((virus) => virus.GetHashCode() == child.GetHashCode()))
            {
                _children.Remove(child);
            }
            else
            {
                throw new Exception("Virus not find");
            }
        }
        public object Clone()
        {
            List<Virus> clonedChild = new List<Virus>();
            foreach (Virus child in _children)
            {
                clonedChild.Add(child);
            }
            return new Virus(_weight, _age, _name, _type, clonedChild);
        }
        public override string ToString()
        {
            return $"Name:{_name}\nType: {_type}\nWeight: {_weight}\nAge: {_age}";
        }
    }
    public class VirusChild : Virus
    {
        protected DateTime _birthDate { get; set; }
        protected Virus _parent { get; set; }
        public VirusChild(int weight, int age, string name, string type, DateTime birthDate, Virus parent) : base(weight, age, name, type)
        {
            _birthDate = birthDate;
            _parent = (Virus)parent;
            _parent.AddChild(this);
        }
        public void SetPerent(Virus perent)
        {
            perent.AddChild(this);
            _parent.RemoveChild(this);
        }
        public new object Clone()
        {
            return new VirusChild(_weight,_age,_name,_type, _birthDate, _parent);
        }
        public override string ToString()
        {
            return $"Name:{_name}\nType: {_type}\nWeight: {_weight}\nAge: {_age}\nDate of birth: {_birthDate.ToString()}\nParent Info:{_parent.ToString()}";
        }
    }
}
