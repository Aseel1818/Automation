using App52.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App52.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCourseView : ContentPage
    {
        public DeleteCourseView()
        {
            InitializeComponent();
            BindingContext = new DeleteCourseModelView();

        }
    }
}