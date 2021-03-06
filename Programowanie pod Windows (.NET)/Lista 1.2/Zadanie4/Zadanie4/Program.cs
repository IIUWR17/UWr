﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class ListHelper
    {
        public static List<TOutput> ConvertAll<T, TOutput>(List<T> list, 
            Converter<T, TOutput> converter)
        {
            List<TOutput> new_list = new List<TOutput>();
            for(int i = 0; i < list.Count(); i++)
            {
                new_list.Add(converter(list[i]));
            }

            return new_list;
        }
        
        public static List<T> FindAll<T>(List<T> list, Predicate<T> match)
        {
            List<T> new_list = new List<T>();
            for(int i = 0; i < list.Count(); i++)
            {
                if (match(list[i]))
                {
                    new_list.Add(list[i]);
                }
            }

            return new_list;
        }

        public static void ForEach<T>(List<T> list, Action<T> action)
        {
            for(int i = 0; i < list.Count(); i++)
            {
                action(list[i]);
            }
        }

        public static int RemoveAll<T>(List<T> list, Predicate<T> match)
        {
            int Counter = 0;
            int n = list.Count();

            for (int i = 0; i < n; i++)
            {
                if (match(list[i]))
                {
                    list.RemoveAt(i);
                    i--;
                    n--;
                    Counter += 1;
                }
            }

            return Counter;
        }


        public static void Sort<T>(List<T> list, Comparison<T> comparison)
        {
            list.Sort(comparison);
           /* int n = list.Count();
            while (n > 1)
            {
                for(int i = 0; i < n - 1; i++)
                {
                    if(comparison(list[i], list[i+1]) > 0)
                    {
                        T tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;
                    }
                    n--;
                }
            }*/
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
