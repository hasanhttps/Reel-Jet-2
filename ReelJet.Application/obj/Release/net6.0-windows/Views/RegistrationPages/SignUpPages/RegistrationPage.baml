   M S B A M L   `   `   `  ���� N  JReelJet.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reel_Jet.UtilitiesReel_Jet.Utilities  S.clr-namespace:Reel_Jet.Views.RegistrationPages Reel_Jet.Views.RegistrationPages  k:clr-namespace:ReelJet.Application.Models.DatabaseNamespace,ReelJet.Application.Models.DatabaseNamespace  C    =Reel_Jet.Views.RegistrationPages.SignUpPages.RegistrationPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /ut clr-namespace:Reel_Jet.Utilities     @local.clr-namespace:Reel_Jet.Views.RegistrationPages     Odatabase:clr-namespace:ReelJet.Application.Models.DatabaseNamespace       N� Title$  RegistrationPage��.��� .+��� $��20 8 8 8q�.+��� $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��30(�
�������$��	20 10 0 0q����� *RegistrationText+;   5ReelJet.Application.Models.DatabaseNamespace.Database   CurrentLanguageControl �� Source# Z  �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� ���#ed1c24$��1q�$��5��$��24��$��-405 0 0 50q���  �� Orientation$ 
Horizontal=�.+�(   "Reel_Jet.Utilities.BindableTextBox  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��20 0 0 0q�
������ 
����������#6B6B77   PlaceHolder �� *
NameText+# Z $ TwoWay=�$ PropertyChanged=�   Text �� *newUser.Name+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��97 0 0 0q�
������ 
����������#6B6B77 �� *SurnameText+# Z $ TwoWay=�$ PropertyChanged=� �� *newUser.Surname+$ 	LostFocus=�$ TwoWay=��� $ 
Horizontal=�.+��� -   $��NameTxtBoxTip��$	��163��$��20 0 0 0q��� -   $��SurnameTxtBoxTip��$	��163��$��97 0 0 0q��� $ 
Horizontal=�.+�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��20 0 0 0q�
������ 
����������#6B6B77 �� *UsernameText+# Z $ TwoWay=�$ PropertyChanged=� �� *newUser.Username+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��97 0 0 0q�
������ 
����������#6B6B77 �� *	AgeText+# Z $ TwoWay=�$ PropertyChanged=� �� *newUser.Age+$ 	LostFocus=�$ TwoWay=��� $ 
Horizontal=�.+��� -   $��UsernameTxtBoxTip��$	��163��$��20 0 0 0q��� -   $��AgeTxtBoxTip��$	��163��$��97 0 0 0q��� $ 
Horizontal=�.+�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$ Email��$	��163��$��20 0 0 0q�
������ 
����������#6B6B77 �� *newUser.Email+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��97 0 0 0q�
������ ���#6B6B77
������� �� *PhoneNumberText+# Z $ TwoWay=�$ PropertyChanged=� �� *newUser.PhoneNumber+$ 	LostFocus=�$ TwoWay=��� $ 
Horizontal=�.+��� -   $��EmailTxtBoxTip��$	��163��$��20 0 0 0q��� -   $��PasswordTxtBoxTip��$	��163��$��97 0 0 0q��� $ 
Horizontal=�.+�*   $Reel_Jet.Utilities.CustomPasswordBox  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��20 0 0 0q�
������ 
����������#6B6B77   PlaceHolder �� *PasswordText+# Z $ TwoWay=�$ PropertyChanged=�	   Password	 �� *newUser.Password+$ 	LostFocus=�$ TwoWay=�  $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��163��$��97 0 0 0q�
������ ���#6B6B77
������� �� *ConfirmYourPasswordText+# Z $ TwoWay=�$ PropertyChanged=�	 �� *ConfirmPassword+$ 	LostFocus=�$ TwoWay=��� $ 
Horizontal=�.+��� -   $��RegistrationCodeTxtBoxTip��$	��163��$��20 0 0 0q��� -   $��ConfirmTxtBoxTip��$	��163��$��97 0 0 0q��� $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$	��200��$��30q�$��35��$��15(�
����������� *
SignUpText+# Z $ TwoWay=�$ PropertyChanged=����� *SignUpCommand+�� $ 
Horizontal=�.+��� $.��(/Static Files/Fonts/QuickSand/#Quicksand)�$��11(�
����������� *AlreadyHaveAnAccountText+# Z $ TwoWay=�$ PropertyChanged=��� -	   $	��5 0q�$.��(/Static Files/Fonts/QuickSand/#Quicksand)�
���  ��$��	Underline{����� *
SignInText+# Z $ TwoWay=�$ PropertyChanged=�