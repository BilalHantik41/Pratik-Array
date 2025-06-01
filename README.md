Dinamik Boyutlu Dizi Uygulaması
Bu proje, kullanıcıdan dizi elemanları alarak başlangıçta 10 elemandan oluşan bir int[] dizisini doldurur. Ardından kullanıcı isterse diziyi dinamik olarak birer eleman artırarak devam ettirebilir. Son olarak, dizi içeriğini büyükten küçüğe sıralayıp konsolda görüntüler.

Özellikler
Başlangıçta 10 elemanlık bir tamsayı dizisi (int[]) oluşturur.

Kullanıcıdan her bir dizi elemanı için değer alır.

İsteğe bağlı olarak, “Bir eleman daha eklemek ister misiniz? (e/h)” sorusuyla dizinin boyutunu birer eleman artıramaya olanak sağlar.

Son olarak, dizi elemanlarını büyükten küçüğe doğru sıralayarak ekrana basar.

Gereksinimler
.NET SDK 6.0 veya üzeri (https://dotnet.microsoft.com/download)

C# dilini çalıştırabileceğin herhangi bir IDE ya da metin editörü:

Visual Studio 2022/2019

Visual Studio Code + C# eklentisi

Rider, vb.

Kurulum ve Çalıştırma
Bu dizini bilgisayarınıza klonlayın veya ZIP olarak indirin:

bash

git clone https://github.com/KullaniciAdi/ProjeAdi.git
Proje klasörüne gidin:

bash

cd ProjeAdi
Eğer projenin .csproj dosyası varsa, komut satırından çalıştırmak için:

arduino

dotnet run --project DinamikDiziUygulamasi.csproj
— ya da doğrudan ana dizindeyseniz:

arduino

dotnet run
Visual Studio veya başka bir IDE kullanıyorsanız:

IDE’de “Solution” veya “Proje” olarak açın.

Ana proje dosyasını (örneğin Program.cs) çalıştırın (F5 veya “Start” butonuna tıklayarak).

Kullanım
Uygulama çalıştığında konsolda şu satır görünür:

javascript
Kopyala
Düzenle
Array
İstenilen her bir satırda:


Bir Değer Giriniz:
komutu görünür. Buraya tamsayı değerler girin ve her Enter’a bastığınızda diziye atılır. Toplam 10 kez bu adım tekrar eder (dizi başlangıçta 10 elemanlı olarak tanımlandığı için).

İlk 10 değeri girdikten sonra, uygulama dizinin mevcut halini gösterir:


Dizi Elemanları
Dizi: 12
Dizi: 5
Dizi: 8
… (10 satır)
Ardından her tur:


Bir eleman daha eklemek ister misiniz? (e/h):
sorusu ile karşılaşırsınız.

e (evet) derseniz:

Array.Resize kullanılarak dizi boyutu bir arttırılır.

Yeni eklenen elemanın indeksi (örneğin 10’dan 11’e geçişte yeni indeks [10]) için kullanıcıdan tamsayı değeri istenir ve diziye eklenir.

Sorunun yanıtına göre kullanıcı istediği kadar eleman eklemeye devam edebilir.

h (hayır) derseniz:

Eleman ekleme döngüsünden çıkar ve doğrudan “Dizinin son hali” bölümüne geçer.

Başka bir karakter girerseniz “Lütfen sadece 'e' veya 'h' girin.” diye uyarı verip tekrar sorulur.

Kullanıcı “h” dediğinde, uygulama dizinin tüm elemanlarını büyükten küçüğe doğru sıralar ve ekrana yazar:


Dizinin son hali:
Dizi: 98
Dizi: 76
Dizi: 55
… 
Kod Akışı ve Açıklama

Console.WriteLine("Array");
int[] array = new int[10];
“Array” başlığı konsola yazılır.

Başlangıçta 10 elemanlı bir int[] array oluşturulur. Bu aşamada tüm elemanlar varsayılan olarak 0 değerine sahiptir.


for (int i = 0; i < array.Length; i++)
{
    Console.Write("Bir Değer Giriniz: ");
    int index = int.Parse(Console.ReadLine());
    array[i] = index;
}
for döngüsü, i 0’dan 9’a (toplam 10 kez) kadar döner.

Her turda kullanıcıdan bir tamsayı girmesi beklenir (int.Parse ile parse edilir).

Girilen değer, array[i] konumuna atanır.


Console.WriteLine($"Dizi Elemanları");
foreach (int i in array)
{
    Console.WriteLine($"Dizi: " + i);
}
İlk 10 eleman alındıktan sonra “Dizi Elemanları” başlığı yazılır.

foreach döngüsü ile dizinin mevcut (ilk 10) elemanları tek tek ekrana basılır.


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
        // Artık ekleme yapmayacaksa döngüyü kır
        break;
    }
    else
    {
        Console.WriteLine("Lütfen sadece 'e' veya 'h' girin.");
    }
}
Sonsuz while(true) döngüsü başlatılır ve her seferinde “Bir eleman daha eklemek ister misiniz? (e/h)” sorusunu sorar.

e girilirse:

Array.Resize(ref array, array.Length + 1); ile mevcut diziyi bir eleman daha büyük yapar.

ref array demek, orijinal array referansının (pointer’ının) kendisini işlemi uyguladıktan sonra yeni, daha büyük diziye güncelle demektir.

array.Length + 1 ifadesi “mevcut uzunluk + 1” olarak yeni dizi uzunluğunu belirler. Örneğin 10 → 11, 11 → 12 vb.

Yeni eklenen konum (array.Length - 1) için kullanıcıdan tekrar int girmesini ister.

while(!int.TryParse(...)) bloğu, kullanıcı geçerli bir tamsayı girene kadar tekrar tekrar “Geçersiz sayı” mesajı verir.

Geçerli sayı girildiğinde, son indeksteki elemana (array[array.Length - 1]) atanır.

h girildiğinde:

break; ile while(true) döngüsünden çıkılır, ekleme işlemi sonlanır.

Başka bir karakter girilirse:

“Lütfen sadece 'e' veya 'h' girin.” mesajı ile yeniden seçim istenir.

csharp
Kopyala
Düzenle
Console.WriteLine("\nDizinin son hali:");
Array.Sort(array);
Array.Reverse(array);
foreach (int i in array)
{
    Console.WriteLine($"Dizi: " + i);
}
Kullanıcı ekleme işlemini bitirdiğinde:

"Dizinin son hali:" başlığı yazdırılır.

Array.Sort(array); ile dizi küçükten büyüğe sıralanır.

Array.Reverse(array); ile sıralı dizi tersine çevrilir; böylece “büyükten küçüğe” sıralanmış dizi elde edilir.

foreach ile tüm elemanlar ekrana tek tek basılır.

Örnek Çıktı
yaml
Kopyala
Düzenle
Array
Bir Değer Giriniz: 15
Bir Değer Giriniz: 8
Bir Değer Giriniz: 42
Bir Değer Giriniz: 3
Bir Değer Giriniz: 27
Bir Değer Giriniz: 99
Bir Değer Giriniz: 50
Bir Değer Giriniz: 11
Bir Değer Giriniz: 68
Bir Değer Giriniz: 25

Dizi Elemanları
Dizi: 15
Dizi: 8
Dizi: 42
Dizi: 3
Dizi: 27
Dizi: 99
Dizi: 50
Dizi: 11
Dizi: 68
Dizi: 25

Bir eleman daha eklemek ister misiniz? (e/h): e
array[10] için bir değer girin: 100

Bir eleman daha eklemek ister misiniz? (e/h): e
array[11] için bir değer girin: 5

Bir eleman daha eklemek ister misiniz? (e/h): h

Dizinin son hali:
Dizi: 100
Dizi: 99
Dizi: 68
Dizi: 50
Dizi: 42
Dizi: 27
Dizi: 25
Dizi: 15
Dizi: 11
Dizi: 8
Dizi: 5
Dizi: 3
İpuçları & Geliştirmeler Önerisi
Hata Kontrolleri:

Şu an int.Parse bazen FormatException fırlatabilir. int.TryParse kullanarak “Geçersiz sayı” kontrolünü tüm girişlerde kullanmak hata olasılığını azaltır.

List<int> Kullanımı:

Eğer dinamik olarak liste boyutunu büyütüp küçültmek, silme/ekleme işlemleri yapmak istersen, int[] yerine List<int> kullanmak kodu daha anlaşılır ve bakımı kolay hâle getirir.

Örneğin:

csharp
Kopyala
Düzenle
List<int> liste = new List<int>();
// liste.Add(girilenDeger);
// liste.Sort(); liste.Reverse();
// liste.Count ile uzunluğa ulaşabilirsin.
Arama / Filtreleme:

Ekstra bir adım olarak, kullanıcıdan belirli bir değeri arama veya ortalama, en küçük, en büyük gibi istatistiksel veriler hesaplama özellikleri ekleyebilirsin.

Unit Test:

Kodunu test etmek istersen, giriş verilerini simüle eden birim test (NUnit veya xUnit) yazarak, farklı boyutlardaki dizilerle ve hata durumlarıyla test edebilirsin.

