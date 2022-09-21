//
// Created by skira21 on 5/31/22.
//

/* WINDOWS COMPILER:
    VS NOTE ONLY: Make sure to build the C# and C++ project with same Debug/Release to prevent any weird errors.
*/

#ifndef C_COMMS_H
#define C_COMMS_H

// selects if it's a Linux Shared Object or Windows DLL
#if defined(_WIN32) | defined(_WIN64)
    #define EXPORT extern "C" _declspec(dllexport)
#else
    #define EXPORT extern "C"
#endif

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
EXPORT char* CPostReply(const char* msg);
EXPORT void DeleteCPointer(char* cPointer);

#endif //C_COMMS_H
