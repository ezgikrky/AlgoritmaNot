
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {

        //ÖRNEK1
        // 1234 string hale dönüştürme
        // 1234 - 1234/10*10 = 1234 - 1230=4           (1234/10)*10 =1230
        // 123 -123/10*10 =3

        int a = 1234;
        string s = "";

        while (a > 0)
        {
            s = (char)((a - a / 10 * 10) + '0') + s; //'0' asci başlangıç. 1234 - 1234/10*10 = 1234 - 1230=4,  4 ü aldık. stringi almak içinde '0'yazıp 0 ile topladık.
                                                     //string sağa doğru genişlediği için  +s'yi en sona yazdık
            a = a / 10;
        }
        Console.WriteLine(s);


        Console.WriteLine();






        //ÖRNEK2
        // Verilen 2 stringin en uzun ortak substringini bul. longest common substring 
        // ab , fg , d, hjk 
        // en uzun olanı hjk bunu istiyoruz
        string s1 = "abcdefghjkl";
        string s2 = "abxfgdhjkq";


        //substring state li ya da state siz olarak iç  içe 2 döngü ile çözülebilir. Ama iç içe döngü maliyeti arttırır
        // matris kulanıcaz
        // bu stringleri 1. stringlerimiz satırları, 2. stringlermiz sütunları ifade edecek. Sorguluyoruz a 0 ile eşit mi değil o zaman 0,  a 1 e eşit mi değil 0, a!=d o zaman 0 a a ya eşit mi evet o zaman 1 böyle gider
        // burada çaprazına bak çaprazındakinin 1 fazlasını a kuralı var

        //     a  b  c  d  e  f  g  h  j  k  l
        //  a  1  0  0  0  0  0  0  0  0  0  0
        //  b  0  2  0  0  0  0  0  0  0  0  0  // sol çaprazına baktık 1 var bir fazlasını alınca 2 yazdık. Yani ondan önce gelen string demek
        //  x  0  0  0  0  0  0  0  0  0  0  0
        //  f  0  0  0  0  0  1  0  0  0  0  0  // f ile f eşit sol çaprazında 0 var o zaman f 1 olur
        //  g  0  0  0  0  0  0  2  0  0  0  0
        //  d  0  0  0  1  0  0  0  0  0  0  0  
        //  h  0  0  0  0  0  0  0  1  0  0  0  // çaprazda 0 var +1 i 1
        //  j  0  0  0  0  0  0  0  0  2  0  0  //çaprazda g var 1+1 den h 2 oldu
        //  k  0  0  0  0  0  0  0  0  0  3  0
        //  q  0  0  0  0  0  0  0  0  0  0  0


        int[,] lcs=new int[s2.Length, s1.Length]; //2 boyutlu dizi. 

        int eblcs = 0;
        for (int i = 0; i < s2.Length; i++)  
        {
            for (int j = 0; j < s1.Length; j++) // en baştan en sona doğru 2.döngü oluşturduk
            {
                if (s2[i] == s1[j]) 
                {
                    if (i == 0 || j == 0) // i ya da j 0 ise 
                        lcs[i, j] = 1;    // 1 yap
                    else
                        lcs[i, j] = lcs[i - 1, j - 1]+1;       //diğer durumda sol çapraza git ve 1 fazlasını yaz
                    if (eblcs < lcs[i, j]) eblcs = lcs[i, j];  
                }
            }
        }
        Console.WriteLine(eblcs);
        //BigO = O(n*m)

        Console.WriteLine();






        //ÖRNEK3
        // Polinromic sağdan ve soldan okunduğunda aynı olan 12321 gibi
        // Verilen stringin en uzun palinromic kelimesini bulun
        //hocanın çözümü stringi tersten al lcs gibi çöz

        s1 = "ahmet12321adetmumsatsana";
        s2 = "anastasmumteda12321temha";

        lcs = new int[s2.Length, s1.Length];

        eblcs = 0;
        for (int i = 0; i < s2.Length; i++)
        {
            for (int j = 0; j < s1.Length; j++) // en baştan en sona doğru 2.döngü oluşturduk
            {
                if (s2[i] == s1[j])
                {
                    if (i == 0 || j == 0)
                        lcs[i, j] = 1;
                    else
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    if (eblcs < lcs[i, j]) eblcs = lcs[i, j];
                }
            }
        }
        Console.WriteLine(eblcs);
        Console.WriteLine();





        //ÖRNEK4
        //Stringin içerisinde başka bir string var mı

        s1 = "ahmet 12321 adet mum satsana";
        s2 = "satana";
        lcs = new int[s2.Length, s1.Length];
                        
        eblcs = 0;
        for (int i = 0; i < s2.Length; i++)
        {
            for (int j = 0; j < s1.Length; j++) // en baştan en sona doğru 2.döngü oluşturduk
            {
                if (s2[i] == s1[j])
                {
                    if (i == 0 || j == 0)
                        lcs[i, j] = 1;
                    else
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    if (eblcs < lcs[i, j]) eblcs = lcs[i, j];
                }
            }
        }
        if(eblcs==s2.Length)Console.WriteLine("bulundu");
        else Console.WriteLine("bulunamadı");

        //BİGO= O(n*m)

        Console.WriteLine();






        //örnek4 ün daha hızlı çözümü mevcut. otomata tarzı çözüm 

        s1 = "abfabccdefgh";
        //          a=0; b=1; c=2;d=3;e=4;
        s2 = "abc";


        int[,] q = new int[4, 40];  // 4 state var, her state te 40 input var, hoca 40 ı kafasına göre verdi   0 dayken a gelince 1 e gitti a dayken b gelince 2 ye gitti ,
                                    // b deyken c gelince 3 e gitti toplamda 4 state oldu
        int state = 0;

        //a = 0; b = 1; c = 2; d = 3; e = 4;

        q[0, 0] = 1;  // q 0'dayken a geldiğinde 1'e gidecek (yukarıda a nın 0 olduğunu yazmıştım a=0)
        q[1, 1] = 2;  // q 1'deyken 1(b) geldiğinde 2'ye gidecek.
        q[1, 0] = 1;  // q 1'deyken 0(a) geldiğinde 1'de kalacak
        q[2, 2] = 3;  // q 2'deyken 2(c) geldiğinde 3'e gidecek
        q[2, 0] = 1;  // q 2'deyken 0(a) geldiğinde 1'e dönecek

        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - 'a']; //state'in yeni durumu q nun mevcut state'e göre s1'in i.karakterini alıp ve bundan asci olarak a düştü.  
                                           //mevcut state'teyiz input a geldi. a'yı sayıya dönüştürmek  için -'a' yazıldı. a yı da çıkartınca asci olarak 0 1 2 3 kaldı ve yeni state değerleri eklemiş olduk
            if (state == 3) //3' e gelip bulduğumuz için devam etmemize gerek yok
            { 
                Console.WriteLine("canım bulundu"); 
                break; 
            }
        }
        Console.WriteLine();







        //ÖRNEK5
        // her ab den sonra en az 1 adet c gelmeli,  ab den sonra c gelmez ve ab tekrar gelirse strng kabul edilmeyecek dead state olacak
        //state fotosu telefonda

         s1 = "abfabdcdefgh";
        //          a=0; b=1; c=2; d=3; e=4;
         s2 = "abc";


         q = new int[5, 40]; //5 state  var
         state = 0;



        q[0, 0] = 1;
        q[1, 1] = 2;


        for (int i = 0; i < 40; i++) // c ve a hariç hepsini kend,nde dönüyor ondan dolayı böyle yazdık diğer a ve c olayını ayriyeten ekledik
        {
            q[2, i] = 2;
        }

        q[2, 2] = 0; // 2deyken 2(c) gelirse 0 a gidecek
        q[2, 0] = 3; // 2 deyken a gelirse 3 e gidecek


        for (int i = 0; i < 40; i++) // 3 teyken ne gelirse gelsin hepsini 2 ye gönder
        {
            q[3, i] = 2;
        }

        q[3, 0] = 3; // ama bunlar gelirse de böyle yap diye ekstra ekledik daha kolaylaştı
        q[3, 1] = 4;
        q[3, 3] = 0;


        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - 'a']; 
            if (state == 4) 
            { 
                Console.WriteLine("dead state");
                break; 
            }
        }
        if (state == 2) Console.WriteLine("ret"); // state olarak hala 2 de kaldıysak ret 



   
    
}
}



