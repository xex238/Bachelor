#include "cows_and_bulls.h"
#include <iostream>

void Cows_and_bulls::Filling_output(int x_left_part, int x_right_part)
{
        for (int i=0; i<count_of_numbers/2; i++)
        {
            output[i]=x_left_part;
        }
        for (int i=count_of_numbers/2; i<count_of_numbers; i++)
        {
            output[i]=x_right_part;
        }
}

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
        length_cdi_part_1 = count_of_numbers / 2;
        length_cdi_part_2 = count_of_numbers / 2 + 1;
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
        for (int i = 0; i < count_of_numbers / 2; i++)
        {
            output[i] = count_of_tries;
        }
        for (int i = count_of_numbers / 2; i < count_of_numbers; i++)
        {
            output[i] = 9 - count_of_tries;
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
        cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = output[0];
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
        cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = output[count_of_numbers - 1];
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

void Cows_and_bulls::Moving_array(int* arr, int* size)
{
    for (int i = 0; i < size - 2; i++)
    {
        arr[i] = arr[i + 2];
    }
    size -= 2;
}

bool Cows_and_bulls::Step_2()
{
    if (size_cc!=0)
    {
        if (size_cb!=0)
        {
            Filling_output(check_cow[0],check_bull[1]);
            id_check = 23;
        }
        else
        {
            if (size_bn!=0)
            {
                Filling_output(check_cow[0], bad_numbers[0]);
                id_check = 24;
            }
            else
            {
                if (size_cdi_part_1 + size_cdi_part_2 != 0)
                {
                    if (size_cdi_part_2!=0)
                    {
                        Filling_output(check_cow[0],cows_divided_in2parts[count_of_numbers/2]);
                        id_check = 212;
                    }
                    else
                    {
                        Filling_output(cows_divided_in2parts[0],check_cow[1]);
                        id_check = 211;
                    }
                }
                else
                {
                    Filling_output(check_cow[0], check_cow[3]);
                    id_check = 22;
                }
            }
        }
    }
    else
    {
        if (size_cb!=0)
        {
            if (size_bn!=0)
            {
                Filling_output(check_bull[0], bad_numbers[0]);
                id_check = 34;
            }
            else
            {
                if (size_cdi_part_1 + size_cdi_part_2 != 0)
                {
                    if (size_cdi_part_2!=0)
                    {
                        Filling_output(check_bull[0],cows_divided_in2parts[count_of_numbers/2]);
                        id_check = 312;
                    }
                    else
                    {
                        Filling_output(cows_divided_in2parts[0],check_bull[1]);
                        id_check = 311;
                    }
                }
            }
        }
    }
    for (int i=0; i<count_of_numbers; i+=1)
    {
        std::cout << output[i];
    }
    //проверка ограничений(для каждого варианта у пользователя только несколько определенных ответов)
    cin >> cows >> bulls;
    //проверка на валидность
    switch (id_check)
    {
        case 23:
        {
            switch (cows, bulls)
            {
                case (cows == 1, bulls == 0):
                {
                    cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
                    size_cdi_part_1++;
                    cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
                    size_cdi_part_1++;
                    cows_divided_in2parts[size_cdi_part_2] = check_cow[1];
                    size_cdi_part_2++;
                    bad_numbers[size_bn] = check_cow[0];
                    size_bn++;
                    break;
                }
                case (cows == 1, bulls == 1):
                {
                    cows_divided_in2parts[size_cdi_part_2] = check_bull[0];
                    size_cdi_part_2++;
                    cows_divided_in2parts[size_cdi_part_2] = check_bull[1];
                    size_cdi_part_2++;
                    cows_divided_in2parts[size_cdi_part_2] = check_cow[1];
                    size_cdi_part_2++;
                    bad_numbers[size_bn] = check_cow[0];
                    size_bn++;
                    break;
                }
                case (cows == 2, bulls = 1):
                {
                    cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
                    size_cdi_part_1++;
                    cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
                    size_cdi_part_1++;
                    cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
                    size_cdi_part_1++;
                    bad_numbers[size_bn] = check_cow[1];
                    size_bn++;
                    break;
                }
                case (cows == 2, bulls == 2):
                {
                    cows_divided_in2parts[size_cdi_part_2] = check_bull[0];
                    size_cdi_part_2++;
                    cows_divided_in2parts[size_cdi_part_2] = check_bull[1];
                    size_cdi_part_2++;
                    cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
                    size_cdi_part_1++;
                    bad_numbers[size_bn] = check_cow[1];
                }
                default:
                {
                    Moving_array(check_cow, size_cc);
                    Moving_array(check_bull, size_cb);
                }
            }
            // Проверка на другое значение быков и коров
            break;
        }
        case 24:
        {
            switch (cows, bulls)
            {
                case (cows == 0, bulls == 0):
                {
                    cows_divided_in2parts[size_cdi_part_2] = check_cow[1];
                    size_cdi_part_2++;
                    bad_numbers[size_bn] = check_cow[0];
                    size_bn++;
                    break;
                }
                case (cows == 1, bulls == 1):
                {
                    cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
                    size_cdi_part_1++;
                    bad_numbers[size_bn] = check_cow[1];
                    size_bn++;
                    break;
                }
                default:
                {
                    Moving_array(check_cow, size_cc);
                }
            }
            break;
        }
        case 212:
        {
            switch (cows, bulls)
            {
                case (cows == 1, bulls == 1):
                {
                    cows_divided_in2parts[size_cdi_part_2] = check_cow[1];
                    size_cdi_part_2++;
                    bad_numbers[size_bn]=check_cow[0];
                    size_bn++;
                    break;
                }
                case (cows == 2, bulls == 2):
                {
                    cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
                    size_cdi_part_1++;
                    bad_numbers[size_bn]=check_cow[1];
                    size_bn++;
                    break;
                }
                default:
                {
                    Moving_array(check_cow, size_cc);
                }
            }
            break;
        }
        case 211:
        {
            break;
        }
        case 22:
        {
            break;
        }
        case 34:
        {
            break;
        }
        case 312:
        {
            break;
        }
        case 311:
        {
            break;
        }
    }
}
