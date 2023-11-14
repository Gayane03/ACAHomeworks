using System.Collections;

namespace EnumerableFunctions
{
    public static class MyEnumerable
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var element in source)
            {
                if (predicate.Invoke(element))
                    yield return element;
            }
        }
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            int index = -1;
            foreach (var element in source)
            {
                ++index;
                if (predicate.Invoke(element, index))
                    yield return element;
            }
        }
        public static IEnumerable<TResult> MyOfType<TResult>(this IEnumerable source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return MyOfTypeInterator<TResult>(source);
        }
        private static IEnumerable<TResult> MyOfTypeInterator<TResult>(IEnumerable source)
        {
            foreach (var element in source)
            {
                if (element is TResult answer)
                    yield return answer;
            }
        }
        public static IEnumerable<TSource> MyOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            //SortedList<TKey, TSource> sort = new SortedList<TKey, TSource>();
            //foreach (var item in source)
            //{
            //    sort.Add(keySelector(item), item);
            //}
            //foreach (var item in sort)
            //{
            //    yield return item.Value;
            //}
            List<TSource> sortedList = source.MyToList();
            Comparison<TSource> comparison = (x, y) =>
            {
                TKey keyX = keySelector(x);
                TKey keyY = keySelector(y);
                return Comparer<TKey>.Default.Compare(keyX, keyY);
            };
            sortedList.Sort(comparison);
            foreach (var item in sortedList)
            {
                yield return item;
            }
        }
        public static IEnumerable<TSource> MyOrderBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            List<TSource> sortedList = source.MyToList();
            Comparison<TSource> comparison = (x, y) =>
            {
                TKey keyX = keySelector(x);
                TKey keyY = keySelector(y);
                if (comparer != null)
                    return comparer.Compare(keyX, keyY);
                return Comparer<TKey>.Default.Compare(keyX, keyY);
            };
            sortedList.Sort(comparison);
            foreach (var item in sortedList)
            {
                yield return item;
            }
        }
        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> keyValuePair)
        {

            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keyValuePair == null)
                throw new ArgumentNullException(nameof(keyValuePair));

            Dictionary<TKey, List<TSource>> keyValues = new Dictionary<TKey, List<TSource>>();

            foreach (var item in source)
            {
                TKey key = keyValuePair(item);
                if (!keyValues.TryGetValue(key, out List<TSource> list))
                {
                    list = new List<TSource>();
                    keyValues[key] = list;
                }
                list.Add(item);
            }
            foreach (var item in keyValues)
            {
                yield return new Grouping<TKey, TSource>(item.Key, item.Value);
            }
        }
        public static int MyCount<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null || source.Count() == 0)
                throw new ArgumentNullException(nameof(source));

            int count = 0;
            foreach (var item in source)
            {
                ++count;
            }
            return count;
        }
        public static int MyCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            int count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    ++count;
            }
            return count;
        }
        public static decimal MySum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            decimal sum = 0;
            foreach (var item in source)
            {
                sum += selector(item);
            }
            return sum;
        }
        public static decimal MyAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.MySum(selector) / source.MyCount();
        }
        public static TAccumulate MyAggregate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            TAccumulate result = seed;

            foreach (var item in source)
            {
                result = func(result, item);
            }
            return result;
        }
        public static bool MyAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }
        public static bool MyAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }
        public static bool MyAny<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                return true;
            }
                return false;
        }
        public static decimal MyMax<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            decimal max = decimal.MinValue;
            foreach (var item in source)
            {
                if (selector(item) > max)
                    max = selector(item);
            }
            return max;
        }
        public static decimal MyMin<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            decimal min = decimal.MaxValue;
            foreach (var item in source)
            {
                if (selector(item) < min)
                    min = selector(item);
            }
            return min;
        }
        public static TSource? MyFirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source is IList<TSource> l)
            {
                if (l.Count > 0)
                    return l[0];
            }
            return source.GetEnumerator().Current;
        }
        public static TSource MyFirst<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source is IList<TSource> l)
            {
                if (l.Count > 0)
                    return l[0];
            }
            throw new NotSupportedException();
        }
        public static List<TSource> MyToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (source is IList<TSource> list)
                return (List<TSource>)list;
            return new List<TSource>(source);
        }
        public static TSource[] MyToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            TSource[] array = new TSource[source.MyCount()];
            int index = 0;
            foreach (var item in source)
            {
                array[index] = item;
                ++index;
            }
            return array;
        }
        public static IEnumerable<TResult> MYSelect<TSource, TResult>(this IEnumerable<TSource> source
            , Func<TSource, TResult> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> MyJoin<TOuter, TInner, TKey, TResult>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector)
        {
            if (outer == null)
                throw new ArgumentNullException(nameof(outer));
            if (inner == null)
                throw new ArgumentNullException(nameof(inner));
            if (outerKeySelector == null)
                throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null)
                throw new ArgumentNullException(nameof(innerKeySelector));
            if (resultSelector == null)
                throw new ArgumentNullException(nameof(resultSelector));

            var innerLookup = new Dictionary<TKey, List<TInner>>();

            foreach (var innerItem in inner)
            {
                TKey key = innerKeySelector(innerItem);

                if (!innerLookup.TryGetValue(key, out var innerList))
                {
                    innerList = new List<TInner>();
                    innerLookup[key] = innerList;
                }

                innerList.Add(innerItem);
            }

            foreach (var outerItem in outer)
            {
                TKey key = outerKeySelector(outerItem);

                if (innerLookup.TryGetValue(key, out var innerList))
                {
                    foreach (var innerItem in innerList)
                    {
                        yield return resultSelector(outerItem, innerItem);
                    }
                }
            }
        }
        public static bool MyContains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            foreach (var item in source)
            {
                if (item.Equals(value))
                    return true;
            }
            return false;
        }
        
        public static TSource MyLast<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (source is IList<TSource> l)
            {
                if (l.MyCount() > 0)
                {
                    return l[l.MyCount() - 1];
                }
            }
            throw new NotSupportedException();
        }
        public static TSource MyLastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (source is IList<TSource> l)
            {
                if (l.MyCount() > 0)
                {
                    return l[l.MyCount() - 1];
                }
            }
            return source.GetEnumerator().Current;
        }
        public static TSource MySingle<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicte)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicte is null)
                throw new ArgumentNullException(nameof(predicte));

            TSource answer = source.GetEnumerator().Current;
            int temp = 0;
            foreach (var item in source)
            {
                if (!predicte(item))
                    continue;

                if (predicte(item) && temp != 0)
                    throw new InvalidOperationException();
                else
                {
                    answer = item;
                    ++temp;
                }
            }
            if (temp == 0)  
                throw new ArgumentException();

            return answer;
        }
        public static TSource? MySingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicte)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicte is null)
                throw new ArgumentNullException(nameof(predicte));

            TSource? answer = source.GetEnumerator().Current;
            int temp = 0;
            foreach (var item in source)
            {
                if (!predicte(item))
                    continue;
                if (predicte(item) && temp != 0)
                    throw new InvalidOperationException();
                else
                {
                    answer = item;
                    ++temp;
                }
            }     
            return answer;
        }
        public static IEnumerable<TSource> MyTake<TSource>(this IEnumerable<TSource> source,int count)
        {
            if(source is null)
                throw new ArgumentNullException(nameof (source));   
            if(count==0)
                throw new ArgumentException("count=0");
           
            foreach (var item in source)
            {
                if (count > 0)
                {
                    --count;
                    yield return item;
                }  
            }
        }
        public static IEnumerable<TSource> MyTake<TSource>(this IEnumerable<TSource> source, int count,Func<TSource,bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (count == 0)
                throw new ArgumentException("count=0");
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (count > 0 && predicate(item))
                {
                    --count;
                    yield return item;
                }
            }
        }

        public static IEnumerable<TType> MyAsEnumerable<TType>(this IEnumerable source)
        {
           if( source is null)  
                throw new ArgumentNullException(nameof (source));   
          
            IList<TType> list = new List<TType>(); 
            int count = 0;  
            foreach (var item in source)
            {
                ++count;
                if (item is TType titem)
                    list.Add(titem);
            }
            if(list.Count() == count)
            {
                foreach (var item in source)
                {
                    if (item is TType titem)
                        yield return titem; 
                }
            }
            throw new ArithmeticException("non cast");
        }

        public static IEnumerable<TResult> MyConcat<TSource,TParam,TResult>(this IEnumerable<TSource> source, 
            IEnumerable<TParam> param,
            Func<TSource,TParam, bool> predicate,
            Func<TResult> selectioin)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (param is null)
                throw new ArgumentNullException(nameof(param));
            if (selectioin is null)
                throw new ArgumentNullException(nameof(selectioin));


            foreach (var itemSource in source)
            {
                foreach (var itemParam in param)
                {
                    if (predicate(itemSource, itemParam))
                        yield return selectioin();
                }

            }

        }
    }
}
