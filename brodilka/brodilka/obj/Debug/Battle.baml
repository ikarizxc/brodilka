   M S B A M L   `   `   `  ����  brodilka    brodilka.BattleWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  BattleWindow��5   	   $	��300��6   $	��480��6+    � 
ResizeMode$ NoResize=�6P    � WindowStyle$
 None=�6f   .��5      � .+�5   
   �� -   5         ��Name$ heroHP��5      $
��Left=�6$   $��	16,66,0,0q�6?   $
��Wrap=�6R   $��Здоровье: 0��6f   $	��Top=�6y    J� RenderTransformOrigin$ 0.478,0.764&�6�   $��Sylfaen)�6�   $��14(�6�   $	��100��6�    �� TextAlignment$ Center=�6�   �� 5   
   -   5        $ 	combatLog��5      $��Center=�6'   $��0,63,0,0q�6D   $
��Wrap=�6V   $	��Top=�6j   $	��169��6�   $	��158��6�   $��Sylfaen)�6�   $��16(�6�   $ Center=�6�   �� 5   
   -   5        $ 	enemyName��5      $
��Left=�6'   $��
351,13,0,0q�6B   $
��Wrap=�6V   $	��Top=�6j   $	��119��6�   $��50��6�   $)��#Rekkul, Champion of the Blood Guard��6�   $ Center=�6�   $��Mathcad UniMath Prime)�6�   $��14(�6�   �� 5	   
   -   5        $ heroName��5	      $
��Left=�6&   $��	10,15,0,0q�6A   $
��Wrap=�6T   $	��Top=�6h   $	��100��6�   $��47��6�   $$��Гервант из Ливии��6�   $ Center=�6�   $��Sylfaen)�6�   $��16(�6�   $ 	0.443,0.6&�6�   �� 5
   
   -   5         ��Name$ enemypic��5
      $
��Left=�6"   $��85��6=   $��362,100,0,0q�6I   $	��Top=�6^   $	��100��6v   $ 
0.51,0.503&�6�   �� 5   
   -   5        $ heropic��5      $
��Left=�6!   $	��100��6<   $��
16,117,0,0q�6I   $	��Top=�6]   $	��100��6u   $��pics/hero.jpg��6�   �� 5   
   -   5        $ enemyHP��5      $
��Left=�6%   $��
362,66,0,0q�6@   $
��Wrap=�6T   $��Здоровье: 0��6h   $	��Top=�6{   $ 0.462,0.543&�6�   $��Sylfaen)�6�   $��Normal"�6�   $��Normal$�6�   $��14(�6�   $	��100��6  $ Center=�6  �� 5   
   -	   5         ��Name$ attackButton1��5      $��Heroic Strike��6(   $
��Left=�6@   $��
16,188,0,0q�6[   $	��Top=�6o   $	��100��6�   $	��0.1q�6�    J� Opacity$	 0.7Q�6�   
�������$��Mathcad UniMath Prime)�6�   	 � ToolTip$(	 "Attack the enemy with your weapon.��6	  �� 5   
   -
   5        $ attackButton2��5      $��Electrocute��6(   $
��Left=�6>   $��
16,210,0,0q�6Y   $	��Top=�6m   $	��100��6�   $	��0.1q�6�   $	 0.7Q�6�   
�������$��Mathcad UniMath Prime)�6�   $/	 )Electrocute the enemy with your gauntlet.��6  $y�Hidden=�6;  �� 5   
   -   5        $ attackButton3��5      $��Flame Blast��6(   $
��Left=�6>   $��
16,232,0,0q�6Y   $	��Top=�6m   $	��100��6�   $	��0.1q�6�   $	 0.7Q�6�   
�������$��Mathcad UniMath Prime)�6�   $A	 ;Cast a powerful Fire spell that will incinerate your enemy.��6  $y�Hidden=�6M  �� 5   
   -   5        $
 heal��5      $
��Heal��6   $
��Left=�6.   $��
16,254,0,0q�6I   $	��Top=�6]   $	��100��6u   $	��0.1q�6�   $	 0.7Q�6�   
�������$��Mathcad UniMath Prime)�6�   $4	 .Pray to the gods that they will replenish you.��6�   $y�Hidden=�60  5      5      