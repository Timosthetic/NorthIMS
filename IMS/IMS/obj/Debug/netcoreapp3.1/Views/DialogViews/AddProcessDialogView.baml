   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:IMS.Views.DialogViewsIMS.Views.DialogViews  5      0    *IMS.Views.DialogViews.AddProcessDialogView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:IMS.Views.DialogViews     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      $	??650??5
      $	??400??5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5         
_textblock ?? 
TargetType   MaterialDesignBody1TextBlock ?? BasedOn ?? Property ?? Value??%?   &	        7  ?? 5   
   " ??6#   8   .?5      ??  ? ??$ Center=?64   ?? 5       ? ??$ Center=?62   ?? 5       ? ??$ 0 20 0 0q?6'   5      5      .??5      ? ???#F1F1F1 ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      ?? 5      $??60 ?6   .+?5   
   '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ LoginSnakeBar??5      $??2??5      $??Center=?5      $??Bottom=?5       K? ZIndex$ 1??5       	   MessageQueue	 5!      ?? *BoundMessageQueue+]? 5#   
     PrimaryHueDarkBrush#???  6   .+?5$      ?? $
??Left=?6   
 ?? Orientation$
 
Horizontal=?6/   .+?5%      ?? $
??20,0q?5&      $??Center=?5'      $??15(?5(         PrimaryHueMidForegroundBrush#???  5)      $??工序齐套??5*      ?? 5+      5,      ?? 5-      $??Right=?5.      #???  5/      $??0q?50      #???  52       # MaterialDesignFlatLightBgButton#??[ 53      ??51      ?? *CancelCommand+.??54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?6*   55      56      ? 57   
   $??1??6   .+?58      ?? $
 Vertical=?6   $??20q?60   .+?59      A?  A? Columns$ 2??6   .+?5:      ?? $??物料编码??6    #??[  6,   $??Center=?6P   $??Center=?6k   ?? 5;      $??Bottom=?6B   ${?False??6]    ?? 
IsReadOnly$
 True??6o   ??6   ?? *CraftItem.mal_code+6o   5=      A? 5>      $ 2??6   .+?5?      ?? $??物料名称??6    #??[  6,   $??Center=?6P   $??Center=?6k   ?? 5@      $??Bottom=?6C   $
 True??6_   ${?False??6q   ??6   ?? *CraftItem.mal_name+6q   5A      A? 5C      $ 2??6   .+?5D      ?? $??产品齐套??6    #??[  6,   $??Center=?6P   $??Center=?6k   ?? 5E      $??Bottom=?6B   $
 True??6]   ${?False??6p   ??6   ?? *CraftItem.mal_num+6p   5H      A? 5J      $ 2??6   .+?5L      ?? $??工序齐套??6    #??[  6,   $??Center=?6P   $??Center=?6k   ?? 5M      -   5         ??Name$ _textbox??5M   <   $??Bottom=?6O   ??6   ?? *PrcCraftNum+6O   5N      ?? 5Q      $:??4注：单工序齐套数量不得高于产品齐套 ??6   #??[  66   
???  ??$??Right=?6k   $??Center=?6?   5S      5W      ? 5Y   
   $??2??6    ? ColumnDefinitions 5Z      ?? 5[      ?? 5\      .+?5^      ?? $??Center=?5_      $?? ??5`      $??20(?5a      #??[ 5b      ]? 5c      $??1??6   .+?5d      ?? $??	20,0,20,0q?5e        PrimaryHueMidBrush#???  5f      $??0q?5g       ? Cursor$
 Hand??5i      $??Right=?5j      #???  5k      ??5h      ?? *SaveCommand+.??5l      ?? $
 
Horizontal=?6!   .+?5m        $ ContentSave=?62   ?? 5n      $	??5,0q?6$   $??保存??61   5o      5q      ?? 5r      $??Right=?5s      ???#F1F1F1$??0q?5u      $??关闭??5w      
???   ???5v      ?? *CancelCommand+5x      5y      5{      5}      5~      