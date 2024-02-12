
using System;

class Program
{

    public Program() {

        //ÖRNEK 1

        #region  //Kendimize parametre olarak aldığımız bir sayının kalesis sayıyı olup olmadığını ekrana yazdırma
        //Sayının bütün asal çarpanlarını bir listede toplayıp bu listedeki elemanların benzersiz olup olmadığını tespit edip bu kalesis sayı ya da değil deriz.
        //Kalesis sayı: bütün asal çarpanlarının üstü 1 olacak


        int sayi;

        Console.WriteLine("Sayi giriniz:");
        sayi = Convert.ToInt32(Console.ReadLine());
        List<int> A = AsalCarpanVektoru(sayi);
        bool sonuc = DiziElemanlariFarkliMi(A);
        if (sonuc == true)
            Console.WriteLine("Bu sayi karesiz sayidir.");
        else Console.WriteLine("Karesiz sayi değildir.");



    }
    #endregion


    static void Main(string[] args)
    {
        new Program();

        Console.WriteLine();






        //ÖRNEK 2

        #region  //Elimizde bir toplam değeri olacak ve bu toplam değeri elimizdeki dizinin elemanları ile oluşturabiliyor muyuz onu kontrol eden kod

        int[] dizi = { 1, 5, 98, 12, 6 };
        int toplam = 18;
        int boyut = dizi.Length;
        if (altToplam(dizi, boyut, toplam) == true)
            Console.WriteLine("Verilen toplama ait alt küme vardır.");
        else Console.WriteLine("Alt küme bulunamadı");



        int[] dizi2 = { 1, 5, 98, 12, 6 };
        toplam = 18;
        bool sonuc = ToplamDegerBul(dizi2, toplam, dizi2.Length);
        Console.WriteLine(sonuc);

        #endregion

    }



    //ÖRNEK 1

    //2 den kendisinin kareköküne kadar olan aralıkta bir çarpanı yoksa bu sayı asal sayı değidlir.
    List<int> AsalCarpanVektoru(int n) //method
    {
        List<int> DinamikDizi = new List<int>();
        int i = 2; // asal sayı 2' den başladığı için 2 dedik

        while ((i * i) <= n)  //
        {
            while ((n % i) == 0) // N İN MEVCUTTAKİ İ YE TAM BÖLÜNÜP ÖLÜNMEDİĞİNİ TEST ETME DURUMU
            {
                DinamikDizi.Add(i);
                n = n / i;

            }

            if (i == 2) { i = 3; } // i=2 yken bundan sonra gelen asal sayı 3 olduğu için direkt 3 yap demek
            else { i = i + 2; } // ama bunu haricindekiler 2 şer şer artacak


        }
        if (n > 1) // bu aralıktaki hiçbir asal sayıya bölünöeden olduğu gibiçıkan sayımız yani demek ki kendi sayımız asal çarpan
        {
            DinamikDizi.Add(n);

        }
        return DinamikDizi;

    }

    bool DiziElemanlariFarkliMi(List<int> A) //listedeki sayıların tekrar edip etmediğini anlamamızı sağlar
    {
        int diziBoyutu = A.Count; //liste yapılarının boyutu count ile alınoır  
        for (int i = 0; i < diziBoyutu - 1; i++)
            for (int j = 1; j < diziBoyutu; j++)
            {
                if (A[i] == A[j])
                    return false;
            }

        return true;
    }




    //ÖRNEK 2
    static bool altToplam(int[] dizi, int boyut, int toplam)
    {

        if (toplam == 0)
            return true;
        if (boyut == 0)
            return false;
        if (dizi[boyut - 1] > toplam) //sonuncu elemandan başlatıldı
            return altToplam(dizi, boyut - 1, toplam);
        return altToplam(dizi, boyut - 1, toplam - dizi[boyut - 1]) || altToplam(dizi, boyut - 1, toplam);
    }


    // chatgpt
    static bool ToplamDegerBul(int[] dizi2, int toplam, int n)
    {
        // Eğer toplam değerimiz sıfırsa, dizideki hiçbir elemanı kullanmadan toplam değerini oluşturduk demektir.
        if (toplam == 0)
            return true;

        // Eğer toplam değerimiz sıfırdan küçükse, bu durumda dizideki elemanları kullanarak toplam değerini oluşturamayız.
        if (n == 0 && toplam != 0)
            return false;

        // Eğer son elemandan önceki elemanları kullanarak toplam değerini oluşturabiliyorsak veya son elemanı kullanarak oluşturabiliyorsak, true değerini döndürüyoruz.
        if (dizi2[n - 1] > toplam)
            return ToplamDegerBul(dizi2, toplam, n - 1);

        return ToplamDegerBul(dizi2, toplam, n - 1) || ToplamDegerBul(dizi2, toplam - dizi2[n - 1], n - 1);
    }
}










