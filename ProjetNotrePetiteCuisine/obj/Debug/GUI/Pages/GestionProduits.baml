   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      8    2ProjetNotrePetiteCuisine.GUI.Pages.GestionProduits   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  GestionProduits��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � 
�������$��0��6"   $��	0,10,0,10q�6/   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10,0,0,0q�62   .+�5      �� $7��1pack://application:,,,/Resources/img/LogoNpC2.png��6   $��50��6S   $��50��6^   �� 5      $��Gestionnaire Cooking��6   $��15(�67   $��Center=�6E   $
��Left=�6`   
���   �$
��20,0q�6�   5      �� 5      -   5         ��Name$ 
HomeButton��5   �   
������ 
������  *  &MaterialDesignFloatingActionDarkButton#��[  6b   $��50��6�   $��50��6�   $��Right=�6�   $
��20,0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
���   �   Kind$
 Home=�6=   $��30��6I   $��30��6T   $��Center=�6`   $��Center=�6|   5      5      � 5   
   $��1��6   $��20,10,20,10q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsDatagrid��5   J    � Cursor$
 Hand��6   $	��470��6%   $	��Top=�6d      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6�      
IsReadOnly . ��62   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	ProductID+6S     5!      $	
 Nom��6)   $
 Auto 6O    66   �� *Name+6O     5"      $
 
Catégorie��6)   $
 Auto 6Y    6<   �� *
Category+6Y     5#      $
 Unité��6)   $
 Auto 6Q    68   �� *Unit+6Q     5$      $
 Stock Actuel��6)   $
 Auto 6\    6?   �� *
Quantity+6\     5%      $
 	Stock Min��6)   $
 Auto 6\    6<   �� *MinQuantity+6\     5&      $
 	Stock Max��6)   $
 Auto 6\    6<   �� *MaxQuantity+6\     5'      $
 Fournisseur��6)   $
 Auto 6[    6>   �� *
Supplier+6[   5)      5*      5+      5,      