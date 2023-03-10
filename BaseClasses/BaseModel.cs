using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BaseClasses
{
  public class BaseModel : INotifyPropertyChanged
  {
    // Declare the PropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;

    // OnPropertyChanged will raise the PropertyChanged event passing the
    // source property that is being updated.
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      if (this.PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
