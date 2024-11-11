using System;
using System.Collections.Generic;
using System.Linq;

namespace DersYonetimSistemi
{
    // Öğrenci sınıfı: Öğrenci bilgilerini tutar
    public class Ogrenci
    {
        public int Numara { get; set; } // Öğrenci numarası
        public string Ad { get; set; } // Öğrenci adı
        public string Soyad { get; set; } // Öğrenci soyadı

        public Ogrenci(int numara, string ad, string soyad) // Öğrenci sınıfı yapıcı metodu
        {
            Numara = numara; // Numara ataması
            Ad = ad; // Ad ataması
            Soyad = soyad; // Soyad ataması
        }
    }

    // Ders sınıfı: Öğrencilerin tutulduğu sınıf
    public class Ders
    {
        private List<Ogrenci> ogrenciler; // Öğrencilerin tutulduğu liste

        public Ders()
        {
            ogrenciler = new List<Ogrenci>(); // Öğrenci listesinin başlatılması
        }

        // Yeni öğrenci ekleme metodu
        public void OgrenciEkle(int numara, string ad, string soyad)
        {
            ogrenciler.Add(new Ogrenci(numara, ad, soyad)); // Yeni öğrenci listeye eklenir
        }

        // Öğrenci silme metodu
        public void OgrenciSil(int numara)
        {
            var ogrenci = ogrenciler.FirstOrDefault(o => o.Numara == numara); // Silinecek öğrenci bulunur
            if (ogrenci != null)
            {
                ogrenciler.Remove(ogrenci); // Öğrenci listeden silinir
            }
        }

        // Öğrencileri numara sırasına göre sıralı listeleme metodu
        public List<Ogrenci> OgrencileriListele()
        {
            return ogrenciler.OrderBy(o => o.Numara).ToList(); // Öğrenciler numara sırasına göre sıralanır
        }

        // Öğrencileri yazdırma metodu
        public void OgrencileriYazdir()
        {
            foreach (var ogrenci in OgrencileriListele())
            {
                Console.WriteLine($"Numara: {ogrenci.Numara}, Ad: {ogrenci.Ad}, Soyad: {ogrenci.Soyad}"); // Öğrenci bilgileri yazdırılır
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ders ders = new Ders(); // Ders oluşturulur

            bool devam = true; // Programın çalışmaya devam edip etmeyeceğini belirler

            while (devam)
            {
                // Kullanıcıdan işlem türünü alma
                Console.WriteLine("1: Yeni Öğrenci Ekleme");
                Console.WriteLine("2: Öğrenci Silme");
                Console.WriteLine("3: Öğrencileri Listeleme");
                Console.WriteLine("4: Çıkış");
                Console.Write("Yapmak istediğiniz işlemi seçin: ");
                int secim = (int)Convert.ToInt64(Console.ReadLine());

                switch (secim)
                {
                    case 1: // Yeni öğrenci ekleme
                        Console.Write("Öğrenci numarası: ");
                        int numara = (int)Convert.ToInt64(Console.ReadLine());
                        Console.Write("Öğrenci adı: ");
                        string ad = Console.ReadLine();
                        Console.Write("Öğrenci soyadı: ");
                        string soyad = Console.ReadLine();
                        ders.OgrenciEkle(numara, ad, soyad); // Öğrenci ekleme metodu çağırılır
                        break;
                    case 2: // Öğrenci silme
                        Console.Write("Silinecek öğrenci numarası: ");
                        int silinecekNumara = int.Parse(Console.ReadLine());
                        ders.OgrenciSil(silinecekNumara); // Öğrenci silme metodu çağırılır
                        break;
                    case 3: // Öğrencileri listeleme
                        Console.WriteLine("Öğrenci Listesi:");
                        ders.OgrencileriYazdir(); // Öğrencileri yazdırma metodu çağırılır
                        break;
                    case 4: // Çıkış
                        devam = false; // Program döngüsünden çık
                        break;
                    default: // Geçersiz seçim
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }
            }
        }
    }
}

