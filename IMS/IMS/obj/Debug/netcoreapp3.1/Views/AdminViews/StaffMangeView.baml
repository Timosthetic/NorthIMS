   M S B A M L   `   `   `  ????I  EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]?clr-namespace:Infrastructure.Extensions;assembly=InfrastructureInfrastructure.Extensions  5	       IMS)   #IMS.Views.AdminViews.StaffMangeView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      Jpass?clr-namespace:Infrastructure.Extensions;assembly=Infrastructure  5	      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5
      j fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf        5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ? $??1??6    5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ LoginSnakeBar??5      $??2??5      $??Center=?5      $??Bottom=?5       K? ZIndex$ 1??5          MessageQueue 5!      ?? *BoundMessageQueue+?? 5"      $??10q?5#      
???????$??0q?5%       ?? CornerRadius$ 5??5&      ._?5(      c? .@?5*      ?? $??Right=?5+      $??Center=?5,      $??
权限    ??5-      ?? 5.      $	??100??5/      $??Center=?50       ?? SelectedIndex 51      ?? *SelectedIndex+ ?? SelectedValue 52      ?? *
Permission+.@?53      ?? $??	装配员??6'   ?? 54      $??	上料员??6'   ?? 55      $??	仓管员??6'   ?? 56      $??	管理员??6'   58      ?? 59      $??Right=?5:      $??Center=?5;      $??
姓名    ??5<      ?? 5=      $	??100??5>      $??Center=?5?      ??5@      ?? *	StaffName+ ?? Mode$ TwoWay=??? 5A      $??Right=?5B      $??Center=?5C      $??员工号    ??5D      ?? 5E      $	??100??5F      $??Center=?5G      ??5H      ?? *
StaffNum+$ TwoWay=??? 5I      $??Right=?5J      $??Center=?5K      $??
密码    ??5L      G? 5N      $	??100??5O      $
??0,10q?5P      $	??Top=?5R      2   ,Infrastructure.Extensions.PassWordExtensions	   PassWord	 5Q      ?? *StaffPassword+$ TwoWay=?
 ?? UpdateSourceTrigger$
 PropertyChanged=?*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5S      0   *Infrastructure.Extensions.PasswordBehavior  5T      5V      ?? 5W      $
??10,0q?5X      $	??add??5Z         BtnBase#??[  5[      ??5Y      ?? *ExcuteCommad+.??5\      A?  A? Columns$ 2??6&   .+?5]      '  !MaterialDesignThemes.Wpf.PackIcon  $??Center=?5^   !   $??Center=?5_   !      Kind$ PlaylistPlus=?5`   !   ?? 5a      $??Center=?5b   !   $??Center=?5c   !   $??添加员工??5d   !   5e      5f      ?? 5h      $
??10,0q?5i      $??update??5k      #??[  5l      ??5j      ?? *ExcuteCommad+.??5m      A? $ 2??6&   .+?5n        $??Center=?5o   !   $??Center=?5p   !   $ ApplicationEditOutline=?5q   !   ?? 5r      $??Center=?5s   !   $??Center=?5t   !   $??更新信息??5u   !   5v      5w      ?? 5x      $
??10,0q?5y      $??0q?5z      #??[  5}      ??5{      ?? *ExcelCommand+??5|      ??  ?? Source %  System.Windows.Markup.Reference  *
dataGrid+.??5      A? $ 2??6&   .+?5?        $
??Left=?5?   !   $??Center=?5?   !   $ FolderSettingsOutline=?5?   !   ?? 5?      $??Right=?5?   !   $??Center=?5?   !   $??导出数据??5?   !   5?      5?      5?      5?      ?? 5?      $??1??5?      $
??10,0q?5?      
???????$??0q?5?      $ 5??5?      ._?5?      ?  5?      ?? 5?      $
??auto ?6(   ?? 5?      $??* ?6(   ?? 5?      $
??auto ?6(   .+?5?      ?? $??10q?6      PrimaryHueDarkBrush#???  6,   A? 5?      $ 2??6&   .+?5?        $??Right=?5?   !   $??Center=?5?   !   $ ChevronDoubleDown=?5?   !   ?? 5?      $??Center=?6(   $??员工信息??6C   5?      5?      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  5?      -   5          Name$ dataGrid??5?      $??1??5?      $??5,20,0,0q?5?      (	  "Syncfusion.UI.Xaml.Grid.SfGridBase 	  AllowEditing$
 True??5?       	  AutoGenerateColumns$ False??5?       	  
IsReadOnly$
 True??5?        SimpleDataGridStyle#??[ 5?         ItemsSource 5?      ??  ?? ElementName$ sfDataPager?? ?? Path$ PagedSource?   Columns 5?      ,
  &Syncfusion.UI.Xaml.Grid.GridTextColumn
  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 	员工号??68      MappingName$ 	员工号??6I   
  5?      $ 姓名??68   $ 姓名??6H   
  5?      (  "Syncfusion.UI.Xaml.Grid.GridColumn   AllowFiltering$ False??5?   !   $ 权限描述??5?   !   $ 权限描述??5?   !   
  5?      $ 授权人员工号??68   $ 授权人员工号??6L   
  5?      $ 授权人姓名??68   $ 授权人姓名??6K   0  *Syncfusion.UI.Xaml.Grid.GridDateTimeColumn  5?      $ False??5?   !      CustomPattern$ yyyy-MM-dd hh:mm:ss??5?   !   $ 更新时间??5?   !   $ 更新时间??5?   !      Pattern$ CustomPattern=?5?   !   5?      7  1Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager  5?      -   5          Name$ sfDataPager??5?      $??2??5?      $??Right=?5?         AccentBackground
 ????   NumericButtonCount$ 5??5?         PageSize$ 50??5?          Source  5?      ?? *
UserList+5?      5?      5?      5?      5?      