   M S B A M L   `   `   `  ����C  ?Cafe.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Cafe.AppCafe.App  5   	       Cafe.App.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Cafe.App     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��433* �6   .+�5   
   G� -   5        $��
PbPassword��5      $��1��6(   $��Center=�68   $��	0,190,0,0q�6U   $��1��6h   $	��Top=�6u   $	��120��6�   �� 5   
   $��1��6.   $��Center=�6>   $��	0,127,0,0q�6[   $��1��6n    �� TextWrapping$
 Wrap=�6{   $	��Top=�6�   $	��120��6�   ��6   �� *
User.Login+6�   �� 5   
   $��1��6   $��Center=�6$   $��0,39,0,0q�6A   $��1��6S   $
��Wrap=�6`   $	��Top=�6t   �� 6�    � Language$ ru-ru�6�   $�Авторизация��6�   6�   �� 5   
   $��1��6   $
��Left=�6$   $��
94,127,0,0q�6?   $��1��6S   $
��Wrap=�6`   $	��Top=�6t   $��Логин:��6�   �� 5   
   $��1��6   $
��Left=�6$   $��
86,190,0,0q�6?   $��1��6S   $
��Wrap=�6`   $	��Top=�6t   �� 6�   $ ru-ru�6�   $�Пароль:��6�   6�   �� 5   
   $��1��62   $��Enter��6B   $��Center=�6�   $��	0,229,0,0q�6�   $��1��6�   $	��Top=�6�   
���   �
���  ��$��KentuckyFriedChickenFont)�6   $��14(�6&  ��6   �� *LoginCommand+��6R   ��  �� ElementName$ 
PbPassword��6&  �� 5   
   $��Center=�6   $	��390��6-   $��	0,106,0,0q�6:   $��1��6M   $	��Top=�6Z   $	��390��6r   $��/Image2.png��6~   5      5      