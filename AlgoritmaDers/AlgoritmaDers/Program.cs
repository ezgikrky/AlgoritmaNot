//1.hafta

#region//fibonacci serisi: ilk 2 terimi sabittir.  0,1,1,2,3
      //Her terim kendisinden önceki iki terimin toplamından devam eder
 // Her sayının kendinden önceki ile toplanması sonucu oluşan bir sayı dizisidir.

       static int FibonacciSerisi(int n)
        {
            //int ilkSayi = 0, ikinciSayi = 1, sonuc = 0;
            if (n == 0) return 0;
            if (n == 1) return 1;


           // if (n == 0 || n==1) return n;
            
            //for (int i = 2; i <= n; i++)
            //{
            //    sonuc = ilkSayi + ikinciSayi;
            //    ilkSayi = ikinciSayi;
            //    ikinciSayi = sonuc;
            //}
            //return sonuc;


            //2.örnekte diğerlerini yorum satırına alıp bunu yazarız
            //Seriyi recursive olarak açıcaz
            return FibonacciSerisi(n - 1) + FibonacciSerisi(n - 2);
        }

        Console.Write("Fibonacci boyutunu gir: ");
        int length = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0} ", FibonacciSerisi(i));
        }

#endregion

Console.WriteLine();
Console.WriteLine("3.ÖRNEK");

#region//3.örnek serinin 3.elemanını nokta atışı olarak yazdırma
static int FibonacciSerisi3(int n)
        { 
            if (n == 0 || n==1) return n;
            
            return FibonacciSerisi3(n - 1) + FibonacciSerisi3(n - 2);
        }


        Console.Write("Fibonacci kaçıncı elemanı girece: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        sayi = sayi - 1; // seri 0 dan başlıyor bundan dolayı da sayıyı 1 eksiltip metoda parametre olarak göndericez
        Console.WriteLine(FibonacciSerisi3(sayi));

#endregion


Console.WriteLine();
Console.WriteLine("4.ÖRNEK");



//Örnek 4 
#region //Kendisine parametre olarak aldığı bir integer sayının basamakları toplamını recursive olarak hesaplayan kod
static int Sum(int n)
        {
            if (n != 0)
            {
                return (n % 10 + Sum(n / 10)); //sayı 131:  n % 10  birler basamağı 1 i aldı, Sum(n / 10) onlar basamağı 13 ü aldı sonra tekrar bu sefer 13 için aynısı yapılacak önce 3 ü alacak sonra da 1 i
            }
            else return 0;
        }

        Console.Write("Fibonacci kaçıncı elemanı girecek: ");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(Sum(sayi2));
#endregion