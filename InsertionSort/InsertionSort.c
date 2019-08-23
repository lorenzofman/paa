#include <stdio.h>

void insert(int* v, int *element)
{
	int key = *element;
	for (int* it = element - 1; it >= v; it--)
	{
		if (*it < key)
		{
			*(it+1) = key;
			return;
		}
		*(it + 1) = *it;
	}
	*v = key;
}

void recursiveInsertionSort(int* v, int* f)
{
	if (f == v)
		return;
	recursiveInsertionSort(v, f - 1);
	insert(v, f);
}

void insertionSort(int* v, int size)
{
	recursiveInsertionSort(v, v + size - 1);
}


int main()
{
	int size = 16;
	int v[] = { 4, 2, 3, 5, 12, 8, 10, 9, 42, 65, 11, 1, 0, 40, 20, 30};
	insertionSort(v, size);
	for (int i = 0; i < size; i++)
	{
		printf("%i\n", v[i]);
	}
}