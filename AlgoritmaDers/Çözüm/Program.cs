using System;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] array = { 3, 5, 7, 9, 12, 15, 7, 8, 9, 10, 11, 12 };
        int currentLength = 1;
        int currentStart = 0;
        int maxLength = 0;
int startIndex = 0;
int endIndex = 0;

for (int i = 1; i < array.Length; i++)
{
    if (array[i] == array[i - 1] + 1)
    {
        currentLength++;
    }
    else
    {
        if (currentLength > maxLength)
        {
            startIndex = currentStart;
            maxLength = currentLength;
            endIndex = i - 1;
        }
        currentStart = i;
        currentLength = 1;
    }
}

if (currentLength > maxLength)
{
    startIndex = currentStart;
    maxLength = currentLength;
    endIndex = array.Length - 1;
}

int[] lengthiest = new int[maxLength];
for (int i = 0; i < maxLength; i++)
{
    lengthiest[i] = array[startIndex + i];
}

Console.WriteLine("En uzun dizi: ");
for (int i = 0; i < maxLength; i++)
{
    Console.Write(lengthiest[i] + " ");
}

Console.WriteLine("\nUzunluk: " + maxLength);
    }
}