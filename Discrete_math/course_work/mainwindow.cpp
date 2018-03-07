#include "mainwindow.h"
#include "ui_mainwindow.h"

//MainWindow::MainWindow()
//{
//    ui->knopka->setEnabled(false);
//}

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_knopka_clicked()
{
    int temp = ui->textic->toPlainText().toInt(); // Забираем число из окошечка
    ui->textEdit->setText(cl.Result(temp));
}

void MainWindow::Zapolnenie()
{
    cl.Filling_with_reiteration();
}

void MainWindow::on_OK_clicked()
{
    int temp = ui->textic->toPlainText().toInt();
    cl.Do_size_a_and_b(temp);
    ui->textEdit->setText("Отгадайте число");
    ui->knopka->setEnabled(true);
    ui->OK->setEnabled(false);
}
