   M S B A M L   `   `   `  ????>  :IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:IMS.StyleControlIMS.StyleControl  5   
       IMS.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   ,localclr-namespace:IMS.StyleControl   5   
   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5   	   $
??1580??5      $	??850??5      #   IMS.StyleControl.WindowCloser   EnableWindowClosing$
 True??5
   	      WinodwStyle.Base#??[  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowState$ 	Maximized=?6.    ? 	Resources 5        btn  
FlatButton ?? BasedOn ?? 
TargetType ?? Property  PrimaryHueDarkBrush ?? Value   PrimaryHueMidForegroundBrush??%  &	       7  ?? 5   
   8   " ??5      .?5      ??  ? ??# ?  6+   ?? 5       ? ??$ 0q?60   ?? 5       ? ??# ?  6+   ?? 5       ? ?? 6(   ?? *WindowBtnCommand+?? 5       ? ??$ 0 0 15 0q?6'   5      5      .??5      )  #MaterialDesignThemes.Wpf.DialogHost   $  MaterialDesignEmbeddedDialogHost#??[ 6!   	   
Identifier$
	 Root??6[   .??5   
   ? -   5        
 ?Name$
 MainGrid??5       ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $??* ?6    ?? 5      $??20 ?6    .+?5!      ? $??0??6   #???  6!   .+?5"      ?? $??60??6   $	??Top=?6%   ._?5#      ?? $??Right=?6!    ?? Orientation$ 
Horizontal=?6=   .+?5$      ?? $	??Min??6!   #???  68   .??5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=?66   5&      ?? 5'      $	??Max??5(      #???  5)      y?5*      ?? *MaxVis+.??5+        $ WindowMaximize=?66   5,      ?? 5-      $	??Nol??5.       ? Cursor$
 Hand??5/      #???  51      y?52      ?? *NolVis+.??53        $ WindowRestore=?66   54      ?? 55      $	??Clo??56      $
 Hand??57      #???  59      .??5:        $ WindowClose=?66   5;      5<      5=      5>      ? 5?      $??1??6   .+?5@      ?? !  Prism.Regions.RegionManager   
RegionName$ TopRegionMenu??6!   5A      ? 5B      -   5        $??gridMain??5B      $??2??6#    5C      ?? 5D      $	??70* ?6$   ?? 5E      $??2 ?6$   ?? 5F      $	??30* ?6$   .+?5H      ?? 
???   ? ?? ShowsPreview$
 True??5J      $??1??5K      $??Stretch=?5L      ?? 5M      -   5         ??Name$ _richTextBox??5N      $??2??5M      $ IBeam??5O      $5??/Cascadia Mono, Consolas, Courier New, monospace)?5P      $??14(?5Q       ?? 
IsReadOnly$
 True??5R      ? 5S      -   5        $??gridRightColumn??5S      $??0??6.    ? ColumnDefinitions 5T      ?? 5U      $
??1.2* ?6+   ?? 5V      $??2 ?6+   ?? 5W      $??8* ?6+   .+?5Y      ?? ???#EAEEF9$ LeftRegionTree??6:   ?? 5Z      
???   ?$
 True??5\      $??1??5]      $??Stretch=?5^      $??Stretch=?5_      ?? 5`      $??2??6%   $??Stretch=?5a   %   $??Stretch=?5b   %   $ BottomRegionContent??5c   %   5d      5e      ? 5f      $??3??6   
?????d?6    ?? 5g      $ ContentRegion??5h        CloseControlStyle#???  5i        CloseControlTemplate#???  5j      5k      5l      5m      