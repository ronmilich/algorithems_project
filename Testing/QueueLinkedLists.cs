using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class QueueLinkedLists<T>
    {
        public TimeDataNode<T> _head;
        public TimeDataNode<T> _tail;

        public int Count { get; internal set; }

        public bool Contains(ref T yValue)
        {
            TimeDataNode<T> current = _head;

            while (current != null)
            {
                if (current.YValue.Equals(yValue))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        public void AddFirst(ref T yValue)
        {
            TimeDataNode<T> node = new TimeDataNode<T>(yValue);
            TimeDataNode<T> temp = _head;
            _head = node;
            _head.Next = temp;

            if (Count == 0)
                _tail = _head;
            else
                temp.Previous = _head;

            Count++;
        }

        public TimeDataNode<T> AddLast(ref T yValue)
        {
            TimeDataNode<T> node = new TimeDataNode<T>(yValue);

            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            Count++;

            return _tail;
        }

        public bool Remove(ref T yValue)
        {
            TimeDataNode<T> previous = null;
            TimeDataNode<T> current = _head;


            while (current != null)
            {
                if (current.YValue.Equals(yValue))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            _tail = previous;
                        else
                            current.Next.Previous = previous;

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                _head = _head.Next;
                Count--;

                if (Count == 0)
                    _tail = null;
                else
                    _head.Previous = null;
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _tail.Previous.Next = null;
                    _tail = _tail.Previous;
                }
                Count--;
            }
        }

        public List<T> RemoveOldData()
        {
            List<T> list = new List<T>();
            while (DateTime.Now.Subtract(_head.Time).TotalMinutes >= 20)
            {
                list.Add(_head.YValue);
                RemoveFirst();
            }
            return list;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            TimeDataNode<T> tmp = _head;

            while (tmp != null)
            {
                sb.AppendLine(tmp.YValue.ToString());
                tmp = tmp.Next;
            }

            return sb.ToString();
        }
    }
}
