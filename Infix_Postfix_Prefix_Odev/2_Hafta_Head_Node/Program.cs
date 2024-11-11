using System; // Gerekli kütüphaneyi içe aktar

namespace BagliListeOrnek // Programın bulunduğu ad alanı
{
    // Öğrenci sınıfı: Öğrenci bilgilerini tutar
    public class Ogrenci
    {
        public int Numara { get; set; } // Öğrenci numarası
        public string Ad { get; set; } // Öğrenci adı
        public string Soyad { get; set; } // Öğrenci soyadı
        public Ogrenci Sonraki { get; set; } // Sonraki öğrenciye işaretçi

        public Ogrenci(int numara, string ad, string soyad) // Öğrenci sınıfı yapıcı metodu
        {
            Numara = numara; // Numara ataması
            Ad = ad; // Ad ataması
            Soyad = soyad; // Soyad ataması
            Sonraki = null; // Sonraki düğüm başlangıçta null
        }
    }

    // Bağlı liste sınıfı: Öğrencileri bağlı liste yapısında tutar
    public class OgrenciListesi
    {
        private Ogrenci headNode; // Listenin başını tutan düğüm

        public OgrenciListesi()
        {
            headNode = null; // Başlangıçta liste boş
        }

        // Öğrenci ekleme metodu
        public void OgrenciEkle(int numara, string ad, string soyad)
        {
            Ogrenci yeniOgrenci = new Ogrenci(numara, ad, soyad); // Yeni öğrenci düğümü oluştur
            if (headNode == null) // Liste boşsa
            {
                headNode = yeniOgrenci; // Yeni öğrenci baş düğüm olur
            }
            else
            {
                Ogrenci mevcut = headNode; // Mevcut düğümü baş düğüm olarak başlat
                while (mevcut.Sonraki != null) // Sonraki düğüm boş olana kadar ilerle
                {
                    mevcut = mevcut.Sonraki; // Mevcut düğümü güncelle
                }
                mevcut.Sonraki = yeniOgrenci; // Sonraki düğüm olarak yeni öğrenciyi ekle
            }
        }

        // Öğrencileri yazdırma metodu
        public void OgrencileriYazdir()
        {
            Ogrenci mevcut = headNode; // Mevcut düğümü baş düğüm olarak başlat
            while (mevcut != null) // Listenin sonuna gelene kadar devam et
            {
                Console.WriteLine($"Numara: {mevcut.Numara}, Ad: {mevcut.Ad}, Soyad: {mevcut.Soyad}"); // Öğrenci bilgilerini yazdır
                mevcut = mevcut.Sonraki; // Mevcut düğümü güncelle
            }
        }
    }

    class Program
    {
        static void Main() // Programın ana girişi
        {
            OgrenciListesi ogrenciListesi = new OgrenciListesi(); // Öğrenci listesi oluştur

            // Örnek öğrenciler ekleniyor
            ogrenciListesi.OgrenciEkle(1, "Ali", "Yılmaz"); // Ali isimli öğrenci ekle
            ogrenciListesi.OgrenciEkle(2, "Ayşe", "Kara"); // Ayşe isimli öğrenci ekle
            ogrenciListesi.OgrenciEkle(3, "Mehmet", "Çelik"); // Mehmet isimli öğrenci ekle

            // Öğrenci bilgilerini yazdırma
            Console.WriteLine("Öğrenci Listesi:"); // Başlık yazdır
            ogrenciListesi.OgrencileriYazdir(); // Öğrencileri yazdır

            Console.ReadKey(); // Ekranı beklet
        }
    }
}
