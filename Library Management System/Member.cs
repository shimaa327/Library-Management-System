using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Library_Management_System
{
    public class Member : Person
    {
        public Member(string name) : base(name)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Member ID: {personID} , Name: {personName}");
        }
    }

}
