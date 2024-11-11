using System;
using System.Collections.Generic;

namespace BankaKuyrugu
{
    // Müşteri sınıfı: Ad ve işlem türü ile müşteriyi temsil eder
    public class Musteri
    {
        public string Ad { get; set; }
        public string IslemTuru { get; set; }

        public Musteri(string ad, string islemTuru)
        {
            Ad = ad;
            IslemTuru = islemTuru;
        }

        public override string ToString()
        {
            return $"{Ad} ({IslemTuru})";
        }
    }

    // Kuyruk sınıfı: Üç öncelik grubuna göre müşterileri saklar
    public class BankaKuyrugu
    {
        private Queue<Musteri> oncelik1; // Yüksek öncelikli grup
        private Queue<Musteri> oncelik2; // Orta öncelikli grup
        private Queue<Musteri> oncelik3; // Düşük öncelikli grup

        public BankaKuyrugu()
        {
            oncelik1 = new Queue<Musteri>();
            oncelik2 = new Queue<Musteri>();
            oncelik3 = new Queue<Musteri>();
        }

        // Yeni müşteri ekleme metodu
        public void Enqueue(Musteri musteri)
        {
            switch (musteri.IslemTuru.ToLower())
            {
                case "yatirim":
                    oncelik1.Enqueue(musteri);
                    break;
                case "kredi":
                    oncelik2.Enqueue(musteri);
                    break;
                case "hesap":
                    oncelik3.Enqueue(musteri);
                    break;
                default:
                    Console.WriteLine("Bilinmeyen işlem türü!");
                    break;
            }
        }

        // Müşteri alım metodu
        public Musteri Dequeue()
        {
            if (oncelik1.Count > 0)
                return oncelik1.Dequeue();
            if (oncelik2.Count > 0)
                return oncelik2.Dequeue();
            if (oncelik3.Count > 0)
                return oncelik3.Dequeue();
            return null;
        }

        // Kuyruk durumu gösterim metodu
        public void KuyrukDurumu()
        {
            Console.WriteLine("Oncelik 1:");
            foreach (var musteri in oncelik1)
                Console.WriteLine(musteri);

            Console.WriteLine("Oncelik 2:");
            foreach (var musteri in oncelik2)
                Console.WriteLine(musteri);

            Console.WriteLine("Oncelik 3:");
            foreach (var musteri in oncelik3)
                Console.WriteLine(musteri);
        }
    }

    class Program
    {
        static void Main()
        {
            BankaKuyrugu kuyruk = new BankaKuyrugu();

            // Yeni müşteriler ekleniyor
            kuyruk.Enqueue(new Musteri("Ali", "yatirim"));
            kuyruk.Enqueue(new Musteri("Ayşe", "hesap"));
            kuyruk.Enqueue(new Musteri("Mehmet", "kredi"));
            kuyruk.Enqueue(new Musteri("Fatma", "yatirim"));
            kuyruk.Enqueue(new Musteri("Ahmet", "hesap"));

            Console.WriteLine("Başlangıçta kuyruk durumu:");
            kuyruk.KuyrukDurumu();

            // Müşteri alınıyor
            Console.WriteLine($"\nMüşteri işlemini tamamladı: {kuyruk.Dequeue()}");

            Console.WriteLine("\nGüncel kuyruk durumu:");
            kuyruk.KuyrukDurumu();
            Console.ReadKey();
        }
    }
}

