#pragma once
#ifndef Cows_and_bulls_
#define Cows_and_bulls_

class Cows_and_bulls
{
public:
    Cows_and_bulls(int count_of_numbers_);
    // Метод для заполнения массива output[i]
    void Filling_output(int x_left_part, int x_right_part);
    void Moving_array(int* arr, int* size);
    bool Step_1();
    bool Step_2();
private:
    int count_of_numbers{ 0 };

    int* cows_divided_in2parts;
    int* check_cow;
    int* check_bull;
    int* bad_numbers;
    int* output;

    int size_cdi_part_1{ 0 };
    int size_cdi_part_2{ 0 };
    int size_cc{ 0 };
    int size_cb{ 0 };
    int size_bn{ 0 };

    int length_cdi_part_1{ 0 };
    int length_cdi_part_2{ 0 };
    int length_cc{ 0 };
    int length_cb{ 0 };
    int length_bn{ 0 };

    int step{ 1 };

    int count_of_tries{ 0 };

    int cows{ 0 };
    int bulls{ 0 };

    int sum_cows{ 0 };

    int id_check{ 0 };
};

#endif // !Cows_and_bulls_
