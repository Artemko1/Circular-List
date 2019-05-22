public class Element
{
    public int Data { get; private set; }
    public Element Next { get; set; }

    public Element(int data)
    {
        Data = data;
    }
}
