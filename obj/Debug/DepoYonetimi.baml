   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   @ <DYSis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DYSisDYSis 5   	      DYSis.DepoYonetimi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   %localclr-namespace:DYSis     5   	     � Title$#  Canesis Depo Yönetim Sistemi��5	   	   $	��400��6.   $	��820��6;    � 
ResizeMode$ NoResize=�6G    � Icon$ canesis.jpg��6]   .��5
      � .+�5   
   #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6A   $	��200��6W   $	��100��6c   $��Center=�6p   $	��Top=�6�   $��163,10,450.6,0q�6�      Series 6   �� *SeriesCollection+   AxisX 5         LiveCharts.Wpf.Axis     Title$ Malzeme Adı��6      Labels 6/   �� *Labels+6L      AxisY 5        $
 Adet��6    6(   �� *Labels+6D   5      �� 5   
   -   5        	 ��Name$	 AButton��5      $��Anasayfa��6"   $
��Left=�65   $��	10,40,0,0q�6P   $	��Top=�6c   $	��120��6{   $��40��6�   6�   �� 5   
   -   5        $	 DYButton��5      $��Depo Yönetimi��6#   $
��Left=�6;   $��	10,80,0,0q�6V   $	��Top=�6i   $	��120��6�   $��40��6�   6�   �� 5   
   -   5        $	 EYButton��5      $��Envanter Yönetimi��6#   $
��Left=�6?   $��
10,120,0,0q�6Z   $	��Top=�6n   $	��120��6�   $��40��6�   6�   �� 5   
   -   5        $	 DepoGirdiButton��5      $
��Left=�6*   $��
599,40,0,0q�6E   $	��Top=�6Y   $	��120��6q   $��40��6}   .��5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5      �� $<��6C:\Users\nigbu\source\repos\DYSis\shopping_cartpng.png��6   $��40��6X   $��40��6c   �� 5      $��   Depo Giriş��6   $��Center=�61   5      5      �� 5   
   $��Depo Yönetimi��6   $
��Left=�6(   $��20,9,0,0q�6C   $	��Top=�6U   $	��650��6m   $
��Bold"�6y   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ dg��5       $
��Left=�6   $	��200��6:   $��160,120,0,0q�6G   $	��Top=�6\   $	��616��6t   ��6�   �� 5"      �� 5#   
   -   5        $	 DepoGirdiButton_Copy��5#      $
��Left=�6/   $��
599,40,0,0q�6J   $	��Top=�6^   $	��120��6v   $��40��6�   .��5$      �� $
 
Horizontal=�6   .+�5%      �� $<��6C:\Users\nigbu\source\repos\DYSis\shopping_cartpng.png��6   $��40��6X   $��40��6c   �� 5&      $��   Depo Giriş��6   $��Center=�61   5'      5(      �� 5)   
   -   5        $
��Left=�5)      $��
465,40,0,0q�6,   $	��Top=�6@   $	��120��6X   $��40��6d   .��5*      �� $
 
Horizontal=�6   .+�5+      �� $4��.C:\Users\nigbu\source\repos\DYSis\exiticon.png��6   $��35��6P   $��38��6[   �� 5,      $��Depo Çıkış��6   $��Center=�6.   5-      5.      �� 5/   
   $��10,286,683.6,22.4q�6   $��canesis.jpg��6+   $
��Fill=�6@   53      54      