
using System;
using System.Linq.Expressions;

namespace InternalsViewer.Internals
{
    public class MarkItem<T>
    {
        public MarkItem(Expression<Func<T, object>> property, int startPosition, int length)
        {
            PropertyExpression = property;
            StartPosition = startPosition;
            Length = length;
        }

        public MarkItem(Expression<Func<T, object>> property, int startPosition, int length, int index)
            : this(property, startPosition, length)
        {
            Index = index;
        }

        public MarkItem(Expression<Func<T, object>> property, string prefix, int startPosition, int length, int index)
            : this(property, startPosition, length, index)
        {
            Prefix = prefix;
        }

        public MarkItem(Expression<Func<T, object>> propertyName, string prefix, int index)
        {
            PropertyExpression = propertyName;
            Prefix = prefix;
            Index = index;
            StartPosition = -1;

        }

        public int StartPosition { get; set; }

        public int Length { get; set; }
        
        public int Index { get; set; } = -1;

        public string Prefix { get; set; }
        
        public Expression<Func<T, object>> PropertyExpression { get; set; }
    }
}
