using System;

namespace StandartSapmaHesaplama_Iterasyon
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

            double ortalama = OrtalamaHesapla(degerler);
            double standartSapma = StandartSapmaHesapla(degerler, ortalama);

            Console.WriteLine($"Standart Sapma: {standartSapma}");
            Console.ReadKey();
        }

        // Ortalama hesaplama fonksiyonu
        static double OrtalamaHesapla(double[] degerler)
        {
            double toplam = 0;
            foreach (var deger in degerler)
            {
                toplam += deger;
            }
            return toplam / degerler.Length;
        }

        // Standart sapma hesaplama fonksiyonu
        static double StandartSapmaHesapla(double[] degerler, double ortalama)
        {
            double toplam = 0;
            foreach (var deger in degerler)
            {
                toplam += Math.Pow(deger - ortalama, 2);
            }
            return Math.Sqrt(toplam / degerler.Length);
        }
    }
}

