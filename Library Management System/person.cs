using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Library_Management_System
{
    public abstract class Person : IDisplayable
    {
        private static int nexpersonID = 1;
        public int personID { get; private set; }
        public string personName { get; set; }

        public Person(string personName)
        {
            personID = nexpersonID++;
            this.personName = personName;
        }
       
           public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {personID}, Name: {personName}");
        }
    }

    }

