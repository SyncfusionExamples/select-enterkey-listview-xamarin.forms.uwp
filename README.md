# How to select ListView item using Enter key in Xamarin.Forms ListView (UWP)
ListView allows you to select the ListView item when the Enter key is pressed in UWP platform. You can achieve this by customizing the parent element of SfListView by which you can get the Enter key pressed notification in renderers.


**Custom KeyDetector:** Parent element that sets SelectedItem when pressing the Enter key.
```C#
public class KeyDetector : Grid 
{ 
  SfListView ListView; 
 
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
      }
  } 
} 
```
**XAML:** KeyDetector set for parent of SfListView.
``` xml
<local:KeyDetector Grid.Row="0"> 
   <syncfusion:SfListView x:Name="listView" ItemsSource="{Binding contactsinfo}"> 
        … 
   </syncfusion:SfListView> 
</local:KeyDetector> 
```
**Custom renderer:** Receive the notification of Enter key and raise the selection for SfListView. 
``` c#
public class CustomControl : Control 
{ 
 
} 
    
public class KeyDetectorRenderer : VisualElementRenderer<KeyDetector, CustomControl> 
{ 
   private CustomControl control; 
 
   protected override void OnElementChanged(ElementChangedEventArgs<KeyDetector> e) 
   { 
       base.OnElementChanged(e); 
       if (e.NewElement != null) 
       { 
           this.control = new CustomControl(); 
           this.SetNativeControl(this.control); 
           this.Control.IsTabStop = true; 
           this.KeyDown += KeyDetectorRenderer_KeyDown; 
…  
       } 
   } 
 
   private void KeyDetectorRenderer_KeyDown(object sender, KeyRoutedEventArgs e) 
   { 
      if (e.Key == VirtualKey.Enter) 
      { 
         this.Element.RaiseSelectionForListView(); 
      } 
   } 
} 
```
