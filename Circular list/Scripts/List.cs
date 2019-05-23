using System;
using System.Collections;

public class List : IEnumerable
{
    private Element head = null;
    private Element tail = null;
    private Element lastPositive = null;

    public int Count { get; private set; }

    public void Add(int data)
    {
        if (data > 0)
        {
            AddFirst(data);
        }
        else if (data == 0)
        {
            AddAfterPositive(data);
        }
        else
        {
            AddLast(data);
        }

    }

    /// <summary>
    /// Удаляет элемент, содержащий значение.
    /// </summary>
    /// <param name="data">Искомое значение для удаления.</param>
    public bool Remove(int data)
    {
        Element current = head;
        Element previous = null;

        do
        {
            if (current.Data.Equals(data))
            {
                // Если узел в середине или в конце
                if (previous != null)
                {
                    previous.Next = current.Next;
                    // Если узел последний, изменяем переменную tail
                    if (current == tail)
                    {
                        tail = previous;
                    }
                }
                else // если удаляется первый элемент
                {
                    if (Count == 1)
                    {
                        head = tail = null;
                    }
                    else
                    {
                        head = current.Next;
                        tail.Next = current.Next;
                    }
                }
                Count--;
                return true;
            }
            previous = current;
            current = current.Next;
        } while (current != head);
        return false;
    }

    public bool Contains(int data)
    {
        Element current = head;
        do
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        } while (current != head);
        return false;

    }

    /// <summary>
    /// Добавляет элемент в конец списка.
    /// </summary>
    private void AddLast(int data)
    {
        Element element = new Element(data);

        // Если нет элементов - добавляемый так же становится head.
        // Иначе последнему элементу добавляется next.
        if (head == null)
        {
            head = element;
            tail = element;
            tail.Next = head;
        }
        else
        {
            element.Next = head;
            tail.Next = element;
            tail = element;
        }
        Count++;
    }

    /// <summary>
    /// Добавляет элемент в начало списка.
    /// </summary>
    private void AddFirst(int data)
    {
        Element element = new Element(data);

        // Если добавляемый элемент - первый положительный.
        // Если список пуст или если head списка не положительный.
        if ((head == null) || (head.Data <= 0))
        {
            lastPositive = element;
        }
        element.Next = head;
        head = element;
        if (Count == 0)
        {
            tail = head;
        }
        tail.Next = head;
        Count++;
    }

    /// <summary>
    /// Добавляет элемент за последним положительным элементом.
    /// </summary>
    private void AddAfterPositive(int data)
    {
        Element element = new Element(data);

        // Если нет положительных элементов.
        if (lastPositive == null)
        {
            element.Next = head;
            head = element;
            // Если совсем нет элементов.
            if (Count == 0)
            {
                tail = head;
            }
            tail.Next = head;
        }
        else
        {
            element.Next = lastPositive.Next;
            lastPositive.Next = element;
            if (element.Next.Data > 0)
            {
                tail = element;
            }
            if (tail.Data > 0)
            {
                tail = FindLastZeroElement(element);
            }
        }
        Count++;
    }

    /// <summary>
    /// Возвращает первый элемент, у которого Next отрицательный.
    /// Если элемет последний - вызывает исключение.
    /// </summary>
    /// <param name="element">От какого элемента начать проверять.</param>
    /// <returns></returns>
    private Element FindLastZeroElement(Element element)
    {
        if (element.Next == head)
        {
            throw new Exception();
        }
        if (element.Next.Data >= 0)
        {
            FindLastZeroElement(element.Next);
        }
        return element;

    }

    // Реализация foreach.
    IEnumerator IEnumerable.GetEnumerator()
    {
        Element current = head;
        do
        {
            if (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        while (current != head);
    }
}
