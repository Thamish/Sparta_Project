   M S B A M L   `   `   `  ����M  IFootballManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FootballManagerAppFootballManagerApp  5      %    FootballManagerApp.RemovePlayer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:FootballManagerApp     5        N� Title$  RemovePlayer��5	       N� 
Background 5
      �� 5   
    j� Stretch$
 Fill=�6    �� ImageSource$ /Background.jpg��6$   .��5      � .+�5   
   �� -   5         ��Name$
 Home��5      $
��Home��6   $
��Left=�6.   $��47��6I   $��	10,10,0,0q�6U   $	��Top=�6h   $��66��6�   $��16(�6�   6�   �� 5   
   -   5         ��Name$ 	TitleText��5      $��0q�6%   $��Center=�69   $��0,10,0,0q�6V   $��Remove Player��6h    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��392��6�   $��61��6�    �� 
IsReadOnly$
 True��6�   
�������$��Center=�6�   $��Center=�6   $��36(�6B  $��Roland)�6P  ��6�   Z� ��6d  Z�  �� SelectionBrush 6{  Z� �� 5   
   -   5        	 ��Name$	 PlayersListBox��5      $��170,158,346,50q�6*   $��16(�6B   �� 5   
   -   5        $ RemovePlayerButton��5      $��Remove��6-   $
��Left=�6>   $��544,418,0,0q�6Y   $	��Top=�6n   $��53��6�   $��86��6�   $��16(�6�   6�   �� 5   
   -   5        $ FirstNamefilter��5      
 �� 	MaxLength$
 12��6+   $
��Left=�6:   $��500,257,0,0q�6U   $�� ��6j   $
 Wrap=�6r   $	��Top=�6�   $	��193��6�   $��29��6�    J� RenderTransformOrigin$ 0.583,0.093&�6�   $��18(�6�   $��Center=�6
  �� 5   
   -   5         ��Name$ Positionfilter��5      $
��Left=�6+   $��518,336,0,0q�6F   $	��Top=�6[   $	��138��6s   $��36��6�   $��18(�6�   $��Center=�6�   $��Center=�6�   �� 5   
   -   5        $ FilterTitle��5      $��0q�6'   $
��Left=�6;   $��481,226,0,0q�6V   $
 True��6k   $��Filter by First Name :��6}   $
 Wrap=�6�   $	��Top=�6�   $	��212��6�   
�������$��Center=�6�   $��Center=�6  $��
Calisto MT)�6B  $��18(�6�  ��6�   Z� ��6Z  Z�  6q  Z�  �� SelectionTextBrush 6�  Z� 6�  5      5      