using Prism.Common;
using System.Windows.Controls;

namespace PawnShop.Controls.ContractItemViews.Views
{
    /// <summary>
    /// Interaction logic for Laptop
    /// </summary>
    public partial class Laptop : UserControl
    {
        public Laptop()
        {
            InitializeComponent();
            this.Loaded += Laptop_Loaded;
        }

        private void Laptop_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ObservableObject<object> viewRegionContext = Prism.Regions.RegionContext.GetObservableContext(this);
            viewRegionContext.Value = Grid.ColumnDefinitions[0].ActualWidth;
        }
    }
}
