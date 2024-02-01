Задача: Пример многофайловой сборки.

Создание многофайловой сборки Car
(текущий каталог в cmd/powershell/terminal должен быть "part 1")


1. Файл Auto.cs переведем в .NET модуль

```csc.exe /t:module auto.cs``` - создание .NET модуля 

2. Получили .net модуль, далее теперь создадим еще один класс Sportcar, но уже объединим его с модулем auto

```csc /t:library /addmodule:auto.netmodule /out:car.dll sportcar.cs``` - команда для создания car.dll

3. Создаем класс с точкой входа Main, который бы использовал нашу сборку Car.dll

```csc /r:car.dll Client.cs``` - команда финальной компиляции



