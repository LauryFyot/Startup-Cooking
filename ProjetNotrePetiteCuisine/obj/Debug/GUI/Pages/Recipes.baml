   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      0    *ProjetNotrePetiteCuisine.GUI.Pages.Recipes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Recipes��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � $��20,20,20,40q�6   $��0��6$   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ RecipesDataGrid��5   �   $	��Top=�6   $	��520��6/    � Cursor$
 Hand��6<      SelectionMode$ Single=�6J      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6     
IsReadOnly .    SelectionUnit$ FullRow=�6V  ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 Nom��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6O      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Name+6\     5      $	 PrixCook��6)   $

 Auto 6U    6;   �� *Price+6U     5      $
	 Type��6)   $

 Auto 6P    67   �� *Type+6P     5      $	 	Créateur��6)   $

 Auto 6e    6;   �� *RecipeCreatorUsername+6e     5      $	 
Créée le��6)   $

 Auto 6\    6;   �� *CreationDate+6\     5      $	 
Descriptif��6)   $
 * 6]    6=   �� *Description+6]   5      �� 5      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Bottom=�6?   $��Center=�6Z   $
��0,10q�6w   .+�5      �� -   5         ��Name$	 Add��5   .   ���#FE6560$��MADE GoodTime Grotesk)�6N   $��Voir la recette !��6q   $	��200��6�   $��40��6�   $
��20,0q�6�   5       5!      5"      5#      