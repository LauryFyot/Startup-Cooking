   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ProjetNotrePetiteCuisine.GUI.Windows$ProjetNotrePetiteCuisine.GUI.Windows  5   	   6    0ProjetNotrePetiteCuisine.GUI.Windows.Proposition   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:ProjetNotrePetiteCuisine.GUI.Windows     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Proposition��5	   	   $	��650��6   $	��700��6*    � WindowStartupLocation$ CenterScreen=�5
   	    � Icon$8 2pack://application:,,,/Resources/img/chef_icon.png��5   	    � 	Resources 5       �� 
TargetType   RoundButton2 �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name��%�  &	        �� 5   
   " ��6   .�5      ��  � �� �#FE65606+   �� 5       �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 15��6!   ���#FE6560���#ccc._�5      �� $	 contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      5      .��5      � .+�5   
   � $��40,20q�6   .+�5      �� .+�5       �� $��Notre petite Cuisine.��6   $��40(�69   $��0,0,0,10q�6G   $��MADE GoodTime Grotesk)�6Y   $	��Top=�6|   $��Center=�6�   �� 5!      $��Proposer une recette��6   $��25(�68   $��MADE GoodTime Grotesk)�6F   $��Center=�6i   $��Center=�6�   � 5"      $��0,10,0,0q�6   
 � ColumnDefinitions
 5#      �� 5$      $��3* �6+   �� 5%      $��1* �6+   .+�5'      � $��1��6   .+�5(      �� $	��100��6!   $	��100��6-   $ 80��6:   $
��Left=�6L   ._�5)      � .+�5*   "   �� $8��2pack://application:,,,/Resources/img/chef_icon.png��6(   5+      5,      5-      � 5.      $��0��6   .+�5/      �� $��0��6%   $��0,0,10,0q�65   .+�50      �� -   5         ��Name$ NomRecetteTextBox��50   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NOM DE LA RECETTE��6A   $	��400��6t   
���   �$
��Left=�6�   $
��10,5q�6�   �� 51      -   5        $ DescriptifRecetteTextBox��51   &   $ DESCRIPTIF RECETTE��6H      
HelperText$B <Votre descrptif ne doit pas contenir plus de 256 caractères��6|   $��70��6�   $	��400��6�   
���   �$
��Left=�6  $
��10,5q�6&  52      53      54      �� 55       �� Orientation$ 
Horizontal=�6   $��0,40,0,0q�66   $��Center=�6H   .+�56      �� $��NBR PERSONNES :��6   $��13(�66   
���   �$��Yu Gothic UI Semilight)�6X    J� Opacity$	 0.6Q�6|   �� 57      -   5        $ NbrPersonnesTextBox��57      
���   �$��50��6z   �� 58      $��NBR D'ETAPES :��6   $��13(�65   
���   �$��Yu Gothic UI Semilight)�6W   $	 0.6Q�6{   $��20,0,0,0q�6�   �� 59      -   5        $ NbrEtapesTextBox��59      
���   �$��50��6w   �� 5:      $��DIFFICULTE (/5) :��6   $��13(�68   
���   �$��Yu Gothic UI Semilight)�6Z   $	 0.6Q�6~   $��20,0,0,0q�6�   �� 5;      -   5        $ DifficulteTextBox��5;      
���   �$��50��6x   �� 5<      $��PRIX :��6   $��13(�6-   
���   �$��Yu Gothic UI Semilight)�6O   $	 0.6Q�6s   $��20,0,0,0q�6�   �� 5=      -   5        $ PrixClientTextBox��5=      
���   �$��50��6x   5>      �� 5?      $ 
Horizontal=�6   $��7,20,0,0q�66   .+�5@      �� $��INGREDIENTS :��6   $��13(�64   
���   �$��Yu Gothic UI Semilight)�6V   $	 0.6Q�6z   �� 5A      $Y��SChoisissez les ingrédients puis cliquez sur valider. Indiquez alors les quantités��6   $��13(�6x   
���   �$��Yu Gothic UI Semilight)�6�   $	 0.6Q�6�   5B      �� 5C      $ 
Horizontal=�6   $��	10,10,0,0q�66   .+�5D      �� -   5         ��Name$ ScrollViewerIngredients��5D   #   $	��120��6D   $	��540��6Q   .��5E      �� -   5         ��Name$ StackPanelIngredientsQtes��5E   >   $ 
Horizontal=�6%   .+�5F      �� -	   5        $ StackPanelIngredients��5F   )   .+�5G   "   �� -
   5         ��Name$ ComboboxIngerdient��5G   +   $	��350��6G   $��30��6S   
���   �$��5q�6s   $
��Left=�6~   �� 5H   "   -   5        $ ComboboxIngerdient2��5H   +   $	��350��6H   $��30��6T   
���   �$��5q�6t   $
��Left=�6   �� 5I   "   -   5        $ ComboboxIngerdient3��5I   +   $	��350��6H   $��30��6T   
���   �$��5q�6t   $
��Left=�6   5J      �� 5K      -   5        $ StackPanelQtes��5K   )   .+�5L   "   �� -   5        $ 
TextBoxQte��5L   *   $��60��6i   $��30��6t   
���   �$��5q�6�   $��Right=�6�   �� 5M   "   -   5        $ TextBoxQte2��5M   *   $��60��6j   $��30��6u   
���   �$��5q�6�   $��Right=�6�   �� 5N   "   -   5        $ TextBoxQte3��5N   *   $��60��6j   $��30��6u   
���   �$��5q�6�   $��Right=�6�   5O      �� 5P      -   5        $ StackPanelUnitesLabel��5P   )   .+�5Q   "   �� -   5         ��Name$ 
UniteLabel��5Q   (   $��13(�6<   
���   �$��Yu Gothic UI Semilight)�6^   $	 0.6Q�6�   $��80��6�   $��30��6�   $��5q�6�   �� 5R   "   -   5        $ 
UniteLabe2��5R   (   $��13(�6<   
���   �$��Yu Gothic UI Semilight)�6^   $	 0.6Q�6�   $��80��6�   $��30��6�   $��5q�6�   �� 5S   "   -   5        $ 
UniteLabe3��5S   (   $��13(�6<   
���   �$��Yu Gothic UI Semilight)�6^   $	 0.6Q�6�   $��80��6�   $��30��6�   $��5q�6�   5T      5U      5V      �� 5W      .+�5X      �� -   5         ��Name$ Valider��5X   !   $��20��6H   $��20��6S   
������� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6v   
������ $��Right=�6�   $��20q�6�   .��5Y      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Check=�66   
���   � � Cursor$
 Hand��6V   $��15��6d   $��15��6o   $��Center=�6{   $��Center=�6�   5Z      �� 5[      -   5        $	 Add��5[   !   $��20��6@   $��20��6K   
�������#��[ 6n   
������ $��Right=�6�   $��20q�6�   .��5\        $	 Add=�66   
���   �$
 Hand��6T   $��20��6b   $��20��6m   $��Center=�6y   $��Center=�6�   5]      5^      5_      �� 5`      $ 
Horizontal=�6   $��	10,20,0,0q�66   .+�5a      �� $��CATEGORIE :��6   $��13(�62   
���   �$��Yu Gothic UI Semilight)�6T   $	 0.6Q�6x   $��0,0,5,0q�6�   �� 5b      -   5        $ CategorieCombobox��5b      $	��400��6:   $��25��6F   
���   �$
��Left=�6f   $
��10,5q�6�   5c      5e      �� 5f      -   5        $��PropositionButton��5f   �   $
 Hand��6   #��[  6C   $��MADE GoodTime Grotesk)�6i   $��13(�6�   $��Proposer ma recette !��6�   
���   �$��30��6�   $	��200��6�   $��Bottom=�6�   $��Center=�6  5g      5h      5i      