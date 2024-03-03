using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    public class Circle:Shape
    {
        protected double radius;
        public double Radius
        {
            get => radius;
            set
            {
                if (value < 0)
                    throw new Exception("Радиус не может быть меньше 0");
                else
                    radius = Math.Round(value, 2);
            }
        }
        public Circle(): base()
        {
            Radius = 0;
        }
        public Circle(string name, int number, double radius) : base(name, number) 
        {
            Radius = radius;
        }
        public Circle(Circle other): base(other)
        {
            this.Radius = other.Radius;
        }
        public override double GetArea()
        {
            return Math.Pow(Radius, 2) * 3.14;
        }
        public override void Show()
        {
            Console.WriteLine($"Окружность: {Name}, радиус окружности: {Radius}");
            Console.WriteLine($"Площадь окружности: {GetArea()}");
        }
        public override void Init()
        {
            base.Init();
            Radius = GetDouble("Введите радиус окружности", 0, 100);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Radius = random.NextDouble() + random.Next(0, 100);
        }
        public override bool Equals(object? obj)
        {
            Circle c = obj as Circle;
            return c != null && Name == c.Name && Radius == c.Radius;
        }
        public override string ToString()
        {
            return $"ID: {id}, окружность: {Name}, радиус окружности: {Radius}";
        }
        public object Clone()
        {
            return new Circle(Name, id.number, Radius);
        }
    }
}
