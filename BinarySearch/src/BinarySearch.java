import javafx.util.Pair;

import java.util.Collection;
import java.util.List;

public class BinarySearch<T extends Comparable>
{
    public Pair<Integer,Integer> IndexOf(List<T> list, T item)
    {
        int comparisons = 0;
        int low = 0, hi = list.size();
        do{
            int middle = (low + hi)/2;
            T searchedItem = list.get(middle);
            int difference = searchedItem.compareTo(item);
            comparisons++;
            if(difference == 0)
            {
                return new Pair<>(middle, comparisons);
            }
            else
            {
                if(difference > 0) // searchedItem > item
                {
                    if(hi == middle)
                    {
                        return new Pair<>(-1, comparisons);
                    }
                    hi = middle;
                }
                else
                {
                    if(low == middle)
                    {
                        return new Pair<>(-1, comparisons);
                    }
                    low = middle;
                }
            }
        } while(true);
    }

}
