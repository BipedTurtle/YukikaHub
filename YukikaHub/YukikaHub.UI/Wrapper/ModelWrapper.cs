using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.Wrapper
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase
    {
        public T Model { get; }
        public ModelWrapper(T model)
        {
            this.Model = model;
        }

        public TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(this.Model);
        }

        public void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(this.Model, value);
            OnPropertyChanged(propertyName);
            this.ValidateInternal(propertyName, value);
        }

        private void ValidateInternal<TValue>(string propertyName, TValue value)
        {
            base.ClearErorrs(propertyName);

            this.ValidateDataAnnotations(propertyName, value);
            this.ValidateCustom(propertyName);
        }

        private void ValidateDataAnnotations(string propertyName, object value)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(Model) { MemberName = propertyName };
            Validator.TryValidateProperty(value, context, results);

            foreach (var result in results)
                base.AddError(propertyName, result.ErrorMessage);
        }

        private void ValidateCustom(string propertyName)
        {
            var errors = this.ValidateProperty(propertyName);
            if (errors == null)
                return;

            foreach (var error in errors)
                base.AddError(propertyName, error);
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
    }
}