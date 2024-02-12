class Program
{

    #region ÖRNEK1 SubstringSorusu

    //metot kısmı public static
    public static string OrtakAltKelime(string kelime1, string kelime2)
    {
        int maksUz = 0;
        int bitisNoktasi = 0;

        for (int i = 0; i < kelime1.Length; i++)
            for (int j = 0; j < kelime2.Length; j++)
            {
                int uzunluk = 0;
                int guncelIndis1 = i; //benzerlikleri bulunann noktaları başka değerde tutmak için
                int guncelIndis2 = j;

                while (guncelIndis1 < kelime1.Length && guncelIndis2 < kelime2.Length && kelime1[guncelIndis1] == kelime2[guncelIndis2])
                {
                    uzunluk++;
                    guncelIndis1++;
                    guncelIndis2++;

                }

                if (uzunluk > maksUz)
                {
                    maksUz = uzunluk;
                    bitisNoktasi = guncelIndis1;


                }

            }

        if (maksUz == 0)
            return ""; //ortak alt kelime bulunamadı

        char[] ortaklarKumesi = new char[maksUz];
        int indis = 0;

        for (int t = bitisNoktasi - maksUz; t < bitisNoktasi; t++)
        {
            ortaklarKumesi[indis] = kelime1[t];
            indis++;
        }

        string ortakKelime = new string(ortaklarKumesi);
        return ortakKelime;
    }

    #endregion

    #region ÖRNEK2  Dizideki En Büyük İlk 2 Elemanı Bulan Kod

    public static void EnBuyuk2Eleman(int[] array)
    {
        int max1 = array[0];
        int max2 = array[1];

        if (max1 < max2) //max1<max2 ise kendi arasında değiş tokuş olacak 2 değişkeni kendi arasında değiştireceksek geçici değişken kullanmak zorundayuız
        {
            int temp = max1;
            max1 = max2;
            max2 = temp;
        }

        for (int i = 2; i < array.Length; i++)
        {
            if (array[i] > max1)
            {
                max2 = max1;
                max1 = array[1];
            }

            else if (array[i] > max2 && array[i] < max1)
            {
                max2 = array[i];
            }
        }
        Console.WriteLine("En büyük ilk eleman: " + max1);
        Console.WriteLine("En büyük ikinci eleman: " + max2);
    }


    #endregion


    #region ÖRNEK3 Dengeli Sayı Mı? 

    //Sayı alınacak dengeli sayının bütün basamakları birbirinden farklı olması gerekiyoır ve tek ve çift sayısı birbirine eşit olmalı

    static List<int> BasamaklarVektoru(int n)
    {
        int birlerBas;
        double a = Convert.ToInt32(n);

        List<int> DinamikDizi = new List<int>();
        if (n == 0) DinamikDizi = null;

        else
            while (a > 0)
            {
                birlerBas = Convert.ToInt32(a % 10);
                DinamikDizi.Add(birlerBas);
                a = Math.Floor(a / 10);
            }
        return DinamikDizi;
    }

    static bool DiziElemanlariFarkliMi(List<int> DinamikDizi)
    {
        int diziBoyutu = DinamikDizi.Count;

        for (int i = 0; i < diziBoyutu - 1; i++)
        {
            for (int j = 1; j < diziBoyutu; j++)
            {
                if (DinamikDizi[i] == DinamikDizi[j])
                    return false;
            }

        }
        return true;
    }


    static bool DengeliSayiMi(int n)
    {
        int tekSayisi;
        int ciftSayisi = 0;

        List<int> DinamikDizi = new List<int>();
        int sonuc = 0;
        if (n >= 10) DinamikDizi = BasamaklarVektoru(n);

        int basamakSayisi = 0;
        int diziBoyutu = DinamikDizi.Count;
        while (n > 0)
        {
            n = n / 10;
            basamakSayisi++;
        }


        if ((basamakSayisi % 2 == 0) && (DiziElemanlariFarkliMi(DinamikDizi)))
        {
            for (int i = 0; i < diziBoyutu; i++)
            {
                if (DinamikDizi[i] % 2 == 0 || DinamikDizi[i] == 0)
                {
                    ciftSayisi++;
                }
            }

            tekSayisi = diziBoyutu - ciftSayisi;
            if (tekSayisi == ciftSayisi)
            {
                sonuc = 1;
            }
            return true;
        }
        return false;

    }
    #endregion

    #region ÖRNEK4 Metin içerisindeki en uzun polindrom kelimeyi bulma
    static bool PalindromMu(string kelime)  //soldan ve sağdan bakıldığında aynı ifadeyi görürsk bu palindromdur
    {

        int sol = 0;
        int sag = kelime.Length - 1;
        while (sol < sag)
        {

            if (kelime[sol] != kelime[sag])
            {
                return false;
            }

            sol++;
            sag--;

        }

        return true;



    }

    static string EnUzunPalindrom(string metin)
    {
        string[] kelimeler = metin.Split(' ');
        string uzunPalindrom = "";

        foreach (string kelime in kelimeler)
        {
            if (PalindromMu(kelime) && kelime.Length > uzunPalindrom.Length)
            { uzunPalindrom = kelime; }

        }

        return uzunPalindrom;

    }

    #endregion


    #region ÖRNEK5 Çok diziyi tek bir dizide toplama

    static int[] DizileriBirlestir(params int[][] diziler)
    {
        int toplamBoyut = 0;

        foreach (int[] dizi in diziler)
        {
            toplamBoyut += dizi.Length;

        }
        int[] birlesikDizi = new int[toplamBoyut];
        int[] diziIndisleri = new int[diziler.Length];

        for (int i = 0; i < toplamBoyut; i++)
        {
            int minIndis = -1;
            int minDeger = int.MaxValue;

            for (int j = 0; j < diziler.Length; j++)
            {
                int mevcutIndis = diziIndisleri[j];
                if (mevcutIndis < diziler[j].Length && diziler[j][mevcutIndis] < minDeger)
                {
                    minIndis = j;
                    minDeger = diziler[j][mevcutIndis];
                }
            }

            birlesikDizi[i] = minDeger;
            diziIndisleri[minIndis]++;

        }
        return birlesikDizi;

    }
    #endregion

    #region ÖRNEK6 a,b,c ve d farklı rakamlar olamak üzere (ab+cd)^2=abcd eşitliğini doğrulayan bütün abcd sayıların adedini bulup ekrana alt alta yazdıracak kod
    //abcd 4 basamaklı; ab ve cd ise 2 basamaklı sayılardır.






    #endregion


    #region ÖRNEK7  Elimizde 50,20, 5 ,1 litrelik hacimlere sahip sınırsız şişe var
    //belli bir miktarda zeytinyağı bu şişeler kullanılarak paketlenecektir. Bu zeytinyağını minimum şişe kullanımıyla paketlenmesi gerkmektedir.
    //Yazılacak program kendisine zet,nyağının listre bilgiasini parametre alacak ve ekrana paketleme işlemi sonrasında hangi haimdeki şişenin kullandığını basacaktır.

    static void MinimumSiseKullanimi(int zeytinyagiLitre)
    {
        int adet50L = zeytinyagiLitre / 50; // 50 ye bölnmeyene kadar devazm edece
        zeytinyagiLitre %= 50;
        int adet20L = zeytinyagiLitre / 20;
        zeytinyagiLitre %= 20;
        int adet5L = zeytinyagiLitre / 5;
        zeytinyagiLitre %= 5;
        int adet1L = zeytinyagiLitre;

        Console.WriteLine("50 litrelik şişe: " + adet50L + " adet");
        Console.WriteLine("20 litrelik şişe: " + adet20L + " adet");
        Console.WriteLine("5 litrelik şişe: " + adet5L + " adet");
        Console.WriteLine("1 litrelik şişe: " + adet1L + " adet");




    }

    #endregion



    #region ÖRNEK8 Knapsack Problemi
    /*
     
     Dinamik programlama: Çözüme ulaşması istenilen problemi direkt çözüme götürmek yerine problemi alt çözüm yollarına ayırarak en optimize yolu bulmak demektir

     Knapsack Problemi: Bir dizi özelliğin verildiği ve bazı özelliklere sahip alt kümelerin bulunması gerekn sorunları ifade eder.
     
     
     
     */
    static int Knapsack(int kapasite, int[] ağırlıklar, int[] değerler, int n2)
    {

        if (n2 == 0 || kapasite == 0) return 0;
        if (ağırlıklar[n2 - 1] > kapasite)
        {
            return Knapsack(kapasite, ağırlıklar, değerler, n2 - 1);
        }

        int dahilEtme = değerler[n2 - 1] + Knapsack(kapasite - ağırlıklar[n2 - 1], ağırlıklar, değerler, n2 - 1);
        int hariçBırakma = Knapsack(kapasite, ağırlıklar, değerler, n2 - 1);

        return Math.Max(dahilEtme, hariçBırakma);



    }
    #endregion



    #region ÖRNEK9 Bellman Ford Algoritması
    class Kenar
    {
        public int baslangicDugum;
        public int hedefDugum;
        public int uzaklik;

    }

    static void BellmanFord(int[,] graf, Kenar[] kenarlar, int baslangicDugumu, int dugumSayisi, int kenarSayisi)
    {
        int[] mesafeler = new int[dugumSayisi];
        int[] oncekiDugumler = new int[dugumSayisi];

        //Baslangıc dugumu harix tum mesafelerı sonsuz yap
        for (int i = 0; i < dugumSayisi; i++)
        {
            mesafeler[i] = int.MaxValue;
            oncekiDugumler[i] = -1;

        }

        //Baslangic dugumunun mesafesını sıfır yapıyorum

        mesafeler[baslangicDugumu] = 0;
        //Tüm dugumlerı dolasarak en kısa mesafelerı bul

        for (int i = 0; i < dugumSayisi - 1; i++)
        {
            for (int j = 0; j < kenarSayisi; j++)
            {
                int baslangic = kenarlar[j].baslangicDugum;
                int hedef = kenarlar[j].hedefDugum;
                int uzaklik = kenarlar[j].uzaklik;


                //mevcut dugumun mesafesı sonsuz değilse ve yenı yol daha kısa ise
                if (mesafeler[baslangic] != int.MaxValue && mesafeler[baslangic] + uzaklik < mesafeler[hedef])
                {
                    //yeni daha kısa yolu guncelle
                    mesafeler[hedef] = mesafeler[baslangic] + uzaklik;
                    oncekiDugumler[hedef] = baslangic;


                }
            }
        }
        Console.WriteLine("Düğüm    Mesafe  Nereden Geldim");
        for (int i = 0; i < dugumSayisi; i++)
        {
            Console.WriteLine(i + "\t" + mesafeler[i] + "\t" + oncekiDugumler[i]);
        }

    }
    #endregion



    static void Main(string[] args)
    {


        #region SINAVSORU1
        /*
         A, B, C harflerinden oluşan bir stringde kelimenin en başından itibaren her bir 4'lüde sadece 1 adet B bulunması isteniyor.
        Bu stringi kabul eden programı yazınız
        Örneğin; ACBC / ABAC/CAAB/ BAAC/ BCAA/ BCAC
         */


        Console.WriteLine("Bir string giriniz: ");
        string kelime = Console.ReadLine();
        int hata = 1;

        if (kelime.Length % 4 != 0)
        {
            Console.WriteLine("string kurala uymuyor.");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < kelime.Length; i += 4)
        {
            int adetB = 0;

            for (int j = i; j < i + 4; j++)
            {
                if (kelime[j] == 'B')
                    adetB++;
            }

            if (adetB != 1)
            {
                hata = 0;
                break;
            }
        }

        if (hata == 0)
            Console.WriteLine("Bu string kurala uymuyor");
        else
            Console.WriteLine("Bu string kurala uyuyor");

        //return;

        #endregion

        Console.WriteLine();



        #region SINAVSORU2

        uint A1 = 0xFFFF0000;
        uint A2 = 0x0000FFFF;
        ulong yeniSayi = ((ulong)A1 << 32) | A2;

        int enUzun = 0;
        int uzunluk = 0;

        for (int i = 0; i < 64; i++)
        {
            if ((yeniSayi & (1)) != 0)
            {
                uzunluk++;
                yeniSayi = yeniSayi >> 1;
            }

            else
            {
                enUzun = Math.Max(enUzun, uzunluk);
                uzunluk = 0;
            }
        }
        enUzun = Math.Max(enUzun, uzunluk);
        Console.WriteLine("En uzun 1 uzunluğu: " + enUzun);

        #endregion

        Console.WriteLine();



        #region ÖRNEK1 SubstringSorusu
        //static void Main kısmı

        string[] strler = { "zeynep", "eymen", "reyhan" };
        int boyut = strler.Length;
        string ortak = "";

        for (int i = 0; i < boyut; i++)
        {
            ortak = OrtakAltKelime(strler[i], strler[i + 1]);
            Console.WriteLine("Ortak alt kelime: " + ortak);
            break;

        }

        Console.WriteLine();

        #endregion



        #region ÖRNEK2 Dizideki En Büyük İlk 2 Elemanı Bulan Kod
        //yanlış çıktı veriyor

        Console.WriteLine("Dizideki En Büyük İlk 2 Elemanı Bulan Kod");
        int[] dizi = { 1, 23, 46, 78, 98, 99 };
        EnBuyuk2Eleman(dizi);

        Console.WriteLine();

        #endregion



        #region ÖRNEK3 Dengeli Sayı Mı? 

        //Sayı alınacak dengeli sayının bütün basamakları birbirinden farklı olması gerekiyoır ve tek ve çift sayısı birbirine eşit olmalı

        int n = 5;
        if (DengeliSayiMi(n))
            Console.WriteLine("dengeli");
        else Console.WriteLine("dengesiz");

        Console.WriteLine();
        #endregion


        #region ÖRNEK4 Metin içerisindeki en uzun polindrom kelimeyi bulma

        string metin = "buraya bir şeyler yazıyorum level";
        string uzunPolindrom = EnUzunPalindrom(metin);
        Console.WriteLine("En uzun polindromik kelime : " + uzunPolindrom);

        Console.WriteLine();
        #endregion



        #region ÖRNEK5 Çok diziyi tek bir dizide toplama. dizi boyutu onların toplamı kadar olmak zorunda

        int[] dizi1 = { 1, 3, 5, 7, 9 };
        int[] dizi2 = { 2, 4, 6, 8 };
        int[] dizi3 = { 10, 11, 12 };

        int[] birlesikDizi = DizileriBirlestir(dizi1, dizi2, dizi3);
        Console.WriteLine("Birleştirilmiş dizi: ");

        foreach (int sayı in birlesikDizi)
        {
            Console.Write(sayı + " ");
        }
        #endregion




        #region ÖRNEK6 a,b,c ve d farklı rakamlar olamak üzere (ab+cd)^2=abcd eşitliğini doğrulayan bütün abcd sayıların adedini bulup ekrana alt alta yazdıracak kod
        //abcd 4 basamaklı; ab ve cd ise 2 basamaklı sayılardır.
        Console.WriteLine();
        #endregion


        #region ÖRNEK7 Elimizde 50,20, 5 ,1 litrelik hacimlere sahip sınırsız şişe var
        //belli bir miktarda zeytinyağı bu şişeler kullanılarak paketlenecektir. Bu zeytinyağını minimum şişe kullanımıyla paketlenmesi gerkmektedir.
        //Yazılacak program kendisine zet,nyağının listre bilgiasini parametre alacak ve ekrana paketleme işlemi sonrasında hangi haimdeki şişenin kullandığını basacaktır.


        int zeytinyagiLitre = 123;

        MinimumSiseKullanimi(zeytinyagiLitre);



        #endregion




        #region ÖRNEK8 Knapsack Problemi

        int kapasite = 5;
        int[] agırlıklar = { 2, 1, 3, 2 };
        int[] degerler = { 12, 10, 20, 15 };
        int n2 = agırlıklar.Length;

        int sonuc = Knapsack(kapasite, agırlıklar, degerler, n2);
        Console.WriteLine(sonuc);

        #endregion




        #region ÖRNEK9 Bellman Ford Algoritması
        int dugumSayisi = 5;
        int kenarSayisi = 8;

        //Kenarları tanıma
        Kenar[] kenarlar = new Kenar[kenarSayisi];

        kenarlar[0] = new Kenar() { baslangicDugum = 0, hedefDugum = 1, uzaklik = -1 };
        kenarlar[1] = new Kenar() { baslangicDugum = 0, hedefDugum = 2, uzaklik = 4 };
        kenarlar[2] = new Kenar() { baslangicDugum = 1, hedefDugum = 2, uzaklik = 3 };
        kenarlar[3] = new Kenar() { baslangicDugum = 1, hedefDugum = 3, uzaklik = 2 };
        kenarlar[4] = new Kenar() { baslangicDugum = 1, hedefDugum = 4, uzaklik = 2 };
        kenarlar[5] = new Kenar() { baslangicDugum = 3, hedefDugum = 2, uzaklik = 5 };
        kenarlar[6] = new Kenar() { baslangicDugum = 3, hedefDugum = 1, uzaklik = 1 };
        kenarlar[7] = new Kenar() { baslangicDugum = 4, hedefDugum = 3, uzaklik = -3 };

        int baslangicDugum = 0;
        //BellmanFord algoritmasını uyguluyorum
        BellmanFord(new int[dugumSayisi, dugumSayisi], kenarlar, baslangicDugum, dugumSayisi, kenarSayisi);


        //Negatif döngü kontrolü 
        //for (int i = 0; i < kenarSayisi; i++)
        //{
        //    int baslangic = kenarlar[i].BaslangicDugum;
        //    int hedef = kenarlar[i].HedefDugum;
        //    int uzaklık = kenarlar[i].Uzaklik;

        //    //Negatif döngü tespit edilirse
        //    if (mesafeler[baslangic] != int.MaxValue && (mesafeler[baslangic] + uzaklık) < mesafeler[hedef])
        //    {
        //        Console.WriteLine("Negatif döngü bulundu. ");

        //    }
        //}
        #endregion
    }


}


















