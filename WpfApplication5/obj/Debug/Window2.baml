   M S B A M L   `   `   `  ����J  FWpfApplication5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication5WpfApplication5  5   	   o kMicrosoft.Expression.Prototyping.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�iclr-namespace:Microsoft.Expression.Prototyping.Branding;assembly=Microsoft.Expression.Prototyping.Runtime)Microsoft.Expression.Prototyping.Branding 5
   	       WpfApplication5.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication5     5   	   V ROxyPlot.Wpf, Version=2013.1.38.1, Culture=neutral, PublicKeyToken=75e952ba404cdbb0%oxyhttp://oxyplot.codeplex.com  5   	   xBrandingiclr-namespace:Microsoft.Expression.Prototyping.Branding;assembly=Microsoft.Expression.Prototyping.Runtime  5
   	     � Title$  Window2��5   	   $	��540��6   $	��960��6&   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��163* �6   �� 5      $
��313* �6   .+�5   
     OxyPlot.Wpf.Plot  -   5          Name$ Plot1��5         Title$ A Graph��6"   $��Right=�6N   $	��561��6j   $��
0,10,10,40q�6v   $��1��6�      Model 62   �� *	PlotModel+6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgUsers��5         AutoGenerateColumns .  $��-2,65,583,0q�6>    J� RenderTransformOrigin$ 0.5,0.5&�6S   $��2��6s   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.368Q�6&   T� 5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Lp��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Lp+  5      $	 
Id procesu��6%   
 69   �� *Id+  5       $	 Nzawa procesu��6%   
 6<   �� *Name+  5!      $	 Czas[s]��6%   
 66   �� *Czas+  5"      $	 Procent udziału��6%   
 6>   �� *	Procent+5$      �� 5%   
   -   5         ��Name$ button��5%      $��Ok��6!   $
��Left=�6.   $	��Top=�6I   $��72��6a   $��
209,32,0,0q�6l   $��26��6�   6�   �� 5&   
   -   5         ��Name$ 	TextBoxDo��5&      $
��Left=�6%   $��26��6@    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��110��6x   $ 2.726,1.669&�6�   $��	61,32,0,0q�6�   �� 5'   
   -   5         ��Name$ label1��5'      $4��.Czasu pracy programu(czas podać w sekundach):��6    $
��Left=�6X   $	��Top=�6s   $��19,1,0,0q�6�   $��26��6�   $	��326��6�   $��2��6�   �� 5(   
   -   5        $ label��5(      $��Czas działania programu:��6   $
��Left=�6B   $	��Top=�6]   $��369,474,0,0q�6u   $��1��6�   �� 5)   
   -   5        $ textBox��5)      $
��Left=�6#   $��23��6>   $
 Wrap=�6J   $	��Top=�6^   $	��104��6v   $��1��6�   $��512,478,0,0q�6�   5*      5,      