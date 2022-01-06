using System;
using System.Linq;
using System.Collections;

namespace CSh_Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Set numbers = new Set();
            Set numbers2 = new Set();
            Set numbers3 = new Set(numbers.Elements);
            numbers3 = numbers + numbers2;
            numbers3.ShowSet();
            numbers3 = numbers * numbers2;
            numbers3.ShowSet();
            numbers3 = numbers / numbers2;
            numbers3.ShowSet();
        }
    }

    class Set
    {
        //Поля
        public int[] Elements;
        public int Count;

        //Конструкторы
        public Set()
        {
            Console.WriteLine("Введите размер массива:");
            Count = Convert.ToInt32(Console.ReadLine());
            Elements = new int[Count];
            Console.WriteLine("Введите элементы массива:");
            Fill(Count);

        }
        public Set(int[] massiv)
        {
            Elements = massiv;
        }

        //Методы
        public void Fill(int c)
        {
            for (int i = 0; i < c; i++)
            {
                Elements[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public int IndexOf(int Value)
        {
            return Array.IndexOf(Elements, Value);
        }
        public void ShowSet()
        {
            Console.WriteLine("Элементы:");
            for (int i = 0; i < Elements.Length; i++)
            {
                Console.WriteLine(Elements[i]);
            }
        }
        public void Add(int NewElement)
        {
            Array.Resize(ref Elements, Elements.Length + 1);
            Elements.Append(NewElement);
        }

        //Перегрузка операций
        public static Set operator ++(Set set1)
        {
            for (int i = 0; i < set1.Elements.Length; i++)
            {
                set1.Elements[i] += 1;
            }
            return set1;
        }
        public static Set operator +(Set set1, Set set2)
        {
            IEnumerable ElementsUnion = from i in set1.Elements.Union(set2.Elements) select i;
            int[] ElemUnionArr = ElementsUnion.Cast<int>().ToArray();
            Set set3 = new Set(set1.Elements);
            set3.Elements = ElemUnionArr;
            return set3;
        }
        public static Set operator *(Set set1, Set set2)
        {
            IEnumerable ElementsIntersect = from i in set1.Elements.Intersect(set2.Elements) select i;
            int[] ElemInterArr = ElementsIntersect.Cast<int>().ToArray();
            Set set3 = new Set(set1.Elements);
            set3.Elements = ElemInterArr;
            return set3;
        }

        public static Set operator /(Set set1, Set set2)
        {
            IEnumerable ElementsExcept = from i in set1.Elements.Except(set2.Elements) select i;
            int[] ElemExceptArr = ElementsExcept.Cast<int>().ToArray();
            Set set3 = new Set(set1.Elements);
            set3.Elements = ElemExceptArr;
            return set3;
        }
        public static bool operator <(Set set1, Set set2)
        {
            return set1.Elements.Length < set2.Elements.Length;
        }
        public static bool operator >(Set set1, Set set2)
        {
            return set1.Elements.Length > set2.Elements.Length;
        }

        //Индексатор
        public int this[int index]
        {
            get { return Elements[index]; }
            set { Elements[index] = value; }
        }
    }
}
