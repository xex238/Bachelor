#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <ctime>
#include "class_1.h"

namespace Ui
{
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    //MainWindow();

    class_1 cl = class_1(); // Переменная класса, где хранится и обрабатывается загаданное число
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

    void Zapolnenie();
private slots:

    void on_knopka_clicked();

    void on_OK_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
