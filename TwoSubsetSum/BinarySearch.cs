using System;
using System.Collections.Generic;

public class BinarySearch<T> where T : IComparable
{
    // Returns the index of an element inside a list
    // The array must be sorted to work
    // Also the reference class need to implement/extend Comparable
    public int IndexOf(List<T> list, T item, bool verbose)
    {
        // Start initial variable values
        // Comparison is used for debugging
        int comparisons = 0;
        // The initial range is the whole array, it can be at any index
        int low = 0, hi = list.Count;
        do
        {
            // Set index to half the range we are testing
            int middle = (low + hi) / 2;
            // The item at middle index is fetched from list
            T searchedItem = list[middle];
            // The difference is given in the Comparable interface
            // If the result is less than zero, searchedItem is lower than the item
            // If the result is equal to zero, searchedItem is equal to the item
            // If the result is greater than zero, searchedItem is greater than the item
            int difference = searchedItem.CompareTo(item);
            // Increase the number of comparisons needed
            comparisons++;

            //If difference is equal to zero, elements are the same and we found it
            //SearchedItem == item
            if (difference == 0)
            {
                // Call display comparisons if verbose is enabled
                DisplayComparisons(verbose, comparisons);
                // Return value
                return middle;
            }
            // Otherwise value is not the requested and we need to
            else
            {
                // SearchedItem > item
                if (difference > 0)
                {
                    // High became middle
                    // Because we are sure the element is lower than the middle point
                    // And it's useless to search in greater elements than the middle
                    hi = middle;
                }
                // SearchedItem < item
                else
                {
                    // Truncation might result in a endless loop when looking for a item not present in array
                    // Example: A = [1,4,6]
                    // Looking for five
                    // 0) lo = 0, hi = 2, middle = 1
                    // Element is greater than middle and we set low to middle
                    // 1) lo = 1, hi = 2, middle = 1 (truncation)
                    // And the endless loop
                    if (low == middle)
                    {
                        // Call display comparisons if verbose is enabled
                        DisplayComparisons(verbose, comparisons);
                        // Return a not found code
                        return -1;
                    }
                    // Low became middle
                    // Because we are sure the element is greater than the middle point
                    // And it's useless to search in lower elements than the middle
                    low = middle;
                }
            }
        } while (true);
    }

    public int IndexOfRecursive(List<T> list, T item, bool verbose)
    {
        return IndexOfRecursive(list, item, 0, list.Count, 0, verbose);
    }


    private int IndexOfRecursive(List<T> list, T item, int low, int hi, int comparisons, bool verbose)
    {
        // Set index to half the range we are testing
        int middle = (low + hi) / 2;
        // The item at middle index is fetched from list
        T searchedItem = list[middle];
        // The difference is given in the Comparable interface
        // If the result is less than zero, searchedItem is lower than the item
        // If the result is equal to zero, searchedItem is equal to the item
        // If the result is greater than zero, searchedItem is greater than the item
        int difference = searchedItem.CompareTo(item);
        //If difference is equal to zero, elements are the same and we found it
        //SearchedItem == item
        if (difference == 0)
        {
            // Call display comparisons if verbose is enabled
            DisplayComparisons(verbose, comparisons);
            // Return value
            return middle;
        }
        // Otherwise value is not the requested and we need to
        else
        {
            // SearchedItem > item
            if (difference > 0)
            {
                // High became middle
                // Because we are sure the element is lower than the middle point
                // And it's useless to search in greater elements than the middle
                return IndexOfRecursive(list, item, low, middle, comparisons + 1, verbose);
            }
            // SearchedItem < item
            else
            {
                // Truncation might result in a endless loop when looking for a item not present in array
                // Example: A = [1,4,6]
                // Looking for five
                // 0) lo = 0, hi = 2, middle = 1
                // Element is greater than middle and we set low to middle
                // 1) lo = 1, hi = 2, middle = 1 (truncation)
                // And the endless loop
                if (low == middle)
                {
                    // Call display comparisons if verbose is enabled
                    DisplayComparisons(verbose, comparisons);
                    // Return a not found code
                    return -1;
                }
                // Low became middle
                // Because we are sure the element is greater than the middle point
                // And it's useless to search in lower elements than the middle
                return IndexOfRecursive(list, item, middle, hi, comparisons + 1, verbose);
            }
        }
    }


    protected void DisplayComparisons(bool verbose, int comparisons)
    {
        if(verbose)
        {
            Console.WriteLine("Comparisons needed to find element: " + comparisons);
        }
    }


}
