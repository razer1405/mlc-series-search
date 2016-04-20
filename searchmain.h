#ifndef SEARCHMAIN_H
#define SEARCHMAIN_H

#include <QMainWindow>

namespace Ui {
class SearchMain;
}

class SearchMain : public QMainWindow
{
    Q_OBJECT

public:
    explicit SearchMain(QWidget *parent = 0);
    ~SearchMain();

private:
    Ui::SearchMain *ui;
};

#endif // SEARCHMAIN_H
