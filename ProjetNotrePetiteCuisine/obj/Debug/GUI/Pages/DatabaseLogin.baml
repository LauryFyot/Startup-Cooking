   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      6    0ProjetNotrePetiteCuisine.GUI.Pages.DatabaseLogin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Register��5	      $	��650��6   $
��1000��6%    � 	Resources 5       �� 
TargetType   RoundButton �� Property �� Value �� 
TargetType �� CornerRadius ��Name��%�  &	        �� 5   
   " ��6   .�5      ��  � �� �#FE65606+   �� 5       �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 20��6!   ���#FE6560���#ccc._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6   .+�5!   
   � $��1��6   .+�5"      �� $L��Fpack://application:,,,/Resources/img/fennel-yogurt-dip-2-Basically.jpg��6   $��UniformToFill=�6d   $��Center=�6|   5#      � 5$   
   $��0��6   .+�5%      � $��30,40q�6   .+�5&      �� .+�5'      �� $��Notre petite Cuisine.��6    $��40(�6=   $��	0,20,0,10q�6K   $��MADE GoodTime Grotesk)�6^   $	��Top=�6�   $��Center=�6�   �� 5(      $��Database Login��6    $��25(�66   $��MADE GoodTime Grotesk)�6D   $��Center=�6g   $��Center=�6�   � 5)       5*      �� 5+      $��3* �6/   �� 5,      $��2* �6/   .+�5.      �� $��0��6%   $��0,20,0,0q�65   .+�50      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase	   OpeningEffects	 51   "   ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  52   &   
   Kind$
 SlideInFromLeft=�6F      Duration$ 0:0:0.8h�6]   .��54   "   ��  �� Orientation$ 
Horizontal=�6-   $��50��6F   .+�55   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��0,20,0,0q�6>      Kind$ Account=�6P   $��30��6_   $��30��6j   �� 56   &   -   5         ��Name$ UsernameTextBox��56   B   
���   �$��	10,20,0,0q�6[   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ USERNAME��6n   $��15(�6�    �� TextWrapping$
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   �   
HelperText$ VOTRE USERNAME MYSQL��6   57   #   58        5:      	 5;   "     5<   &   $
 SlideInFromRight=�6F   $ 0:0:0.8h�6^   .��5>   "   �� $ 
Horizontal=�6-   $��50��6F   .+�5?   &     $��0,20,0,0q�6>   $
 Lock=�6P   $��30��6\   $��30��6g   G� 5@   &   -   5         G�Name$ PasswordTextBox��5@   F   
���   �$��	10,20,0,0q�6_   $ PASSWORD��6r   $ VOTRE PASSWORD MYSQL��6�   $��15(�6�   $	��200��6�   $��30��6�   $��Bottom=�6�   
���   �6  5A   #   5B        5E      	 5F   "     5G   &   $
 SlideInFromRight=�6F   $ 0:0:0.8h�6^   .��5I   "   �� $ 
Horizontal=�6-   $��50��6F   .+�5J   &     $��0,20,0,0q�6>   $ AccountEdit=�6P   $��30��6c   $��30��6n   �� 5K   &   -   5        $ DatabaseTextBox��5K   B   
���   �$��	10,20,0,0q�6[   $ DATABASE NAME��6n   $0 *NOM DE LA DATABASE A LAQUELLE SE CONNECTER��6�   $��15(�6�   $
 Wrap=�6�   $	��250��6  $��30��6  $��Bottom=�6)  
���   �6D  5L   #   5M        5O      	 5P   "     5Q   &   $
 SlideInFromRight=�6F   $ 0:0:0.84h�6^   .��5S   "   �� $ 
Horizontal=�6-   $��50��6F   .+�5T   &     $��0,20,0,0q�6>   $ TextBox=�6P   $��30��6_   $��30��6j   �� 5U   &   -   5        $ DomainTextBox��5U   B   
���   �$��	10,20,0,0q�6Y   $ 	localhost��6l   $��15(�6�   $
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   �6�   5V   #   5W        5Y      	 5Z   "     5[   &   $
 SlideInFromRight=�6F   $ 0:0:0.8h�6^   .��5]   "   �� $ 
Horizontal=�6-   $��50��6F   $��0,0,0,40q�6R   .+�5^   &     $��0,20,0,0q�6>   $ At=�6P   $��30��6Z   $��30��6e   �� 5_   &   -   5        $ PortTextBox��5_   B   
���   �$��	10,20,0,0q�6W   $
 3306��6�   $��15(�6�   $
 Wrap=�6�   $	��250��6�   $��30��6�   $��Bottom=�6�   
���   �6  5`   #   5a      5c      � 5d      $��1��6   .+�5e      �� $	��100��6%   $	��100��61   $ 80��6>   $	��Top=�6P   $��0,50,0,0q�6h   ��5f   "   �� 5g   &    �� ImageSource$8 2pack://application:,,,/Resources/img/chef_icon.png��61   5i      5j      5k        5m      	 5n        5o      $
 SlideInFromBottom=�6>   $ 0:0:0.8h�6W   .��5q      �� -   5        $��Login��5q   �    � Cursor$
 Hand��6!   #��[  6C   $��MADE GoodTime Grotesk)�6h   $��13(�6�   $��Login��6�   
���   �$��40��6�   $	��450��6�   $��Bottom=�6�   $��Center=�6�   5r      5t      5u      5v      5w      5x      