   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      6    0ProjetNotrePetiteCuisine.GUI.Pages.DashboardPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  DashboardPage��5
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
   $��1��6   $��20q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5       $��2* �6#   .+�5"      �� $��0��6   $��0,20,0,0q�6)   .+�5%      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5&      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5'         Kind$ SlideInFromLeft=�6:      Duration$ 0:0:0.8h�6Q   .��5)      �� $ 
Horizontal=�6!   $��50��6:   .+�5*        $��0,20,0,0q�62   $ CrownOutline=�6D   $��30��6X   $��30��6c   �� 5+      -   5        	 ��Name$	 CdrOfTheWeek��5+   $   $"��Recipe Creator of the Week !��6:   $��	10,20,0,0q�6^   $��15(�6q   $
��Wrap=�6   $	��400��6�   $��25��6�   $��Bottom=�6�   
���   �6�   5,      5-        5/       50        51      $ SlideInFromRight=�6:   $ 0:0:0.8h�6R   .��53      �� $ 
Horizontal=�6!   $��50��6:   .+�54        $��0,20,0,0q�62   $
 Face=�6D   $��30��6P   $��30��6[   �� 55      -   5        $	 CdrOfTheWeekName��55   $   $��	10,20,0,0q�6>   $��15(�6Q   $
��Wrap=�6_   $	��400��6s   $��25��6   $��Bottom=�6�   
���   �6�   56      57        59       5:        5;      $ SlideInFromRight=�6:   $ 0:0:0.8h�6R   .��5=      �� $ 
Horizontal=�6!   $��50��6:   .+�5>        $��0,20,0,0q�62   $ TextBox=�6D   $��30��6S   $��30��6^   �� 5?      -   5        $	 CdrOfTheWeekId��5?   $   $��	10,20,0,0q�6<   $��15(�6O   $
��Wrap=�6]   $	��400��6q   $��25��6}   $��Bottom=�6�   
���   �6�   5@      5A      &   System.Windows.Controls.DataGrid  5E      -   5        
  Name$
 Top5OfTheWeek��5E   a   $��	0,20,20,0q�6    � Cursor$
 Hand��6.   $	��300��6<      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6�      
IsReadOnly . ��6I   ��    Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ NbSolded��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6\   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6?   �� *
NbSolded+6\     5H      $ Creator��6-   $
 Auto 6h    6>   �� *RecipeCreatorUsername+6h     5I      $
 Name��6-   $
 Auto 6T      
Foreground
 �   � 6;   �� *Name+6a     5J      $ Description��6-   $	 200 6b    6B   �� *Description+6b     5K      $ Price��6-   $
 Auto 6V    6<   �� *Price+6V     5L      $
 Type��6-   $
 Auto 6T    6;   �� *Type+6T     5M      $ CreationDate��6-   $
 Auto 6d    6C   �� *CreationDate+6d   5O      5S      �� 5U      $��1��6   $��0,20,0,0q�6)   .+�5X         5Y        5Z      $ SlideInFromLeft=�6:   $ 0:0:0.8h�6Q   .��5\      �� $ 
Horizontal=�6!   $��50��6:   .+�5]        $��0,20,0,0q�62   $ Crown=�6D   $��30��6Q   $��30��6\   �� 5^      -   5        $	 
AllTimeCdr��5^   $   $��All Time Recipe Creator !��68   $��	10,20,0,0q�6Y   $��15(�6l   $
��Wrap=�6z   $	��400��6�   $��25��6�   $��Bottom=�6�   
���   �6�   5_      5`        5b       5c        5d      $ SlideInFromRight=�6:   $ 0:0:0.8h�6R   .��5f      �� $ 
Horizontal=�6!   $��50��6:   .+�5g        $��0,20,0,0q�62   $
 Face=�6D   $��30��6P   $��30��6[   �� 5h      -   5        $	 AllTimeCdrName��5h   $   $��	10,20,0,0q�6<   $��15(�6O   $
��Wrap=�6]   $	��400��6q   $��25��6}   $��Bottom=�6�   
���   �6�   5i      5j        5l       5m        5n      $ SlideInFromRight=�6:   $ 0:0:0.8h�6R   .��5p      �� $ 
Horizontal=�6!   $��50��6:   .+�5q        $��0,20,0,0q�62   $ TextBox=�6D   $��30��6S   $��30��6^   �� 5r      -   5        $	 AllTimeCdrId��5r   $   $��	10,20,0,0q�6:   $��15(�6M   $
��Wrap=�6[   $	��400��6o   $��25��6{   $��Bottom=�6�   
���   �6�   5s      5t        5x      -	   5        $
 AllTimeCdrTop5��5x   `   $��0,20,0,0q�6   $
 Hand��6-   $	��300��6;    .  $
��Auto=�6�   $
��Auto=�6�    . ��6H   ��  5y        5z      $ NbSolded��6-   $
 Auto 6\   
 �   � 6?   �� *
NbSolded+6i     5{      $	 Nom��6-   $
 Auto 6S   
 �   � 6:   �� *Name+6`     5|      $ 
Descriptif��6-   $	 150 6a    6A   �� *Description+6a     5}      $ PrixCook��6-   $
 Auto 6Y    6?   �� *Price+6Y     5~      $
 Type��6-   $
 Auto 6T    6;   �� *Type+6T     5      $ 
Créée le��6-   $
 Auto 6`    6?   �� *CreationDate+6`   5�      5�      5�      5�      5�      