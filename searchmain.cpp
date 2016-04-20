#include "searchmain.h"
#include "ui_searchmain.h"

SearchMain::SearchMain(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::SearchMain)
{
    ui->setupUi(this);
}

SearchMain::~SearchMain()
{
    delete ui;
}
