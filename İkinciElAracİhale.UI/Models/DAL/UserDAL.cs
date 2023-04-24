using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace İkinciElAracİhale.UI.Models.DAL
{
    public class UserDAL
    {
        public Kullanici KullaniciGetir(string kullaniciAdi, string sifre)
        {
            using (var db = new AracIhale())
            {
                return db.Kullanicis.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            }
        }

        public List<string> RoluneGoreKullanicilariGetir(int? rolId)
        {
            using (var db = new AracIhale())
            {
                var kullanicilar = (from r in db.Rols
                                    join k in db.Kullanicis on r.RolID equals k.RolID
                                    where r.RolID == rolId
                                    select k.KullaniciAdi).ToList();
                return kullanicilar;
            }
        }
    }
}