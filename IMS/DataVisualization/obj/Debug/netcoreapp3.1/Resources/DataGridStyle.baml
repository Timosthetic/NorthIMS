   M S B A M L   `   `   `  ????L  HDataVisualization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DataVisualizationDataVisualization  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DataGridRow.Height  DataGrid.BorderThickness  u? Bottom u? Left u? Right
 u? Top   ColumnHeader.BorderThickness  DataGridRow.BorderThickness  DataGrid.BorderBrush ?? Color  ColumnHeader.Background  ColumnHeader.BorderBrush  DataGridRow.BorderBrush ! DataGridRow.Normal.Background !	 DataGridRow.Normal.Foreground $
  DataGridRow.MouseOver.Background $  DataGridRow.MouseOver.Foreground # DataGridRow.Selected.Background # DataGridRow.Selected.Foreground&    System.Windows.Controls.DataGrid ?? 
TargetType ?? Property ?? Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType	 ??Name
 J? SnapsToDevicePixels ? UseLayoutRounding)  #System.Windows.Controls.DataGridRow?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid ? ColumnDefinitions ? RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical ?? ConverterParameter#    RowDetailsScrollingConverter ?? 	Converter ?? RelativeSource ?? AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row!    HeadersVisibilityConverter ?? Triggers P? Property P? Value*	  $System.Windows.Controls.DataGridCell ?? Triggers?? 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:DataVisualization  5      .sys&clr-namespace:System;assembly=mscorlib  5      %  &	        &	      &	 l     &	 ?     &	     &	 1    &	 R    &	 s    &	 ?    &		 ?    &	
 ?    &	 ?    &	     &	 9    '   Z    7  7  7  7   '  l    7  7  '  ?    7  7  7  7  7   7  7 
 7  7  '	  ?    X?5      33Q?60   u? 5
      $  1Q?5   	   $ 1Q?5   	   $ 1Q?5   	   $ 1Q?5   	   u? 5      $  0Q?5   	   $ 0Q?5   	   $ 1Q?5   	   $ 0Q?5   	   u? 5      $  0Q?5   	   $ 0Q?5   	   $ 0Q?5   	   $ 1Q?5   	   ?? 5       $ #E9ECF1??63   ?? 5"      $ #F6F7FB??66   ?? 5$      $ #E9ECF1??67   ?? 5&      $ #E9ECF1??66   ?? 5(      $ #FFFFFF??6<   ?? 5*      $ #000000??6<   ?? 5,      $ #F6F7FB??6?   ?? 5.      $ #000000??6?   ?? 50      $ #F6F7FB??6>   ?? 52      $ #000000??6>   ?? 54      "   6   .?56   
   ??  ?@  RowHeaderWidth$ 0Q?6+   ?? 57   
    ? ??8   6,   ?? 58   
    ?@  HeadersVisibility$ Column=?6.   ?? 59   
    ? ??8  6'   ?? 5:   
    ? ??8  6(   ?? 5;   
     ?@  HorizontalGridLinesBrush ?	#00E9ECF165   ?? 5<   
    ?@  VerticalGridLinesBrush ?	#00E9ECF163   ?? 5=   
    ?@?UseLayoutRounding$
 True??6.   ?? 5>   
    ?@J?SnapsToDevicePixels$
 True??60   ?? 5?   
    ?@  AutoGenerateColumns$ False??60   ?? 5@   
    ?@  CanUserAddRows$ False??6+   ?? 5A   
    ?@  CanUserReorderColumns$ False??62   ?? 5B   
    ?@  CanUserResizeColumns$ False??61   ?? 5C   
    ?@  CanUserResizeRows$ False??6.   ?? 5D   
    ?@  CanUserSortColumns$ False??6/   ?? 5E   
    ?@  GridLinesVisibility$
 None=?60   ?? 5F   
    ?@  
IsReadOnly$
 True??6'   ?? 5G   
    ?@  	RowHeight8  6&   ?? 5H   
    ?@  SelectionMode$ Single=?6*   5I      ?? 5K      "  6   .?5L   
   ??  ?@J?SnapsToDevicePixels$
 True??60   ?? 5M   
    ? ?? ?#0000006'   ?? 5N   
    ? ??$ 12(?6%   ?? 5O   
    ?@?Cursor$
 Hand??6#   ?? 5P   
    ? ??$ 28??6#   ?? 5Q   
    ? ?? 5R      ?? 5S      "  6"   .R?5T      ?? $	 BackgroundBorder??5U      $
??Auto??5V      $
??-1,0q?5W      8??  8?? $

 True??5Z      $
 True??5[      ._?5\      ?? $	??5,0q?5]      $??Center=?5^      $??Center=?5_      5`      5a      5c      5d      ?? 5f      "  6   .?5g   
   ??  ? ??8   6'   ?? 5h   
    ? ??8  6'   ?? 5i   
    ?@J?SnapsToDevicePixels$
 true??60   ?? 5j   
    ?@?UseLayoutRounding$
 True??6.   ?? 5k   
    ?@=?ErrorTemplate 65   Z? ?? 5l   
    ? ??8  6,   ?? 5m   
    ? ??8  6(   ?? 5n   
    ?@ ValidationErrorTemplate 5o      ?? 5p      .R?5q      ?? $??0,0,0,0q?5r      $??Center=?5s      
???  ??$??!??5u      5v      5x      ?? 5y   
    ? ?? 5z      ?? 5{      "  6"   .R?5|      ?? $	 
DGR_Border??5}      $??0,0,0,-1q?5~      #??z??5      #??z??5?      #??z??5?      $

 True??5?      $
 True??5?      ._?5?         5?      ?? 5?   "   $
??Auto ?63   ?? 5?   "   $??* ?63    5?      ?? 5?   "   $??* ?60   8?? 6;   ?? 5?   "   $
??Auto ?60   .+?5?        $??1??5?   !   #??z 5?   !   #
 z
 5?   !     5?      $??1??5?   !   $??1??5?   !   #y?z 5?   !    5?   !   ?? *AreRowDetailsFrozen+# Z # Z  ?? "   5?   !     5?      $??2??5?   !   $ Vertical=?5?   !   y?5?   !   ?? *HeadersVisibility+# Z # Z  ?? "   5?      5?       5?      P? 5?       ?@J?IsMouseOver$
 True??69   . ?5?      ?? 8   ? ??6;   ?? 5?      8   ? ??6;   5?      P? 5?       ?@ 
IsSelected$
 True??68   . ?5?      ?? 8   ? ??6;   ?? 5?      8   ? ??6;   5?      5?      5?      5?      ?? 5?      " 	 6   .?5?   
   ??  ? ?? 5?      ?? 5?      " 	 6"   .R?5?      ?? $	 Bg??5?      
?????? $
 True??5?      ._?5?      ?? $??Center=?6+   $??Center=?6H   5?      5?      5?       5?   
   P? 5?       ?@	 
IsSelected$
 True??6,   . ?5?      ??  ? ??
 ???? 6/   ?? 5?       ? ?? ?#0000006/   5?      5?      5?      