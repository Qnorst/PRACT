   M S B A M L   `   `   `  ����C  ?Cafe.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Cafe.AppCafe.App  5   	       Cafe.App.OrderList   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Cafe.App     5   	     � Title$  	OrderList��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   �� $	��434��6   $	��Top=�6"   $��2��6:    J� RenderTransformOrigin$ 0.502,0.495&�6N   .@�5      �� $��Заказы��6   .��5      � ���	#FFE5E5E5$ 0.447,0.503&�6.    5      �� 5      �� 5      .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
OrdersGrid��5   /      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      
IsReadOnly$
 True��6A      AutoGenerateColumns$ False��6n   $��0,0,67,0q�6�    �� SelectedItem 6S   �� *.+��6�   �� *Orders+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Заказ��61   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� *Id+6Y     5      $ Статус блюда��61   
   
IsReadOnly$
 False��6G   	 6Z   �� *CookerStatus+6}     5      $ Статус заказа��61   $
 False��6H   	 6[   �� *WaiterStatus+6~   5        5      $ * 6   $
 True��6/   $ False��6_   $��2��6�   $��	330,0,0,0q�6�    6A   �� *Dish+��6{   ��  �� ElementName$ 
OrdersGrid�� �� Path$ SelectedItem.DishOrders� 5        5      $ 
Блюдо��61   	 6@   �� *
Dish.Title+6a     5       $ Стоимость��61   	 6D   �� *
Dish.Price+6e     5!      $+ %Время приготовления��61   	 6N   �� *	Dish.Time+6n   5#      5$      5%      �� 5&      $&�� Работа с заказами��6>   y�6   �� *WaiterVisibility+.��5'      �  5(      �� 5)      �� 5*      .+�5,      �� $��0��6;   $!��Добавить заказ��6K   $	��Top=�6�   
���   ����	#FFAB9C9C$��KentuckyFriedChickenFont)�6�   $��14(�6  $��10,102,629,0q�6  $��2��6%  ��6   �� *	User.Role+��6d   �� $ 
PbPassword��6%  �� 5-      $��0��6;   $0��*Изменить статус заказа��6K   $	��Top=�6�   
���   ����	#FFAB9C9C$��KentuckyFriedChickenFont)�6�   $��14(�6	  $��10,138,629,0q�6  $��2��6-  ��6   �� *	User.Role+��6l   �� $ 
PbPassword��6-    5.      -   5        $��OrdersGrid1��5.   /   $ * 6   $
 True��6B   $ False��6o   $��0,0,10,0q�6�   $��1��6�    6T   �� *.+��6�   �� *Orders+ 5/        50      $ 
Заказ��61   	 6@   �� *Id+6Y     51      $ Статус блюда��61   $
 False��6G   	 6Z   �� *CookerStatus+6}     52      $ Статус заказа��61   $
 False��6H   	 6[   �� *WaiterStatus+6~   54      55      56      �� 57      $$��Работа с блюдами��6>   y�6   �� *FlunkyVisibility+.��58      �  59      �� 5:      �� 5;      .+�5=      �� $��0��6;   $0��*Изменить статус заказа��6K   $	��Top=�6�   
���   ����	#FFAB9C9C$��KentuckyFriedChickenFont)�6�   $��14(�6	  $��10,138,629,0q�6  ��6   �� *	User.Role+��6l   �� $ 
PbPassword��6    5>      -   5        $��OrdersGrid2��5>   /   $ * 6   $
 True��6B   $ False��6o   $��0,0,10,0q�6�   $��1��6�    6T   �� *.+��6�   �� *Orders+ 5?        5@      $ 
Заказ��61   	 6@   �� *Id+6Y     5A      $ Статус блюда��61   $
 False��6G   	 6Z   �� *CookerStatus+6}     5B      $ Статус заказа��61   $
 False��6H   	 6[   �� *WaiterStatus+6~   5D      5E      5F      5G      5H      5I      