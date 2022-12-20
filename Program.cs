// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine("Задача 54. Упорядочит по убыванию элементы каждой строки");
Console.Write("Введите количество строк массива: ");
var rows = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов массива: ");
var columns = int.Parse(Console.ReadLine());
var minval = 1;
var maxval = 10;

int[,] array = GetRandomArray(rows, columns, minval, maxval);
PrintArray(array);
DescendingArray(array);
Console.WriteLine("Отсортировано по убыванию");
PrintArray(array);


int[,] GetRandomArray(int row, int column, int minValue, int maxValue)
{
    var rnd = new Random();
    int[,] result = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
           result[i, j] = rnd.Next(minValue, maxValue);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

void DescendingArray(int[,] desArray)
{
    for (int i = 0; i < desArray.GetLength(0); i++)
    {
        for (int j = 0; j < desArray.GetLength(1) - 1; j++)
        {
            int temp = j;                          // переменная для индекса столбца максимального числа
            for (int m = j + 1; m < desArray.GetLength(1); m++)
            {
                if (desArray[i, m] > desArray[i, temp])
                {
                    temp = m;  
                }
            }
            int maxnum = desArray[i, temp];         // максимальное число помещаем во временную переменную
            desArray[i, temp] = desArray[i, j];     // на ее место записываем текущий элемент i j
            desArray[i, j] = maxnum;                // в данной перестановке сортировка слева на право, на убывание 
        }
    }
}


// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и 
// выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.WriteLine("Задача 56. Найдет строку с наименьшей суммой элементов");
Console.Write("Введите число, которое определит количество строк и столбцов в прямоугольном массиве: ");
var enternum = int.Parse(Console.ReadLine());
var rw = enternum;
var cl = enternum;

array = GetRandomArray(rw, cl, minval, maxval);
PrintArray(array);
MinSumRowArray(array);
Console.WriteLine();

void MinSumRowArray(int[,] msrArray)
{   
    int [] minsum = new int[msrArray.GetLength(0)];
    for (int i = 0; i < msrArray.GetLength(0); i++)
    {
        int t = i;
        for (int j = 0; j < msrArray.GetLength(1); j++)
        {
            minsum[t] = minsum[t] + msrArray[i, j];
        }
        Console.WriteLine($"Сумма элементов строки {t + 1} равна: {minsum[t]}");
    }
    int result = 0;
    for (int t = 0; t < minsum.GetLength(0) - 1; t++)
    {   
        for (int temp = t + 1; temp <  minsum.GetLength(0); temp++)
        {
            if (minsum[temp] < minsum[result])
            {
                result = temp;
            }
        }
    }
    Console.WriteLine($"Строка с наименьшей суммой элементов - {result +1}");
}



// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.WriteLine("Задача 58. Надет произведение двух матриц");
Console.Write("Введите количество строк двух матриц: ");
var row = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов двух матриц: ");
var column = int.Parse(Console.ReadLine());

int[,] array1 = GetRandomArray(row, column, minval, maxval);
int[,] array2 = GetRandomArray(row, column, minval, maxval);
int[,] resultArray = workArray(row, column, array1, array2);

PrintArray(array1);
Console.WriteLine();
PrintArray(array2);
Console.WriteLine("Результат произведения двух матриц");
PrintArray(resultArray);

int[,] workArray(int row, int column, int [,] inarray1, int [,] inarray2)
{
    int[,] resultArray = new int[row, column];
    for (int i = 0; i < inarray1.GetLength(0); i++)
    {
        for (int j = 0; j < inarray2.GetLength(1); j++)
        {
             for (int k = 0; k < inarray2.GetLength(0); k++)
                    {
                        resultArray[i, j] += inarray1[i, k] * inarray2[k, j];
                    }    
        }       
    }
    return resultArray;
}

// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.WriteLine("Задача 60. Выведет 3D массив с индексами");
Console.Write("Введите количество строк 3D массива: ");
var row3d = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов 3D массива: ");
var column3d = int.Parse(Console.ReadLine());

Console.Write("Введите глубину 3D массива: ");
var depth3d = int.Parse(Console.ReadLine());
var minVal = 10;
var maxVal = 100;

int[,,] array3D = GetRandomArray3d(row3d, column3d, depth3d, minVal, maxVal);
PrintArray3D(array3D);

int[,,] GetRandomArray3d(int row3d, int column3d, int depth3d, int minValue, int maxValue)
{
    var rnd = new Random();
    int[,,] array3D = new int[row3d, column3d, depth3d];
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
           for (int z = 0; z < array3D.GetLength(2); z++)
           {
                array3D[x, y, z] = rnd.Next(minValue, maxValue);
           }
            
        }
    }
    return array3D;
}

void PrintArray3D(int[,,] inArray)
{
    for (int z = 0; z < inArray.GetLength(2); z++)
    {
        for (int x = 0; x < inArray.GetLength(0); x++)
        {
            for (int y = 0; y < inArray.GetLength(1); y++)
            {
                Console.Write($"{inArray[x, y, z]}{(x, y, z)} "); 
            }
            Console.WriteLine();
        }
        
    }
}





// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("Задача 62. Заполнит массив по часовой стрелке");
Console.Write("Введите количество строк и столбцов массива в пределах от 2 до 9: ");
var numS = int.Parse(Console.ReadLine());

if (numS > 1 & numS < 10)
{ 
    int numSpiral = numS;
    
    int[,] arraySpiral = GetSpiralArray(numSpiral, numSpiral);
    
    PrintArray(arraySpiral);

    int[,] GetSpiralArray(int row, int column)
    {
        int[,] arraySpiral = new int[row, column];
        int temp = 0;
        int horizon0 = 0;
        int horizonCol = column - 1;
        int vertical0 = 0;
        int verticalRow = row - 1;
        while (temp < row * column)
        {                
            for (int j = horizon0; j <= horizonCol; j++)
            {
                arraySpiral[vertical0, j] = ++temp;
            }
            vertical0++;
               
            for (int i = vertical0; i <= verticalRow; i++)
            {
                arraySpiral[i, horizonCol] = ++temp;
            }    
            horizonCol--;
            
            for (int j = horizonCol; j >= horizon0; j--)
            {
                arraySpiral[verticalRow, j] = ++temp;
            }
            verticalRow--;

            for (int i = verticalRow; i >= vertical0; i--)
            {
                arraySpiral[i, horizon0] = ++temp;
            }
            horizon0++;
        }        
    return arraySpiral;
    }
}
else 
{
    Console.WriteLine($"Введеное число строк {numS}, не соответствет требуемому диапозону");
}
