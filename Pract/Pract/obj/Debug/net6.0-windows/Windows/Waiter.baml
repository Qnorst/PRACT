   M S B A M L   `   `   `  ����@  <Pract, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PractPract  5   	   )clr-namespace:Pract.toolsPract.tools  6+       Pract.Waiter   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Pract     5   	   0
viewmodelsclr-namespace:Pract.tools     6+     � Title$  Window1��5   	   $	��450��6   $
��1080��6&   $
��1920��67   $	��450��6G   $	��800��6W   $	��800��6f    � 	Resources 5	      !  Pract.tools.WaiterViewModel   vm��%   &	          5
   
   62   5      ��5      �� 5   
    �� ImageSource$ /Windows/thumb1.png��6    � DataContext 5      �� 5   
    �� Source# [  6   61   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $
��153* �6   �� 5      $
��141* �6   �� 5      $	��85* �6   �� 5      $
��213* �6   �� 5      $
��177* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $	��23* �6   �� 5      $	��68* �6   �� 5      $
��323* �6   .+�5!   
   &   System.Windows.Controls.DataGrid  -   5        $��ProductItem��5!   �   $��Center=�6   $	��287��61   $��Center=�6^   $	��760��6y      AutoGenerateColumns$ False��6�   $��2��6�   $��1��6�   $��5��6�   $��2,0,0,0q�6   �� SelectedItem 6>   �� *LotsOf+��6�   �� *Orders+	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	OrderId+4  .System.Windows.Controls.DataGridComboBoxColumn  5$      $
 Status��6)   $ * 69      DisplayMemberPath$ StatusPaymentOrder��6�      ItemsSource 6C   �� *Waites+# [     SelectedItemBinding 6~   �� *StatusWaiter+6�     5%      $
 Payment��6%   $ * 66    6@   �� *	Payment+   RowDetailsTemplate 5(      �� 5)      .R�5*      �� ��6   �� *	LotsOfs+��5+      �� 5,      .R�5-   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5.   &   �� $��5q�6N   ��60   �� *Product.Name+6[   �� 5/   &   $�� Количество - ��60   $��5q�6F   6S   �� 50   &   $��5q�6G   ��60   �� *Count+6T   52   #   53      55      56      58      �� 5:   
   $!��Добавить заказ��6   $��Center=�6J   $��8,0,0,0q�6g   $��Center=�6x   $��48��6�   $	��128��6�   $��16(�6�   $��2��6�   $��1��6�   ��6*   �� *CreateOrder+6�   �� 5;   
   -   5        $��Изменить��5;      $��Center=�6@   $��10,0,0,0q�6]   $��Center=�6o   $��45��6�   $	��128��6�   $��1��6�   $��1��6�   ��6$   �� *	Izmenik+6�   �� 5<   
   $��Center=�6    �� DisplayMemberPath$
 Name��6u   $��5,0,0,0q�6�   $��Center=�6�   $	��198��6�   $��45��6�   $��4��6�   $��1��6�   ��60   �� *
Products+ 6R   �� *	Producted+6�   �� 5=   
   $%��добавить продукт��6   $��Center=�6L   $��Center=�6i   $��48��6�   $��16(�6�   $	��166��6�   $��5��6�   $��1��6�   ��6,   �� *AddPosition+6�   �� 5>   
   $��Center=�6    �� TextWrapping$
 Wrap=�6F   $��Center=�6Z   $��71��6u   $��45��6�   $��16(�6�   $��3��6�   $��1��6�   ��6/   �� *Count+6�   5?      5@      