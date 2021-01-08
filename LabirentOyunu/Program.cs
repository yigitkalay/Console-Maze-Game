using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LabirentOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.giris();
            ConsoleKeyInfo gonderilenTus;
            gonderilenTus = Console.ReadKey();
            int baslatici = 0;
            while (gonderilenTus.Key != ConsoleKey.K&& gonderilenTus.Key != ConsoleKey.B)
            {
                Console.WriteLine("\nHatalı tuşlama yaptınız. Lütfen konrol ediniz...");
                gonderilenTus = Console.ReadKey();
                Console.Clear();
                kullanici.giris();
            }
            if (gonderilenTus.Key==ConsoleKey.K)
            {
                kullanici.kurallar();
                gonderilenTus = Console.ReadKey();
                if (gonderilenTus.Key == ConsoleKey.H)
                {
                    Console.Clear();
                    Console.WindowHeight = 8;
                    Console.WindowWidth = 50;
                    Console.WriteLine("\n\nHazır olduğun bir zaman buluşmak üzere...");
                    Console.WriteLine("\nOyun Kapanıyor...");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                else if (gonderilenTus.Key == ConsoleKey.E)
                {
                    baslatici = 1;
                }
            }
            if (gonderilenTus.Key == ConsoleKey.B || baslatici == 1)
            {
                Console.Clear();
                Console.WindowHeight = 8;
                Console.WindowWidth = 40;
                Console.WriteLine("\n\nOyun Başlatılıyor. Lütfen Bekleyiniz...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WindowHeight = 20;
                Console.WindowWidth = 65;
                int bitti = 0;
                int gosterici = 0;
                kullanici.matrisUretici();
                kullanici.baslangicUretimi();
                kullanici.labirentUretici();
                kullanici.cikisBelirle();
                kullanici.labirentYazdir();
                kullanici.baslangicNumaralandir();
                kullanici.bombaOlustur();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nHangi yoldan gitmek istediğinizi tuşlayınız ve ENTER'a basınız...");
                Console.ForegroundColor = ConsoleColor.White;
                gonderilenTus = Console.ReadKey();
                kullanici.baslangicSec(gonderilenTus);
                do
                {
                    gonderilenTus = Console.ReadKey();
                    if (gonderilenTus.Key == ConsoleKey.G && gosterici == 0)
                    {
                        kullanici.bombaGoster();
                        gosterici = 1;
                    }
                    else if (gonderilenTus.Key == ConsoleKey.G && gosterici == 1)
                    {
                        kullanici.bombaGizle();
                        gosterici = 0;
                    }
                    kullanici.labirentYazdir();
                    kullanici.baslangicNumaralandir();
                    kullanici.konumDegistir(gonderilenTus);
                    kullanici.konumlandir();
                    kullanici.puanYaz();
                    kullanici.bittMi();
                    bitti = kullanici.bittMi();
                    if (bitti == 1)
                    {
                        break;
                    }
                } while (gonderilenTus.Key != ConsoleKey.Escape);
            }
            Console.ReadKey();
        }
    }
}
