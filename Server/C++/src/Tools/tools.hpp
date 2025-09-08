#include <string>

namespace Tools {
    inline char* StrToChar(std::string str)
    {
        char* result = new char[str.length() + 1];

        for(int i = 0; i < str.length(); i++)
            result[i] = str[i];

        result[str.length()] = '\0';

        return result;
    }
}