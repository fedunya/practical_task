// Задача: Написать программу, которая из имеющегося массива строк
// формирует массив из строк, длина которых меньше либо равна 3 символа.
// Первоначальный массив можно ввести с клавиатуры, либо задать
// на старте выполнения алгоритма. При решении не рекомендуется пользоваться
// коллекциями, лучше обойтись исключительно массивами.

void PrintArray(string[] array)
{
    int length = array.Length;
    Console.Write($"[{array[0]}");
    for (int i = 1; i < length; i++)
    {
        Console.Write($", {array[i]}");
    }
    Console.Write("]");
    Console.WriteLine();
}

string[] SelectionFromArrayToArray(string[] array)
{
    string[] temp = new string[array.Length];
    int j = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length < 4)
        {
            temp[j] = array[i];
            j++;
        }
    }
    string[] newArray = new string[j];
    Array.Copy(temp, 0, newArray, 0, j);
    return newArray;
}

int IntParseInput(string str)
{
ReadInput:
    Console.Write(str);
    var inputStringA = Console.ReadLine()!;
    if (!int.TryParse(inputStringA, out int num))
    {
        Console.WriteLine("Введено не число!");
        goto ReadInput;
    }
    else return num;
}

string[] CreateArrayRandom(int m)
{
    string[] array = new string[m];
    var random = new Random();
    for (int i = 0; i < m; i++)
    {
        int stringLength = random.Next(1, 8);
        string str = "";
        for (int j = 0; j < stringLength; j++)
        {
            char letter = Convert.ToChar(random.Next(97, 123));
            str = str + letter;
        }
        array[i] = str;
    }
    return array;
}

string[] InputArrayFromConsole(int m)
{
    string[] array = new string[m];
    for (int i = 0; i < m; i++)
    {
        Console.Write($"Введите {i + 1}-й элемент массива: ");
        array[i] = Console.ReadLine()!;
    }
    return array;
}

int m = IntParseInput("Введите размер массива: ");
string[] array = new string[m];
Input:
    int answer = IntParseInput("Введите 1 для задания массива в ручную или " +
        "2 для создания его автоматически: ");
    if (answer == 1) array = InputArrayFromConsole(m);
    if (answer == 2) array = CreateArrayRandom(m);
    else
    {
        Console.WriteLine("Должно быть 1 или 2. Повторите ввод");
        goto Input;
    }
PrintArray(array);
Console.WriteLine();
PrintArray(SelectionFromArrayToArray(array));
