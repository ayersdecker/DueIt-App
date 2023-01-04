using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Due_It
{
    public class AssignmentCardViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;


        protected virtual void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }

    }
}
