   M S B A M L   `   `   `  ����M  IFootballManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FootballManagerAppFootballManagerApp  5      #    FootballManagerApp.RemoveTeam   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:FootballManagerApp     5        N� Title$  
RemoveTeam��5	      .��5      � ��5   
   �� 5       �� ImageSource$ /Background.jpg��6   .+�5   
   �� -   5         ��Name$
 Home��5      $
��Home��6   $
��Left=�6.   $��47��6I   $��	10,10,0,0q�6U   $	��Top=�6h   $��66��6�   $��16(�6�   6�   �� 5   
   -   5         ��Name$ 	TitleText��5      $��0q�6%   $��Center=�69   $��0,10,0,0q�6V   $��Remove Team��6h    �� TextWrapping$
 Wrap=�6{   $	��Top=�6�   $	��392��6�   $��61��6�    �� 
IsReadOnly$
 True��6�   
�������$��Center=�6�   $��Center=�6  $��36(�6@  $��Roland)�6N  ��6�   Z� ��6b  Z�  �� SelectionBrush 6y  Z� �� 5   
   -   5         ��Name$ TeamsListBox��5      $��43,143,431,65q�6(   �� 5   
   -   5        $ RemoveTeamsButton��5      $��Remove��6,   $
��Left=�6=   $��510,373,0,0q�6X   $	��Top=�6m   $��53��6�   $��86��6�   $��16(�6�   6�   �� 5   
   -   5        $ 
FilterTeam��5      $
��Left=�6&   $��439,288,0,0q�6A   $�� ��6V   $
 Wrap=�6^   $	��Top=�6r   $	��234��6�   $��34��6�   $��18(�6�   $��Center=�6�   �� 5   
   -   5        $ FilterTitle��5      $��0q�6'   $
��Left=�6;   $��439,211,0,0q�6V   $
 True��6k   $��Filter by Team Name :��6}   $
 Wrap=�6�   $	��Top=�6�   $	��234��6�   
�������$��Center=�6�   $��Center=�6  $��
Calisto MT)�6A  $��72��6�  $��22(�6�  ��6�   Z� ��6Y  Z�  6p  Z�  �� SelectionTextBrush 6�  Z� 6�  5      5      