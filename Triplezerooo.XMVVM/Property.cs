using System.Collections.Generic;
using System.ComponentModel;


namespace Triplezerooo.XMVVM
{
    public interface IProperty : INotifyPropertyChanged, IValidatable
    {
        string Name { get; set; }
        bool IsInvalid { get; }
        string ValidationError { get; set; }
        void Raise(string property);
    }

    public class Property<T> : IProperty
    {
        private string validationError;
        private T value;

        public Property()
        {

        }

        public Property(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                Validation.Validate(this, true);
                Raise(nameof(Value));
            }
        }

        public bool IsValid => string.IsNullOrEmpty(ValidationError);
        public bool IsInvalid => !IsValid;

        public string ValidationError
        {
            get => validationError;
            set
            {
                if (value == validationError)
                    return;

                validationError = value;
                Raise(nameof(ValidationError));
                Raise(nameof(IsValid));
                Raise(nameof(IsInvalid));

            }
        }

        public List<IValidator<T>> ValidationRules { get; set; } = new List<IValidator<T>>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void Raise(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public bool Validate(bool updateState) => Validation.Validate(this, updateState);
    }
}
