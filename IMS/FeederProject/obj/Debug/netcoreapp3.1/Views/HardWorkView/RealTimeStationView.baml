   M S B A M L   `   `   `  ????I  EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU;clr-namespace:Infrastructure.Common;assembly=InfrastructureInfrastructure.Common  5      H DFeederProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:FeederProject.Views.HardWorkView FeederProject.Views.HardWorkView 5      :   4FeederProject.Views.HardWorkView.RealTimeStationView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Oconvert;clr-namespace:Infrastructure.Common;assembly=Infrastructure     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:FeederProject.Views.HardWorkView     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5
      j	 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c896sync!http://schemas.syncfusion.com/wpf 	 
     5        ? 	Resources  5      1   +Infrastructure.Common.ColorToBrushConverter   ColorToBrushConverter??%   &	          5   
   6(   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??1??5      $??5q?5      
??????? ?? CornerRadius$ 5??5      ._?5      c? .@?5       ?? $
??20,0q?5!      $??Center=?5"      $??Center=?5#      $??15(?5$      $??西门子PLC??5%      ?? 5&      $
??20,0q?5'      $??Right=?5(      $??Center=?5)      $??15(?5*      $	??IP:??5+      ?? 5,      $	??150??5-       ? Cursor$ Arrow??5.      $??15(?5/      ??50      ?? *Ip+?? 51      $
??20,0q?52      $??Center=?53      $??15(?54      $??连接状态??55      '  !MaterialDesignThemes.Wpf.PackIcon  56      $??30??57      $??30??58      $??Center=?59         Kind$ Brightness1=?5;      ??5:      ?? *IsConnectPlc+ ?? 	Converter# [   ?? UpdateSourceTrigger$ PropertyChanged=? ?? Mode$ TwoWay=?5;      ?? 5<      $??100,0q?5=      $??重连??5?      $??15(?5@        BtnBase#??[ 5A      ??5>      ?? *ConnectCommand+5A      ?? 5B      $
??10,0q?5C      $??超时刷新??5E      $??15(?5F      #??[ 5G      ??5D      ?? *ConnectCommand+5G      5H      5I      ?? 5J   
   $??2??5K      $??5q?5L      
???????$ 5??5N      ._?5P      ( 
 "Syncfusion.UI.Xaml.Grid.SfDataGrid  ( 
 "Syncfusion.UI.Xaml.Grid.SfGridBase   AllowEditing$ False??5Q      	   AllowResizingColumns$	 False??5R      
   AllowSorting$
 False??5S         AllowTriStateSorting$
 True??5T         AutoGenerateColumns$ False??5U         
IsReadOnly$
 True??5V      !   NewItemPlaceholderPosition$ AtBeginning=?5X        SimpleDataGridStyle#??[ 5Y         ItemsSource 5W      ?? *
ObPlcEvnet+   Columns 5[      , 
 &Syncfusion.UI.Xaml.Grid.GridTextColumn  ( 
 "Syncfusion.UI.Xaml.Grid.GridColumn   AllowFiltering$ False??5\      , 
 &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 处理线程??5]         MappingName$ FName??5^        5_      $ False??5`      $	 Seq??5a      $ SeqID??5b        5d      $ 	载具码??6*   $ 	FTrayName??6;     5f      $ False??5g      $ 事件名称??5h      $  FEvent??5i      0 
 *Syncfusion.UI.Xaml.Grid.GridDateTimeColumn  5j      $ False??5k         AllowSorting$
 True??5l         CustomPattern$ yyyy-MM-dd HH:mm:ss??5m      $ 请求时间??5n      $  FStartTime1??5o         Pattern$ CustomPattern=?64     5p      $ False??5q      $ 处理耗时(ms)??5r      $  FDoTime??5s      0	 
 *Syncfusion.UI.Xaml.Grid.GridTemplateColumn	  5t      $ False??6.   $ 回复结果??6E      CellTemplate 5u      ?? 5v      .R?5w   "   ?? 
?????????5x   %   ?? *FResultColor+??5z   %   ?? *	FResult+5{      5}        5~      $ False??5      $ 回复提示??5?      $ FResultMark??5?      5?      5?      5?      5?      