using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcers.Caching
{
    public interface ICacheService
    {
        //Burada bir çok cache yapısı kurabileceğin yer olduğu için interface loose-coupling ile yapılır.

        T Get<T>(string key); //belli bir tipteki cache değerini okumayı sağlar.
        object Get(string key); //burada tip dönüşümü yapılması gerekir. T Get<T> nin generic olmayan hali.
        void Add(string key, object value, int duration); //object bütün gelebilecek veri tiplerinin basedir.
        bool IsAdd(string key); // eklenmemiş mi ? yani cacheden mi veritabanından mı okuyacağını bildiği yerdir.
        void Remove(string key); //belli bir tipteki cachein ortadan kaldırılmasını sağlar.
        void RemoveByPattern(string pattern); //buradaki cache uçurucak ancak amacı şu içinde get olanları uçur demek istersen mesela bu kullanılacak.
    }
}
