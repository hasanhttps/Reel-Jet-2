   M S B A M L   `   `   `  ���� N  JReelJet.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reel_Jet.UtilitiesReel_Jet.Utilities  k:clr-namespace:ReelJet.Application.Models.DatabaseNamespace,ReelJet.Application.Models.DatabaseNamespace  q=clr-namespace:Reel_Jet.Views.NavigationBarPages.SettingsPages/Reel_Jet.Views.NavigationBarPages.SettingsPages  A    ;Reel_Jet.Views.NavigationBarPages.SettingsPages.AccountPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /ut clr-namespace:Reel_Jet.Utilities     Odatabase:clr-namespace:ReelJet.Application.Models.DatabaseNamespace     Olocal=clr-namespace:Reel_Jet.Views.NavigationBarPages.SettingsPages       N� Title$  AccountPage��.��� .+�� $��10q�.+��� $.��(/Static Files/Fonts/Quicksand/#Quicksand)�$��30(�
�������$��20q�$
��Bold"����� *EditProfileText+;   5ReelJet.Application.Models.DatabaseNamespace.Database   CurrentLanguageControl �� Source# Z  �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��Center=�$
��Left=�$��100 -20 0 0q�.+��� $	��150��$	��150�� �� CornerRadius$	 150��$��0 0 0 50q�����  j� Stretch$ UniformToFill=� �� ImageSource �� *Avatar+$ TwoWay=�$ PropertyChanged=�._���    EditButtonForAccount#��[  $��Bottom=�$��Right=����� *EditPfpCommand+��  �� Orientation$ 
Horizontal=�$��0 0 0 0q�.+�(   "Reel_Jet.Utilities.BindableTextBox  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��0 0 70 0q�$	��300��
�������$��40��	   PlaceHolder	 �� *
NameText+# Z $ TwoWay=�$ PropertyChanged=�
   Text
 �� *EditedUser.Name+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��300��$��40��
�������	 �� *SurnameText+# Z $ TwoWay=�$ PropertyChanged=�
 �� *EditedUser.Surname+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�${�False��$��0 20 0 0q�
�������$��40��$	 Email��
 �� *EditedUser.Email+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��0 20 0 0q�
�������$��40��	 �� *PhoneNumberText+# Z $ TwoWay=�$ PropertyChanged=�
 �� *EditedUser.PhoneNumber+$ 	LostFocus=�$ TwoWay=��� $ 
Horizontal=�$��0 20 0 0q�.+�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��0 0 70 0q�$	��300��
�������$��40��	 �� *	AgeText+# Z $ TwoWay=�$ PropertyChanged=�
 �� *EditedUser.Age+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��300��$��40��
�������	 �� *UsernameText+# Z $ TwoWay=�$ PropertyChanged=�
 �� *EditedUser.Username+$ 	LostFocus=�$ TwoWay=�*   $Reel_Jet.Utilities.CustomPasswordBox  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��0 20 0 0q�
�������$��40��   PlaceHolder �� *PasswordText+# Z $ TwoWay=�$ PropertyChanged=�   Password �� *EditedUser.Password+$ 	LostFocus=�$ TwoWay=��� $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��200��$��35��$��0 50 0 0q�
����������� *ConfirmChangesText+# Z $ TwoWay=�$ PropertyChanged=����� *ConfirmChangeCommand+