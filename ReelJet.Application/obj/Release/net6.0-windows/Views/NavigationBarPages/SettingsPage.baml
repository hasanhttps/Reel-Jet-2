   M S B A M L   `   `   `  ���� N  JReelJet.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reel_Jet.UtilitiesReel_Jet.Utilities  k:clr-namespace:ReelJet.Application.Models.DatabaseNamespace,ReelJet.Application.Models.DatabaseNamespace  U/clr-namespace:Reel_Jet.Views.NavigationBarPages!Reel_Jet.Views.NavigationBarPages  4    .Reel_Jet.Views.NavigationBarPages.SettingsPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /ut clr-namespace:Reel_Jet.Utilities     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:ma1http://materialdesigninxaml.net/winfx/xaml/themes  Idatabase:clr-namespace:ReelJet.Application.Models.DatabaseNamespace  ;local/clr-namespace:Reel_Jet.Views.NavigationBarPages    N� 
Background  �#1F1F2B N� Title$ SettingsPage��.���  � ColumnDefinitions �� $��55 ��� .+�� $��0�����#12121A.+��� $��0 60 0 0q�$	��Top=�   NavigationWatchListButton#��[  ���� *WatchListPgButtonCommand+�� $��	0 110 0 0q�$	��Top=�  NavigationHistoryButton#��[ ���� *HistoryPgButtonCommand+�� $��	0 160 0 0q�$	��Top=�  NavigationMovieListButton#��[ ���� *MovieListPageCommand+�� $��	0 210 0 0q�$	��Top=�  NavigationForYouButton#��[ ���� *ForYouPageCommand+�� $��0 0 0 70q�$��Bottom=�  NavigationSettingsButton#��[ �� $��0 0 0 20q�$��Bottom=�  NavigationProfileButton#��[ ���� *ProfilePgButtonCommand+� $��1�� � RowDefinitions �� $	��180 ��� .+�� $��0��.+��� -   $��ComboBox�� & "MaterialDesignFloatingHintComboBox#��[ $.��(/Static Files/Fonts/QuickSand/#Quicksand)�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 LNG��$��Right=�$��Bottom=�$��50q�
�������.@��� ����  �� Orientation$ 
Horizontal=�.+���   
AzeFlagImg#��[ $��25��$��	0 -4 10 0q�$��UniformToFill=��� $	��AZE���� ���� $ 
Horizontal=�.+���   	UKFlagImg#��[ $��25��$��	0 -4 10 0q�$��UniformToFill=��� $	��ENG��*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 �� *!LanguageSelectionChangedCommand+
   CommandParameter
 �� *SelectedItem+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �� �� UpdateSourceTrigger$ PropertyChanged=�� $��1��$��	200 0 0 0q� �� $	��300 ��� .+�� .+��� $	��Top=�.+��� $��Settings��
�������$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��45(��� $��Medium"�$
��Left=�$��20(�
�������
������ 
������ $��50��$��0 60 0 0q����� *AccountPgButtonCommand+���� $ 
Horizontal=�.+��� $��25��$��25�� 	 SettingsAccountImg#��[	 $��
-12 0 15 0q��� 
�������$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��23(�$��Center=����� *AccountText+;   5ReelJet.Application.Models.DatabaseNamespace.Database   CurrentLanguageControl �� Source# Z  �� Mode$ TwoWay=�$ PropertyChanged=� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� $��Medium"�$
��Left=�$��20(�
�������
������ 
������ $��50������ *$"UploadPersonalMoviePgButtonCommand+���� $ 
Horizontal=�.+��� $��25��$��25�� 
 UploadPersonalMovie#��[
 $��
-12 0 15 0q��� 
�������$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��23(�$��Center=����� *UploadVideoText+# Z $ TwoWay=�$ PropertyChanged=� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� $��Bottom=�$��0 0 0 49q�.+��� $��Medium"�$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$
��Left=�$��20(�
�������
������ 
������ $��50��$��0 20 0 0q����� *ClearCacheDataButtonCommand+���� $ 
Horizontal=�.+��� $��25��$��25��  ClearCacheImg#��[ $��
-10 0 15 0q��� 
�������$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��20(�$��Center=����� *ClearCacheText+# Z  ��%:   '��       �� " ��.���  �@��CornerRadius$ 20���� $��Medium"�$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$
��Left=�$��20(�
�������
������ 
������ $��50��$��0 20 0 0q����� *LogOutCommand+���� $ 
Horizontal=�.+��� $��25��$��25��  	LogOutImg#��[ $��
-10 0 15 0q��� 
�������$.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��20(�$��Center=����� *
LogOutText+# Z  ��%:   '��       �� " ��.���  �@��CornerRadius$ 20�� � -   $��SettingsPageFrame��$��1��