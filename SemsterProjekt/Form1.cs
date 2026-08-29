namespace SemsterProjekt
{
    public partial class Form1 : Form
    {
        private readonly List<Person> _persons = new();

        public Form1()
        {
            InitializeComponent();
            TxtOutput.ReadOnly = true;
            TxtOutput.WordWrap = false;
            TxtOutput.ScrollBars = ScrollBars.Both;
            TxtOutput.Font = new Font("Consolas", 10);

            // lese Werte aus Enums aus für Dropdown auswahl im Programm
            CmbSalutation.DataSource = Enum.GetValues<Salutation>();
            CmbGender.DataSource = Enum.GetValues<Gender>();
            CmbTitle.DataSource = Enum.GetValues<Title>();

            CmbDepartment.DataSource = Enum.GetValues<Job>(); 
            CmbManagmentLevel.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5}); // da Enum keine blosen Zahlen zulässt
            CmbManagmentLevel.SelectedIndex = 0; //Kaderstufe Standardmässig auf 0 setzen


            CmdSave.Click += CmdSave_Click; //verbindet Save Knopf mit methode

        }

        private void CmdSave_Click(object? sender, EventArgs e)
        {
                        
                Person person; //variable wird als Basisklasse gespeichert und kann anschliessend Kunde oder Mitarbeiter werden
                if (RadCustomer.Checked)
                {
                    person = CreateCustomer();
                }
                else if (RadEmployee.Checked)
                {
                    person = CreateEmployee();
                }
                else
                {
                    MessageBox.Show("Bitte Kunde oder Mitarbeiter auswählen.");
                    return;
                }
                _persons.Add(person);
                UpdateOutput();
                MessageBox.Show("Person wurde gespeichert");
        }

        private Customer CreateCustomer() //Methode um Kunde zu erstellen
        {
            Customer customer = new Customer
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                BirthDate = DateOnly.FromDateTime(DtBirthday.Value),
                MobilePhone = TxtPhoneNumberPrivate.Text,
                BusinessPhone = TxtPhoneNumberBuisness.Text,
                Email = TxtEmail.Text,
                IsActive = ChkActive.Checked,
                //Enums werden aus dropdown auswahl gelesen
                Salutation = (Salutation)CmbSalutation.SelectedItem!,
                Gender = (Gender)CmbGender.SelectedItem!,
                Title = (Title)CmbTitle.SelectedItem!
            };
            return customer;
        }

        private Employee CreateEmployee()
        {
            if (!int.TryParse(TxtPlzPrivat.Text,out int privatePostalCode))
            {
                throw new ArgumentException("Die private Postleitzahl muss eine Zahl sein.");
            }

            if (!int.TryParse(
                TxtEmployment.Text,
                out int employment))
            {
                throw new ArgumentException("Der Anstellungsgrad muss eine Zahl sein.");
            }

            int? businessPostalCode = null; //geschäftliche PLZ ist optional 

            if (!string.IsNullOrWhiteSpace(TxtPlzBuisness.Text))
            {
                if (!int.TryParse(TxtPlzBuisness.Text,out int parsedPostalCode)) //tryparse versucht Text in eine Zahl zu formatieren
                {
                    throw new ArgumentException("Die geschäftliche Postleitzahl muss eine Zahl sein.");
                }

                businessPostalCode = parsedPostalCode;
            }

            DateOnly? exitDate = null;

            if (DtExitDate.Checked)
            {
                exitDate = DateOnly.FromDateTime(DtExitDate.Value);
            }

            Employee employee = new Employee
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                BirthDate = DateOnly.FromDateTime(DtBirthday.Value),
                MobilePhone = TxtPhoneNumberPrivate.Text,
                BusinessPhone = TxtPhoneNumberBuisness.Text,
                Email = TxtEmail.Text,
                IsActive = ChkActive.Checked,

                Job = (Job)CmbDepartment.SelectedItem!,
                AhvNumber = TxtAhvNumber.Text,
                ManagmentLevel = (int)CmbManagmentLevel.SelectedItem!,

                Nationality = TxtNationality.Text,
                Employment = employment,
                EntryDate = DateOnly.FromDateTime(DtEntryDate.Value),
                ExitDate = exitDate,
                Trainee = ChkTrainee.Checked,

                Adressprivat = TxtAdressPrivat.Text,
                Plzprivat = privatePostalCode,
                Residance = TxtResidence.Text,

                Adressbuisness = TxtAdressBuisness.Text,
                PlzBuisness = businessPostalCode
            };

            TxtEmployeeNumber.Text = employee.EmployeeNumber.ToString();

            return employee;

        }



        private void UpdateOutput() //Methode um Anzeigeliste auszugeben
        {
            List<string> lines = new List<string>();  //provisorisch eingebaut um anzeige zu testen
            string header =
             $"{"Typ",-14}" + // Zahlen reservieren zeichen für die Spalte 
             $"{"Vorname",-16}" +
             $"{"Nachname",-16}" +
             $"{"Geburtsdatum",-16}" +
             $"{"Aktiv",-8}";

            lines.Add(header);
            lines.Add(new string('-', header.Length));

            foreach (Person person in _persons)
            {
                string type;
                if (person is Customer)
                {
                    type = "Kunde";
                }
                else
                {
                    type = "Mitarbeiter";
                }

                string birthDate = person.BirthDate.ToString("dd.MM.yyyy");

                string active;

                if (person.IsActive)
                {
                    active = "Ja";
                }
                else
                {
                    active = "Nein";
                }

                string row =
                     $"{type,-14}" +
                     $"{person.FirstName,-16}" +
                     $"{person.LastName,-16}" +
                     $"{birthDate,-16}" +
                     $"{active,-8}";

                lines.Add(row);
            }

            TxtOutput.Lines = lines.ToArray();
        }
    }
}
