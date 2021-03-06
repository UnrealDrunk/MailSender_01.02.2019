﻿using System;
using System.Collections.Generic;
using MailSender.lib.Services.Iterfaces2;
using MailSender.lib.Entities.Base;
using System.Linq;

namespace MailSender.lib.Services
{
    public abstract class DataStoreInMemeory<T> : IDataStore<T> where T : BaseEntity
    {
        private readonly List<T> _Items;


        public DataStoreInMemeory(List<T> Items = null) => _Items = Items ?? new List<T>();

        public int Create(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (_Items.Contains(item)) return item.Id;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(r => r.Id) + 1;
            _Items.Add(item);
            return item.Id;
        }

        public abstract void Edit(int id, T item);
        

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int id) => _Items.FirstOrDefault(item => item.Id == id);
        
      

        public T Remove(int id)
        {
            var item = GetById(id);
            if(item != null)
            {
                _Items.Remove(item);
            }
            return item;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище {0} ", typeof(T));
        }
    }




}
