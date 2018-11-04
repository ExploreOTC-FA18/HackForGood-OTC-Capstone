using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BorrowMyAngel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavMenuMaster : ContentPage
    {
        public ListView ListView;

        public NavMenuMaster()
        {
            InitializeComponent();

            BindingContext = new NavMenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class NavMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavMenuMenuItem> MenuItems { get; set; }
            
            public NavMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<NavMenuMenuItem>(new[]
                {
                    new NavMenuMenuItem { Id = 0, Title = "Page 1" },
                    new NavMenuMenuItem { Id = 1, Title = "Page 2" },
                    new NavMenuMenuItem { Id = 2, Title = "Page 3" },
                    new NavMenuMenuItem { Id = 3, Title = "Page 4" },
                    new NavMenuMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}