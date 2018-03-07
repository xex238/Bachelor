#ifndef CLASS_1_H
#define CLASS_1_H

#include <iostream>
#include <QMainWindow>

class class_1
{
public:
    class_1() = default;
    ~class_1() = default;
    int* a; // Здесь лежит загаданное компьютером число
    int* b; // Число, которое ввёл пользователь
    int size{ 0 }; // Длина числа
    int metadata_a[10]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Сведения о загаданном числе (количество цифр в числе)
    int metadata_b[10]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Сведения о числе, который ввёл пользователь
    int bulls{ 0 }; // Количество быков
    int cows{ 0 }; // Количество коров
    void Do_size_a_and_b(int x);
    void Filling_with_reiteration(); // Создаём случайное число с повторяющимимся цифрами
    void Filling_metadata(); // Заполняем массив о количестве повторяющихся цифр в числе
    QString Result(int x); // Проверяем поступающее число на количество быков и коров
};

#endif // CLASS_1_H
