using System;
using System.Collections.Generic;
using System.Text;

namespace SemsterProjekt
{
    internal class Customer : Person
    {
        public Salutation Salutation { get; set; }
        public Gender Gender { get; set; }
        public Title Title { get; set; }
    }

    public enum Salutation
    {
        None,
        Herr,
        Frau,
        Divers
    }

    public enum Gender
    {
        Mann,
        Frau,
        Divers
    }

    public enum Title
    {
        Professor,
        Doktor
    }
}
