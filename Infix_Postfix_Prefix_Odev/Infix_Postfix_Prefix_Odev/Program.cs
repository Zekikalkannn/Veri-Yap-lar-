using System;
using System.Collections.Generic;

// Bagli liste yapısı ile infix ifadeyi postfix ve prefix ifadeye dönüştüren program
namespace InfixDonusturucuProgram
{
    // Düğüm sınıfı: bağlı listede her bir düğümü temsil eder
    public class Dugum<T>
    {
        public T Veri; // Düğüm verisi
        public Dugum<T> Sonraki; // Sonraki düğüme işaretçi

        public Dugum(T veri)
        {
            Veri = veri;
            Sonraki = null;
        }
    }

    // Bağlı Liste sınıfı: düğümlerden oluşan bir listeyi temsil eder
    public class BagliListe<T>
    {
        public Dugum<T> Bas; // Listenin başını tutar

        public BagliListe()
        {
            Bas = null;
        }

        // Listeye veri ekler
        public void SonaEkle(T veri)
        {
            Dugum<T> yeniDugum = new Dugum<T>(veri);

            if (Bas == null)
            {
                Bas = yeniDugum;
            }
            else
            {
                Dugum<T> mevcut = Bas;
                while (mevcut.Sonraki != null)
                {
                    mevcut = mevcut.Sonraki;
                }
                mevcut.Sonraki = yeniDugum;
            }
        }

        // Listeyi string olarak döndürür
        public override string ToString()
        {
            Dugum<T> mevcut = Bas;
            string sonuc = "";
            while (mevcut != null)
            {
                sonuc += mevcut.Veri + " ";
                mevcut = mevcut.Sonraki;
            }
            return sonuc.Trim();
        }
    }

    // Infix ifadeleri dönüştürmek için yardımcı sınıf
    public class InfixDonusturucu
    {
        // Operatör önceliğini belirler
        private static int Oncelik(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }

        // Infix ifadeyi Postfix ifadeye dönüştürür
        public static string InfixToPostfix(string ifade)
        {
            Stack<char> yigin = new Stack<char>();
            BagliListe<string> sonuc = new BagliListe<string>();

            for (int i = 0; i < ifade.Length; i++)
            {
                char c = ifade[i];

                if (char.IsLetterOrDigit(c))
                {
                    sonuc.SonaEkle(c.ToString());
                }
                else if (c == '(')
                {
                    yigin.Push(c);
                }
                else if (c == ')')
                {
                    while (yigin.Count > 0 && yigin.Peek() != '(')
                    {
                        sonuc.SonaEkle(yigin.Pop().ToString());
                    }
                    yigin.Pop();
                }
                else
                {
                    while (yigin.Count > 0 && Oncelik(c) <= Oncelik(yigin.Peek()))
                    {
                        sonuc.SonaEkle(yigin.Pop().ToString());
                    }
                    yigin.Push(c);
                }
            }

            while (yigin.Count > 0)
            {
                sonuc.SonaEkle(yigin.Pop().ToString());
            }

            return sonuc.ToString();
        }

        // Infix ifadeyi Prefix ifadeye dönüştürür
        public static string InfixToPrefix(string ifade)
        {
            Stack<char> yigin = new Stack<char>();
            BagliListe<string> sonuc = new BagliListe<string>();

            for (int i = ifade.Length - 1; i >= 0; i--)
            {
                char c = ifade[i];

                if (char.IsLetterOrDigit(c))
                {
                    sonuc.SonaEkle(c.ToString());
                }
                else if (c == ')')
                {
                    yigin.Push(c);
                }
                else if (c == '(')
                {
                    while (yigin.Count > 0 && yigin.Peek() != ')')
                    {
                        sonuc.SonaEkle(yigin.Pop().ToString());
                    }
                    yigin.Pop();
                }
                else
                {
                    while (yigin.Count > 0 && Oncelik(c) < Oncelik(yigin.Peek()))
                    {
                        sonuc.SonaEkle(yigin.Pop().ToString());
                    }
                    yigin.Push(c);
                }
            }

            while (yigin.Count > 0)
            {
                sonuc.SonaEkle(yigin.Pop().ToString());
            }

            var arr = sonuc.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    class Program
    {
        static void Main()
        {
            // Otomatik olarak tanımlanan basit infix ifade
            string infix = "a+b*c";
            Console.WriteLine("Infix: " + infix);

            // Postfix ifadeyi hesaplar ve ekrana yazdırır
            string postfix = InfixDonusturucu.InfixToPostfix(infix);
            Console.WriteLine("Postfix: " + postfix);

            // Prefix ifadeyi hesaplar ve ekrana yazdırır
            string prefix = InfixDonusturucu.InfixToPrefix(infix);
            Console.WriteLine("Prefix: " + prefix);
            Console.ReadKey();
        }
    }
}

