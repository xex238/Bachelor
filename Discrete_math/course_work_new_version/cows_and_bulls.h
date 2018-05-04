#ifndef Cows_and_bulls_
#define Cows_and_bulls_

class Cows_and_bulls
{
public:
	Cows_and_bulls(int count_of_numbers_);

	bool Pick_step();

	bool Step_1();
	void Check_cows_and_bulls_for_valid_values_step_1(); // Проверка ограничений после ввода быков и коров
	void Processing_cows_and_bulls_step_1(); // Обработка коров и быков на первом шаге
	void Check_conditions_for_the_step_2(); // Проверка условий для перехода на второй этап

	bool Step_2();
	void Selection_for_Filling_output_step_2();
	void Check_cows_and_bulls_for_valid_values_step_2(); // Проверка ограничений после ввода быков и коров
	void Processing_cows_and_bulls_step_2(); // Обработка быков и коров на втором шаге
	void Check_conditions_for_the_step_3(); // Проверка условий для перехода на третий этап

	bool Step_3();

	void Print_output(); // Вывод массива output на экран
	void Filling_output(int x_left_part, int x_right_part); // Метод для заполнения массива output[i]
	void Moving_array(int* arr, int& size);
	void Check_cows_and_bulls_for_valid_values_level_1(); // Проверка ограничений после ввода быков и коров (самая простая)
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
