   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:IMS.Model	IMS.Model  5      ;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews  5      .    (IMS.Views.AdminViews.DatenverfolgungView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )excelclr-namespace:IMS.Model     5      4local"clr-namespace:IMS.Views.AdminViews     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      j fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j	 fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b
 ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf   	 
    5
      .??5      ?   ? RowDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5      $??8* ?6   ?? 5      $
??auto ?6   .+?5   
   ?? $??10q?5      
???????$??0q?5       ?? CornerRadius$ 5??5      ._?5      c? .@?5      ?? $
??10,5q?5      $??0q?5         MaterialDesignRaisedButton#??[  5!      ??5      ?? *ExcelCommand+??5       ??  ?? Source %  System.Windows.Markup.Reference  *
dataGrid+.??5#      A?  A? Columns$ 2??6"   .+?5$      '  !MaterialDesignThemes.Wpf.PackIcon  $
??Left=?5%      $??Center=?5&         Kind$ FolderSettingsOutline=?5'      ?? 5(      $??Right=?5)      $??Center=?5*      $??导出数据??5+      5,      5-      ?? 5.      $??Center=?5/      
???  ??$@??:注:导出数据前请先进行筛选符合条件的数据??51      52      53      ? 54   
   $??1??6   $??	10,0,10,0q?6   .+?55      ?? 
???????$??0q?57      $ 5??58      ._?59      ?   5:      ?? 5<      ?? 5=      $
??auto ?6(   .+?5?      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  -   5          Name$ dataGrid??5@      (  "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False??5A         
IsReadOnly$
 True??5C        SimpleDataGridStyle#??[ 5E         ItemsSource 5D      ?? 	 ?? ElementName$	 sfDataPager??
 ?? Path$
 PagedSource?   Columns 5G      ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 	流水号??68      MappingName$ 
Serial_num??6I     5H      $ 标牌唯一信息??68   $ TagSerialnum??6L     5I      $ 工位ID??68   $ 
StrStation??6J   0  *Syncfusion.UI.Xaml.Grid.GridDateTimeColumn  5J         CustomPattern$ yyyy-MM-dd hh:mm:ss??5K   !   $ 进站时间??5L   !   $ 
IN_Station??5M   !      Pattern$ CustomPattern=?5N   !     5O      $ yyyy-MM-dd hh:mm:ss??5P   !   $ 出站等待时间??5Q   !   $ OutWait_Station??5R   !   $ CustomPattern=?5S   !     5T      $ yyyy-MM-dd hh:mm:ss??5U   !   $ 出站时间??5V   !   $ Out_Station??5W   !   $ CustomPattern=?5X   !     5Y      $ 加工工时/min??68   $ Processing_Hours??6N     5Z      $ 等待工时/min??68   $ 
Wait_Hours??6N     5[      $ 员工姓名??68   $ 	StaffName??6J     5\      $ 员工工号??68   $ StaffNum??6J     5]      $ 	工单号??68   $ 	WorkOrder??6I   5_      7  1Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager  5`      -   5          Name$ sfDataPager??5a      $??1??5b      $??Right=?5c         AccentBackground
 ????   NumericButtonCount$ 5??5e         PageSize$ 50??5f         Source 5g      ?? *Dt_Trace_Track+5h      5k      5l      5n      5o      