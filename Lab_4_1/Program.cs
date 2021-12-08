using System;

namespace Lab_4_1
{
    class Quadrate
    {
        public double size { get; set; }
        public string color { get; set; }

        public Quadrate(double size)
        {
            this.size = size;
        }

        public Quadrate(double size, string color)
        {
            this.size = size;
            this.color = color;
        }

        public virtual void ToString()
        {
            Console.WriteLine($"Поточний розмiр квадрата становить: {size} та початковий колiр {color}");
        }
    }

    class PointsOnGraph : Quadrate
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }

        public double[] x = new double[2];
        public double[] y = new double[2];

        public PointsOnGraph(double a) : base(a)
        {
            this.x1 = -a;
            this.y1 = a;
            this.x2 = a;
            this.y2 = -a;
            x[0] = x1;
            x[1] = x2;
            y[0] = y1;
            y[1] = y2;
        }

        public override void ToString()
        {
            Console.WriteLine("Координати квадрата на графiку: ");
            Console.WriteLine($"X = ({x[0]}, {x[1]}), Y = ({y[0]}, {y[1]})");
        }
    }

    class Segment : PointsOnGraph
    {
        public Segment(double a) : base(a) { }

        void Stretching()
        {
            Console.WriteLine("Розтягнення утричi:");
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i] * 3;
            }
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = y[i] * 3;
            }
            Console.WriteLine($"X = ({x[0]}, {x[1]}), Y = ({y[0]}, {y[1]})");
        }

        void Compression()
        {
            Console.WriteLine("Стиснення у два з половиною рази:");
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Math.Round(x[i] / 2.5, 2);
            }
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Math.Round(y[i] / 2.5, 2);
            }
            Console.WriteLine($"X = ({x[0]}, {x[1]}), Y = ({y[0]}, {y[1]})");
        }

        public override void ToString()
        {
            Stretching();
            Compression();
            Console.WriteLine("Поворот лiворуч:");
            Console.WriteLine($"X = ({x[0]}, {x[1]}), Y = ({y[0]}, {y[1]})");
            Console.Write("Змiна кольору: ");
            color = Console.ReadLine();
            Console.WriteLine($"Колiр фiруги за таким координатами: X = ({x[0]}, {x[1]}), Y = ({y[0]}, {y[1]}) становить {color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть розмiр квадрата: ");
            double size = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введiть колiр квадрата: ");
            string color = Console.ReadLine();
            Quadrate q = new Quadrate(size, color);
            q.ToString();
            PointsOnGraph p = new PointsOnGraph(size);
            p.ToString();
            Segment s = new Segment(size);
            s.ToString();
        }
    }
}
