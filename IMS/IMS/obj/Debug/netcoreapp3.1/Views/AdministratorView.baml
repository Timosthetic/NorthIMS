   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:IMS.Views	IMS.Views  5      !    IMS.Views.AdministratorView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:IMS.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	      * 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded??6   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   ?? *LoginLoadingCommand+5       ? 	Resources 5         NavigateMenu ?? Source ?? GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName  btn1  
FlatButton	 ?? BasedOn
 ?? 
TargetType ?? Property ?? Value ?? Triggers P? Property P? Value??%H  &	        &	 b     7  ?? 5   
    64   ?? *	leftMenus+ 5        5      $ RootNode??6+   5      ?? 5   
   8	   "
 d?5!      .?5"      ??  ? ?? ?#3038436+   ?? 5#       ? ??$ 0q?60   ?? 5$       ? ??
 ?????6+   ?? 5%       ? ?? 6(   ?? *OpenMenuCommand+?? 5&       ? ??$ 0,0,15,0q?6'    5'      P? 5(       ?@d?	IsChecked$
 TrueY?6/   . ?5)      ??  ? ??$ C??69   5*      P? 5+       ?@d?	IsChecked$ FalseY?6/   . ?5,      ??  ? ??$ O??69   5-      50      51      .??52      ?  ? ColumnDefinitions 53   
   ?? 54      ??6   ?? *With+?? 55      $??8* ?6   .+?57   
   >? .??59      ?? -   5         ??Name$ _listOfMenuItem??59   @   $??0q?6   ???#303843 ?? SelectedIndex$ 0??6Z   ??6l   ??  ?? Source# [   5:        5;      $ SelectionChanged??6%   . 5<      -  'Prism.Interactivity.InvokeCommandAction     Command 65   ?? *NavigationRegionCommand+   CommandParameter 6b   ?? *SelectedItem+ ?? ElementName$ _listOfMenuItem??5=      ??5?      ?? 5@      .R?5A      ??  ?? Orientation$ 
Horizontal=?6(   .+?5B      '  !MaterialDesignThemes.Wpf.PackIcon  $??	20,0,10,0q?67   
???????   Kind 6^   ?? *Icon+?? 5C      $??15(?6(   
?????????6I   ?? *Name+5D      5E       ?? 
GroupStyle 5G      (	  "System.Windows.Controls.GroupStyle	  5H       	  ContainerStyle 5I      ?? 5J      "
 ??6$   .?5K   "   ??  ? ?? 5L   &   ?? 5M   *   .R?5N   .   ?? $??Stretch=?6;   $??Disabled=?6Y   $
??Auto=?6?   .??5O   2   9? ???#303843
?????????5P   6   ?? 5Q   :   $??15(?6D   
?????????6e   ?? *Name+.??5S   6   ?? $??0??6E   5T   3   5U   /   5V   +   5X   #   5Y      5[      5]      5^      ? 5`   
   $??1??6   .+?5a      ?  ? RowDefinitions 5b      ?? 5c      $
??auto ?6$   ?? 5d      $??* ?6$   .+?5g      ?? $??40??5h      ???#303843$??0q?5j      ._?5k      ?? $
??30 0q?6!   $ 
Horizontal=?6/   .+?5l      d? #???  6(   .??5m        $??20??6L   $??20??6X    66   ?? *Icon+6X   5n      ?? 5o      $
??20,0q?5p      $??Center=?5q      $
??Bold"?5r      
?????????5t      ?? *Title+5u      5w      ?? 5x      $??1??6"   !
  Prism.Regions.RegionManager 
  
RegionName$ ContentRegion??5y      5z      5|      5}      5~      