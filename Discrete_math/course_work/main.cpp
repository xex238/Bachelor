#include "mainwindow.h"
#include <QApplication>
#include <QSpinBox>
#include <QSlider>
#include <QHBoxLayout>
#include <Qt>
#include <cstdlib>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

     MainWindow w;
     w.Zapolnenie(); // Загадываем четырёхзначное число
     w.show();

    return a.exec();
}
