   M S B A M L   `   `   `  ����@  <Pract, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Pract.WindowsPract.Windows  5   	   )clr-namespace:Pract.toolsPract.tools  64       Pract.Windows.Cooker   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Pract.Windows     5   	   0
viewmodelsclr-namespace:Pract.tools     64     � Title$  
Повар��5   	   $	��450��6   $
��1080��6$   $
��1920��65   $	��450��6E   $	��800��6U   $	��800��6d    � 	Resources 5	      !   Pract.tools.CookerViewModel   vm��%   &	          5
   
   62   5       � DataContext 5      �� 5   
    �� Source# [  6   61   .��5      � $��10q�6   ��5   
   �� 5       �� ImageSource$ /Windows/thumb.png��6    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5      $
��135* �6   �� 5      $
��277* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $
��119* �6   �� 5      $
��657* �6   �� 5      $��4* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ProductItem��5   �   $��Center=�6   $	��400��61   $��	10,10,0,0q�6>   $��Center=�6q   $	��641��6�      AutoGenerateColumns$ False��6�   $��1��6�   $��3��6�    �� SelectedItem 6Q   �� *LotsOf+��6�   �� *Orders+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	OrderId+4  .System.Windows.Controls.DataGridComboBoxColumn  5!      $
 Status��6)   $ * 69      DisplayMemberPath$ 
StatusCook��6�      ItemsSource 6C   �� *Cooks+# [     SelectedItemBinding 6}   �� *StatusCooker+6�      RowDetailsTemplate 5$      �� 5%      .R�5&      �� ��6   �� *	LotsOfs+��5'      �� 5(      .R�5)   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5*   &   �� $��5q�6N   ��60   �� *Product.Name+6[   �� 5+   &   $�� Время - ��60   $��5q�6A   6N   �� 5,   &   $��5q�6N   ��60   �� *Product.Time+6[   �� 5-   &   $�� Количество - ��60   $��5q�6F   6S   �� 5.   &   $��5q�6G   ��60   �� *Count+6T   5/   #   50      52      53      55      �� 56   
   -   5        $#��Изменить статус��56      $��Center=�6F   $��	16,26,0,0q�6c   $��Center=�6v   $��90��6�   $��92��6�   $��2��6�   ��6+   �� *Izmena+6�   59      5:      