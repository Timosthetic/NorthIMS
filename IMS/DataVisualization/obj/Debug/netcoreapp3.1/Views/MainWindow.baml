   M S B A M L   `   `   `  ????b  ^Syncfusion.SfChart.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts  5      I EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU;clr-namespace:Infrastructure.Common;assembly=InfrastructureInfrastructure.Common 5      L HDataVisualization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DataVisualization.ConverterDataVisualization.Converter 5      (   "DataVisualization.Views.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      YchartGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5      Oconvert;clr-namespace:Infrastructure.Common;assembly=Infrastructure     5      ;local)clr-namespace:DataVisualization.Converter     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      a
 ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89:
syncfusion!http://schemas.syncfusion.com/wpf   
    5	      -   5        $
??3840??5      $
??2160??5      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? Title 5
      ?? *Title+ ? 	Resources 5       ?? MergedDictionaries ?? Source8  2DataVisualization.Converter.PieChartColorConverter   	colorConv  HanziCharacterFontFamily. 
 (Syncfusion.UI.Xaml.Grid.HeaderRowControl ?? 
TargetType ?? Property ?? Value1  +Infrastructure.Common.ColorToBrushConverter  ColorToBrushConverter  DefaultHeaderStyle3 
 -Syncfusion.UI.Xaml.Grid.GridHeaderCellControl  DefaultGeicell& 
  Syncfusion.UI.Xaml.Grid.GridCell  	textblock?? 5   
    5      ?? 5      $" ../Resources/ColorModel.xaml??6%   ?? 5      $% ../Resources/DataGridStyle.xaml??6%   %?  &	        &	      '  E     &	 ?     &	 ?     &	 ?     &	 :      5      6+   *?5      ../Assets/微软雅黑.ttf)?6N   ?? 5      "  6   .?5      ??  ? ?? ?#00163E6/   5        5      6,   ?? 5       "  6/   .?5#      ??  ? ??$ 30(?6-   5%      ?? 5&      "  6+   .?5'      ??  ? ??$ Center=?68   5(      ?? 5*      " ??6&   .?5+      ??  ? ??$ 5q?6+   5,      5-      .??51      (?  (? Stretch$
 Fill=?6   .??52   
   ? ???#030035	 ? ColumnDefinitions	 53      ?? 54      $
??2304 ?6#   ?? 55      $
??1536 ?6#   
 ? RowDefinitions
 57      ?? 58      $	??324 ?6    ?? 59      $	??864 ?6    ?? 5:      $	??864 ?6    .+?5=      ?? $??3??5>      $??10q?5?      ???#110C42$??0q?5A       ?? CornerRadius$ 10??5B      ._?5C      ? 	 5D      ?? 5E      $??2* ?6+   ?? 5F      $??6* ?6+   ?? 5G      $??2* ?6+   .+?5J      (? $??1??6   $
 Fill=?6.   .??5K      ?? $??1??5L      $??15q?5M      $??Center=?5N      $??Center=?5O      #??[ 5P      $??40(?5Q      $
??Bold"?5R      
?????????5T      ?? *
LineName+ ?? UpdateSourceTrigger$ PropertyChanged=?5U      (? 5V      $??2??6   $
 Fill=?6.   .??5W      ?? $??2??5X      $??20q?5Y      $??Right=?5Z      $??Center=?5[      #??[ 5\      $??20(?5]      
?????????5_      ?? *Time+5`      5a      5c      ?? 5f      $??1??5g      $??10q?5h      ???#2D2F58
???????$??1q?5k      $ 	10 10 0 0??5l      ._?5m      ? 
 5n      ?? 5o      $
??auto ?6(   ?? 5p      $??* ?6(   .+?5s      ?? $??10q?5t      $??Center=?5u      $??Center=?5v      $??Microsoft YaHei Bold)?5w      $??40(?5x      
???????$??生产详情表??5z      ( 
 "Syncfusion.UI.Xaml.Grid.SfDataGrid  5|      $??1??5}      ( 
 "Syncfusion.UI.Xaml.Grid.SfGridBase   AllowSorting$ False??5~         AutoGenerateColumns$ False??5      ???#05034C$??1q?5?         ColumnSizer$
 Star=?5?      $??30(?5?      
???????   HeaderRowHeight$	 100Q?5?         HeaderStyle# [ 5?         
IsReadOnly$
 True??5?      !   NewItemPlaceholderPosition$ AtBeginning=?5?         	RowHeight$ 73Q?5?         RowSelectionBrush ?#0A3F83$??Hidden=?5?         SelectionMode$ Multiple=?5?         ItemsSource 5?      ?? *
WorkOrders+   Columns 5?      ,	 
 &Syncfusion.UI.Xaml.Grid.GridTextColumn	  ,
 
 &Syncfusion.UI.Xaml.Grid.GridColumnBase 
  
HeaderText$ 项目代号??68    
  MappingName$ 	项目号??6J   	  5?      $ 	任务号??68   $ 	工单号??6I   	  5?      $ 名称??68   $  产成品名称??6H   	  5?      $ 图号??68   $  图号??6H   	  5?      $ 完工/工单数量??68   $ Produktionsmenge??6M   0 
 *Syncfusion.UI.Xaml.Grid.GridDateTimeColumn  5?      $ 计划完工日期??6<   $  计划完工日期??6P   	  5?      $ 实际完工日期??68   $ 实际完工日期??6L   	  5?      $ 工单状态??68   $ 工单状态??6J   	  5?      $ 工位利用率??68   $ 工位利用率??6K   5?      5?      5?      (? 5?      $??2??6   $
 Fill=?6#   .??5?      ?? ???#03034D??64   ?? *StaffLogins+$ PropertyChanged=? ?? Mode$ TwoWay=???5?      ?? 5?      .R?5?      A?  A? Columns$ 6??6*    A? Rows$ 2??66   5?      ??5?      ?? 5?      .R?5?      (? $??10q?6&   $
 Fill=?62   .??5?   "   ?? $??0q?6)   ._?5?   &   ? 
 5?   *   ?? 5?   .   $
??auto ?6<   ?? 5?   .   $??* ?6<   ?? 5?   .   $
??auto ?6<   .+?5?   *   ?? ???#2E2A58._?5?   .   ? 	 5?   2   ?? 5?   6   ?? 5?   6   .+?5?   2   ?? $??20??5?   5   $	??2,2q?5?   5   $??0q?5?   5   $ 5??5?   5   ??5?   5   ?? *	IsLogin+ ?? 	Converter# [ $ PropertyChanged=?$ TwoWay=?._?5?   6   ?? $??Center=?5?   9   $??Center=?5?   9   ??5?   9   ?? *
Loginstr+5?   3   ?? 5?   2   $??1??5?   5   $??Center=?5?   5   $??Center=?5?   5   
??? ?????5?   5   ?? *STName+5?   /   5?   +   ? 5?   *   $??1??6/   $??3??6<   .+?5?   .   A? $ 2??6:   $ 5??6F   .+?5?   2   ?? ???#00163E
???????$	??0.5q?5?   5   ._?5?   6   ?? ???#808080#??[ 5?   9   $??名称??5?   9   5?   3   ?? 5?   2   ???#00163E
???????$??0,0.5,0.5,0.5q?5?   5   ._?5?   6   ?? ???#808080#??[ 5?   9   $??属性??5?   9   5?   3   ?? 5?   2   
???????$??0.5,0,0.5,0q?6M   ._?5?   6   ?? 
???????#??[ 5?   9   $??工序名称??5?   9   5?   3   ?? 5?   2   
???????$??	0,0,0.5,0q?6M   ._?5?   6   ?? 
???????#??[ 5?   9   ??5?   9   ?? *ProcessName+$ PropertyChanged=?$ TwoWay=?5?   3   ?? 5?   2   
???????$	??0.5q?6M   ._?5?   6   ?? 
???????#??[ 5?   9   $??工序状态??5?   9   5?   3   ?? 5?   2   
???????$??0,0.5,0.5,0.5q?6M   ._?5?   6   ?? 
???????#??[ 5?   9   ??5?   9   ?? *	procstr+5?   3   ?? 5?   2   
???????$??0.5,0q?6M   ._?5?   6   ?? 
???????#??[ 5  9   $??姓名??5  9   5  3   ?? 5  2   
???????$??	0,0,0.5,0q?6M   ._?5  6   ?? 
???????#??[ 5  9   ??5  9   ?? *	StaffName+5	  3   ?? 5  2   
???????$	??0.5q?6M   ._?5  6   ?? 
???????#??[ 5  9   $??产名??5  9   5  3   ?? 5  2   
???????$??0,0.5,0.5,0.5q?6M   ._?5  6   ?? 
???????#??[ 5  9   ??5  9   ?? *ProductName+5  3   5  /   5  +   ?? 5  *   $??2??5  -   $??30??5  -   
??? ?|?$??0q?5  -   $ 3??5   -   ._?5!  .   ?? $??Center=?5"  1   $??Center=?5#  1   ??5$  1   ?? *
Efficiency+ ?? StringFormat$ 装配时长{0}min??5%  +   5&  '   5(  #   5)     5*     5,     5-     (? 5.     $??1??5/     $??1 ??50     $??10q?51     $ UniformToFill=?52     .??53     ?? $??1??54     $??1??55     ???#05034C$??0q?57     $ 10??58     ._?59     ?? -   5          ??Name$  contentcontrol??59  %   .??5:     ?  5;     8  2DataVisualization.Converter.PieChartLabelConverter  labelconverter 
 legend! ?? Orientation  labelTemplate??%?  &	        &	      &	 &     &	 "    7   7    5<  "   6?     5=  "   6?   ?? 5?  "   .R?5@  &   ?? $! 
Horizontal=?61   .+?5A  *   ? $??10,5,0,0q?6/   	 5B  .   ?? 5C  2   ?? 5D  2   .+?5F  .   ?? ??68   ?? *
Interior+?? 5G  .   $??1??68   ??6H   ?? *Item+5H  +   5I  '   5J  #   ?? 5L  "   .R?5M  &   ? .+?5N  *   ?? 
???????$??1??5Q  -   ??5O  -   ?? 8   5Q  -   ?? 5R  *   
?????????6G   ?? 8  5S  '   5T  #   5V     .+?5X     '   !Syncfusion.UI.Xaml.Charts.SfChart  -   5        "  Name$" chart??5Y  !   $??2??5Z  !   $??10q?5[  !   $??Center=?5\  !   
???????)   #Syncfusion.UI.Xaml.Charts.ChartBase#   Header$# 生产状态??5^  !   $   	Behaviors$ 5b  &   6   0Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior  %   EnableSegmentSelection$
% True??6C   &   Legend& 5e  "   +   %Syncfusion.UI.Xaml.Charts.ChartLegend  5f  &   '   DockPosition$' Right=?68   (   
ItemMargin$( 0,8,0,0q?6M   )   Series.) 5i  "   .   (Syncfusion.UI.Xaml.Charts.DoughnutSeries  -   5        *  Name$* doughnutSeries??5j  %    	 CustomColor/   )Syncfusion.UI.Xaml.Charts.ChartSeriesBase+   
ColorModel#+ [	 5k  %   2   ,Syncfusion.UI.Xaml.Charts.CircularSeriesBase,   EnableSmartLabels$
, True??5l  %   -   ExplodeRadius$- 0Q?5m  %   .   LabelPosition$. OutsideExtended=?5o  %   /   ListenPropertyChange$
/ True??5p  %   0   Palette$0 Custom=?5q  %   1   XBindingPath$1 Category??5r  %   6   0Syncfusion.UI.Xaml.Charts.AccumulationSeriesBase2   YBindingPath$2 
Percentage??5s  %   3   ItemsSource3 5n  %   ?? *Tax+4   
CenterView4 5t  &   ?? 5u  *   .??5v  .   ?? $??Center=?69   $??Center=?6V   .+?5w  2   ?? $??Center=?5x  5   $??	Helvetica)?5y  5   $??12(?5z  5   $
??Bold"?5{  5   
???????5 ?? TextAlignment$5 Center=?5~  5   $
??Wrap=?5  5   ??5}  5   ?? *ProductName+$ TwoWay=?5  5   5?  /   5?  +   /   )Syncfusion.UI.Xaml.Charts.AdornmentSeries6   AdornmentsInfo6 5?  &   2   ,Syncfusion.UI.Xaml.Charts.ChartAdornmentInfo  5?  *   6   0Syncfusion.UI.Xaml.Charts.ChartAdornmentInfoBase7   HorizontalAlignment$7 Center=?5?  -   8   VerticalAlignment$8 Center=?5?  -   9   AdornmentsPosition$9 Bottom=?5?  -   :   ConnectorHeight$: 20Q?5?  -   ;   LabelTemplate#; [ 5?  -   <   SegmentLabelContent$< LabelContentPath=?5?  -   =   ShowConnectorLine$
= True??5?  -   >   	ShowLabel$
> True??5?  -   ?   UseSeriesPalette$
? True??5?  -   5?  #   5?     5?     5?     5?     5?     (? 5?     $??2??5?     $??1 ??5?     $??10,10,10,25q?5?     $
 Fill=?5?     .??5?     ?? $??2??5?     $??1??5?     ???#05034C$??0q?5?     $ 10??5?     ._?5?       $??10q?5?     @   
ColorModel#@ [	 5?     
???????$# 装配时长统计??5?     A   Palette$A Custom=?5?     & 5?       5?     $' Bottom=?65   B   PrimaryAxisB 5?     ,   &Syncfusion.UI.Xaml.Charts.CategoryAxis  5?     )   #Syncfusion.UI.Xaml.Charts.ChartAxisC   Header$C 工位??66   D   ShowGridLines$D False??6B   E   SecondaryAxisE 5?     -   'Syncfusion.UI.Xaml.Charts.NumericalAxis  5?     $C 分钟(min)??67   F   RangePadding$F Round=?6H   .) 5?     4   .Syncfusion.UI.Xaml.Charts.StackingColumnSeries  G   EnableAnimation$
G True??5?     
???????H   Label$H 装配工时??5?     $1 STName??5?     ,   &Syncfusion.UI.Xaml.Charts.XyDataSeriesI   YBindingPath$I Processing_Hours??5?     3 5?     ?? *KanbanWorkingHours+$ PropertyChanged=?6 5?       5?  "   J   LabelPosition$J Inner=?6@   $
> True??6V   5?       5?     $
G True??5?     
???????$H 等待工时??5?     $1 STName??5?     $I 
Wait_Hours??5?     3 5?     ?? *KanbanWorkingHours+$ PropertyChanged=?6 5?       5?  "   K   
Foreground
K ?????$J Inner=?5?  %   $
> True??5?  %   5?     5?     5?     5?     5?     5?     5?     