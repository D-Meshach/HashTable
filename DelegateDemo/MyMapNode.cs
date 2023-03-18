using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            // Console.WriteLine("\npion=" + position+"hashcode="+key.GetHashCode());
            return Math.Abs(position);
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {

            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {

                    return item.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {

                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }

        }
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }

        }


    }

    public class inputs {
        public inputs() {

            String exit = "n";
            while (exit == "n")
            {
                Console.WriteLine("Enter \n 1) For Frequency of word \n 2) Find Frequency in sentence ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1: SingleWordFrequency(); break;
                    //case 2: MultiWordFrequency(); break;
                    

                }

                Console.WriteLine("Do You wish to exit (y/n)?");
                exit = Convert.ToString(Console.ReadLine());
            }

        }
        public void SingleWordFrequency() {

            MyMapNode<String, String> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "to");
            hash.Add("5", "be");
            String hash5 = hash.Get("5");
            Console.WriteLine("5th index console value is " + hash5);
            String hash2 = hash.Get("2");
            Console.WriteLine("2nd index console Value is " + hash2);

        }
        //Multiword Added
        public void MultiWordFrequency()
        {
            int count = 0;
            String para = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            String[] text = para.Split(' ');
            MyMapNode<String, String> hashpara = new MyMapNode<string, string>(5);
            foreach (String texts in text)
            {

                Console.WriteLine("\nPosition= " + Convert.ToString(count) + " word" + count + "= " + texts + "\n");
                hashpara.Add(Convert.ToString(count), texts);
                count++;

            }
            Console.WriteLine("value First index position is " + hashpara.Get("1"));
            Console.WriteLine("value Second index position is " + hashpara.Get("2"));
            Console.WriteLine("value Third index position is " + hashpara.Get("3"));
            



        }






    }
}

