//
// Created by skira21 on 5/31/22.
//

// This is made with Shared Libraries (SO) not DLL.

#ifndef C_COMMS_H
#define C_COMMS_H

#include <string>
namespace Tools {
    inline char* StrToChar(std::string str)
    {
        char* result = new char[str.length() + 1];

        for(int i = 0; i < str.length(); i++)
        {
            result[i] = str[i];

            if (i + 1 == str.length())
                result[i + 1] = '\0';
        }

        return result;
    }
}

// API Post MSG Handler
extern "C" char* CPostReply(const char* msg);
extern "C"  void DeleteCPointer(char* cPointer);

#endif //C_COMMS_H
