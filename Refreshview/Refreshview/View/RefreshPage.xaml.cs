using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Refreshview.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RefreshPage : ContentPage
	{
		public RefreshPage ()
		{
			InitializeComponent ();
		}
	}
}