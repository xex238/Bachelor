#include "cows_and_bulls.h"
#include <iostream>

Cows_and_bulls::Cows_and_bulls(int count_of_numbers_)
{
    count_of_numbers = count_of_numbers_;

    if (count_of_numbers % 2 == 0)
    {
        length_cdi_part_1 = count_of_numbers / 2;
        length_cdi_part_2 = count_of_numbers / 2;
    }
    else
    {
        length_cdi_part_1 = count_of_numbers / 2 + 1;
        length_cdi_part_2 = count_of_numbers / 2;
    }

    if (count_of_numbers >= 5)
    {
        length_cc = (10 - count_of_numbers) * 2;
        length_cb = length_cc;
    }
    else
    {
        length_cc = count_of_numbers * 2;
        length_cb = length_cc;
    }

    length_bn = 10 - count_of_numbers;

    cows_divided_in2parts = new int[count_of_numbers];
    check_cow = new int[length_cc];
    check_bull = new int[length_cb];
    bad_numbers = new int[length_bn];
    output = new int[count_of_numbers];

    for (int i = 0; i < count_of_numbers; i++)
    {
        cows_divided_in2parts[i] = -1;
    }
}

bool Cows_and_bulls::Step_1()
{
    // Загадывание числа
    if (count_of_numbers % 2 == 0)
    {
        for (int i = 0; i < count_of_numbers / 2; i++)
        {
            output[i] = count_of_tries;
        }
        for (int i = count_of_numbers / 2; i < count_of_numbers; i++)
        {
            output[i] = 9 - count_of_tries;
        }
    }
    else
    {
        for (int i = 0; i < count_of_numbers / 2 + 1; i++)
        {
            output[i] = count_of_tries;
        }
        for (int i = count_of_numbers / 2 + 1; i < count_of_numbers; i++)
        {
            output[i] = 9 - count_of_tries;
        }
    }

    for (int i = 0; i < count_of_numbers; i++)
    {
        std::cout << output[i];
    }

    std::cout << " ";

    std::cin >> cows;
    std::cin >> bulls;

    // Проверка ограничений
    while ((size_cdi_part_1 + size_cdi_part_2 + size_cc / 2 + size_cb > count_of_numbers) &&
        (size_bn + size_cc / 2 > length_bn) &&
        (cows > count_of_numbers) && (bulls > count_of_numbers))
    {
        std::cout << "Wrong count of cows and (or) bulls" << std::endl;
        std::cin >> cows;
        std::cin >> bulls;
    }

    sum_cows += cows;

    if ((cows == 0) && (bulls == 0))
    {
        bad_numbers[size_bn] = output[0];
        size_bn++;
        bad_numbers[size_bn] = output[count_of_numbers - 1];
        size_bn++;
    }
    if ((cows == 1) && (bulls == 0))
    {
        check_cow[size_cc] = output[count_of_numbers - 1];
        size_cc++;
        check_cow[size_cc] = output[0];
        size_cc++;
    }
    if ((cows == 1) && (bulls == 1))
    {
        check_cow[size_cc] = output[0];
        size_cc++;
        check_cow[size_cc] = output[count_of_numbers - 1];
        size_cc++;
    }
    if ((cows == 2) && (bulls == 0))
    {
        cows_divided_in2parts[size_cdi_part_1] = output[count_of_numbers - 1];
        size_cdi_part_1++;
        if (count_of_numbers % 2 == 0)
        {
            cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = output[0];
        }
        else
        {
            cows_divided_in2parts[count_of_numbers / 2 + 1 + size_cdi_part_2] = output[0];
        }
        size_cdi_part_2++;
    }
    if ((cows == 2) && (bulls == 1))
    {
        check_bull[size_cb] = output[0];
        size_cb++;
        check_bull[size_cb] = output[count_of_numbers - 1];
        size_cb++;
    }
    if ((cows == 2) && (bulls == 2))
    {
        cows_divided_in2parts[size_cdi_part_1] = output[0];
        size_cdi_part_1++;
        if (count_of_numbers % 2 == 0)
        {
            cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = output[count_of_numbers - 1];
        }
        else
        {
            cows_divided_in2parts[count_of_numbers / 2 + 1 + size_cdi_part_2] = output[count_of_numbers - 1];
        }
        size_cdi_part_2++;
    }

    count_of_tries++;

    for (int i = 0; i < count_of_numbers; i++)
    {
        std::cout << cows_divided_in2parts[i];
    }
    std::cout << std::endl;
    for (int i = 0; i < size_cc; i++)
    {
        std::cout << check_cow[i];
    }
    std::cout << std::endl;
    for (int i = 0; i < size_cb; i++)
    {
        std::cout << check_bull[i];
    }
    std::cout << std::endl;
    for (int i = 0; i < size_bn; i++)
    {
        std::cout << bad_numbers[i];
    }
    std::cout << std::endl;

    return (count_of_numbers == sum_cows);
}
