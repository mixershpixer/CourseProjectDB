   M S B A M L   `   `   `  ����  MixerAirways    MixerAirways.Registration   5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Registration��5   	   $	��470��6   $	��500��6+   $��14(�67   ���#FF9800 � WindowStartupLocation$ CenterScreen=�6Z    � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6�   .��5
      �� ���#37474F �� CornerRadius$ 20��6"   $��25q�64   ._�5   
   �� .+�5      �� $��38 15 38 15q�6    � Cursor$	 Pen��6/   .+�5      �� $��Registration��6   $��36(�6/   $��Center=�6=   
�������$	��Top=�6m   $��Center=�6�   $ Arrow��6�   �� 5      $��5q�6   ���	#FFFFFDFD���	#FFF8F8F8���	#FFFFF9F96_   �� 5       �� Orientation$ 
Horizontal=�6   $
��0,10q�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ RegMail��5   .   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ MailRu=�6?   ���#FF9800$��35��6b   $��35��6m   $��Center=�6y   $��Center=�6�   $��Center=�6�   $��Bottom=�6�   �� 5      -   5        	 ��Name$	 
RegMailTxt��5      $��	0,10,10,0q�62   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Enter your email here��6E      
IsFloating . ���	#FFB3EEF3���#37474F
�������$��16(�6�   $	 Pen��6  $��Center=�6$  $
��Left=�6A  $��Center=�6c  $��Center=�6�  $	��320��6�  5      )  #MaterialDesignThemes.Wpf.DialogHost  5      -   5          Name$ Complite��5   ;      IsOpen .     DialogContent 5      �� 5      $��15q�6%   $ Vertical=�61   .+�5      �� $��Registration successfull��6(   ���#FF9800$��20(�6]   $
��10 0q�6k   �� 5      $��Happy reading!)��6(   ���#FF9800$��18(�6T   $��	50 10 0 0q�6b   �� 5      -   5         ��Name$ ReadyBtn��5   %   ���#37474F$��Accept��6L      MaterialDesignFlatButton#���   6]   6�   5      5        5       -   5        $ RegFail��5    ;    .   5!      �� 5"      $��15q�6%   $ Vertical=�61   .+�5#      �� $%��This username is already exists��6(   ���#FF9800$��20(�6d   $��0 0 0 10q�6r   �� 5$      ���#37474F$��Change username��6:   #���   6T      CloseDialogCommand#��Z 6�   ��6�   ��  �� ElementName$ RegFail��5%      5'      �� 5)      $ 
Horizontal=�6   .+�5*        -   5        $ RegUserName��5*   .   $ Account=�6C   ���#FF9800$��35��6g   $��35��6r   $��Center=�6~   $��Center=�6�   $��Center=�6�   $��Bottom=�6�   �� 5+      -   5        $	 RegUserNameTxt��5+      $��0,0,10,0q�67   $
 Enter username here��6I    . ���	#FFB3EEF3���#37474F
�������$��16(�6  $	 Pen��6  $��Center=�6*  $
��Left=�6G  $��Center=�6i  $��Center=�6�  $	��320��6�  5,      �� 5.      $ 
Horizontal=�6   .+�5/        -   5        $ RegPassword��5/   /   $	 Key=�6D   ���#FF9800$��35��6d   $��35��6o   $��Center=�6{   $��Center=�6�   $��Center=�6�   $��Bottom=�6�   G� 50      -	   5         G�Name$ RegPasswordTxt��50   "   $��	0,10,10,0q�6;   $
 Enter password here��6N    . ���	#FFB3EEF3���#37474F
�������$��16(�6  $	 Pen��6"  $��Center=�6/  $
��Left=�6L  $��Center=�6n  $��Center=�6�  $	��320��6�  51      �� 52      -
   5        $��RegistrationButton��52      $��Sign up��63   $��40��6E   $��30,25,24,15q�6Q   ���#FF9800���#37474F
�������$��18(�6�   �� 53      $��or��6   $��14(�6%   $��0,-15,0,-10q�63   
�������$��Center=�6[   $ Arrow��6x   �� 54      -   5        $��BackToLoginButton��54      $��Back to LogIn Window��62   $��40��6Q   $��
45,15,45,0q�6]   ���#FF9800���#37474F
�������$��18(�6�   56      �� 57      .+�58      � -   5         �Name$ ProgressBar1��58       � Minimum$ 0Q�66    � Maximum$ 1Q�6B   ���#37474F���#FF9800 � IsIndeterminate . $��10��6�   $y�	Collapsed=�6�   $��Center=�6�   $	��250��6�   ��6N   Z� 6�   59      5:      5;      5<      