   M S B A M L   `   `   `  ����@  <Janek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Janek.ToolsJanek.Tools  5   	   3clr-namespace:Janek.PropertiesJanek.Properties  5   	   clr-namespace:JanekJanek  5   	       Janek.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @i2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Dint:http://schemas.microsoft.com/expression/2010/interactivity  5   	   %toolsclr-namespace:Janek.Tools  5   	   /
propertiesclr-namespace:Janek.Properties  5   	   janekclr-namespace:Janek  5   	     � Title$  
MainWindow��5
   	   $	��550��6   $	��525��6)   {�65   �� *SetEnableWindow+ � 	Resources 5       �� MergedDictionaries �� Source!   Janek.Tools.HeightConverter   HC  ListTemplate �� DataType�� 5   
    5      �� 5      $ /Style/Style.xaml?�6%   6B   %�   &	        &	        5      6$   �� 5      $ 	TextBlock��60   .R�5      �� �� 5      
����+���6   �� *Meat+6F   5      5      5      .��5      � 
����ح� � RowDefinitions 5   
   �� 5      $��50 �6   5      �� 5      $��* �6   6*   �� 5      $��* �6   6*    � ColumnDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $	��100 �6   .+�5%   
   � $��0��6   $��2��6   
�������.+�5&      �� $"��Witamy u Niechlujenego Janka��6     TextBoxHeader#��[ 6<   6e   5'      �� 5(   
   -   5         ��Name$ pageLayoutStackPanel��5(   6   $��1��6   $��2��6"   $
��20,0q�6T   .+�5)      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,20q�62   .+�5*      �� $��0,0,20,0q�6   .+�5+      �� $��Wielkość menu��6    67   �� 5,      $
��Left=�6   $��82��6e   $y�Visible=�6p   ��69   �� *NumberOfItems+	 �� Mode$	 TwoWay=�6p   5.      �� 5/      -   5        $��generujMenu��5/      $	��100��6,   $��20��68   $��Wygeneruj Menu��6E   $��0,0,20,0q�6^   .  (System.Windows.Interactivity.Interaction
   Triggers
 50      /  )System.Windows.Interactivity.EventTrigger  51         	EventName$ Click��6+   .  (System.Windows.Interactivity.TriggerBase   Actions. 52      6  0System.Windows.Interactivity.InvokeCommandAction     Command 66   �� *buttonClickCommand+   CommandParameter 53   :   ��  �� ElementName$ generujMenu�� �� Path$ Height�54      57      58      �� 59      $��2��6   .+�5:      �  5;      �� 5<      $	��425 �6+   �� 5=      $��* �6+   .+�5@      �� $��0��6   $��
0,10,100,0q�6M   $	��124��6a   ��60   �� *Menu+ �� SelectedItem 6n   �� *SelectedMeal+
 5A        5B      $ SelectionChanged��6/   . 5C   "      6:   �� *SelectionChangedCommand+6h   5D      5F      �� 5G      $��1��6    �� CornerRadius$	 180��5H       
���   �$��1q�5J   !   ��5L       ��  �� RelativeSource �� *Self+$ ActualWidth���5M   !   �� *bubbleHeight+ �� 	Converter# [   �� ConverterParameter �� *Self+5N      5O      5P      �� 5Q      ��6   �� *GeneratedDate+69   5S      �� 5T   
   $��2��6   $��2��6"   .+�5U      �� $%��Round and round the ragged rock��6   $��WordEllipsis=�5V      $	��150��5W      5X      �� 5Y      -   5         ��Name$ 
ChangeSize��5Y       � Maximum$	 100Q�6)    � Minimum$ 0Q�67   
���   �6[   �� 5\      $	 180��6   
������
���   �$��0q�5a      ��5]      �� $ 
ChangeSize��$ Value���5^      ��  �� *Self+$ ActualHeight�._�5b      (�  (� StretchDirection$
 Both=�6   $��Center=�62   $��Center=�6M   .��5c      �� #��[ 6    $��Center=�6G   $��Center=�6d   30005e      5f      5g      �� 5i      #��[ 6   ��6?   �� *	ReadyText+6\   �� 5j      -   5        $��StartAnimation��5j      $	��100��6+   $��20��67   $��Uruchom��6D   $��0,0,20,0q�6V   
 5k        5l      $ Click��6'   . 5m         62   �� *buttonStartAnimationsCommand+5o      5q      5�      5�      5�      