using PawnShop.Core.ScopedRegion;
using PawnShop.Modules.Sale.Base;
using Prism.Regions;
using System.Windows;

namespace PawnShop.Modules.Sale.Views
{
    /// <summary>
    /// Interaction logic for SaleBasicInfo
    /// </summary>
    public partial class SaleBasicInfo : SaleInfoViewBase
    {
        public SaleBasicInfo(IRegionManager regionManager)
        {
            InitializeComponent();
            var scopedRegionManager = regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(SaleBasicInfoContentControl, scopedRegionManager);
            RegionManager.SetRegionManager(SaleInfoContentControl, scopedRegionManager);
            RegionManagerAware.SetRegionManagerAware(this, scopedRegionManager);
            SaleInfoContentControl.Loaded += SaleInfoContentControl_Loaded; // to do?
        }

        private void SaleInfoContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustGrids(SaleBasicInfoContentControl, SaleInfoContentControl, SellGroupBox);
        }

    }

}