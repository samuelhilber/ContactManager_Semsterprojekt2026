namespace SemsterProjekt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TxtFirstName = new TextBox();
            TxtLastName = new TextBox();
            DtBirthday = new DateTimePicker();
            TxtPhoneNumberPrivate = new TextBox();
            TxtEmail = new TextBox();
            ChkActive = new CheckBox();
            CmbSalutation = new ComboBox();
            CmbGender = new ComboBox();
            CmbTitle = new ComboBox();
            TxtEmployeeNumber = new TextBox();
            CmbDepartment = new ComboBox();
            TxtAhvNumber = new TextBox();
            TxtAdressPrivat = new TextBox();
            TxtPlzPrivat = new TextBox();
            TxtNationality = new TextBox();
            DtEntryDate = new DateTimePicker();
            DtExitDate = new DateTimePicker();
            TxtEmployment = new TextBox();
            CmbManagmentLevel = new ComboBox();
            ChkTrainee = new CheckBox();
            TxtTraineeYear = new TextBox();
            RadCustomer = new RadioButton();
            RadEmployee = new RadioButton();
            CmdSave = new Button();
            LblFirstName = new Label();
            LblLastName = new Label();
            LblBirthday = new Label();
            LblPhoneNumberPrivate = new Label();
            LblEmail = new Label();
            LblGender = new Label();
            LblSalutation = new Label();
            lblTitle = new Label();
            LblEmployeeNumber = new Label();
            LblDepartment = new Label();
            LblAhvNumber = new Label();
            LblAdressPrivat = new Label();
            LblPlzPrivat = new Label();
            LblNationality = new Label();
            LblEntry = new Label();
            LblExit = new Label();
            LblEmployment = new Label();
            LblManagementLevel = new Label();
            LblTrainee = new Label();
            LblTraineeYear = new Label();
            CmdDelete = new Button();
            TxtPhoneNumberBuisness = new TextBox();
            LblPhoneNumberBuisness = new Label();
            LblAdressBuisness = new Label();
            TxtAdressBuisness = new TextBox();
            TxtPlzBuisness = new TextBox();
            LblPlzBuisness = new Label();
            LblResidence = new Label();
            TxtResidence = new TextBox();
            CmdUpdate = new Button();
            TabContactList = new TabControl();
            TabEmployees = new TabPage();
            TxtEmployeeOutput = new RichTextBox();
            TabCustomers = new TabPage();
            TxtCustomerOutput = new RichTextBox();
            TxtSearch = new TextBox();
            TabContactList.SuspendLayout();
            TabEmployees.SuspendLayout();
            TabCustomers.SuspendLayout();
            SuspendLayout();
            // 
            // TxtFirstName
            // 
            TxtFirstName.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtFirstName.Location = new Point(512, 79);
            TxtFirstName.Name = "TxtFirstName";
            TxtFirstName.Size = new Size(180, 23);
            TxtFirstName.TabIndex = 0;
            // 
            // TxtLastName
            // 
            TxtLastName.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtLastName.Location = new Point(698, 79);
            TxtLastName.Name = "TxtLastName";
            TxtLastName.Size = new Size(180, 23);
            TxtLastName.TabIndex = 1;
            // 
            // DtBirthday
            // 
            DtBirthday.Font = new Font("Arial Rounded MT Bold", 9.75F);
            DtBirthday.Location = new Point(887, 79);
            DtBirthday.Name = "DtBirthday";
            DtBirthday.Size = new Size(200, 23);
            DtBirthday.TabIndex = 2;
            // 
            // TxtPhoneNumberPrivate
            // 
            TxtPhoneNumberPrivate.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtPhoneNumberPrivate.Location = new Point(512, 139);
            TxtPhoneNumberPrivate.Name = "TxtPhoneNumberPrivate";
            TxtPhoneNumberPrivate.Size = new Size(180, 23);
            TxtPhoneNumberPrivate.TabIndex = 3;
            // 
            // TxtEmail
            // 
            TxtEmail.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtEmail.Location = new Point(887, 139);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(200, 23);
            TxtEmail.TabIndex = 5;
            // 
            // ChkActive
            // 
            ChkActive.AutoSize = true;
            ChkActive.BackColor = Color.FloralWhite;
            ChkActive.Font = new Font("Arial Rounded MT Bold", 9.75F);
            ChkActive.Location = new Point(748, 13);
            ChkActive.Name = "ChkActive";
            ChkActive.Size = new Size(58, 19);
            ChkActive.TabIndex = 5;
            ChkActive.TabStop = false;
            ChkActive.Text = "Aktiv";
            ChkActive.UseVisualStyleBackColor = false;
            // 
            // CmbSalutation
            // 
            CmbSalutation.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmbSalutation.FormattingEnabled = true;
            CmbSalutation.Location = new Point(512, 199);
            CmbSalutation.Name = "CmbSalutation";
            CmbSalutation.Size = new Size(180, 23);
            CmbSalutation.TabIndex = 7;
            // 
            // CmbGender
            // 
            CmbGender.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmbGender.FormattingEnabled = true;
            CmbGender.Location = new Point(698, 199);
            CmbGender.Name = "CmbGender";
            CmbGender.Size = new Size(180, 23);
            CmbGender.TabIndex = 8;
            // 
            // CmbTitle
            // 
            CmbTitle.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmbTitle.FormattingEnabled = true;
            CmbTitle.Location = new Point(887, 199);
            CmbTitle.Name = "CmbTitle";
            CmbTitle.Size = new Size(200, 23);
            CmbTitle.TabIndex = 9;
            // 
            // TxtEmployeeNumber
            // 
            TxtEmployeeNumber.BackColor = Color.FloralWhite;
            TxtEmployeeNumber.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtEmployeeNumber.Location = new Point(512, 199);
            TxtEmployeeNumber.Name = "TxtEmployeeNumber";
            TxtEmployeeNumber.ReadOnly = true;
            TxtEmployeeNumber.Size = new Size(180, 23);
            TxtEmployeeNumber.TabIndex = 10;
            TxtEmployeeNumber.TabStop = false;
            // 
            // CmbDepartment
            // 
            CmbDepartment.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmbDepartment.FormattingEnabled = true;
            CmbDepartment.Location = new Point(698, 199);
            CmbDepartment.Name = "CmbDepartment";
            CmbDepartment.Size = new Size(180, 23);
            CmbDepartment.TabIndex = 6;
            // 
            // TxtAhvNumber
            // 
            TxtAhvNumber.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtAhvNumber.Location = new Point(887, 199);
            TxtAhvNumber.Name = "TxtAhvNumber";
            TxtAhvNumber.Size = new Size(200, 23);
            TxtAhvNumber.TabIndex = 7;
            // 
            // TxtAdressPrivat
            // 
            TxtAdressPrivat.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtAdressPrivat.Location = new Point(512, 259);
            TxtAdressPrivat.Name = "TxtAdressPrivat";
            TxtAdressPrivat.Size = new Size(180, 23);
            TxtAdressPrivat.TabIndex = 8;
            // 
            // TxtPlzPrivat
            // 
            TxtPlzPrivat.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtPlzPrivat.Location = new Point(698, 259);
            TxtPlzPrivat.Name = "TxtPlzPrivat";
            TxtPlzPrivat.Size = new Size(100, 23);
            TxtPlzPrivat.TabIndex = 9;
            // 
            // TxtNationality
            // 
            TxtNationality.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtNationality.Location = new Point(512, 379);
            TxtNationality.Name = "TxtNationality";
            TxtNationality.Size = new Size(180, 23);
            TxtNationality.TabIndex = 13;
            // 
            // DtEntryDate
            // 
            DtEntryDate.Font = new Font("Arial Rounded MT Bold", 9.75F);
            DtEntryDate.Location = new Point(512, 439);
            DtEntryDate.Name = "DtEntryDate";
            DtEntryDate.Size = new Size(200, 23);
            DtEntryDate.TabIndex = 14;
            // 
            // DtExitDate
            // 
            DtExitDate.Font = new Font("Arial Rounded MT Bold", 9.75F);
            DtExitDate.Location = new Point(723, 439);
            DtExitDate.Name = "DtExitDate";
            DtExitDate.Size = new Size(200, 23);
            DtExitDate.TabIndex = 15;
            // 
            // TxtEmployment
            // 
            TxtEmployment.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtEmployment.Location = new Point(512, 499);
            TxtEmployment.Name = "TxtEmployment";
            TxtEmployment.Size = new Size(109, 23);
            TxtEmployment.TabIndex = 16;
            // 
            // CmbManagmentLevel
            // 
            CmbManagmentLevel.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmbManagmentLevel.FormattingEnabled = true;
            CmbManagmentLevel.Location = new Point(634, 499);
            CmbManagmentLevel.Name = "CmbManagmentLevel";
            CmbManagmentLevel.Size = new Size(79, 23);
            CmbManagmentLevel.TabIndex = 17;
            // 
            // ChkTrainee
            // 
            ChkTrainee.AutoSize = true;
            ChkTrainee.BackColor = Color.FloralWhite;
            ChkTrainee.Font = new Font("Arial Rounded MT Bold", 9.75F);
            ChkTrainee.Location = new Point(810, 499);
            ChkTrainee.Name = "ChkTrainee";
            ChkTrainee.Size = new Size(127, 19);
            ChkTrainee.TabIndex = 18;
            ChkTrainee.Text = "Auszubildender";
            ChkTrainee.UseVisualStyleBackColor = false;
            // 
            // TxtTraineeYear
            // 
            TxtTraineeYear.BackColor = Color.FloralWhite;
            TxtTraineeYear.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtTraineeYear.Location = new Point(731, 499);
            TxtTraineeYear.Name = "TxtTraineeYear";
            TxtTraineeYear.ReadOnly = true;
            TxtTraineeYear.Size = new Size(63, 23);
            TxtTraineeYear.TabIndex = 22;
            TxtTraineeYear.TabStop = false;
            // 
            // RadCustomer
            // 
            RadCustomer.AutoSize = true;
            RadCustomer.BackColor = Color.FloralWhite;
            RadCustomer.Font = new Font("Arial Rounded MT Bold", 9.75F);
            RadCustomer.Location = new Point(10, 10);
            RadCustomer.Name = "RadCustomer";
            RadCustomer.Size = new Size(67, 19);
            RadCustomer.TabIndex = 23;
            RadCustomer.Text = "Kunde";
            RadCustomer.UseVisualStyleBackColor = false;
            RadCustomer.CheckedChanged += RadCustomer_CheckedChanged;
            // 
            // RadEmployee
            // 
            RadEmployee.AutoSize = true;
            RadEmployee.BackColor = Color.FloralWhite;
            RadEmployee.Font = new Font("Arial Rounded MT Bold", 9.75F);
            RadEmployee.Location = new Point(92, 10);
            RadEmployee.Name = "RadEmployee";
            RadEmployee.Size = new Size(98, 19);
            RadEmployee.TabIndex = 24;
            RadEmployee.Text = "Mitarbeiter";
            RadEmployee.UseVisualStyleBackColor = false;
            RadEmployee.CheckedChanged += RadEmployee_CheckedChanged;
            // 
            // CmdSave
            // 
            CmdSave.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmdSave.Location = new Point(672, 10);
            CmdSave.Name = "CmdSave";
            CmdSave.Size = new Size(70, 23);
            CmdSave.TabIndex = 26;
            CmdSave.TabStop = false;
            CmdSave.Text = "Erstellen";
            CmdSave.UseVisualStyleBackColor = true;
            CmdSave.Click += CmdSave_Click;
            // 
            // LblFirstName
            // 
            LblFirstName.AutoSize = true;
            LblFirstName.BackColor = Color.FloralWhite;
            LblFirstName.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblFirstName.Location = new Point(512, 59);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(66, 15);
            LblFirstName.TabIndex = 100;
            LblFirstName.Text = "Vorname";
            // 
            // LblLastName
            // 
            LblLastName.AutoSize = true;
            LblLastName.BackColor = Color.FloralWhite;
            LblLastName.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblLastName.Location = new Point(697, 59);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(77, 15);
            LblLastName.TabIndex = 100;
            LblLastName.Text = "Nachname";
            // 
            // LblBirthday
            // 
            LblBirthday.AutoSize = true;
            LblBirthday.BackColor = Color.FloralWhite;
            LblBirthday.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblBirthday.Location = new Point(887, 59);
            LblBirthday.Name = "LblBirthday";
            LblBirthday.Size = new Size(100, 15);
            LblBirthday.TabIndex = 100;
            LblBirthday.Text = "Geburtsdatum";
            // 
            // LblPhoneNumberPrivate
            // 
            LblPhoneNumberPrivate.AutoSize = true;
            LblPhoneNumberPrivate.BackColor = Color.FloralWhite;
            LblPhoneNumberPrivate.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblPhoneNumberPrivate.Location = new Point(510, 119);
            LblPhoneNumberPrivate.Name = "LblPhoneNumberPrivate";
            LblPhoneNumberPrivate.Size = new Size(151, 15);
            LblPhoneNumberPrivate.TabIndex = 100;
            LblPhoneNumberPrivate.Text = "Telefonnummer Privat";
            // 
            // LblEmail
            // 
            LblEmail.AutoSize = true;
            LblEmail.BackColor = Color.FloralWhite;
            LblEmail.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblEmail.Location = new Point(887, 119);
            LblEmail.Name = "LblEmail";
            LblEmail.Size = new Size(44, 15);
            LblEmail.TabIndex = 100;
            LblEmail.Text = "Email";
            // 
            // LblGender
            // 
            LblGender.AutoSize = true;
            LblGender.BackColor = Color.FloralWhite;
            LblGender.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblGender.Location = new Point(698, 179);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(81, 15);
            LblGender.TabIndex = 33;
            LblGender.Text = "Geschlecht";
            // 
            // LblSalutation
            // 
            LblSalutation.AutoSize = true;
            LblSalutation.BackColor = Color.FloralWhite;
            LblSalutation.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblSalutation.Location = new Point(512, 179);
            LblSalutation.Name = "LblSalutation";
            LblSalutation.Size = new Size(54, 15);
            LblSalutation.TabIndex = 34;
            LblSalutation.Text = "Anrede";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FloralWhite;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 9.75F);
            lblTitle.Location = new Point(884, 179);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(45, 15);
            lblTitle.TabIndex = 35;
            lblTitle.Text = "Titel *";
            // 
            // LblEmployeeNumber
            // 
            LblEmployeeNumber.AutoSize = true;
            LblEmployeeNumber.BackColor = Color.FloralWhite;
            LblEmployeeNumber.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblEmployeeNumber.Location = new Point(512, 179);
            LblEmployeeNumber.Name = "LblEmployeeNumber";
            LblEmployeeNumber.Size = new Size(134, 15);
            LblEmployeeNumber.TabIndex = 36;
            LblEmployeeNumber.Text = "Mitarbeiternummer";
            // 
            // LblDepartment
            // 
            LblDepartment.AutoSize = true;
            LblDepartment.BackColor = Color.FloralWhite;
            LblDepartment.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblDepartment.Location = new Point(698, 179);
            LblDepartment.Name = "LblDepartment";
            LblDepartment.Size = new Size(69, 15);
            LblDepartment.TabIndex = 37;
            LblDepartment.Text = "Abteilung";
            // 
            // LblAhvNumber
            // 
            LblAhvNumber.AutoSize = true;
            LblAhvNumber.BackColor = Color.FloralWhite;
            LblAhvNumber.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblAhvNumber.Location = new Point(887, 179);
            LblAhvNumber.Name = "LblAhvNumber";
            LblAhvNumber.Size = new Size(94, 15);
            LblAhvNumber.TabIndex = 38;
            LblAhvNumber.Text = "AHV Nummer";
            // 
            // LblAdressPrivat
            // 
            LblAdressPrivat.AutoSize = true;
            LblAdressPrivat.BackColor = Color.FloralWhite;
            LblAdressPrivat.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblAdressPrivat.Location = new Point(512, 239);
            LblAdressPrivat.Name = "LblAdressPrivat";
            LblAdressPrivat.Size = new Size(98, 15);
            LblAdressPrivat.TabIndex = 39;
            LblAdressPrivat.Text = "Privatadresse";
            // 
            // LblPlzPrivat
            // 
            LblPlzPrivat.AutoSize = true;
            LblPlzPrivat.BackColor = Color.FloralWhite;
            LblPlzPrivat.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblPlzPrivat.Location = new Point(698, 239);
            LblPlzPrivat.Name = "LblPlzPrivat";
            LblPlzPrivat.Size = new Size(84, 15);
            LblPlzPrivat.TabIndex = 40;
            LblPlzPrivat.Text = "Postleitzahl";
            // 
            // LblNationality
            // 
            LblNationality.AutoSize = true;
            LblNationality.BackColor = Color.FloralWhite;
            LblNationality.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblNationality.Location = new Point(512, 359);
            LblNationality.Name = "LblNationality";
            LblNationality.Size = new Size(84, 15);
            LblNationality.TabIndex = 41;
            LblNationality.Text = "Nationalität";
            // 
            // LblEntry
            // 
            LblEntry.AutoSize = true;
            LblEntry.BackColor = Color.FloralWhite;
            LblEntry.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblEntry.Location = new Point(512, 419);
            LblEntry.Name = "LblEntry";
            LblEntry.Size = new Size(53, 15);
            LblEntry.TabIndex = 42;
            LblEntry.Text = "Eintritt";
            // 
            // LblExit
            // 
            LblExit.AutoSize = true;
            LblExit.BackColor = Color.FloralWhite;
            LblExit.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblExit.Location = new Point(723, 419);
            LblExit.Name = "LblExit";
            LblExit.Size = new Size(65, 15);
            LblExit.TabIndex = 43;
            LblExit.Text = "Austritt *";
            // 
            // LblEmployment
            // 
            LblEmployment.AutoSize = true;
            LblEmployment.BackColor = Color.FloralWhite;
            LblEmployment.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblEmployment.Location = new Point(512, 479);
            LblEmployment.Name = "LblEmployment";
            LblEmployment.Size = new Size(113, 15);
            LblEmployment.TabIndex = 44;
            LblEmployment.Text = "Anstellungsgrad";
            // 
            // LblManagementLevel
            // 
            LblManagementLevel.AutoSize = true;
            LblManagementLevel.BackColor = Color.FloralWhite;
            LblManagementLevel.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblManagementLevel.Location = new Point(634, 479);
            LblManagementLevel.Name = "LblManagementLevel";
            LblManagementLevel.Size = new Size(79, 15);
            LblManagementLevel.TabIndex = 46;
            LblManagementLevel.Text = "Kaderstufe";
            // 
            // LblTrainee
            // 
            LblTrainee.AutoSize = true;
            LblTrainee.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblTrainee.Location = new Point(510, 551);
            LblTrainee.Name = "LblTrainee";
            LblTrainee.Size = new Size(0, 15);
            LblTrainee.TabIndex = 47;
            // 
            // LblTraineeYear
            // 
            LblTraineeYear.AutoSize = true;
            LblTraineeYear.BackColor = Color.FloralWhite;
            LblTraineeYear.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblTraineeYear.Location = new Point(731, 479);
            LblTraineeYear.Name = "LblTraineeYear";
            LblTraineeYear.Size = new Size(63, 15);
            LblTraineeYear.TabIndex = 48;
            LblTraineeYear.Text = "Lehrjahr";
            // 
            // CmdDelete
            // 
            CmdDelete.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmdDelete.Location = new Point(512, 10);
            CmdDelete.Name = "CmdDelete";
            CmdDelete.Size = new Size(70, 23);
            CmdDelete.TabIndex = 49;
            CmdDelete.TabStop = false;
            CmdDelete.Text = "Löschen";
            CmdDelete.UseVisualStyleBackColor = true;
            CmdDelete.Click += CmdDelete_Click;
            // 
            // TxtPhoneNumberBuisness
            // 
            TxtPhoneNumberBuisness.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtPhoneNumberBuisness.Location = new Point(698, 139);
            TxtPhoneNumberBuisness.Name = "TxtPhoneNumberBuisness";
            TxtPhoneNumberBuisness.Size = new Size(180, 23);
            TxtPhoneNumberBuisness.TabIndex = 4;
            // 
            // LblPhoneNumberBuisness
            // 
            LblPhoneNumberBuisness.AutoSize = true;
            LblPhoneNumberBuisness.BackColor = Color.FloralWhite;
            LblPhoneNumberBuisness.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblPhoneNumberBuisness.Location = new Point(698, 119);
            LblPhoneNumberBuisness.Name = "LblPhoneNumberBuisness";
            LblPhoneNumberBuisness.Size = new Size(150, 15);
            LblPhoneNumberBuisness.TabIndex = 100;
            LblPhoneNumberBuisness.Text = "Telefonnummer Firma";
            // 
            // LblAdressBuisness
            // 
            LblAdressBuisness.AutoSize = true;
            LblAdressBuisness.BackColor = Color.FloralWhite;
            LblAdressBuisness.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblAdressBuisness.Location = new Point(512, 299);
            LblAdressBuisness.Name = "LblAdressBuisness";
            LblAdressBuisness.Size = new Size(124, 15);
            LblAdressBuisness.TabIndex = 52;
            LblAdressBuisness.Text = "Geschäftsadresse";
            // 
            // TxtAdressBuisness
            // 
            TxtAdressBuisness.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtAdressBuisness.Location = new Point(512, 319);
            TxtAdressBuisness.Name = "TxtAdressBuisness";
            TxtAdressBuisness.Size = new Size(180, 23);
            TxtAdressBuisness.TabIndex = 11;
            // 
            // TxtPlzBuisness
            // 
            TxtPlzBuisness.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtPlzBuisness.Location = new Point(698, 319);
            TxtPlzBuisness.Name = "TxtPlzBuisness";
            TxtPlzBuisness.Size = new Size(100, 23);
            TxtPlzBuisness.TabIndex = 12;
            // 
            // LblPlzBuisness
            // 
            LblPlzBuisness.AutoSize = true;
            LblPlzBuisness.BackColor = Color.FloralWhite;
            LblPlzBuisness.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblPlzBuisness.Location = new Point(698, 299);
            LblPlzBuisness.Name = "LblPlzBuisness";
            LblPlzBuisness.Size = new Size(84, 15);
            LblPlzBuisness.TabIndex = 55;
            LblPlzBuisness.Text = "Postleitzahl";
            // 
            // LblResidence
            // 
            LblResidence.AutoSize = true;
            LblResidence.BackColor = Color.FloralWhite;
            LblResidence.Font = new Font("Arial Rounded MT Bold", 9.75F);
            LblResidence.Location = new Point(804, 239);
            LblResidence.Name = "LblResidence";
            LblResidence.Size = new Size(62, 15);
            LblResidence.TabIndex = 56;
            LblResidence.Text = "Wohnort";
            // 
            // TxtResidence
            // 
            TxtResidence.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtResidence.Location = new Point(804, 259);
            TxtResidence.Name = "TxtResidence";
            TxtResidence.Size = new Size(180, 23);
            TxtResidence.TabIndex = 10;
            // 
            // CmdUpdate
            // 
            CmdUpdate.Font = new Font("Arial Rounded MT Bold", 9.75F);
            CmdUpdate.Location = new Point(592, 10);
            CmdUpdate.Name = "CmdUpdate";
            CmdUpdate.Size = new Size(70, 23);
            CmdUpdate.TabIndex = 58;
            CmdUpdate.TabStop = false;
            CmdUpdate.Text = "Edit";
            CmdUpdate.UseVisualStyleBackColor = true;
            CmdUpdate.Click += CmdUpdate_Click;
            // 
            // TabContactList
            // 
            TabContactList.Controls.Add(TabEmployees);
            TabContactList.Controls.Add(TabCustomers);
            TabContactList.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TabContactList.Location = new Point(11, 62);
            TabContactList.Multiline = true;
            TabContactList.Name = "TabContactList";
            TabContactList.SelectedIndex = 0;
            TabContactList.Size = new Size(493, 472);
            TabContactList.TabIndex = 59;
            // 
            // TabEmployees
            // 
            TabEmployees.Controls.Add(TxtEmployeeOutput);
            TabEmployees.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TabEmployees.Location = new Point(4, 24);
            TabEmployees.Name = "TabEmployees";
            TabEmployees.Padding = new Padding(3);
            TabEmployees.Size = new Size(485, 444);
            TabEmployees.TabIndex = 0;
            TabEmployees.Text = "Mitarbeiter";
            TabEmployees.UseVisualStyleBackColor = true;
            // 
            // TxtEmployeeOutput
            // 
            TxtEmployeeOutput.BackColor = Color.FloralWhite;
            TxtEmployeeOutput.Dock = DockStyle.Fill;
            TxtEmployeeOutput.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtEmployeeOutput.Location = new Point(3, 3);
            TxtEmployeeOutput.Name = "TxtEmployeeOutput";
            TxtEmployeeOutput.ReadOnly = true;
            TxtEmployeeOutput.Size = new Size(479, 438);
            TxtEmployeeOutput.TabIndex = 0;
            TxtEmployeeOutput.TabStop = false;
            TxtEmployeeOutput.Text = "";
            TxtEmployeeOutput.WordWrap = false;
            // 
            // TabCustomers
            // 
            TabCustomers.Controls.Add(TxtCustomerOutput);
            TabCustomers.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TabCustomers.Location = new Point(4, 24);
            TabCustomers.Name = "TabCustomers";
            TabCustomers.Padding = new Padding(3);
            TabCustomers.Size = new Size(485, 444);
            TabCustomers.TabIndex = 1;
            TabCustomers.Text = "Kunden";
            TabCustomers.UseVisualStyleBackColor = true;
            // 
            // TxtCustomerOutput
            // 
            TxtCustomerOutput.BackColor = Color.FloralWhite;
            TxtCustomerOutput.Dock = DockStyle.Fill;
            TxtCustomerOutput.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtCustomerOutput.Location = new Point(3, 3);
            TxtCustomerOutput.Name = "TxtCustomerOutput";
            TxtCustomerOutput.ReadOnly = true;
            TxtCustomerOutput.Size = new Size(479, 438);
            TxtCustomerOutput.TabIndex = 0;
            TxtCustomerOutput.Text = "";
            TxtCustomerOutput.WordWrap = false;
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Arial Rounded MT Bold", 9.75F);
            TxtSearch.Location = new Point(812, 10);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Suchen...";
            TxtSearch.Size = new Size(293, 23);
            TxtSearch.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1117, 542);
            Controls.Add(TxtSearch);
            Controls.Add(TabContactList);
            Controls.Add(CmdUpdate);
            Controls.Add(TxtResidence);
            Controls.Add(LblResidence);
            Controls.Add(LblPlzBuisness);
            Controls.Add(TxtPlzBuisness);
            Controls.Add(TxtAdressBuisness);
            Controls.Add(LblAdressBuisness);
            Controls.Add(LblPhoneNumberBuisness);
            Controls.Add(TxtPhoneNumberBuisness);
            Controls.Add(CmdDelete);
            Controls.Add(LblTraineeYear);
            Controls.Add(LblTrainee);
            Controls.Add(LblManagementLevel);
            Controls.Add(LblEmployment);
            Controls.Add(LblExit);
            Controls.Add(LblEntry);
            Controls.Add(LblNationality);
            Controls.Add(LblPlzPrivat);
            Controls.Add(LblAdressPrivat);
            Controls.Add(LblAhvNumber);
            Controls.Add(LblDepartment);
            Controls.Add(LblEmployeeNumber);
            Controls.Add(lblTitle);
            Controls.Add(LblSalutation);
            Controls.Add(LblGender);
            Controls.Add(LblEmail);
            Controls.Add(LblPhoneNumberPrivate);
            Controls.Add(LblBirthday);
            Controls.Add(LblLastName);
            Controls.Add(LblFirstName);
            Controls.Add(CmdSave);
            Controls.Add(RadEmployee);
            Controls.Add(RadCustomer);
            Controls.Add(TxtTraineeYear);
            Controls.Add(ChkTrainee);
            Controls.Add(CmbManagmentLevel);
            Controls.Add(TxtEmployment);
            Controls.Add(DtExitDate);
            Controls.Add(DtEntryDate);
            Controls.Add(TxtNationality);
            Controls.Add(TxtPlzPrivat);
            Controls.Add(TxtAdressPrivat);
            Controls.Add(TxtAhvNumber);
            Controls.Add(CmbDepartment);
            Controls.Add(TxtEmployeeNumber);
            Controls.Add(CmbTitle);
            Controls.Add(CmbGender);
            Controls.Add(CmbSalutation);
            Controls.Add(ChkActive);
            Controls.Add(TxtEmail);
            Controls.Add(TxtPhoneNumberPrivate);
            Controls.Add(DtBirthday);
            Controls.Add(TxtLastName);
            Controls.Add(TxtFirstName);
            Name = "Form1";
            Text = "Contact Manager";
            TabContactList.ResumeLayout(false);
            TabEmployees.ResumeLayout(false);
            TabCustomers.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtFirstName;
        private TextBox TxtLastName;
        private DateTimePicker DtBirthday;
        private TextBox TxtPhoneNumberPrivate;
        private TextBox TxtEmail;
        private CheckBox ChkActive;
        private ComboBox CmbSalutation;
        private ComboBox CmbGender;
        private ComboBox CmbTitle;
        private TextBox TxtEmployeeNumber;
        private ComboBox CmbDepartment;
        private TextBox TxtAhvNumber;
        private TextBox TxtAdressPrivat;
        private TextBox TxtPlzPrivat;
        private TextBox TxtNationality;
        private DateTimePicker DtEntryDate;
        private DateTimePicker DtExitDate;
        private TextBox TxtEmployment;
        private ComboBox CmbManagmentLevel;
        private CheckBox ChkTrainee;
        private TextBox TxtTraineeYear;
        private RadioButton RadCustomer;
        private RadioButton RadEmployee;
        private Button CmdSave;
        private Label LblFirstName;
        private Label LblLastName;
        private Label LblBirthday;
        private Label LblPhoneNumberPrivate;
        private Label LblEmail;
        private Label LblGender;
        private Label LblSalutation;
        private Label lblTitle;
        private Label LblEmployeeNumber;
        private Label LblDepartment;
        private Label LblAhvNumber;
        private Label LblAdressPrivat;
        private Label LblPlzPrivat;
        private Label LblNationality;
        private Label LblEntry;
        private Label LblExit;
        private Label LblEmployment;
        private Label LblManagementLevel;
        private Label LblTrainee;
        private Label LblTraineeYear;
        private Button CmdDelete;
        private TextBox TxtPhoneNumberBuisness;
        private Label LblPhoneNumberBuisness;
        private Label LblAdressBuisness;
        private TextBox TxtAdressBuisness;
        private TextBox TxtPlzBuisness;
        private Label LblPlzBuisness;
        private Label LblResidence;
        private TextBox TxtResidence;
        private Button CmdUpdate;
        private TabControl TabContactList;
        private TabPage TabEmployees;
        private TabPage TabCustomers;
        private RichTextBox TxtEmployeeOutput;
        private RichTextBox TxtCustomerOutput;
        private TextBox TxtSearch;
    }
}
