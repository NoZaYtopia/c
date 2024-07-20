// Дюны.cpp : Определяет точку входа для приложения.
//

#include "framework.h"
#include <random>
#include <time.h>
#include "дюны.h"

#define MAX_LOADSTRING 100

// Глобальные переменные:
HINSTANCE hInst;                                // текущий экземпляр
WCHAR szTitle[MAX_LOADSTRING];                  // Текст строки заголовка
WCHAR szWindowClass[MAX_LOADSTRING];            // имя класса главного окна

// Отправить объявления функций, включенных в этот модуль кода:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPWSTR    lpCmdLine,
    _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Разместите код здесь.

    // Инициализация глобальных строк
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_MY, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Выполнить инициализацию приложения:
    if (!InitInstance(hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY));

    MSG msg;

    // Цикл основного сообщения:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int)msg.wParam;
}



//
//  ФУНКЦИЯ: MyRegisterClass()
//
//  ЦЕЛЬ: Регистрирует класс окна.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDC_MY));
    wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_MY);
    wcex.lpszClassName = szWindowClass;
    wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   ФУНКЦИЯ: InitInstance(HINSTANCE, int)
//
//   ЦЕЛЬ: Сохраняет маркер экземпляра и создает главное окно
//
//   КОММЕНТАРИИ:
//
//        В этой функции маркер экземпляра сохраняется в глобальной переменной, а также
//        создается и выводится главное окно программы.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
    hInst = hInstance; // Сохранить маркер экземпляра в глобальной переменной

    HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

    if (!hWnd)
    {
        return FALSE;
    }

    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);

    return TRUE;
}

//
//  ФУНКЦИЯ: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  ЦЕЛЬ: Обрабатывает сообщения в главном окне.
//
//  WM_COMMAND  - обработать меню приложения
//  WM_PAINT    - Отрисовка главного окна
//  WM_DESTROY  - отправить сообщение о выходе и вернуться
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    const int N = 30;
    static int f[N][N] = {}, k[N][N] = {}, nf[N][N] = {}, n[N][N] = {}, x_scr0, y_scr0, x_scr, y_scr, sum, l, left, right, top, bottom;
    double p, r;
    switch (message)
    {
    case WM_CREATE:
        srand(time(NULL));
        l = 15;
        p = 0.5;
        x_scr0 = 0;
        y_scr0 = 0;
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
            {
                r = (double)rand() / RAND_MAX;
                // k - состояние клетки изначальное. Можно сделать так, чтобы неактивные клетки никогда не участвовали в процессе, если закинуть эту строку в нижний цикл
                k[i][j] = 1;
                if (r < p)
                {
                    //f - это состояние клетки в этой иттерации.
                    //nf - соотвественно, в следующей.
                    //n - время, сколько клетка прячется
                    f[i][j] = 1;
                    nf[i][j] = 1;
                    n[i][j] = 3;
                    
                }
                SetTimer(hWnd, 1, 1000, NULL);
            }



        break;
    case WM_TIMER:
        InvalidateRect(hWnd, NULL, TRUE);
        break;
    case WM_COMMAND:
    {
        int wmId = LOWORD(wParam);
        // Разобрать выбор в меню:
        switch (wmId)
        {
        case IDM_ABOUT:
            DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
            break;
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
    }
    break;
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);
        SelectObject(hdc, GetStockObject(DC_PEN));
        SelectObject(hdc, GetStockObject(DC_BRUSH));
        SetDCPenColor(hdc, RGB(0, 0, 0));
        SetDCBrushColor(hdc, RGB(0, 255, 0, ));
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
            {
                f[i][j] = nf[i][j];
                if (f[i][j] == 1)
                {
                    x_scr = i * l;
                    y_scr = j * l;
                    Rectangle(hdc, x_scr + x_scr0, y_scr + y_scr0, x_scr + l + x_scr0, y_scr + l + y_scr0);
                }
            }
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
            {
                if (i == 0) left = N - 1;
                else left = i - 1;
                if (i == N - 1) right = 0;
                else right = i + 1;
                if (j == 0) top = N - 1;
                else top = j - 1;
                if (j == N - 1) bottom = 0;
                else bottom = j + 1;
                sum = f[left][top] + f[left][j] + f[left][bottom] + f[i][top] + f[i][bottom] + f[right][top] + f[right][j] + f[right][bottom];
                
                //Цикл будет работать только, если время равно 3. Если клетка остается или становится активной
                //то время n не будет меняться. Если условия не выполняется else n будет увеличиваться на 1
                if (n[i][j] == 3)
                {
                    if (f[i][j] == 0)
                    {
                        switch (sum)
                        {
                        // Если клетка неактивна, то она станет активной (возьмет состояние k), если рядеом не более 1 активного соседа
                        case 0: nf[i][j] = k[i][j]; n[i][j] = n[i][j]; break;
                        case 1: nf[i][j] = k[i][j]; n[i][j] = n[i][j]; break;
                        default: nf[i][j] = 0; n[i][j] = 0; break;
                        }
                    }
                    else
                    {
                        switch (sum)
                        {
                        //Активная клетка будет прятаться, если рядом есть 4 и более активных клеток.
                        case 0: nf[i][j] = f[i][j]; n[i][j] = n[i][j]; break;
                        case 1: nf[i][j] = f[i][j]; n[i][j] = n[i][j]; break;
                        case 2: nf[i][j] = f[i][j]; n[i][j] = n[i][j]; break;
                        case 3: nf[i][j] = f[i][j]; n[i][j] = n[i][j]; break;
                        default: nf[i][j] = 0; n[i][j] = 0; break;
                        }
                    }
                }
                else
                {
                    n[i][j] = n[i][j] + 1;
                }
                
            }
        EndPaint(hWnd, &ps);
    }
    break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

// Обработчик сообщений для окна "О программе".
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
