
class Program
{
    static void Main(string[] args)
    {
        //ORNEK1
        #region    //int kendisine bir A dizisini parametre alacak ve bu dizinin aritmetik dizi olup olmadığını tespit etme

        // bir dizinin artimetik dizi olması için elemanlar arasında belli bir artış ya da azalış olmalı

        Console.WriteLine("ÖRNEK 1");
        int[] A = { 2, 4, 6, 8, 10, 12, 14 };
        if (SonluAritmetikDiziMi(A) == 1)
        {
            Console.WriteLine("Evet bu dizi aritmetik dizidir.");

        }
        else Console.WriteLine("Hayır bu dizi aritmetik dizi değildir.");

        Console.WriteLine();


        #endregion


        //ÖRNEK 2 
        #region      //Sonlu bir aritmetik dizi olup olmadığını belirlicez ama içinde bir çok sonlu aritmetik dizi olacak.
        //örneğin ilk 4 eleman aritmetik gidiyor
        //ama 5.eleman da ortak fark bozuldu sonra 5. elemanı takip eden elemanlar da aritmetik gidiyor ve bizim 2.zincir 1.den uzun olaca
        // en uzun diziyi ekrana yazdırma ve zincir uzunluğunu hesaplamamız lazım bunun için alt ve üst sınır belirleriz

        Console.WriteLine("ÖRNEK 2");

        int[] B = { 2, 4, 6, 8, 10, 12, 3, 6, 9, 12, 15, 18, 21, 24, 5, 10, 15 };
        int diziBoyutu2 = B.Length;
        int alt = 0;  //en uzun zincri nerede konumladığını bilmediğimiz 0 tanımlarız
        int ust = 0;
        int maksZincUz = 1; //min 1 olabilir.
        int zincirUz; //yakalanlan her bir dizi için zincir uzunluğu belirlenmeli

        for (int i = 0; i < diziBoyutu2 - 2; i++)
        {
            for (int j = i + 2; j < diziBoyutu2; j++)
            {
                if (SonluAritmetikDiziMi2(B, i, j) == 1)
                {

                    zincirUz = (j - i + 1);
                    if (zincirUz > maksZincUz)
                    {
                        maksZincUz = zincirUz;
                        alt = i;
                        ust = j;
                    }
                }
            }
        }
        if (maksZincUz != 1)
        {
            for (int i = alt; i <= ust; i++)
            {
                Console.Write(B[i] + " ");
            }
        }
        else Console.WriteLine("Aritmetik Dizi Yoktur.");

        #endregion
    }





    //ORNEK1

    static int SonluAritmetikDiziMi(int[] A)
    {

        int ortakFark = 1;
        int sonuc;
        int diziBoyutu = A.Length;
        if (diziBoyutu >= 3)  // bir dizinin aritmetik oladuğunu anlamamız için en az 3 eleman olmalı
        {
            sonuc = 1;
            ortakFark = A[1] - A[0]; //0 ve 1 i kontrol ettik
            for (int i = 3; i < diziBoyutu; i++) // artık 2 ve diğerlerinş kontrol edeceğimşz iöin 3 ten başladı
            {
                if ((A[i] - A[i - 1] != ortakFark))
                {
                    sonuc = 0;
                    break; //döngüden çıkılıyor
                }

            }
            return sonuc;

        }
        return 0;
    }




    //Örnek 2
    static int SonluAritmetikDiziMi2(int[] B, int alt, int ust)  // en uzun diziyi ekrana yazdırma ve zincir uzunluğunu hesaplamamız lazım bunun için alt ve üst sınır belirleriz
    {
        int ortakFark2 = 1;

        int sonuc2 = 1;

        int diziBoyutu2 = B.Length;

        if ((alt >= 0) && (ust < diziBoyutu2) && (ust - alt + 1) >= 3)
        {
            // alt sınıra en kötü 0.elemanda rastlayabiliriz onun dışında rastlayamayız
            // üst sınır da dizi boyutunu aşamaz ve 3 eleman şartı olduğundan üst sınırdan alt sınırı çıkarıp 1 ekleriz bunun da 3 ten büyük eşit olması lazım
            
            ortakFark2 = B[alt + 1] - B[alt]; //içinde bir sürü dizi olduğu için alt sınırın yanındaki elemandan alt sınırı çıkarıp ortak fark elde edicez

            for (int i = alt + 2; i <= ust; i++)  // alt + 2 ilk 2 elemanı pas geçip 3.elemandan başlamış oluyoruz.
            {
                if ((B[i] - B[i - 1] != ortakFark2))
                {

                    sonuc2 = 0;
                    break;
                }
            }
            return sonuc2;
        }
        return 0;
    }

}



