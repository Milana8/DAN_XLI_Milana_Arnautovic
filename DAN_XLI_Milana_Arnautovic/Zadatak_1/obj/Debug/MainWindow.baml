   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Zadatak_1	Zadatak_1  5   	       Zadatak_1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Zadatak_1     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   .��5	      � .+�5
   
   � -   5        $��pbStatus��5      $y�Visible=�5      $��Center=�5      $��0��5      $��42��5       � Minimum$ 0Q�5       � Maximum$	 100Q�6   $��75,335,52,192q�5       � Value 5      �� *CurrentProgress+ �� Mode$ OneWay=�5      �� 5   
   -   5         ��Name$ Printing��5      $��Printing��6$   $��170,426,492,109q�5       J� RenderTransformOrigin$ 0.471,1.427&�6+   6O   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��487,426,172,109q�5      $ 1.035,0.968&�6*   6N   �� 5   
   -   5         ��Name$
 Text��5   M   $
��Left=�6   $	��220��6-   $��	10,35,0,0q�6:    �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��490��6*   �� 5   
   -   5        	 ��Name$	 	TextLabel��5   K   $��Write text to print: ��6   $
��Left=�60   $��	10,10,0,0q�5      $	��Top=�6#   $ -0.282,-0.378&�5      $	��140��66   �� 5!   
   -   5        $	 CopiesLabel��5!   [   $��Number of copies:��6   $
��Left=�6,   $��
530,66,0,0q�6G   $	��Top=�5"      $ 1.623,1.035&�5#      �� 5%   
   -   5        $ Number��5%   9   $
��Left=�6   $��23��6-   $��
654,69,0,0q�5&      $
 Wrap=�6&   $	��Top=�6:   $��39��6R   $ -0.055,1.17&�5'      �� 5)   
   -   5        $	 Label��5)   ,   $
��Left=�6   $��108,382,0,0q�5*      $	��Top=�6%   $	��352��6=   �� 5,   
   -	   5        $	 
Percentage��5,      $
��Left=�6%   $��
75,280,0,0q�6@   $	��Top=�6T   $ -0.526,0.385&�5-      $��75��66   51      52      