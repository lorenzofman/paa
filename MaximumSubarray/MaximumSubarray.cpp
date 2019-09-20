#include <cstdlib>
#include <iostream>
#include <chrono>
constexpr auto ELEMENTS_COUNT = 10;
constexpr auto RANGE = 10;


int* GenerateRandomArray(int maxElements, int min, int max)
{
    int* array = new int[maxElements];
    srand(time(0));
    for(int i = 0; i < maxElements; i++)
    {
        array[i] = rand() % (max - min) + min;
    }
    return array;
}

void PrintArray(int *array, int elements)
{
    for(int i = 0; i < elements; i++)
    {
        std::cout << array[i] << "\t";
    }
	std::cout << "\n\n";
}

void QuadraticMaxSubarray(int* array, int elements)
{
	int start = 0, end = 0;
	int currentSum;
	int max = ~1;
	for (int i = 0; i < elements; i++)
	{
		currentSum = 0;
		for (int j = i; j < elements; j++)
		{
			currentSum += array[j];
			if (currentSum > max)
			{
				start = i;
				end = j;
				max = currentSum;
			}
		}
	}
	std::cout << "Maximum subarray range is [" << start << ", " << end << "]\n\n";
	std::cout << "Max sum is: " << max;
}


int main()
{
	int* array = GenerateRandomArray(ELEMENTS_COUNT, -RANGE, RANGE);
	PrintArray(array, ELEMENTS_COUNT);
	QuadraticMaxSubarray(array, ELEMENTS_COUNT);
}