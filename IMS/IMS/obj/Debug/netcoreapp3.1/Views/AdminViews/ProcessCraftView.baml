   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IMS.Views.AdminViewsIMS.Views.AdminViews  5      +    %IMS.Views.AdminViews.ProcessCraftView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      .local"clr-namespace:IMS.Views.AdminViews  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5
      j
 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfGridConverter.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf 
       5      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5         HeaderTemplate ?? Mode  ContentTemplate(  "Syncfusion.UI.Xaml.Grid.SfDataGrid  Name   AllowFiltering(  "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns   
IsReadOnly  SimpleDataGridStyle   ItemsSource ?? UpdateSourceTrigger	   Columns,  &Syncfusion.UI.Xaml.Grid.GridTextColumn,  &Syncfusion.UI.Xaml.Grid.GridColumnBase
   
HeaderText   MappingName0  *Syncfusion.UI.Xaml.Grid.GridTemplateColumn(  "Syncfusion.UI.Xaml.Grid.GridColumn   AllowFiltering   AllowSorting   CellTemplate ?? Orientation9  3Syncfusion.Windows.Tools.Controls.DropDownButtonAdv   Label  OperationButtonStyle ?? RelativeSource ?? Mode ?? AncestorType  EditHeaderTemplate  TabListContentTemplate??%?  &	        &	 P     7  7  &	 
    &	 Z    ?? 5   
   .R?5      ?? ??6   ?? *
NodeName+$ TwoWay=?5      ?? 5   
   .R?5        $ 
_dataGrid1??5      $ False??5      $ False??5      $
 True??5      8??   5      ?? *StanardList+$ PropertyChanged=?$ TwoWay=?	 5        $
 物料编码??60   $ 	 Materiel??6B     5      $
 物料类型??60   $ 	 MtiClass??6B     5      $
 物料名称??60   $  MtiName??6B     5       $
 工序齐套??60   $  Atprule??6B     5!      $ False??5"      $ False??5#      $
 操作??5$       5&      ?? 5'      .R?5(   "   ?? $ 
Horizontal=?6-   .+?5)   &     $ 操作??6C   8?? .??5*   *   ?? $ Vertical=?65   .+?5+   .   ?? $??5q?5,   1   $??3q?5-   1   
?????? $??0q?5/   1   $??编辑??52   1   
?????????50   1   ?? *" DataContext.EditDealCraftCommand+ ?? $ FindAncestor=? syncfusion:SfDataGrid??51   1   ?? 53   1   ?? 54   .   $??5q?55   1   $??3q?56   1   
?????? $??0q?58   1   $??删除??5;   1   
?????????59   1   ?? *$"DataContext.DeleteDealCraftCommand+ ?? $ FindAncestor=? syncfusion:SfDataGrid??5:   1   ?? 5<   1   5=   +   5>   '   5@   #   5A      5C      5F      5G      ?? 5H   
   .R?5I      ?? ??6   ?? *
NodeName+$ TwoWay=?5J      ?? 5K   
   .R?5L      ?? ??6   ?? *
NodeName+5M      5N      .??5P      ?  ? RowDefinitions 5Q   
   ?? 5R      $
??auto ?6   ?? 5S      .+?5a   
   ? $??1??6    ? ColumnDefinitions 5b      ?? 5c      $??2* ?6#   ?? 5d      $??8* ?6#   .+?5g      ?? $??2??5h      $??	10,10,0,0q?5i      
???????$??0q?5k       ?? CornerRadius$ 5??5l      ._?5m      ?? $ Vertical=?6   .+?5n      ?? $??10q?6      PrimaryHueDarkBrush#???  6,   ?? 5o      $ 
Horizontal=?6%   .+?5p      '	  !MaterialDesignThemes.Wpf.PackIcon	  $??Right=?5q   !   $??Center=?5r   !    	  Kind$ ChevronDoubleDown=?5s   !   ?? 5t      $??Center=?6(   $??选择产品型号??6C   5u      5v      ?? 5w      $ Vertical=?6!   .+?5y      3
  -Syncfusion.Windows.Tools.Controls.ComboBoxAdv
  -   5         
 Name$ 	_ComBoBox??5z      $??35??5{      $
??20,0q?5|       
  AllowMultiSelect$ False??5}       
  AutoCompleteMode$ Suggest=?5~      
???????$??0,0,1,0q?5?       
  EnableToken$
 True??5?       
  
IsEditable$
 True??5?      ??5?      ?? *	Product+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5?      +  %Microsoft.Xaml.Behaviors.EventTrigger  5?   "      	EventName$ SelectionChanged??61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5?   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction      Command  6<   ?? *SelectedProItemCommand+!   CommandParameter! 6g   ?? *SelectedItem+" ?? ElementName$" 	_ComBoBox??5?   #   5?      ?? 5?      $??15q?6$   #???  60   ?? 5?      $ 
Horizontal=?6)   .+?5?   "   	  $??Right=?5?   %   $??Center=?5?   %   $ ChevronDoubleDown=?5?   %   ?? 5?   "   $??Center=?6,   $??产品工序??6G   5?      5?        5?      -   5        $ peocess??5?      $ False??5?      #??[ 5?       5?      ?? *Prcess+ 5?        5?   "   $ SelectionChanged??61   . 5?   &       6<   ?? *SelectedPrcItemCommand+! 6g   ?? *SelectedItem+$" peocess??5?   #   	 5?   "     $ False??5?   %   $
 工序名称??5?   %   $ NodeName??5?   %     5?   "   $ False??5?   %   $
 工位??5?   %   $ Station??5?   %   5?      5?      5?      5?      ? 5?      $??1??6    5?      ?? 5?      $
??auto ?6$   ?? 5?      $??4* ?6$   ?? 5?      $??6* ?6$   .+?5?      ?? $??10q?5?      
???????$??0q?5?      $ 5??5?      ._?5?      ?? $??10q?6    #???  6,   ?? 5?      $ 
Horizontal=?6%   .+?5?      	  $??Right=?5?   !   $??Center=?5?   !   $ ChevronDoubleDown=?5?   !   ?? 5?      $??Center=?6(   $??产品工艺配置??6C   5?      5?      5?      ?? 5?      $??1??5?      $
??10,0q?5?      
???????$??0q?5?      $ 5??5?      ._?5?      ?  5?      ?? 5?      $
??auto ?6,   ?? 5?      $??* ?6,   ?? 5?      $
??auto ?6,   .+?5?      ?? $??10q?6$   #???  60   ?? 5?      $ 
Horizontal=?6)   .+?5?   "   	  $??Right=?5?   %   $??Center=?5?   %   $ ChevronDoubleDown=?5?   %   ?? 5?   "   $??Center=?6,   $??产品齐套??6G   5?      5?        5?      -   5        $ carftDatagrid??5?      $??1??5?      $ False??5?      #??[ 5?       5?      ?? *Pro_CompleteSets+	 5?   "     $
 物料编码??6<   $ mal_code??6N     5?   "   $
 物料类型??6<   $ mal_type??6N     5?   "   $
 物料名称??6<   $ 	 mal_name??6N     5?   "   $
 物料标识??6<   $ 	 mal_flag??6N     5?   "   $ False??5?   %   $
 剩余齐套数量??5?   %   $ mal_lastnum??5?   %     5?   "   $ False??5?   %   $
 产品齐套??5?   %   $  mal_num??5?   %     5?   "   $ False??5?   %   $ False??5?   %   $
 操作??5?   %    5?   &   ?? 5?   *   .R?5?   .   ?? $ 
Horizontal=?69   .+?5?   2   ?? $	??5,0q?5?   5   #???  5?   5      MaterialDesignFlatDarkButton#??[ 5?   5   ??5?   5   ?? *DataContext. AddCraftCommand+ ??  syncfusion:SfDataGrid??5?   5   ?? {?5?   5   ?? *DataContext.IsEnable+ ??  syncfusion:SfDataGrid??5?   6   	  5?   :   $??20??5   =   $??20??5  =   $ ArchiveArrowDownOutline=?5  =   5  3   5  /   5  +   5  #   5
     5     5     ?? 5     $??2??5     $??
10,10,10,0q?5     
???????$??0q?5     $ 5??5     ._?5     5  /Syncfusion.Windows.Tools.Controls.TabControlExt  -   5        #  Name$# _tabcontrol??5     $??10q?5     ! 	 Prism.Regions.RegionManager$   
RegionName$$ PersonDetailsRegion??5     %   AllowDragDrop$% False??5     $??0q?5     &   CloseButtonType$& 
Individual=?5     '   EnableLabelEdit$' False??5     ??5      Z?  5"     2  ,Syncfusion.Windows.Tools.Controls.TabItemExt( ?? 
TargetType) ?? Property* ?? Value??%{   '        ?? 5#     "(  6$   .?5$  "   ?? ) ? ??* 6;   ?? *&$DataContext.SelectedProcess.NodeName+5&     5'     5(     5+     5,     5/     53     54     