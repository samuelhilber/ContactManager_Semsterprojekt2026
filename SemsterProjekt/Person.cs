using System;
using System.Collections.Generic;
using System.Text;

namespace SemsterProjekt
{
    internal class Person //ist die Father class wovon Employee und Customer die selben Daten erben
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string MobilePhone { get; set; } = string.Empty;
        public string BusinessPhone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }
}
