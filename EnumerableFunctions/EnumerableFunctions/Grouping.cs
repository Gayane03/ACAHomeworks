using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableFunctions
{
    public class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public TKey Key { get; }
        private IList<TSource> SourceList { get; }  
        public Grouping(TKey key, IList<TSource> sourceList) 
        { 
           this.Key = key;
           this.SourceList = sourceList;
        }  
       

        public IEnumerator<TSource> GetEnumerator()
        {
           return SourceList.GetEnumerator();   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();  
        }
    }
}
