   M S B A M L   `   `   `  ����G  CMixerAirways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MixerAirwaysMixerAirways  5   	       MixerAirways.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MixerAirways     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � WindowStyle$
 None=�6q    � 	Resources 5
         MenuOpen �� TargetProperty �� 
TargetName p� KeyTime p� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value  	MenuClose��%�  &	        &	 o    �� 5   
   .��5      r� $ Margin�6/   $ ContentGrid��6R   .	�5      �� $ 0��6*   $ 60 0 0 0q�66   �� 5      $ 0:0:0.25��6*   $ 	200 0 0 0q�6=   5      U� 5      $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $	 0��6'   $
 60Q�63     5      $	 0:0:0.25��6'   $	
 200Q�6:   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $	 0��6'   $	
 200Q�63     5      $	 0:0:0.25��6'   $
 60Q�6:   5      r� 5      $ Margin�6/   $ ContentGrid��6R   .	�5      �� $ 0��6*   $ 	200 0 0 0q�66   �� 5      $ 0:0:0.25��6*   $ 60 0 0 0q�6=   5      5      5       � Triggers 5       :� 5!   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ OpenMenuButton��66   .[�5"      �� #��[  6   5#      :� 5$   
   $ ButtonBase.Click��6   $ CloseMenuButton��66   .[�5%      �� #��[ 6   5&      .��5(      � -   5        .+�5)   
   )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ Empty��5)   3      IsOpen .     DialogContent 5*      �� 5+      $��15q�6    �� Orientation$ Vertical=�6)   .+�5,      �� $!��You have no active bookings��6    ���#FF9800$��20(�6X   $��0q�6f   �� 5-      ���#7E57C2$��Ok��62     MaterialDesignFlatButton#���  6?      CloseDialogCommand#��Z 6r   ��6�   ��  �� ElementName$ Empty��5.      50        51   
   -   5        $ NoTick��51   3    .   52      �� 53      $��15q�6   $ Vertical=�6)   .+�54      �� $��You have no tickets��6    ���#FF9800$��20(�6P   $��0q�6^   �� 55      ���#7E57C2$��Ok��62   #���  6?   #��Z 6r   ��6�   �� $ NoTick��56      58        59   
   -   5        $ NoNot��59   3    .   5:      �� 5;      $��15q�6   $ Vertical=�6)   .+�5<      �� $��You have no notifications��6    ���#FF9800$��20(�6V   $��0q�6d   �� 5=      ���#7E57C2$��Ok��62   #���  6?   #��Z 6r   ��6�   �� $ NoNot��5>      5@        5A   
   -   5        $ SuccessTicket��5A   3    .   5B      �� 5C      $��15q�6   $ Vertical=�6)   .+�5D      �� $(��"This ticket successfully purchased��6    ���#FF9800$��20(�6_   $��0q�6m   �� 5E      -   5         ��Name$ ReloadBookings��5E      ���#7E57C2$��Ok��6J   #���  6u   #��Z 6�   ��6�   �� $ SuccessTicket��5F      5H      � 5I   
   -   5         �Name$ 
TopTopGrid��5I      $��50��6#   $	��Top=�6/   ���#37474F J� Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K         ShadowDepth$ 3Q�6#   +  %MaterialDesignThemes.Wpf.ShadowAssist   Darken .    ShadowEdges$ Bottom=�6]   .+�5N      �� $��Right=�6   $��Center=�65   $ 
Horizontal=�6P   .+�5O      �� .+�5P      � -   5         �Name$ ProgressBar1��5P   "   $��20q�68    � Minimum$ 0Q�6E    � Maximum$ 1Q�6Q   ���#FF9800 � IsIndeterminate . $��10��6�   $	��700��6�   $y�Hidden=�6�   ��6]   Z� ��6t   Z� 6�   5Q      �� 5R      $ 
Horizontal=�6   $��Right=�66   $
��10 0q�6R   .+�5S      �� $��0q�6    
�������$��MixerAirways��6>   $��25(�6R   $��Center=�6`   $��Center=�6}   $��Yu Gothic UI)�6�   $
��Bold"�6�   5T      '  !MaterialDesignThemes.Wpf.PopupBox  5U      ���#FF9800$��0q�6?      PlacementMode$ BottomAndAlignRightEdges=�6J      	StaysOpen .      PopupContent.  5V      �� $	��150��6!   .+�5W      �� -	   5        $ SettingsButton��5W   !   $��Settings��69   6k   �� 5X      -
   5        $ AboutBtn��5X   1   $��About��6!   6\   �� 5Y      6&   �� 5Z      -   5        $ 	LogOutBtn��5Z   3   $��Log out��6!   6`   5[      5\      �� 5]      $ 
Horizontal=�6   .+�5^      �� -   5        $��Close��5^      $
��10 0q�6W    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6e   ��6*   Z� ��6@   Z� .��5_      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]!   Kind$! Power=�62   ���#FF9800$��25��6T   $��25��6_   5`      5a      5b      5c      � 5d   
   $��Bottom=�6   ���#ECEFF1.+�5e      � -   5        $ ContentGrid��5e      $��60 0 0 0q�6(   $	��940��6:   $	��550��6F   ���#ECEFF1$��Center=�6h   $
��Left=�6�   5g      5h      � 5i   
   -   5        $ GridMenu��5i      $��60��6!   $
��Left=�6,   ���#37474F 5j        5k      $ 2Q�6#    . $ Right=�6]   .+�5m      �� .+�5n      � -   5        $ TopInfoGrid��5n      $	��150��6,   $	��Top=�69   ���#ECEFF1.+�5o      �� $	��Top=�6!   $��Right=�69   .+�5p      �� -   5        $ CloseMenuButton��5p   !   $��60��6:   $��60��6E   $y�	Collapsed=�6   ��6Q   Z� ��6g   Z� .��5q        $! 	ArrowLeft=�66   ���#FF9800$��25��6\   $��25��6g   5r      �� 5s      -   5        $ OpenMenuButton��5s   !   $��60��69   $��60��6D   ��6P   Z� ��6f   Z� .��5t        $
! Menu=�66   ���#FF9800$��25��6W   $��25��6b   5u      5v      5w      �� 5x      -   5        " ��Name$" MenuListView��5x   F   ���#FF9800$��10q�61   $��Hidden=�6\   .@�5y      �� $��60��6#   ���#FF9800.��5z      �� $ 
Horizontal=�6%   .+�5{        $! Account=�66   $��25��6E   $��25��6P   $��10 10q�6\   �� 5|      
�������$��
My account��6;   $��16(�6M   $��Center=�6[   $��Center=�6v   $��20 10q�6�   5}      5~      �� 5      $��60��6#   ���#FF9800.��5�      �� $ 
Horizontal=�6%   .+�5�        $! BookOpenVariant=�66   $��25��6M   $��25��6X   $��10 10q�6d   �� 5�      
�������$��My books��6;   $��16(�6K   $��Center=�6Y   $��Center=�6t   $��20 10q�6�   5�      5�      �� 5�      $��60��6#   ���#FF9800.��5�      �� $ 
Horizontal=�6%   .+�5�        $! TicketAccount=�66   $��25��6K   $��25��6V   $��10 10q�6b   �� 5�      
�������$��
My tickets��6;   $��16(�6M   $��Center=�6[   $��Center=�6v   $��20 10q�6�   5�      5�      �� 5�      $��60��6#   ���#FF9800.��5�      �� $ 
Horizontal=�6%   .+�5�        $! Magnify=�66   $��25��6E   $��25��6P   $��10 10q�6\   �� 5�      
�������$��Search flights��6;   $��16(�6Q   $��Center=�6_   $��Center=�6z   $��20 10q�6�   5�      5�      �� 5�      $��60��6#   ���#FF9800.��5�      �� $ 
Horizontal=�6%   .+�5�        $! NotificationsActive=�66   $��25��6Q   $��25��6\   $��10 10q�6h   �� 5�      
�������$��Notifications��6;   $��16(�6P   $��Center=�6^   $��Center=�6y   $��20 10q�6�   5�      5�      �� 5�      -   5        # ��Name$# admin��5�   #   $��60��62   ���#FF9800$y�	Collapsed=�6S   .��5�      �� $ 
Horizontal=�6%   .+�5�        $! Crown=�66   $��25��6C   $��25��6N   $��10 10q�6Z   �� 5�      
�������$��	Developer��6;   $��16(�6L   $��Center=�6Z   $��Center=�6u   $��20 10q�6�   5�      5�      5�      5�      5�      5�      5�      