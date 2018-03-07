#include "class_1.h"

void class_1::Filling_with_reiteration()
{
    for (int i=0; i<4; i++)
    {
        // a[i] = rand() % 10;
        a[0] = 1;
        a[1] = 2;
        a[2] = 2;
        a[3] = 2;
    }
}

void class_1::Filling_metadata()
{
    for (int i=0; i<4; i++)
    {
        metadata_a[a[i]]++;
    }
}

QString class_1::Result(int x) // Сделать const int* x
{
    QString str;
    int number = x; // Делаем копию числа, введёного с экрана
    cows = 0; // Обнуляем количество быков и коров
    bulls = 0;
    for (int i=0; i<4; i++) // Очищаем значения для вводимого числа
    {
        b[i] = -1;
    }
//    for (int i=0; i<10; i++)
//    {
//        metadata_b[i] = 0;
//    }
    int g = 3; // Последняя цифра числа
    while (g >= 0) // Переводим число, назвонное пользователем в массив целых чисел
    {
        b[g] = number % 10;
        number = number / 10;
        g--;
    }
    for (int i=0; i<4; i++) // Заполняем метаданные о введённом числе
    {
        metadata_b[b[i]]++;
    }
    for (int i=0; i<10; i++) // Считаем количество коров
    {
        if (metadata_a[i] < metadata_b[i])
        {
            cows = cows + metadata_a[i];
        }
        else
        {
            cows = cows + metadata_b[i];
        }
    }
    for (int i=0; i<4; i++) // Считаем количество быков
    {
        if (a[i] == b[i])
        {
            bulls++;
        }
    }
    str = QString::number(cows);
    str.append(" cows, ");
    str = str + QString::number(bulls);
    str.append(" bulls ");
    return str;
}

void class_1::Do_size_a_and_b(int x)
{
    size = x;
    a = new int[size];
    b = new int[size];
    for (int i=0; i<size; i++)
    {
        a[i]=-1;
        b[i]=-1;
    }
}
