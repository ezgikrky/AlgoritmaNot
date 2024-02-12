#region LONGEST COMMEN SUBSEQUENCE

//stringe deki karakterler yan yana olmak zorunda değil
//sequence bir birliktelikler var ama aralarında karakterlerde olabilir.

/*
 0a12cc3v456x789   ---> sequence dediğimiz burada aradaki karakteri alıp yaklaştırınca string olunca demek
 accvx   stringi yukarıda dağılmış
 a00c12c3vx333  burada sequence leer var
 önce accvx yazdık sonra 0123 sequence oldu             
 0123
 a12cvx

 */




//      0  a  1  2  c  c  3  v  4  5  6  x

//  a   0  1  1  1  1  1  1  1  1  1  1  1      --> a 0 a eşit değil o zaman 0, a a ya eşit o zaman 1, a 1 e eşit değil burada a yı devam ettirriz 1 diye. sol taraftakini taşımış oluyoruz
//  0   1  1  1  1  1  1  1  1  1  1  1  1    --> 0 ile 0 1, diğer yanındaki 1 i oluştururken önce çapraza baktık 0 şimdi de  yukarısına ve soluna bakarız 0 ile a eşit değil eşit olmadığıiçin yukardaki ve solundakinin büyüğü alınır yani 1 aldık
//  0   1  1  1  1  1  1  1  1  1  1  1  1    
//  c   1  1  1  1  2  2  2  2  2  2  2  2   -->c ile c eşit çapraza baktık 1, 1 in bir fazlasını aldık 2. Şu ana kadar 2 tane çıktı
//  1   1  1  2  2  2  2  2  2  2  2  2  2   --> 1 ile 0 eşit değil yukarıya baktık 1 var 1 yazarz
//  2   1  1  2  3  3  3  3  3  3  3  3  3    --> 2 ile 1 eşit değil ama yukarı ve soluna bakınca en büyük 2 olduğu için 2 yazdık daha sonrasında 2 ile 2 gelince çaprazın bir fazlası 3 oldu
//  c   1  1  2  3  4  4  4  4  4  4  4  4
//  3   1  1  2  3  4  4  5  5  5  5  5  5
//  v   1  1  2  3  4  4  5  6  6  6  6  6   --> v 1'e eşit değil yukaeısına ve soluna baktık en büyük 2 o yüzden 2'yi aldık
//  x   1  1  2  3  4  4  5  6  6  6  6  7
//  3   1  1  2  3  4  4  5  6  6  6  6  7    --> 7 tane squence varmış



/*

 longest common subsequence

 a66b66cd
 a111c222d   --> acd aralarda farklı karakter olsa da yukarıdaki ile aynı sequence oldu

sequence; string demek değil, arada farklı karakterler olsa da sırası önemli yani a' dan sonra c gelmiş c'den sonra da d gelmiş

ÇÖZÜMÜ
1- matris oluşturulacak. bu matrisi oluşturmak için eleman sayılarının çarpımı kadar olacak
2- döngü oluşturulacak
 */

#endregion

class Program
{

    #region Örnek2-Longest Comman Subsequence
    static int max(int a, int b)
    {
        if (a > b) return a;
        else return b;
    }

    #endregion
    static void Main(string[] args)
    {


        #region Örnek1-PiSayısıHesaplama
        //pi=4(1/1-1/3+1/5-1/7+1/9-........)
        // ilk 10 bin teimin toplamını bılalım
        //pi sayısının seri acılımı buymuş bunun 10 bin terim için ekrana yazalım
        //tek sayılar şeklinde  gidiyor, tek sayıları 2n+1 ile yakalıya biliriz ama for'u 1 den başlatıp 2 şer arttırarak
        // gidersek daha rahat buluruz

        double toplam = 0;
        int f = 1;

        for (int i = 1; i < 10000; i = i + 2)
        {

            toplam = toplam + (double)1 / i * f; //   /5, /7 yi uyguladık ve 1 artı 1 eksi için de f ile çarptık
            f = f * -1; //artı 1 ve eksi 1 ile çarpma kısmını bıurada sagladık

        }
        Console.WriteLine(toplam * 4);
        Console.WriteLine();

        #endregion


        #region Örnek2-Longest Comman Subsequence

        string s1 = "a66b6666c777777d";
        string s2 = "a111c222d";
        int[,] dizi = new int[s1.Length, s2.Length]; //s1 satır s2 sütun oldu

        int deger = 0;

        //satırdaki elemanların hepsini sütundaki elemanlarla karşılaştırıcaz

        for (int i = 0; i < s1.Length; i++)  //s1.Lenght ile a yı alacak bütün s2 harfleri ile kıyaslayacak, byi alacak bütün harfleriyle kıyaslayacak yine c için de aynı
        {
            for (int j = 0; j < s2.Length; j++)
            {
                if (s1[i] == s2[j]) //eşitliği yakalarsak rakam arttırıcaz
                {
                    //i veya j nin herhangi biri 0 a eşitse 1 yaptık. hiç sağa sola bakmadık
                    if (i == 0 || j == 0) dizi[i, j] = 1;

                    //i veya j artık 0 değil şimdi sol çapraza bakarız 
                    else dizi[i, j] = dizi[i - 1, j - 1] + 1;  //sol çarprazı 1 arttırıp o noktaya eşitledik

                    if (deger < dizi[i, j]) deger = dizi[i, j];
                }

                else  //eşit değilse 1 üstün ve 1 solun üstünğ alıyoruz ama en yukarıdaysa(1.satırdaysa) bir solu alırız. en başta(1.sütundaysa) ise 1 yukarısını alırız 
                {

                    if (i == 0 && j == 0) dizi[i, j] = 0; //i ve j 0 'a eşitse

                    else
                    {
                        if (i == 0 || j == 0)
                        {
                            //ilk 2 if ile 1.satırın hepsi ile 1.sütunun hepsini çözmüş olduk

                            if (i == 0) dizi[i, j] = dizi[i, j - 1];
                            if (j == 0) dizi[i, j] = dizi[i - 1, j];
                        }

                        //geri kalanı sol ve yukarı bakıp en büyüğünü alma durumu
                        else dizi[i, j] = max(dizi[i - 1, j], dizi[i, j - 1]);
                    }

                }

            }
        }
        Console.WriteLine(deger);
        Console.WriteLine();


        #endregion


        #region ÖRNEK3-STRİNG İÇİNDE KELİME ARAMA STATE

        //abcdef stringi içinde de var mı?
        //ilk state q0    d gelirse q1 denir
        // q1 deyken d gelirse q1 de kalmaya devam, e gelirse q2 ye git
        // q2 ne gelirse gelsin q2 de kal


        string str = "abcdef";
        int[,] q = new int[3, 10]; // q0,q1,q2 olarak 3 state var. abcdef 10 diye sınırlayalım
        int state = 0;

        q[0, 4] = 1; //q0 dayken d yani abcdef de 4.sıradaki d gelince 1 e götürecek. diğer durumlarda yerinde sayacak

        q[1, 5] = 2; //q1 deyken e gelince 2 ye gidecek
        q[1, 4] = 2; //q1 deyken tekrar d gelirse yerinde duracak


        //q[2, 0] = 2;
        //q[2, 1] = 2;
        //q[2, 2] = 2;
        //q[2, 3] = 2;
        //q[2, 4] = 2;
        //q[2, 5] = 2;
        //q[2, 6] = 2;


        //yukarıdaki gibi yazmak yerine for döngüsüne aldık
        for (int i = 0; i < 10; i++)
        {
            q[2, i] = 2;
        }

        for (int i = 0; i < str.Length; i++)
        {
            state = q[state, str[i] - 'a'];
        }
        if (state == 2) Console.WriteLine("tamam"); else Console.WriteLine("olmadı");


        Console.WriteLine();
        #endregion


        #region ÖRNEK4-State

        // abcccccabcabcccccab   ab den sonra en az 1 tane c gelecek bu sürekli tekrar edecek


        s1 = "abcccccabcabcccccab";

        q = new int[5, 3];
        state = 0;

        q[0, 0] = 1;
        q[0, 1] = 4;
        q[0, 2] = 4;

        q[1, 0] = 4;
        q[1, 2] = 4;
        q[1, 1] = 2;

        q[2, 0] = 4;
        q[2, 1] = 4;
        q[2, 2] = 3;

        q[3, 0] = 1;
        q[3, 1] = 4;
        q[3, 2] = 3;

        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - 'a'];

        }
        if (state == 3) Console.WriteLine("tebrikler");
        else Console.WriteLine("olmadı");
        #endregion


        #region ÖRNEK5-Stringdeki Tek sayıdaki sayılar 1 olmalı mesela 1010101 gibi 1 3 5 ... gibi buradakiler 1 olmalı 11111111  de olabilir

        s1 = "111111";

        q = new int[3, 2];
        state = 0;

        q[0, 0] = 2;
        q[0, 1] = 1;

        q[1, 0] = 0;
        q[1, 1] = 0;

        q[2, 0] = 2;
        q[2, 1] = 2;

        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - '0'];
        }

        if (state != 2) Console.WriteLine("tebrikler"); // hem q0 a hem de q1 e gitmesini kabul ediyoruz. kabul etmediğimiz dead state(qN)
                                                        // state 2 den farklıysa tebrikler
        else Console.WriteLine("olmadı");

        Console.WriteLine();
        #endregion


        #region ÖRNEK6- İçerisinde 00 ve 11 olmayan state 

        s1 = "1010101011";

        q = new int[4, 2];
        state = 0;

        q[0, 0] = 2;
        q[0, 1] = 1;

        q[1, 0] = 2;
        q[1, 1] = 3;

        q[2, 0] = 3;
        q[2, 1] = 1;

        q[3, 0] = 3;
        q[3, 1] = 3;

        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - '0'];

        }
        if (state != 3) Console.WriteLine("tebrikler");
        else Console.WriteLine("olmadı");


        Console.WriteLine();
        #endregion






        #region 9.HAFTA
        #endregion


        Console.WriteLine("9.HAFTA");

        #region ÖRNEK9.1 abcdefghi   abc def ghi olacak şekilde 3 erli gruplar halinde sıralı halde gelmesi lazım

        // abcdefghi   İNPUT İÇİN 9 HARFİMİZ VAR ALFABE DERİZ BUNA
        // abc def ghi olacak şekilde 3 erli gruplar halinde sıralı halde gelmesi lazım
        //  1   2   3
        // her gruptan 1 tane ve gruplar sırasıyla gelecekler 123123123... şeklinde olabilir

        // adh kabul, a kabul, ad kabul, d kabul değil, h kabul değil, dh da kabul değil

        // q0 dayken abc geldiğinde q1 e gidicez diğer durumlarda kabul etmeyeceğiz
        // q1'deyken def bekliyoruz bunlar gelirse q2, diğer durumlarda kabul edilmiyor
        // q2 deyken ghi geldiğinde q0 a git yoksa reddedilecek

        //Yani

        // q0   abc   q1;
        // q1   def   q2
        // q2   ghi   q0

        s1 = "dh";

        q = new int[4, 9]; // 4 state var(q0 q1 q2 qn) 9 tane de inputumuz var
        state = 0;


        for (int i = 3; i < 9; i++)
        {
            q[0, i] = 3;   // q0 da 3-9(defghi) arasında gelirse dead state e git
        }

        q[0, 0] = 1; // q0 da a gelince q1 e git
        q[0, 1] = 1;
        q[0, 2] = 1;






        for (int i = 0; i < 9; i++)  //aradaki 3 4 ve 5 i aşağıda ayırdık
        {
            q[1, i] = 3;
        }


        q[1, 3] = 2;
        q[1, 4] = 2;
        q[1, 5] = 2;





        for (int i = 0; i < 6; i++)
        {
            q[2, i] = 3;
        }

        q[2, 6] = 0; //g
        q[2, 7] = 0; //h
        q[2, 8] = 0; //i



        for (int i = 0; i < 9; i++)
        {
            q[3, i] = 3;
        }




        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - 'a'];

        }
        if (state != 3) Console.WriteLine("tebrikler");
        else Console.WriteLine("olmadı");

        Console.WriteLine();
        #endregion





        #region ÖRNEK9.2 1 ve 0 lardan oluşan sonsuz bir string yapımız var bu sayıyı alıp mod 5 e göre kalan 2 ise sayıyı kabul edicez yoksa etmeyeceğiz 

        /*
         1 ve 0 lardan oluşan sonsuz bir string yapımız var bu sayıyı alıp mod 5 e göre kalan 2 ise sayıyı kabul edicez yoksa etmeyeceğiz
         

        1000   8 oldu bunun 5 e bölümünden kalan    5*1+3 ten 3 oldu o zaman olmaz
        10000  16 oldu bunun 5 e bölümünden kalan  (5*1+3)*2 = 5*1+6 dan 6 oldu yani 2 katı arttı 6 yı da 5+1 olarak yazarız kalan 1 oldu
         
         */

        s1 = "1001111111011";

        q = new int[5, 2];
        state = 0;


        q[0, 0] = 0;
        q[0, 1] = 1;

        q[1, 0] = 2;
        q[1, 1] = 3;

        q[2, 0] = 4;
        q[2, 1] = 0;

        q[3, 0] = 1;
        q[3, 1] = 2;

        q[4, 0] = 3;
        q[4, 1] = 4;



        for (int i = 0; i < s1.Length; i++)
        {
            state = q[state, s1[i] - '0'];

        }
        if (state != 2) Console.WriteLine("tebrikler");
        else Console.WriteLine("olmadı");

        #endregion


        #region VERİ SIKIŞTIRMA-ZİPLEME

        /* VERİ SIKIŞTIRMA
         
        Tüm dosyalar tek boyutlu bu yüzden ram yetmediği yerde rahatça dosyaları kullanabiliriz.
        Verinin temel taşını harfler-karakterler oluşturur
        255 adet karakter var. Bu karakterlerin her biri bir sayı ile ifade edilir.
        A,B,C..Z, a...z, 0..9, ŞİĞÜÖ
        Her birinin bir sayı karşılığı var A=65, B=66, C=67 ... sıra ile devam eder
        8 bit ile ifade edilir ve biz buna ASCI deriz
        Veri sıkıştırmada amaç daha az yer kaplamasıdır.



              Veriyi küçültme

          AAAABBCD      buradaki verileri sıkıştıralım. Her biri 8 bit. 8 karakter olduğu için 64 bitte sakladık. Veri orjinal veri

        A yı 65 olarak yazıp B yi 66 C 67, D 68

        65,65,65,65,66,66,67,68 --> A YI b Yİ c Yİ d Yİ BÖYLE SAKLAMAK YERİNE AŞAĞIDAKİ GİBİ SAKLANABİLİR
        00 00 00 00 01 01 10 11 --> 16 BİT OLDU. 64 BİTİ 16 BİTE DÜŞÜRDÜK

        A = 00
        B = 01
        C = 10
        D = 11



        Sıkıştırma algoritmaları 2 ye ayrılı kayıplı ve kayıpsız algoritmalar

        Kayıpsız algoritma: bir veriyi alırsın sıkıştırırsın ilk veri ile açtığın veri aynı ise kayıpsız
        Kayıplı algoritma: bir veriyi alırsın sıkıştırırsın ilk veri ile açtığın veri farklı ise kayıplı

        Kayıplı algoritmalar daha çok sıkıştırılır. Kayıplı sıkıştırma daha az yer kaplar.Kayıpsızsa veri sıkıştırma oranı daha azdır.




        A = 00
        B = 01
        C = 1
        D = 1

        00 00 00 00 01 01  1  1    --> 14 bit oldu kayıplı oldu C ve D yi 1 olarak kabul ettik
        A   A  A  A  B  B  C  C    oldu D kayboldu 

        o yüzden exe,text, word, pdf dosyalar önemli kayıpsız saklanmalılar

        Kayıplı olarak saklanacak dosyalar ses, görüntü



        ABABABCD saklanacak burada AB yi bir bütün olarak kabul edebiliriz

        AB    1
        C     00
        D     01

        ABABABCD
        1110001 oldu burada da 

        Sıkıştırma algoritmaları 2 ye ayrılır. Sıkıştırm algoritmalarında birincisinde karakter temelli gidilir. Bir de word temelli gidilir.
        yan yana olanları gruplaya gruplaya gidebiliyoruz

        Bütün zip dosyaların header ı vardır. Karakterleri alır, işler ve asci A yı 10 ya da 1 e döndürdüm. Biz zaten A nın B nin karşılıpını
        bu şekilde biliriz.

        Sıkıştırılan karakter, eleman arttıkça veri düşer

         */

        #endregion



        #region HUFFMAN

        /*
         
        Huffman'ın 2 temel özelliği var:
        1- Karakterlerin sayısal ifadelerini yeniden belirledi. Yani kullanmadığımız karakterleri yok sayıp kullandığımız karakterlerden yeni bir ascii tablosu oluşturdu
        2- Çok fazla tekrar eden karakterleri daha az bitle kodlarız. Yani Frekansı yüksek olan karakterlerin bit karşılıklarını küçük yapıp sıkıştırınca daha az yer 
        kaplamış olsun

        

       1)  AAAAAA  bu veriyi sıkıştırıken 1 byte 1 byte yazarz 6 byte oldu
         
        65 65 65 65 65 65   8 bit olacak şekilde yazıyourz ve 8*6= 48 bitlik yer işgal ediyor
        1  1  1  1  1  1  = 1 bit*6 = 6 bit e düşürdü huffman
         
        Huffman diyor ki; 65 i diğer karakterlere göre verdin 256 tane farklı karakter old. için 65 verdin diyor. Sıkıştırma yaptığın yerde hiç farklı grup yok sadece 1 tane var
        o zaman A'yı 65 ile değilde 1 ile ifade et 

        Huffman 48 bitten 6 bite düşürdü
         
         
         
        AAAAABCD bunu gruplandırırsak 4 tane var   8*8= 64 bitti

        A=00
        B=01
        C=10
        D=11 diye kodlarız

        0000000000 01 10 11   => 8 karakteri böylelikle 16 bite indirdik
        



        2) AAAAABCD  = 8*8=64 bit
           
        A=0
        B=101
        C=100
        D=111   diye kdolarsak

        00000 101 100 111  = 14 bit etmiş oldu yani biz yukarıdaki 16 bitten 14 bite düşürmüş olduk





        HUFFMAN NE ZAMAN VERİMLİ OLMAZ?

        1- Karakter sayısı 8 bit ile temsil edilecek olursa verimli olmaz. yani karakter sayısı çok fazlaysa
        2- Frekanslar birbirine yakın olursa faydası olmaz


         */


        #endregion


        #region HEADER-HUFFMAN TREE OLUŞTURMA

        /*
         Veri sıkıştırıcaz, Dosyaları aldık, karakterleri bulduk ve frekansları çıkarttık
        20 karakter olsun ve frkeanslarda dağılmış olsun şimdi bunu sıkıştırıcaz. 20 karaktere göre yeni bir kod yazdık ve sıkıştırdık diyelim
        A...J ye kadar karakter olsun ve bunu açıcaz. açmak için her bir karakterin yeni karşılık gelen ascii değerini bilemeyiz
        Bunun için Başlık denilen Header Ön Bilgi Bölümüne ihtiyacımız var
         
         
        Burada HUFFMAN TREE OLUŞTURULMASI var. Bunu oluşturmk için önce frekansları alırız. Frekansların alonması derken her bir harf kaç adet kullanılmış onun çözümünü 
        sunmuş olur.
         
        
            A-15, B-7, C-6, D-6, E-5 er tane varlar. En düşük 2 taneyi alıyoruz. En düşük D ve E var ikisini aldık toplamı 5+6 dan 11 böylelikle 
            1 tane tree oluşuyor

            A-15, B-7, C-6,   -11    oldu 11 in altında D ve E var ağaç oldu tekrardan en küçük iki taneyi alırsakta B ve C yi alırız.
            B+C den 13 olur

            A-15,   -13,   -11      burada da 13 ün altında B ve C var şimdi tekrar sıralarsak en düşükler 11 ve 13 var o ikisini alırsak 24 eder
            böyle byle ilerler

            Aşağıdaki linkte fotoğrafı mevcut

            https://upload.wikimedia.org/wikipedia/commons/d/d8/HuffmanCodeAlg.png


            tree nin sol tarafına 0, sağ tarafına 1 dersek A, B, C, D, E aşağıdaki gibi olur

            A  0
            B  100   
            C  101
            D  110
            E  111

         */

        #endregion



        #region örnek9.3 FrekansBulma
        string s = "abcabbbbbbbbbcdbd";
        int[] x = new int[6];
        for (int i = 0; i < s.Length; i++)
        {
            x[s[i] - 'a']++; //ascii karşılıpından düştük
        }


        Console.WriteLine();
        #endregion








        #region 10.HAFTA
        #endregion
        Console.WriteLine("10.HAFTA");


        #region Örnek10.1 Huffman Tree Oluşturma


        //btree[] bt = new btree[5];//hufmana uygukayacagım dizi,4 farklı karakter oldugu için 4


        ////  hufmann tree ve her bir kodun string
        //// sıkıştırma işlemi

        //string st = "aaaaaaaabcd";//ziplencek data
        //                                             //             00111110010


        //for (int i = 0; i < bt.Length; i++)
        //{
        //    bt[i] = new btree();
        //    bt[i].data = 1; //frekansları direkt 1 olarak yazdık
        //    bt[i].ch = 'a' + i;

        //}

        //bt[0].data = 124;

        //Array.Sort(bt, (object x, object y) => {//.net özellikleriyle sort etme

        //    // 0 eşitlik durumu, -1 küçüklük durumu, 1 büyüklük durumu
        //    int a = 0;
        //    if (x == null && y == null) return 0;
        //    if (x == null) return 1;
        //    if (y == null) return -1;
        //    if (((btree)x).data < ((btree)y).data) a = -1;
        //    if (((btree)x).data > ((btree)y).data) a = 1;
        //    return a;
        //});
        //huffmantreeolustur(bt);

        //huffmanstryaz(bt[0], "");
        //huffmantreeyaz(bt[0]);

        Btree[] bts = new Btree[50];//hufmana uygukayacagım dizi,50 farklı karakter oldugu için 50


        //  hufmann tree ve her bir kodun string
        // sıkıştırma işlemi

        string data = "AAABABBBBAAAACDEFGHJKLSDFGHJ";//ziplencek data
                                                     //             00111110010


        //frekansların bulunması, adet sayısı
        int[] frekans = new int[255];
        for (int i = 0; i < data.Length; i++)
        {
            frekans[data[i]]++;
        }


        for (int i = 0; i < data.Length; i++)
        {
            if (frekans[data[i]] > 0)
            {
                bts[i] = new Btree();
                bts[i].data = frekans[data[i]];
                bts[i].ch = data[i];
                frekans[data[i]] = 0;// giderken tekrar tekrar gelmesin diye
            }
        }

        Array.Sort(bts, (object x, object y) => {//.net özellikleriyle sort etme
            int a = 0;
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            if (((Btree)x).data < ((Btree)y).data) a = -1;
            if (((Btree)x).data > ((Btree)y).data) a = 1;
            return a;
        });
        tree(bts);
        yazBtree(bts[0], "");
        string hufman = "";
        for (int i = 0; i < data.Length; i++)
        {
            hufman = hufman + hf[data[i]];
        }

        Console.WriteLine(hufman);
        //  11110011010101
        Console.WriteLine(hufman.Length);
        Console.WriteLine(data.Length * 8);
        string ln = "";
        string unzip = "";
        for (int i = 0; i < hufman.Length; i++)
        {
            int adet = 0;
            int jvalue = 0;
            ln = ln + hufman[i];
            bool find = true;
            for (int j = 0; j < 255; j++)
            {
                if (chars[j] > 0) if (reverse(hf[j], ln)) { adet++; jvalue = j; }
            }
            if (adet == 1) { ln = ""; unzip = unzip + ((char)jvalue).ToString(); }
            adet = 0;
        }
        Console.WriteLine("--------------");
        Console.WriteLine(unzip);
        Console.WriteLine(data);



        #endregion



    }

    #region Örnek10.1 Huffman Tree Oluşturma


    //class btree
    //{
    //    public int data;//frekans da yazılabilir
    //    public int ch;//karakter hangi ascii karakteri
    //    public string hufman;//onun 01 00 11 gibi karşılıgı
    //    public btree left;
    //    public btree right;
    //}

    //static void huffmantreeolustur(btree[] bt)//reqursive tree oluşturma, resimdeki gibi agac yapısı yapma    
    //{
    //    if (bt[0]== null) return;

    //    btree b= new btree();
    //    b.left = bt[0];
    //    b.right = bt[1];
    //    b.data = bt[0].data + bt[1].data;

    //    bt[0] = b;
    //    bt[1] = null;

    //    Array.Sort(bt, (object x, object y) => {//.net özellikleriyle sort etme

    //        // 0 eşitlik durumu, -1 küçüklük durumu, 1 büyüklük durumu
    //        int a = 0;
    //        if (x == null && y == null) return 0;
    //        if (x == null) return 1;
    //        if (y == null) return -1;
    //        if (((btree)x).data < ((btree)y).data) a = -1;
    //        if (((btree)x).data > ((btree)y).data) a = 1;
    //        return a;
    //    });

    //    huffmantreeolustur(bt);

    //}

    //static void huffmanstryaz(btree bt, string yon)
    //{
    //    if(bt== null) return;

    //    if (bt.left == null)  bt.hufman = yon;
    //    huffmanstryaz(bt.left, yon + "0");

    //    if (bt.right == null) bt.hufman = yon;
    //    huffmanstryaz(bt.right, yon + "1");
    //}

    //static void huffmantreeyaz(btree bt)
    //{
    //    if (bt == null) return;
    //    if (bt.left == null) Console.WriteLine("{0}      {1}", (char)bt.ch, bt.hufman);
    //    huffmantreeyaz(bt.left);
    //    huffmantreeyaz(bt.right);
    //    //  2 ^n 

    //}


    static void yazBtree(Btree bt, string yon)
    {
        if (bt == null) return;
        if (bt.left == null)
        {
            bt.hufman = yon;
            chars[bt.ch] = bt.ch;
            hf[bt.ch] = yon;
        }
        yazBtree(bt.left, yon + "0");
        if (bt.right == null) bt.hufman = yon;
        yazBtree(bt.right, yon + "1");
    }
    class Btree
    {
        public int data;//frekans da yazılabilir
        public int ch;//karakter hangi ascii karakteri
        public string hufman;//onun 01 00 11 gibi karşılıgı
        public Btree left;
        public Btree right;
    }
    static Btree local(Btree a, Btree b)
    {
        Btree bt = new Btree();
        bt.data = a.data + b.data;
        bt.left = a;
        bt.right = b;
        return bt;
    }
    //   b 1; c 1; d 1; a3
    static void tree(Btree[] bt)//reqursive tree oluşturma, resimdeki gibi agac yapısı yapma    
    {
        if (bt[1] == null) return;
        bt[0] = local(bt[0], bt[1]);
        bt[1] = null;

        Array.Sort(bt, (object x, object y) => {
            int a = 0;
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            if (((Btree)x).data < ((Btree)y).data) a = -1;
            if (((Btree)x).data > ((Btree)y).data) a = 1;
            return a;
        });
        tree(bt);
    }
    static void yazBtreeSonuc(Btree bt)
    {
        if (bt == null) return;
        if (bt.left == null) Console.WriteLine("{0}      {1}", (char)bt.ch, bt.hufman);
        yazBtreeSonuc(bt.left);
        yazBtreeSonuc(bt.right);
        //  2 ^n 

    }
    static int[] chars = new int[255];
    static string[] hf = new string[255];

    static bool reverse(string hf, string kontrol)
    {
        bool f = true;
        for (int i = 0; i < hf.Length && i < kontrol.Length; i++)
        {
            if (hf[i] != kontrol[i]) { f = false; break; }
        }
        return f;
    }
    #endregion
}

