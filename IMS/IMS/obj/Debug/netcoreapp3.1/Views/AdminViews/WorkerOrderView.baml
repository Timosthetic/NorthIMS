   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews  5      *    $IMS.Views.AdminViews.WorkerOrderView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IMS.Views.AdminViews     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      j	 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf 	 
      5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ? $??1??6    5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      ?? $??10q?5      
???????$??0q?5       ?? CornerRadius$ 5??5       ._?5!      c? .@?5"      ?? $
??10,0q?5#       "  MaterialDesignPaperLightButton#??[  5%      ??5$      ?? *
AddCommand+.??5&      A?  A? Columns$ 2??6&   .+?5'      '  !MaterialDesignThemes.Wpf.PackIcon  $
??Left=?5(   !   $??Center=?5)   !      Kind$ PlaylistPlus=?5*   !   ?? 5+      $??Center=?5,   !   $??Center=?5-   !   $??创建??5.   !   5/      50      ?? 51      #??[  54      ??52      ?? *EditCommand+??53      ?? *SelectedItem+ ?? ElementName$ DrderDatagrid??.??55      A? $ 2??6&   .+?56        $
??Left=?57   !   $??Center=?58   !   
???   ?$ PlaylistEdit=?5:   !   ?? 5;      $??Center=?5<   !   $??Center=?5=   !   $??编辑??5>   !   5?      5@      ?? 5A      $
??10,0q?5B      
???  ??$??0q?5D        MaterialDesignRaisedButton#??[ 5G      ??5E      ?? *DeleteCommand+??5F      ?? *SelectedItem+$ DrderDatagrid??.??5H      A? $ 2??6&   .+?5I        $
??Left=?5J   !   $??Center=?5K   !   
???   ?$ DeleteForever=?5M   !   ?? 5N      $??Right=?5O   !   $??Center=?5P   !   
???   ?$??删除??5R   !   5S      5T      ?? 5U      
??? ? ?$??0q?5W      #??[ 5Z      ??5X      ?? *StartCommand+??5Y      ?? *SelectedItem+$ DrderDatagrid??.??5[      A? $ 2??6&   .+?5\        $
??Left=?5]   !   $??Center=?5^   !   
???   ?$ 	PageFirst=?5`   !   ?? 5a      $??Right=?5b   !   $??Center=?5c   !   
???   ?$??开始??5e   !   5f      5g      ?? 5h      $
??10,0q?5i      
??? ???$??0q?5k      #??[ 5n      ??5l      ?? *PauseCommand+??5m      ?? *SelectedItem+$ DrderDatagrid??.??5o      A? $ 2??6&   .+?5p        $
??Left=?5q   !   $??Center=?5r   !   
???   ?$ Pause=?5t   !   ?? 5u      $??Right=?5v   !   $??Center=?5w   !   
???   ?$??暂停??5y   !   5z      5{      ?? 5|      
???  ??$??0q?5~      #??[ 5?      ??5      ?? *StopCommand+??5?      ?? *SelectedItem+$ DrderDatagrid??.??5?      A? $ 2??6&   .+?5?        $
??Left=?5?   !   $??Center=?5?   !   
???   ?$ 	PlayPause=?5?   !   ?? 5?      $??Right=?5?   !   $??Center=?5?   !   
???   ?$??中止??5?   !   5?      5?      ?? 5?      $??100,5q?5?      $??Right=?5?      #??[  5?      ??5?      ?? *RefreshCommand+.??5?      A? $ 2??6&   .+?5?        $
??Left=?5?   !   $??Center=?5?   !   $ Refresh=?5?   !   ?? 5?      $??Center=?5?   !   $??Center=?5?   !   $??刷新??5?   !   5?      5?      ?? 5?      $??100,5q?5?      $??Right=?5?      #??[  5?      ??5?      ?? *ExcelCommand+??5?      ??  ?? Source %  System.Windows.Markup.Reference  *DrderDatagrid+.??5?      A? $ 2??6&   .+?5?        $
??Left=?5?   !   $??Center=?5?   !   $ FolderSettingsOutline=?5?   !   ?? 5?      $??Center=?5?   !   $??Center=?5?   !   $??导出??5?   !   5?      5?      5?      5?      ?? 5?      $??1??5?      $
??10,0q?5?      
???????$??0q?5?      $ 5??5?      ._?5?      ?  5?      ?? 5?      $
??auto ?6(   ?? 5?      $??* ?6(   ?? 5?      $
??auto ?6(   .+?5?      ?? $??10q?6      PrimaryHueDarkBrush#???  6,   A? 5?      $ 2??6&   .+?5?        $??Center=?5?   !   $??Center=?5?   !   $ ChevronDoubleDown=?5?   !   ?? 5?      $??Center=?6(   $??工单信息??6C   5?      5?      ( 
 "Syncfusion.UI.Xaml.Grid.SfDataGrid  5?      -   5          Name$ DrderDatagrid??5?      $??1??5?      ( 
 "Syncfusion.UI.Xaml.Grid.SfGridBase   
IsReadOnly$
 True??5?        SimpleDataGridStyle#??[ 5?      	   ItemsSource	 5?      ?? $ sfDataPager??
 ?? Path$
 PagedSource?   SelectedItem 5?      ?? *SelectedOrder+   Columns 5?      , 
 &Syncfusion.UI.Xaml.Grid.GridTextColumn  , 
 &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 	项目号??68      MappingName$ 	项目号??6I     5?      $ 	任务号??68   $ 	工单号??6I     5?      $ 图号/产品型号??68   $ 图号??6M     5?      ( 
 "Syncfusion.UI.Xaml.Grid.GridColumn   AllowFiltering$ False??5?   !   $ 生产数量??5?   !   $ 工单数量??5?   !     5?      $ 计划状态??68   $ 工单状态??6J   0	 
 *Syncfusion.UI.Xaml.Grid.GridDateTimeColumn	  5?      $ False??5?   !    	  CustomPattern$ yyyy-MM-dd hh:mm:ss??5?   "   $ 计划完工日期??5?   !   $ 计划完工日期??5?   !    	  Pattern$ CustomPattern=?66     5?      $ False??5?   !   $ 流转路线??5?   !   $ 流转路线??5?   !   5?      7
 
 1Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager
  5?      -   5         
 Name$ sfDataPager??5?      $??2??5?      $
??30,0q?5?      $??Right=?5?       
  AccentBackground
 ???? 
  NumericButtonCount$ 5??5?       
  PageSize$ 50??5?       
  Source 5?      ?? *
Po_Infos+5?      5?      5?      5?      5?      