1. Применение
    Данное API используется для получения изображение, содержащего синусоидальный сигнал по заданным параметрам.
    Для его получения необходимо отправить POST запрос на "[host]:[port]/Main/GeneratePointSignal" с параметрами синусоидального сигнала: 
    А - амплитуда в условных единицах, 
    Fd - частота дискретизации сигнала в точках за секунду, 
    Fs - частота сигнала в герцах, 
    N - количество периодов.

2. Использованные библиотеки
    Microsoft.AspNet.WebApi.Core
    Microsoft.AspNetCore.OpenApi
    Swashbuckle.AspNetCore
    System.Drawing.Common

3. Совместимость
    System.Drawing не поддерживается на Linux и MacOS, следовательно, сервер с API должен быть на Windows.
