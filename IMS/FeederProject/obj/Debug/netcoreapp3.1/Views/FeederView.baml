   M S B A M L   `   `   `  ????H  DFeederProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FeederProject.ViewsFeederProject.Views  5      ;"clr-namespace:FeederProject.ModelsFeederProject.Models  5      ;"clr-namespace:FeederProject.ModelsFeederProject.Models  5      $    FeederProject.Views.FeederView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      -local!clr-namespace:FeederProject.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5
      -rich"clr-namespace:FeederProject.Models  5      /select"clr-namespace:FeederProject.Models  5      j	 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c896sync!http://schemas.syncfusion.com/wpf 	 
     5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $??3* ?6   ?? 5      $??7* ?6   .+?5   
   ?? $??2??5      $??10q?5      
??????? ?? CornerRadius$ 5??5       ._?5!      ?  5"      ?? 5#      $
??auto ?6$   ?? 5$      $??* ?6$   .+?5'      ?? $
??0,10q?6      PrimaryHueDarkBrush#???   6*   A? 5(       A? Columns$ 2??6"   .+?5)      '  !MaterialDesignThemes.Wpf.PackIcon  $??Right=?5*      $??Center=?5+         Kind$ ChevronDoubleDown=?5,      ?? 5-      $
??Left=?5.      $??Center=?5/      $??当前工单信息??50      51      52      ( 
 "Syncfusion.UI.Xaml.Grid.SfDataGrid  53      $??1??54         AllowFiltering$ False??55      ( 
 "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False??56         
IsReadOnly$
 True??57        SimpleDataGridStyle#??[ 59      	   ItemsSource	 58      ?? *
Po_Infos+
   Columns
 5;      , 
 &Syncfusion.UI.Xaml.Grid.GridTextColumn  , 
 &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 	项目号??6.      MappingName$ 	项目号??6?     5<      $ 	工单号??6.   $ 	工单号??6?     5=      $ 图号??6.   $ 图号??6>     5>      $ 线上数量??6.   $ 线上数量??6@     5?      $ 计划数量??6.   $ 工单数量??6@     5@      $ 已完工数量??6.   $ 已完工数量??6A     5A      $ 工单状态??6.   $ 工单状态??6@   5D      5G      5J      ? 5K   
   $??1??6    5L      ?? 5M      $
??auto ?6    ?? 5N      $??* ?6    .+?5Q      ?? $
??10,5q?5R      
???????$ 5??5T      ._?5V      ? $??20q?6    5W      ?? 5X      $
??auto ?6+   ?? 5Y      $??6* ?6+   ?? 5Z      $??4* ?6+   .+?5\      A? $??0,0,20,0q?6"    A? Rows$ 2??64   .+?5]      ?? $??Right=?5^      $??Center=?5_      $??20(?5`      $??标签??5a      ?? 5b      $??Right=?5c      $??Center=?5d      $??20(?5e      $??	托盘码??5f      5i      A? 5j      $??1??5k      $ 2??5m       +? FocusedElement 5l      ??  ?? ElementName$ Textbox??.+?5n      ?? -   5         ??Name$ Textbox??5o      $
??0,25q?5p       ? Cursor$ Arrow??5q      $??20(?5r      5s      ?? 5t      -   5        $ RFIDInfo??5u      $??20(?5v      ${?False??5w       ?? 
IsReadOnly$
 True??5x      5z        5{      $??2??5|      $ False??5}      $
 True??5~      #??[ 5?      	 5      ?? *NeedStation+
 5?        $ 缺料工位??62   $ stName??6D   5?      5?      5?      ?? 5?      $??1??5?      $
??10,5q?5?      
???????$ 5??5?      ._?5?      ??  ?? Orientation$ Vertical=?6   .+?5?      ?? $
??0,10q?6    #???   6.   ?? 5?      $
??40,0q?6%   $ 
Horizontal=?63   .+?5?        $??Right=?5?   !   $??Center=?5?   !   $ ChevronDoubleDown=?5?   !   ?? 5?      $
??Left=?5?   !   $??Center=?5?   !   $??标签绑定日志信息??5?   !   5?      5?      ?? 5?      -   5         ??Name$ _list??5?      $??	10,10,0,0q?5?      $??0q?5?      $??Visible=?5?       ?? View 5?      ?? 5?      P?5?   "   ?? 5?   &   $??发生时间??6`    ?? DisplayMemberBinding 65   ?? *	DateTime1+6`   ?? 5?   &   $??日志信息??6]    65   ?? *LogTxt+6]   ?? 5?   &   $??目标工位??6^    65   ?? *	Station+6^   5?      5?      5?      5?      5?      ?? 5?   
   $??1??5?      $??1??5?      $??2??5?      $??0,5,10,5q?5?      
???????$ 5??5?      ._?5?        $ False??5?      $
 True??5?      #??[ 5?      	 5?      ?? *Vehicles_Bings+
 5?        $ 产品流水号??6*   $ 
serial_num??6=     5?      $ 母件编码??6*   $ pro_code??6<     5?      $ 物料编码??6*   $ material_code??6<   5?      5?      5?      5?      