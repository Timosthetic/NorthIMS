   M S B A M L   `   `   `  ????I  EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU;clr-namespace:Infrastructure.Common;assembly=InfrastructureInfrastructure.Common  5      ]?clr-namespace:Infrastructure.Dto.NewDto;assembly=InfrastructureInfrastructure.Dto.NewDto  5      > :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews 5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      ,   &IMS.Views.AdminViews.ProcessConfigView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Oconvert;clr-namespace:Infrastructure.Common;assembly=Infrastructure     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Penum?clr-namespace:Infrastructure.Dto.NewDto;assembly=Infrastructure     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      .local"clr-namespace:IMS.Views.AdminViews  5	      _	 [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      [
 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 
  5      j fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf        5      <sys&clr-namespace:System;assembly=mscorlib        5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5      1   +Infrastructure.Common.ColorToBrushConverter   ColorToBrushConverter  StationEnum S? 
MethodName S? 
ObjectTypeU QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum S? MethodParameters M? Type+   %Infrastructure.Dto.NewDto.EnumStation??%?   &	        &	        5   
   6(   S? 5   
   $ 	GetValues??5      "  5       5      M? 5      "  6   5      5      .??5      ?  ? RowDefinitions 5    
   ?? 5!      $
??auto ?6   ?? 5"      .+?5&   
   ? $??1??6    ? ColumnDefinitions 5'      ?? 5(      $??3* ?6#   ?? 5)      $??7* ?6#   .+?5,      ?? $??2??5-      $??	10,10,0,0q?5.      
???????$??0q?50       ?? CornerRadius$ 5??51      ._?52      ?? 	 ?? Orientation$	 Vertical=?6   .+?53      ?? $??10q?6      PrimaryHueDarkBrush#???  6,   ?? 54      $	 
Horizontal=?6%   .+?55      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $??Right=?56   !   $??Center=?57   !   
   Kind$
 ChevronDoubleDown=?58   !   ?? 59      $??Center=?6(   $??产品型号/母件编码??6C   5:      5;      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  5<      -   5          Name$ 	_dataGrid??5=      (  "Syncfusion.UI.Xaml.Grid.SfGridBase   AllowEditing$ False??5>         AllowFiltering$ False??5?         AllowResizingColumns$ False??5@         AllowSorting$ False??5A         AutoGenerateColumns$ False??5B      
???????   
IsReadOnly$
 True??5D      !   NewItemPlaceholderPosition$ AtBeginning=?5F         SelectionMode$ Single=?5H        SimpleDataGridStyle#??[ 5I         ItemsSource 5E      ?? *ProductCode+   SelectedItem 5G      ?? *SelectedItem+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5K      +	  %Microsoft.Xaml.Behaviors.EventTrigger	  5L       	  	EventName$ SelectionChanged??6-   *
  $Microsoft.Xaml.Behaviors.TriggerBase 
  Actions. 5M   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   ?? *SelectedItemEventCommand+   CommandParameter 6e   ?? *SelectedItem+ ?? ElementName$ 	_dataGrid??5N         Columns 5S      0  *Syncfusion.UI.Xaml.Grid.GridTemplateColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ 是否配置工序??6<      
IsReadOnly$
 True??6P      CellTemplate 5T   "   ?? 5U   &   .R?5V   *     $??20??5W   -   $??20??5X   -   $??Center=?5Y   -   $
 
Attachment=?5[   -   ??5Z   -   ?? *isPrc+  ?? 	Converter#  [  ! ?? UpdateSourceTrigger$! PropertyChanged=?" ?? Mode$" TwoWay=?5[   -   5\   '   5^      ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  5_      $ 产品型号??5`   !   $
 True??5a   !   #   MappingName$# proCode??5b   !     5d      (  "Syncfusion.UI.Xaml.Grid.GridColumn$   AllowFiltering$$ False??5e   !   %   AllowSorting$% False??5f   !   $ 操作??5g   !    5i   "   ?? 5j   &   .R?5k   *   ?? $	 
Horizontal=?65   .+?5m   .   ?? $	??5,0q?5n   1   
???   ?   MaterialDesignFlatDarkButton#??[ 5r   1   & ? ToolTip$& 添加工序??5s   1   ??5o   1   ?? *#!DataContext.AddDealProductCommand+' ?? RelativeSource' ?? ( ?? Mode$( FindAncestor=?) ?? AncestorType) syncfusion:SfDataGrid??5p   1   ?? ??5u   2     5v   6   $??20??5w   9   $??20??5x   9   $
 PlaylistPlus=?5y   9   5{   /   ?? 5|   .   $	??5,0q?5}   1   
???  ??#??[ 5?   1   $& 删除产品??5?   1   ??5~   1   ?? *&$DataContext.DeleteDealProductCommand+' ?? $( FindAncestor=?) syncfusion:SfDataGrid??5   1   ?? ??5?   2     5?   6   $??20??5?   9   $??20??5?   9   $
 DeleteForever=?5?   9   5?   /   5?   +   5?   '   5?      5?      5?      5?      ? 5?      $??1??6    5?      ?? 5?      $
??auto ?6$   ?? 5?      $??* ?6$   .+?5?      ?? $??10q?5?      
???????$??0q?5?      $ 5??5?      ._?5?      ?? $	 
Horizontal=?6!   .+?5?      ?? $??10q?6$   #???  60   ?? 5?      $	 
Horizontal=?6)   .+?5?   "     $??Right=?5?   %   $??Center=?5?   %   $
 ChevronDoubleDown=?5?   %   ?? 5?   "   $??Center=?6,   $??产品工序配置??6G   5?      5?      ?? 5?      $??20,10q?6$   ??63   ?? *	ProInfo+* ?? StringFormat$#* 当前选中产品型号: {0}??5?      5?      ?? 5?      $??1??5?      $??	10,0,10,0q?5?      
???????$??0q?5?      $ 5??5?      ._?5?      ?? $	 Vertical=?6!   .+?5?      ?? $??10q?6$   #???  60   ?? 5?      $	 
Horizontal=?6)   .+?5?   "     $??Right=?5?   %   $??Center=?5?   %   $
 ChevronDoubleDown=?5?   %   ?? 5?   "   $??Center=?6,   $??产品工序??6G   5?      5?        5?      -   5        $ 
_dataGrid1??5?      $ False??5?      $
 True??5?      #??[ 5?       5?      ?? *Prc_Products+$! PropertyChanged=? 5?      ?? *Prc+ 5?   "     $ 工序名称??6<   $$ False??6N   $# NodeName??6e   0  *Syncfusion.UI.Xaml.Grid.GridCurrencyColumn  5?   "   +   CurrencyDecimalDigits$+ 0??5?   %   ,   CurrencySymbol$
, Prc_??5?   %   $ 工序ID??5?   %   $$ False??5?   %   '-    HorizontalHeaderContentAlignment$
- Left=?5?   %   $
# Node??5?   %     5?   "   $ 工序描述??6<   $$ False??6N   $# Description??6e     5?   "   $ 标准CT??6<   $$ False??6N   $# CT??6e     5?   "   $	 Sop??6<   $$ False??6M   $
# Esop??6d     5?   "   $ 创建用户??6<   $$ False??6N   $#  User_create??6e     5?   "   $$ False??5?   %   $% False??5?   %   $ 操作??5?   %    5?   &   ?? 5?   *   .R?5?   .   ?? $	 
Horizontal=?69   .+?5?   2   9  3Syncfusion.Windows.Tools.Controls.DropDownButtonAdv  .   Label$. 操作??6O     OperationButtonStyle#??[ 6Z   .??5?   6   ?? $	 Vertical=?6A   .+?5?   :   ?? $??5q?5?   =   $??3q?5?   =   
?????? $??0q?5?   =   $??编辑??5?   =   
?????????5?   =   ?? *$"DataContext.EditDealProcessCommand+' ?? $( FindAncestor=?) syncfusion:SfDataGrid??5?   =   ?? 5?   =   ?? 5?   :   $??5q?5?   =   $??3q?5?   =   
?????? $??0q?5?   =   $??删除??5?   =   
?????????5?   =   ?? *&$DataContext.DeleteDealProcessCommand+' ?? $( FindAncestor=?) syncfusion:SfDataGrid??5?   =   ?? 5?   =   5?   7   5?   3   5?   /   5?   +   5?   #   5?      5     5     5     5	     5     5     