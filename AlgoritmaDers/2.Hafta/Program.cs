class Program
{

    //1.ÖRNEK

    #region // a dizisinin içinde b dizisi var mı yani dizi içerisinde dizi mevcut mu bakıcaz
    // A=1,5,4,2,2,6,9
    //B=2,6,9


    static bool DiziIcerisindeMevcutMu(int[] A, int[] B)
    {
        int diziBoyutuA = A.Length;
        int diziBoyutuB = B.Length;
        int mevcutMu = 1;

        if (diziBoyutuB > diziBoyutuA) return false;
        else
        {
            for (int i = 0; i <= (diziBoyutuA - diziBoyutuB); i++)
            {
                if (A[i].Equals(B[0]))
                {
                    for (int j = 0; j < diziBoyutuB; j++)
                    {
                        if (A[i + j] != B[j])
                        {
                            mevcutMu = 0;
                            break;
                        }

                    }
                }
            }
        }
        if (mevcutMu == 1) return true;
        else return false;
    }

    #endregion




    //2.ÖRNEK
    #region //diziyi bir sağa kaydırma sonra da n pozisyon sağa kaydırma

    static void BirSagaKaydir(int[] C)
    {
        //A=1,6,4,2,8

        int diziBoyutu = C.Length;
        int dizininSonElemani = C[diziBoyutu - 1];
        for (int i = diziBoyutu - 1; i >= 1; i--)
        {
            C[i] = C[i - 1];
        }
        C[0] = dizininSonElemani;
    }

    #endregion
    
    
    
    
    static void Main(String[] args)
    {


        //ÖRNEK 1

        int[] A = { 3, 6, 3, 189, 43, 2, 3 };
        int[] B = { 2, 3, 8 };
        if (DiziIcerisindeMevcutMu(A, B) == true)
            Console.WriteLine("Mevcut");
        else Console.WriteLine("Mevcut değil");

        Console.WriteLine();





        //ÖRNEK 2

        int[] C = { 7, 8, 3, 5, 6, 2, 1 };
        Console.WriteLine("Dizinin ilk hali: ");
        for (int i = 0; i < C.Length; i++)
        {
            Console.Write(C[i] + " ");
        }

        int n = 17;
        n = n % C.Length;
        int dizininSonElemani = C[C.Length - 1];


        for (int i = 0; i < n; i++)
        {
            BirSagaKaydir(C);
            C[0] = dizininSonElemani;
            dizininSonElemani = C[C.Length - 1];
        }

        Console.WriteLine();
        Console.WriteLine("Dizinin son hali: ");

        for (int i = 0; i < C.Length; i++)
        {
            Console.Write(C[i] + " ");
        }

    }





}


