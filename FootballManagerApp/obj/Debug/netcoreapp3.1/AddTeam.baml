   M S B A M L   `   `   `  ����M  IFootballManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FootballManagerAppFootballManagerApp  5           FootballManagerApp.AddTeam   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:FootballManagerApp     5        N� Title$  AddTeam��5	      .��5      � ��5   
   �� 5       �� ImageSource$ /Background.jpg��6   .+�5   
   �� -   5         ��Name$
 Home��5      $
��Home��6   $
��Left=�6.   $��47��6I   $��	10,10,0,0q�6U   $	��Top=�6h   $��66��6�   $��16(�6�   6�   �� 5   
   -   5         ��Name$ 	TitleText��5      $��0q�6%   $��Center=�69   $��0,10,0,0q�6V   $��Add New Team��6h    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��392��6�   $��61��6�    �� 
IsReadOnly$
 True��6�   
�������$��Center=�6�   $��Center=�6  $��36(�6A  $��Roland)�6O  ��6�   Z� ��6c  Z�  �� SelectionBrush 6z  Z� �� 5   
   -   5        $ TeamNameTitle��5      $��0q�6)   $
��Left=�6=   $��
43,110,0,0q�6X   $
 True��6l   $��Team Name* :��6~   $
 Wrap=�6�   $	��Top=�6�   $	��122��6�   
�������$��Center=�6�   $��Center=�6  $��16(�69  $��
Calisto MT)�6G  ��6�   Z� ��6_  Z�  6v  Z�  �� SelectionTextBrush 6�  Z� �� 5   
   -   5        $ TeamNameText��5       �� 	MaxLength$ 25��6(   $
��Left=�6U   $��
43,133,0,0q�6p   $��	Team Name��6�   $
 Wrap=�6�   $	��Top=�6�   $	��283��6�   $��45��6�   $��Center=�6�   $��Center=�6�   #��� ��6  $��16(�6n  �� 5   
   -   5        	 ��Name$	 SelectedPlayersListBox��5      $��43,261,474,44q�62   �� 5   
   -   5        $	 PlayersListBox��5      $��481,175,47,44q�6*   �� 5   
   -   5        $ 	AddButton��5      $	��Add��6$   $��Center=�62   $��	0,300,0,0q�6O   $	��Top=�6b   $��59��6z   $��68��6�   6�   �� 5   
   -   5        $ RemoveButton��5      $��Remove��6'   $��Center=�68   $��	0,383,0,0q�6U   $	��Top=�6h   $��59��6�   $��68��6�   6�   �� 5   
   -	   5        $ SelectedPlayersTitle��5      $��0q�60   $
��Left=�6D   $��
43,224,0,0q�6_   $
 True��6s   $��Selected Players :��6�   $
 Wrap=�6�   $	��Top=�6�   $	��141��6�   
�������$��Center=�6   $��Center=�6"  $��16(�6F  $��
Calisto MT)�6T  ��6�   Z� ��6l  Z�  6�  Z�  6�  Z� �� 5   
   -
   5        $ 
SubmitTeam��5      $��Submit��6%   $
��Left=�66   $��
687,10,0,0q�6Q   $	��Top=�6e   $��47��6}   $��66��6�   $��16(�6�   6�   �� 5   
   -   5        $ FirstNamefilter��5      $ 12��6+   $
��Left=�6:   $��481,146,0,0q�6U   $�� ��6j   $
 Wrap=�6r   $	��Top=�6�   $	��115��6�   $��24��6�   �� 5   
   -   5        
 ��Name$
 Positionfilter��5      $
��Left=�6+   $��633,147,0,0q�6F   $	��Top=�6[   $	��120��6s   6   �� 5   
   -   5        $ FilterTitle��5      $��0q�6'   $
��Left=�6;   $��481,127,0,0q�6V   $
 True��6k   $��Filter by First Name :��6}   $
 Wrap=�6�   $	��Top=�6�   $	��115��6�   
�������$��Center=�6�   $��Center=�6  $��
Calisto MT)�6B  ��6�   Z� ��6Z  Z�  6q  Z�  6�  Z� 5      5      