using System; // Gerekli kütüphaneyi içe aktarır
using System.Collections.Generic; // Koleksiyonlar kütüphanesini içe aktarır
using System.Linq; // Linq kütüphanesini içe aktarır

namespace VeriyapisiUygulamasi // Programın ad alanı
{
    // Ürün sınıfı: Ürün bilgilerini tutar
    public class Urun
    {
        public int ID { get; set; } // Ürün ID'si
        public string Ad { get; set; } // Ürün adı
        public int Miktar { get; set; } // Ürün miktarı

        public Urun(int id, string ad, int miktar) // Ürün sınıfı yapıcı metodu
        {
            ID = id; // ID ataması
            Ad = ad; // Ad ataması
            Miktar = miktar; // Miktar ataması
        }
    }

    // Kuyruk sınıfı: Ürünleri kuyruk yapısında tutar
    public class Kuyruk
    {
        private LinkedList<Urun> urunler = new LinkedList<Urun>(); // Ürünlerin tutulduğu bağlı liste

        // Başa ekleme metodu
        public void BasaEkle(int id, string ad, int miktar) => urunler.AddFirst(new Urun(id, ad, miktar));

        // Sona ekleme metodu
        public void SonaEkle(int id, string ad, int miktar) => urunler.AddLast(new Urun(id, ad, miktar));

        // Başa silme metodu
        public void BasaSil() { if (urunler.Count > 0) urunler.RemoveFirst(); }

        // Sona silme metodu
        public void SonaSil() { if (urunler.Count > 0) urunler.RemoveLast(); }

        // Arama metodu
        public Urun Ara(int id) => urunler.FirstOrDefault(u => u.ID == id);

        // Listeleme metodu
        public void Listele() => urunler.ToList().ForEach(u => Console.WriteLine($"ID: {u.ID}, Ad: {u.Ad}, Miktar: {u.Miktar}"));

        // Miktara göre sıralama ve görüntüleme metodu
        public void SiralaVeGoruntule() => urunler.OrderBy(u => u.Miktar).ToList().ForEach(u => Console.WriteLine($"ID: {u.ID}, Ad: {u.Ad}, Miktar: {u.Miktar}"));
    }

    // Yığıt (Stack) sınıfı: Ürünleri yığıt yapısında tutar
    public class Yigit
    {
        private Stack<Urun> urunler = new Stack<Urun>(); // Ürünlerin tutulduğu yığıt

        // Ekleme metodu
        public void Ekle(int id, string ad, int miktar) => urunler.Push(new Urun(id, ad, miktar));

        // Silme metodu
        public void Sil() { if (urunler.Count > 0) urunler.Pop(); }

        // Listeleme metodu
        public void Listele() => urunler.ToList().ForEach(u => Console.WriteLine($"ID: {u.ID}, Ad: {u.Ad}, Miktar: {u.Miktar}"));

        // Miktara göre sıralama ve görüntüleme metodu
        public void SiralaVeGoruntule() => urunler.OrderBy(u => u.Miktar).ToList().ForEach(u => Console.WriteLine($"ID: {u.ID}, Ad: {u.Ad}, Miktar: {u.Miktar}"));
    }

    class Program
    {
        static void Main(string[] args) // Programın ana girişi
        {
            Kuyruk kuyruk = new Kuyruk(); // Kuyruk oluştur
            Yigit yigit = new Yigit(); // Yığıt oluştur
            bool devam = true; // Programın çalışmaya devam edip etmeyeceğini belirler

            while (devam)
            {
                // Kullanıcıdan işlem türünü alma
                Console.WriteLine("Linked List Kuyruk (1) mi Stack (2) mi olsun?");
                int secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1: // Kuyruk işlemleri
                        Console.WriteLine("Ekle(1), Sil(2), Ara(3), Listele(4), Sırala(5)");
                        int kuyrukSecim = int.Parse(Console.ReadLine());
                        IslemYapKuyruk(kuyruk, kuyrukSecim);
                        break;
                    case 2: // Yığıt işlemleri
                        Console.WriteLine("Ekle(1), Sil(2), Listele(4), Sırala(5)");
                        int yigitSecim = int.Parse(Console.ReadLine());
                        IslemYapYigit(yigit, yigitSecim);
                        break;
                    default: // Geçersiz seçim
                        devam = false;
                        break;
                }
            }
        }

        static void IslemYapKuyruk(Kuyruk kuyruk, int secim) // Kuyruk işlemlerini yapan metot
        {
            switch (secim)
            {
                case 1: // Ekleme
                    Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
                    Console.Write("Ad: "); string ad = Console.ReadLine();
                    Console.Write("Miktar: "); int miktar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Başa (1) mı Sona (2) mı eklemek istersiniz?");
                    int ekleSecim = int.Parse(Console.ReadLine());
                    if (ekleSecim == 1) kuyruk.BasaEkle(id, ad, miktar); else kuyruk.SonaEkle(id, ad, miktar);
                    break;
                case 2: // Silme
                    Console.WriteLine("Baştan (1) mı Sondan (2) mı silmek istersiniz?");
                    int silSecim = int.Parse(Console.ReadLine());
                    if (silSecim == 1) kuyruk.BasaSil(); else kuyruk.SonaSil();
                    break;
                case 3: // Arama
                    Console.Write("Aranacak ID: "); int araId = int.Parse(Console.ReadLine());
                    var urun = kuyruk.Ara(araId);
                    if (urun != null) Console.WriteLine($"ID: {urun.ID}, Ad: {urun.Ad}, Miktar: {urun.Miktar}");
                    else Console.WriteLine("Ürün bulunamadı.");
                    break;
                case 4: // Listeleme
                    kuyruk.Listele();
                    break;
                case 5: // Sıralama
                    kuyruk.SiralaVeGoruntule();
                    break;
            }
        }

        static void IslemYapYigit(Yigit yigit, int secim) // Yığıt işlemlerini yapan metot
        {
            switch (secim)
            {
                case 1: // Ekleme
                    Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
                    Console.Write("Ad: "); string ad = Console.ReadLine();
                    Console.Write("Miktar: "); int miktar = int.Parse(Console.ReadLine());
                    yigit.Ekle(id, ad, miktar);
                    break;
                case 2: // Silme
                    yigit.Sil();
                    break;
                case 4: // Listeleme
                    yigit.Listele();
                    break;
                case 5: // Sıralama
                    yigit.SiralaVeGoruntule();
                    break;
            }
        }
    }
}
