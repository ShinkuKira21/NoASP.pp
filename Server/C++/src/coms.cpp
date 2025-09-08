//
// Created by skira21 on 5/31/22.
//
#include "coms.h"
#include "Tools/tools.hpp"


EXPORT char* CPostReply(const char* msg)
{
    std::string res = "Hello " + std::string(msg) + "! ";
    res += "This char* message is from C++";

    char* cStr = Tools::StrToChar(res);
    return cStr;
}

EXPORT void DeleteCPointer(char* cPointer)
{ delete[] cPointer; }