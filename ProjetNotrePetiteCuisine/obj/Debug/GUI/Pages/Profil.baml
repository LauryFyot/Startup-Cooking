   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      /    )ProjetNotrePetiteCuisine.GUI.Pages.Profil   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Profil��5
       � 	Resources 5       �� 
TargetType   RoundButton �� Property �� Value �� 
TargetType �� CornerRadius ��Name��%�  &	        �� 5   
   " ��6   .�5      ��  � �� �#FE65606+   �� 5       �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 15��6!   ���#FE6560���#ccc._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     CloseOnClickAway . 	   DialogContent	 5   
   � 5      
 � RowDefinitions
 5      �� 5       $��2* �6$   �� 5!      $��7* �6$   .+�5$      � $��0��6   ���#FE6560.+�5%      �� $
��20,0q�6    $
��Wrap=�6.   $��Confirmer ?��6B   $��MADE GoodTime Grotesk)�6U   $��15(�6x   $
��Left=�6�   $��Center=�6�   �� 5&      -   5         ��Name$ CloseButton��5&   �    * &MaterialDesignFloatingActionMiniButton#��[ 6      CloseDialogCommand#��Z 6]    � Cursor$
 Hand��6�   ���#FE6560$��20��6�   $��20��6�   $��Right=�6�   $��Center=�6
  $��10q�6%  .��5'      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�62   
���   �6?   5(      5)      � 5+      $��1��6   .+�5,      �� $��20q�6!   .+�5-      �� $
��Wrap=�6$   $T��NVous pourrez désormais proposer vos propres recettes sur Notre petite Cuisine��68   $��Yu Gothic Medium)�6�   $��15(�6�   $
��Left=�6�   �� 5.       �� Orientation$ 
Horizontal=�6%   $
��0,20q�6>   $	��200��6L   .+�5/      �� -   5        $ Confirm��5/   �   #��Z 6%   ���#FE6560$
��10,0q�6|   $��	Confirmer��6�   $��MADE GoodTime Grotesk)�6�   $��10(�6�   
���   �$��80��6	  �� 50      -   5        $
 Deny��50   �   #��Z 6%   ���#FE6560$
��10,0q�6|   $��Annuler��6�   $��MADE GoodTime Grotesk)�6�   $��10(�6�   
���   �$��80��6�   51      52      53      54      .��57   
   � 
������� � ColumnDefinitions 59      �� 5:      $��4* �6#   �� 5;      $��2* �6#   .+�5>      � $��1��6   .+�5?      �� $@��:pack://application:,,,/Resources/img/Baneau orchiettas.png��6   $��UniformToFill=�6\   5@      �� 5B      
���   �$��0.5,0.5,0,0q�6)   $��0��6G    J� Effect 5C      3  -System.Windows.Media.Effects.DropShadowEffect  5D         ShadowDepth$ 1Q�6'      
BlurRadius$ 10Q�67   5F      �� 5G      
���   �$��	0,0.5,0,0q�6)   $��1��6E    5H        5I      $ 1Q�6'   $ 10Q�67   5K      � 5M      .+�5N      �� .+�5O      �� $��Notre petite Cuisine.��6    $��40(�6=   $��	0,20,0,10q�6K   $��MADE GoodTime Grotesk)�6^   $	��Top=�6�   $��Center=�6�   �� 5P      $��
Mon Profil��6    $��25(�62   $��MADE GoodTime Grotesk)�6@   $��Center=�6c   $��Center=�6�   � 5Q      $��0,20,0,0q�6    5R      �� 5S      $��1* �6/   �� 5T      $��3* �6/   .+�5V      � .+�5W      �� $	��100��6%   $	��100��61   $ 80��6>   ��5X   "   �� 5Y   &    �� ImageSource$8 2pack://application:,,,/Resources/img/ChefIcon3.png��61   5[      5\      � 5]      $��1��6    5^      �� 5_   "   $��1* �63   �� 5`   "   $��1* �63   .+�5b      �� $��0��6)   .+�5c   "   �� $��Mes informations :��6(   $��20(�6E   $��MADE GoodTime Grotesk)�6S   
���   �$
��10,0q�6�   �� 5d   "   -   5         ��Name$ UsernameTextBox��5d   *   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ USERNAME��6C   $	��200��6m   
���   �$
��Left=�6�   $
��10,5q�6�   �� 5e   "   -   5        $ PrenomTextBox��5e   *   $ PRENOM��6A   $	��200��6i   
���   �$
��Left=�6�   $
��10,5q�6�   �� 5f   "   -   5        $ 
NomTextBox��5f   *   $	 NOM��6>   $	��200��6c   
���   �$
��Left=�6�   $
��10,5q�6�   5g      �� 5h      $��1��6)   .+�5i   "   �� -   5        $ NumtelTextBox��5i   *   $ NUMERO TELEPHONE��6A   $	��200��6s   
���   �$
��Left=�6�   $��	10,38,0,0q�6�   �� 5j   "   -   5        $ MailTextBox��5j   *   $
 MAIL��6?   $	��200��6e   
���   �$
��Left=�6�   $
��10,5q�6�   5k      5l      5m      �� 5n      -	   5        $��
DevenirCdR��5n   �   $
 Hand��6      OpenDialogCommand#��Z 6+   #��[  6l   $��MADE GoodTime Grotesk)�6�   $��13(�6�   $%��Devenir créateur de recettes !��6�   
���   �$��35��6  $	��450��6  $
��Left=�6(  $��	40,20,0,0q�6C  �� 5o      $��A propos de vous :��6   $��20(�69   $��MADE GoodTime Grotesk)�6G   
���   �$
��40,5q�6}   �� 5p      $ 
Horizontal=�6!   .+�5q      �� $��VOTRE SOLDE COOK :��6    $��13(�6=   
���   �$��40,0,0,0q�6_   $��Yu Gothic UI Semilight)�6q    J� Opacity$	 0.6Q�6�   �� 5r      ���#FE6560$ 13��66   $��80��6H   ._�5s      �� -
   5         ��Name$ SoldeCookLabel��5s   (   $��Center=�6@   $��Center=�6[   $��MADE GoodTime Grotesk)�6x   $��15(�6�   5t      5u      �� 5v      $ 
Horizontal=�6!   $��40,10q�6:   .+�5w      �� $��VOS RECETTES :��6    $��13(�69   
���   �$��Yu Gothic UI Semilight)�6[   $	 0.6Q�6   &   System.Windows.Controls.DataGrid  5y      -   5          Name$ YourRecipeDatagrid��5y   <   $	��550��6#   $	��150��6/      AutoGenerateColumns .  "   VerticalScrollBarVisibility$ Visible=�6�   ��6X   ��    Columns 5z      0  *System.Windows.Controls.DataGridTextColumn  5{   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Nom de la recette��65      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6i   1	  +System.Windows.Controls.DataGridBoundColumn  	  Binding  6P   �� *Name+6i     5|   "   $ Nb de commandes��65   $
 auto 6k     6N   �� *
NbSolded+6k   5~      5      5�      �� 5�      -   5        $��ProposerUneRecetteButton��5�   �   $
 Hand��6   #��[  6N   $��MADE GoodTime Grotesk)�6s   $��13(�6�   $��Proposer une recette !��6�   
���   �$��35��6�   $	��450��6  $��Center=�6  $��Bottom=�6-  $
��0,30q�6H  5�      5�      5�      5�      