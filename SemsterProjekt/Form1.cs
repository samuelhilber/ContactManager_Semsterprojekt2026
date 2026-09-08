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
        // tabs vom Tabcontroll ausblenden, da radiobuttons bereits anzeigen ob MA oder Kunde ausgewählt ist.
        TabContactList.Appearance = TabAppearance.FlatButtons;
        TabContactList.ItemSize = new Size(0, 1);
        TabContactList.SizeMode = TabSizeMode.Fixed;
        TabContactList.TabStop = false;
        ConfigureOutput(TxtEmployeeOutput);
        ConfigureOutput(TxtCustomerOutput);
        TxtEmployeeOutput.Click += TxtOutput_Click;
        TxtCustomerOutput.Click += TxtOutput_Click;

        TabContactList.SelectedIndexChanged += TabContactList_SelectedIndexChanged;

        TxtSearch.TextChanged += TxtSearch_TextChanged;

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

    private void TabContactList_SelectedIndexChanged(
    object? sender,
    EventArgs e)
    {
        if (TabContactList.SelectedTab == TabEmployees)
        {
            RadEmployee.Checked = true;
        }
        else if (TabContactList.SelectedTab == TabCustomers)
        {
            RadCustomer.Checked = true;
        }
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

            TxtFirstName.BackColor = customerErrors.ContainsKey("FirstName") ? Color.MistyRose : SystemColors.Window;
            TxtLastName.BackColor = customerErrors.ContainsKey("LastName") ? Color.MistyRose : SystemColors.Window;
            TxtPhoneNumberPrivate.BackColor = customerErrors.ContainsKey("MobilePhone") ? Color.MistyRose : SystemColors.Window;
            TxtEmail.BackColor = customerErrors.ContainsKey("Email") ? Color.MistyRose : SystemColors.Window;
            TxtPhoneNumberBuisness.BackColor = customerErrors.ContainsKey("BusinessPhone") ? Color.MistyRose : SystemColors.Window;

            if (customer == null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, customerErrors.Values), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        TxtFirstName.BackColor = errors.ContainsKey("FirstName") ? Color.MistyRose : SystemColors.Window;
        TxtLastName.BackColor = errors.ContainsKey("LastName") ? Color.MistyRose : SystemColors.Window;
        TxtPhoneNumberPrivate.BackColor = errors.ContainsKey("MobilePhone") ? Color.MistyRose : SystemColors.Window;
        TxtEmail.BackColor = errors.ContainsKey("Email") ? Color.MistyRose : SystemColors.Window;
        TxtPhoneNumberBuisness.BackColor = errors.ContainsKey("BusinessPhone") ? Color.MistyRose : SystemColors.Window;
        TxtAhvNumber.BackColor = errors.ContainsKey("AhvNumber") ? Color.MistyRose : SystemColors.Window;
        TxtEmployment.BackColor = errors.ContainsKey("Employment") ? Color.MistyRose : SystemColors.Window;
        TxtAdressPrivat.BackColor = errors.ContainsKey("PrivateAddress") ? Color.MistyRose : SystemColors.Window;
        TxtPlzPrivat.BackColor = errors.ContainsKey("PrivatePostalCode") ? Color.MistyRose : SystemColors.Window;
        TxtResidence.BackColor = errors.ContainsKey("Residence") ? Color.MistyRose : SystemColors.Window;
        TxtAdressBuisness.BackColor = errors.ContainsKey("BusinessAddress") ? Color.MistyRose : SystemColors.Window;
        TxtPlzBuisness.BackColor = errors.ContainsKey("BusinessPostalCode") ? Color.MistyRose : SystemColors.Window;
        TxtNationality.BackColor = errors.ContainsKey("Nationality") ? Color.MistyRose : SystemColors.Window;

        if (employee == null)
        {
            MessageBox.Show(string.Join(Environment.NewLine, errors.Values), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            SaveData();
            MessageBox.Show("Mitarbeiter erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        RefreshList();
    }

    private void ConfigureOutput(RichTextBox output)
    {
        output.ReadOnly = true;
        output.WordWrap = false;
        output.ScrollBars = RichTextBoxScrollBars.Both;
        output.Font = new Font("Consolas", 10);
    }

    private void TxtOutput_Click(object? sender,EventArgs e)
    {
        if (sender is not RichTextBox output)
        {
            return;
        }

        int lineIndex = output.GetLineFromCharIndex(output.SelectionStart);

        if (output == TxtEmployeeOutput)
        {
            var employees = _employeeManager.Search(TxtSearch.Text);

            if (lineIndex < 0 ||
                lineIndex >= employees.Count)
            {
                return;
            }

            Employee employee = employees[lineIndex];

            RadEmployee.Checked = true;
            _selectedEmployee = employee;
            _selectedCustomer = null;

            TxtFirstName.Text = employee.FirstName;
            TxtLastName.Text = employee.LastName;
            TxtPhoneNumberPrivate.Text = employee.MobilePhone;
            TxtPhoneNumberBuisness.Text = employee.BusinessPhone;
            TxtEmail.Text = employee.Email;

            DtBirthday.Value =
                employee.BirthDate.ToDateTime(
                    TimeOnly.MinValue);

            TxtAhvNumber.Text = employee.AhvNumber;
            TxtNationality.Text = employee.Nationality;
            TxtEmployment.Text = employee.Employment.ToString();

            DtEntryDate.Value =
                employee.EntryDate.ToDateTime(
                    TimeOnly.MinValue);

            if (employee.ExitDate != null)
            {
                DtExitDate.Value =
                    employee.ExitDate.Value.ToDateTime(
                        TimeOnly.MinValue);
            }

            CmbDepartment.SelectedItem = employee.Job;
            CmbManagmentLevel.SelectedItem =
                employee.ManagementLevel;

            ChkTrainee.Checked = employee.Trainee;
            TxtAdressPrivat.Text = employee.PrivateAddress;
            TxtPlzPrivat.Text =
                employee.PrivatePostalCode.ToString();

            TxtResidence.Text = employee.Residence;
            TxtAdressBuisness.Text = employee.BusinessAddress;
            TxtPlzBuisness.Text =
                employee.BusinessPostalCode.ToString();

            TxtEmployeeNumber.Text =
                employee.EmployeeNumber.ToString();

            ChkActive.Checked = employee.IsActive;

            if (employee.Trainee &&
                employee.ExitDate != null)
            {
                TxtTraineeYear.Text =
                    employee.ApprenticeshipYear().ToString();
            }
            else
            {
                TxtTraineeYear.Text = string.Empty;
            }
        }
        else if (output == TxtCustomerOutput)
        {
            var customers = _customerManager.Search(TxtSearch.Text);

            if (lineIndex < 0 ||
                lineIndex >= customers.Count)
            {
                return;
            }

            Customer customer = customers[lineIndex];

            RadCustomer.Checked = true;
            _selectedCustomer = customer;
            _selectedEmployee = null;

            TxtFirstName.Text = customer.FirstName;
            TxtLastName.Text = customer.LastName;
            TxtPhoneNumberPrivate.Text = customer.MobilePhone;
            TxtPhoneNumberBuisness.Text = customer.BusinessPhone;
            TxtEmail.Text = customer.Email;

            DtBirthday.Value =
                customer.BirthDate.ToDateTime(
                    TimeOnly.MinValue);

            CmbSalutation.SelectedItem =
                customer.Salutation;

            CmbGender.SelectedItem =
                customer.Gender;

            CmbTitle.SelectedItem =
                customer.Title;

            ChkActive.Checked = customer.IsActive;
        }
        else
        {
            return;
        }

        int startIndex =
            output.GetFirstCharIndexFromLine(lineIndex);

        string lineText = output.Lines[lineIndex];

        output.Select(
            startIndex,
            lineText.Length);
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

        if (RadCustomer.Checked)
        {
            TabContactList.SelectedTab = TabCustomers;
            // MA darf nach dem Wechsel nicht aus versehen bearbeitet werden
            _selectedEmployee = null;
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

        if (RadEmployee.Checked)
        {
            TabContactList.SelectedTab = TabEmployees;
            // Kunde darf nach dem Wechsel nicht aus versehen bearbeitet werden
            _selectedCustomer = null;
        }
    }

   
    private void RefreshList() //neue Refreshlist Methode, um aktiv / inaktiv visuell anzuzeigen können und Tab wechsel ermöglichen
    {
        var allEmployees = _employeeManager.Search(TxtSearch.Text);

        var allCustomers = _customerManager.Search(TxtSearch.Text);

        TxtEmployeeOutput.Clear();
        TxtCustomerOutput.Clear();

        foreach (Employee employee in allEmployees)
        {
            string text =
                $"Mitarbeiter {employee.EmployeeNumber}: " +
                $"{employee.FirstName} {employee.LastName}";

            AppendContactLine(
                TxtEmployeeOutput,
                text,
                employee.IsActive);
        }

        foreach (Customer customer in allCustomers)
        {
            string text =
                $"Kunde: {customer.FirstName} " +
                $"{customer.LastName}";

            AppendContactLine(
                TxtCustomerOutput,
                text,
                customer.IsActive);
        }

        TxtEmployeeOutput.Select(0, 0);
        TxtCustomerOutput.Select(0, 0);
    }

    //hilfsmethode um inaktive Kunden / Mitarbeiter grau anzuzeigen
    private void AppendContactLine(
    RichTextBox output,
    string text,
    bool isActive)
    {
        if (!isActive)
        {
            text += " (inaktiv)";
        }

        int startPosition = output.TextLength;

        output.AppendText(
            text + Environment.NewLine);

        output.Select(
            startPosition,
            text.Length);

        output.SelectionColor =
            isActive ? Color.Black : Color.Gray;
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
                out Dictionary<string, string> errors);

            TxtFirstName.BackColor = errors.ContainsKey("FirstName") ? Color.MistyRose : SystemColors.Window;
            TxtLastName.BackColor = errors.ContainsKey("LastName") ? Color.MistyRose : SystemColors.Window;
            TxtPhoneNumberPrivate.BackColor = errors.ContainsKey("MobilePhone") ? Color.MistyRose : SystemColors.Window;
            TxtEmail.BackColor = errors.ContainsKey("Email") ? Color.MistyRose : SystemColors.Window;
            TxtPhoneNumberBuisness.BackColor = errors.ContainsKey("BusinessPhone") ? Color.MistyRose : SystemColors.Window;

            if (!success)
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, errors.Values),
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
                out Dictionary<string, string> errors);

            TxtFirstName.BackColor = errors.ContainsKey("FirstName") ? Color.MistyRose : SystemColors.Window;
            TxtLastName.BackColor = errors.ContainsKey("LastName") ? Color.MistyRose : SystemColors.Window;
            TxtPhoneNumberPrivate.BackColor = errors.ContainsKey("MobilePhone") ? Color.MistyRose : SystemColors.Window;
            TxtEmail.BackColor = errors.ContainsKey("Email") ? Color.MistyRose : SystemColors.Window;
            TxtPhoneNumberBuisness.BackColor = errors.ContainsKey("BusinessPhone") ? Color.MistyRose : SystemColors.Window;
            TxtAhvNumber.BackColor = errors.ContainsKey("AhvNumber") ? Color.MistyRose : SystemColors.Window;
            TxtEmployment.BackColor = errors.ContainsKey("Employment") ? Color.MistyRose : SystemColors.Window;
            TxtAdressPrivat.BackColor = errors.ContainsKey("PrivateAddress") ? Color.MistyRose : SystemColors.Window;
            TxtPlzPrivat.BackColor = errors.ContainsKey("PrivatePostalCode") ? Color.MistyRose : SystemColors.Window;
            TxtResidence.BackColor = errors.ContainsKey("Residence") ? Color.MistyRose : SystemColors.Window;
            TxtAdressBuisness.BackColor = errors.ContainsKey("BusinessAddress") ? Color.MistyRose : SystemColors.Window;
            TxtPlzBuisness.BackColor = errors.ContainsKey("BusinessPostalCode") ? Color.MistyRose : SystemColors.Window;
            TxtNationality.BackColor = errors.ContainsKey("Nationality") ? Color.MistyRose : SystemColors.Window;

            if (!success)
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, errors.Values),
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

    private void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        _selectedEmployee = null;
        _selectedCustomer = null;
        RefreshList();
    }

    
}
