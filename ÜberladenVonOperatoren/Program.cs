using System;

namespace ÜberladenVonOperatoren
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class AnimalList
    {
        private class Element
        {
            public Animal a;
            public Element next;
            public Element previous;
            public Element(Animal a, Element previous, Element next)
            {
                this.a = a;
                this.previous = previous;
                this.next = next;
            }
        }
        private Element head = null;
        private Element tail = null;
        
        public AnimalList()
        {
            head = null;
            tail = null;
        }
        public static AnimalList operator +(AnimalList list,Animal newAnimal)
        {
            Element newElement = new Element(newAnimal, null, null);
            if (list.head==null)
            {
                list.head = newElement;
                list.tail = newElement;
                
            }
            else
            {
                Element oldLast = list.tail;
                Element newLast = newElement ;
                oldLast.next = newElement;
                newElement.previous = oldLast;
                list.tail = newElement;
                 
            }
            return list;
        }
        public static string operator *(AnimalList liste,int zahl)
        {
            Element temp = liste.head;
            string s = "";
            while (temp!=null)
            {
                Console.Write(temp.a.Name+": ");
                for (int i = 0; i < zahl-1; i++)
                {
                    s+=temp.a.Sound +" ";
                    
                }

                temp = temp.next;
                Console.WriteLine();
            }
            return s;
            
        }
        public static implicit  operator string(AnimalList list)
        { string s = "";
            Element temp = list.head;
            while (temp!=null)
            {
                s += temp.a.Name +" ";
                temp = temp.next;
            }
           
            return s;
        }


    }
    class Animal
    {
        public string Name;
        public string Sound;
        public void MakeSound()
        {
            Console.WriteLine(Sound);
        }
        public Animal(string name, string sound)
        {
            this.Sound = sound;
            this.Name = name;
        }
    }
}
