using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    public class Parallelepiped: Rectangle
    {
        protected double height;
        public double Height
        {
            get => height;
            set
            {
                if (value < 0)
                    throw new Exception("Высота не может быть отрицательной");
                else
                    height = Math.Round(value, 2);
            }
        }
        public Parallelepiped(): base() 
        {
            Height = 0;
        }
        public Parallelepiped(string name, int number, double width, double length, double height): base(name, number, width, length) 
        {
            Height = height;
        }
        public Parallelepiped(Parallelepiped other): base(other)
        {
            this.Height = other.Height;
        }
        public override double GetArea()
        {
            return Width * Length * Height;
        }
        public override void Show()
        {
            Console.WriteLine($"Параллелепипед: {Name}, ширина: {Width}, длина: {Length}, высота: {Height}");
            Console.WriteLine($"Объём параллелепипеда: {GetArea()}");
        }
        public override void Init()
        {
            base.Init();
            Height = GetDouble("Введите высоту", 0, 100);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Height = random.NextDouble() + random.Next(0, 100);
        }
        public override bool Equals(object? obj)
        {
            Parallelepiped r = obj as Parallelepiped;
            return r != null && Name == r.Name && Width == r.Width && Length == r.Length && Height == r.Height;
        }
        public override string ToString()
        {
            return $"ID: {id}, параллелепипед: {Name}, ширина: {Width}, длина: {Length}, высота: {Height}";
        }
        public object Clone()
        {
            return new Parallelepiped(Name, id.number, Width, Length, Height);
        }
    }
}
