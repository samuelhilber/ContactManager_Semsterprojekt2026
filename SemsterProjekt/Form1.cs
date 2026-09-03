namespace SemsterProjekt;

using System.Text.Json;

public partial class Form1 : Form
{
    private EmployeeManager _employeeManager = new EmployeeManager();
    private CustomerManager _customerManager = new CustomerManager();
    private Employee? _selectedEmployee;
    private Customer? _selectedCustomer;

    private readonly DataStorage _datastorage = new DataStorage();

    public Form1()
    {
        InitializeComponent();
        TxtOutput.Click += TxtOutput_Click;
        TxtOutput.ReadOnly = true;
        TxtOutput.WordWrap = false;
        TxtOutput.ScrollBars = RichTextBoxScrollBars.Both;
        TxtOutput.Font = new Font("Consolas", 10);

        // lese Werte aus Enums aus für Dropdown auswahl im Programm
        CmbSalutation.DataSource = Enum.GetValues<Salutation>();
        CmbGender.DataSource = Enum.GetValues<Gender>();
        CmbTitle.DataSource = Enum.GetValues<Title>();

        CmbDepartment.DataSource = Enum.GetValues(typeof(Job));
        CmbDepartment.SelectedIndex = 0;
        CmbManagmentLevel.DataSource = Enumerable.Range(0, 5).ToList(); // 0,1,2,3,4
        CmbManagmentLevel.SelectedIndex = 0;
        RadCustomer.Checked = true;

        LoadData();
    }



    private void CmdSave_Click(object sender, EventArgs e)
    {
        DateOnly birthDate = DateOnly.FromDateTime(DtBirthday.Value); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
        DateOnly entryDate = DateOnly.FromDateTime(DtEntryDate.Value); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
        DateOnly exitDate = DateOnly.FromDateTime(DtExitDate.Value); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
        int.TryParse(TxtPlzPrivat.Text, out int privatePostalCode); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
        int.TryParse(TxtEmployment.Text, out int employment); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
        int.TryParse(TxtPlzBuisness.Text, out int businessPostalCode); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können

        if (RadCustomer.Checked)
        {
            var customer = _customerManager.AddCustomer(
                TxtFirstName.Text,
                TxtLastName.Text,
                DateOnly.FromDateTime(DtBirthday.Value),
                TxtPhoneNumberPrivate.Text,
                TxtEmail.Text,
                TxtPhoneNumberBuisness.Text,
                (Salutation)CmbSalutation.SelectedItem!,
                (Gender)CmbGender.SelectedItem!,
                (Title)CmbTitle.SelectedItem!,
                out var customerErrors);

            if (customer == null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, customerErrors), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveData();
                MessageBox.Show("Kunde erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshList();
            return;
        }

        var employee = _employeeManager.AddEmployee(
            TxtFirstName.Text,
            TxtLastName.Text,
            birthDate,
            TxtPhoneNumberPrivate.Text,
            TxtEmail.Text,
            TxtPhoneNumberBuisness.Text,
            (Job)CmbDepartment.SelectedItem,
            Convert.ToInt32(CmbManagmentLevel.SelectedItem),
            TxtAhvNumber.Text,
            employment,
            entryDate,
            exitDate,
            TxtAdressPrivat.Text,
            privatePostalCode,
            TxtResidence.Text,
            TxtAdressBuisness.Text,
            businessPostalCode,
            TxtNationality.Text,
            ChkTrainee.Checked,
            out var errors);

        if (employee == null)
        {
            MessageBox.Show(string.Join(Environment.NewLine, errors), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            SaveData();
            MessageBox.Show("Mitarbeiter erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        RefreshList();
    }

    private void TxtOutput_Click(object sender, EventArgs e)
    {
        int lineIndex = TxtOutput.GetLineFromCharIndex(TxtOutput.SelectionStart);
        var allEmployees = _employeeManager.GetAllActive();
        var allCustomers = _customerManager.GetAllActive();

        if (lineIndex < 0 || lineIndex >= allEmployees.Count + allCustomers.Count)
        {
            return;
        }

        if (lineIndex < allEmployees.Count)
        {
            RadEmployee.Checked = true;

            var selectedEmployee = allEmployees[lineIndex];
            _selectedEmployee = selectedEmployee;
            _selectedCustomer = null;
            TxtFirstName.Text = selectedEmployee.FirstName;
            TxtLastName.Text = selectedEmployee.LastName;
            TxtPhoneNumberPrivate.Text = selectedEmployee.MobilePhone;
            TxtPhoneNumberBuisness.Text = selectedEmployee.BusinessPhone;
            TxtEmail.Text = selectedEmployee.Email;
            DtBirthday.Value = selectedEmployee.BirthDate.ToDateTime(TimeOnly.MinValue);
            TxtAhvNumber.Text = selectedEmployee.AhvNumber;
            TxtNationality.Text = selectedEmployee.Nationality;
            TxtEmployment.Text = selectedEmployee.Employment.ToString();
            DtEntryDate.Value = selectedEmployee.EntryDate.ToDateTime(TimeOnly.MinValue);
            if (selectedEmployee.ExitDate != null)
            {
                DtExitDate.Value = selectedEmployee.ExitDate.Value.ToDateTime(TimeOnly.MinValue);
            }
            CmbDepartment.SelectedItem = selectedEmployee.Job;
            CmbManagmentLevel.SelectedItem = selectedEmployee.ManagementLevel;
            ChkTrainee.Checked = selectedEmployee.Trainee;
            TxtAdressPrivat.Text = selectedEmployee.PrivateAddress;
            TxtPlzPrivat.Text = selectedEmployee.PrivatePostalCode.ToString();
            TxtResidence.Text = selectedEmployee.Residence;
            TxtAdressBuisness.Text = selectedEmployee.BusinessAddress;
            TxtPlzBuisness.Text = selectedEmployee.BusinessPostalCode.ToString();
            TxtEmployeeNumber.Text = selectedEmployee.EmployeeNumber.ToString();
            ChkActive.Checked = selectedEmployee.IsActive;

            if (ChkTrainee.Checked)
            {
                string TraineeYears = selectedEmployee.ApprenticeshipYear().ToString();
                TxtTraineeYear.Text = TraineeYears;
            }
        }
        else
        {
            RadCustomer.Checked = true;

            var selectedCustomer = allCustomers[lineIndex - allEmployees.Count];
            _selectedCustomer = selectedCustomer;
            _selectedEmployee = null;
            TxtFirstName.Text = selectedCustomer.FirstName;
            TxtLastName.Text = selectedCustomer.LastName;
            TxtPhoneNumberPrivate.Text = selectedCustomer.MobilePhone;
            TxtPhoneNumberBuisness.Text = selectedCustomer.BusinessPhone;
            TxtEmail.Text = selectedCustomer.Email;
            DtBirthday.Value = selectedCustomer.BirthDate.ToDateTime(TimeOnly.MinValue);
            CmbSalutation.SelectedItem = selectedCustomer.Salutation;
            CmbGender.SelectedItem = selectedCustomer.Gender;
            CmbTitle.SelectedItem = selectedCustomer.Title;
            ChkActive.Checked = selectedCustomer.IsActive;
        }

        int startIndex = TxtOutput.GetFirstCharIndexFromLine(lineIndex);
        string lineText = TxtOutput.Lines[lineIndex];
        TxtOutput.Select(startIndex, lineText.Length);
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
        if (_selectedEmployee != null)
        {
            _selectedEmployee.IsDeleted = true;
            _selectedEmployee = null;
            MessageBox.Show("Mitarbeiter wurde gelöscht.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else if (_selectedCustomer != null)
        {
            _selectedCustomer.IsDeleted = true;
            _selectedCustomer = null;
            MessageBox.Show("Kunde wurde gelöscht.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Bitte zuerst einen Eintrag aus der Liste auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        SaveData();
        RefreshList();
    }

    private void RadCustomer_CheckedChanged(object sender, EventArgs e)
    {
        foreach (Control field in EmployeeFields())
        {
            field.Visible = !RadCustomer.Checked;
        }
        foreach (Control field in CustomerFields())
        {
            field.Visible = RadCustomer.Checked;
        }
    }

    private void RadEmployee_CheckedChanged(object sender, EventArgs e)
    {
        foreach (Control field in EmployeeFields())
        {
            field.Visible = RadEmployee.Checked;
        }
        foreach (Control field in CustomerFields())
        {
            field.Visible = !RadEmployee.Checked;
        }
    }

    private void RefreshList() //neue Refreshlist Methode, um aktiv / inaktiv visuell anzuzeigen können
    {
        var allEmployees =
            _employeeManager.GetAllActive();

        var allCustomers =
            _customerManager.GetAllActive();

        TxtOutput.Clear();

        foreach (Employee employee in allEmployees)
        {
            string text =
                $"Mitarbeiter {employee.EmployeeNumber}: " +
                $"{employee.FirstName} {employee.LastName}";

            AppendContactLine(
                text,
                employee.IsActive);
        }

        foreach (Customer customer in allCustomers)
        {
            string text =
                $"Kunde: {customer.FirstName} {customer.LastName}";

            AppendContactLine(
                text,
                customer.IsActive);
        }

        TxtOutput.Select(0, 0);
    }

    //hilfsmethode um inaktive Kunden / Mitarbeiter grau anzuzeigen
    private void AppendContactLine(string text, bool isActive)
    {
        if (!isActive)
        {
            text += " (inaktiv)";
        }

        int startPosition = TxtOutput.TextLength;  //merkt sich, wo neue Zeile beginnt

        TxtOutput.AppendText(
            text + Environment.NewLine);

        TxtOutput.Select(
            startPosition,
            text.Length);

        if (isActive)
        {
            TxtOutput.SelectionColor = Color.Black;
        }
        else
        {
            TxtOutput.SelectionColor = Color.Gray;
        }
    }


    private void SaveData()  // Methode erstellt Speichert Daten auf C:\Users\Benutzername\AppData\Local\SemsterProjekt\contact-data.json
    {
        ContactData data = new ContactData
        {
            Employees = _employeeManager.GetAll(),
            Customers = _customerManager.GetAll()
        };

        _datastorage.Save(data); //Save Methode wandelt in JSON um und speichert auf Festplatte
    }

    private void LoadData()
    {
        try
        {
            ContactData data = _datastorage.Load();
            List<Employee> employees = data.Employees ?? new List<Employee>();
            List<Customer> customers = data.Customers ?? new List<Customer>();

            _employeeManager.ReplaceAll(employees);
            _customerManager.ReplaceAll(customers);

            int nextEmployeeNumber = 1;

            if (employees.Count > 0) //berechnet die nächste Mitarbeiternummer
            {
                int highestEmployeeNumber = employees.Max(employee => employee.EmployeeNumber);

                nextEmployeeNumber = highestEmployeeNumber + 1;
            }
            Employee.SetNextEmployeeNumber(nextEmployeeNumber);

            RefreshList();

        }
        catch (JsonException ex)
        {
            MessageBox.Show(
            "Die gespeicherte JSON-Datei ist beschädigt:\r\n" +
            ex.Message,
            "Ladefehler",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
        catch (IOException ex)
        {
            MessageBox.Show(
            "Die Datei konnte nicht gelesen werden:\r\n" +
            ex.Message,
            "Ladefehler",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }


    private Control[] EmployeeFields()
    {
        return new Control[]
        {
            TxtEmployeeNumber, LblEmployeeNumber,
            CmbDepartment, LblDepartment,
            TxtAhvNumber, LblAhvNumber,
            TxtAdressPrivat, LblAdressPrivat,
            TxtPlzPrivat, LblPlzPrivat,
            TxtNationality, LblNationality,
            DtEntryDate, LblEntry,
            DtExitDate, LblExit,
            TxtEmployment, LblEmployment,
            CmbManagmentLevel, LblManagementLevel,
            ChkTrainee, LblTrainee,
            TxtTraineeYear, LblTraineeYear,
            TxtAdressBuisness, LblAdressBuisness,
            TxtPlzBuisness, LblPlzBuisness,
            TxtResidence, LblResidence,
        };
    }

    private Control[] CustomerFields()
    {
        return new Control[]
        {
            CmbGender, LblGender,
            CmbSalutation, LblSalutation,
            CmbTitle, lblTitle
        };
    }

    private void CmdUpdate_Click(object sender, EventArgs e)
    {
        // Prüfen, ob ein Kunde ausgewählt wurde
        if (_selectedCustomer != null)
        {
            bool success = _customerManager.UpdateCustomer(
                _selectedCustomer,
                TxtFirstName.Text,
                TxtLastName.Text,
                DateOnly.FromDateTime(DtBirthday.Value),
                TxtPhoneNumberPrivate.Text,
                TxtEmail.Text,
                TxtPhoneNumberBuisness.Text,
                (Salutation)CmbSalutation.SelectedItem!,
                (Gender)CmbGender.SelectedItem!,
                (Title)CmbTitle.SelectedItem!,
                ChkActive.Checked,
                out List<string> errors);

            if (!success)
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, errors),
                    "Fehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            SaveData();
            RefreshList();

            MessageBox.Show(
                "Kunde wurde erfolgreich bearbeitet.",
                "Erfolg",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        // Prüfen, ob ein Mitarbeiter ausgewählt wurde
        if (_selectedEmployee != null)
        {
            int.TryParse(
                TxtEmployment.Text,
                out int employment);

            int.TryParse(
                TxtPlzPrivat.Text,
                out int privatePostalCode);

            int.TryParse(
                TxtPlzBuisness.Text,
                out int businessPostalCode);

            bool success = _employeeManager.UpdateEmployee(
                _selectedEmployee,
                TxtFirstName.Text,
                TxtLastName.Text,
                DateOnly.FromDateTime(DtBirthday.Value),
                TxtPhoneNumberPrivate.Text,
                TxtEmail.Text,
                TxtPhoneNumberBuisness.Text,
                (Job)CmbDepartment.SelectedItem!,
                Convert.ToInt32(CmbManagmentLevel.SelectedItem),
                TxtAhvNumber.Text,
                employment,
                DateOnly.FromDateTime(DtEntryDate.Value),
                DateOnly.FromDateTime(DtExitDate.Value),
                TxtAdressPrivat.Text,
                privatePostalCode,
                TxtResidence.Text,
                TxtAdressBuisness.Text,
                businessPostalCode,
                TxtNationality.Text,
                ChkTrainee.Checked,
                ChkActive.Checked,
                out List<string> errors);

            if (!success)
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, errors),
                    "Fehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            SaveData();
            RefreshList();

            MessageBox.Show(
                "Mitarbeiter wurde erfolgreich bearbeitet.",
                "Erfolg",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        // Weder Kunde noch Mitarbeiter wurde ausgewählt
        MessageBox.Show(
            "Bitte zuerst einen Eintrag aus der Liste auswählen.",
            "Fehler",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
