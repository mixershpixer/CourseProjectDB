   M S B A M L   `   `   `  ����G  CMixerAirways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MixerAirwaysMixerAirways  5          MixerAirways.MyAccount   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MixerAirways     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  Trance��5   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6>   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:0.5X�   OpeningEffects 5      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5         Duration$ 0:0:0.5h�62      Kind$ FadeIn=�6E   .��5      ��  �� Orientation$ 
Horizontal=�6   ��5      �� 5       �� ImageSource$ Resources/Aircraft.png��6!    j� Stretch$
 Fill=�6F   	 �� Opacity$
	 0.15Q�6U   .+�5      �� $ 
Horizontal=�6   .+�5      �� $	��Top=�6!   $
��Left=�69   $��
100 30 0 0q�6U   $
��Auto��6i   .+�5      �� -   5        
 ��Name$
 UserName��5   $   $��Center=�66   $��Center=�6S   $��username��6n   $��40(�6~   $	��0 5q�6�   ���#FF98006�   �� 5      $��Center=�6%   $ 
Horizontal=�6C   .+�5      �� -   5        $
 Email��5   (   $
��Left=�67   $��Center=�6R   $��email��6m   $��24(�6z   $	��0 5q�6�   
���   �6�   5      5      �� 5      .+�5      �� -   5         ��Name$ EditBtn��5   !    &  "MaterialDesignFloatingActionButton#���   6H   $��10(�6�   $��Center=�6�   ���#FF9800$��Right=�6�   $��40��6�   $��40��6�   $��	15 60 0 0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$
 Edit=�66   
�������$��25��6U   $��25��6`   $��Center=�6l   $��Center=�6�   $��Center=�6�   $��Bottom=�6�    � ToolTip 5      _� 5   "    _� 	Placement$ Mouse=�6*   .��6<   Remove from bookings5!   #   5#      5$      �� 5%      -   5         ��Name$ RedStack��5%   !   $y�Hidden=�63   $��	50 50 0 0q�6G   .+�5&      �� -   5         ��Name$ UserNameTxt��5&   "   $��0,0,10,0q�67   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter username here��6I      
IsFloating . 
���   �$��20(�6�    � Cursor$	 Pen��6�   $��Center=�6�   $
��Left=�6  $��Center=�6.  $��Center=�6P  $	��320��6k  ��6�   Z� 6k  G� 5'      -   5         G�Name$ PasswordTxt��5'   &   $��0,0,10,0q�6;   $ Enter password here��6M    . 
���   �$��20(�6�   $	 Pen��6�   $��Center=�6�   $
��Left=�6  $��Center=�62  $��Center=�6T  $	��320��6o  ��6�   Z� 6o  G� 5(      -   5        $ ConfPasswordTxt��5(   &   $��0,0,10,0q�6?   $ Confirm password��6Q    . 
���   �$��20(�6�   $	 Pen��6�   $��Center=�6�   $
��Left=�6  $��Center=�63  $��Center=�6U  $	��320��6p  ��6�   Z� 6p  �� 5)      -	   5        $ EmailTxt��5)   "   $��0,0,10,0q�64   $ Enter email here��6F    . 
���   �$��20(�6�   $	 Pen��6�   $��Center=�6�   $
��Left=�6  $��Center=�6(  $��Center=�6J  $	��320��6e  ��6�   Z� 6e  )  #MaterialDesignThemes.Wpf.DialogHost  5*      -
   5          Name$
 Conf��5*   C      IsOpen .     DialogContent 5+      �� 5,   "   $��15q�6-   $ Vertical=�69   .+�5-   &   �� $"��Do you want to save changes?��60   ���#FF9800$��20(�6i   $��0q�6w   �� 5.   &   $��(need to relogin)��60   ���#FF9800$��20(�6^   $��0q�6l   $��Center=�6w   �� 5/   &   -   5        $ ConfCh��5/   -   ���#7E57C2$	��Yes��6R     MaterialDesignFlatButton#���  6`   6�   �� 50   &   ���#7E57C2$��No��6B   #���  6O      CloseDialogCommand#��Z 6�   ��6�   ��  �� ElementName$
 Conf��51   #   53        54      -   5        $ Error��54   C    .   55      �� 56   "   $��15q�6-   $ Vertical=�69   .+�57   &   �� $��Incorrect input��60   ���#FF9800$��20(�6\   $��0q�6j   $��Center=�6u   �� 58   &   ���#7E57C2$��Ok��6B   #���  6O   #��Z 6�   ��6�   �� $ Error��59   #   5;      �� 5<      -   5        $ Confirm��5<   !   $��40��62   $��0 9 0 0q�6U   $��Confirm changes��6f   
�������$��18(�6�   ���#FF9800���	#FFF5F1E46�   5=      5>      5B      5C      5D      5E      