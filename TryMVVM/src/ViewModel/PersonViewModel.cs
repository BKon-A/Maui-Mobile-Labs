using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TryMVVM.src
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        Person person = new Person { Name = "Tom", Age = 88 };

        public string Name
        {
            get => person.Name;
            set
            {
                if (person.Name != value)
                {
                    person.Name = value;
                    OnPropertyChanged();
                }
            }

        }
        public int Age
        {
            get => person.Age;
            set
            {
                if (person.Age != value)
                {
                    person.Age = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
