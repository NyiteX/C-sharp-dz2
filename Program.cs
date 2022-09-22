using System.Security.Cryptography.X509Certificates;

class Massive_1
{
    public Random rnd = new Random();
    private int x, y, s;
    private double[] A;
    private double[,] B;

    public Massive_1(int X, int Y, int S)
    {       
        x = X;
        y = Y;
        s = S;
        A = new double[X];
        B = new double[Y, S];
        Rand();
    }
    public bool Prover(string str)
    {
        if (str.Length > 0)
        {
            if (str[0] == '-' || Char.IsDigit(str[0]))
            {
                for (int i = 1; i < str.Length; i++)
                {
                    if (!Char.IsDigit(str[i]))
                        return false;
                }
            }
            else
                return false;
            return true;
        }
        return false;
    }
    public void Vvod1D()
    {
        Console.WriteLine("Enter " + x + "elements.");
        string str = "adsad";
        
        for (int i = 0; i < x; i++)
        {
            while (!Prover(str))
            {
                Console.Write((i + 1) + " element: ");
                str = Console.ReadLine();
                if (!Prover(str)) Console.WriteLine("Wrong input");
                else A[i] = int.Parse(str);
            }
            str = "adada";
        }
    }
    public void Rand()
    {
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                B[i, u] = Math.Round(rnd.NextDouble() * 100, 2);  //2 symbols after ' , '
            }           
        }
    }
    public void PrintMas1D()
    {
        Console.WriteLine("\t1D mas");
        for (int i = 0; i < x; i++)
        {
            Console.Write(A[i] + "\t");
        }
        Console.WriteLine("\n");
    }
    public void PrintMas2D()
    {
        Console.WriteLine("\t2D mas");
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                Console.Write(B[i, u] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public void Max_Min()
    {
        double max = B[0,0], min = B[0,0], summ = 0, proizv = 1, summChet = 0, summNeChet = 0;
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                if (max < B[i, u]) max = B[i, u];
                if (min > B[i, u]) min = B[i, u];
                if (i % 2 != 0 && i > 0) summNeChet += B[i, u];
                summ += B[i, u];
                proizv *= B[i, u];
            }
          
        }
        for (int i = 0; i < x; i++)
        {
            if (max < A[i]) max = A[i];
            if (min > A[i]) min = A[i];
            if (A[i] % 2 == 0) summChet += A[i];
            summ += A[i];
            proizv *= A[i];
        }
        Console.WriteLine("max = " + max);
        Console.WriteLine("min = " + min);
        Console.WriteLine("proizv = " + proizv);
        Console.WriteLine("summ = " + summ);
        Console.WriteLine("summ Chetnix 1D = " + summChet);
        Console.WriteLine("summ Ne Chetnix stolbcov 2D = " + summNeChet);
    }
    
}
class Massive_2
{
    public Random rnd = new Random();
    int x, y;
    private double[,] C;
    public Massive_2(int X, int Y)
    {
        x = X;
        y = Y;
        C = new double[X, Y];
    }
    public bool Prover(string str)
    {
        if (str.Length > 0)
        {
            if (str[0] == '-' || Char.IsDigit(str[0]))
            {
                for (int i = 1; i < str.Length; i++)
                {
                    if (!Char.IsDigit(str[i]))
                        return false;
                }
            }
            else
                return false;
            return true;
        }
        return false;
    }
    public void Rand()
    {
        for (int i = 0; i < x; i++)
        {
            for (int u = 0; u < y; u++)
            {
                C[i, u] = rnd.Next(-100,100);
            }
        }
    }
    public void PrintMas2D()
    {
        Console.WriteLine("\t2D mas");
        for (int i = 0; i < x; i++)
        {
            for (int u = 0; u < y; u++)
            {
                Console.Write(C[i, u] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public void Summ()
    {
        double min = C[0, 0], max = C[0, 0];
        int iMin = 0, iMax = 0,kol = 0;
        for (int i = 0; i < x; i++)
        {
            for (int u = 0; u < y; u++)
            {
                kol++;
                if (min > C[i, u])
                {
                    min = C[i, u];
                    iMin = kol;
                }
                if (max < C[i, u])
                {
                    max = C[i, u];
                    iMax = kol;
                }
            }
        }
        if(iMin > iMax)
        {
            int te = iMin;
            iMin = iMax;
            iMax = te;
        }
        kol = 0;
        Console.WriteLine("min = " + min + "\nmax = " + max);
        bool f = false;
        for (int i = 0; i < x; i++)
        {
            for (int u = 0; u < y; u++)
            {
                kol++;
                if (kol == iMin) f = true;
                if (kol > iMax) f = false;
                if (f) Console.Write(C[i, u] + "\t");
            }
        }
        Console.WriteLine();
    }
}
class Programm
{
    static void Main()
    {
        const int x = 5, y = 3, s = 4;
        Massive_1 M = new Massive_1(x, y, s);

        char vvod;
        do
        {
            Console.Clear();
            Console.WriteLine("1.Part 1\n2.Part 2\n3.Part 3\n4.Part 4\n5.Part 5\n6.Part 6\n7.Part 7\n");
            vvod = Console.ReadKey().KeyChar;

            switch (vvod)
            {
                case '1':
                    Console.Clear();
                    M.Vvod1D();
                    M.PrintMas1D();
                    M.PrintMas2D();
                    M.Max_Min();
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case '2':
                    Console.Clear();
                    Massive_2 M2 = new Massive_2(5, 5);
                    M2.Rand();
                    M2.PrintMas2D();
                    M2.Summ();
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    

                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case '4':
                    Console.Clear();
                    

                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case '5':
                    Console.Clear();
                    Console.WriteLine("Kalendar ? opyat ? no thx...");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case '6':
                    Console.Clear();
                    
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case '7':
                    Console.Clear();
                    
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
            }
        } while (vvod != 27);

    }
}