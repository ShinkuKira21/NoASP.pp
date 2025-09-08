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


// API Post MSG Handler
EXPORT char* CPostReply(const char* msg);
EXPORT void DeleteCPointer(char* cPointer);

#endif //C_COMMS_H
