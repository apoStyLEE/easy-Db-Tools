using System;
using System.Collections.Generic;
using System.Collections;
using System.Web.Caching;
using System.Web;

public class onbellek
{
	public static void tumunuTemizle()
	{
        List<string> keys = new List<string>();
        IDictionaryEnumerator _enumerator = HttpContext.Current.Cache.GetEnumerator();
        while (_enumerator.MoveNext())
        {
            keys.Add(_enumerator.Key.ToString());
        }
        for (int i = 0; i < keys.Count; i++)
        {
            HttpContext.Current.Cache.Remove(keys[i]);
        }
	}
    public static List<string> tumunuListele(){
        List<string> keys = new List<string>();
        IDictionaryEnumerator _enumerator = HttpContext.Current.Cache.GetEnumerator();
        while (_enumerator.MoveNext())
        {
            keys.Add(_enumerator.Key.ToString());
        }
        return keys;
    }
    public static string Temizle(string key) {
        string _durum;
        if (HttpContext.Current.Cache[key] != null)
        {
            HttpContext.Current.Cache.Remove(key);
            _durum = "Silindi !";
        }
        else
        {
            _durum = "Bir hata oluştu !";
        }
        return _durum;
    }
}
