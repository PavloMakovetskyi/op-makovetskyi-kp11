   M S B A M L   `   `   `  ����G  CMultiProgram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab01_OPLab01_OP  5   	       Lab01_OP.StudentsDatabase   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Lab01_OP     5   	   -   5          �Name$  StudentsDatabaseWindow��5   	    � Title$ StudentsDatabase��5   	   $	��450��6"   $	��800��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q    � WindowStyle$
 None=�6v   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF493E5F��6   � 5      $ 	#FF0F6F2B��6    � Offset$ 1Q�6-   � 5      $ 	#FF38777F��6   $ 0.572Q�6-   � 5      $ 	#FF1B3F98��6   $
 0.99Q�6-   5      .��5      � .+�5   
   �� $��Database��6   $
��Left=�6#   $��
354,10,0,0q�6>   $	��Top=�6R   $��Cascadia Mono)�6j   $��24(�6�   
�������6�   �� 5   
   $��Adding��6   $
��Left=�6!   $��379,102,0,0q�6<   $	��Top=�6Q   
�������$��Cascadia Mono Light)�6|   $��18(�6�   	 � Cursor$	  ��6�   �� 5   
   -   5        
 ��Name$
 IDBox��5      $
��Left=�6!   $��251,177,0,0q�6<    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $��60��6}   $��48��6�   $��20(�6�   �� 5   
   $��ID��6   $
��Left=�6   $��270,146,0,0q�68   $	��Top=�6M   
�������$��Cascadia Code ExtraLight)�6x   �� 5   
   -   5        $
 SNP_Box��5      $
��Left=�6#   $��354,177,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��176��6   $��48��6�   $��20(�6�   �� 5   
   $
��Name��6   $
��Left=�6   $��416,148,0,0q�6:   $	��Top=�6O   $��Cascadia Code ExtraLight)�6g   
�������6�   �� 5   
   -   5        $
 
Number_Box��5      $
��Left=�6&   $��574,177,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��164��6�   $��48��6�   $��20(�6�   �� 5   
   $��Phone Number��6   $
��Left=�6'   $��611,147,0,0q�6B   $	��Top=�6W   
�������6o   �� 5   
   -   5         ��Name$ 	AddButton��5      $	��Add��6$   $
��Left=�62   $��
471,98,0,0q�6M   $	��Top=�6a   $��35��6y   $	��123��6�   $��18(�6�   6�   �� 5   
   $��(Remove by ID)��6   $
��Left=�6)   $��106,146,0,0q�6D   $	��Top=�6Y    J� RenderTransformOrigin$ 0.925,-0.514&�6q   $��Cascadia Code ExtraLight)�6�   
�������6�   �� 5   
   -   5        $ RemoveButton��5      $��Remove��6'   $
��Left=�68   $��106,182,0,0q�6S   $	��Top=�6h   $ 0.408,0.324&�6�   $��43��6�   $	��108��6�   $��18(�6�   6�   �� 5   
   -   5        $ MainMenuButton��5      $��	Main Menu��6)   $
��Left=�6=   $��	23,22,0,0q�6X   $	��Top=�6k   $��52��6�   $	��137��6�   $��16(�6�   6�   5      5       