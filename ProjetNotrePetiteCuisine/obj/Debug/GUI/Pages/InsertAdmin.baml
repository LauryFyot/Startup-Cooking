   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      4    .ProjetNotrePetiteCuisine.GUI.Pages.InsertAdmin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  InsertAdmin��5
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
������  *  &MaterialDesignFloatingActionDarkButton#��[  6a   $��50��6�   $��50��6�   $��Right=�6�   $
��20,0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
���   �   Kind$
 Home=�6=   $��30��6I   $��30��6T   $��Center=�6`   $��Center=�6|   5      5      � 5   
   $��1��6   $��30,40q�6   .+�5      �� .+�5      �� $��Insert New Admin��6   $��25(�64   $��MADE GoodTime Grotesk)�6B   $��Center=�6e   $��Center=�6�   � 5       � ColumnDefinitions 5       �� 5!      $��3* �6+   �� 5"      $��2* �6+   .+�5$      �� $��0��6!   $��0,20,0,0q�61   .+�5&      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5'      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5(   "      Kind$ SlideInFromLeft=�6B      Duration$ 0:0:0.8h�6Y   .��5*      �� $ 
Horizontal=�6)   $��50��6B   .+�5+   "     $��0,20,0,0q�6:   $ Account=�6L   $��30��6[   $��30��6f   �� 5,   "   -   5        	 ��Name$	 UsernameTextBox��5,   >   
���   �$��	10,20,0,0q�6W   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 USERNAME��6j   $��15(�6�    �� TextWrapping$
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   �   
HelperText$% VOTRE PSEUDO DOIT ETRE UNIQUE !��6�   5-      5.        50       51        52   "   $ SlideInFromRight=�6B   $ 0:0:0.8h�6Z   .��54      �� $ 
Horizontal=�6)   $��50��6B   .+�55   "     $��0,20,0,0q�6:   $ AccountEdit=�6L   $��30��6_   $��30��6j   �� 56   "   -   5        $	 PrenomTextBox��56   >   
���   �$��	10,20,0,0q�6U   $
 PRENOM��6h   $��15(�6�   $
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   �6�   57      58        5:       5;        5<   "   $ SlideInFromRight=�6B   $ 0:0:0.8h�6Z   .��5>      �� $ 
Horizontal=�6)   $��50��6B   .+�5?   "     $��0,20,0,0q�6:   $ TextBox=�6L   $��30��6[   $��30��6f   �� 5@   "   -   5        $	 
NomTextBox��5@   >   
���   �$��	10,20,0,0q�6R   $	
 NOM��6e   $��15(�6�   $
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5A      5B      5D      � 5E      $��1��6   .+�5F      �� $	��100��6!   $	��100��6-    �� CornerRadius$ 80��6:   $	��Top=�6L   $��0,50,0,0q�6d   ��5G      �� 5H   "    �� ImageSource$8 2pack://application:,,,/Resources/img/chef_icon.png��6-   5J      5K      5L        5N       5O        5P      $ SlideInFromRight=�6:   $ 0:0:0.8h�6R   .��5R      �� $ 
Horizontal=�6!   $��50��6:   .+�5S        $��0,20,0,0q�62   $ At=�6D   $��30��6N   $��30��6Y   �� 5T      -   5        $	 MailTextBox��5T   6   
���   �$��	10,20,0,0q�6K   $

 MAIL��6^   $��15(�6�   $
 Wrap=�6�   $	��450��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5U      5V        5X       5Y        5Z      $ SlideInFromRight=�6:   $ 0:0:0.8h�6R   .��5\      �� $ 
Horizontal=�6!   $��50��6:   .+�5]        $��0,20,0,0q�62   $ Phone=�6D   $��30��6Q   $��30��6\   �� 5^      -   5        $	 NumtelTextBox��5^   6   
���   �$��	10,20,0,0q�6M   $
 	TELEPHONE��6`   $��15(�6�   $
 Wrap=�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5_      5`      � 5b       5c      �� 5d      $��1* �6+   �� 5e      $��1* �6+   .+�5g      � $��0��6   .+�5i         5j        5k   "   $ SlideInFromRight=�6B   $ 0:0:0.8h�6Z   .��5m      �� $ 
Horizontal=�6)   $��50��6B   .+�5n   "     $��0,20,0,0q�6:   $
 Lock=�6L   $��30��6X   $��30��6c   G� 5o   "   -   5         G�Name$ ChoosePasswordTextBox��5o   B   
���   �$��	10,20,0,0q�6a   $
 PASSWORD��6t   $��15(�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5p      5q      5r      � 5s      $��1��6   .+�5t         5u        5v   "   $ SlideInFromRight=�6B   $ 0:0:0.8h�6Z   .��5x      �� $ 
Horizontal=�6)   $��50��6B   .+�5y   "     $��0,20,0,0q�6:   $ 	LockCheck=�6L   $��30��6]   $��30��6h   G� 5z   "   -   5        $ ConfirmPasswordTextBox��5z   B   
���   �$��	10,20,0,0q�6b   $
 CONFIRM PASSWORD��6u   $��15(�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5{      5|      5~      5        5�       5�        5�      $ SlideInFromBottom=�6:   $ 0:0:0.8h�6S   .��5�      �� -	   5        $��AddAdmin��5�   �   $��0,50,0,0q�6    � Cursor$
 Hand��6/   ���#FE6560$��MADE GoodTime Grotesk)�6i   $��13(�6�   $��	Add Admin��6�   
���   �$��40��6�   $	��200��6�   $��Bottom=�6�   $��Center=�6  5�      5�      5�      5�      5�      