using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int baslangic, bitis, istenenSayiAdedi, gosterilecekSayiAdedi, toplam = 0;
            double[,] sayilar;

            baslangicAl:

            Console.WriteLine("Başlangıç değerini giriniz");
            string alinanDeger = Console.ReadLine();

            // string sayi dönüşüm işlemleri için https://youtu.be/IjuDU5AMTOI linkinden ilgili videomu izleyebilirsiniz. 

            if (!Int32.TryParse(alinanDeger, out baslangic))
            {
                Console.WriteLine("Girilen değer tam sayı olmak zorunda.");
                goto baslangicAl;
            }

            bitisAl:
            Console.WriteLine("Bitiş değerini giriniz");
            alinanDeger = Console.ReadLine();

            if (!Int32.TryParse(alinanDeger, out bitis))
            {
                Console.WriteLine("Girilen değer tam sayı olmak zorunda.");
                goto bitisAl;
            }

            istenenSayiAdet:
            Console.WriteLine("İstenen Sayı adetini giriniz");
            alinanDeger = Console.ReadLine();

            if (!Int32.TryParse(alinanDeger, out istenenSayiAdedi))
            {
                Console.WriteLine("Girilen değer tam sayı olmak zorunda.");
                goto istenenSayiAdet;
            }

            gosterilecekSayiAdet:
            Console.WriteLine("Gösterilecek Sayı adetini giriniz");
            alinanDeger = Console.ReadLine();

            if (!Int32.TryParse(alinanDeger, out gosterilecekSayiAdedi))
            {
                Console.WriteLine("Girilen değer tam sayı olmak zorunda.");
                goto gosterilecekSayiAdet;
            }

            sayilar = new double[istenenSayiAdedi, 2];

            Random random = new Random();

            for (int i = 0; i < istenenSayiAdedi; )
            {
                int sayi = random.Next(baslangic, bitis + 1);
                if (sayi % 2 != 1) continue;
                toplam += sayi;
                sayilar[i, 0] = sayi;
                i++;
            }

            double ortalama = toplam / (double)istenenSayiAdedi;

            for (int i = 0; i < istenenSayiAdedi; i++)
            {
                sayilar[i, 1] = Math.Abs(sayilar[i, 0] - ortalama);
            }

            double[,] temp = new double[1, 2];

            for (int i = 0; i < istenenSayiAdedi - 1; i++)
            {
                for (int j = 0; j < istenenSayiAdedi - 1; j++)
                {
                    if (sayilar[j, 1] > sayilar[j + 1, 1])
                    {
                        temp[0, 0] = sayilar[j, 0];
                        temp[0, 1] = sayilar[j, 1];
                        sayilar[j, 0] = sayilar[j + 1, 0];
                        sayilar[j, 1] = sayilar[j + 1, 1];
                        sayilar[j + 1, 0] = temp[0, 0];
                        sayilar[j + 1, 1] = temp[0, 1];
                    }
                }
            }

            for (int i = 0; i < gosterilecekSayiAdedi; i++)
            {
                Console.WriteLine(sayilar[i,0]);
            }

            Console.ReadLine();
        }
    }
}
