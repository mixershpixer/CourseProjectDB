   M S B A M L   `   `   `  ����G  CMixerAirways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MixerAirwaysMixerAirways  5          MixerAirways.Booking   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &localclr-namespace:MixerAirways  5      .��5
      � -   5        $��
15 5 -20 5q�5
      .+�5   
   ��   �� Orientation$  
Horizontal=�6   .+�5      �� .+�5      �� -   5         ��Name$ 
background��5       �� CornerRadius$ 10��6-   ���#F5F5F5
���   �$��4q�6h   ._�5      �� .+�5      �� $  
Horizontal=�6%   $��Center=�6>   .+�5      �� $��Center=�6(   $��Center=�6E   $��
Bookdate: ��6`   $��20(�6r   $��0q�6�   �� 5      -   5         ��Name$ Bookdate��5   (   $��Center=�6:   $��Center=�6W   $��bookdate��6r   $��20(�6�   $��0q�6�   5      �� 5      $��5q�6%   ���	#FFE8F9F3.+�5      �� $  
Horizontal=�6)   .+�5   "   �� $��5q�6-   $	��400��68   
�������.+�5   &   �� $��Center=�60   $��Center=�6M   $
��From��6h   $��20(�6t   $��0q�6�   �� 5   &   $  
Horizontal=�61   $��Center=�6J   .+�5   *   �� -   5        $ 
DepAirport��5   4   $��Center=�6H   $��Center=�6e   $��
DepAirport��6�   $��20(�6�   $��0,0,10,0q�6�   �� 5   *   -   5        $ DepCity��5   4   $��Center=�6E   $��Center=�6b   $��DepCity��6}   $��20(�6�   $��10,0,0,0q�6�   5   '   �� 5   &   -   5        $ DepTime��5   0   $��Center=�6A   $��Center=�6^   $��DepTime��6y   $��20(�6�   $��0q�6�   5   #   �� 5   "   $��5q�6-   $	��400��68   
�������.+�5   &   �� $��Center=�60   $��Center=�6M   $��To��6h   $��20(�6r   $��0q�6�   �� 5   &   $  
Horizontal=�61   $��Center=�6J   .+�5    *   �� -   5        $ 
ArrAirport��5    4   $��Center=�6H   $��Center=�6e   $��
ArrAirport��6�   $��20(�6�   $��0,0,10,0q�6�   �� 5!   *   -   5        $ ArrCity��5!   4   $��Center=�6E   $��Center=�6b   $��ArrCity��6}   $��20(�6�   $��10,0,0,0q�6�   5"   '   �� 5#   &   -	   5        $ ArrTime��5#   0   $��Center=�6A   $��Center=�6^   $��ArrTime��6y   $��20(�6�   $��0q�6�   5$   #   5%      �� 5&      $  
Horizontal=�6)   $��Center=�6B   .+�5'   "   �� $��Center=�6,   $��Center=�6I   $��Model      ��6d   $��20(�6w   $��0q�6�   �� 5(   "   -
   5        $ Model��5(   ,   $��Center=�6;   $��Center=�6X   $��Model��6s   $��20(�6�   $��0q�6�   �� 5)   "   -   5        $ 	Flight_Id��5)   ,   $y�	Collapsed=�6@   5*      5+      �� 5,      .+�5-      �� $  
Horizontal=�6)   $	��600��6B   $��Center=�6N   $��Center=�6k   .+�5.   "   �� $  
Horizontal=�6-   $	��200��6F   .+�5/   &   �� $
��Left=�60   $��Center=�6K   $��SeatNo: ��6f   $��20(�6v   $��0q�6�   $	��100��6�   �� 50   &   -   5        $ SeatNo��50   0   $
��Left=�6@   $��Center=�6[   $��SeatNo��6v   $��20(�6�   $��0q�6�   $	��100��6�   51   #   �� 52   "   $  
Horizontal=�6-   $	��200��6F   .+�53   &   �� $
��Left=�60   $��Center=�6K   $��Class:��6f   $��20(�6t   $��0q�6�   $	��100��6�   �� 54   &   -   5        $ Class��54   0   $
��Left=�6?   $��Center=�6Z   $��Class��6u   $��20(�6�   $��0q�6�   $	��100��6�   55   #   �� 56   "   $  
Horizontal=�6-   $	��200��6F   .+�57   &   �� $
��Left=�60   $��Center=�6K   $��Price:��6f   $��20(�6t   $��0q�6�   $	��100��6�   �� 58   &   -   5        $ Price��58   0   $
��Left=�6?   $��Center=�6Z   $��Price��6u   $��20(�6�   $��0q�6�   $	��100��6�   59   #   5:      5;      5<      5=      5>      �� 5?      $��10 0 0 0q�6   .+�5@      �� -   5         ��Name$ DelBook��5@       &  "MaterialDesignFloatingActionButton#���   6@   $��18(�6}   $��Center=�6�   ���#FF9800$��Right=�6�   $��52��6�   $��53��6�   $��0 20 0 0q�6�   .��5A      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Trashcan=�6.   
�������$��36��6Q   $��36��6\   $��Center=�6h   $��Center=�6�   $��Center=�6�   $��Bottom=�6�    � ToolTip 5B      _� 5C       _� 	Placement$ Mouse=�6"   .��64   Remove from bookings5E      5G      �� 5H      -   5        $ 	BuyTicket��5H      $��0 40 0 0q�6,   #���   6V   $��18(�6�   $��Center=�6�   ���#FF9800$��Right=�6�   $��52��6�   $��53��6�    5I      _� 5J      $ Mouse=�6"   $��
Buy ticket��64   .��5L      �� $  
Horizontal=�6!   .+�5M        $ Ticket=�62   $��5 0 -5 0q�6@   
�������$��25��6e   $��25��6p   $��Center=�6|   $��Center=�6�   $��Center=�6�   $��Bottom=�6�     5N      $
 Plus=�62   
�������$��25��6Q   $��25��6\   $��Center=�6h   $��Center=�6�   $��Center=�6�   $��Bottom=�6�   $
��Bold"�6�   5O      5P      5Q      5R      5S      5T      