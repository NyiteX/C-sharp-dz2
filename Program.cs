using System.Security.Cryptography.X509Certificates;

class MassiveBasic
{
    protected Random rnd = new Random();
    protected int x, y, s;
    protected double[] A;
    protected double[,] B;
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
    public bool ProverWithMinus(string str)
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
}
class Massive_1: MassiveBasic
{
    public Massive_1(int X, int Y, int S)
    {       
        x = X;
        y = Y;
        s = S;
        A = new double[X];
        B = new double[Y, S];
        Rand();
    }
    public Massive_1(int Y, int S)
    {
        y = Y;
        s = S;
        B = new double[Y, S];
    }
    
    public void Summ()
    {
        double min = B[0, 0], max = B[0, 0];
        int iMin = 0, iMax = 0, kol = 0;
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                kol++;
                if (min > B[i, u])
                {
                    min = B[i, u];
                    iMin = kol;
                }
                if (max < B[i, u])
                {
                    max = B[i, u];
                    iMax = kol;
                }
            }
        }
        if (iMin > iMax)
        {
            int te = iMin;
            iMin = iMax;
            iMax = te;
        }
        kol = 0;
        Console.WriteLine("min = " + min + "\nmax = " + max);
        bool f = false;
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                kol++;
                if (kol == iMin) f = true;
                if (kol > iMax) f = false;
                if (f) Console.Write(B[i, u] + "\t");
            }
        }
        Console.WriteLine();
    }
    public void Vvod1D()
    {
        Console.WriteLine("Enter " + x + "elements.");
        string str = "adsad";
        
        for (int i = 0; i < x; i++)
        {
            while (!ProverWithMinus(str))
            {
                Console.Write((i + 1) + " element: ");
                str = Console.ReadLine();
                if (!ProverWithMinus(str)) Console.WriteLine("Wrong input");
                else 
                    A[i] = int.Parse(str);               
            }
            str = "asdkasd";
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
    public void Rand(int a, int b)
    {
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                B[i, u] = rnd.Next(a, b);
            }
        }
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
    public void Umnozh()
    {
        string str = "adsad";
        int num = 0;
        while (!ProverWithMinus(str))
        {
            Console.WriteLine("Umnozhenie na(chislo): ");
            str = Console.ReadLine();
            if (!ProverWithMinus(str)) Console.WriteLine("Wrong input");
            else 
                num = int.Parse(str);
        }
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                B[i, u] *= num;
            }
        }
    }
    public void MatrixMath()
    {
        double[,] B2 = new double[y, s];
        PrintMas2D();
        Console.WriteLine("Second 2D mas");
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                B2[i, u] = Math.Round(rnd.NextDouble() * 100, 2);
                Console.Write(B2[i, u]+"\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nUmnozhenie massivov");
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                Console.Write(Math.Round(B2[i, u] * B[i, u],2) +"\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nSumma massivov");
        for (int i = 0; i < y; i++)
        {
            for (int u = 0; u < s; u++)
            {
                Console.Write(Math.Round(B2[i, u] + B[i, u]) + "\t");
            }
            Console.WriteLine();
        }
    }
    
}
class Programm
{
    static void Main()
    {        
        char vvod;
        do
        {
            Console.Clear();
            Console.WriteLine("1.Part 1\n2.Part 2\n3.Part 3\n4.Part 4\n5.Part 5\n6.Part 6\n7.Part 7\n");
            vvod = Console.ReadKey().KeyChar;

            switch (vvod)
            {
                case '1':
                    {
                        const int D1x = 5;
                        const int D2x = 3;
                        const int D2y = 4;
                        Massive_1 M = new Massive_1(D1x, D2x, D2y);
                        Console.Clear();
                        M.Vvod1D();
                        M.PrintMas1D();
                        M.PrintMas2D();
                        M.Max_Min();
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '2':
                    {
                        Console.Clear();
                        Massive_1 M2 = new Massive_1(5, 5);
                        M2.Rand(-100, 100);
                        M2.PrintMas2D();
                        M2.Summ();
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '3':
                    {
                        Console.Clear();
                        Console.WriteLine("Cesar =/");

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '4':
                    {
                        Console.Clear();
                        Massive_1 M2 = new Massive_1(5, 5);
                        M2.Rand(-100, 100);
                        M2.PrintMas2D();
                        M2.Umnozh();
                        M2.PrintMas2D();
                        Console.WriteLine("\nNext part: Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        M2.Rand(-10, 10);
                        M2.MatrixMath();
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '5':
                    {
                        Console.Clear();
                        
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '6':
                    {
                        Console.Clear();

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '7':
                    {
                        Console.Clear();

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
            }
        } while (vvod != 27);

    }
}