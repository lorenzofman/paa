#include <cstdlib>
#include <iostream>
#include <chrono>
constexpr auto ELEMENTS_COUNT = 10;
constexpr auto RANGE = 10;
constexpr auto TESTS = 1000;

struct SubArray
{
	int start, end, sum;
	SubArray(int start, int end, int sum)
	{
		this->start = start;
		this->end = end;
this->sum = sum;
	}
};

SubArray Max(SubArray a, SubArray b)
{
	return (a.sum > b.sum) ? a : b;
}

SubArray Max(SubArray a, SubArray b, SubArray c)
{
	return Max(Max(a, b), c);
}

int* GenerateRandomArray(int maxElements, int min, int max)
{
	int* array = new int[maxElements];
	srand((unsigned int) time(0));
	for (int i = 0; i < maxElements; i++)
	{
		array[i] = rand() % (max - min) + min;
	}
	return array;
}

int QuadraticMaxSubarray(int* array, int elements)
{
	int start = 0, end = 0;
	int currentSum;
	int max = -RANGE;
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
	return max;
}


SubArray MaxMiddleSubarray(int* array, int left, int middle, int right)
{
	int leftBest = -RANGE;
	SubArray leftSubArray = SubArray(0, middle, 0);
	for (int i = middle; i >= left; i--)
	{
		leftSubArray.sum += array[i];
		if (leftSubArray.sum > leftBest)
		{
			leftSubArray.start = i;
			leftBest = leftSubArray.sum;
		}
	}

	int rightBest = -RANGE;
	SubArray rightSubArray = SubArray(middle + 1, 0, 0);
	for (int i = middle + 1; i <= right; i++)
	{
		rightSubArray.sum += array[i];
		if (rightSubArray.sum > rightBest)
		{
			rightSubArray.end = i;
			rightBest = rightSubArray.sum;
		}
	}

	return SubArray(leftSubArray.start, rightSubArray.end, leftBest + rightBest);
}
SubArray LinearLogMaxSubarray(int* array, int left, int right)
{
	if (left == right)
		return SubArray(left, right, array[left]);
	int middle = (left + right) / 2;
	SubArray leftBest = LinearLogMaxSubarray(array, left, middle);
	SubArray rightBest = LinearLogMaxSubarray(array, middle + 1, right);
	SubArray middleBest = MaxMiddleSubarray(array, left, middle, right);
	return Max(leftBest, rightBest, middleBest);
}

int LinearLogMaxSubarray(int* array, int elements)
{
	SubArray best = LinearLogMaxSubarray(array, 0, elements - 1);
	return best.sum;
}

int main()
{
	for (int i = 0; i < TESTS; i++) 
	{
		int* array = GenerateRandomArray(ELEMENTS_COUNT, -RANGE, RANGE);
		if (QuadraticMaxSubarray(array, ELEMENTS_COUNT) != LinearLogMaxSubarray(array, ELEMENTS_COUNT))
		{
			std::cout << "Algorithm problem\n";
		}
		delete array;
	}
}