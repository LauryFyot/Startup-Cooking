   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      2    ,ProjetNotrePetiteCuisine.GUI.Pages.UserLogin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Login��5	      $	��650��6   $
��1000��6"   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��1��6   .+�5      �� $��UniformToFill=�6   $��Center=�6-   $��Center=�6J   $8��2pack://application:,,,/Resources/img/PastaBowl.png��6e   �� 5       �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��Right=�6J   .+�5      �� -   5         ��Name$ CloseButton��5      )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6.      MaterialDesignIconButton#��[  6p   $��10q�6�   $��25��6�   $��25��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircleOutline=�6.   
�������$��25��6[   $��25��6g   5      5      5      � 5   
   $��0��6   .+�5      � $��50,80q�6   .+�5      �� .+�5      �� $��Notre petite Cuisine.��6    $��30(�6=   $��	0,40,0,10q�6K   $��MADE GoodTime Grotesk)�6^   $	��Top=�6�   $��Center=�6�   �� 5       $��Login��6    $��25(�6-   $��MADE GoodTime Grotesk)�6;   $��Center=�6^   $��Center=�6{   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  5#      C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5$      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5%         Kind$ SlideInFromLeft=�6>      Duration$ 0:0:0.8h�6U   .��5'      �� $ 
Horizontal=�6%   $��70��6>   .+�5(        $��	20,40,0,0q�66   $ Account=�6I   $��30��6X   $��30��6c   �� 5)      -   5        	 ��Name$	 UsernameTextBox��5)   :   
���   �$��	10,40,0,0q�6S   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 USERNAME��6f   $��15(�6�    �� TextWrapping$
 Wrap=�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5*      5+        5-       5.        5/      $ SlideInFromRight=�6>   $ 0:0:0.8h�6V   .��51      �� $ 
Horizontal=�6%   $��70��6>   .+�52        $��	20,40,0,0q�66   $
 Lock=�6I   $��30��6U   $��30��6`   G� 53      -   5         G�Name$ PasswordTextBox��53   >   
���   �$��	10,40,0,0q�6W   $
 PASSWORD��6j   $��15(�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6�   54      55        59       5:        5;      $ SlideInFromBottom=�6>   $ 0:0:0.8h�6W   .��5=      �� -   5        $ LoginButton��5=   !   ���#FE6560 � Cursor$
 Hand��6K   $��MADE GoodTime Grotesk)�6h   $��13(�6�   $��LOGIN��6�   
���   �$��40��6�   $	��100��6�   $��Center=�6�   $��
20,40,20,0q�6�   5>      5A        5D       5E        5F      $ FadeIn=�6:   $ 0:0:0.8h�6H   .��5H      �� $��Bottom=�6    �� 5I   "   -   5        
���   �.�5I   X   &$Pas encore membre ? Inscrivez-vous !5K   #   5L      5M      5O      5P      5Q      5R      