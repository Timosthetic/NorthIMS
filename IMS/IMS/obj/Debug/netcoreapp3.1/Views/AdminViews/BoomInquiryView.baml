   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews  5      *    $IMS.Views.AdminViews.BoomInquiryView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IMS.Views.AdminViews     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      j	 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf 	 
      5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ? $??1??6    5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      ?? $??10q?5      
???????$??0q?5!       ?? CornerRadius$ 5??5"      ._?5#      c? .@?5$      ??    BtnBase#??[  6?   ??6   ?? *ExceteCommand+.??5%      A?  A? Columns$ 2??6&   .+?5&      '  !MaterialDesignThemes.Wpf.PackIcon  $
??Left=?5'   !   $??Center=?5(   !      Kind$ Refresh=?5)   !   ?? 5*      $??Right=?5+   !   $??Center=?5,   !   $??刷新??5-   !   5.      5/      50      51      ?? 52      $??1??53      $
??10,0q?54      
???????$??0q?56      $ 5??57      ._?58      ?  59      ?? 5:      $
??auto ?6(   ?? 5;      $??* ?6(   ?? 5<      $
??auto ?6(   .+?5>      ?? $??10q?6      PrimaryHueDarkBrush#???  6,   ?? 5?       ?? Orientation$ 
Horizontal=?6%   .+?5@        $??Right=?5A   !   $??Center=?5B   !   $ ChevronDoubleDown=?5C   !   ?? 5D      $??Center=?6(   $??	BOM信息??6C   5E      5F      ( 
 "Syncfusion.UI.Xaml.Grid.SfDataGrid  5H      $??1??5I      $??5,20,0,0q?5J      ( 
 "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False??5K         
IsReadOnly$
 True??5L        SimpleDataGridStyle#??[ 5N         ItemsSource 5M      ?? 	 ?? ElementName$	 sfDataPager??
 ?? Path$
 PagedSource?   Columns 5P      , 
 &Syncfusion.UI.Xaml.Grid.GridTextColumn  , 
 &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 母件编码??68      MappingName$ 母件编码??6J     5Q      $ 母件名称??68   $ 母件名称??6J     5R      $ 子件类别??68   $ 子件类别??6J     5S      $ 子件编码??68   $ 子件编码??6J     5T      $ 子件名称??68   $ 子件名称??6J     5U      $ 主辅标识??68   $ 主辅标识??6J     5V      ( 
 "Syncfusion.UI.Xaml.Grid.GridColumn   AllowFiltering$ False??5W   !   $ 数量??5X   !   $ 数量??5Y   !     5Z      $ 版本??68   $ 版本??6H   5\      7 
 1Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager  5]      -   5          Name$ sfDataPager??5^      $??2??5_      $??Right=?5`         AccentBackground
 ????   NumericButtonCount$ 5??5b         PageSize$ 50??5c         Source 5d      ?? *
BoomList+5f      5h      5i      5k      5m      