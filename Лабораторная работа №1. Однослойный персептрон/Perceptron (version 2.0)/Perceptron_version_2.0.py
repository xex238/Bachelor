import functions
import csv
import numpy as np
import random
import math
import copy

# Открытие файла через проводник
#import easygui
#csv_path = easygui.fileopenbox()

# Основное тело кода
# Считывание датасета из файла
my_dataset_path = "dataset/htru_2.csv"
Roma_dataset_path = "dataset/data_banknote_authentication_Roma_dataset.txt"
file_matrix = []
file_matrix = functions.read_from_file(Roma_dataset_path)
#print(file_matrix)

# Проверка датасета на корректность
functions.check_dataset(file_matrix)
print("Количество строк в исходном датасете: ", len(file_matrix))
print("Количество столбцов в исходном датасете: ", len(file_matrix[0]))
print()

# Конвертация значений исходной матрицы в тип float
for i in range(len(file_matrix)):
    file_matrix[i] = [float(j) for j in file_matrix[i]]

# Определение количества признаков, количества нейронов и количества весов
signs = []
signs.append(file_matrix[0][len(file_matrix[0]) - 1])
for i in range(len(file_matrix)):
    find = 0
    for j in range(len(signs)):
        if(signs[j] == file_matrix[i][len(file_matrix[i]) - 1]):
            find = 1
    if(find == 0):
        signs.append(file_matrix[i][len(file_matrix[i]) - 1])

count_of_signs = len(signs)
print("Количество признаков равно", len(signs))
print(signs)
print("Введите количество нейронов")
count_of_neurons = int(input())
lines_count_of_neurons = len(file_matrix[0])
columns_count_of_neurons = count_of_neurons
print("Количество весов в персептроне равно", lines_count_of_neurons * columns_count_of_neurons)
print()

# Генерация случайных значений для весов
np.random.seed(1)
synaptic_weights = []
for i in range(lines_count_of_neurons):
    helper_mas = []
    for j in range(columns_count_of_neurons):
        helper_mas.append(2 * np.random.random() - 1)
    synaptic_weights.append(helper_mas)

print("Случайные инициализирующие веса")
print(synaptic_weights)

print("Введите скорость обучения персептрона:")
speed = float(input())

#print("Введите количество эпох обучения:")
#count_of_eras = int(input())
count_of_eras = 100

# Составление слова признак - ключ, где признак - массив значений нейронов, ключ - номер признака (класса)
# discharges - разряды
# count_of_discharges = count_of_segments
count_of_discharges = math.ceil(count_of_signs / count_of_neurons)
if(count_of_discharges < 2):
    count_of_discharges = 2
key = []
key_value = []
for i in range(count_of_neurons):
    key.append(0)
key[0] = -1

print("key = ", key)

class_value = 0
# Количество рядом стоящих значений для одного класса
count_of_values_for_class = math.floor((count_of_discharges ** count_of_neurons) / count_of_signs)
# Количество первых классов с меньшим количеством рядом стоящих значений
count_of_first_classes = count_of_signs - ((count_of_discharges ** count_of_neurons) % count_of_signs)
print("count_of_values_for_class = ", count_of_values_for_class)
print("count_of_first_classes = ", count_of_first_classes)
for i in range(count_of_discharges ** count_of_neurons):
    key = functions.change(key, count_of_discharges)
    print("key = ", key)

    mas_helper = []
    mas_helper.append(copy.deepcopy(key))
    mas_helper.append(copy.deepcopy(class_value))
    key_value.append(mas_helper)

    if(i < count_of_values_for_class * count_of_first_classes):
        if((i % count_of_values_for_class) + 1 == count_of_values_for_class):
            class_value = class_value + 1
    elif(((i - count_of_values_for_class * count_of_first_classes) % (count_of_values_for_class + 1)) + 1 == count_of_values_for_class + 1):
        class_value = class_value + 1

print(key_value)

# Создание переменных для разделения исходного датасета на множества случайным способом
learn_training_inputs = []
learn_training_outputs = []
validation_training_inputs = []
validation_training_outputs = []
test_training_inputs = []
test_training_outputs = []
# Количество % из всего датасета для тестового множества
test_probability = 20
# Количество % из всего датасета для валидационного множества
validation_probability = 10

# Разделение исходного датасета на множества случайным способом
for i in range(len(file_matrix)):
    random_number = random.randint(1, 100)
    if(random_number > test_probability + validation_probability):
        learn_training_inputs.append(file_matrix[i])
        learn_training_outputs.append(file_matrix[i][len(file_matrix[i]) - 1])
        learn_training_inputs[len(learn_training_inputs) - 1].pop()
    elif(random_number <= validation_probability):
        validation_training_inputs.append(file_matrix[i])
        validation_training_outputs.append(file_matrix[i][len(file_matrix[i]) - 1])
        validation_training_inputs[len(validation_training_inputs) - 1].pop()
    else:
        test_training_inputs.append(file_matrix[i])
        test_training_outputs.append(file_matrix[i][len(file_matrix[i]) - 1])
        test_training_inputs[len(test_training_inputs) - 1].pop()

print("Размер обучающей выборки равен:", len(learn_training_inputs))
print("Это составляет", round((len(learn_training_inputs) / len(file_matrix) * 100), 2), "% от исходной выборки")
print("Размер тестовой выборки равен:", len(test_training_inputs))
print("Это составляет", round((len(test_training_inputs) / len(file_matrix) * 100), 2), "% от исходной выборки")
print("Размер валидационной выборки равен:", len(validation_training_inputs))
print("Это составляет", round((len(validation_training_inputs) / len(file_matrix) * 100), 2), "% от исходной выборки")
print()

# Нормализация входных данных (для входных значений - нелинейная, для выходных - линейная)
learn_training_inputs = functions.not_linear_matrix_normalization(learn_training_inputs)
validation_training_inputs = functions.not_linear_matrix_normalization(validation_training_inputs)
test_training_inputs = functions.not_linear_matrix_normalization(test_training_inputs)
learn_training_outputs = functions.linear_mas_normalization(learn_training_outputs)
validation_training_outputs = functions.linear_mas_normalization(validation_training_outputs)
test_training_outputs = functions.linear_mas_normalization(test_training_outputs)

# Единичный вход для нейронов
for i in range(len(learn_training_inputs)):
    learn_training_inputs[i].append(1)
for i in range(len(test_training_inputs)):
    test_training_inputs[i].append(1)
for i in range(len(validation_training_inputs)):
    validation_training_inputs[i].append(1)

exit()

# Обучение персептрона
activation_function = "sigmoid"
#activation_function = "softsign"
MSE_mas_learning = []
MSE_mas_test = []
accuracy_mas_learning = []
accuracy_mas_test = []
counter = 0
#while((counter < 2) or (MSE_mas_test[counter - 1] < MSE_mas_test[counter - 2])):
min_MSE = -1
min_MSE_era = 0
best_synaptic_weights = []
while(counter < count_of_eras):
    print("Эпоха обучения №", counter)
    print("Сейчас идёт обучающая выборка")
    functions.learning_function(learn_training_inputs, learn_training_outputs, synaptic_weights, speed, signs, activation_function, MSE_mas_learning, accuracy_mas_learning)
    print("Сейчас идёт тестовая выборка")
    functions.test_function(test_training_inputs, test_training_outputs, synaptic_weights, signs, 0, MSE_mas_test, accuracy_mas_test)
    counter = counter + 1
    if((min_MSE == -1) or (MSE_mas_test[len(MSE_mas_test) - 1] < min_MSE)):
        min_MSE = MSE_mas_test[len(MSE_mas_test) - 1]
        min_MSE_era = counter
        best_synaptic_weights = synaptic_weights
print("MSE_mas_learning = ")
print(MSE_mas_learning)
print("MSE_mas_test = ")
print(MSE_mas_test)

# Рисуем графики для MSE
functions.graph_drawing_function(MSE_mas_learning, MSE_mas_test, accuracy_mas_learning, accuracy_mas_test)

#print("Веса после обучения:")
#print(synaptic_weights)

# Проверка весов на валидационной выборке
MSE_mas_validation = []
accuracy_mas_validation = []
functions.test_function(validation_training_inputs, validation_training_outputs, best_synaptic_weights, signs, 1, MSE_mas_validation, accuracy_mas_validation)
print()
#print("Последняя MSE в обучающей выборке ", MSE_mas_learning[len(MSE_mas_learning) - 1])
#print("Последняя MSE в тестовой выборке ", MSE_mas_test[len(MSE_mas_test) - 1])
print("MSE в валидационной выборке ", MSE_mas_validation[0])