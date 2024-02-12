class Program
{
    static void DoviziTurkLirasınıCevir(double dovizMiktari, double dovizkuru)
    {
        int adet = 0;
        int tlMiktari = Convert.ToInt32(Math.Ceiling(dovizkuru * dovizMiktari)); // dovizkuru * dovizMiktari tl ye çevirdik
        Console.WriteLine("Bozdurulan dövizin tl karşılığı: " + tlMiktari);

        string[] tlHucreDizi = { "İki Yüz", "Yüz", "Elli", "Yirmi", "On", "Beş", "Bir" }; //banknotların ne olduklarını gösteren string bir dizi

        double[] onlukTlVektoru = { 200, 100, 50, 20, 10, 5, 1 };  //sayısal karşılıklarını tutan dizi

        for (int i = 0; i < 7; i++)   //sayının tl miktarını sayıya kaç kere bölündüğü benim adetimdir
        {
            if (tlMiktari >= onlukTlVektoru[i])   
            {
                adet = Convert.ToInt32(Math.Floor(tlMiktari / onlukTlVektoru[i])); //virgüllü çıkmasın diye floor kullanıldı.
                Console.WriteLine(adet + " " + "adet  " + tlHucreDizi[i] + "  TL");
                tlMiktari = Convert.ToInt32((tlMiktari % onlukTlVektoru[i]));  //tl miktarını güncelleme
                if (tlMiktari == 0) break;

            }

        }

    }

    static void Main(string[] args)
    {
        //ÖRNEK1
        #region    //Elimizde döviz miktarı ve döviz kuru var. Elimizde 100,200, 50, 20,15,1 den oluşan banknotlar var.
        //Kullanıcıya parasını Tl'ye çevirip bunları en az kullanarak parasını vermeye çalışıcaz. Bunlardan kaçar tane kullandığını da ekrana basacak

        DoviziTurkLirasınıCevir(137, 16); //16 kurdan hesapladık


        Console.WriteLine();

        #endregion



        Console.WriteLine("ÖRNEK2");

        //ÖRNEK2

        #region  //Taksi şoförü yola çıkmadan önce km göstergesine bakıyor ve palindrom bir sayı görüyor. Daha sonra yola çıkıyor ve sürekli göstergeye bakıyor
        /* Bir an teta bir palindrom sayı yakalıyor ve hemen saatine bakıp yolculuğa çıkalı 40 dk old. görüyor. Bu şoförün ortalama hızını bulan kodu yazınız
        
         Palindrom sayı baştan ve sondan ayna görüntüsü
         

        Bir sayının tersini bulmak için birler basamağındaki sayıyı en yüksek mertebeye taşımak lazım ve bu mertebeler arası değişklikte de katsayıları gözetmek gerekiyor.
         */

        Console.WriteLine("Göstergede okunan 1. palindrom değer: 23932 ");
        int kmSayaci = 23933;
        int hiz;

        //polindrom sayı yakalayana kadar döndürecek yakalayınca döngüden çıkacak
        while (PalindromMu(kmSayaci) != true) //kmSayaci parametre olarak gönderdik true olmadığı sürece kmSayaci nı arttır
        { 
            kmSayaci++; 
        }

        Console.WriteLine("40 dk sonra göstergede okunan 2. palindrom sayi: {0}", kmSayaci);
        int yol = kmSayaci - 23932;
        hiz = (yol * 60) / 40; //dk olduğu için 60 ile çarptık
        Console.WriteLine("Şoförün hizi: {0} km/sa", hiz);

        #endregion
    }




    //ÖRNEK2

    static int SayininTersiniBul(int n) //sayının tersini bulan metıt
    {
        int nTers = 0;
        int birlerBas;

        while(n > 0)
        {
            birlerBas = n%10; //birler basamağı hesaplama 10 a göre modunu alma
            nTers= nTers*10+birlerBas; // nTers'e birler basamağını göndermemiz gerekiyor. Katsayı olarak 10'ar 10'ar arttığı için 10 ile çarpıldı
            n = n / 10; //güncelledik her zaman birler basamağını gönderecek
        }
        return nTers;

    }



    static bool PalindromMu(int n)
    {
        if(n == SayininTersiniBul(n)) //Elimizdeki n ile sayınıntersinibul a n'i gönderiyoruz oradan gelecek olan sayıya eşitse evet polindrom deriz.
            return true;
        else return false;
    }
}