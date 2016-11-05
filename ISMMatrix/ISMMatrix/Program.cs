using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMMatrix
{
   

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int i=0, j=0;
            Console.WriteLine("Введите размер матрицы");
            try
            {
                while (i == 0 | j == 0)
                {
                    i = int.Parse(Console.ReadLine());
                    j = int.Parse(Console.ReadLine());
                }
                if (i == 0 | j == 0) throw new SystemException("Одне з значень рівне нулю");
               int [,] matr=new int[i,j];
               Input(matr, i, j);
               Console.Clear();
               Print(matr);
               Console.WriteLine("Кiлькiсть рядкiв , якi не мiстять жодного нульового елементу : {0}", CountLines(matr, i, j));
               Console.WriteLine("Кiлькiсть стовпців , які містять хоча б один нульовий елемент : {0}", CountOfColumnWithZero(matr));
               Console.WriteLine("Максимальне із чисел , що зустрічається в заданій матриці більше одного разу : {0}", MaxItemMorePne(matr));
               Console.WriteLine("Номер першого рядка , в якому знаходиться найдовша серія однакових елементів : {0}", NumberOfRowWIthMax(matr));
               Console.WriteLine("Добуток елементів в тих рядках , які не містять від'ємних елементів : {0}", MulWithoutNull(matr));
               Console.WriteLine("Суму елементів в тих стовпцях , які не містять від'ємних елементів : {0}", SumOfRowsWithoutNeg(matr));
               Console.WriteLine("Суму елементів в тих стовпцях , які містять хоча б один від'ємний елемент : {0}", SumOfRowsWithNeg(matr));
               Console.WriteLine("Максимум серед сум елементів діагоналей, паралельних головній діагоналі  матриці : {0}", SumOfDiagonal1(matr));
               Console.WriteLine("Мінімум серед сум модулей елементів діагоналей, паралельних побічній діагоналі  матриці : {0}", SumOfDiagonal2(matr));
               matr = Tranc(matr);
               Console.WriteLine("Транспонування :"); Print(matr);
               
            }
             
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }

            
        }

       static void Print(int[,]mat )
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

       static int[,] Input(int[,] mat, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                   mat[i,j]=int.Parse(Console.ReadLine());
                }
            }
            return mat;
        }

    
        static int MaxItemMorePne(int[,]mat)
       {
           int[] mass = new int[mat.GetLength(0)*mat.GetLength(1)];
           int count=0;
           int max = 0;
           int p = 0;
            for(int i=0 ; i<mat.GetLength(0) ; i++)
            {
                count = 0;
                for(int j=0 ; j<mat.GetLength(1) ; j++)
                {
                    count = 0;
                    int elem = mat[i, j];
                    for (int k = 0; k < mat.GetLength(0); k++)
                    {
                        for (int l = 0; l < mat.GetLength(1); l++)
                        {
                            if (elem == mat[k, l]) count++;
                        }
                    }
                    if (count > 1) mass[p] = mat[i, j];
                    p++;
                }
            }
            for(int i=0 ; i<p ; i++)
            {
                if (mass[i] > max) max = mass[i];
            }
            return max;
       }

        static int CountLines(int[,]mat , int row , int col)
        {
            int count = 0;
            for (int i = 0; i < row; i++)
            {
                int k = 0;
                for (int j = 0; j < col; j++)
                {
                    if (mat[i, j] == 0) k++;
                }
                if (k == 0) count++;
            }
             return count;
        }

        static int CountOfColumnWithZero(int [,] mat)
        {
            int count = 0;
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                int k = 0;
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (mat[j, i] == 0) k++;
                }
                if (k > 0) count++;
            }
            return count;
        }

        static int NumberOfRowWIthMax(int[,] mat)
        {
            int max = 0;
            int number=0;
            int count=0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    count = 0;
                    int elem=mat[i,j];
                    for(int k=0 ; k<mat.GetLength(1) ; k++)
                    {
                        if (elem == mat[i, k]) count++;
                    }
                    if (count > max) { max = count; number = i; }

                }
            }
            return number+1;
        }

        static int MulWithoutNull(int[,]mat)
        {
            int mul = 1;
            int NuLL = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                NuLL = 0;
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] < 0) NuLL++;
                }
                if(NuLL==0)
                for (int k = 0; k < mat.GetLength(1); k++)
                {
                    mul *= mat[i, k];
                }
            }
            return mul;
        }

        static int SumOfRowsWithoutNeg(int[,] mat)
        {
            int sum = 0;
            int nul=0;
            for(int i=0 ; i<mat.GetLength(1);i++)
            {
                for(int j=0 ; j<mat.GetLength(0);j++)
                {
                    if (mat[j, i] < 0) nul++;
                }
                if (nul == 0)
                {
                    for (int k = 0; k < mat.GetLength(0); k++)
                        sum += mat[k, i];
                }
            }
            return sum;
        }

        static int SumOfRowsWithNeg(int[,] mat)
        {
            int sum = 0;
            int nul = 0;
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                nul = 0;
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (mat[j, i] < 0) nul++;
                }
                if (nul > 0)
                {
                    for (int k = 0; k < mat.GetLength(0); k++)
                        sum += mat[k, i];
                }
            }
            return sum;
        }

        static int[,] Tranc(int[,]mat)
        {
            int[,] tranc = new int[mat.GetLength(1), mat.GetLength(0)];
            int k = 0, l = 0;
            for(int i=0 ; i<mat.GetLength(0);i++)
            {
                k = 0;
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    tranc[k, l] = mat[i, j];
                    k++;
                }
                l++;
            }
            return tranc;
        }

        static int SumOfDiagonal1(int[,] mat)
        {
            int[] mass = new int[mat.GetLength(0)+mat.GetLength(1)];
            int sum = 0;
            int max = 0;
            int i=1 , j=0;
            int p=0;
            int outt=1;
            //сума нижніх діагоналей
            while(i!=mat.GetLength(0)&j!=mat.GetLength(1))
            {
                sum = 0;
                int k=i,l=j;
                 while (k != mat.GetLength(0) & l != mat.GetLength(1))
                {
                    sum += mat[k, l];
                    k++;
                    l++;
                }
                i++;
                j = 0;
                mass[p] = sum;
                outt++;
                p++;
            }
            i = 0;
            j = 1;
            outt = 2;
            //сума верхніх діагоналей
            while (i != mat.GetLength(0) & j != mat.GetLength(1) )
            {
                sum = 0;
                int k = i, l = j;
                while (k != mat.GetLength(0) & l != mat.GetLength(1) )
                {
                    sum += mat[k, l];
                    k++;
                    l++;
                }
                j++;
                i = 0;
                mass[p] = sum;
                outt++;
                p++;
            }
            for(int t=0 ; t<p ; t++)
            {
                if (mass[t] > max) max = mass[t];
            }
            return max;
        }

        static int SumOfDiagonal2(int[,] mat)
        {
            int[] mass = new int[mat.GetLength(0) + mat.GetLength(1)];
            int sum = 0;
            int min = 10000;
            int i = 0, j = mat.GetLength(1)-2;
            int p = 0;
            int outt = 1;
            //сума над побічною
            while (i != mat.GetLength(0)-1 & j != -1)
            {
                sum = 0;
                int k = i, l = j;
                while (k != mat.GetLength(0) & l != -1)
                {
                    sum += Math.Abs(mat[k, l]);
                    k++;
                    l--;
                }
                i=0;
                j --;
                mass[p] = sum;
                outt++;
                p++;
            }
            i = 1;
            j = mat.GetLength(1)-1;
            outt =1;
            //сума під побічною
            while (i !=mat.GetLength(0) & j !=-1)
            {
                sum = 0;
                int k = i, l = j;
                while (k != mat.GetLength(0) & l != -1)
                {
                    sum += Math.Abs(mat[k, l]);
                    k++;
                    l--;
                }
                i++;
                j=mat.GetLength(1)-1;
                mass[p] = sum;
                outt++;
                p++;
            }
            for (int t = 0; t < p; t++)
            {
                if (mass[t] < min) min = mass[t];
            }
            return min;
        }
    }
}
