using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssignmentCard : Grid
	{
		public AssignmentCard ()
		{
			InitializeComponent ();
		}
	}
}