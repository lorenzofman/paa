import javafx.util.Pair;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws IOException
    {
        while(true)
        {
            ArrayList<Integer> array = new ArrayList<>();
            array.add(1);
            array.add(2);
            array.add(4);
            array.add(5);
            array.add(6);
            array.add(7);
            array.add(10);
            array.add(18);
            array.add(19);
            array.add(42);
            array.add(68);
            array.add(69);
            array.add(555);
            array.add(666);
            array.add(8080);
            array.add(192168);

            BinarySearch<Integer> search = new BinarySearch<>();
            System.out.println("Give me some integer to look for ya':");
            Scanner in = new Scanner(System.in);
            int num = in.nextInt();
            Pair<Integer, Integer> pair = search.IndexOf(array, num);
            System.out.println("Index of number:" + pair.getKey());
            System.out.println("Comparisons of number:" + pair.getValue());
        }
    }
}
