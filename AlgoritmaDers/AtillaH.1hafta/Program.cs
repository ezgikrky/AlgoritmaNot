/*
 
 Algoritma 

algoritma problem çözme sanatıdır. bilgisayarda bir problem verirler ve komutlarla onu çözeriz.bir problemi çözmek için komutlardan oluşan yapıdır. algoritma mantık dersidir.


bir algortimanın doğru olup olmadığını anlamanın yolu problemi check etmek ve sonucuna bakmaktır.

Algoritmanın performasnı için 2 temel unsur var 
1. Zaman: algoritmanın çalışma süresi, ne kadar zamanda çalışır, soncu ne kadar sürede üretir, rakiplere göre performans nasıldır gibi kriterler var. algoritmanın
performansını ölçerken zamanı boyutu netleştirilmelidir
2. Space: veri yapısının hafızada kapladığı yer.Kapladığı alanı söylemek yeterli

amaç algoritmyaı en hızlı, en performanslı, en az alan kullanarak çözmek. yukarıdaki 2 unsuru en optime etmek asıl amacıdır.




Algoritma analizi

Algoritmanın, problemin çözüm metotları ve bu çözümlerin yorumlamasını içerisinde bulunduran bir alandır. Yani çzöümleri kıyaslayacağız en iyi çözümü
bulmak için yorumlar yapıp bu yapılan yorumlarla da en iyi, en optimum çözümü bulucaz

algritmanın kodlanması, implemenatasyon, kod yazmak demektir. 
algoritmada programlama dillerinin temel alt yapısını kullanıcaz ve kıyaslama yaparken algoritmaların ne kadar iş yükü oluşturduğuna bakıcaz.

kullandığımız yazılım datadan bağımsız olması gerekiyor.  gerçekleştirdiğimiz algoritmanın iş yüküne bakıcaz

Matematiksel işlem kullanıcaz

Dikkat edilmesi gerekenler
1.Bir problemi çözmek için kaç adet komut olduğunu saymalıyız. yani algoritmanın komut sayıısına bakıcaz ve sonucunda da büyüme fonksiyonuna bakıcaz
2. Komut sayılarına göre de büyüme fonksiyonu geliştiricez ve bunun üzerinde de çalışıcaz


Algoritmanın zaman sürelerini ölçmek için basit 2 komut var


count= count +1;      Cost:c1 c1 süresinde çalışır

count= count +1;      Cost:c1     cost=maliyet
sum=sum+count;        Cost:c2

total Cost= c1+c2



//ÖRNEK 1
                                              Maliyet     Time
if (n<0)                                        с1          1    // Atama ifadeleri sabit maliyetli ondan dolayı 1 defa çalışır
  absval= -n                                    c2          1
else                                                                            
  absval= n                                    c3          1   


Toplam maliyet <= c1 + max(c2,c3)

performans olarak yani çalışma süresi olarak c2 nin süresi c3 ten daha fazladır.





//ÖRNEK 2

Döngü                                                        
                                              Maliyet     Defa
i = 1;                                          с1          1    // Atama ifadeleri sabit maliyetli ondan dolayı 1 defa çalışır
sum = 0;                                        c2          1
while (i <= n) {                                C3          n+1  // koşul ifadesi n kez çalışıyor 1 kez de koşulun gerçekleşmeme durumundan dolayı çalışoır ondan n+1
  i = i + 1;                                    c4          n    // döngü n kez döndüğü için n kez çalışıyor
  sum = sum + i;                                c5          n    // döngü n kez döndüğü için n kez çalışıyor
}


Total Cost = с1 + c2 + (n+1)*c3 + n*c4 + n*c5 = (c3+c4+c5)*n +  (c1+c2+c3)  = a*n+b 
O(n)

Bu algoritmanın büyüme hızı n değeri ile orantılıdır.

koşul ifadesi olan yerde maximum karmaşıklık, max işlem neredeyse onu dikkate alırız.
Bu Growth Rates oldu 








// İç içe döngülerde dıştaki döngü içteki satırlar üzerinde çarpan etkisi sağlar. Bu yüzden içteki döngüyü çözümleyip dıştaki döngü kaç kere dönüyorsa
onu çarpan olarak dağıtmak lazım

iç içe döngünün çalișma zamani analizi

 içiçe döngüler
                      Maliyet    Defa
                             
  i=1;                  c1         1
  sum == 0;             c2         1                       
  while (i <= n) {      с3         n+1                      
     j=1;               c4         n                // c4 normalde 1 olacaktı ama dıştaki döngü n kez döndüüğü için n ile çarptık            
     while (j <= n) {   с5         n* (n+1)               
        sum = sum + i;  c6         n*n                 
        j + 1;          c7         n*n                      
    }
    i = i +1;           с8         n
  }                    
                              
 Toplam Maliyet = с1 + c2 + (n+1)*c3 + +n*c4+n*(n+1)*c5+n*n*c6+n*n*c7+n*c8
 O(n^2)
 Bu algoritmanin çalișma zamani n^2 orantilidir.





Algorithm Growth Rates

bir algoritmanın problem size ı karşımıza çıktı
Problem size denildiğinde aklımıza n gelmeli
Algoritma geneldir. bütün algoritmalar problem size a göre çalışır. 
Bütün problemlerde n bizim bilinmeyenimizdir n e göre işlem yaparız.

Bir algoritma n^2/5 sürede diğer algoritma ise 7*n sürede çalışıyor. 
Hız açısından en hızlısı 7*n 'dir. çünkü n 'e bağlıdır.
n^2 ile çözülen algoritma verimli bir algoritma değildir. n^2 sorun çıkartır

Growth rates
n' e göre mi, n^2 ye göre mi yoksa n^3 e göre mi onu belirler.
içerisinde polinomik bir ifade var ve Growth rate içerisinde üstü en yüksek olan n i kabul eder
 

n=lineer doğru orantılı yaklaşım

c               Constant
logN            Logaritmik. Logarithmic
log^2(N)        Log-squared
N               lineer - Linear
NlogN           doğru orantılı logn
N^2             ikinci Dereceden Zaman:   - Quadratic
N^3             kübik   -  Cubic
2^N             verimli algoritma değil   Exponential



// En iyi Durum : Sabit Zamanlı durum
// En Kötü durum: Faktörieyele doğru gittiği durum yani aşağı indikçe kötüleşiyor

dizi elemanlarına ulaşım süresi constanttır yani c, n'den bağımsızdır.
n den bağımsızdır.




BIG -OH 

Büyüklük ölçüsüdür. O ile ifade edilir.
Big oh, Growth rate i  kabul eden ve buna göre ortaya bir algoritmanın hızını yorumlamamızı, anlamaızı kolaylaştıran bie notasyondur.
Big o notasyonu Growth rate in yorumlanması olarak ifade edebilir.


 

n
           —————-----------n-----------------——
Function | 10 100 1,000 10,000 100,000 1,000,000
1           1  1    1      1      1      1
logn        3  6    9      13     16     19
n           10 10^2 10^3   10^4   10^5   10^6
n*logn      30 664 9,965   10^5   10^6   10^7
n^2         
n^3          
2^n           


O(1): dizi elemanlarına ulaşım maliyeti
 

O(n^3 + 4n^2 + 3n)  => O(n^3)

O(5n^3)  =>  O(n^3)

O(f(n)) + O(g(n)) = O(f(n)+ g(n))    
O(n^3 ) +O(4n)  --> O(n^3 + 4n^2) =>  O(n^3)



 £ i  , i=1 den n'e kadar  = (n^2)/2
 £ i^2, i=1 den n'e kadar = (n^3)/3
 £ 2^i, i=0 dan n-1'e kadar = (2^n)-1






//ÖRNEK 3

for (i=1; i<=n; i++)              c1      n+1
  for (j=1; j<=i; j++)            c2      £(j+1)
    for (k=1; k<=j; k++)          c3      ££(k+1)
        x=x+1;                    C4      ££k


T(n) =a*n^3 + b*n^2  + c*n + d
O(n^3)

 */