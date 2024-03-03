using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    public class Rectangle: Shape
    {
        protected double width;
        protected double length;
        public double Width
        {
            get => width;
            set
            {
                if (value < 0)
                    throw new Exception("Ширина не может быть отрицательным");
                else
                    width = Math.Round(value, 2);
            }
        }
        public double Length
        {
            get => length;
            set
            {
                if (value < 0)
                    throw new Exception("Длина не может быть отрицательным");
                else
                    length = Math.Round(value, 2);
            }
        }
        public Rectangle() : base() 
        {
            Width = 0;
            Length = 0;
        }
        public Rectangle(string name, int number, double width, double length): base(name, number)
        {
            Width = width;
            Length = length;
        }
        public Rectangle(Rectangle other) : base(other)
        {
            this.Width = other.Width;
            this.Length = other.Length;
        }
        public override double GetArea()
        {
            return Width * Length;
        }
        public bool IsSquare()
        {
            return Width == Length;
        }
        public override void Show()
        {
            Console.WriteLine($"Прямоугольник: {Name}, ширина: {Width}, длина: {Length}");
            Console.WriteLine($"Площадь прямоугольника: {GetArea()}");
        }
        public override void Init()
        {
            base.Init();
            Width = GetDouble("Введите ширину", 0, 100);
            Length = GetDouble("Введите длину", 0, 100);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Width = random.NextDouble() + random.Next(0, 100);
            Length = random.NextDouble() + random.Next(0, 100);
        }
        public override string ToString()
        {
            return $"ID: {id}, прямоугольник: {Name}, ширина: {Width}, длина: {Length}";
        }
        public override bool Equals(object? obj)
        {
            Rectangle r = obj as Rectangle;
            return r != null && Name == r.Name && Width == r.Width && Length == r.Length;
        }
        public object Clone()
        {
            return new Rectangle(Name, id.number, Width, Length);
        }
    }
}
