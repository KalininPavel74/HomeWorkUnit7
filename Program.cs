// Калинин Павел 23.10.2022 
// Знакомство с языками программирования (семинары)
// Урок 7. Как не нужно писать код. Часть 1
// Домашняя работа

bool isRepeat = true; 
string s = "";
string taskName = "";

void FillArray(int[,] aAr, int aMin, int aMax) {
    Random random = new Random();
    for(int i=0; i<aAr.GetLength(0); i++)
        for(int j=0; j<aAr.GetLength(1); j++)
            aAr[i,j] = random.Next(aMin, aMax);
}
void PrintArray(int[,] aAr) {
    for(int i=0; i<aAr.GetLength(0); i++) {
        for(int j=0; j<aAr.GetLength(1); j++)
            Console.Write($"{aAr[i,j]} ");
        Console.WriteLine();
    }    
}

int[,] ar = null;

taskName = "Задание  №1. Написать программу, упорядочивания по убыванию"
         +" элементы каждой строки двумерной массива.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк двумерного массива: ");
    int qtyRow = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов двумерного массива: ");
    int qtyCol = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[qtyRow,qtyCol];
    FillArray(ar, 0,10);    
    Console.WriteLine("Двумерный массив задан:");
    PrintArray(ar);
    for(int i=0; i<ar.GetLength(0); i++) 
        SortRowArray(ar, i);
    Console.WriteLine("Ответ:");
    PrintArray(ar);
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

void SortRowArray(int[,] aAr, int aRow) {
    int len = aAr.GetLength(1);
    int temp;
    bool isMove = true;
    while(isMove) {
        isMove = false;
        for(int j=0, i=aRow; j<len-1; j++) {
            if(aAr[i,j]>aAr[i,j+1]) {
                temp = aAr[i,j];
                aAr[i,j] = aAr[i,j+1];
                aAr[i,j+1] = temp;
                if(!isMove) isMove = true;
            }
        }
    }        
}


// if(false) { // выборочно отключить для отладки

taskName = "Задание  №2. Написать программу, которая в двумерном массиве"
         +" заменяет строки на столбцы или сообщить, что это невозможно"
         +" (в случае, если матрица не квадратная).";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк двумерного массива: ");
    int qtyRow = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов двумерного массива: ");
    int qtyCol = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[qtyRow,qtyCol];
    FillArray(ar, 0,10);    
    Console.WriteLine("Двумерный массив задан:");
    PrintArray(ar);
    Console.WriteLine("Ответ:");
    if(qtyCol != qtyRow)
        Console.WriteLine("Не возможно заменить строки на столбцы,"
                         +" потому что матрица не квадратная.");
    else {
        ChangeRowCollArray(ar);
        PrintArray(ar);
    }    
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

void ChangeRowCollArray(int[,] aAr) {
    int len = aAr.GetLength(0);
    // диагональ не трогать и единичную матрицу тоже
    // начать с матрицы размерностью 2: n=2 
    int temp;
    for(int n=2; n<=len; n++)
        for(int j=len-n+1; j<len; j++) {
            temp = aAr[j,len-n];
            aAr[j,len-n] = aAr[len-n,j];
            aAr[len-n,j] = temp;
        }    
}


taskName = "Задание  №3. В прямоугольной матрице найти строку"
          +" с наименьшей суммой элементов.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк двумерного массива: ");
    int qtyRow = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов двумерного массива: ");
    int qtyCol = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[qtyRow,qtyCol];
    FillArray(ar, 0,10);    
    Console.WriteLine("Двумерный массив задан:");
    PrintArray(ar);
    int currSum; 
    int indexMinSumRow = 0;
    int minSum = FindSumRowArray(ar, 0);
    for(int i=1; i<ar.GetLength(0); i++) {
        currSum = FindSumRowArray(ar, i);
        if(minSum > currSum) {
            minSum = currSum;
            indexMinSumRow = i;
        }    
    }    
    Console.WriteLine("Ответ:");
    Console.WriteLine($"Строка {indexMinSumRow} содержит элементы с наименьшей суммой.");
    PrintRowArray(ar, indexMinSumRow);
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

int FindSumRowArray(int[,] aAr, int aRow) {
    int len = aAr.GetLength(1);
    int sum = 0;
    for(int j=0; j<len; j++) 
        sum += aAr[aRow,j];
    return sum;
}

void PrintRowArray(int[,] aAr, int aRow) {
    for(int j=0; j<aAr.GetLength(1); j++)
        Console.Write($"{aAr[aRow,j]} ");
    Console.WriteLine();
}



// }