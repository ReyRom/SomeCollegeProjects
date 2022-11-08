#include "pch.h"
#include "framework.h"

extern "C"{
	__declspec(dllexport) const char* __stdcall size_sort(long long fileSize)
	{
		int gbyteDivider;
		__asm {
			mov eax, 1
			sal eax, 30
			mov gbyteDivider, eax
		}
		if (fileSize / (float)gbyteDivider > 1)
		{
			return "����� 1 ��";
		}
		else
		{
			int fileSizeShort = fileSize;
			__asm {
				mov eax, fileSizeShort
				cmp eax, 1024
				jb less_kbyte
				sar eax, 10
				cmp eax, 1024
				jb less_mbyte
				cmp eax, 10240
				jb less_10mbyte
			}
			return "����� 10 ��";
			
			__asm less_kbyte :
			return "����� 1 ��";

			__asm less_mbyte :
			return "����� 1 ��";

			__asm less_10mbyte :
			return "����� 1 ��";
		}
	}
}