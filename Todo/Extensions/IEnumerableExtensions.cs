using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// ForEachWhere(x=>x.filter, doAction: (x)=>x.doSomething);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="where"></param>
        /// <param name="doAction"></param>
        public static void ForEachWhere<T>(this IEnumerable<T> @this, Func<T,bool> where, Action<T> doAction)
        {
            foreach (T item in @this.Where(where))
            {
                doAction(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
            {
                action(item);
            }
        }

    }
}
