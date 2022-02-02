﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Cach
{
  public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key);
        object Get(string key);
        bool IsAdd(string key);//Cachden mi yoksa db den mi gelecek 
        void Remove(string key);
        void RemoveByPattern(string pattern); // regex ile cachden uçurmak için 
    }
}
