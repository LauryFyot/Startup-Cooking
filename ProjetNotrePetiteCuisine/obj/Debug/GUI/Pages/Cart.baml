   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      -    'ProjetNotrePetiteCuisine.GUI.Pages.Cart   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$
  Cart��5
       � 	Resources 5       �� 
TargetType   RoundButton �� Property �� Value �� 
TargetType �� CornerRadius ��Name��%�  &	        �� 5   
   " ��6   .�5      ��  � �� �#FE65606+   �� 5       �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 15��6!   ���#FE6560���#ccc._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5"   
   � $��1��6   .+�5#      �� $F��@pack://application:,,,/Resources/img/HLY-FGFP-Kale-Pesto-1x1.jpg��6   $��UniformToFill=�6^   $��Right=�6v   5$      � 5'   
   $��20q�6   .+�5(      �� .+�5)      �� $��Notre petite Cuisine.��6   $��40(�69   $��0,0,0,10q�6G   $��MADE GoodTime Grotesk)�6Y   $	��Top=�6|   $��Center=�6�   �� 5*      $��Votre panier��6   $��25(�60   $��MADE GoodTime Grotesk)�6>   $��Center=�6a   $��Center=�6~   � 5,      $��0,20,0,0q�6    5-      �� 5.      $��2* �6+   �� 5/      $��1* �6+   .+�52      � $��0��6   .+�53      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 RecipeCartDatagrid��53   #   
 � Cursor$

 Hand��6W   $	��350��6e   $	��450��6r      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6�      
IsReadOnly . ��6?   ��    Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55   "   ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6Z      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Key+6f     56   "   $
 Qté��65   $
 Auto 6\   
 �   � 6B   �� *Value+6i   58      59      � 5:      $��1��6   .+�5;      �� $��Center=�6%   $��Center=�6@   .+�5<      �� -   5         ��Name$ Increase��5<   %   $��25��6O   $��25��6Z   
������� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6}   
������ $��Right=�6�   $��20q�6�   .��5=   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6:   
���   �$

 Hand��6X   $��20��6f   $��20��6q   $��Center=�6}   $��Center=�6�   5>      �� 5?      -   5        $ 	Supprimer��5?   %   $��25��6Q   $��25��6\   
�������#��[ 6   
������ $��Right=�6�   $��20q�6�   .��5@   "     $ DeleteOutline=�6:   
���   �$

 Hand��6b   $��16��6p   $��16��6{   $��Center=�6�   $��Center=�6�   5A      �� 5B      -   5        $ Decrease��5B   %   $��25��6O   $��25��6Z   
�������#��[ 6}   
������ $��Right=�6�   $��20q�6�   .��5C   "     $ Minus=�6:   
���   �$

 Hand��6Z   $��15��6h   $��15��6s   $��Center=�6   $��Center=�6�   5D      5E      �� 5F      $��Bottom=�6%   $��Center=�6@   .+�5G      ��  �� Orientation$ 
Horizontal=�6)   $	��Top=�6B   $��Center=�6Z   .+�5H   "   �� $��Total :��6,   $��0,0,10,0q�6;   
���   �$��16(�6`   $��Segoe UI Light)�6n   �� 5I   "   -   5         ��Name$ 
TotalPrice��5I   ,   
���   �$��16(�6S   $��Segoe UI Light)�6a   �� 5J   "   $��cooks��6,   $��	10,0,10,0q�69   
���   �$��16(�6_   $��Segoe UI Light)�6m   5K      �� 5L      $ 
Horizontal=�6)   $��Bottom=�6B   $��Center=�6]   .+�5M   "   �� $��Après déduction :��6,   $��0,0,10,0q�6E   
���   �$��16(�6j   $��Segoe UI Light)�6x   �� 5N   "   -   5        $ TotalPriceAfterDeduction��5N   ,   
���   �$��16(�6a   $��Segoe UI Light)�6o   �� 5O   "   $��cooks��6,   $��	10,0,10,0q�69   
���   �$��16(�6_   $��Segoe UI Light)�6m   5P      5Q      5R      5S      �� 5T      -   5        $ OrderButton��5T      $

 Hand��6.   #��[  6Q   $��MADE GoodTime Grotesk)�6v   $��13(�6�   $��Commander !��6�   
���   �$��35��6�   $	��200��6�   $��Center=�6�   $��Bottom=�6  $
��0,40q�6!  5U      5V      5W      5X      