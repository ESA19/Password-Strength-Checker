
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public static class Password // password adlı static sınıf oluşturuldu.
    {
        public static void baslangıc() // Global değişkenlerin tanımlanması,kullanıcıya yönelik mesajlar ve kullanıcıdan sifre alan method
        {
            int score = 0;
            Console.WriteLine("<---------------------------------------------------->");
            Console.WriteLine("Lütfen Bir Şifre Giriniz!");
            string alinanSifre = Console.ReadLine();
            char[] karakterler = alinanSifre.ToCharArray();
            Password.uzunlukKontrol(karakterler, score);
            Console.ReadKey();
           
        }

        private  static void uzunlukKontrol(char[] karakterler, int score)// şifre uzunluk kontrolu yapan method

        {

            if (karakterler.Length >= 9)
            {

                score += 10;
                buyukHarfKontrol(karakterler, score);

            }
            else
            {
                Console.WriteLine("Şifre En Az Dokuz Karakter Uzunluğunda Olmalı");
                Console.WriteLine("Tekrar Deneyiniz!");
                baslangıc();
            }
        }
        private static void buyukHarfKontrol(char[] karakterler, int score) // buyuk harf kontrolü yapan method
        {
            int buyukHarfSayisi = 0;

            for (int i = 0; i < karakterler.Length; i++)
            {
                bool resultBuyuk;
                resultBuyuk = Char.IsUpper(karakterler[i]);
                if (resultBuyuk == true)
                {
                    buyukHarfSayisi++;
                }

            }
            if (buyukHarfSayisi == 1)
            {
                score += 10;

                kucukHarfKontrol(karakterler, score);
            }
            else if (buyukHarfSayisi >= 2)
            {
                score += 20;
                kucukHarfKontrol(karakterler, score);
            }
            else
            {
                Console.WriteLine("Şifre En Az Bir Büyük Harf İçermeli");
                Console.WriteLine("Tekrar Deneyiniz!");
                baslangıc();
            }

        }
        private static void kucukHarfKontrol(char[] karakterler, int score) // küçük harf kontrolü yapan method
        {
            int kucukHarfSayisi = 0;

            for (int i = 0; i < karakterler.Length; i++)
            {
                bool resultKucuk;
                resultKucuk = Char.IsLower(karakterler[i]);
                if (resultKucuk == true)
                {
                    kucukHarfSayisi++;


                }

            }
            if (kucukHarfSayisi == 1)
            {
                score += 10;


                rakamKontrol(karakterler, score);
            }
            else if (kucukHarfSayisi >= 2)
            {
                score += 20;
                rakamKontrol(karakterler, score);
            }
           
            else
            {
                Console.WriteLine("Şifre En Az Bir Küçük Harf İçermeli");
                Console.WriteLine("Tekrar Deneyiniz!");
                baslangıc();
            }

        }
        private static void rakamKontrol(char[] karakterler, int score)//rakam kontrolü yapan method
        {
            int rakamSayisi = 0;
            for (int i = 0; i < karakterler.Length; i++)
            {
                bool resultRakam;
                resultRakam = Char.IsNumber(karakterler[i]);
                if (resultRakam == true)
                {
                    rakamSayisi++;
                }

            }
            if (rakamSayisi == 1)
            {
                score += 10;

                sembolKontrol(karakterler, score);
            }
            else if (rakamSayisi >= 2)
            {
                score += 20;
                sembolKontrol(karakterler, score);
            }
            
            else
            {
                Console.WriteLine("Şifre En Az Bir Tane Rakam İçermeli");
                Console.WriteLine("Tekrar Deneyiniz!");
                baslangıc();

            }

        }
        private static void sembolKontrol(char[] karakterler, int score)// sembol ve noktalama işareti kontolü yapan method
        {
            int noktalamaSayisi = 0;
            int sembolSayisi=0;
            for (int i = 0; i < karakterler.Length; i++)
            {
                
                bool resultNoktalama,resultSembol;
                resultNoktalama=Char.IsPunctuation(karakterler[i]);
                resultSembol=Char.IsSymbol(karakterler[i]);
                if(resultNoktalama == true)
                {
                    noktalamaSayisi++;
                    score += 10;
                }
                if (resultSembol == true)
                {
                    sembolSayisi++;
                    score += 10;
                }

            }
            if (noktalamaSayisi>0||sembolSayisi>0)
            {
                Console.WriteLine("Şifre Seviyeniz: " + score);
                if (score < 70)
                {

                    Console.WriteLine("Şifre Seviyesi Çok Düşük Şifre Kabul Edilemez!");
                    Console.WriteLine("Lütfen Şifrenizi Daha Karmaşık Hale Getirin");
                }
                else if (score >= 70 && score < 90)
                {
                    Console.WriteLine("Şifre Seviyesi Orta Seviyede Şifre Kabul Edilebilir!");
                    Console.WriteLine("Güvenliğiniz İçin Şifrenizi Daha Karmaşık Hale Getirmenizi Öneririz!");
                }
                else if (score >= 90)
                {
                    Console.WriteLine("Şifre Seviyesi Güçlü Seviyede Şifre Kabul Edilebilir!");
                }

            }
            else
            {
                Console.WriteLine("Şifre En Az Bir Tane Sembol İçermeli");
                Console.WriteLine("Tekrar Deneyiniz!");
                baslangıc();
            }

        }
    }
}
