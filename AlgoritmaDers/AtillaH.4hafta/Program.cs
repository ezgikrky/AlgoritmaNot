
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {



        //MSB ... LSB  sayılar en önemli bitten en düşük bite kadar gider
        //sol taraf en önemli sağ taraf en düşük
        //1.bit denildiğinde aksi belirtilmedikçe sağdan itibarendir.
        //1 1 1 1 0 0 0 0      1.biti 0, 2.biti 0, ....  5.biti 1, ... 8.biti 1  


        // a sayısının 1.bitini(sağ taraftaki ilk bit ya da en sağ biti) 0 olarak değiştirelim. Diğer bitler zarar görmeyecek
        // x and 0 = 0   x and 1 = x 

        // bu tarz sorularda maskeleme kullanırız
        // xxxx xxxx sonu 0 olsun
        // 1111 1110 maske sayesinde
        // xxxx xxx0 böyle oldu


        //uint a = 1; 
        //

        /* And  ve Or  yapısı bitleri andleyip orlayan yapı

           1 or x = 1    0 or x=x
           1 and x= x    0 and x=0

         */
        uint a = 11;   //a hafızada 32 bit yer kaplar      0000 0000 00000 .... 1011
        uint maske = 0xfffffff3;
        a= a & maske;
        Console.WriteLine(a);

        Console.WriteLine();


        a = 0; //yani 32 tane 0 var     0000 0000 0000 0000 0000 0000 0000 0000 0000
        a = ~a; // değilini almış olduk ve 32 tane 1 oldu    1111 1111 1111 1111 1111 1111 1111 1111 
        Console.WriteLine(a);

        Console.WriteLine();
                                          //1111 1111 1111 1111 1111 1111 1111 1111
        a = a | 0xf;  // 0xf = 0x0000000f = 0000 0000 0000 0000 0000 0000 0000 1111 demek
        Console.WriteLine(a);             //1111 1111 1111 1111 1111 1111 1111 1111 oldu yine 


        Console.WriteLine();

                                          //1111 1111 1111 1111 1111 1111 1111 1111
        a = a & 0xf;  // 0xf = 0x0000000f = 0000 0000 0000 0000 0000 0000 0000 1111 demek
        Console.WriteLine(a);             //0000 0000 0000 0000 0000 0000 0000 1111 oldu


        Console.WriteLine();



        /*Shift işlemi(kaydırmak)
         * 
         *   1 1 1 1 1        sola dogru shift ettiğimizi düşünelim
         * 1|1 1 1 1 0        1 bit taştı ve en sona 0 geldi, 1 bit daha shift edelim
         * 1|1 1 1 0 0      
         * 
         *  1 1 1 0 0 sayının 2 bit shift edilmiş hali
         * 
         * 
         *    0101   sola shift edelim
         *  0|1010   1 bir soldaki 0 ın yerine geçecek, 0 bir soldaki 1 in yerine geçecek, 1 bir soldaki 0 ın yerine geçecek ve 0 taşacak
         * 
         * 
         */
        



        a = 1; //1 bit sola kaydırmamız lazım    1= 0000 0000 0000 0000 0000 0000 0000 0001
        a = a << 1;                               //0000 0000 0000 0000 0000 0000 0000 0010 olur
        Console.WriteLine(a);                    // a = 2; oldu
        Console.WriteLine();

        a = 1;
        for (int i = 0; i < 4; i++) //sayıyı 4 shift yapıcaz öyle ekrana basacak
        {
            a = a << 1;                               //0000 0000 0000 0000 0000 0000 0001 0000 olur
            Console.WriteLine(a);                    // a = 16; oldu

        }

        //  0001
        //  0010  2
        //  0100  4
        //  1000  8

        Console.WriteLine();





        //SÜRELERİNİ HESAPLAMA
        //a = 1;

        //Stopwatch sw = new Stopwatch();
        //sw.Start();

        //for (uint i = 0; i < 0xffffffff; i++) 
        //{
        //    a = (uint) 1;
        //    //a = a << 1;
        //    a = a * 2;
        //    //çarpım işlemi shift işleminden daha hızlı çalışır.
        //}

        //sw.Stop();
        //Console.WriteLine(sw.ElapsedMilliseconds);





        Console.WriteLine();


        //sağa shift etme
        a = 8;             // 0000 .... 1000
        a = a >> 1;        // 0000 .... 0100
        Console.WriteLine(a);

        Console.WriteLine();
        // Sayının sağa doğru shifti bölmek, sola doğru shift etmek çarpmak olarak düşünülebilir






        a = 1;
        for (int i = 0; i < 32; i++) //sayıyı 32 shift yapıcaz öyle ekrana basacak
        {
            a = a << 1;                              
            Console.Write($"{a,-15}"); //2 den başlar                   

        }

        Console.WriteLine();




        a = 1;
        for (int i = 0; i < 32; i++) //sayıyı 32 shift yapıcaz öyle ekrana basacak
        {
            Console.Write($"{a,-15}"); //1 den başlar
            a = a << 1;
        }
        Console.WriteLine();

        Console.WriteLine();





        //tek mi çift mi bulma

        uint sayi = 4;

        if ((sayi % 2) == 1) Console.WriteLine("tek");
        else Console.WriteLine("çift");

        if ((sayi&0x1)==1) Console.WriteLine("tek");   // 0x1 = 0000 0000 ... 0001
        else Console.WriteLine("çift");

        //sayi = 1;
        //if ((sayi >> 1) << 1 == sayi) Console.WriteLine("çift");
        //else Console.WriteLine("tek");

        Console.WriteLine();





        //Sayımızın ilk 2 bitini diğer bitlere zarar vermeden 1 yapalım
        // xxxxxxxxxxxxxxxxxxxxx11 elde etmek istediğimiz
        // xxxxxxxxxxxxxxxxxxxxxxx bizim sayımız
        // 00000000000000000000011 maskemiz
        sayi = 1;
        maske = 0x3;
        Console.WriteLine(maske | sayi);

        Console.WriteLine();






        //3.bit 1; 9.bit 0; 12.bit 1 ve 28.bit 0 olsun
        //1000 0000 0100 = 0x804

        sayi = 1;
        maske = 0x804;

        //benim yaptığım
        sayi = sayi | maske;
        Console.WriteLine(sayi&maske);

        //hocanın yaptığı
        maske = 0xf7fffeff;      // 1111 0111 1111 1111 1111 1110 1111 1111
        sayi = sayi & maske;
        Console.WriteLine(sayi);

        Console.WriteLine();





        //sayı değişkenimizin içinde kaç adet bit 1 dir?
        // 1010 1010 0000 0000 0000 0000 0001

        int adet = 0;
        sayi = 0xffffffff;
        for (int i = 0; i < 32; i++)
        {
            if ((sayi & 1) == 1)
                adet++;
            sayi >>= 1; // sayıyı 1 ile andledik sonuç 1 ise adeti arttırdık sonra 1 bit sağa kaydırarak bir sonraki bite geçtik
        }
        Console.WriteLine(adet);

        Console.WriteLine();




        // bu daha iyi bir çözüm
        int adet1 = 0;
        sayi = 0xffffffff;
        maske = 1;
        for (int i = 0; i < 32; i++)
        {
            if ((sayi & maske) != 0) //0 dan farklıysa adeti 1 arttır
                adet1++;
            maske <<= 1; 
        }
        Console.WriteLine(adet);

        Console.WriteLine();




        // sayıyı binary e dönüştür

        sayi = 0xfff0f0f0;
        maske=0x80000000;

        for (int i = 0; i < 32; i++)
        {
            if((sayi&maske) !=0) Console.Write("1");
            else Console.Write("0");
            maske>>= 1;
        }

        Console.WriteLine();

        sayi = 0xfff0f0f0;
        maske = 0x80000000;
        string st = "";

        for (int i = 0; i < 32; i++)
        {
            if ((sayi & maske) != 0) 
                st += "1";
            else
                st += "0";
            maske >>= 1;
        }

        Console.WriteLine(st);

        Console.WriteLine();


      


        // a ve b sayıları aynı mı
        //a sayısının ilk 4 bitini diğer bitlere zarar vermeden 1 arttır








    }
}

