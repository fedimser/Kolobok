===HOW TO CREATE LEVELS===

You can create your own levels. Name files "Level[num].dat", where [num] is number of level and put them to /Levels folder. Numbers should be serial.
First line of file must consist of two integers: width and height of level in pixels.
Then you have to describe game objects in next way:

0 X Y W H - Static rectangular block. X - Top border, Y - Left border, W - width, H - height;
1 X Y W H X1 Y1 - Moving rectangular block. X - Top border, Y - Left border, W - width, H - height, (X1,Y1) - coordinates of top and left borders in other position;
2 X Y W H - Portal. X - Top border, Y - Left border, W - width, H - height. This line should meet at least once. 
3 X Y W H - Trampoline. X - Top border, Y - Left border, W - width, H - height. Recommended size 40x20.
4 X Y - Coin. {X,Y} - coordinates of center (Radius 10);
5 X Y W H - Unvisible block for stopping mobs. Recommended size 50x100;
6 X Y - Drug. {X,Y} - coordinates of center (Radius 10);
10 X Y - Start position of Kolobok. This line should meet exactly once.
 
Enemies:
11 X Y - Fox
12 X Y - Rabbit
13 X Y - Bear
14 X Y - Wolf

WARNING: Split numbers with exactly one space!

You can make comments after "//" in any line and leave empty lines.

Good luck!

(c) Dmytry Fedoryaka, 2013
    e-mail fedimser@yandex.ru
	web-site http://mitay.at.ua

	
	
===��� ��������� ������=== 

�� ������ ��������� ���� ����������� ������. ��� ����� ��������� ����� "Level[num].dat", ��� [num] - ��� ����� ������ � ��������� �� � ����� /Levels. ������ ������ ���� �����������������.
������ ������ ����� ������ �������� �� ���� ����� �����: ������ � ������ �������.
���� �� ������ ������� ������� ���� ��������� �������:

0 X Y W H - ����������� ������������� ����. X - ������� �������, Y - ����� �������, W - ������, H - ������;
1 X Y W H X1 Y1 - ��������� ������������� ����. X - ������� �������, Y - ����� �������, W - ������, H - ������, (X1,Y1) - ���������� ������� � ����� ������� � ������ ������� ���������. ���� ����� ��������� ��������, ������������, ������������� � ���������� ���, ��� ��� ����� ������� ���� ����� ��������� ����� ������� ����� ������� {X,Y} � {X1,Y1};
2 X Y W H - ������. X - ������� �������, Y - ����� �������, W - ������, H - ������. ������������� ������ 100�100. ��� ������ ������ ����������� ���� �� ���� ���.
3 X Y W H - ��������. X - ������� �������, Y - ����� �������, W - ������, H - ������. ������������� ������ 40x20;
4 X Y - ������� (���� � ������, ���� ���������� �� 10). {X,Y} - ���������� ������ (������ 10);
5 X Y W H - ��������� ���� ��� ����������� �������� ������. ��� ������� � ���� - �� ����������. ������������� ������ 50x100;
6 X Y - �������� (���� � ������, ��� ����� �������� ����). {X,Y} - ���������� ������ (������ 10);
10 X Y - ��������� ��������� �������. ��� ������ ������ ����������� ����� ���� ���.
 
����� (X,Y - ���������� ������)
11 X Y - ����
12 X Y - ����
13 X Y - �������
14 X Y - ����

���������� ������ "� �������". ��� ������ �� ������������ � �������������� ������������ � ����� ����� ��������� ����� ��� ������ (��������) �� ������������ � ������� ��� �������������. ��� ������������ ��� �����������.

��������: ���������� ����� ����� ����� ��������!

�� ������ ��������� ����������� ����� "//" � ����� ������, � ����� ��������� ������ ������.
�����!


(c) ������� ��������, 2013, ���������-�������-������������.
    e-mail fedimser@yandex.ru
	���� http://mitay.at.ua