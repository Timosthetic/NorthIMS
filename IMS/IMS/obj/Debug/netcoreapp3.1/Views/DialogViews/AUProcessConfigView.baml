   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:IMS.Views.DialogViewsIMS.Views.DialogViews  5      I EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]?clr-namespace:Infrastructure.Dto.NewDto;assembly=InfrastructureInfrastructure.Dto.NewDto 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      /    )IMS.Views.DialogViews.AUProcessConfigView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:IMS.Views.DialogViews     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5	      Lenum?clr-namespace:Infrastructure.Dto.NewDto;assembly=Infrastructure 	 
 5      2sys&clr-namespace:System;assembly=mscorlib 	 
 5      $	??650??5
      $	??400??5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5         StationEnum S? 
MethodName S? 
ObjectTypeU QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum S? MethodParameters M? Type+  %Infrastructure.Dto.NewDto.EnumStation  
_textblock ?? 
TargetType   MaterialDesignBody1TextBlock ?? BasedOn ?? Property	 ?? Value  _textbox % !MaterialDesignFloatingHintTextBox??%}  &	        &	 c     7  &	     7  S? 5   
   $ 	GetValues??5      "  5       5      M? 5      "  6   5      ?? 5   
   " ??6#   8   .?5      ??  ? ??$	 Center=?64   ?? 5       ? ??$	 Center=?62   ?? 5       ? ??$	 0 20 0 0q?6'   5      ?? 5    
   " ??6!   8   .?5!      ??  ? ??$	 Bottom=?69   5"      5#      .??5$      ? ???#F1F1F1
 ? RowDefinitions
 5%   
   ?? 5&      $??40 ?6   ?? 5'      ?? 5(      $??60 ?6   .+?5*   
   '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ LoginSnakeBar??5+      $??2??5,      $??Center=?5-      $??Bottom=?5.       K? ZIndex$ 1??5/         MessageQueue 50      ?? *BoundMessageQueue+]? 52   
     PrimaryHueDarkBrush#???  6   .+?53      ?? $
??Left=?6    ?? Orientation$ 
Horizontal=?6/   .+?54      ?? $
??20,0q?55      $??Center=?56      $??15(?57         PrimaryHueMidForegroundBrush#???  58      $??工序配置??59      ?? 5:      5;      ?? 5<      $??Right=?5=      #???  5>      $??0q?5?      #???  5A       # MaterialDesignFlatLightBgButton#??[ 5B      ??5@      ?? *CancelCommand+.??5C      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?6*   5D      5E      ? 5F   
   $??1??6   .+?5I      ?? $??10 20 10 10 q?6   .+?5J      A?  A? Columns$ 4??6#    A? Rows$ 2??6/   .+?5K      ?? $??工序名称??6$   #??[ 60   ?? 5L      #??[ 6o   ??6   ?? *Pross.NodeName+ ?? UpdateSourceTrigger$ PropertyChanged=? ?? Mode$ TwoWay=?6o   ?? 5M      $??工序代码??6$   #??[ 60   ?? 5N       ?? 
IsReadOnly$
 True??6:   #??[ 6M   ??6   ?? *
Pross.Node+6M   ?? 5O      $??标准CT??6$   #??[ 60   ?? 5P      #??[ 68   ??6   ?? *
Pross.CT+68   ?? 5Q      $??
min/分钟??6$   $
??Left=?62   $??Bottom=?6N   5R      ? 5S       ? ColumnDefinitions 5T      ?? 5U      $
??2.5* ?6/   ?? 5V      $
??7.5* ?6/   ?? 5W      $
??auto ?6/   
 5Y      ?? 5Z      ?? 5[      ?? 5\      .+?5^      ?? $??工序描述??6$   #??[ 60   ?? 5_      $??2??6   $??1??62    ?? TextWrapping$
 Wrap=?6B   #??[ 6y   ??6V   ?? *Pross.Description+6y   ?? 5`      $??1??6$   $	??SOP??61   #??[ 6<   ?? 5a      $??1??6   $??1??6+   #??[ 6?   ??6;   ?? *
Pross.Esop+$ PropertyChanged=?$ TwoWay=?6?   ?? 5b      $??1??6G   $??2??6T   $??获取SOP路径??6d   ??6!   ?? *GetSopFileCommand+6d   ?? 5c      $??组装工位??6$   $??2??60   #??[ 6=   ?? 5d      $??2??6   $??1??6,   $??2??6<   ??6P   ??  ?? Source# [   ?? SelectedValue 6?   ?? *Pross.Station+5e      5g      5k      ? 5m   
   $??2??6    5n      ?? 5o      ?? 5p      .+?5r      ?? $??Center=?5s      $?? ??5t      $??20(?5u      #??[ 5v      ]? 5w      $??1??6   .+?5x      ?? $??	20,0,20,0q?5y        PrimaryHueMidBrush#???  5z      $??0q?5{       ? Cursor$
 Hand??5}      $??Right=?5~      #???  5      ??5|      ?? *SaveCommand+.??5?      ?? $ 
Horizontal=?6!   .+?5?        $ ContentSave=?62   ?? 5?      $	??5,0q?6$   $??保存??61   5?      5?      ?? 5?      $??Right=?5?      ???#F1F1F1$??0q?5?      $??关闭??5?      
???   ???5?      ?? *CancelCommand+5?      5?      5?      5?      5?      