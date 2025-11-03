#include <iostream>
#include <string>
#include <vector>
#include <functional>

using namespace std;


class EventHandler {
private: 
    vector<function<void(const string&)>> listeners;
public:
    void AddListener(function<void(const string&)> listener) {
        listeners.push_back(listener);
    }

    void Invoke(const string& message) {
        for (auto& listener : listeners) {
            listener(message);
        }
    }

    size_t GetListener() const {
        return listeners.size();
    }
};



void ConsoleLogger(const string& message) {
    cout << "[LOG] " << message << endl;
}

void EmailLogger(const string& message) {
    cout << "[EMAIL] " << message << endl;
}

void FileLogger(const string& message) {
    cout << "[FILE] " << message << endl;
}







// Ссылка на функцию.
using MathOperation = int(*)(int, int);

int Add(int a, int b) {
    return a + b;
}

int Multiply(int a, int b) {
    return a * b;
}

// Массив указателей на функцию (аналог Делегата)
using StringFormatter = string(*)(const string&);

string ToUpper(const string& str) {
    string result = str;
    for (char& c : result)
        c = toupper(c);
    return result;
}

string ToLower(const string& str) {
    string result = str;
    for (char& c : result)
        c = tolower(c);
    return result;
}

string AddVoskl(const string& str) {
    return str + "!";
}


string AddQuestion(const string& str) {
    return str + "?";
}

int main()
{
    //MathOperation op = Add;
    //cout << op(5, 3) << endl;

    //op = Multiply;
    //cout << op(5, 3) << endl;


    //vector<StringFormatter> delegates = {
    //    ToLower,
    //    ToUpper,
    //    AddVoskl,
    //    AddQuestion
    //};

    //string text = "Hello World";

    //cout << "Исходный текст" << text;

    //for (auto formatter : delegates) {
    //    string  result = formatter(text);
    //    cout << "Результат: " << result;
    //}


    EventHandler eventHandler;
    eventHandler.AddListener(ConsoleLogger);
    eventHandler.AddListener(FileLogger);
    eventHandler.AddListener(EmailLogger);


    eventHandler.Invoke("Произошла ошибка!");
    
    eventHandler.AddListener(
        [](const  string& msg) {
            cout << "[LAMBDA] " << msg << endl;
        }
    );

    eventHandler.Invoke("Произошла ошибка!");


    return 0;
}
