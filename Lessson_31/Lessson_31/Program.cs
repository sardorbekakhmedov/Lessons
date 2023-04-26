

NewDelegate<string> delegate1 = Add1;


delegate1.Invoke("5", "5");


NewDelegate<int> delegate2 = Add2;
delegate2.Invoke(10, 9);

// event NewDelegate<string> event1 = Add1;



void Add1(string item, string value)
{
    Console.WriteLine(item + value);
}


void Add2(int item, int value)
{
    Console.WriteLine(item - value);
}


struct Shop
{
    
}

interface Shop1
{

}



delegate void NewDelegate<T>(T item1, T item2);