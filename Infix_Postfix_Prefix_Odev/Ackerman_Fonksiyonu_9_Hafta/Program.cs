using System;

namespace AckermanFonksiyonu
{
    class Program
    {
        // Ackerman fonksiyonu, m ve n değerlerine göre hesaplama yapar
        static int Ackerman(int m, int n)
        {
            if (m == 0)
                return n + 1;                                                       // m = 0 olduğunda, sonucu n + 1 olarak döner
            if (m > 0 && n == 0)
                return Ackerman(m - 1, 1);                                      // m > 0 ve n = 0 olduğunda, A(m-1, 1) hesaplanır
            if (m > 0 && n > 0)
                return Ackerman(m - 1, Ackerman(m, n - 1));                     // m > 0 ve n > 0 olduğunda, A(m-1, A(m, n-1)) hesaplanır
            return 0;                                                        // Bu satır sadece derleyici uyarılarından kaçınmak için
        }

        static void Main(string[] args)
        {
            // Kullanıcıdan m ve n değerlerini al
            Console.Write("m değerini girin: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("n değerini girin: ");
            int n = int.Parse(Console.ReadLine());

            // Ackerman fonksiyonunu çağır ve sonucu yazdır
            int sonuc = Ackerman(m, n);
            Console.WriteLine($"Ackerman({m}, {n}) = {sonuc}");
            Console.ReadKey();
        }
    }
}
