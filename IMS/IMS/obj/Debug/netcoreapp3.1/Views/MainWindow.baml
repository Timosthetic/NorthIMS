   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:IMS.StyleControlIMS.StyleControl  5          IMS.Views.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:IMS.StyleControl     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      $
??1580??5	      $	??850??5
      #   IMS.StyleControl.WindowCloser    EnableWindowClosing$
  True??5      !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5         WinodwStyle.Base#??[  5       ? WindowStartupLocation$ CenterScreen=?5       ? WindowState$ 	Maximized=?5       ? 	Resources 5        btn  
FlatButton ?? BasedOn ?? 
TargetType ?? Property ?? Value  btn1	 ?? Triggers
 P? Property P? Value??%?  &	       7  &	 ?     7  ?? 5   
   8   " ??5      .?5      ??  ? ??
 ???? 6+   ?? 5       ? ??$ 0q?60   ?? 5       ? ??
 ?   ?6+   ?? 5       ? ?? 6(   ?? *WindowBtnCommand+?? 5       ? ??$ 0,0,15,0q?6'   5      ?? 5   
   8   " d?5       .?5!      ??  ? ??
 ???? 6+   ?? 5"       ? ??$ 0q?60   ?? 5#       ? ??
 ?   ?6+   ?? 5$       ? ?? 6(   ?? *WindowBtnCommand+?? 5%       ? ??$ 0,0,15,0q?6'   	 5&      P? 5'      
 ?@d?	IsChecked$
 TrueY?6/   . ?5(      ??  ? ??$	 Max??69   5)      P? 5*      
 ?@d?	IsChecked$ FalseY?6/   . ?5+      ??  ? ??$	 Nol??69   5,      5/      50      .??51      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$
 Root??6     $  MaterialDesignEmbeddedDialogHost#??[ 62   .??53   
   ?? ???#F5F7F9???#D7DDE4$??2q?56      ._?57      ? -   5         ?Name$ MainGrid??57       ? RowDefinitions 58      ?? 59      $
??auto ?6$   ?? 5:      $
??auto ?6$   ?? 5;      $??* ?6$   ?? 5<      $??30 ?6$   .+?5>      ? $??0??6   
???????.+?5?      A? $??60??6"    A? Columns$ 2??6.   .+?5C      ?? $??0q?6!   ._?5D      ?? $??5q?6)    ?? Orientation$ 
Horizontal=?64   .+?5E   "   ?? $0??*/Views/27c829c73efd9d919f2d2cb9c30a68c.png??6(   $
??Fill=?6\   ?? 5G   "   $ Vertical=?6-   .+?5H   &   ?? $
??20,0q?5I   )   $??Center=?5J   )   $??20(?5K   )     PrimaryHueDarkBrush#???  5L   )   $1??+北 方 自 动 控 制 技 术 研 究 所??5M   )   ?? 5N   &   $
??15,0q?5O   )   $??Center=?5P   )   $??15(?5Q   )   #???  5R   )   $2??,NORTH AUTOMATIC CONTROL TECHNOLOGY INSTITUTE??5S   )   5T   #   5V      5X      ?? 5Y      $??60??6!   $	??Top=?6-   ._?5Z      ?? $??Right=?6)   $ 
Horizontal=?6E   .+?5]   "   ?? #???  5_   %    ? ToolTip$ 退出登录??5`   %   ??5^   %   ?? *LoginOutCommand+??5a   &   '  !MaterialDesignThemes.Wpf.PackIcon  5b   *   $??20??5c   -   $??20??5d   -      Kind$ AccountCowboyHat=?5e   -   5g   #   ?? 5i   "   $	??Min??6)   #???  6@   .??5j   &     $??20??5k   )   $??20??5l   )   $ WindowMinimize=?5m   )   5n   #   d? 5o   "   #???  6/   .??5p   &     $??20??5q   )   $??20??5r   )    5s   )   ?? *Icon+5t   #   ?? 5v   "   $	??Clo??5w   %    ? Cursor$
 Hand??5x   %   #???  5y   %   .??5z   &     $??20??5{   )   $??20??5|   )   $ WindowClose=?5}   )   5~   #   5      5?      5?      5?      ? 5?      $??1??6   .+?5?      ?? !  Prism.Regions.RegionManager   
RegionName$ TopRegionMenu??6%   5?      ? 5?      -   5        $??gridMain??5?      $??2??5?      ???#e0e0e0.+?5?      ?? $ CentterRegionPermission??6%   5?      ? 5?      $??3??6   
???????.+?5?      ?? $??Right=?6!   $ 
Horizontal=?6=   .+?5?      ?? $??Right=?5?      $??Center=?5?      $??当前版本:??5?      ?? 5?      $??	10,0,70,0q?5?      $
??Left=?5?      $??Center=?5?      
???2͚???5?      ?? *	Version+?? 5?      $??Right=?5?      $??Center=?5?      $??当前用户:??5?      ?? 5?      $
??10,0q?5?      $
??Left=?5?      $??Center=?5?      $??	管理员??5?      ?? 5?      $??Right=?5?      $??Center=?5?      $??时间:??5?      ?? 5?      $	??150??5?      $
??10,0q?5?      $
??Left=?5?      $??Center=?5?      ??5?      ?? *Time+5?      5?      5?      5?      5?      5?      