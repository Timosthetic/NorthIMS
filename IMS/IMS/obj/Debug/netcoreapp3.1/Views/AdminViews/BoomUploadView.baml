   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews  5      )    #IMS.Views.AdminViews.BoomUploadView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IMS.Views.AdminViews     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      j	 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf 	 
      5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ? $??1??6    5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ LoginSnakeBar??5      $
??Left=?5      $??Center=?5       K? ZIndex$ 1??5      
???   ?
???  ??   MessageQueue 5!      ?? *BoundMessageQueue+?? 5"      $??10q?5#      
???????$??0q?5%       ?? CornerRadius$ 5??5&      ._?5'      c? .@?5(      ?? $	??300??5)       ?? 
IsReadOnly$
 True??5*      ??5+      ?? *
FileName+?? 5,       ?? Orientation$ 
Horizontal=?6!   .+?5-      ?? $??	ChoseFile??5/         BtnBase#??[  50      ??5.      ?? *ExceteCommand+.??51      A?  A? Columns$ 2??6*   .+?52   "   '  !MaterialDesignThemes.Wpf.PackIcon  $??Center=?53   %   $??Center=?54   %   	   Kind$	 CreditCardSearchOutline=?55   %   ?? 56   "   $??Center=?57   %   $??Center=?58   %   $??选择文件??59   %   5:      5;      ?? 5<      $??Upload??5>      #??[  5?      ??5=      ?? *ExceteCommand+.??5@      A? $ 2??6*   .+?5A   "     $??Center=?5B   %   $??Center=?5C   %   $	 DatabaseArrowUpOutline=?5D   %   ?? 5E   "   $??Center=?5F   %   $??Center=?5G   %   $??上传文件??5H   %   5I      5J      ?? 5K      $??Empty??5M      #??[  5N      ??5L      ?? *ExceteCommand+.??5O      A? $ 2??6*   .+?5P   "     $??Center=?5Q   %   $??Center=?5R   %   $ 	 CloseCircleMultipleOutline=?5S   %   ?? 5T   "   $??Center=?5U   %   $??Center=?5V   %   $??清空??5W   %   5X      5Y      5Z      5[      5\      ?? 5]      $??1??5^      $
??10,0q?5_      
???????$ 5??5a      ._?5b      ( 
 "Syncfusion.UI.Xaml.Grid.SfDataGrid  
   AllowFiltering$
 False??5c      ( 
 "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False??5d         
IsReadOnly$
 True??5e        SimpleDataGridStyle#??[ 5g         ItemsSource 5f      ?? *
BoomList+   Columns 5i      , 
 &Syncfusion.UI.Xaml.Grid.GridTextColumn  , 
 &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 母件编码??64      MappingName$ 母件编码??6F     5j      $ 母件名称??64   $ 母件名称??6F     5k      $ 子件类别??64   $ 子件类别??6F     5l      $ 子件编码??64   $ 子件编码??6F     5m      $ 子件名称??64   $ 子件名称??6F     5n      $ 主辅标识??64   $ 主辅标识??6F     5o      $ 数量??64   $ 数量??6D     5p      $ 版本??64   $ 版本??6D   5r      5s      5t      5u      5v      