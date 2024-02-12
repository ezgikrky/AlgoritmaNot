
//ÖRNEK1
//32 BİTLİK BİR SAYININ EN YÜKSEK SEVİYELİ 5 BİTİNİ 1 ARTTIRAN PROGRAM
uint a = 0xefffffff;
Console.WriteLine(Convert.ToString(a, toBase: 2)); //binary sayıyı ekrana yazdırdık
uint b = a & 0xf8000000;
b = b >> 27;
b++;
b = b << 27;
a = 0x07ffffff;
a = a | b;
Console.WriteLine(Convert.ToString(a, toBase: 2));

Console.WriteLine();





//ÖRNEK2
//ilk 4 biti son 4 bite kopyalayan program
uint esasSayi = 0xABCD1234;
Console.WriteLine(Convert.ToString(esasSayi, toBase: 2));
uint ilkDortlu = esasSayi & 0xF0000000;
uint sonuc = ilkDortlu >> 28;
sonuc |= esasSayi & 0xFFFFFFF0;
Console.WriteLine(Convert.ToString(sonuc, toBase: 2));


Console.WriteLine();





Console.WriteLine(SayininTersiniBul(485) );

static int SayininTersiniBul(int n) //sayının tersini bulan metıt
{
    int nTers = 0;
    int birlerBas;

    while (n > 0)
    {
        birlerBas = n % 10; //birler basamağı hesaplama 10 a göre modunu alma
        nTers = nTers * 10 + birlerBas; // nTers'e birler basamağını göndermemiz gerekiyor. Katsayı olarak 10'ar 10'ar arttığı için 10 ile çarpıldı
        n = n / 10; //güncelledik her zaman birler basamağını gönderecek
    }
    return nTers;

}