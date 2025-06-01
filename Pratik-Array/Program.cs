Console.WriteLine("Array");
int[] array = new int[10];

for (int i = 0; i < array.Length; i++)
{
    Console.Write("Bir Değer Giriniz: ");
    
    
    
    int index = int.Parse(Console.ReadLine());
    array[i] = index;

}
Console.WriteLine($"Dizi Elemanları");
foreach (int i in array)
{
    
    Console.WriteLine($"Dizi: " + i);
}

while (true)
{
    Console.Write("Bir eleman daha eklemek ister misiniz? (e/h): ");
    string cevap = Console.ReadLine()!.Trim().ToLower();

    if (cevap == "e")
    {
        // Diziyi 1 eleman büyüt
        Array.Resize(ref array, array.Length + 1);

        // Yeni eleman için tekrar değer iste
        Console.Write($"array[{array.Length - 1}] için bir değer girin: ");
        int yeniDeger;
        while (!int.TryParse(Console.ReadLine(), out yeniDeger))
        {
            Console.WriteLine("Geçersiz sayı. Lütfen tekrar deneyin:");
        }
        array[array.Length - 1] = yeniDeger;
    }
    else if (cevap == "h")
    {
        // Kullanıcı “h” diyerek artık eklemek istemiyor, döngüyü bitir
        break;
    }
    else
    {
        Console.WriteLine("Lütfen sadece 'e' veya 'h' girin.");
    }
}

Console.WriteLine("\nDizinin son hali:");
  
Array.Sort(array);
Array.Reverse(array);
foreach (int i in array)
{
    Console.WriteLine($"Dizi: " + i);
}