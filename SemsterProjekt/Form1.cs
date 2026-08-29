namespace SemsterProjekt
{
    public partial class Form1 : Form
    {
        private EmployeeManager _employeeManager = new EmployeeManager();
        private readonly List<Customer> _customers = new List<Customer>();

        public Form1()
        {
            InitializeComponent();

            TxtOutput.Click += TxtOutput_Click;
            TxtOutput.ReadOnly = true;
            TxtOutput.WordWrap = false;
            TxtOutput.ScrollBars = ScrollBars.Both;
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
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            if (RadCustomer.Checked)
            {
                var customer = CreateCustomer(out var customerErrors);
                if (customer == null)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, customerErrors), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _customers.Add(customer);
                    MessageBox.Show("Kunde erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                RefreshList();
                return;
            }

            DateOnly birthDate = DateOnly.FromDateTime(DtBirthday.Value); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
            DateOnly entryDate = DateOnly.FromDateTime(DtEntryDate.Value); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
            DateOnly exitDate = DateOnly.FromDateTime(DtExitDate.Value); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
            int.TryParse(TxtPlzPrivat.Text, out int privatePostalCode); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
            int.TryParse(TxtEmployment.Text, out int employment); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können
            int.TryParse(TxtPlzBuisness.Text, out int businessPostalCode); // formatiert die Daten aus den Feldern, damit sie korrekt an die Methode AddEmployee übergeben werden können

            var employee = _employeeManager.AddEmployee(
                TxtFirstName.Text,
                TxtLastName.Text,
                birthDate,
                TxtPhoneNumberPrivate.Text,
                TxtEmail.Text,
                TxtPhoneNumberBuisness.Text,
                (Job)CmbDepartment.SelectedItem,
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
                out var errors);

            if (employee == null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Mitarbeiter erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshList();
        }

        private Customer? CreateCustomer(out List<string> errors)
        {
            var customer = new Customer();
            errors = new List<string>();

            try { customer.FirstName = TxtFirstName.Text; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { customer.LastName = TxtLastName.Text; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { customer.BirthDate = DateOnly.FromDateTime(DtBirthday.Value); } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { customer.MobilePhone = TxtPhoneNumberPrivate.Text; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { customer.BusinessPhone = TxtPhoneNumberBuisness.Text; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { customer.Email = TxtEmail.Text; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            customer.IsActive = ChkActive.Checked;
            customer.Salutation = (Salutation)CmbSalutation.SelectedItem!;
            customer.Gender = (Gender)CmbGender.SelectedItem!;
            customer.Title = (Title)CmbTitle.SelectedItem!;

            if (errors.Count > 0)
            {
                return null;
            }

            return customer;
        }

        private void TxtOutput_Click(object sender, EventArgs e)
        {
            int lineIndex = TxtOutput.GetLineFromCharIndex(TxtOutput.SelectionStart);
            var allEmployees = _employeeManager.GetAll();

            if (lineIndex < 0 || lineIndex >= allEmployees.Count)
            {
                return;
            }

            var selectedEmployee = allEmployees[lineIndex];
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

            if (ChkTrainee.Checked)
            {
                string TraineeYears = selectedEmployee.ApprenticeshipYear().ToString();
                TxtTraineeYear.Text = TraineeYears;
            }


            int startIndex = TxtOutput.GetFirstCharIndexFromLine(lineIndex);
            string lineText = TxtOutput.Lines[lineIndex];
            TxtOutput.Select(startIndex, lineText.Length);
        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {

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

        private void RefreshList()
        {
            var allEmployees = _employeeManager.GetAll();
            var lines = allEmployees.Select(m => $"Mitarbeiter: {m.FirstName} {m.LastName}")
                .Concat(_customers.Select(c => $"Kunde: {c.FirstName} {c.LastName}"));
            TxtOutput.Text = string.Join("\r\n", lines);
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
    }
}
