   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews  5      I EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]?clr-namespace:Infrastructure.Extensions;assembly=InfrastructureInfrastructure.Extensions 5      U;clr-namespace:Infrastructure.Common;assembly=InfrastructureInfrastructure.Common 5      E ADragablz, Version=0.0.3.234, Culture=neutral, PublicKeyToken=nullC/clr-namespace:Dragablz.Themes;assembly=DragablzDragablz.Themes 5      2    ,IMS.Views.AdminViews.StationFlowLableNewView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6dragablz'http://dragablz.net/winfx/xaml/dragablz  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      .local"clr-namespace:IMS.Views.AdminViews  5      _	 [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5
      Jpass?clr-namespace:Infrastructure.Extensions;assembly=Infrastructure 	 5      [
 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 
  5      j fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf        5      Qtab;clr-namespace:Infrastructure.Common;assembly=Infrastructure        5      Hthemes/clr-namespace:Dragablz.Themes;assembly=Dragablz        5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5         
_textblock   MaterialDesignBody1TextBlock ?? BasedOn ?? 
TargetType ?? Property ?? Value0  *Infrastructure.Common.DivideValueConverter  DivideValueConverter??%?   &	        7  &	 ?     ?? 5   
   8   " ??5      .?5      ??  ? ??$ Center=?64   ?? 5       ? ??$ Center=?62   ?? 5       ? ??$ 0,20,0,0q?6'   5        5   
   6#   5       .??5!      ?  ? RowDefinitions 5"   
   ?? 5#      $
??auto ?6   ?? 5$      $??* ?6   .+?5'   
   ?? $??10q?5(      
???????$??0q?5*       ?? CornerRadius$ 5??5+      ._?5,      c? .@?5-      ?? $??Right=?5.      $??Center=?5/      $??任务号/工单号  ??50      ?? 51      -   5         ??Name$ 	_ComBoBox??52      $	??150??53      	 ?? DisplayMemberPath$	 	工单号??54      
 ?? SelectedValuePath$
 ID??56      ??55      ?? *	PlanCodes+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 57      +  %Microsoft.Xaml.Behaviors.EventTrigger  58         	EventName$ SelectionChanged??6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 59      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   ?? *SelectedPlanCodeCommand+   CommandParameter 6`   ?? *SelectedItem+ ?? ElementName$ 	_ComBoBox??5:      5<      ?? 5=      $??Right=?5>      $??Center=?5?      $??计划状态    ??5@      ?? 5A      $	??100??5B      $??Center=?5C      ${?False??5D       ?? 
IsReadOnly$
 True??5E      ??5F      ?? *PlanInfo.工单状态+ ?? Mode$ TwoWay=??? 5G      $??Right=?5H      $??Center=?5I      $??产品类型    ??5J      ?? 5K      $	??150??5L      $
??0,10q?5M      $??Center=?5N      ${?False??5O      $
 True??5P      ??5Q      ?? *PlanInfo.图号+$ TwoWay=??? 5R      $??Right=?5S      $??Center=?5T      $??计划数量    ??5U      ?? 5V      $	??100??5W      $
??0,10q?5X      $??Center=?5Y      ${?False??5Z      $
 True??5[      ??5\      ?? *PlanInfo.工单数量+$ TwoWay=??? 5]      $??Right=?5^      $??Center=?5_      $#??标牌流水码起始值  NO.??5`      ?? 5a      $??Right=?5b      $??Center=?5c      ??5d      ?? *Year+$ TwoWay=??? 5e      $	??100??5f      $
??0,10q?5g      $??Center=?5h      ??5i      ?? *SerialStartNum+$ TwoWay=??? 5j      $
??10,0q?5k        BtnBase#??[ 5m      ??5l      ?? *LoadInfoCommand+.??5n      A?  A? Columns$ 2??6"   .+?5o      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $??Center=?5p      $??Center=?5q         Kind$ PlaylistPlus=?5r      ?? 5s      $??Center=?5t      $??Center=?5u      $??加载信息??5v      5w      5x      5|      5}      ?? 5   
   $??1??5?      $??
10,0,10,10q?5?      ???#303843$??0q?5?      $ 5??5?      ._?5?        Dragablz.TabablzControl  ??5?      ?? 5?       & "MaterialDesignDragableTabItemStyle# [ 6   	  Dragablz.DragablzItem" 	 6Z    ?? Triggers 5?      P? 5?       P? Property ?@	 
IsSelected P? Value$
 True??6<   . ?5?   "   ?? *
  $Dragablz.Themes.MaterialDesignAssist ?@
 IndicatorBrush
 ?????6_   5?      .?5?      ??  ? ?? 62   ?? *ActualWidth+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType"   ?? 	Converter# [  ?? ConverterParameter$ 9??5?      .@?5?      ?? $??主料标签打印??6   .??5?      ?  5?      ?? 5?      $??* ?6,   ?? 5?      $
??auto ?6,   .+?5?      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  -   5          Name$ peocess??5?      $
??0,20q?5?      (  "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False??5?        SimpleDataGridStyle#??[ 5?         ItemsSource 5?      ?? *MPrintNodes+   Columns 5?   "   ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  (  "Syncfusion.UI.Xaml.Grid.GridColumn    AllowFiltering$  False??5?   %   ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase!   
HeaderText$! 	流水号??5?   %   "   MappingName$" 
serial_num??5?   %     5?   "   $  False??5?   %   $! 流转工位??5?   %   $" station??5?   %     5?   "   $  False??5?   %   $! 产品名称??5?   %   $" proName??5?   %     5?   "   $! 打印标记??6<   $" IsCode??6N   0  *Syncfusion.UI.Xaml.Grid.GridTemplateColumn  5?   "   $  False??5?   %   #   AllowSorting$# False??5?   %   $! 操作??5?   %   $   CellTemplate$ 5?   &   ?? 5?   *   .R?5?   .   ?? % ?? Orientation$% 
Horizontal=?69   .+?5?   2   9  3Syncfusion.Windows.Tools.Controls.DropDownButtonAdv  &   Label$& 操作??6O     OperationButtonStyle#??[ 6Z   .??5?   6   ?? $% Vertical=?6A   .+?5?   :   ?? $??5q?5?   =   $??3q?5?   =   
?????? $??0q?5?   =   $??补印??5?   =   
?????????5?   =   ?? *DataContext.ReprintCommand+ ?? ' ?? Mode$' FindAncestor=? syncfusion:SfDataGrid??5?   =   ?? 5?   =   5?   7   5?   3   5?   /   5?   +   5?   #   5?      ? 5?      $??1??6   $??
20,0,10,10q?6,   ( ? ColumnDefinitions( 5?      ?? 5?   "   ?? 5?   "   ?? 5?   "   .+?5?      ?? $??1??5?   !   $??Right=?5?   !   $% 
Horizontal=?5?   !   .+?5?   "   ?? $
??20,0q?5?   %   #??[  5?   %   $??未打印数量:??5?   %   ?? 5?   "   $	??100??5?   %   $??Center=?5?   %   ${?False??5?   %   $
 True??5?   %   ??5?   %   ?? *MNum+?? 5?   "   $
??20,0q?5?   %   #??[  5?   %   $??打印数量:??5?   %   ?? 5?   "   $	??100??5?   %   $??Center=?5?   %   ??5?   %   ?? *
PrintNum+5?      ?? 5?      $??2??5?   !   $	??200??5?   !   $
??10,0q?5?   !   $	??主??5?   !   #??[ 5?   !   ??5?   !   ?? *PrintLableCommand+{?5?   !   ?? *BtnPrintIsenable+.??5?   "   A? $ 2??6.   .+?5?   &     $??Center=?5?   )   $??Center=?5?   )   $ PlaylistPlus=?5?   )   ?? 5?   &   $??Center=?5   )   $??Center=?5  )   $??打印??5  )   5  #   5     5     5     5     ?? 5	     $??辅料标签打印??6   .??5
     ?  5     ?? 5     $??* ?6,   ?? 5     $
??auto ?6,   .+?5       -   5        $ Speocess??5     $
??0,20q?5     $ False??5     #??[ 5      5     ?? *SPrintNodes+ 5  "   0  *Syncfusion.UI.Xaml.Grid.GridCheckBoxColumn  )   Width$) 70Q?5  %   *   AllowEditing$
* True??5  %   $  False??5  %   $! 打印选择??5   %   +   
IsReadOnly$+ False??5!  %   $" 	IsShipped??5"  %     5#  "   $  False??5$  %   $! 	流水号??5%  %   $" 
serial_num??5&  %     5'  "   $  False??5(  %   $! 流转工位??5)  %   $" station??5*  %     5+  "   $  False??5,  %   $! 产品名称??5-  %   $" proName??5.  %   51     ? 52     $??1??6   $??
20,0,10,10q?6,   ( 53     ?? 54  "   ?? 55  "   ?? 56  "   .+?58     ?? $
??20,0q?59  !   
???  ??#??[  5;  !   $(??"注:辅料标签可以重复打印??5<  !   ?? 5=     $??1??5>  !   $??Right=?5?  !   $% 
Horizontal=?5@  !   .+?5C  "   ?? $
??20,0q?5D  %   #??[  5E  %   $??打印套数:??5F  %   ?? 5G  "   $	??100??5H  %   $??Center=?5I  %   ??5J  %   ?? *	SprintNum+5M     ?? 5N     $??2??5O  !   $	??200??5P  !   $
??10,0q?5Q  !   #??[ 5S  !   ??5R  !   ?? *PrintLableSCommand+.??5T  "   A? $ 2??6.   .+?5U  &     $??Center=?5V  )   $??Center=?5W  )   $ PlaylistPlus=?5X  )   ?? 5Y  &   $??Center=?5Z  )   $??Center=?5[  )   $??打印??5\  )   5]  #   5^     5_     5a     5b     5c     5d     5e     5f     