   M S B A M L   `   `   `  ????I  EInfrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU;clr-namespace:Infrastructure.Common;assembly=InfrastructureInfrastructure.Common  5      H DFeederProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:FeederProject.Views.HardWorkView FeederProject.Views.HardWorkView 5      6   0FeederProject.Views.HardWorkView.RealTimeWMSView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Oconvert;clr-namespace:Infrastructure.Common;assembly=Infrastructure     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      :local.clr-namespace:FeederProject.Views.HardWorkView  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/ 	 5      j
 fSyncfusion.SfBusyIndicator.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSkinManager.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=20.1310.0.59, Culture=neutral, PublicKeyToken=3d67ed1f87d44c896sync!http://schemas.syncfusion.com/wpf 
      5      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5      4   .Infrastructure.Common.WmsColorToBrushConverter   WmsColorToBrushConverter  
_textBlock ?? 
TargetType ?? Property ?? Value 
 button ?? 
TargetType ??Name ?? CornerRadius J? SnapsToDevicePixels	 A? Rows
 ?? Triggers P? Property P? Value ?? 
TargetName??%?  &	        &	      &	 ?     7  7  7  7    5   
   6+   ?? 5   
   " ??6#   .?5      ??  ? ??$ Center=?64   ?? 5       ? ??$ Center=?62   5      ?? 5   
   " ??6   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ?? $ border??5      #??z??5!      #??z??5"      $ 3??5#      $
 True??5$      ??5       ?? *
BackGround+._?5%      A? $	 4??6*   .+?5&   "   ?? 8??  ??6P   ?? *
wms_code+?? 5'   "   8?? ??6P   ?? *
serial_num+?? 5)   "   8?? ??6P   ?? *	Station+?? 5*   "   8?? ??6P   ?? *	ProName+5,      5-      
 5.      P? 5/       ?@J?IsMouseOver$
 True??6=   . ?50   "   ?? $ border??6)    6S   ?? *
BackGround+ ? ??51      P? 52       ? ??$
 True??6;   . ?53   "   ?? $ border??6)    6S   ?? *
BackGround+ ? ??54      57      59      5:      5;      .??5<      ? $??10q?6    ? RowDefinitions 5>   
   ?? 5?      $
??Auto ?6   ?? 5@      $??7* ?6   ?? 5A      $??3* ?6   .+?5F   
   ]? .+?5G      ?? $
??0,10q?5H      $
??Left=?5I        PrimaryHueDarkBrush#???  5J      A? 5K       A? Columns$ 2??6   .+?5L      '  !MaterialDesignThemes.Wpf.PackIcon  $??Right=?5M      $??Center=?5N         Kind$ ChevronDoubleDown=?5O      ?? 5P      $
??Left=?5Q      $??Center=?5R      $??	立体库??5S      5T      5U      ?? 5V      $??200,0q?5W      $??Right=?5Z       " MaterialDesignPaperLightButton#??[ 5[      ??5X      ?? *RefreshCommand+??5Y      ?? *SelectedItem+ ?? ElementName$ DrderDatagrid??.??5\      A? $ 2??6   .+?5]        $
??Left=?5^      $??Center=?5_      
???   ?$ Refresh=?5a      ?? 5b      $??Center=?5c      $??Center=?5d      $??刷新??5e      5f      5g      5h      ? 5j   
   $??1??6    ? ColumnDefinitions 5k      ?? 5l      $
??auto ?6#   ?? 5m      $??* ?6#    5p      ?? 5q      $
??auto ?6    ?? 5r      $??* ?6    .+?5v      A? $??1??6   $ 9??6*   .+?5w      ?? #??[ 6   $??C1??6@   ?? 5x      #??[ 6   $??C2??6@   ?? 5y      #??[ 6   $??C3??6@   ?? 5z      #??[ 6   $??C4??6@   ?? 5{      #??[ 6   $??C5??6@   ?? 5|      #??[ 6   $??C6??6@   ?? 5}      #??[ 6   $??C7??6@   ?? 5~      #??[ 6   $??C8??6@   ?? 5      #??[ 6   $??C9??6@   5?      A? 5?      $??1??6   $	 3??6'   .+?5?      ?? #??[ 6   $??R1??6@   ?? 5?      #??[ 6   $??R2??6@   ?? 5?      #??[ 6   $??R3??6@   5?      ?? 5?      -   5         ??Name$ itemControl??5?      $??1??5?      $??1??5?      $??5q?5?      ??5?      ?? *WMSS+??5?      ?? 5?      .R?5?      A? $ 9??6&   $	 3??62   5?      ??5?      ?? 5?      .R?5?      ?? $??2q?5?      $??0q?5?      #??[ 5?      ??5?      ?? *$"DataContext.SelectedWMSCODECommand+ ?? RelativeSource ??  ?? AncestorType ItemsControl??5?      ?? {?5?      ?? *
IsEnable+5?      5?      5?      5?      57     5:     