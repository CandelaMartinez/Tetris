   M S B A M L   `   `   `  ����A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TetrisTetris  5   	       Tetris.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Tetris     5   	   -   5          � Title$  Tetris��5   	   $	��600��6   $	��800��6%   $	��600��5	   	   $	��800��6   
�������$��Segoe UI Light)�5   	   $��28(�6%   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   ��5   
   �� 5       �� ImageSource$ Assets/Background.png��6   .+�5   
   (� $��1��6   $��1��5      $��0,0,0,20q�5       .��5"      �� -   5         ��Name$ 
GameCanvas��5"      ���#101010$	��250��5$      $	��510��5%      $
}�True��5&      5'      5*      �� 5,   
   -   5         ��Name$ 	ScoreText��5,      $��0��5-      $��1��5.      $��Score:��5/      $
��0,10q�50       �� TextAlignment$ Center=�51      �� 54   
   $��1��6   $��0��55      $��Center=�56      $��Right=�57      .+�58      �� $
��Hold��6   $ Center=�59       �� 5;      -   5         ��Name$ 	HoldImage��5;      $��20q�5<      $	��125��5=      5>      �� 5@   
   $��1��6   $��2��5A      $��Center=�5B      $
��Left=�5C      .+�5D      �� $
��Next��6   $ Center=�5E      �� 5F      -   5        $ 	NextImage��5F      $��20q�5G      $	��125��5H      5I      � 5L   
   -   5         �Name$ GameOverMenu��5L      ���	#CC000000$��2��5N      $��3��5O      $y�Hidden=�5P      .+�5R      �� $��Center=�6   $��Center=�5S      .+�5T      �� $��	Game Over��6   $��48(�5U      $ Center=�5V      �� 5X      -   5        $ FinalScoreText��5X      $��Score��5Y      $��36(�5Z      $ Center=�5[      �� 5]      -   5        $��
Play Again��5]      
������$��0,20,0,0q�5_      $��5q�5`      5a      5c      5e      5h      5i      