using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InternalsViewer.Internals
{
    public class Markable<T>
    {
        public void Mark(Expression<Func<T, object>> propertyName, int startPosition, int length)
        {
            MarkItems.Add(new MarkItem<T>(propertyName, startPosition, length));
        }

        public void Mark(Expression<Func<T, object>> propertyName, int startPosition, int length, int index)
        {
            MarkItems.Add(new MarkItem<T>(propertyName, startPosition, length, index));
        }

        public void Mark(Expression<Func<T, object>> propertyName, string prefix, int startPosition, int length, int index)
        {
            MarkItems.Add(new MarkItem<T>(propertyName, startPosition, length, index));
        }

        public void Mark(Expression<Func<T, object>> propertyName, string prefix, int index)
        {
            MarkItems.Add(new MarkItem<T>(propertyName, prefix, index));
        }

        public void Mark(Expression<Func<T, object>> propertyName)
        {
            MarkItems.Add(new MarkItem<T>(propertyName, string.Empty, -1));
        }

        public List<MarkItem<T>> MarkItems { get; } = new List<MarkItem<T>>();
    }
}
