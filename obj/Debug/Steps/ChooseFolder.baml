   M S B A M L   `   `   `  ����O  KFinanceiro Installer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Financeiro_Installer.StepsFinanceiro_Installer.Steps  5      -    'Financeiro_Installer.Steps.ChooseFolder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Financeiro_Installer.Steps     5      .��5	      � ���#FFFFFF$��5q�6      � RowDefinitions  5
   
   �� 5      $��45 �6   �� 5      $��45 �6   �� 5      6   �� 5      $��30 �6   .+�5   
   �� .+�5      �� Pasta de installação6.   � 5       � ColumnDefinitions 5      �� 5      �� 5      $��80 �6'   .+�5      �� -   5         ��Name$ PastaTB��5      6O   �� 5      -   5        $��	ProcurarB��5   ;   $��1��6   $��10,0,5,0q�6)   .��6d   
Procurar6n   5      5      � 5   
   $��1��6   .+�5      �� -   5        $��CreateShortcutCB��5   N   $��Center=�6   $��5q�62    d� 	IsChecked$
 TrueY�6=   .��6f   #!Criar atalho na área de trabalho6�   5      � 5   
   $��2��6   $��5q�6   .+�5      �� -   5        $��	StatusTBL��5      
Pendente63   � 5       $��0,20,0,0q�6   .+�5!      �� 
���   �$��1q�61    J� SnapsToDevicePixels . 6b   �� 5"      -   5        $��LogSV��5"   N   $��1q�6   $��Visible=�6&   .��5#      �� -   5        $��LogSP��5#   0   
�������5%      5&      5'      5(      � 5)   
   $��3��6   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5+      �� -   5         ��Name$ IniciarB��5+      {�.  $��0,0,10,0q�6=   .��6f   	Iniciar6o   5,      5-      5.      5/      