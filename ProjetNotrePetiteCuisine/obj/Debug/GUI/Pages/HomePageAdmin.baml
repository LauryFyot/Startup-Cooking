   M S B A M L   `   `   `  ����S  OProjetNotrePetiteCuisine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages"ProjetNotrePetiteCuisine.GUI.Pages  5      6    0ProjetNotrePetiteCuisine.GUI.Pages.HomePageAdmin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      <local0clr-namespace:ProjetNotrePetiteCuisine.GUI.Pages  5        N� Title$  	HomePageG��5
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
������  *  &MaterialDesignFloatingActionDarkButton#��[  6a   $��50��6�   $��50��6�   $��Right=�6�   $
��20,0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
���   �   Kind$
 Home=�6=   $��30��6I   $��30��6T   $��Center=�6`   $��Center=�6|   5      5      � 5   
   $��1��6   $��20q�6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5       $��1* �6#   �� 5!      $��1* �6#   �� 5"      $��1* �6#   �� 5#      $��1* �6#   �� 5$      $��1* �6#    5&      �� 5'      $��1* �6    �� 5(      $��1* �6    .+�5+      � $��0��6   $��0��6    .+�5,      �� -   5        $ 	Dashboard��5,      $��	DASHBOARD��6,   $��20(�6X   ���	#FF114F52 $  MaterialDesignFlatAccentBgButton#��[ 6~   ���	#FF156064$
��auto��6�   $
��auto��6�   5-      � 5/      $��0��6   $��1��6    $��2��60   .+�50      �� -   5        $ AllRC��50      $��ALL RECIPE CREATORS��6(   $��28(�6Z   ���	#FF114F52#��[ 6�   ���	#FF00C49A$
��auto��6�   $
��auto��6�   51      � 53      $��0��6   $��3��6    .+�54      �� -   5        $ GestionProduitsButton��54      $��PRODUCTS��6\   $��20(�6o   ���	#FFED5D3D#��[ 6�   ���	#FFFA6C4D$
��auto��6�   $
��auto��6�   55      � 57      $��0��6   $��4��6    $��2��60   .+�58      �� -   5        $ GestionRecetteButton��58      $��ALL RECIPES��6Z   $��28(�6p   ���	#FFF1D43D#��[ 6�   ���	#FFD3B935$
��auto��6�   $
��auto��6�   59      � 5;      $��1��6   $��0��6    $��2��60   .+�5<      �� -   5        $ GestionClients��5<      $��CLIENT MANAGEMENTT��6N   $��28(�6k   ���	#FF7AC9D1#��[ 6�   ���	#FF4BB5BF$
��auto��6�   $
��auto��6�   5=      � 5?      $��1��6   $��2��6    .+�5@      �� -   5        $ AddAdmin��5@      $��	ADD ADMIN��6B   $��20(�6V   ���	#FF08B08C#��[ 6|   ���	#FF56A071$
��auto��6�   $
��auto��6�   5A      � 5C      $��1��6   $��3��6    $��3��60   .+�5D      �� -   5        $ WeeklyOderList��5D      $��WEEKLY ORDER LIST��6N   $��28(�6j   ���	#FFEAB3A7#��[ 6�   ���	#FFFFC2B4$
��auto��6�   $
��auto��6�   5E      5F      5G      5H      