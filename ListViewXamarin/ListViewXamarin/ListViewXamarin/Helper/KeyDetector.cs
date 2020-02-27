using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class KeyDetector : Grid
    {
        SfListView ListView;

        public KeyDetector()
        {

        }

        public void RaiseSelectionForListView()
        {
            if (ListView == null)
                ListView = this.Children[0] as SfListView;

            if (ListView != null)
            {                    
                //Write the logics based on SelectionMode of SfListView here.
                if (ListView.SelectedItem != ListView.CurrentItem)
                    ListView.SelectedItem = ListView.CurrentItem;
                else
                    ListView.SelectedItem = null;

                var methodinfo = ListView.GetType().GetRuntimeMethods().FirstOrDefault(x => x.Name == "RaiseSelectionChangedEvent");
                methodinfo.Invoke(ListView, new object[] { null });
            }
        }
    }
}