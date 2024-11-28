#include <iostream>
#include <string>
using namespace std;

int main() {
    int num;
    string answer;
    
    cout << "Enter a number: ";
    cin >> num;
    cin.ignore(1000, '\n'); // Ignore newline character after integer input
    
    cout << "Enter a string: ";
    getline(cin, answer); // Input a string with spaces
    
    string s = "COMP";
    cout << s + "ILE" << endl;            // Concatenation: "COMPILE"
    cout << s.length() << endl;           // Length: 4
    cout << s[2] << endl;                 // Character at index 2: 'M'
    cout << s.substr(0, 3) << endl;       // Substring from index 0 of length 3: "COM"
    cout << s.substr(1) << endl;          // Substring from index 1 to end: "OMP"

    return 0;
}
