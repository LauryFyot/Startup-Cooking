   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      7    1ProjetNotrePetiteCuisine.GUI.Pages.GestionRecette   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  GestionRecette��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � 
�������$��0��6"   $��	0,10,0,10q�6/   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10,0,0,0q�62   .+�5      �� $7��1pack://application:,,,/Resources/img/LogoNpC2.png��6   $��50��6S   $��50��6^   �� 5      $��Gestionnaire Cooking��6   $��15(�67   $��Center=�6E   $
��Left=�6`   
���   �$
��20,0q�6�   5      �� 5      -   5         ��Name$ 
HomeButton��5   �   
������ 
������  *  &MaterialDesignFloatingActionDarkButton#��[  6b   $��50��6�   $��50��6�   $��Right=�6�   $
��20,0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
���   �   Kind$
 Home=�6=   $��30��6I   $��30��6T   $��Center=�6`   $��Center=�6|   5      5      � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ RecipesDatagrid��5   S    � Cursor$
 Hand��6   $��20,10,20,100q�6%      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6�      
IsReadOnly . ��6;   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6V      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
RecipeID+6c     5       $
 Confirmed ?��6-   $
 Auto 6b   
 �   � 6B   �� *IsValidated+6o     5!      $	
 Nom��6-   $
 Auto 6S   
 �   � 6:   �� *Name+6`     5"      $
 
Difficulty��6-   $
 Auto 6e   
 �   � 6A   �� *DifficultyLevel+6r     5#      $
 PrixCook��6-   $
 Auto 6Y    6?   �� *Price+6Y     5$      $
 	NbSolded ��6-   $
 Auto 6]    6@   �� *
NbSolded+6]     5%      $
 RecipeCreatorFees ��6-   $
 Auto 6p    6I   �� *RecipeCreatorFees+6p     5&      $
 ForNbPerson��6-   $
 Auto 6b   
 �   � 6B   �� *ForNbPerson+6o     5'      $
 
Descriptif��6-   $	 200 6a    6A   �� *Description+6a     5(      $
 NbStep��6-   $
 Auto 6X    6=   �� *NbStep+6X     5)      $

 Type��6-   $
 Auto 6T    6;   �� *Type+6T     5*      $
 RecipeCreatorID ��6-   $
 Auto 6l    6G   �� *RecipeCreatorID+6l     5+      $
 	Créateur��6-   $
 Auto 6i    6?   �� *RecipeCreatorUsername+6i     5,      $
 Cration Date��6-   $
 Auto 6d    6C   �� *CreationDate+6d     5-      $
 Modification Date ��6-   $
 Auto 6o    6I   �� *ModificationDate+6o   5/      �� 50      $ 
Horizontal=�6   $��Bottom=�62   $��Center=�6M   $
��0,30q�6j   .+�51      �� -   5        $ ShowProductList��51      $��Show product list��6P   $	��200��6l   $��40��6x   $
��20,0q�6�   �� 52      -   5        $ ValidateRecipe��52      $��Validate recipe��6N   $	��200��6h   $��40��6t   $
��20,0q�6�   �� 53      -   5        $ DeleteRecipe��53      $��Delete recipe��6J   $	��200��6b   $��40��6n   $
��20,0q�6z   54      55      57      58      