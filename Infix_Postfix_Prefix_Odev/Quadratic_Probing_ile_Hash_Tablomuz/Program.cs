using System; 

namespace HashTablosuQuadraticProbing
{
    class Program
    {
        static void Main(string[] args) 
        {
            int boyut = 100; // Hash tablosunun boyutu
            int[] hashTablosu = new int[boyut]; // Hash tablosunu temsil eden dizi
            Random rastgele = new Random(); // Rastgele sayı üretici

            // Hash tablosunu -1 ile başlatıyoruz, bu boş anlamına geliyor
            for (int i = 0; i < boyut; i++)
            {
                hashTablosu[i] = -1; // Tüm indeksleri -1 yaparak tabloyu boş olarak işaretliyoruz
            }

            // Hash tablosuna rastgele anahtarlar ekliyoruz
            for (int i = 0; i < boyut; i++)
            {
                int anahtar = rastgele.Next(1, 1000); // 1 ile 1000 arasında rastgele anahtar değerleri oluşturuluyoruz.
                HashEkleQuadraticProbing(hashTablosu, boyut, anahtar); // Rastgele anahtarı hash tablosuna ekliyoruz
            }

            Console.WriteLine("Quadratic Probing ile Hash Tablosu:"); // Başlık yazdırılıyor
            HashTablosuYazdir(hashTablosu); // Hash tablosunun içeriği yazdırılıyor
            Console.ReadKey(); // Programın kapanmasını beklemek için bir tuşa basılmasını bekler
        }

        // Hash fonksiyonu (division metodu)
        static int HashFonksiyonu(int anahtar, int boyut)
        {
            return anahtar % boyut; // Anahtarın boyuta bölümünden kalan, indeks olarak kullanılır
        }

        // Quadratic Probing ile hash tablosuna anahtar ekleme
        static void HashEkleQuadraticProbing(int[] hashTablosu, int boyut, int anahtar)
        {
            int index = HashFonksiyonu(anahtar, boyut); // İlk hash indeksini hesaplıyoruz
            int i = 1; // Quadratic Probing için adım sayacı

            // Çakışma (collision) durumunda quadratic probing uygula
            while (hashTablosu[index] != -1) // Boş olmayan bir indeks bulunduğu sürece devam et
            {
                index = (index + i * i) % boyut; // Quadratic artış ile yeni indeks hesapla
                i++; // Adım sayacını artır
            }

            hashTablosu[index] = anahtar; // Boş indeksi bulduktan sonra anahtarı ekle
        }

        // Hash tablosunu yazdırma
        static void HashTablosuYazdir(int[] hashTablosu)
        {
            for (int i = 0; i < hashTablosu.Length; i++) // Tablodaki tüm indeksler boyunca döngü
            {
                Console.WriteLine($"{i,-3}: {hashTablosu[i],-3}"); // Her bir indeks ve değeri yazdırılıyor
            }
        }
    }
}

