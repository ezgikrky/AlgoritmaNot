using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //ÖRNEK 1

        //sayı değişkenimizin içinde kaç adet bit 1 dir?
        uint a = 0xf00000ff; // 12 adet 1 var
        int adt = 0;
        uint b = 1;
        for (int i = 0; i < 32; i++)
        {
            if ((a & b) != 0) //0 dan farklıysa adeti 1 arttır
                adt++;
            b <<= 1;
        }
        Console.WriteLine(adt);
        Console.WriteLine();


        //recursive hali
        Console.WriteLine(Bitsayisi(0xf00000ff, 0x1));
        Console.WriteLine(Bitsayisi2(0xf00000ff));
        Console.WriteLine(bitsayisi(0xf00000ff));
        Console.WriteLine();






        //ÖRNEK 2

        //10 lu sayı sistemine göre ekrana yazdır 
        // yani 1 0 1 1
        //      8 4 2 1    yukarıdakileri bunlarla çarp çıktı 11 olmalı
        //      

        a = 0xb;
        uint carpan = 1;
        uint sayi = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((a & 1) == 1)
                sayi = sayi + carpan;
            a >>= 1;
            carpan = carpan * 2;

        }
        Console.WriteLine(sayi);
        Console.WriteLine(bitsayisi3(0xb, 1));
        Console.WriteLine(bitsayisi4(0xb, 0x80000000, 1)); //sağa doğru shift edildiği için 0x80000000
        Console.WriteLine();









        //ÖRNEK 3

        // a ve b 2 tane sayı bu 2 sayı birbirine eşit mi gösteren kodu yazınız

        a = 0xff;
        b = 0xff;
        adt = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((a & 1) == (b & 1)) adt++;
            else break; //kodun bir miktar hızlı çalışmasını sağlar. eşit değilse artık çalışmasına gerek yok demek 
            a >>= 1;
            b >>= 1;
        }

        if (adt == 32) Console.WriteLine("eşit");
        else Console.WriteLine("değil");

        Console.WriteLine(bitsayisi5(0xff, 0xff)); //recersive için
        Console.WriteLine();









        //ÖRNEK 4

        //32 bilik bir sayının en yüksek seviyeli 4 biti b değişkenine aktar. b sayısının diğer bitleri de değişmesin.

        a = 0xfbfbfbfb;
        b = 0x1bfbfbfb;

        Console.WriteLine("a: "+ a);
        Console.WriteLine("b: "+ b);

        b = b & 0x0fffffff;
        //  0000xxxxxxxxxx

        b = b | (a & 0xf0000000);

        Console.WriteLine("b: "+ b);

        // bu recursive çözülmez çünkü döngüsel problemler recursive olur

        Console.WriteLine();







        // ÖRNEK 5:

        // 32 bilik bir sayının en yüksek seviyeli 4 bitini b sayısına kendisi olarak atama

        a = 0xfbfbfbfb;
        b = 0;
        b = b | (a >> 28);  // a>> 28    =>   0000000f oldu a çünkü 28 bit sağa aktardık.
        Console.WriteLine("b: " + b);

        Console.WriteLine();







        //ÖRNEK 6 

        // sağdan itibaren 13,14,15 ve 16 bitlerini 1 arttıralım.

        a = 0x1230123;
        a = a + 0x1000; 
        Console.WriteLine(a);


        //2. yol

        a = 0x1230123;

        // 000f000   a sayısının 4 bitini maske ile aldık 
        //       x   12 bit sağa kaydırdık 1 bit ekledik
        //       y oldu bununla a eski halini orladık
        a = a | (((a & 0xf000) >> 12) + 1) << 12;  
        Console.WriteLine(a);
        Console.WriteLine();





        //ÖRNEK 7

        //d değişkeninin ilk 5 bitine a; 20 ile 23.bitlerine b;
        //en yüksek seviyeli 3 bitine de c sayılarını aktarınız.

        a = 3;
        b = 7;
        uint c = 8;
        uint d = 0;

        // dye yazılacak bitlerin yerlerini sıfırladık
        // d nin ilk 5 bitini sıfırlamamız lazım o 5 bit 0 olacak diğerleri 1 olacak 

        d = d & 0xffffffe0;
        d = d & 0xff87ffff; // 1111 1111 1000 0111 1111 1111 1111 1111
        d = d & 0x1fffffff;

        d = d | a;   // d=d+a; da denilebilir
        d = d | (b << 20); // b nnin yerini bulmak için 
        d = d | (c << 28);

        Console.WriteLine(d);







        // ÖRNEK 8

        //string bir sayının int e dönüşümü

        string s = "1234";
        a=(uint) Convert.ToInt32(s);

        int carpan2  = 1; 
        int sayi2  = 0;
        for (int i = 0; i < s.Length; i++)
        {
            sayi2 = sayi2 + carpan2 * (s[i] - '0');
            carpan2 = carpan2 * 10;
        }

        Console.WriteLine(carpan2);
        














    }



    //sayı değişkenimizin içinde kaç adet bit 1 dir? recursive hali
    static int Bitsayisi(uint a, uint b)
    {
        if (b == 0) return 0;
        if ((a & b) != 0) { return 1 + Bitsayisi(a, b <<= 1); }
        else return 0 + Bitsayisi(a, b <<= 1);
    }


    //2.yol yukarıdaki daha iyi
    static int Bitsayisi2(uint a)
    {
        if (a == 0) return 0;
        if ((a & 1) == 1) return 1 + Bitsayisi2(a >>= 1);
        else return 0 + Bitsayisi2(a >> 1);
    }

    //3.yol
    static int bitsayisi(uint a)
    {
        if (a == 0) return 0;
        return (int)(a & 1) + bitsayisi(a >>= 1);
    }

    //4.yol
    static int bitsayisi2(uint a, uint b)
    {
        if (b == 0) return 0;
        return ((a & b) != 0 ? 1 : 0) + bitsayisi2(a, b <<= 1);
    }


    //1.yol
    static uint bitsayisi3(uint a, uint carpan)
    {
        if (a == 0) return 0;
        return carpan * (a & 1) + bitsayisi3(a >> 1, carpan * 2);
    }


    //2.yol
    static uint bitsayisi4(uint a, uint b, uint carpan)
    {
        if (b == 0) return 0;
        return carpan * (uint)(((a & b) != 0) ? 1 : 0) + bitsayisi4(a, b >> 1, carpan * 2);
    }


    //1.yol
    static uint bitsayisi5(uint a, uint b)
    {
        if (a == 0 && b == 0) return 1;  // hep eşit eşit gelmiş ondan dolayı 1

        if ((a & 1) == (b & 1)) return bitsayisi5(a >>= 1, b >> 1); //karşılıklı bitler eşit olduğunda kontrole devam et demek
        else return 0; // eşitsizlik yakaladığında 0 gönder demek 
    }



    //ÖRNEK 8

    static int bitSayisi(string s, int b, int leng)
    {
        if(leng>=s.Length) return 0;

        return b* (s[leng] -'0')* bitSayisi(s, b * 10, leng + 1);
    }
}
