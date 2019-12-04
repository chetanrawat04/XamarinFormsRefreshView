using Refreshview.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Refreshview.ViewModel
{
    class RefreshPageViewModel : INotifyPropertyChanged
    {
        const int RefreshDuration = 2;
        int itemNumber = 1;
        readonly Random random;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<RefreshModel> _Items;
        public ObservableCollection<RefreshModel> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());
        public RefreshPageViewModel()
        {
            random = new Random();
            Items = new ObservableCollection<RefreshModel>();
            AddItems();
        }
        void AddItems()
        {
            for (int i = 0; i < 50; i++)
            {
                _Items.Add(new RefreshModel
                {
                    Color = Color.FromRgb(random.Next(100, 255), random.Next(50, 200), random.Next(10, 255)),
                    Name = $"Item {itemNumber++}"
                });
            }
        }
        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            Items = null;
            Items = new ObservableCollection<RefreshModel>();
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            AddItems();
            IsRefreshing = false;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
