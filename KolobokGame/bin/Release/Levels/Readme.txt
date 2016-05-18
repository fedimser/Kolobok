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

	
	
===КАК СОЗДАВАТЬ УРОВНИ=== 

Вы можете создавать свои собственные уровни. Для этого называйте файлы "Level[num].dat", где [num] - это номер уровня и помещайте их в папку /Levels. Номера должны быть последовательными.
Первая строка файла должна состоять из двух целых чисел: ширины и высоты уровния.
Ниже Вы должны описать объекты игры следующим образом:

0 X Y W H - Неподвижный прямоугольный блок. X - Верхняя граница, Y - левая граница, W - ширина, H - высота;
1 X Y W H X1 Y1 - Подвижный прямоугольный блок. X - Верхняя граница, Y - левая граница, W - ширина, H - высота, (X1,Y1) - координаты верхней и левой границы в другом крайнем положении. Блок будет двигаться циклично, прямолинейно, поступательно и равномерно так, что его левый верхний угол будет двигаться вдоль отрезка между точками {X,Y} и {X1,Y1};
2 X Y W H - Портал. X - Верхняя граница, Y - левая граница, W - ширина, H - высота. Рекомендуемый размер 100х100. Эта строка должна встречаться хотя бы один раз.
3 X Y W H - Трамплин. X - Верхняя граница, Y - левая граница, W - ширина, H - высота. Рекомендуемый размер 40x20;
4 X Y - Монетка (если её съесть, счёт увеличится на 10). {X,Y} - координаты центра (радиус 10);
5 X Y W H - Невидимый блок для ограничения движения врагов. Для колобка и пуль - не существует. Рекомендуемый размер 50x100;
6 X Y - Таблетка (если её съесть, все блоки поменяют цвет). {X,Y} - координаты центра (радиус 10);
10 X Y - Начальное положение Колобка. Эта строка должна встречаться ровно один раз.
 
Враги (X,Y - координаты центра)
11 X Y - Лиса
12 X Y - Заяц
13 X Y - Медведь
14 X Y - Волк

Создавайте врагов "в воздухе". Они упадут до столкновения с горизонтальной поверхностью и затем будут двигаться влево или вправо (случайно) до столкновения с блоками или ограничителми. При столкновении они развернутся.

Внимание: Разделяйте числа ровно одним пробелом!

Вы можете оставлять комментарии после "//" в любой строке, а также оставлять пустые строки.
Удачи!


(c) Дмитрий Федоряка, 2013, Кременчуг-Брисбен-Долгопрудный.
    e-mail fedimser@yandex.ru
	сайт http://mitay.at.ua