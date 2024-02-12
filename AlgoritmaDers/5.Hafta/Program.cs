class Program
{
    static int OzelSayiMi(int sayi)
    {
        #region //kaprekar sabitleri: Bu sabitlerin karesi alındığında yeni oluşan sayıyı herhangi bir noktadan ikiye böldüğümüzde, bu iki parçanın toplamı tekrar sayının orijinal halinbi veriyorsa
        //bu sayılara kaprekar sabitler deniyor. ve bu iki sayının sıfırdan büyük olması gerekiyor.

        int sonuc = 0;
        double sayininKaresi;
        int kuvvet = 10;   //bir sayının birler basamağına erişirken 10'a göre modunu alıyoruz ondan 10 a eşitledik
        int kareninSagi;
        double kareninSolu; //double tanımlama sebebi 10 a bölünce virgüllü çıkacağı için

        if (sayi == 1) //sayı 1'e eşitse otomatik olarak onu kaprekar sayı olarak kabul ederler. Bu sayı özel sayı
        {
            sonuc = 1;  
        }

        if (sayi > 1)  //sayı 1 den büyükse önce bu sayının karesini almamız lazım.
        {
            sayininKaresi = Math.Pow(sayi, 2);     //Pow fonkdiyonu ile ilk önce sayıyı giriyoruz sonra da kaçıncı dereceden almak istediğimizi yazıyoruz. karesi olduğu için 2 yazdık
            while (kuvvet <= sayininKaresi)       // Basamaklarına bölmek istediğimiz için kuvvet sayınınKaresinden küçük ya da eşit olmalı
            {
                kareninSagi = Convert.ToInt32(sayininKaresi % kuvvet);
                kareninSolu = (sayininKaresi / 10);
                kareninSolu = Math.Floor(kareninSolu); //tekrar kareninSolunu güncelleyip kendisinden küçük bir tamsayıya yuvarladık

                if ((kareninSolu > 0) && (kareninSagi > 0) && (sayi == kareninSagi + kareninSolu))
                {
                    sonuc = 1;
                    break;
                }
                kuvvet = kuvvet * 10; //her bir iterasyonda 10 katı ile güncelledik.
            }
            return sonuc; // ve gelen sonuç değerini return ettik
        }
        else return sonuc;

        #endregion
    }

    static void Main(string[] args)
    {
        int sayi;
        int sonuc;
        Console.WriteLine("Bir sayi giriniz: ");
        sayi = Convert.ToInt32(Console.ReadLine());
        sonuc = OzelSayiMi(sayi); // sonuc değerine OzelSayı metotundan gelen cevap girildi, sayı parametre olarak gönderildi
        if (sonuc == 1) //sonuç 1 ise özel sayıdır değilse özel sayı değildir.
        { Console.WriteLine("Evet ozel sayi"); }
        else Console.WriteLine("Hayır özel sayi değil.");

    }
}





