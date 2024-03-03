using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    public class IdNumber
    {
        public int number;
        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                    throw new Exception("Number не может быть меньше 0");
                else
                    number = value;
            }
        }
        public IdNumber()
        {
            Number = 0;
        }
        public IdNumber(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is IdNumber n)
                return this.Number == n.Number;
            else
                return false;
        }
    }
    public abstract class Shape: IInit, IComparable, ICloneable
    {
        protected Random random = new Random();
        public IdNumber id;
        protected string Name { get; set; }
        public Shape()
        {
            Name = "фигура";
            id = new IdNumber();
        }
        public Shape(string name, int number)
        {
            Name = name;
            id = new IdNumber(number);
        }
        public Shape(Shape shape)
        {
            Name = shape.Name;
            id = shape.id;
        }
        public abstract double GetArea();
        protected double GetDouble(string message, double min, double max)
        {
            bool isConvert;
            double result;
            do
            {
                Console.WriteLine(message);
                isConvert = double.TryParse(Console.ReadLine(), out result);
                if (!isConvert || result < min || result > max)
                    Console.WriteLine("Ошибка ввода");
            }
            while (!isConvert || result < min || result > max);
            return result;
        }
        public virtual void Show()
        {
            Console.WriteLine($"ID: {id}, фигура: {Name}");
        }
        public virtual void Init()
        {
            id.number = (int)GetDouble("Введите ID", 0, 1000);
            Console.WriteLine("Введите название фигуры");
            Name = Console.ReadLine();
        }
        public virtual void RandomInit()
        {
            id.number = random.Next(0, 1000);
            Console.WriteLine("Введите название случайной фигуры");
            Name = Console.ReadLine();
        }
        public override bool Equals(object? obj)
        {
            Shape s = obj as Shape;
            return s != null && Name == s.Name;
        }
        public override string ToString()
        {
            return $"ID: {id}, фигура: {Name}";
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not  Shape) return -1;
            Shape s = (Shape)obj;
            return String.Compare(this.Name, s.Name);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
