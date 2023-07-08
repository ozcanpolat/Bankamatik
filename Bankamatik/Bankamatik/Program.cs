using System;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secim = "";
            double bakiye = 0;
            double ekhesap = 1000;
            double ekhesapLimiti = 1000;

            do
            {
                Console.Write("1-Bakiye Görüntüle\n2-Para Yatırma\n3-Para Çekme\n4-Çıkış\nSeçiminiz: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.WriteLine("Bakiyeniz {0} TL", bakiye);
                        Console.WriteLine("Ek Hesap Bakiyeniz {0} TL", ekhesap);
                        break;
                    case "2":
                        Console.Write("Yatırmak İstediğiniz Miktar: ");
                        double yatirilan = double.Parse(Console.ReadLine());

                        if (ekhesap < ekhesapLimiti)
                        {
                            double ekhesaptankullanilan = ekhesapLimiti - ekhesap;
                            if (yatirilan >= ekhesaptankullanilan)
                            {
                                ekhesap = ekhesapLimiti;
                                bakiye = yatirilan - ekhesaptankullanilan;
                            }
                            else
                            {
                                ekhesap += yatirilan;
                            }
                        }
                        else
                        {
                            bakiye += yatirilan;
                        }
                        break;

                    case "3":
                        Console.Write("Çekmek İstediğiniz Miktar: ");
                        double cekilecekMiktar = double.Parse(Console.ReadLine());
                        if (cekilecekMiktar > bakiye)
                        {
                            double toplam = bakiye + ekhesap;
                            if (toplam >= cekilecekMiktar)
                            {
                                Console.Write("Ek Hesap Kullanılsın Mı? (e/h) :");
                                string ekhesaptercihi = Console.ReadLine();

                                if (ekhesaptercihi == "e")
                                {
                                    Console.Write("Paranızı Alabilirsiniz.");
                                    ekhesap -= (cekilecekMiktar - bakiye);
                                    bakiye = 0;
                                }
                                else
                                {
                                    Console.WriteLine("Bakiyeniz Yetersiz.");
                                }
                            }
                        }
                        else
                        {
                            Console.Write("Paranızı Alabilirsiniz.");
                            bakiye -= cekilecekMiktar;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Çıkış");
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yaptınız.");
                        break;

                }
            } while (secim != "4");
            Console.WriteLine("Uygulamadan Çıkış Yapıldı.");
                 
        }
    }
}
