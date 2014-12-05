using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SystemUpdate
{
    public abstract class BindableObject : INotifyPropertyChanged
    {
        private Dictionary<string, object> _valueStorage = new Dictionary<string, object>();
        private Dictionary<string, List<string>> _dependencies = new Dictionary<string, List<string>>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null) throw new ArgumentException("Invalid lambda expression", "property");
            var propertyName = GetPropertyName(lambdaExpression);
            NotifyPropertyChanged(propertyName);
        }

        protected void SetValue<T>(Expression<Func<T>> property, T value)
        {
            var lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null) throw new ArgumentException("Invalid lambda expression", "property");
            var propertyName = GetPropertyName(lambdaExpression);
            var storedValue = GetValue<T>(propertyName);
            if (!object.Equals(storedValue, value))
            {
                _valueStorage[propertyName] = value;
                NotifyPropertyChanged(propertyName);
                NotifyPropertyChangedForDependencies(propertyName);
            }
        }

        protected T GetValue<T>(Expression<Func<T>> property)
        {
            var lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null) throw new ArgumentException("Invalid lambda expression", "property");
            var propertyName = GetPropertyName(lambdaExpression);
            return GetValue<T>(propertyName);
        }

        protected void RegisterPropertyDependency<TProperty, TDependsOn>(Expression<Func<TProperty>> property, Expression<Func<TDependsOn>> dependsOn)
        {
            var propertyName = GetPropertyName(property);
            var dependsOnPropertyName = GetPropertyName(dependsOn);

            if (!_dependencies.ContainsKey(dependsOnPropertyName))
            {
                _dependencies.Add(dependsOnPropertyName, new List<string> { propertyName });
            }
            else
            {
                _dependencies[dependsOnPropertyName].Add(propertyName);
            }
        }

        private T GetValue<T>(string propertyName)
        {
            if (_valueStorage.ContainsKey(propertyName))
            {
                return (T)_valueStorage[propertyName];
            }
            else
            {
                return default(T);
            }
        }

        private string GetPropertyName(LambdaExpression lambdaExpression)
        {
            MemberExpression memberExpression;
            if (lambdaExpression.Body is UnaryExpression)
            {
                var unaryExpression = lambdaExpression.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambdaExpression.Body as MemberExpression;
            }
            return memberExpression.Member.Name;
        }

        private void NotifyPropertyChangedForDependencies(string propertyName)
        {
            if (!_dependencies.ContainsKey(propertyName)) return;

            foreach (var dependency in _dependencies[propertyName])
            {
                NotifyPropertyChanged(dependency);
            }
        }
    }
}