using App74.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace App74.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}