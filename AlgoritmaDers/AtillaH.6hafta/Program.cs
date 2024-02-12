
using System.Threading.Tasks;

class Program
{


    //RECURSİVE
    static void kumeyaz(int sayi, string kume)
    {
        if (sayi > 7) //sayı 7 den büyük olmayacak
            return;

        int tmp = 0x4;

        for (int j = 0; j < 3; j++)
        {
            if ((tmp & sayi) != 0)
                Console.Write(kume[j]);
            tmp >>= 1;
        }
        Console.WriteLine();
        kumeyaz(sayi + 1, kume);
    }




    static void Main(String[] args)
    {

        //KÜMELER
        //a,b,c    3 elemanlı bir küme ve bu kümenin tüm alt kümeleri nelerdir?
        //a, b , c , ab , abc , bc , ac =>  2^n-1 => 2^3-1= 7



        /*

        a       b       c
        0       0       0                          0
        0       0       1          c               1
        0       1       0          b               2
        0       1       1          bc              3
        1       0       0          a               4
        1       0       1          ac              5
        1       1       0          ab              6
        1       1       1          abc             7          2^n-1 den 



         her bir eleman diğerleriyle yan yana gelmeye çalışacak bütün kombinasyonları denememiz lazım



        2.Çözüm
        a yalnızdı yanına b ekledik önce a yazdık başka yok sonra b yi ekliyoruz b yi eklerken a ile yazdık sonra b nin kendisini yazdık...
        a    ba    b    c     ca    cba    cb

        a   b    ba   c   ca    cb    cba    
         */


        //ÖRNEK 1
        string kume = "abc";
        for (int i = 0; i < 8; i++)  //2^n-1 den kaynaklı 8; 7 olması için
        {
            int tmp = i;
            for (int j = 0; j < 3; j++)  //3 eleman var abc
            {
                // abc
                //001; c
                //010; b
                //100; a ya baksın
                // 100  shift edince 
                //  100

                if ((tmp & 0x4) != 0) // 4 olma sebebi 3 tane elamanımız var ve 100 maskemiz olacak ve bu 100 ı kaydırıcaz 0100 yani 4 oluyor.
                                      // 4 elemanlı deseydik 1000 dan 8 olacaktı
                    Console.Write(kume[j]);
                tmp <<= 1; //i sayımızın 101 i kontrol edince sola shift edince 010 oldu tekrar shift ettik 100 oldu

            }
            Console.WriteLine();
        }





        //2.yol
        kume = "abc";
        for (int i = 0; i < 8; i++)  //2^n-1 den kaynaklı 8 7 olması için
        {
            int maske = 0x4;
            for (int j = 0; j < 3; j++)  //3 eleman var
            {
                if ((maske & i) != 0)

                    Console.Write(kume[j]);
                maske >>= 1;

            }
            Console.WriteLine();
        }





        // 3.YOL

        kume = "abc";
        for (int i = 0; i < 8; i++)  //2^n-1 den kaynaklı 8 7 olması için
        {
            int maske = 1;
            for (int j = 2; j >= 0; j--)  
            {

                if ((maske & i) != 0)    //maskeyi i ile andledik

                    Console.Write(kume[j]);
                maske <<= 1;             //maskeyi sola doğru shiftledik

            }
            Console.WriteLine();
        }




        Console.WriteLine();




        //recursive
        kume = "edf";
        kumeyaz(1, kume);





        Console.WriteLine();






        //ÖRNEK 2
        
        kume = "abcdef";
        int cntr = 0;
        for (int i = 0; i < 64; i++)  //2^n-1 den kaynaklı 64
        {

            int tmp = 0x20; // 10 0000 6 elemanlı olduğu için 20 oldu 0010 0000 dan
            for (int j = 0; j < 6; j++)   // 6 bit olduğu için 6 lı döngüye attık.
            {
             
                if ((tmp & i) != 0)
                                    
                    Console.Write(kume[j]);
                tmp >>= 1;

            }
            Console.WriteLine();
            cntr++;    //kaç tane yazdığını kontrol ettik

        }
        Console.WriteLine(cntr);
        Console.WriteLine();







        //ÖRNEK 3

        // tüm alt kümelerden alt küme toplamı 10 olan kaç adet alt küme vardır 6-4 , 1-2-3-4 , 1-4-5
        kume = "123456";
        int[] dizi = { 1, 2, 3, 4, 5, 6 };
        //             101010
        //             101011
        //             101100

        cntr = 0;
        for (int i = 0; i < 64; i++)  
        {
            int tmp = 0x20;
            int toplam = 0;
            for (int j = 0; j < 6; j++)  
            {
                if ((tmp & i) != 0)
                    toplam += dizi[j];
                                   
                tmp >>= 1; 
            }
            if(toplam==10)
            { 
            cntr++;
            tmp = 0x20; // 10 0000 6 elemanlı olduğu için 20 oldu 0010 0000 dan
            for (int j = 0; j < 6; j++)   // 6 bit olduğu için 6 lı döngüye attık.
            {

                if ((tmp & i) != 0)

                    Console.Write(kume[j]);
                tmp >>= 1;

            }
            
            Console.WriteLine();
            }
        }
        Console.WriteLine(cntr+" tane");

        Console.WriteLine();





        /*
          
          np-hard: sonucuna problemi çözmeden yorum yapılamayan problemler np-hard  problem grubudur. Polynomial zamanda çözülür.

          np ve p var
          p: polynamial time yani çalıştırılabilir makul sonuçlar
          np: non polynomial time 2^n, n! gibi çok büyük işlrm sayıları barındıran problemlerdir. Çözümü zor oluyor
      
          np-compleate: 100 elemanlı kümenin elemanları çift olan ve alt küme toplamı 20 olan küme var mı? var 18-2, 14-6 gibi bunları direkt doğrulayabiliyoruz.
          polynomial time'da çözülemiyor. Problem olarak np-hard'ın bir alt kümesidir.

          backtrack np  problemm grubunun tüm ihtimalelrini hesaba katmadan sadece işimize yarayacak olanların kullanılmasıdır. 
          np-hard ve np-compleate problemlerini çözebiliriz

          100 elemanlı bir küme var.Bunun alt küme toplamalrı 20 olan kaç alt küme vardır?
          ihtimalelri hesaplarken 20 büyük olan küme elemanlarını kullanmayacağım. 
         */





        // 100 elemanlı bir küme var.Bunun alt küme toplamalrı 120 olan kaç alt küme vardır?

       
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                  if(i==1)  Console.Write(i);
                  if(j==1)  Console.Write(j);
                  if(k==1)  Console.Write(k);
                  Console.WriteLine();
                }
            }
        }

        Console.WriteLine();














        kume = "abc";
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                   if(i==1) Console.Write(kume[0]);       //Console.Write('a');
                   if (j == 1) Console.Write(kume[1]);   //Console.Write('b');
                   if (k == 1) Console.Write(kume[2]);   //Console.Write('c') ; de olur
                   Console.WriteLine("");
                }
            }
        }

        Console.WriteLine();









        //yukarıdakinin sayılı hali
        //4 elemanlı bir kümenin 
        int[] x = new int[5];

        while (x[4] == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (x[i] == 1) Console.Write(i);
            }
            Console.WriteLine(" ");

            x[0]++;
            int lvl = 0;
            while (x[lvl] == 2) // x[0] = 2 olursa . x[0] ı lvl e taşıdık lvl 0 dı zaten 0 yerine lvl yazdık
            {
                x[lvl] = 0; //ilk lvl'ı sıfırla yani döngü bittiğinde yeniden başlayack dolayısıyla sıfırladık
                lvl++; //lvl i 1 arttırdık
                x[lvl]++;  //
            }
        }

        Console.WriteLine();

    }

    }



