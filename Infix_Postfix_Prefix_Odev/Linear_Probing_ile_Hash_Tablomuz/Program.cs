using System;

namespace HashTablosuLinearProbing
{
    class Program
    {
        static void Main(string[] args)
        {
            int boyut = 100;
            int[] hashTablosu = new int[boyut];
            Random rastgele = new Random();

            // Hash tablosunu -1 ile başlatıyoruz, bu boş anlamına geliyor
            for (int i = 0; i < boyut; i++)
            {
                hashTablosu[i] = -1;
            }

            for (int i = 0; i < boyut; i++)
            {
                int anahtar = rastgele.Next(1, 1000); // 1 ile 1000 arasında rastgele anahtar değerleri
                HashEkleLinearProbing(hashTablosu, boyut, anahtar);
            }

            Console.WriteLine("Linear Probing ile Hash Tablosu:");
            HashTablosuYazdir(hashTablosu);
            Console.ReadKey();
        }

        // Hash fonksiyonu (division metodu)
        static int HashFonksiyonu(int anahtar, int boyut)
        {
            return anahtar % boyut;
        }

        // Linear Probing ile hash tablosuna anahtar ekleme
        static void HashEkleLinearProbing(int[] hashTablosu, int boyut, int anahtar)
        {
            int index = HashFonksiyonu(anahtar, boyut);

            while (hashTablosu[index] != -1)
            {
                index = (index + 1) % boyut; // Çakışma durumunda bir sonraki indekse git
            }

            hashTablosu[index] = anahtar;
        }

        // Hash tablosunu yazdırma
        static void HashTablosuYazdir(int[] hashTablosu)
        {
            for (int i = 0; i < hashTablosu.Length; i++)
            {
                Console.Write($"{i,3}: {hashTablosu[i],3}");
            }
        }
    }
}
