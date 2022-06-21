using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuizAPI_UnitTesting.Models
{
    public class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>
           where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public override Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Add(T item)
        {
            try{
                _data.Add(item);
                //var entity = .Add(item);
                //return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
            //return item;
        }
        
        public override Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Remove(T item)
        {
            _data.Remove(item);
            //var entity = base.Attach(item);
            //return entity;
            return null;
        }

        public override Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Attach(T item)
        {
            _data.Add(item);
            var entity = base.Attach(item);
            return entity;
            //return item;
        }
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_data); }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }


    }
}
