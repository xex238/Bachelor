#include "cows_and_bulls.h"
#include <iostream>
using namespace std;

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

bool Cows_and_bulls::Pick_step()
{
	bool result{ false };
	if (step == 1)
	{
		result = Step_1();
	}
	if (step == 2)
	{
		result = Step_2();
	}
	if (step == 3)
	{
		result = Step_3();
	}
	return result;
}

bool Cows_and_bulls::Step_1()
{
	// Загадывание числа
	Filling_output(count_of_tries, 9 - count_of_tries);

	// Вывод массива output на экран
	Print_output();
	// Ввод коров и быков
	cout << " ";
	cin >> cows >> bulls;

	// Проверка ограничений
	Check_cows_and_bulls_for_valid_values_step_1();

	// Находим общую сумму коров
	sum_cows += cows;

	// Обработка данных
	Processing_cows_and_bulls_step_1();

	// Прибавляем номер попытки
	count_of_tries++;

	// Вывод вспомогательных значений на экран
	for (int i = 0; i < count_of_numbers; i++)
	{
		cout << cows_divided_in2parts[i];
	}
	cout << endl;
	for (int i = 0; i < size_cc; i++)
	{
		cout << check_cow[i];
	}
	cout << endl;
	for (int i = 0; i < size_cb; i++)
	{
		cout << check_bull[i];
	}
	cout << endl;
	for (int i = 0; i < size_bn; i++)
	{
		cout << bad_numbers[i];
	}
	cout << endl;
	//cout << "size_cdi_part_1 = " << size_cdi_part_1 << endl;
	//cout << "size_cdi_part_2 = " << size_cdi_part_2 << endl;
	//cout << "size_cc = " << size_cc << endl;
	//cout << "size_cb = " << size_cb << endl;
	//cout << "size_bn = " << size_bn << endl;

	// Проверяем условия для перехода на следующий этап
	Check_conditions_for_the_step_2();

	return (bulls == count_of_numbers);
}
void Cows_and_bulls::Check_cows_and_bulls_for_valid_values_step_1()
{
	retry_1:
	Check_cows_and_bulls_for_valid_values_level_1();
	if ((size_cdi_part_1 + size_cdi_part_2 + size_cc / 2 + size_cb + cows > count_of_numbers) &&
		(size_bn + size_cc / 2 + (2 - cows) > length_bn))
	{
		cout << "You made a mistake. Write cows and bulls again" << endl;
		cin >> cows >> bulls;
		goto retry_1;
	}
}
void Cows_and_bulls::Processing_cows_and_bulls_step_1()
{
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
}
void Cows_and_bulls::Check_conditions_for_the_step_2()
{
	if (size_cdi_part_1 + size_cdi_part_2 + size_cc / 2 + size_cb == count_of_numbers)
	{
		if (size_cdi_part_1 + size_cdi_part_2 == count_of_numbers)
		{
			step = 3;
		}
		else
		{
			step = 2;
		}
		for (int i = count_of_tries; i < 5; i++)
		{
			cout << "sgkjdghgdrfhhrkesfgifheru" << endl;
			bad_numbers[size_bn] = i;
			size_bn++;
			bad_numbers[size_bn] = 9 - i;
			size_bn++;
		}
	}
}

bool Cows_and_bulls::Step_2()  
{
	// Заполнение output в зависимости от исходных параметров
	Selection_for_Filling_output_step_2();

	// Выводим на экран массив output
	Print_output();

	// Ввод коров и быков
	cout << " ";
	cin >> cows >> bulls;

	// Проверка коров и быков на допустимые значения
	Check_cows_and_bulls_for_valid_values_step_2();

	// Обработка значений
	Processing_cows_and_bulls_step_2();

	// Прибавляем номер попытки
	count_of_tries++;

	// Вывод вспомогательных значений на экран
	for (int i = 0; i < count_of_numbers; i++)
	{
		cout << cows_divided_in2parts[i];
	}
	cout << endl;
	for (int i = 0; i < size_cc; i++)
	{
		cout << check_cow[i];
	}
	cout << endl;
	for (int i = 0; i < size_cb; i++)
	{
		cout << check_bull[i];
	}
	cout << endl;
	for (int i = 0; i < size_bn; i++)
	{
		cout << bad_numbers[i];
	}
	cout << endl;
	//cout << "id_check = " << id_check << endl;
	//cout << "size_cdi_part_1 = " << size_cdi_part_1 << endl;
	//cout << "size_cdi_part_2 = " << size_cdi_part_2 << endl;
	//cout << "size_cc = " << size_cc << endl;
	cout << "size_cb = " << size_cb << endl;
	//cout << "size_bn = " << size_bn << endl;

	// Проверяем условие на автозаполнение массива cows_divided_in_two_parts
	Check_automatic_filling_cows_divided_in_two_parts();

	// Проверяем условия для перехода на следующий этап
	Check_conditions_for_the_step_3();

	return (bulls == count_of_numbers);
}
void Cows_and_bulls::Selection_for_Filling_output_step_2()
{
	if ((size_cc != 0) && (size_cb != 0))
	{
		cout << "It's id_check = 23" << endl;
		Filling_output(check_cow[0], check_bull[1]);
		id_check = 23;
	}
	else if ((size_cc != 0) && (size_bn != 0))
	{
		cout << "It's id_check = 24" << endl;
		Filling_output(check_cow[0], bad_numbers[0]);
		id_check = 24;
	}
	else if ((size_cc != 0) && (size_cdi_part_1 != 0))
	{
		cout << "It's id_check = 211" << endl;
		Filling_output(cows_divided_in2parts[0], check_cow[1]);
		id_check = 211;
	}
	else if ((size_cc != 0) && (size_cdi_part_2 != 0))
	{
		cout << "It's id_check = 212" << endl;
		Filling_output(check_cow[0], cows_divided_in2parts[count_of_numbers / 2]);
		id_check = 212;
	}
	else if ((size_cb != 0) && (size_bn != 0))
	{
		cout << "It's id_check = 34" << endl;
		Filling_output(check_bull[0], bad_numbers[0]);
		id_check = 34;
	}
	else if ((size_cb != 0) && (size_cdi_part_1 != 0))
	{
		cout << "It's id_check = 311" << endl;
		Filling_output(cows_divided_in2parts[0], check_bull[1]);
		id_check = 311;
	}
	else if ((size_cb != 0) && (size_cdi_part_2 != 0))
	{
		cout << "It's id_check = 312" << endl;
		Filling_output(check_bull[0], cows_divided_in2parts[count_of_numbers / 2]);
		id_check = 312;
	}
	else if ((size_cc != 0) && (size_cb + size_bn + size_cdi_part_1 + size_cdi_part_2 == 0))
	{
		cout << "It's id_check = 22" << endl;
		Filling_output(check_cow[0], check_cow[3]);
		id_check = 22;
	}
}
void Cows_and_bulls::Check_cows_and_bulls_for_valid_values_step_2()
{
	retry_2:
	Check_cows_and_bulls_for_valid_values_level_1();

	if (id_check == 23)
	{
		if ((cows == 0) && (bulls == 0))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 24)
	{
		if (!((cows == 0) && (bulls == 0)) && !((cows == 1) && (bulls == 1)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 212)
	{
		if (!((cows == 1) && (bulls == 1)) && !((cows == 2) && (bulls == 2)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 211)
	{
		if (!((cows == 1) && (bulls == 1)) && !((cows == 2) && (bulls == 2)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 22)
	{
		if (((cows == 1) && (bulls == 0)) || ((cows == 2) && (bulls == 1)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 34)
	{
		if (!((cows == 1) && (bulls == 0)) && !((cows == 1) && (bulls == 1)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 312)
	{
		if (!((cows == 2) && (bulls == 1)) && !((cows == 2) && (bulls == 2)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
	else if (id_check == 311)
	{
		if (!((cows == 2) && (bulls == 1)) && !((cows == 2) && (bulls == 2)))
		{
			cout << "You made a mistake. Write cows and bulls again" << endl;
			cin >> cows >> bulls;
			goto retry_2;
		}
	}
}
void Cows_and_bulls::Processing_cows_and_bulls_step_2()
{
	if (id_check == 23)
	{
		if ((cows == 1) && (bulls == 0))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
			size_cdi_part_1++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
		}
		if ((cows == 1) && (bulls == 1))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[0];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[1];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
		}
		if ((cows == 2) && (bulls == 1))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
			bad_numbers[size_bn] = check_cow[1];
			size_bn++;
		}
		if ((cows == 2) && (bulls == 2))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[0];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[1];
			size_cdi_part_2++;
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
			bad_numbers[size_bn] = check_cow[1];
		}
		Moving_array(check_cow, size_cc);
		Moving_array(check_bull, size_cb);
	}
	else if (id_check == 24)
	{
		if ((cows == 0) && (bulls == 0))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
		}
		if ((cows == 1) && (bulls == 1))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
			bad_numbers[size_bn] = check_cow[1];
			size_bn++;
		}
		Moving_array(check_cow, size_cc);
	}
	else if (id_check == 212)
	{
		if ((cows == 1) && (bulls == 1))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
		}
		if ((cows == 2) && (bulls == 2))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
			bad_numbers[size_bn] = check_cow[1];
			size_bn++;
		}
		Moving_array(check_cow, size_cc);
	}
	else if (id_check == 211)
	{
		if ((cows == 1) && (bulls == 1))
		{
			bad_numbers[size_bn] = check_cow[1];
			size_bn++;
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
		}
		if ((cows == 2) && (bulls == 2))
		{
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
		}
		Moving_array(check_cow, size_cc);
	}
	else if (id_check == 22)
	{
		if ((cows == 0) && (bulls == 0))
		{
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
			bad_numbers[size_bn] = check_cow[3];
			size_bn++;
			cows_divided_in2parts[size_cdi_part_1] = check_cow[2];
			size_cdi_part_1++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
		}
		if ((cows == 1) && (bulls == 1))
		{
			// Выполняем дополнительную проверку
			Filling_output(check_cow[0], check_cow[2]);
			Print_output();

			cout << " ";
			cin >> cows >> bulls;

			retry_3:
			Check_cows_and_bulls_for_valid_values_level_1();
			if (!((cows == 0) && (bulls == 0)) && !((cows == 2) && (bulls == 1)))
			{
				cout << "You made a mistake. Write cows and bulls again" << endl;
				cin >> cows >> bulls;
				goto retry_3;
			}

			if ((cows == 0) && (bulls == 0))
			{
				bad_numbers[size_bn] = check_cow[0];
				size_bn++;
				bad_numbers[size_bn] = check_cow[2];
				size_bn++;
				cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
				size_cdi_part_2++;
				cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[3];
				size_cdi_part_2++;
			}
			if ((cows == 2) && (bulls == 1))
			{
				bad_numbers[size_bn] = check_cow[1];
				size_bn++;
				bad_numbers[size_bn] = check_cow[3];
				size_bn++;
				cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
				size_cdi_part_1++;
				cows_divided_in2parts[size_cdi_part_1] = check_cow[2];
				size_cdi_part_1++;
			}

			count_of_tries++;
		}
		if ((cows == 2) && (bulls == 2))
		{
			bad_numbers[size_bn] = check_cow[1];
			size_bn++;
			bad_numbers[size_bn] = check_cow[2];
			size_bn++;
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[3];
			size_cdi_part_2++;
		}
		Moving_array(check_cow, size_cc);
		Moving_array(check_cow, size_cc);
	}
	else if (id_check == 34)
	{
		if ((cows == 1) && (bulls == 0))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[0];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[1];
			size_cdi_part_2++;
		}
		if ((cows == 1) && (bulls == 1))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
			size_cdi_part_1++;
		}
		Moving_array(check_bull, size_cb);
	}
	else if (id_check == 312)
	{
		if ((cows == 2) && (bulls == 1))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[0];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[1];
			size_cdi_part_2++;
		}
		if ((cows == 2) && (bulls == 2))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
			size_cdi_part_1++;
		}
		Moving_array(check_bull, size_cb);
	}
	else if (id_check == 311)
	{
		if ((cows == 2) && (bulls == 1))
		{
			cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
			size_cdi_part_1++;
		}
		if ((cows == 2) && (bulls == 2))
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[0];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[1];
			size_cdi_part_2++;
		}
		Moving_array(check_bull, size_cb);
	}
}
void Cows_and_bulls::Check_automatic_filling_cows_divided_in_two_parts()
{
	if (size_cb != 0)
	{
		if (length_cdi_part_1 - size_cdi_part_1 < 2)
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[0];
			size_cdi_part_2++;
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_bull[1];
			size_cdi_part_2++;
		}
		if (length_cdi_part_2 - size_cdi_part_2 < 2)
		{
			cows_divided_in2parts[size_cdi_part_1] = check_bull[0];
			size_cdi_part_1++;
			cows_divided_in2parts[size_cdi_part_1] = check_bull[1];
			size_cdi_part_1++;
		}
		Moving_array(check_bull, size_cb);
	}
	if (size_cc != 0)
	{
		if (length_cdi_part_1 - size_cdi_part_1 == 0)
		{
			cows_divided_in2parts[count_of_numbers / 2 + size_cdi_part_2] = check_cow[1];
			size_cdi_part_2++;
			bad_numbers[size_bn] = check_cow[0];
			size_bn++;
		}
		if (length_cdi_part_2 - size_cdi_part_2 == 0)
		{
			cows_divided_in2parts[size_cdi_part_1] = check_cow[0];
			size_cdi_part_1++;
			bad_numbers[size_bn] = check_cow[1];
			size_bn++;
		}
		Moving_array(check_cow, size_cc);
	}
}
void Cows_and_bulls::Check_conditions_for_the_step_3()
{
	if (size_cdi_part_1 + size_cdi_part_2 == count_of_numbers)
	{
		step = 3;
	}
}

bool Cows_and_bulls::Step_3()
{
	// Заполнение output в зависимости от исходных параметров

	// Выводим на экран массив output
	Print_output();

	// Ввод коров и быков
	cout << " ";
	cin >> cows >> bulls;

	// Проверка коров и быков на допустимые значения

	// Обработка значений

	// Прибавляем номер попытки
	count_of_tries++;

	// Проверяем условие на автозаполнение массива result



	return (bulls == count_of_numbers);
}

void Cows_and_bulls::Print_output()
{
	for (int i = 0; i < count_of_numbers; i += 1)
	{
		cout << output[i];
	}
}
void Cows_and_bulls::Filling_output(int x_left_part, int x_right_part)
{
	for (int i = 0; i < count_of_numbers / 2; i++)
	{
		output[i] = x_left_part;
	}
	for (int i = count_of_numbers / 2; i < count_of_numbers; i++)
	{
		output[i] = x_right_part;
	}
}
void Cows_and_bulls::Moving_array(int* arr, int& size)
{
	for (int i = 0; i < size - 2; i++)
	{
		arr[i] = arr[i + 2];
	}
	size = size - 2;
}
void Cows_and_bulls::Check_cows_and_bulls_for_valid_values_level_1()
{
	while ((cows > 2) || (cows < 0) || (bulls > 2) || (bulls < 0) || (bulls > cows))
	{
		cout << "You made a mistake. Please, write a correct values" << endl;
		cin >> cows >> bulls;
	}
}
