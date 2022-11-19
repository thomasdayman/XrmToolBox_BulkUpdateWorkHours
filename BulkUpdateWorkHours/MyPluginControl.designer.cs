namespace BulkUpdateWorkHours
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.userList = new System.Windows.Forms.CheckedListBox();
            this.getUsers = new System.Windows.Forms.Button();
            this.workDayBox = new System.Windows.Forms.GroupBox();
            this.sat = new System.Windows.Forms.CheckBox();
            this.fri = new System.Windows.Forms.CheckBox();
            this.thu = new System.Windows.Forms.CheckBox();
            this.wed = new System.Windows.Forms.CheckBox();
            this.tue = new System.Windows.Forms.CheckBox();
            this.mon = new System.Windows.Forms.CheckBox();
            this.sun = new System.Windows.Forms.CheckBox();
            this.noEndDate = new System.Windows.Forms.CheckBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.workHours = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.selectAll = new System.Windows.Forms.CheckBox();
            this.setWorkHours = new System.Windows.Forms.Button();
            this.varyByDayBox = new System.Windows.Forms.GroupBox();
            this.vSunEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vSunEndLabel = new System.Windows.Forms.Label();
            this.vSunStartLabel = new System.Windows.Forms.Label();
            this.vSunStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vMonEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vMonEndLabel = new System.Windows.Forms.Label();
            this.vMonStartLabel = new System.Windows.Forms.Label();
            this.vMonStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vTueEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vTueEndLabel = new System.Windows.Forms.Label();
            this.vTueStartLabel = new System.Windows.Forms.Label();
            this.vTueStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vWedEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vWedEndLabel = new System.Windows.Forms.Label();
            this.vWedStartLabel = new System.Windows.Forms.Label();
            this.vWedStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vThuEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vThuEndLabel = new System.Windows.Forms.Label();
            this.vThuStartLabel = new System.Windows.Forms.Label();
            this.vThuStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vFriEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vFriEndLabel = new System.Windows.Forms.Label();
            this.vFriStartLabel = new System.Windows.Forms.Label();
            this.vFriStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vSatEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vSat = new System.Windows.Forms.CheckBox();
            this.vSatEndLabel = new System.Windows.Forms.Label();
            this.vFri = new System.Windows.Forms.CheckBox();
            this.vSatStartLabel = new System.Windows.Forms.Label();
            this.vSatStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vThu = new System.Windows.Forms.CheckBox();
            this.vWed = new System.Windows.Forms.CheckBox();
            this.vTue = new System.Windows.Forms.CheckBox();
            this.vMon = new System.Windows.Forms.CheckBox();
            this.vSun = new System.Windows.Forms.CheckBox();
            this.sameSchedule = new System.Windows.Forms.RadioButton();
            this.varySchedule = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.workDate = new System.Windows.Forms.GroupBox();
            this.noStartDate = new System.Windows.Forms.CheckBox();
            this.everyXWeeks = new System.Windows.Forms.NumericUpDown();
            this.everyXWeeksLabel = new System.Windows.Forms.Label();
            this.clearWorkHours = new System.Windows.Forms.Button();
            this.Capacity = new System.Windows.Forms.GroupBox();
            this.timeZoneLabel = new System.Windows.Forms.Label();
            this.timeZonesBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.calendarTypesBox = new System.Windows.Forms.ComboBox();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityValue = new System.Windows.Forms.NumericUpDown();
            this.bookableResourceFetchXML = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bookableResourceFetchXMLValue = new System.Windows.Forms.RichTextBox();
            this.workDayBox.SuspendLayout();
            this.workHours.SuspendLayout();
            this.varyByDayBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.workDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyXWeeks)).BeginInit();
            this.Capacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityValue)).BeginInit();
            this.bookableResourceFetchXML.SuspendLayout();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.CheckOnClick = true;
            this.userList.DisplayMember = "BookableName";
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(3, 92);
            this.userList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(283, 769);
            this.userList.TabIndex = 5;
            this.userList.ValueMember = "BookableGUID";
            // 
            // getUsers
            // 
            this.getUsers.Location = new System.Drawing.Point(3, 35);
            this.getUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getUsers.Name = "getUsers";
            this.getUsers.Size = new System.Drawing.Size(283, 26);
            this.getUsers.TabIndex = 7;
            this.getUsers.Text = "Retrieve Bookable Resources";
            this.getUsers.UseVisualStyleBackColor = true;
            this.getUsers.Click += new System.EventHandler(this.getUsers_Click);
            // 
            // workDayBox
            // 
            this.workDayBox.Controls.Add(this.sat);
            this.workDayBox.Controls.Add(this.fri);
            this.workDayBox.Controls.Add(this.thu);
            this.workDayBox.Controls.Add(this.wed);
            this.workDayBox.Controls.Add(this.tue);
            this.workDayBox.Controls.Add(this.mon);
            this.workDayBox.Controls.Add(this.sun);
            this.workDayBox.Location = new System.Drawing.Point(901, 281);
            this.workDayBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.workDayBox.Name = "workDayBox";
            this.workDayBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.workDayBox.Size = new System.Drawing.Size(450, 100);
            this.workDayBox.TabIndex = 8;
            this.workDayBox.TabStop = false;
            this.workDayBox.Text = "Work Days";
            // 
            // sat
            // 
            this.sat.AutoSize = true;
            this.sat.Location = new System.Drawing.Point(236, 60);
            this.sat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sat.Name = "sat";
            this.sat.Size = new System.Drawing.Size(51, 21);
            this.sat.TabIndex = 6;
            this.sat.Text = "Sat";
            this.sat.UseVisualStyleBackColor = true;
            // 
            // fri
            // 
            this.fri.AutoSize = true;
            this.fri.Location = new System.Drawing.Point(183, 60);
            this.fri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fri.Name = "fri";
            this.fri.Size = new System.Drawing.Size(46, 21);
            this.fri.TabIndex = 5;
            this.fri.Text = "Fri";
            this.fri.UseVisualStyleBackColor = true;
            // 
            // thu
            // 
            this.thu.AutoSize = true;
            this.thu.Location = new System.Drawing.Point(123, 60);
            this.thu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thu.Name = "thu";
            this.thu.Size = new System.Drawing.Size(55, 21);
            this.thu.TabIndex = 4;
            this.thu.Text = "Thu";
            this.thu.UseVisualStyleBackColor = true;
            // 
            // wed
            // 
            this.wed.AutoSize = true;
            this.wed.Location = new System.Drawing.Point(266, 36);
            this.wed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wed.Name = "wed";
            this.wed.Size = new System.Drawing.Size(59, 21);
            this.wed.TabIndex = 3;
            this.wed.Text = "Wed";
            this.wed.UseVisualStyleBackColor = true;
            // 
            // tue
            // 
            this.tue.AutoSize = true;
            this.tue.Location = new System.Drawing.Point(205, 36);
            this.tue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tue.Name = "tue";
            this.tue.Size = new System.Drawing.Size(55, 21);
            this.tue.TabIndex = 2;
            this.tue.Text = "Tue";
            this.tue.UseVisualStyleBackColor = true;
            // 
            // mon
            // 
            this.mon.AutoSize = true;
            this.mon.Location = new System.Drawing.Point(141, 36);
            this.mon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mon.Name = "mon";
            this.mon.Size = new System.Drawing.Size(57, 21);
            this.mon.TabIndex = 1;
            this.mon.Text = "Mon";
            this.mon.UseVisualStyleBackColor = true;
            // 
            // sun
            // 
            this.sun.AutoSize = true;
            this.sun.Location = new System.Drawing.Point(82, 36);
            this.sun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sun.Name = "sun";
            this.sun.Size = new System.Drawing.Size(55, 21);
            this.sun.TabIndex = 0;
            this.sun.Text = "Sun";
            this.sun.UseVisualStyleBackColor = true;
            // 
            // noEndDate
            // 
            this.noEndDate.AutoSize = true;
            this.noEndDate.Location = new System.Drawing.Point(313, 84);
            this.noEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noEndDate.Name = "noEndDate";
            this.noEndDate.Size = new System.Drawing.Size(111, 21);
            this.noEndDate.TabIndex = 12;
            this.noEndDate.Text = "No End Date";
            this.noEndDate.UseVisualStyleBackColor = true;
            this.noEndDate.CheckedChanged += new System.EventHandler(this.noEndDate_CheckedChanged);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(116, 83);
            this.endDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(178, 22);
            this.endDatePicker.TabIndex = 11;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(39, 83);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(67, 17);
            this.endDateLabel.TabIndex = 10;
            this.endDateLabel.Text = "End Date";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(34, 49);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(72, 17);
            this.startDateLabel.TabIndex = 9;
            this.startDateLabel.Text = "Start Date";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(116, 49);
            this.startDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(178, 22);
            this.startDatePicker.TabIndex = 7;
            // 
            // workHours
            // 
            this.workHours.Controls.Add(this.groupBox1);
            this.workHours.Controls.Add(this.endTimePicker);
            this.workHours.Controls.Add(this.endTimeLabel);
            this.workHours.Controls.Add(this.startTimeLabel);
            this.workHours.Controls.Add(this.startTimePicker);
            this.workHours.Location = new System.Drawing.Point(901, 568);
            this.workHours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.workHours.Name = "workHours";
            this.workHours.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.workHours.Size = new System.Drawing.Size(450, 129);
            this.workHours.TabIndex = 9;
            this.workHours.TabStop = false;
            this.workHours.Text = "Work Hours";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 82);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "HH:mm";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(116, 78);
            this.endTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(178, 22);
            this.endTimePicker.TabIndex = 14;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(43, 79);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(68, 17);
            this.endTimeLabel.TabIndex = 13;
            this.endTimeLabel.Text = "End Time";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(37, 46);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(73, 17);
            this.startTimeLabel.TabIndex = 12;
            this.startTimeLabel.Text = "Start Time";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "HH:mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(116, 44);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(178, 22);
            this.startTimePicker.TabIndex = 11;
            // 
            // selectAll
            // 
            this.selectAll.AutoSize = true;
            this.selectAll.Location = new System.Drawing.Point(7, 68);
            this.selectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(88, 21);
            this.selectAll.TabIndex = 11;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.CheckedChanged += new System.EventHandler(this.selectAll_CheckedChanged);
            // 
            // setWorkHours
            // 
            this.setWorkHours.Location = new System.Drawing.Point(901, 35);
            this.setWorkHours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setWorkHours.Name = "setWorkHours";
            this.setWorkHours.Size = new System.Drawing.Size(904, 57);
            this.setWorkHours.TabIndex = 12;
            this.setWorkHours.Text = "Set Work Hours";
            this.setWorkHours.UseVisualStyleBackColor = true;
            this.setWorkHours.Click += new System.EventHandler(this.setWorkHours_Click);
            // 
            // varyByDayBox
            // 
            this.varyByDayBox.Controls.Add(this.vSunEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vSunEndLabel);
            this.varyByDayBox.Controls.Add(this.vSunStartLabel);
            this.varyByDayBox.Controls.Add(this.vSunStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vMonEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vMonEndLabel);
            this.varyByDayBox.Controls.Add(this.vMonStartLabel);
            this.varyByDayBox.Controls.Add(this.vMonStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vTueEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vTueEndLabel);
            this.varyByDayBox.Controls.Add(this.vTueStartLabel);
            this.varyByDayBox.Controls.Add(this.vTueStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vWedEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vWedEndLabel);
            this.varyByDayBox.Controls.Add(this.vWedStartLabel);
            this.varyByDayBox.Controls.Add(this.vWedStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vThuEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vThuEndLabel);
            this.varyByDayBox.Controls.Add(this.vThuStartLabel);
            this.varyByDayBox.Controls.Add(this.vThuStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vFriEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vFriEndLabel);
            this.varyByDayBox.Controls.Add(this.vFriStartLabel);
            this.varyByDayBox.Controls.Add(this.vFriStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vSatEndTimePicker);
            this.varyByDayBox.Controls.Add(this.vSat);
            this.varyByDayBox.Controls.Add(this.vSatEndLabel);
            this.varyByDayBox.Controls.Add(this.vFri);
            this.varyByDayBox.Controls.Add(this.vSatStartLabel);
            this.varyByDayBox.Controls.Add(this.vSatStartTimePicker);
            this.varyByDayBox.Controls.Add(this.vThu);
            this.varyByDayBox.Controls.Add(this.vWed);
            this.varyByDayBox.Controls.Add(this.vTue);
            this.varyByDayBox.Controls.Add(this.vMon);
            this.varyByDayBox.Controls.Add(this.vSun);
            this.varyByDayBox.Location = new System.Drawing.Point(1374, 158);
            this.varyByDayBox.Name = "varyByDayBox";
            this.varyByDayBox.Size = new System.Drawing.Size(431, 593);
            this.varyByDayBox.TabIndex = 13;
            this.varyByDayBox.TabStop = false;
            this.varyByDayBox.Text = "Vary by Day";
            this.varyByDayBox.Visible = false;
            // 
            // vSunEndTimePicker
            // 
            this.vSunEndTimePicker.CustomFormat = "HH:mm";
            this.vSunEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vSunEndTimePicker.Location = new System.Drawing.Point(166, 75);
            this.vSunEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vSunEndTimePicker.Name = "vSunEndTimePicker";
            this.vSunEndTimePicker.ShowUpDown = true;
            this.vSunEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vSunEndTimePicker.TabIndex = 42;
            this.vSunEndTimePicker.Visible = false;
            // 
            // vSunEndLabel
            // 
            this.vSunEndLabel.AutoSize = true;
            this.vSunEndLabel.Location = new System.Drawing.Point(93, 76);
            this.vSunEndLabel.Name = "vSunEndLabel";
            this.vSunEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vSunEndLabel.TabIndex = 41;
            this.vSunEndLabel.Text = "End Time";
            this.vSunEndLabel.Visible = false;
            // 
            // vSunStartLabel
            // 
            this.vSunStartLabel.AutoSize = true;
            this.vSunStartLabel.Location = new System.Drawing.Point(88, 43);
            this.vSunStartLabel.Name = "vSunStartLabel";
            this.vSunStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vSunStartLabel.TabIndex = 40;
            this.vSunStartLabel.Text = "Start Time";
            this.vSunStartLabel.Visible = false;
            // 
            // vSunStartTimePicker
            // 
            this.vSunStartTimePicker.CustomFormat = "HH:mm";
            this.vSunStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vSunStartTimePicker.Location = new System.Drawing.Point(166, 41);
            this.vSunStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vSunStartTimePicker.Name = "vSunStartTimePicker";
            this.vSunStartTimePicker.ShowUpDown = true;
            this.vSunStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vSunStartTimePicker.TabIndex = 39;
            this.vSunStartTimePicker.Visible = false;
            // 
            // vMonEndTimePicker
            // 
            this.vMonEndTimePicker.CustomFormat = "HH:mm";
            this.vMonEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vMonEndTimePicker.Location = new System.Drawing.Point(166, 156);
            this.vMonEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vMonEndTimePicker.Name = "vMonEndTimePicker";
            this.vMonEndTimePicker.ShowUpDown = true;
            this.vMonEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vMonEndTimePicker.TabIndex = 38;
            this.vMonEndTimePicker.Visible = false;
            // 
            // vMonEndLabel
            // 
            this.vMonEndLabel.AutoSize = true;
            this.vMonEndLabel.Location = new System.Drawing.Point(93, 157);
            this.vMonEndLabel.Name = "vMonEndLabel";
            this.vMonEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vMonEndLabel.TabIndex = 37;
            this.vMonEndLabel.Text = "End Time";
            this.vMonEndLabel.Visible = false;
            // 
            // vMonStartLabel
            // 
            this.vMonStartLabel.AutoSize = true;
            this.vMonStartLabel.Location = new System.Drawing.Point(88, 124);
            this.vMonStartLabel.Name = "vMonStartLabel";
            this.vMonStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vMonStartLabel.TabIndex = 36;
            this.vMonStartLabel.Text = "Start Time";
            this.vMonStartLabel.Visible = false;
            // 
            // vMonStartTimePicker
            // 
            this.vMonStartTimePicker.CustomFormat = "HH:mm";
            this.vMonStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vMonStartTimePicker.Location = new System.Drawing.Point(166, 122);
            this.vMonStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vMonStartTimePicker.Name = "vMonStartTimePicker";
            this.vMonStartTimePicker.ShowUpDown = true;
            this.vMonStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vMonStartTimePicker.TabIndex = 35;
            this.vMonStartTimePicker.Visible = false;
            // 
            // vTueEndTimePicker
            // 
            this.vTueEndTimePicker.CustomFormat = "HH:mm";
            this.vTueEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vTueEndTimePicker.Location = new System.Drawing.Point(166, 235);
            this.vTueEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vTueEndTimePicker.Name = "vTueEndTimePicker";
            this.vTueEndTimePicker.ShowUpDown = true;
            this.vTueEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vTueEndTimePicker.TabIndex = 34;
            this.vTueEndTimePicker.Visible = false;
            // 
            // vTueEndLabel
            // 
            this.vTueEndLabel.AutoSize = true;
            this.vTueEndLabel.Location = new System.Drawing.Point(93, 236);
            this.vTueEndLabel.Name = "vTueEndLabel";
            this.vTueEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vTueEndLabel.TabIndex = 33;
            this.vTueEndLabel.Text = "End Time";
            this.vTueEndLabel.Visible = false;
            // 
            // vTueStartLabel
            // 
            this.vTueStartLabel.AutoSize = true;
            this.vTueStartLabel.Location = new System.Drawing.Point(88, 203);
            this.vTueStartLabel.Name = "vTueStartLabel";
            this.vTueStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vTueStartLabel.TabIndex = 32;
            this.vTueStartLabel.Text = "Start Time";
            this.vTueStartLabel.Visible = false;
            // 
            // vTueStartTimePicker
            // 
            this.vTueStartTimePicker.CustomFormat = "HH:mm";
            this.vTueStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vTueStartTimePicker.Location = new System.Drawing.Point(166, 201);
            this.vTueStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vTueStartTimePicker.Name = "vTueStartTimePicker";
            this.vTueStartTimePicker.ShowUpDown = true;
            this.vTueStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vTueStartTimePicker.TabIndex = 31;
            this.vTueStartTimePicker.Visible = false;
            // 
            // vWedEndTimePicker
            // 
            this.vWedEndTimePicker.CustomFormat = "HH:mm";
            this.vWedEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vWedEndTimePicker.Location = new System.Drawing.Point(166, 315);
            this.vWedEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vWedEndTimePicker.Name = "vWedEndTimePicker";
            this.vWedEndTimePicker.ShowUpDown = true;
            this.vWedEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vWedEndTimePicker.TabIndex = 30;
            this.vWedEndTimePicker.Visible = false;
            // 
            // vWedEndLabel
            // 
            this.vWedEndLabel.AutoSize = true;
            this.vWedEndLabel.Location = new System.Drawing.Point(93, 316);
            this.vWedEndLabel.Name = "vWedEndLabel";
            this.vWedEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vWedEndLabel.TabIndex = 29;
            this.vWedEndLabel.Text = "End Time";
            this.vWedEndLabel.Visible = false;
            // 
            // vWedStartLabel
            // 
            this.vWedStartLabel.AutoSize = true;
            this.vWedStartLabel.Location = new System.Drawing.Point(88, 283);
            this.vWedStartLabel.Name = "vWedStartLabel";
            this.vWedStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vWedStartLabel.TabIndex = 28;
            this.vWedStartLabel.Text = "Start Time";
            this.vWedStartLabel.Visible = false;
            // 
            // vWedStartTimePicker
            // 
            this.vWedStartTimePicker.CustomFormat = "HH:mm";
            this.vWedStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vWedStartTimePicker.Location = new System.Drawing.Point(166, 281);
            this.vWedStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vWedStartTimePicker.Name = "vWedStartTimePicker";
            this.vWedStartTimePicker.ShowUpDown = true;
            this.vWedStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vWedStartTimePicker.TabIndex = 27;
            this.vWedStartTimePicker.Visible = false;
            // 
            // vThuEndTimePicker
            // 
            this.vThuEndTimePicker.CustomFormat = "HH:mm";
            this.vThuEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vThuEndTimePicker.Location = new System.Drawing.Point(166, 391);
            this.vThuEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vThuEndTimePicker.Name = "vThuEndTimePicker";
            this.vThuEndTimePicker.ShowUpDown = true;
            this.vThuEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vThuEndTimePicker.TabIndex = 26;
            this.vThuEndTimePicker.Visible = false;
            // 
            // vThuEndLabel
            // 
            this.vThuEndLabel.AutoSize = true;
            this.vThuEndLabel.Location = new System.Drawing.Point(93, 392);
            this.vThuEndLabel.Name = "vThuEndLabel";
            this.vThuEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vThuEndLabel.TabIndex = 25;
            this.vThuEndLabel.Text = "End Time";
            this.vThuEndLabel.Visible = false;
            // 
            // vThuStartLabel
            // 
            this.vThuStartLabel.AutoSize = true;
            this.vThuStartLabel.Location = new System.Drawing.Point(88, 359);
            this.vThuStartLabel.Name = "vThuStartLabel";
            this.vThuStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vThuStartLabel.TabIndex = 24;
            this.vThuStartLabel.Text = "Start Time";
            this.vThuStartLabel.Visible = false;
            // 
            // vThuStartTimePicker
            // 
            this.vThuStartTimePicker.CustomFormat = "HH:mm";
            this.vThuStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vThuStartTimePicker.Location = new System.Drawing.Point(166, 357);
            this.vThuStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vThuStartTimePicker.Name = "vThuStartTimePicker";
            this.vThuStartTimePicker.ShowUpDown = true;
            this.vThuStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vThuStartTimePicker.TabIndex = 23;
            this.vThuStartTimePicker.Visible = false;
            // 
            // vFriEndTimePicker
            // 
            this.vFriEndTimePicker.CustomFormat = "HH:mm";
            this.vFriEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vFriEndTimePicker.Location = new System.Drawing.Point(166, 469);
            this.vFriEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vFriEndTimePicker.Name = "vFriEndTimePicker";
            this.vFriEndTimePicker.ShowUpDown = true;
            this.vFriEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vFriEndTimePicker.TabIndex = 22;
            this.vFriEndTimePicker.Visible = false;
            // 
            // vFriEndLabel
            // 
            this.vFriEndLabel.AutoSize = true;
            this.vFriEndLabel.Location = new System.Drawing.Point(93, 470);
            this.vFriEndLabel.Name = "vFriEndLabel";
            this.vFriEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vFriEndLabel.TabIndex = 21;
            this.vFriEndLabel.Text = "End Time";
            this.vFriEndLabel.Visible = false;
            // 
            // vFriStartLabel
            // 
            this.vFriStartLabel.AutoSize = true;
            this.vFriStartLabel.Location = new System.Drawing.Point(88, 437);
            this.vFriStartLabel.Name = "vFriStartLabel";
            this.vFriStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vFriStartLabel.TabIndex = 20;
            this.vFriStartLabel.Text = "Start Time";
            this.vFriStartLabel.Visible = false;
            // 
            // vFriStartTimePicker
            // 
            this.vFriStartTimePicker.CustomFormat = "HH:mm";
            this.vFriStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vFriStartTimePicker.Location = new System.Drawing.Point(166, 435);
            this.vFriStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vFriStartTimePicker.Name = "vFriStartTimePicker";
            this.vFriStartTimePicker.ShowUpDown = true;
            this.vFriStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vFriStartTimePicker.TabIndex = 19;
            this.vFriStartTimePicker.Visible = false;
            // 
            // vSatEndTimePicker
            // 
            this.vSatEndTimePicker.CustomFormat = "HH:mm";
            this.vSatEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vSatEndTimePicker.Location = new System.Drawing.Point(166, 545);
            this.vSatEndTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vSatEndTimePicker.Name = "vSatEndTimePicker";
            this.vSatEndTimePicker.ShowUpDown = true;
            this.vSatEndTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vSatEndTimePicker.TabIndex = 18;
            this.vSatEndTimePicker.Visible = false;
            // 
            // vSat
            // 
            this.vSat.AutoSize = true;
            this.vSat.Location = new System.Drawing.Point(25, 511);
            this.vSat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vSat.Name = "vSat";
            this.vSat.Size = new System.Drawing.Size(51, 21);
            this.vSat.TabIndex = 13;
            this.vSat.Text = "Sat";
            this.vSat.UseVisualStyleBackColor = true;
            this.vSat.CheckedChanged += new System.EventHandler(this.vSat_CheckedChanged);
            // 
            // vSatEndLabel
            // 
            this.vSatEndLabel.AutoSize = true;
            this.vSatEndLabel.Location = new System.Drawing.Point(93, 546);
            this.vSatEndLabel.Name = "vSatEndLabel";
            this.vSatEndLabel.Size = new System.Drawing.Size(68, 17);
            this.vSatEndLabel.TabIndex = 17;
            this.vSatEndLabel.Text = "End Time";
            this.vSatEndLabel.Visible = false;
            // 
            // vFri
            // 
            this.vFri.AutoSize = true;
            this.vFri.Location = new System.Drawing.Point(25, 435);
            this.vFri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vFri.Name = "vFri";
            this.vFri.Size = new System.Drawing.Size(46, 21);
            this.vFri.TabIndex = 13;
            this.vFri.Text = "Fri";
            this.vFri.UseVisualStyleBackColor = true;
            this.vFri.CheckedChanged += new System.EventHandler(this.vFri_CheckedChanged);
            // 
            // vSatStartLabel
            // 
            this.vSatStartLabel.AutoSize = true;
            this.vSatStartLabel.Location = new System.Drawing.Point(88, 513);
            this.vSatStartLabel.Name = "vSatStartLabel";
            this.vSatStartLabel.Size = new System.Drawing.Size(73, 17);
            this.vSatStartLabel.TabIndex = 16;
            this.vSatStartLabel.Text = "Start Time";
            this.vSatStartLabel.Visible = false;
            // 
            // vSatStartTimePicker
            // 
            this.vSatStartTimePicker.CustomFormat = "HH:mm";
            this.vSatStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vSatStartTimePicker.Location = new System.Drawing.Point(166, 511);
            this.vSatStartTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vSatStartTimePicker.Name = "vSatStartTimePicker";
            this.vSatStartTimePicker.ShowUpDown = true;
            this.vSatStartTimePicker.Size = new System.Drawing.Size(178, 22);
            this.vSatStartTimePicker.TabIndex = 15;
            this.vSatStartTimePicker.Visible = false;
            // 
            // vThu
            // 
            this.vThu.AutoSize = true;
            this.vThu.Location = new System.Drawing.Point(25, 357);
            this.vThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vThu.Name = "vThu";
            this.vThu.Size = new System.Drawing.Size(55, 21);
            this.vThu.TabIndex = 13;
            this.vThu.Text = "Thu";
            this.vThu.UseVisualStyleBackColor = true;
            this.vThu.CheckedChanged += new System.EventHandler(this.vThu_CheckedChanged);
            // 
            // vWed
            // 
            this.vWed.AutoSize = true;
            this.vWed.Location = new System.Drawing.Point(25, 282);
            this.vWed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vWed.Name = "vWed";
            this.vWed.Size = new System.Drawing.Size(59, 21);
            this.vWed.TabIndex = 15;
            this.vWed.Text = "Wed";
            this.vWed.UseVisualStyleBackColor = true;
            this.vWed.CheckedChanged += new System.EventHandler(this.vWed_CheckedChanged);
            // 
            // vTue
            // 
            this.vTue.AutoSize = true;
            this.vTue.Location = new System.Drawing.Point(25, 202);
            this.vTue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vTue.Name = "vTue";
            this.vTue.Size = new System.Drawing.Size(55, 21);
            this.vTue.TabIndex = 13;
            this.vTue.Text = "Tue";
            this.vTue.UseVisualStyleBackColor = true;
            this.vTue.CheckedChanged += new System.EventHandler(this.vTue_CheckedChanged);
            // 
            // vMon
            // 
            this.vMon.AutoSize = true;
            this.vMon.Location = new System.Drawing.Point(25, 123);
            this.vMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vMon.Name = "vMon";
            this.vMon.Size = new System.Drawing.Size(57, 21);
            this.vMon.TabIndex = 14;
            this.vMon.Text = "Mon";
            this.vMon.UseVisualStyleBackColor = true;
            this.vMon.CheckedChanged += new System.EventHandler(this.vMon_CheckedChanged);
            // 
            // vSun
            // 
            this.vSun.AutoSize = true;
            this.vSun.Location = new System.Drawing.Point(25, 42);
            this.vSun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vSun.Name = "vSun";
            this.vSun.Size = new System.Drawing.Size(55, 21);
            this.vSun.TabIndex = 13;
            this.vSun.Text = "Sun";
            this.vSun.UseVisualStyleBackColor = true;
            this.vSun.CheckedChanged += new System.EventHandler(this.vSun_CheckedChanged);
            // 
            // sameSchedule
            // 
            this.sameSchedule.AutoSize = true;
            this.sameSchedule.Checked = true;
            this.sameSchedule.Location = new System.Drawing.Point(82, 39);
            this.sameSchedule.Name = "sameSchedule";
            this.sameSchedule.Size = new System.Drawing.Size(175, 21);
            this.sameSchedule.TabIndex = 14;
            this.sameSchedule.TabStop = true;
            this.sameSchedule.Text = "Are the same each day";
            this.sameSchedule.UseVisualStyleBackColor = true;
            this.sameSchedule.CheckedChanged += new System.EventHandler(this.sameSchedule_CheckedChanged);
            // 
            // varySchedule
            // 
            this.varySchedule.AutoSize = true;
            this.varySchedule.Location = new System.Drawing.Point(82, 74);
            this.varySchedule.Name = "varySchedule";
            this.varySchedule.Size = new System.Drawing.Size(104, 21);
            this.varySchedule.TabIndex = 15;
            this.varySchedule.TabStop = true;
            this.varySchedule.Text = "Vary by day";
            this.varySchedule.UseVisualStyleBackColor = true;
            this.varySchedule.CheckedChanged += new System.EventHandler(this.varySchedule_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.varySchedule);
            this.groupBox2.Controls.Add(this.sameSchedule);
            this.groupBox2.Location = new System.Drawing.Point(901, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 117);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Work Hours Type";
            // 
            // workDate
            // 
            this.workDate.Controls.Add(this.noStartDate);
            this.workDate.Controls.Add(this.everyXWeeks);
            this.workDate.Controls.Add(this.everyXWeeksLabel);
            this.workDate.Controls.Add(this.noEndDate);
            this.workDate.Controls.Add(this.endDateLabel);
            this.workDate.Controls.Add(this.startDatePicker);
            this.workDate.Controls.Add(this.endDatePicker);
            this.workDate.Controls.Add(this.startDateLabel);
            this.workDate.Location = new System.Drawing.Point(901, 387);
            this.workDate.Name = "workDate";
            this.workDate.Size = new System.Drawing.Size(450, 174);
            this.workDate.TabIndex = 17;
            this.workDate.TabStop = false;
            this.workDate.Text = "Work Dates";
            // 
            // noStartDate
            // 
            this.noStartDate.AutoSize = true;
            this.noStartDate.Location = new System.Drawing.Point(313, 50);
            this.noStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noStartDate.Name = "noStartDate";
            this.noStartDate.Size = new System.Drawing.Size(116, 21);
            this.noStartDate.TabIndex = 16;
            this.noStartDate.Text = "No Start Date";
            this.noStartDate.UseVisualStyleBackColor = true;
            // 
            // everyXWeeks
            // 
            this.everyXWeeks.Location = new System.Drawing.Point(174, 136);
            this.everyXWeeks.Name = "everyXWeeks";
            this.everyXWeeks.ReadOnly = true;
            this.everyXWeeks.Size = new System.Drawing.Size(120, 22);
            this.everyXWeeks.TabIndex = 15;
            // 
            // everyXWeeksLabel
            // 
            this.everyXWeeksLabel.AutoSize = true;
            this.everyXWeeksLabel.Location = new System.Drawing.Point(34, 138);
            this.everyXWeeksLabel.Name = "everyXWeeksLabel";
            this.everyXWeeksLabel.Size = new System.Drawing.Size(114, 17);
            this.everyXWeeksLabel.TabIndex = 14;
            this.everyXWeeksLabel.Text = "Every X Week(s)";
            // 
            // clearWorkHours
            // 
            this.clearWorkHours.BackColor = System.Drawing.SystemColors.ControlDark;
            this.clearWorkHours.Location = new System.Drawing.Point(901, 108);
            this.clearWorkHours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearWorkHours.Name = "clearWorkHours";
            this.clearWorkHours.Size = new System.Drawing.Size(904, 34);
            this.clearWorkHours.TabIndex = 18;
            this.clearWorkHours.Text = "Clear Work Hours";
            this.clearWorkHours.UseVisualStyleBackColor = false;
            this.clearWorkHours.Click += new System.EventHandler(this.clearWorkHours_Click);
            // 
            // Capacity
            // 
            this.Capacity.Controls.Add(this.timeZoneLabel);
            this.Capacity.Controls.Add(this.timeZonesBox);
            this.Capacity.Controls.Add(this.label2);
            this.Capacity.Controls.Add(this.calendarTypesBox);
            this.Capacity.Controls.Add(this.capacityLabel);
            this.Capacity.Controls.Add(this.capacityValue);
            this.Capacity.Location = new System.Drawing.Point(901, 705);
            this.Capacity.Name = "Capacity";
            this.Capacity.Size = new System.Drawing.Size(450, 139);
            this.Capacity.TabIndex = 19;
            this.Capacity.TabStop = false;
            this.Capacity.Text = "Misc";
            // 
            // timeZoneLabel
            // 
            this.timeZoneLabel.AutoSize = true;
            this.timeZoneLabel.Location = new System.Drawing.Point(13, 101);
            this.timeZoneLabel.Name = "timeZoneLabel";
            this.timeZoneLabel.Size = new System.Drawing.Size(76, 17);
            this.timeZoneLabel.TabIndex = 21;
            this.timeZoneLabel.Text = "Time Zone";
            // 
            // timeZonesBox
            // 
            this.timeZonesBox.FormattingEnabled = true;
            this.timeZonesBox.Location = new System.Drawing.Point(95, 98);
            this.timeZonesBox.Name = "timeZonesBox";
            this.timeZonesBox.Size = new System.Drawing.Size(329, 24);
            this.timeZonesBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Calendar Type";
            // 
            // calendarTypesBox
            // 
            this.calendarTypesBox.FormattingEnabled = true;
            this.calendarTypesBox.Items.AddRange(new object[] {
            "Working",
            "Non Working",
            "Time Off"});
            this.calendarTypesBox.Location = new System.Drawing.Point(195, 24);
            this.calendarTypesBox.Name = "calendarTypesBox";
            this.calendarTypesBox.Size = new System.Drawing.Size(152, 24);
            this.calendarTypesBox.TabIndex = 18;
            this.calendarTypesBox.SelectedIndexChanged += new System.EventHandler(this.calendarTypesBox_SelectedIndexChanged);
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(127, 62);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(62, 17);
            this.capacityLabel.TabIndex = 17;
            this.capacityLabel.Text = "Capacity";
            // 
            // capacityValue
            // 
            this.capacityValue.DecimalPlaces = 1;
            this.capacityValue.Location = new System.Drawing.Point(195, 62);
            this.capacityValue.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.capacityValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capacityValue.Name = "capacityValue";
            this.capacityValue.ReadOnly = true;
            this.capacityValue.Size = new System.Drawing.Size(152, 22);
            this.capacityValue.TabIndex = 17;
            this.capacityValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bookableResourceFetchXML
            // 
            this.bookableResourceFetchXML.Controls.Add(this.bookableResourceFetchXMLValue);
            this.bookableResourceFetchXML.Location = new System.Drawing.Point(309, 84);
            this.bookableResourceFetchXML.Name = "bookableResourceFetchXML";
            this.bookableResourceFetchXML.Size = new System.Drawing.Size(569, 760);
            this.bookableResourceFetchXML.TabIndex = 20;
            this.bookableResourceFetchXML.TabStop = false;
            this.bookableResourceFetchXML.Text = "Bookable Resource FetchXML";
            // 
            // bookableResourceFetchXMLValue
            // 
            this.bookableResourceFetchXMLValue.Location = new System.Drawing.Point(20, 34);
            this.bookableResourceFetchXMLValue.Name = "bookableResourceFetchXMLValue";
            this.bookableResourceFetchXMLValue.Size = new System.Drawing.Size(527, 709);
            this.bookableResourceFetchXMLValue.TabIndex = 0;
            this.bookableResourceFetchXMLValue.Text = resources.GetString("bookableResourceFetchXMLValue.Text");
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.bookableResourceFetchXML);
            this.Controls.Add(this.Capacity);
            this.Controls.Add(this.clearWorkHours);
            this.Controls.Add(this.workDate);
            this.Controls.Add(this.varyByDayBox);
            this.Controls.Add(this.setWorkHours);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.workHours);
            this.Controls.Add(this.workDayBox);
            this.Controls.Add(this.getUsers);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1850, 873);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.workDayBox.ResumeLayout(false);
            this.workDayBox.PerformLayout();
            this.workHours.ResumeLayout(false);
            this.workHours.PerformLayout();
            this.varyByDayBox.ResumeLayout(false);
            this.varyByDayBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.workDate.ResumeLayout(false);
            this.workDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyXWeeks)).EndInit();
            this.Capacity.ResumeLayout(false);
            this.Capacity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityValue)).EndInit();
            this.bookableResourceFetchXML.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox userList;
        private System.Windows.Forms.Button getUsers;
        private System.Windows.Forms.GroupBox workDayBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.CheckBox sat;
        private System.Windows.Forms.CheckBox fri;
        private System.Windows.Forms.CheckBox thu;
        private System.Windows.Forms.CheckBox wed;
        private System.Windows.Forms.CheckBox tue;
        private System.Windows.Forms.CheckBox mon;
        private System.Windows.Forms.CheckBox sun;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.GroupBox workHours;
        private System.Windows.Forms.CheckBox selectAll;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Button setWorkHours;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.CheckBox noEndDate;
        private System.Windows.Forms.GroupBox varyByDayBox;
        private System.Windows.Forms.DateTimePicker vSunEndTimePicker;
        private System.Windows.Forms.Label vSunEndLabel;
        private System.Windows.Forms.Label vSunStartLabel;
        private System.Windows.Forms.DateTimePicker vSunStartTimePicker;
        private System.Windows.Forms.DateTimePicker vMonEndTimePicker;
        private System.Windows.Forms.Label vMonEndLabel;
        private System.Windows.Forms.Label vMonStartLabel;
        private System.Windows.Forms.DateTimePicker vMonStartTimePicker;
        private System.Windows.Forms.DateTimePicker vTueEndTimePicker;
        private System.Windows.Forms.Label vTueEndLabel;
        private System.Windows.Forms.Label vTueStartLabel;
        private System.Windows.Forms.DateTimePicker vTueStartTimePicker;
        private System.Windows.Forms.DateTimePicker vWedEndTimePicker;
        private System.Windows.Forms.Label vWedEndLabel;
        private System.Windows.Forms.Label vWedStartLabel;
        private System.Windows.Forms.DateTimePicker vWedStartTimePicker;
        private System.Windows.Forms.DateTimePicker vThuEndTimePicker;
        private System.Windows.Forms.Label vThuEndLabel;
        private System.Windows.Forms.Label vThuStartLabel;
        private System.Windows.Forms.DateTimePicker vThuStartTimePicker;
        private System.Windows.Forms.DateTimePicker vFriEndTimePicker;
        private System.Windows.Forms.Label vFriEndLabel;
        private System.Windows.Forms.Label vFriStartLabel;
        private System.Windows.Forms.DateTimePicker vFriStartTimePicker;
        private System.Windows.Forms.DateTimePicker vSatEndTimePicker;
        private System.Windows.Forms.CheckBox vSat;
        private System.Windows.Forms.Label vSatEndLabel;
        private System.Windows.Forms.CheckBox vFri;
        private System.Windows.Forms.Label vSatStartLabel;
        private System.Windows.Forms.DateTimePicker vSatStartTimePicker;
        private System.Windows.Forms.CheckBox vThu;
        private System.Windows.Forms.CheckBox vWed;
        private System.Windows.Forms.CheckBox vTue;
        private System.Windows.Forms.CheckBox vMon;
        private System.Windows.Forms.CheckBox vSun;
        private System.Windows.Forms.RadioButton varySchedule;
        private System.Windows.Forms.RadioButton sameSchedule;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox workDate;
        private System.Windows.Forms.Label everyXWeeksLabel;
        private System.Windows.Forms.NumericUpDown everyXWeeks;
        private System.Windows.Forms.Button clearWorkHours;
        private System.Windows.Forms.CheckBox noStartDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Capacity;
        private System.Windows.Forms.NumericUpDown capacityValue;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox calendarTypesBox;
        private System.Windows.Forms.Label timeZoneLabel;
        private System.Windows.Forms.ComboBox timeZonesBox;
        private System.Windows.Forms.GroupBox bookableResourceFetchXML;
        private System.Windows.Forms.RichTextBox bookableResourceFetchXMLValue;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
