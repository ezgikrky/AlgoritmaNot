
/* Algoritmaların birbirine göre üstünlüklerini belirlemenin 2 temel esası vardır
1) Ram boyutu: ramde kullanılan hafıza miktarı, kullanılan veri yapısına bakılır. ölçülebilir bir değerdi. bilgisayarlar arasındaki fark önemli değil. byte cinsi yeterli
2) Performans yani yazılan algoitmanın ne kadar sürede çalıştığınıifade etmek istenildiğinde karşımıza engel çıkar bu engel bilgisayarların farklılıklarıdır.

Bilgisayardaki süreyi performans ölçmek için kullanmayız onun yerine Big o denilen grawth rate fonksiyonunun dönüşümünü gerçekleştirmek
Grawth rate:döngülerin,komutların maliyetleri vardı bu maliyetleri hesaplayınca karşımıza sayı çıkar. yani burada komut sayısını hedef alırız 
amaç bir algoritmanın çözümünde ne kadar komut kullanıldığını bilmek. 

Fonksiyonu değerlendirdikten sonra big o ya aktarıyoruz. Big o Grawth rate in düzenlenmiş hali de denebilir.

algortimanın big o su denildiğinde average case ya da normal case deriz. Çünkü bir algoritmanın base/normal case gelme olasılığı diğerlerinden çok daha düşüktür.

Normal/base/ ya da worst case denildiğinde algoritmanın n değerlerinin durumu bakış açımızı değiştirir. 

O(1): dizi elemanlarına ulaşım maliyeti

*/



/*100 elemanlı sıralı olmayan bir dizimiz olsun ve bu dizinin içinde 123 elemanı var mı diye sorulsun.

base case: aradığımız ilk eleman olursa bu base case'dir. x[0] =123 se O(1) olur. çünkü ilk sorulan eleman aradığımız değere eşitmiş
worst case: en son değer aradığımız eleman ise worst case olur. x[99] =123 ise O(n) olur. Bulamayıp son eleman bile olabilir o da O(n) dir.
Average case: en başta ve en sonda olmayan ortada ya da o civarda olursa average case'dir.  O(n/2)'dir. Ama bizim kuralımızda O(n/2) yi O(n) e dönüştürmemizi söyler.
ondan dolayı O(n) olur.

Yani Sıralı Olmayan bir dizide herhangi bir elemanı aramanın maliyeti; diziyi en baştan sona kadar tararız
Worst case= O(n)
Average case= O(n/2) = O(n)
Base case= O(1)

Sıralı bir dizide eleman aramanın yolu;

low                                     high
 1     4     8     9     11      15      17

Sıralı olduğu için diziyi en baştan en sona kadar taramayız. Ortadaki değeri buluruz. low indisimiz bizim 0, high en yüksek indismiz n-1 . bunun ortasındaki değeri alırız  
Aradığımız değer 15 
(low+high)/2 =9 9 aradığımız değere eşitse en iyi durum oldu. eşit değilse 9, 15 ten küçükse artık 9 dan küçüklere bakmayız artık 9 dan büyüklere bakarız.

Bineary searh denilen bir yapı

  low = 0
  high = n-1
  while (low <= high) do
    ix = (low + high)/2
    if (t = A[ix]) then
        return true
    else if (t < A[ix]) then
        high = ix-1
    else low = ix + 1
  return false

Her seferinde 2 ye bölerek ararız

Best O(1) 
Average O(logn)
Worst O(logn)


*/


using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

//ÖRNEK 1
//100 elemanlı dizide en yüksek elemanı bul

int[] x = new int[100];


// Diziye rastgele sayılar atayın.
Random rastgele = new Random();
for (int i = 0; i < x.Length; i++)
{
    x[i] = rastgele.Next(1, 100);
}

int ebe = x[0]; //ilk elemanı en büyük eleman kabul ettik

for (int i = 1; i < x.Length; i++) //ilk eleman 0 ı  buraya taşıdıktan sonra buradan başlatıcaz
{
    if (ebe < x[i])
        ebe = x[i]; //notu 70 dedi elimizdeki en yüyük eleman 60 tı şimi en büyük elemanı 70 yapıp eşitledik.
                    //Yani en büyük eleman x[i] den küçükse ebe nı x[i]ye eşitledik. sonra tekrardan sorduk 2.eleman için sorduk tekrardan aynı işlemleri yaptık
}

Console.WriteLine("En büyük eleman: " + ebe); // En büyük elemanı yazdırın
Console.WriteLine();




//ÖRNEK 2

int[] dizi = { 1, 2, 5, 8, 6, 87, 42 }; // 7 elemanlı bir dizi tanımlayın ve başlangıç değerleri atayın.

int enBuyuk = dizi[0]; // Dizinin ilk elemanını en büyük olarak varsayın.

// Dizinin geri kalan elemanlarını kontrol edin ve en büyük olanını bulun.
for (int i = 1; i < dizi.Length; i++)
{
    if (dizi[i] > enBuyuk)
    {
        enBuyuk = dizi[i];
    }
}

Console.WriteLine("En büyük eleman: " + enBuyuk); // En büyük elemanı yazdırın.
Console.WriteLine();






//ÖRNEK 3
//dizi içerisinde 123 var mı?
int[] y = new int[100];


Random rastgele2 = new Random();
for (int i = 0; i < y.Length; i++)
{
    y[i] = rastgele2.Next(1, 124);
}
int bulundu = 0;

for (int i = 0;i < y.Length;i++)
{
    if (123 == y[i])
    {
        bulundu = 1;
        break;
    }
}
if(bulundu==1) Console.WriteLine("bulduk");
else Console.WriteLine( "bulamadık");


Console.WriteLine();




//ÖRNEK 4
//sıralı bir dizi
//1,3,4,5,77,90,123,456,7890....

int[] dizi2 = { 1, 3, 4, 5, 77, 90, 123, 456, 7890 };

int bulundu2 = 0;
for (int i = 0; i < dizi2.Length; i++)
{
    if (123 == dizi2[i])
    {
        bulundu2 = 1; break;
    }
}

if(bulundu2==1) Console.WriteLine("bulundu");
else Console.WriteLine( "bulunamadı");

Console.WriteLine();





//ÖRNEK 5
//en düşük nottan en yüksek nota göre sıralandığını teyit etme. Yani en baştakine sorduk 20 aldığını söyledi yanındaki >=20 olmalı

int[] dizi3 = { 10,11,20,30,60};

bool hata = false;
for (int i = 1; i < dizi3.Length; i++) //en baştan en sona göre ilerlicez 1 den başlama sebebi ise 1 e bir öncekinin notunu sormamız
{
    if (dizi3[i] < dizi3[i - 1])  // 19 bir öncekinden küçük ve eşitse o zaman burada problem var
    { 
        hata = true; 
        break; 
    }
}
if (hata) Console.WriteLine("Hatalı");
else Console.WriteLine("Hatasız");

Console.WriteLine();


//ÖRNEK 6
//2 dizi var birebir aynı mı değil mi anlayan kod

int[] array1 = { 1, 2, 3, 4, 5 };
int[] array2 = { 1, 2, 3, 4, 5 };

if(array1.Length != array2.Length)
{
    Console.WriteLine("Diziler aynı boyuta değil");
}
else
{
    bool esit = false;
    for (int i = 0; i < array1.Length; i++)
    {
        if (array1[i] != array2[i])
        {
            esit = true;
            break;
        }
    }
    if (esit==false) Console.WriteLine("Diziler aynı");
    else Console.WriteLine("Diziler farklı");
}

Console.WriteLine();




//ÖRNEK 7
// Dizi içerisinde sayılar 1,2,3,2,4,5,6,1,2,45 şeklinde sıralansın. artış sergileyen en uzun grubu bulma

int[] nums = { 1, 2, 3, 2, 4, 5, 6, 1, 2, 45 };
int maxLength = 1;
int currentLength = 1;

for (int i = 1; i < nums.Length; i++)
{
    if (nums[i] > nums[i - 1])
    {
        currentLength++;
    }
    else
    {
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
        }
        currentLength = 1;
    }
}


Console.WriteLine($"Artış sergileyen en uzun grup uzunluğu: {maxLength}");


Console.WriteLine();


//BİTWİSE İŞLEMLER

/* İKİLİK SAYI SİSTEMİNDEKİ BASAMAKLARA BİT DENİR
 * 1 VE 0 İÇERİR
 * BİTWİSE= BİTLERİ KULLANARAK İŞLEMLER
 * ALU DA GERÇEKLEŞİR
 * AND, OR, SHİFT(SOLA, SAĞA KAYDIRMA), DÖNDÜRME İŞLEMLERİ YAPILABİLİR

 * İNTEGER TAMSAYILARDA NEGATİF
 * 
 * TAMSAYILAR BAKIŞ AÇISINA GÖRE DEGİŞİK, İŞARETLİ YADA İŞARETSİZ OALRAK DEGİŞİR
 * İNT UİNT
 * UİNT NEGATİF OLAMAZ
 * UNSORT ''     ''
 * byte 
 * sbyte eksi olabilir
 * bellekte farklı yer kaplıyorlar
 */


/* And  ve Or  yapısı bitleri andleyip orlayan yapı

            1 or x = 1    0 or x=x
            1 and x= x    0 and x=0

*/


int x1 = 1;
uint x2 = 2;
short s1 = 1;
ushort s2 = 2;
byte b1= 1;
sbyte b2= 2;



b1 = 120;
b2=(sbyte)b1;
Console.WriteLine(b2+10);
Console.WriteLine();


/*
 b1 = 200;
b2=(sbyte)b1;
Console.WriteLine(b2+10);

 
 çıktısı : -46 olur negatifi alındığı için
 
 */

Console.WriteLine();


// negatif sayılar
// en sol bit, MSB most significant bit
// sign bit,işaret biti

//hiç işaret yoksa;
//min: 0000 0
//max: 1111 15 olur

//işaret bitli;
//0 000 pozitif
//1 negaitf
//0 011 ->  artı 3
//1 011 -> bu sayı negatif bir sayıdır. 


/*
 * 1 0 0 0 sayı
 * 0 1 1 1 degili
 *       1 1 ile topladık
 * 1 0 0 0 = 8 e eşit 
 * yani 1 0 0 0 -8 e eşit
 * bir işaretli sayının eksi kaç oldugunu anlamak onun degilini alıp 1 ekledigimizde çıkan sayının eksili hali
 */

// 1011 sayısının kaç olduğunu anlamanın yolu
// 0100 değilini aldık
// 0001 1ile topla
// 0101 5 oldu
// yani 1011 -5 oldu


// -3 ün karşılığı
// 0011   +3 yazdık
// 1100  değilini aldık
// 0001  1 ile topla
// 1101  -3   yani -3 ün karşılığı 1101


//sayı sistemlerimiz: 10, 2,8,16

x1 = 0x123a;

/*on altılık sayı sıstemi  
          * SEMBOLLER= 0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F
          * 10=A, 11=B, 12=C, 13=D, 14=E, 15=F
          * 
          */


// BİNARY HEX
// 0101 0101 0001
//  5    5    1  
//BU SAYININ HEX KARŞILIĞI 0X551; OLDU

// 0x123a binary karşılığı bulma
// 0001  0010  0011  1010 
//  1      2    3     a

//10101011111101010100110101010

//0001 0101 0111 1110 1010 1001 1010 1010 yukarıdakini sağdan sola 4 lü ayırdık en son 1 kaldı yanına 3 tane 0 koyduk


// 0xfb0010
// 1111 1011 0000 0000 0001 0000

x1 = 0x1;
Console.WriteLine(x1);

x2 =  0x80000000;  // 1000 0000 0000 0000 0000 0000 0000 0000
x1 = (int)x2;
Console.WriteLine( x1);

x2 = 0xffffffff;  // 1111 1111 1111 1111 1111 1111 1111 11111
x1 = (int)x2;
Console.WriteLine(x1);

x2 = 0x7fffffff;   // 0111 1111 1111 1111 1111 1111 1111 11111
x1 = (int)x2;
Console.WriteLine(x1);