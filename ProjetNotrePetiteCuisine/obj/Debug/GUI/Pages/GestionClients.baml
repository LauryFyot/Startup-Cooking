   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      7    1ProjetNotrePetiteCuisine.GUI.Pages.GestionClients   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  GestionClients��5
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
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ClientsDatagrid��5   j      SelectionMode$ Single=�6    � Cursor$
 Hand��6.   $��20,10,20,100q�6<      AutoGenerateColumns .  $
��Auto=�6�   $
��Auto=�6�   	   
IsReadOnly	 . ��6R   �� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6X      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
Username+6e     5       $ 
First name��6)   $
 Auto 6\    6=   �� *	FirstName+6\     5!      $ 	Last Name��6)   $
 Auto 6Z    6<   �� *
LastName+6Z     5"      $ Phone Number��6)   $
 Auto 6`    6?   �� *PhoneNumber+6`     5#      $ Email ��6)   $
 Auto 6T   
 �   � 69   �� *Email+6a   5%      �� 5&      $ 
Horizontal=�6   $��Bottom=�62   $��Center=�6M   $
��0,30q�6j   .+�5'      �� -   5        $ 
ActualCart��5'      $��Actual Cart��6F   $	��200��6\   $��40��6h   $
��20,0q�6t   �� 5(      -   5        $ Orders��5(      $��
All orders��6>   $	��200��6S   $��40��6_   $
��20,0q�6k   �� 5)      -   5        $ DeleteClient��5)      $��Delete Client��6J   $	��200��6b   $��40��6n   $
��20,0q�6z   5*      5+      5-      5.      