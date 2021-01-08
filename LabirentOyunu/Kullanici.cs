using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirentOyunu
{
    class Kullanici
    {
        public int[,] matris = new int[10, 10];
        public int[,] secilen = new int[1, 10];
        public int[,] bomba = new int[10, 10];
        public Random karistir = new Random();
        public int a = 0;
        public int sutun = 0, satir = 9, sutunSbt = 0, satirSbt = 0, puan = 0, toplayici = 0;
        //0x0 matrisin üretimi.
        public void matrisUretici()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    matris[i, j] = 0;
                }
            }
        }
        //Başlangıç değerlerinin atanması.
        public void baslangicUretimi()
        {
            for (int i = 0; i < 3; i++)
            {
                int sec = karistir.Next(0, 10);
                while (true)
                {
                    sec = karistir.Next(0, 10);
                    if (sec % 2 == 0 && matris[9, sec] != 1)
                    {
                        matris[9, sec] = 1;
                        break; ;
                    }
                }
            }
        }
        //Labirentin Oluşturulması.
        public void labirentUretici()
        {
            for (int ii = 0; ii < 10; ii++)
            {
                if (matris[satir, sutun] == 1)
                {
                    sutunSbt = sutun;
                    satirSbt = satir;
                    for (int i = 1; i <= satirSbt - 1; i++)
                    {
                        a = karistir.Next(1, 4);
                        if (a == 1)
                        {
                            if (sutunSbt >= 0 && sutunSbt < 9)
                            {
                                matris[satirSbt - i, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt + 1] = 1;
                                sutunSbt++;
                                if (satirSbt > 0)
                                    satirSbt--;
                            }
                            else if (sutunSbt >= 9)
                            {
                                matris[satirSbt - i, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt] = 1;

                                matris[satirSbt - i - 1, sutunSbt - 1] = 1;

                                sutunSbt--;
                                if (satirSbt > 0)
                                    satirSbt--;
                            }
                        }
                        else if (a == 2)
                        {
                            if (sutunSbt > 0 && sutunSbt < 10)
                            {
                                matris[satirSbt - i, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt - 1] = 1;
                                sutunSbt--;
                                if (satirSbt > 0)
                                    satirSbt--;
                            }
                            else if (sutunSbt == 0)
                            {
                                matris[satirSbt - i, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt + 1] = 1;
                                sutunSbt++;
                                if (satirSbt > 0)
                                    satirSbt--;
                            }
                        }
                        else
                        {
                            if (sutunSbt < 10 && satirSbt >= i)
                            {
                                matris[satirSbt - i, sutunSbt] = 1;
                                matris[satirSbt - i - 1, sutunSbt] = 1;
                            }
                            if (satirSbt > 0)
                                satirSbt--;
                        }
                    }
                }
                sutun++;
            }
        }
        //Çıkış değerinin yerinin belirlenmesi (en üst basamak).
        public void cikisBelirle()
        {
            int toplam = 0;
            for (int i = 0; i < 10; i++)
            {
                if (matris[1, i] == 1)
                {
                    toplam++;
                }
            }
            if (toplam == 1 || toplam == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (matris[1, i] == 1)
                    {

                        matris[0, i] = 1;
                    }
                }
            }
            else if (toplam >= 3)
            {
                int elemanSayisi = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (matris[1, i] == 1)
                    {
                        secilen[0, elemanSayisi] = i;
                        elemanSayisi++;
                    }

                }
                for (int i = 0; i < toplam+1; i++)
                {
                    matris[0, secilen[0, karistir.Next(0, elemanSayisi)]] = 1;
                }
            }
        }
        //Matrisin Yazdırılması.
        public void labirentYazdir()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matris[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("{0}", matris[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("{0}", matris[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        //Başlangıç yollarının isimlendirilmesi.
        public void baslangicNumaralandir()
        {
            int n = 1, b = 0;
            for (int i = 0; i < 10; i++)
            {
                if (matris[9, i] == 1)
                {
                    Console.SetCursorPosition(i, 10);
                    b = 1 * n;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(b);
                    Console.BackgroundColor = ConsoleColor.Black;
                    n++;
                }
            }
        }
        //Konum koordinatlarını adım adım belirleme.
        public int yatay = 0;
        public int dikey = 0;
        public int G = 0;
        public void konumDegistir(ConsoleKeyInfo Tus)
        {
            if (Tus.Key == ConsoleKey.D)
            {
                if (matris[dikey, yatay + 1] == 1 || matris[dikey, yatay + 1] == 2)
                {
                    yatay++;
                    puan++;
                    if (bomba[dikey, yatay] == 2)
                    {
                        G++;
                    }
                    
                    Console.WriteLine("\n\n\n\n\n                                                                                  ");
                    Console.Write("      ");
                }
                else
                {
                    puan--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\n\n\nDuvara çarptınız. Puanınız 1 azaltıldı...                                        ");
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else if (Tus.Key == ConsoleKey.A)
            {
                if (matris[dikey, yatay - 1] == 1|| matris[dikey , yatay-1] == 2)
                {
                    yatay--;
                    puan++;
                    if (bomba[dikey, yatay] == 2)
                    {
                        G++;
                    }
                    Console.WriteLine("\n\n\n\n\n                                                                                  ");
                    Console.Write("      ");
                }
                else
                {
                    puan--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\n\n\nDuvara çarptınız. Puanınız 1 azaltıldı...                                        ");
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else if (Tus.Key == ConsoleKey.S)
            {
                if (dikey == 9 )
                {
                    
                    Console.Clear();
                    ConsoleKeyInfo gonderilenTus;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nHangi yoldan gitmek istediğinizi tuşlayınız ve ENTER'a basınız...");
                    Console.ForegroundColor = ConsoleColor.White;
                    gonderilenTus = Console.ReadKey();
                    baslangicSec(gonderilenTus);
                    puan = 0;
                }
                else if (matris[dikey + 1, yatay] == 1|| matris[dikey + 1, yatay] == 2)
                {
                    dikey++;
                    puan++;
                    if (bomba[dikey, yatay] == 2)
                    {
                        G++;
                        
                    }
                    
                    Console.WriteLine("\n\n\n\n\n                                                                                  ");
                    Console.Write("      ");
                }
                else
                {
                    puan--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\n\n\nDuvara çarptınız. Puanınız 1 azaltıldı...                                        ");
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
            }
            else if (Tus.Key == ConsoleKey.W)
            {
                if (matris[dikey - 1, yatay] == 1|| matris[dikey - 1, yatay] == 2)
                {
                    dikey--;
                    puan++;
                    if (bomba[dikey, yatay] == 2)
                    {
                        G++;
                    }
                    if (dikey == 0 && matris[dikey, yatay] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\n\n\n*******************************************");
                        Console.WriteLine("Tebrikler Labirentten Çıkmayı Başardınız...");
                        Console.WriteLine("Toplam Puanınız: {0}", puan);
                        Console.WriteLine("*******************************************");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Beep(1500, 1000);
                        G = 2;
                        bittMi();
                        
                    }
                    Console.WriteLine("\n\n\n\n\n                                                                                  ");
                    Console.Write("      ");
                }
                else
                {
                    puan--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\n\n\nDuvara çarptınız. Puanınız 1 azaltıldı...                                      ");
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        //Oyunun bitip bitmediğinin kontrollerinin sağlanması.
        public int bittMi()
        {
            int a = 0;
            if (G == 1)
            {
                Console.Clear();
                Console.WindowHeight = 4;
                Console.WindowWidth = 35;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBombaya Çarptınız. Oyun Sona Erdi.");
                Console.WriteLine("Toplam Puanınız: {0}", puan - 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep(1500, 500);
                a = 1;
            }
            if (G == 2)
            {
                a = 1;
            }
            return a;
        }
        //Başlangıç yolunun seçilmesi.
        public void baslangicSec(ConsoleKeyInfo Tus)
        {
            int top = 0;
            if (Tus.Key == ConsoleKey.NumPad1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (matris[9, i] == 1)
                    {
                        yatay = i;
                        dikey = 9;
                        break;
                    }
                }
            }
            if (Tus.Key == ConsoleKey.NumPad2)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (matris[9, i] == 1)
                    {
                        top++;
                        if (top == 2)
                        {
                            yatay = i;
                            dikey = 9;
                            break;
                        }

                    }
                }
            }
            if (Tus.Key == ConsoleKey.NumPad3)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (matris[9, i] == 1)
                    {
                        top++;
                        if (top == 3)
                        {
                            yatay = i;
                            dikey = 9;
                            break;
                        }
                    }
                }
            }
        }
        //Kullanıcıyı konumlandır.
        public void konumlandir()
        {
            Console.SetCursorPosition(yatay, dikey);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("K");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Puan yazdır.
        public void puanYaz()
        {
            Console.SetCursorPosition(1, 13);
            Console.WriteLine("                      ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(1, 13);
            Console.WriteLine("Puan: " + puan);
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Bomba oluştur.
        public int bomb1 = 0, bomb2 = 0, bomb3 = 0;
        public void bombaOlustur()
        {
            int b = 0;
            int c1 = 0, c2 = 0, c3 = 0;
            int toplam = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matris[i, j] == 1)
                    {
                        toplayici++;
                        if (toplayici == 1)
                        {
                            bomb1 = j;
                        }
                        if (toplayici == 2)
                        {
                            bomb2 = j;
                        }
                        if (toplayici == 3)
                        {
                            bomb3 = j;
                        }
                    }
                }
                if (toplayici == 3)
                {
                    a = karistir.Next(0, 3);
                    while (b != 2)
                    {
                        a = karistir.Next(0, 3);
                        if (a == 0 && c1 == 0)
                        {
                            bomba[i, bomb1] = 2;
                            b++;
                            c1 = 1;
                        }
                        if (a == 1 && c2 == 0)
                        {
                            bomba[i, bomb2] = 2;
                            b++;
                            c2++;
                        }
                        if (a == 2 && c3 == 0)
                        {
                            bomba[i, bomb3] = 2;
                            b++;
                            c3++;
                        }
                    }
                    break;
                }
                bomb1 = 0;
                bomb2 = 0;
                bomb3 = 0;
                toplayici = 0;
            }
            if (toplayici == 0)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (matris[i, j]==1)
                        {
                            toplam++;
                            if (toplam>3)
                            {
                                a = karistir.Next(0, 10);
                                while (b != 2)
                                {
                                    a = karistir.Next(0, 10);
                                    if (matris[i, a] == 1)
                                    {
                                        bomba[i, a] = 2;
                                        b++;
                                    }
                                }
                                i = 10;
                                j = 10;
                            }                        
                        }
                    }
                    toplam = 0;
                }
            }
        }
        //İsteğe bağlı bombaları göster.
        public void bombaGoster()
        {
            for (int i = 1; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (bomba[i,j]==2)
                    {
                        matris[i, j] = 2;
                    }
                }
            }
        }
        //İsteğe bağlı bombaları gizle.
        public void bombaGizle()
        {
            for (int i = 1; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (bomba[i, j] == 2)
                    {
                        matris[i, j] = 1;
                    }
                }
            }
        }
        //Kuralların kullanıcıya sunulması.
        public void kurallar()
        {
            Console.Clear();
            string[] kural = new string[8] { "K", "U", "R", "A", "L", "L", "A", "R" };
            Console.WindowHeight =34;
            Console.WindowWidth = 80;
            int r1 = 0,r2 = 0,r3=0,r4 = 0;
            int i = 0;
            Console.Write("                                    ");
            while (i<8)
            {
                a = karistir.Next(0, 4);
                if (a==0&&r1==0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",kural[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    r1 = 1;
                    r2 = 0;
                    r3 = 0;
                    r4 = 0;
                    i++;
                }
                else if (a==1 && r2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("{0}", kural[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    r1 = 0;
                    r2 = 1;
                    r3 = 0;
                    r4 = 0;
                    i++;
                }
                else if (a==2 && r3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("{0}", kural[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    r1 = 0;
                    r2 = 0;
                    r3 = 1;
                    r4 = 0;
                    i++;
                }
                else if (a == 2 && r4 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", kural[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    r1 = 0;
                    r2 = 0;
                    r3 = 0;
                    r4 = 1;
                    i++;
                }
            }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("1.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirentin içine girmeden önce giriş yolunu tuşlamak gerekir.\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirent içindeki 'K' harfi bulunduğunuz (K)onumu simgeler.\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirent içerisinde W,A,S,D tuşlarıyla hareket edebilirsiniz.\n");
            Console.Write("         (W:Yukarı A:Sol S:Aşağı D:Sağ)\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("4.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirent içerisindeki 1 rakamından oluşan yolda ilerlediğiniz \n");
            Console.Write("         her adımda puanınız 1 ARTMAKTADIR.\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("5.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirent içerisindeki 1 rakamından oluşan yol dışında hareket \n");
            Console.Write("         etmek istediğinizde (0 rakamına) duvara çarparsınız. Bu durumda \n");
            Console.Write("         puanınız 1 AZALMAKTADIR.\n\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("6.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirentin içerisinde iki adet rastgele yerleştirilmiş bomba \n");
            Console.Write("         bulunmaktadır. Bu bombalardan birine çarpmanız haline oyun sonlanır.\n");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("         Püf Nokta:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Başlangıç yolunuzu tuşladıktan sonra 1 kez G harfini \n");
            Console.Write("                   tuşlarsanız bombalar kendilerini gösterir,\n");
            Console.Write("                   1 kez daha tuşlarsanız bombalar gizlenir.\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("7.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirent içinde bulunduğunuz yolu değiştirmek isterseniz \n");
            Console.Write("         başlangıç noktasına geri dönüp S tuşuna basmanız yeterli. \n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8.Kural: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Labirentten hiçbir bombaya çarpmadan çıktığınız takdirde oyunu \n");
            Console.Write("         kazanırsınız ve ekrana toplam puan durumunuz yazdırılır.\n\n");
            Console.WriteLine("   Kuralları öğrendiğimize göre oyuna başlamaya hazır mısınız ?\n");
            Console.WriteLine("-> Eğer cevabınız Evet ise E harfine basmanız yeterli...");
            Console.WriteLine("-> Eğer cevabınız Hayır ise H harfini tuşlayabilirsiniz...\n");
        }
        //Giriş arayüzünün oluşturulması.
        public void giris()
        {
            Console.WindowHeight = 15;
            Console.WindowWidth = 78;
            Console.WriteLine("\n< - < - < - < - < - < - Labirent Oyununa Hoş Geldiniz - > - > - > - > - > - >");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n                                                                              ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n-> Oyunu oynamadan önce oyunun kurallarını bilmek çok önemlidir.");
            Console.WriteLine("   Oyunun kurallarını ve püf noktalarını öğrenmek için K Harfini Tuşlayınız...");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n                                                                              ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n-> Kuralları biliyor ve eğlence dolu labirentin içine girmek istiyorsanız,");
            Console.WriteLine("   Oyuna doğrudan başlamak için B Harfini Tuşlayınız...");
        }
    }
}
