using static Csharp_seminar9.Functions;
var tasks = new Dictionary<int, Action>
{
    { 64, Task64 },
    { 66, Task66 },
    { 68, Task68 },
};
var numbersOfTasks = tasks.Keys.ToArray();
tasks[GetTaskFromUser(numbersOfTasks)].Invoke();

void Task64()
{
    // Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
    // N = 5 -> "5, 4, 3, 2, 1"
    // N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
    Console.WriteLine("Задание 64");
    var userInput = GetUserInt("N");
    printNumbers(userInput);
    
    void printNumbers(int number)
    {
        var iterator = number > 1 ? -1 : 1;
        number += iterator;
        if (number == 1) return;
        Console.Write(number + " ");
        printNumbers(number);
    }

}

void Task66()
{
    // Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
    //
    // M = 1; N = 15 -> 120
    // M = 4; N = 8. -> 30
    Console.WriteLine("Задание 66");
    var userM = GetUserInt("M");
    var userN = GetUserInt("N");
    Console.WriteLine($"Сумма: {SumNumsRange(userM, userN)}");
    
    int SumNumsRange(int currentValue, int limit, int sum = 0)
    {
        int iterator;
        int slicedLimit;
        if (userM > userN)
        {
            iterator = -1;
            slicedLimit = limit + 1;

        }
        else
        {
            iterator = 1;
            slicedLimit = limit - 1;
        }

        currentValue += iterator;
        Console.Write(currentValue + " ");
        sum += currentValue;
        
        if (currentValue == slicedLimit)
        {
            Console.WriteLine();
            return sum;
        }
        return SumNumsRange(currentValue, limit, sum);
    }
}

void Task68()
{
    // Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
    // m = 2, n = 3 -> A(m,n) = 9
    // m = 3, n = 2 -> A(m,n) = 29
    Console.WriteLine("Задание 68");
    var userM = GetUserInt("m");
    var userN = GetUserInt("n");

    Console.WriteLine($"Результат: {FunctionAckermann(userM, userN)}");
    
    int FunctionAckermann(int m, int n)
    {
        if (m == 0) return n + 1;
        return FunctionAckermann(m - 1, n == 0 ? 1 : FunctionAckermann(m, n - 1));
    }
}



int GetTaskFromUser(int[] availableTasks)
{
    var taskNumber = GetUserInt("номер задания");
    while (!availableTasks.Contains(taskNumber))
    {
        Console.WriteLine("!!!Данной задачи не заложено!!!");
        taskNumber = GetUserInt("номер задания");
    }
    return taskNumber;
}