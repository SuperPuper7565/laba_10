using laba_9;
using System.Dynamic;
namespace laba_10;

internal class Program
{
    static double GetDouble(string message, double min, double max)
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
    static void AllSquareAreas(Shape[] shapes)
    {
        foreach (Shape shape in shapes)
        {
            if (shape is Rectangle r && !(shape is Parallelepiped))
            {
                if (r.IsSquare())
                    r.Show();
            }
        }
    }
    static void ShapesWithRightRadius(Shape[] shapes)
    {
        double radius = GetDouble("Введите радиус описанной окружности", 0, 100);
        Console.WriteLine("Такой радиус описанной окружности у следующих прямоугольников:");
        foreach (Shape shape in shapes)
        {
            if (shape is Rectangle r && !(shape is Parallelepiped))
            {
                if (Math.Pow(r.Width, 2) + Math.Pow(r.Length, 2) == Math.Pow(radius * 2, 2))
                    r.Show();
            }
        }
    }
    static void ShapesWithRightArea(Shape[] shapes)
    {
        double area = GetDouble("Введите минимально возможную для фигуры площадь", 0, 10000);
        foreach (Shape shape in shapes)
        {
            if (shape is Rectangle && !(shape is Parallelepiped) || (shape is Circle))
            {
                if (shape.GetArea() >= area)
                    shape.Show();
            }
        }
    }
    static void Main(string[] args)
    {
        Circle c1 = new Circle();
        Circle c2 = new Circle("Михаил Круг", 96, 69);
        Circle c3 = new Circle();
        c3.Init();
        Circle c4 = new Circle();
        c4.RandomInit();
        Circle c5 = new Circle(c4);
        Rectangle r1 = new Rectangle();
        Rectangle r2 = new Rectangle("Алексей Квадрат", 15, 15, 15);
        Rectangle r3 = new Rectangle();
        r3.Init();
        Rectangle r4 = new Rectangle();
        r4.RandomInit();
        Rectangle r5 = new Rectangle(r4);
        Parallelepiped p1 = new Parallelepiped();
        Parallelepiped p2 = new Parallelepiped("Иван Куб", 15, 15, 15, 15);
        Parallelepiped p3 = new Parallelepiped();
        p3.Init();
        Parallelepiped p4 = new Parallelepiped();
        p4.RandomInit();
        Parallelepiped p5 = new Parallelepiped(p4);
        Shape[] shapes = { c1, c2, c3, c4, c5, r1, r2, r3, r4, r5, p1, p2, p3, p4, p5 };
        //foreach (Shape shape in shapes )
        //    shape.Show();
        //AllSquareAreas(shapes);
        //ShapesWithRightArea(shapes);
        ShapesWithRightRadius(shapes);
        IInit[] init = new IInit[20];
        for (int i = 0; i < 15; i++)
            init[i] = shapes[i] as IInit;
        for (int i = 15; i < 20; i++)
        {
            Car car = new Car();
            car.RandomInit();
            init[i] = car as IInit;
        }
        foreach (IInit item in init)
            Console.WriteLine(item);
        Rectangle find = new Rectangle("Найди меня", 3, 15, 2);
        shapes[0] = find;
        Array.Sort(shapes);
        foreach (Shape shape in shapes)
            Console.WriteLine(shape);
        Console.WriteLine($"Найди меня, я под номером {Array.BinarySearch(shapes, find) + 1}");
        Circle[] circles = { c1, c2, c3, c4, c5 };
        Array.Sort(circles, new SortByRadius());
        foreach (Shape shape in circles)
            Console.WriteLine(shape);
        Console.WriteLine();
        Rectangle orig = new Rectangle();
        orig.RandomInit();
        Rectangle clone = orig.Clone() as Rectangle;
        Rectangle copy = orig.ShallowCopy() as Rectangle;
        Console.WriteLine("do izmeneniy");
        Console.WriteLine(orig);
        Console.WriteLine(clone);
        Console.WriteLine(copy);
        Console.WriteLine("posle izmeneniy");
        copy.Width = 10;
        copy.id.Number = 1;
        clone.id.Number = 2;
        clone.Width = 15;
        Console.WriteLine(orig);
        Console.WriteLine(clone);
        Console.WriteLine(copy);

    }
}
