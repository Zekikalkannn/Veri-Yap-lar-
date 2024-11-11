using System;

namespace StandartSapmaHesaplamaRecursive
{
    class Program
    {
        static void Main()
        {
            Console.Write("Kaç adet değer gireceksiniz? ");
            int n = int.Parse(Console.ReadLine());

            double[] degerler = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Değer {i + 1}: ");
                degerler[i] = double.Parse(Console.ReadLine());
            }

            double ortalama = OrtalamaHesapla(degerler, n);
            double standartSapma = StandartSapmaHesapla(degerler, ortalama, n);

            Console.WriteLine($"Standart Sapma: {standartSapma}");
            Console.ReadKey();
        }

        // Recursive ortalama hesaplama fonksiyonu
        static double OrtalamaHesapla(double[] degerler, int n, int i = 0)
        {
            if (i == n)
                return 0;
            return (degerler[i] + i * OrtalamaHesapla(degerler, n, i + 1)) / (i + 1);
        }

        // Recursive standart sapma hesaplama fonksiyonu
        static double StandartSapmaHesapla(double[] degerler, double ortalama, int n, int i = 0, double toplam = 0)
        {
            if (i == n)
                return Math.Sqrt(toplam / n);
            return StandartSapmaHesapla(degerler, ortalama, n, i + 1, toplam + Math.Pow(degerler[i] - ortalama, 2));
        }
    }
}

