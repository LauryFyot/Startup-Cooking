   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      .    (ProjetNotrePetiteCuisine.GUI.Pages.Order   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Order��5
       � 	Resources 5       �� 
TargetType   RoundButton �� Property �� Value �� 
TargetType �� CornerRadius ��Name��%�  &	        �� 5   
   " ��6   .�5      ��  � �� �#FE65606+   �� 5       �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 15��6!   ���#FE6560���#ccc._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5"   
   � $��1��6   .+�5#      �� $����C:\Users\ostov\Downloads\ProjetNotrePetiteCuisine\ProjetNotrePetiteCuisine\ProjetNotrePetiteCuisine\Resources\img\fennel-yogurt-dip-2-Basically.jpg��6   $��UniformToFill=�6�   $��Center=�6�   5$      � 5&   
   .+�5'      �� -   5        	 ��Name$	 	Precedent��5'   �   $��50��6   $��50��6    $	��Top=�6,   $
��Left=�6D   
������ 
������ .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��6*   $��25��65   
   Kind$
 	ArrowBack=�6A   
���   �$��Center=�6e   $��Center=�6�   5)      �� 5*      $��30,10q�6   .+�5+      �� $��Notre petite Cuisine.��6   $��35(�69   $��0,20,0,0q�6G   $��MADE GoodTime Grotesk)�6Y   $	��Top=�6|   $��Center=�6�   �� 5,      $��Commande��6   $��25(�6,   $��MADE GoodTime Grotesk)�6:   $��Center=�6]   $��Center=�6z   $
��0,10q�6�   �� 5-      $��0��6   $��0,20,0,0q�6-   .+�5/      &   System.Windows.Controls.DataGrid  -   5          Name$ RecipeCartDatagrid��5/      $
��Left=�6;    � Cursor$
 Hand��6n   $	��200��6|   $	��550��6�      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6�      
IsReadOnly . ��6V   ��    Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 400 6V      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Key+6b     52      $
 Qté��61   $
 Auto 6X   
 �   � 6>   �� *Value+6e   54      � 55       56      �� 57      $��1* �6/   �� 58      $��1* �6/   .+�5:      � $��0��6   .+�5;      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5<   "   ;	  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect	  5=   &    	  Kind$ SlideInFromLeft=�6F    	  Duration$ 0:0:0.8h�6]   .��5?   "   ��  �� Orientation$ 
Horizontal=�6-   $��50��6F   .+�5@   &     $��0,20,0,0q�6>   $
 GpsFixed=�6P   $��30��6`   $��30��6k   �� 5A   &   -   5         ��Name$ AddressTextBox��5A   B   
���   �$��	10,20,0,0q�6Z   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ ADDRESS��6m   $��15(�6�    �� TextWrapping$
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   � 
  
HelperText$ ADRESSE DE LIVRAISON��6�   5B   #   5C      5D      � 5E      $��1��6   .+�5F      �� $ 
Horizontal=�6)   $	��Top=�6B   $��Right=�6Z   $��0,0,50,0q�6v   .+�5G   "   �� $��Total :��6,   $��0,0,10,0q�6;   
���   �$��16(�6`   $��Segoe UI Light)�6n   �� 5H   "   -   5         ��Name$ 
TotalPrice��5H   ,   
���   �$��16(�6S   $��Segoe UI Light)�6a   �� 5I   "   $��cooks��6,   $��	10,0,10,0q�69   
���   �$��16(�6_   $��Segoe UI Light)�6m   5J      �� 5K      $ 
Horizontal=�6)   $��Bottom=�6B   $��Right=�6]   $��0,0,50,0q�6y   .+�5L   "   �� $��Après déduction :��6,   $��0,0,10,0q�6E   
���   �$��16(�6j   $��Segoe UI Light)�6x   �� 5M   "   -   5        $ TotalPriceAfterDeduction��5M   ,   
���   �$��16(�6a   $��Segoe UI Light)�6o   �� 5N   "   $��cooks��6,   $��	10,0,10,0q�69   
���   �$��16(�6_   $��Segoe UI Light)�6m   5O      5P      5Q        5R       5S      	  5T      $ SlideInFromRight=�6>   $ 0:0:0.8h�6V   .��5V      �  5W      �� 5X   "   $��1* �63   �� 5Y   "   $��1* �63   .+�5[      � $��0��6#   .+�5\   "      5]   &   	  5^   *   $ SlideInFromRight=�6J   $ 0:0:0.8h�6b   .��5`   &   �� $ 
Horizontal=�61   $��50��6J   .+�5a   *     $��0,20,0,0q�6B   $
 AddLocation=�6T   $��30��6g   $��30��6r   �� 5b   *   -   5        $ PostalCodeTextBox��5b   F   
���   �$��	10,20,0,0q�6�   $ POSTAL CODE��6�   $��15(�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6  5c   '   5d   #   5e      � 5f      $��1��6#   .+�5g   "      5h   &   	  5i   *   $ SlideInFromRight=�6J   $ 0:0:0.8h�6b   .��5k   &   �� $ 
Horizontal=�61   $��50��6J   .+�5l   *     $��0,20,0,0q�6B   $
 LocationCity=�6T   $��30��6h   $��30��6s   �� 5m   *   -   5        $ CityTextBox��5m   F   
���   �$��	10,20,0,0q�6[   $
 CITY��6n   $��15(�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5n   '   5o   #   5p      5q      5r      �� 5s      -   5        $��OrderButton��5s   �   $
 Hand��6   #��[  6@   $��MADE GoodTime Grotesk)�6e   $��13(�6�   $��Payer !��6�   
���   �$��35��6�   $	��200��6�   $��Center=�6�   $��Bottom=�6  $
��0,40q�6  5t      5u      5v      5y      5z      