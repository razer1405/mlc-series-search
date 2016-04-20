#include "searchmain.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    SearchMain w;
    w.show();

    return a.exec();
}
