# -*- coding: utf-8 -*-
"""Polyreg.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/drive/1zb9GUwMuSf4FaipJylWmd4JwlMAXWbCi
"""

import numpy as np
import matplotlib.pyplot as plt

# y = 2x + 5 + e
X = np.vstack([np.ones(10), np.arange(4, 14)]).T
y = 2*X[:, 1] + 5 + np.random.randn(10)*3

X

plt.figure()
plt.scatter(X[:, 1], y)
plt.show()

"""# Regression"""

def get_reg_coeffs(X, y):
    # Матрица Грэма
    G = np.dot(X.T, X)
    # Матрица ошибок
    E = np.linalg.inv(G)
    # b = (X.T*X)^-1 * X.T*y
    b = np.dot(np.dot(E, X.T), y)
    return b

# Матрица Грэма. В нормализованом виде показывает корреляцию между факторами.
G = np.dot(X.T, X)
G

# Матрица ошибок
E = np.linalg.inv(G)
E

b = get_reg_coeffs(X, y)
b

"""# Построим график"""

def predict(X, b):
    return np.dot(X, b)

y_pred = predict(X, b)
y_pred

plt.figure()
plt.scatter(X[:, 1], y)
plt.plot(X[:, 1], y_pred, c='red')
plt.show()

"""# Полиномиальная регрессия"""

# Возьмём полином n-ой степени
n = 9
X = np.vstack([np.power(X[:, 1], i) for i in range(n)]).T
X

b = get_reg_coeffs(X, y)
y_pred = predict(X, b)

# Чтобы нарисовать идеально график, нам нужна выше детализация
X_min = X[:, 1].min() - 0.5
X_max = X[:, 1].max() + 0.5

X_0_plot=np.arange(X_min, X_max, step=0.01)
X_plot = np.vstack([np.power(X_0_plot, i) for i in range(n)]).T

y_pred = predict(X_plot, b)

plt.figure()
plt.scatter(X[:, 1], y)
plt.plot(X_0_plot, y_pred, c='red')
plt.show()

"""# Введём регуляризацию"""

# Матрица Грэма. В нормализованом виде показывает корреляцию между факторами.
G = np.dot(X.T, X)
G

# Введём регуляризационный компонент
G = G + np.diag(np.ones(X.shape[1]), k=0)*20

# Матрица ошибок
E = np.linalg.inv(G)
E

b = np.dot(np.dot(E, X.T), y)
b

y_pred = predict(X_plot, b)

plt.figure()
plt.scatter(X[:, 1], y)
plt.plot(X_0_plot, y_pred, c='red')
plt.show()

def ridge_regression(X, y, l):
    # Матрица Грэма
    G = np.dot(X.T, X)
    # Введём регуляризационный компонент
    G = G + np.diag(np.ones(X.shape[1]), k=0)*l
    # Матрица ошибок
    E = np.linalg.inv(G)
    # b = (X.T*X)^-1 * X.T*y
    b = np.dot(np.dot(E, X.T), y)
    return b

b = ridge_regression(X, y, 10)

plt.figure()
plt.bar(['0', '0.01', '0.5', '1', '10', '100'], np.array([ridge_regression(X, y, l) for l in [0, 0.01, 0.5, 1, 10, 100]]).mean(axis=1).T)
plt.show()

"""# Lasso"""

from sklearn.linear_model import Lasso, Ridge, LinearRegression

reg = Lasso()
# fit/predict

# show

"""# На данных"""

import pandas as pd
from sklearn.model_selection import train_test_split

data = pd.read_excel('Car_price_data.xlsx')

X = data.iloc[:, :6]
y = data.iloc[:, -1]

X_train, X_test, y_train, y_test = train_test_split(X, y)

reg = LinearRegression()
reg.fit(X_train, y_train)
reg.score(X_test, y_test), reg.score(X_train, y_train)

y_pred = reg.predict(X_test)
res = y_test - y_pred

plt.figure()
plt.scatter(y_pred, res)
plt.show()

"""### Добавим полиномиальных фич"""

from sklearn.preprocessing import PolynomialFeatures, normalize

X_poly = PolynomialFeatures(3, include_bias=False).fit_transform(X)

X_poly.shape

X_train_poly, X_test_poly, y_train, y_test = train_test_split(X_poly, y)

reg = Ridge(alpha=100)
reg.fit(X_train_poly, y_train)
reg.score(X_test_poly, y_test), reg.score(X_train_poly, y_train)

y_pred = reg.predict(X_test_poly)
res = y_test - y_pred
plt.figure()
plt.scatter(y_pred, res)
plt.show()

