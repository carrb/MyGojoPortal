using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Gojo.Core.Extensions
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected void AddDependency<R, T>(Expression<Func<R>> source, Expression<Func<T>> target)
        {
            PropertyChanged += (s, args) =>
            {
                if (args.PropertyName == source.GetPropertyName())
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(target.GetPropertyName()));
                }
            };
        }

        protected void OnPropertyChanged<R>(Expression<Func<R>> property)
        {
            PropertyChangedEventHandler propChanged = PropertyChanged;
            var propertyName = property.GetPropertyName();
            var args = new PropertyChangedEventArgs(propertyName);
            OnPropertyChanged(args);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }
        }
    }
}
