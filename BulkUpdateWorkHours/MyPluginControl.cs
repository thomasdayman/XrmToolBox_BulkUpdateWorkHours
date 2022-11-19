using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using System.Web.UI.WebControls;
using Ical.Net.DataTypes;
using Microsoft.Crm.Sdk.Messages;
using System.Globalization;
using System.Xml.Linq;
using System.Xml;

namespace BulkUpdateWorkHours
{
    public partial class MyPluginControl : PluginControlBase
    {
        private List<WeekDay> WeekDays = new List<WeekDay>();
        private List<WeekDay> varyDays = new List<WeekDay>();
        private List<int> varyTimes = new List<int>();
        private List<DateTime> varyStartTimes = new List<DateTime>();
        private List<Guid> UserGuids = new List<Guid>();
        private RecurrencePattern RecurrenceRule = new RecurrencePattern();
        private List<IntervalWeekDays> intervalDays = new List<IntervalWeekDays>();
        private List<timeZone> timeZonesList = new List<timeZone>();
        private int Duration;
        //"FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,TU,WE,TH,FR"

        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }

            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }     

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        public class timeZone
        {
            public string Name { get; set; }
            public int Code { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class BookableResourceInfo
        {
            public string BookableName { get; internal set; }
            public Guid BookableGUID { get; internal set; }
            public Guid CalendarID { get; internal set; }
        }

        public class varyDay
        {
            public WeekDay Day { get; set; }
            public int Duration { get; set; }
        }

        public class IntervalWeekDays
        {
            public WeekDay Day { get; set; }
            public int Weeknumber { get; set; }
            public int ArrayNumber { get; set; }
        }

        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        private void getUsers_Click(object sender, EventArgs e)
        {
            if (Service != null)
            {
                clearUsers();
                retrieveUsers();
            }
            else
            {
                ExecuteMethod(WhoAmI);
            }
        }

        private void retrieveUsers()
        {
            try
            {
                string fetchxml;

                if (bookableResourceFetchXMLValue.Text != string.Empty)
                {
                    fetchxml = bookableResourceFetchXMLValue.Text;
                    XmlDocument formattedfetchxml = new XmlDocument();
                    formattedfetchxml.LoadXml(fetchxml);
                    XmlNodeList nodeList = formattedfetchxml.GetElementsByTagName("attribute");
                    XmlNodeList entityList = formattedfetchxml.GetElementsByTagName("entity");


                    bool att_bookablename = false;
                    bool att_bookableresourceid = false;
                    bool att_calendarid = false;
                    bool entity_bookableresource = false;

                    for (var i = 0; i < entityList.Count; i++)
                    {
                        var entityname = entityList[i].Attributes["name"].Value;
                        switch (entityname)
                        {
                            case "bookableresource":
                                entity_bookableresource = true;
                                break;
                            default:
                                entity_bookableresource = false;
                                break;
                        }
                    }

                    for (var i = 0; i < nodeList.Count; i++)
                    {
                        var attributename = nodeList[i].Attributes["name"].Value;
                        switch (attributename)
                        {
                            case "name":
                                att_bookablename = true;
                                break;
                            case "bookableresourceid":
                                att_bookableresourceid = true;
                                break;
                            case "calendarid":
                                att_calendarid = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (entity_bookableresource == false)
                    {
                        MessageBox.Show("The entity name must be 'bookableresource' within the FetchXML");
                        return;
                    }
                    if (att_bookablename == false)
                    {
                        MessageBox.Show("Please add " + "<attribute name = \"name\" /> " + "to the FetchXML query");
                        return;
                    }
                    if (att_bookableresourceid == false)
                    {
                        MessageBox.Show("Please add " + "<attribute name = \"bookableresourceid\" /> " + "to the FetchXML query");
                        return;
                    }
                    if (att_calendarid == false)
                    {
                        MessageBox.Show("Please add " + "<attribute name = \"calendarid\" /> " + "to the FetchXML query");
                        return;
                    }
                }
                else
                {
                    fetchxml = "<?xml version='1.0'?>" +
                               "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>" +
                               "<entity name='bookableresource'>" +
                               "<attribute name='name'/>" +
                               "<attribute name='createdon'/>" +
                               "<attribute name='resourcetype'/>" +
                               "<attribute name='bookableresourceid'/>" +
                               "<attribute name='calendarid'/>" +
                               "<order descending='false' attribute='name'/>" +
                               "</entity>" +
                               "</fetch>";

                    XDocument formattedfetchxml = XDocument.Parse(fetchxml);
                    bookableResourceFetchXMLValue.AppendText(formattedfetchxml.ToString());
                }
                EntityCollection result = Service.RetrieveMultiple(new FetchExpression(fetchxml));

                foreach (var c in result.Entities)
                {
                    var calendarid = ((EntityReference)c.Attributes["calendarid"]).Id;
                    var bookableresourceid = ((Guid)c.Attributes["bookableresourceid"]);
                    var bookablename = ((string)c.Attributes["name"]);
                    userList.Items.Add(new BookableResourceInfo { BookableName = bookablename, BookableGUID = bookableresourceid, CalendarID = calendarid });
                }

                if (userList.Items.Count == 0)
                {
                    MessageBox.Show("You have no Resources to choose from");
                }
                else
                {
                    getTimeZones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkDays()
        {
            WeekDays.Clear();
            if (mon.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Monday));
            }
            if (tue.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Tuesday));
            }
            if (wed.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Wednesday));
            }
            if (thu.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Thursday));
            }
            if (fri.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Friday));
            }
            if (sat.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Saturday));
            }
            if (sun.Checked == true)
            {
                WeekDays.Add(new WeekDay(DayOfWeek.Sunday));
            }
        }

        private void createPattern()
        {
            checkDays();
            RecurrencePattern(WeekDays);
        }

        private int GetSubCode(string CalendarType)
        {
            switch (CalendarType)
            {
                case "Working":
                    return 1;
                case "Non Working":
                    return 0;
                case "Time Off":
                    return 6;
                default:
                    return 1;
            }
        }

        private int GetTimeCode(string CalendarType)
        {
            switch (CalendarType)
            {
                case "Working":
                    return 0;
                case "Non Working":
                    return 2;
                case "Time Off":
                    return 2;
                default:
                    return 0;
            }
        }

        private void createVaryPattern(IOrganizationService organizationService, Guid userid, Guid calendarid)
        {
            ClearCalenderRules(Service, calendarid);

            if (vMon.Checked == true)
            {
                Double duration = vMonEndTimePicker.Value.Subtract(vMonStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Monday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vMonEndTimePicker.Value.Hour, vMonEndTimePicker.Value.Minute, vMonEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vMonStartTimePicker.Value.Hour, vMonStartTimePicker.Value.Minute, vMonStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vMonStartTimePicker.Value.Hour, vMonStartTimePicker.Value.Minute, vMonStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);
            }
            if (vTue.Checked == true)
            {
                Double duration = vTueEndTimePicker.Value.Subtract(vTueStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Tuesday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vTueEndTimePicker.Value.Hour, vTueEndTimePicker.Value.Minute, vTueEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vTueStartTimePicker.Value.Hour, vTueStartTimePicker.Value.Minute, vTueStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vTueStartTimePicker.Value.Hour, vTueStartTimePicker.Value.Minute, vTueStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);
            }
            if (vWed.Checked == true)
            {
                Double duration = vWedEndTimePicker.Value.Subtract(vWedStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Wednesday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vWedEndTimePicker.Value.Hour, vWedEndTimePicker.Value.Minute, vWedEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vWedStartTimePicker.Value.Hour, vWedStartTimePicker.Value.Minute, vWedStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vWedStartTimePicker.Value.Hour, vWedStartTimePicker.Value.Minute, vWedStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);
            }
            if (vThu.Checked == true)
            {
                Double duration = vThuEndTimePicker.Value.Subtract(vThuStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Thursday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vThuEndTimePicker.Value.Hour, vThuEndTimePicker.Value.Minute, vThuEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vThuStartTimePicker.Value.Hour, vThuStartTimePicker.Value.Minute, vThuStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vThuStartTimePicker.Value.Hour, vThuStartTimePicker.Value.Minute, vThuStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);
            }
            if (vFri.Checked == true)
            {
                Double duration = vFriEndTimePicker.Value.Subtract(vFriStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Friday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vFriEndTimePicker.Value.Hour, vFriEndTimePicker.Value.Minute, vFriEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vFriStartTimePicker.Value.Hour, vFriStartTimePicker.Value.Minute, vFriStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vFriStartTimePicker.Value.Hour, vFriStartTimePicker.Value.Minute, vFriStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);
            }
            if (vSat.Checked == true)
            {
                Double duration = vSatEndTimePicker.Value.Subtract(vSatStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Saturday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vSatEndTimePicker.Value.Hour, vSatEndTimePicker.Value.Minute, vSatEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vSatStartTimePicker.Value.Hour, vSatStartTimePicker.Value.Minute, vSatStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vSatStartTimePicker.Value.Hour, vSatStartTimePicker.Value.Minute, vSatStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);
            }
            if (vSun.Checked == true)
            {
                Double duration = vSunEndTimePicker.Value.Subtract(vSunStartTimePicker.Value).TotalMinutes;
                varyDays.Add(new WeekDay(DayOfWeek.Sunday));
                varyTimes.Add((new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, vSunEndTimePicker.Value.Hour, vSunEndTimePicker.Value.Minute, vSunEndTimePicker.Value.Second, DateTimeKind.Utc) - new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vSunStartTimePicker.Value.Hour, vSunStartTimePicker.Value.Minute, vSunStartTimePicker.Value.Second, DateTimeKind.Utc)).Days);
                varyStartTimes.Add(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, vSunStartTimePicker.Value.Hour, vSunStartTimePicker.Value.Minute, vSunStartTimePicker.Value.Second, DateTimeKind.Utc));

                RecurrencePattern(varyDays);
                AddCalenderRules(organizationService, userid, varyDays, varyStartTimes, duration);               
            }
        }
       
        private void RecurrencePattern(List<WeekDay> workDays)
        {
            //No End Date
            if (noEndDate.Checked == true)
            {
                RecurrenceRule = new RecurrencePattern(Ical.Net.FrequencyType.Weekly)
                {
                    Frequency = Ical.Net.FrequencyType.Weekly,
                    Interval = Convert.ToInt32(everyXWeeks.Value) + 1,
                    ByDay = workDays
                };
            }
            //Has an End Date and has no XWeeks
            else if (noEndDate.Checked == false && Convert.ToInt32(everyXWeeks.Value) == 0)
            {
                RecurrenceRule = new RecurrencePattern(Ical.Net.FrequencyType.Weekly)
                {
                    Frequency = Ical.Net.FrequencyType.Weekly,
                    Interval = Convert.ToInt32(everyXWeeks.Value) + 1,
                    ByDay = workDays,
                    Count = GetNumberOfWorkingDays(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, startTimePicker.Value.Hour, startTimePicker.Value.Minute, startTimePicker.Value.Second, DateTimeKind.Utc), new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, endTimePicker.Value.Hour, endTimePicker.Value.Minute, endTimePicker.Value.Second, DateTimeKind.Utc), workDays)
                };
            }
            //Has an End Date and has XWeeks
            else if (noEndDate.Checked == false && Convert.ToInt32(everyXWeeks.Value) > 0)
            {                
                RecurrenceRule = new RecurrencePattern(Ical.Net.FrequencyType.Weekly)
                {
                    Frequency = Ical.Net.FrequencyType.Weekly,
                    Interval = Convert.ToInt32(everyXWeeks.Value) + 1,
                    ByDay = workDays,
                    Count = GetNumberOfIntervalWorkingDays(new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, startTimePicker.Value.Hour, startTimePicker.Value.Minute, startTimePicker.Value.Second, DateTimeKind.Utc), new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, endTimePicker.Value.Hour, endTimePicker.Value.Minute, endTimePicker.Value.Second, DateTimeKind.Utc), workDays, everyXWeeks)
                };
            }
        }

        private int GetNumberOfWorkingDays(DateTime start, DateTime stop, List<WeekDay> listOfDays)
        {
            int days = 0;
            while (start <= stop)
            {
                for (var i = 0; i < listOfDays.Count; i++)
                {
                    if (start.DayOfWeek.ToString() == listOfDays.ElementAt(i).DayOfWeek.ToString())
                    {
                        ++days;
                    }
                }
                start = start.AddDays(1);
            }
            return days;
        }

        private int GetNumberOfIntervalWorkingDays(DateTime start, DateTime stop, List<WeekDay> listOfDays, NumericUpDown Xweeks)
        {
            List<int> withDupes = new List<int>();
            List<int> KeepWeeks = new List<int>();
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            System.Globalization.Calendar cal = dfi.Calendar;
            var currentArray = 1;

            //Add the days into a list
            int days = 0;
            while (start <= stop)
            {
                for (var i = 0; i < listOfDays.Count; i++)
                {
                    if (start.DayOfWeek.ToString() == listOfDays.ElementAt(i).DayOfWeek.ToString())
                    {                       
                        intervalDays.Add(new IntervalWeekDays { Weeknumber = cal.GetWeekOfYear(start, dfi.CalendarWeekRule, dfi.FirstDayOfWeek),
                            Day = listOfDays.ElementAt(i),
                            ArrayNumber = 1 });
                        //MessageBox.Show("Start " + start + " Days " + listOfDays.ElementAt(i).DayOfWeek + " Week " + cal.GetWeekOfYear(start, dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
                        ++days;
                    }
                }
                start = start.AddDays(1);
            }
            //Assign the interval days arraynumber if the weeknumber is different from each other
            for (var i = 1; i < intervalDays.Count; i++)
            {
                if (intervalDays[i-1].Weeknumber == intervalDays[i].Weeknumber)
                {
                    intervalDays[i].ArrayNumber = currentArray;
                }
                else if (intervalDays[i-1].Weeknumber != intervalDays[i].Weeknumber)
                {
                    intervalDays[i].ArrayNumber = currentArray+1;
                    currentArray++;
                }
                //MessageBox.Show("Days " + intervalDays[i].Day.DayOfWeek + " Week " + intervalDays[i].Weeknumber + " Array " + intervalDays[i].ArrayNumber);
                withDupes.Add(intervalDays[i-1].ArrayNumber);
            }

            //Get distinct list of arraynumbers
            List<int> noDupes = withDupes.Distinct().ToList();
            withDupes.Clear();

            //Add numbers which are every 'Xweeks'
            for (int i = 0; i < noDupes.Count; i += Convert.ToInt32(Xweeks.Value) + 1)
            {
                //MessageBox.Show("KeepWeeks " + noDupes[i].ToString());
                KeepWeeks.Add(noDupes[i]);
            }
            noDupes.Clear();

            //Removes days which does not contain any numbers in the SkipNumbers list
            for (var i = 0; i < intervalDays.Count; i++)
            {
                //MessageBox.Show("Week " + intervalDays[i].Weeknumber.ToString() + " Day " + intervalDays[i].Day.DayOfWeek + " Array " + intervalDays[i].ArrayNumber.ToString());
                if (!KeepWeeks.Contains(intervalDays[i].ArrayNumber))
                {
                    //MessageBox.Show("Remove---" + " Week " + intervalDays[i].Weeknumber.ToString() + " Day " + intervalDays[i].Day.DayOfWeek + " Array " + intervalDays[i].ArrayNumber.ToString());
                    days--;
                }
            }
            KeepWeeks.Clear();
            intervalDays.Clear();
            return days;
        }
        private int GetOffset(DateTime StartDate, DateTime EndDate)
        {
            TimeSpan ts = EndDate - StartDate;
            return Convert.ToInt32(ts.TotalMinutes);
        }

        private void clearUsers()
        {
            userList.Items.Clear();
        }

        public void AddCalenderRules(IOrganizationService organizationService, Guid userid, List<WeekDay> varyDays, List<DateTime> varyStartTimes, Double varyDuration)
        {
            /*
             * Codes
             *
             *  Working
             *  calendarRule1.Attributes["subcode"] = 1;
             *  calendarRule1.Attributes["timecode"] = 0;
             *  
             *  Non Working            *  
             *  calendarRule1.Attributes["subcode"] = 0;
             *  calendarRule1.Attributes["timecode"] = 2;
             *  
             *  Time off
             *  calendarRule1.Attributes["subcode"] = 6;
             *  calendarRule1.Attributes["timecode"] = 2;
             *  
             */

            if (userid != Guid.Empty)
            {

                Entity systemUserEntity = organizationService.Retrieve("bookableresource", userid, new ColumnSet(new String[] { "calendarid" }));
                Entity userCalendarEntity = organizationService.Retrieve("calendar", ((EntityReference)(systemUserEntity.Attributes["calendarid"])).Id, new ColumnSet(true));
                EntityCollection calendarRules = (EntityCollection)userCalendarEntity.Attributes["calendarrules"];

                if (sameSchedule.Checked == true)
                {
                    Double duration = endTimePicker.Value.Subtract(startTimePicker.Value).TotalMinutes;

                    Entity newInnerCalendar = new Entity("calendar");
                    newInnerCalendar.Attributes["businessunitid"] = new EntityReference("businessunit", ((EntityReference)(userCalendarEntity["businessunitid"])).Id);
                    newInnerCalendar.Attributes["type"] = new OptionSetValue(-1);
                    Guid innerCalendarId = organizationService.Create(newInnerCalendar);

                    //Create a new calendar rule and assign the inner calendar id to it
                    Entity calendarRule = new Entity("calendarrule");
                    calendarRule.Attributes["duration"] = 1440;
                    calendarRule.Attributes["extentcode"] = 1;
                    //Create a pattern of Mon-Fri
                    calendarRule.Attributes["pattern"] = RecurrenceRule.ToString();
                    calendarRule.Attributes["rank"] = 0;
                    //85 = UK Time Code
                    calendarRule.Attributes["timezonecode"] = ((timeZone)timeZonesBox.SelectedItem).Code; //RetrieveCurrentUsersSettings();
                    calendarRule.Attributes["innercalendarid"] = new EntityReference("calendar", innerCalendarId);
                    //Starting at 12:00 on 1 January 2018
                    calendarRule.Attributes["starttime"] = new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, startTimePicker.Value.Hour, startTimePicker.Value.Minute, startTimePicker.Value.Second, DateTimeKind.Utc);
                    calendarRules.Entities.Add(calendarRule);

                    //Assign all the calendar rule back to the user calendar
                    userCalendarEntity.Attributes["calendarrules"] = calendarRules;
                    //Please refer to here for Calander Types https://msdn.microsoft.com/en-us/library/dn689038.aspx
                    userCalendarEntity.Attributes["type"] = new OptionSetValue(0);
                    organizationService.Update(userCalendarEntity);

                    //Creates a new Calendar Rule 
                    Entity calendarRule1 = new Entity("calendarrule");
                    //Duration of 9 hours (540 mins)
                    calendarRule1.Attributes["duration"] = duration;
                    calendarRule1.Attributes["effort"] = Convert.ToDouble(capacityValue.Value); //1.0
                    calendarRule1.Attributes["issimple"] = true;
                    //Offset of 8 hours (480 mins) - Start Time is 8am
                    calendarRule1.Attributes["offset"] = 0;
                    calendarRule1.Attributes["rank"] = 0;
                    calendarRule1.Attributes["subcode"] = GetSubCode(Convert.ToString(calendarTypesBox.SelectedItem)); //1
                    calendarRule1.Attributes["timecode"] = GetTimeCode(Convert.ToString(calendarTypesBox.SelectedItem)); //0
                    calendarRule1.Attributes["timezonecode"] = ((timeZone)timeZonesBox.SelectedItem).Code; //RetrieveCurrentUsersSettings();
                    calendarRule1.Attributes["calendarid"] = new EntityReference("calendar", innerCalendarId);

                    EntityCollection innerCalendarRules = new EntityCollection();
                    innerCalendarRules.EntityName = "calendarrule";
                    innerCalendarRules.Entities.Add(calendarRule1);

                    newInnerCalendar.Attributes["calendarrules"] = innerCalendarRules;
                    newInnerCalendar.Attributes["calendarid"] = innerCalendarId;
                    organizationService.Update(newInnerCalendar);

                }

                else if (varySchedule.Checked == true)
                {

                    Entity newInnerCalendar = new Entity("calendar");
                    newInnerCalendar.Attributes["businessunitid"] = new EntityReference("businessunit", ((EntityReference)(userCalendarEntity["businessunitid"])).Id);
                    newInnerCalendar.Attributes["type"] = new OptionSetValue(-1);
                    Guid innerCalendarId = organizationService.Create(newInnerCalendar);

                    //Create a new calendar rule and assign the inner calendar id to it
                    Entity calendarRule = new Entity("calendarrule");
                    calendarRule.Attributes["duration"] = 1440;
                    calendarRule.Attributes["extentcode"] = 1;
                    //Create a pattern of Mon-Fri
                    calendarRule.Attributes["pattern"] = RecurrenceRule.ToString();
                    calendarRule.Attributes["rank"] = 0;
                    //85 = UK Time Code
                    calendarRule.Attributes["timezonecode"] = ((timeZone)timeZonesBox.SelectedItem).Code; //RetrieveCurrentUsersSettings();
                    calendarRule.Attributes["innercalendarid"] = new EntityReference("calendar", innerCalendarId);
                    //Starting at 12:00 on 1 January 2018
                    calendarRule.Attributes["starttime"] = new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, varyStartTimes[0].Hour, varyStartTimes[0].Minute, varyStartTimes[0].Second, DateTimeKind.Utc);
                    calendarRules.Entities.Add(calendarRule);

                    //Assign all the calendar rule back to the user calendar
                    userCalendarEntity.Attributes["calendarrules"] = calendarRules;
                    //Please refer to here for Calander Types https://msdn.microsoft.com/en-us/library/dn689038.aspx
                    userCalendarEntity.Attributes["type"] = new OptionSetValue(0);
                    organizationService.Update(userCalendarEntity);

                    //Creates a new Calendar Rule 
                    Entity calendarRule1 = new Entity("calendarrule");
                    //Duration of 9 hours (540 mins)
                    calendarRule1.Attributes["duration"] = varyDuration;
                    calendarRule1.Attributes["effort"] = Convert.ToDouble(capacityValue.Value);
                    calendarRule1.Attributes["issimple"] = true;
                    //Offset of 8 hours (480 mins) - Start Time is 8am
                    calendarRule1.Attributes["offset"] = 0;
                    calendarRule1.Attributes["rank"] = 0;
                    calendarRule1.Attributes["subcode"] = GetSubCode(Convert.ToString(calendarTypesBox.SelectedItem)); //1
                    calendarRule1.Attributes["timecode"] = GetTimeCode(Convert.ToString(calendarTypesBox.SelectedItem)); //0
                    calendarRule1.Attributes["timezonecode"] = ((timeZone)timeZonesBox.SelectedItem).Code; //RetrieveCurrentUsersSettings();
                    calendarRule1.Attributes["calendarid"] = new EntityReference("calendar", innerCalendarId);

                    EntityCollection innerCalendarRules = new EntityCollection();
                    innerCalendarRules.EntityName = "calendarrule";
                    innerCalendarRules.Entities.Add(calendarRule1);

                    newInnerCalendar.Attributes["calendarrules"] = innerCalendarRules;
                    newInnerCalendar.Attributes["calendarid"] = innerCalendarId;
                    organizationService.Update(newInnerCalendar);

                    varyDays.Clear();
                    varyTimes.Clear();
                    varyStartTimes.Clear();
                }
            }
        }

        private void ClearCalenderRules(IOrganizationService organizationService, Guid calendarId)
        {
            if (calendarId != null)
            {
                //Retrieves all CalanderId's for all the users
                string fetchxml = "<?xml version='1.0'?>" +
                                "<fetch distinct='true' mapping='logical' output-format='xml-platform' version='1.0'>" +
                                "<entity name='calendar' >" +
                                "    <attribute name='calendarid' />" +
                                "    <filter type='and' >" +
                                //Primary User Id is not always popualted and is causes orphans when clearing rules (Use Calendar Id instead)
                                "        <condition attribute = 'calendarid' operator= 'eq' value='" + calendarId + "' /> " +
                                //"      <condition attribute='primaryuserid' operator='eq' value='" + userId + "' />" +
                                "    </filter>" +
                                "  </entity>" +
                                "</fetch>";

                EntityCollection result = organizationService.RetrieveMultiple(new FetchExpression(fetchxml));

                Console.WriteLine("There are {0} entities found", result.Entities.Count);

                foreach (var c in result.Entities)
                {
                    Entity Calendar = organizationService.Retrieve("calendar", ((Guid)c.Attributes["calendarid"]), new ColumnSet(true));
                    EntityCollection calendarRules = (EntityCollection)Calendar.Attributes["calendarrules"];

                    int num = 0;
                    List<int> list = new List<int>();
                    foreach (Entity current in calendarRules.Entities)
                    {
                        //Only delete work hours after the selected start date
                        if (noStartDate.Checked == false && noEndDate.Checked == true)
                        {
                            DateTime myStartTime = Convert.ToDateTime(current["starttime"]);

                            var startDate = (new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, 0, 0, 0));
                            var endDate = (new DateTime(2999, 12, 12, 23, 59, 59));

                            if (myStartTime >= startDate && myStartTime <= endDate) //(startDate >= endDate)
                            {
                                list.Add(num);
                            }

                            num++;
                        }
                        //Only delete work hours between the start and end date
                        else if (noStartDate.Checked == false && noEndDate.Checked == false)
                        {
                            DateTime myStartTime = Convert.ToDateTime(current["starttime"]);
                            var startDate = (new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day, 0, 0, 0));
                            var endDate = (new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day, 23, 59, 59));


                            if (myStartTime >= startDate && myStartTime <= endDate) //(startDate >= endDate)
                            {
                                list.Add(num);
                            }

                            num++;
                        }
                        //Only delete all work hours
                        else if (noStartDate.Checked == true && noEndDate.Checked == true)
                        {

                            list.Add(num);
                            num++;
                        }
                    }

                    list.Sort();
                    list.Reverse();

                    for (int i = 0; i < list.Count; i++)
                    {
                        //Remove all Calander Rules from Collection
                        calendarRules.Entities.Remove(calendarRules.Entities[list[i]]);
                    }

                    //Assign Calander Rules to empty Entity Collection
                    Calendar.Attributes["calendarrules"] = calendarRules;
                    organizationService.Update(Calendar);
                }
            }
        }

        private void clearWorkHours_Click(object sender, EventArgs e)
        {
            if (userList.CheckedItems.Count != 0)
            {
                if (sameSchedule.Checked == true)
                {
                    if (startDatePicker.Value <= endDatePicker.Value || noEndDate.Checked == true)
                    {
                        if (startTimePicker.Value <= endTimePicker.Value)
                        {
                            checkDays();
                            if (WeekDays.Count != 0)
                            {
                                WorkAsync(new WorkAsyncInfo
                                {
                                    Message = "Clearing Work Hours...",
                                    Work = (w, z) =>
                                    {
                                        foreach (object item in userList.CheckedItems.OfType<BookableResourceInfo>())
                                        {
                                            var bookinfo = (BookableResourceInfo)item;

                                            ClearCalenderRules(Service, bookinfo.CalendarID);
                                        }
                                    },
                                });
                            }
                            else
                            {
                                MessageBox.Show("You have not selected any days");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Start Time should not be greater than the End Time");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Start Date should not be greater than the End Date");
                    }
                }
                else
                {
                    MessageBox.Show("The Start Date should not be greater than the End Date");
                }
            }
            else
            {
                MessageBox.Show("You have not selected any Resources to clear Work Hours");
            }            
        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll.Checked == false)
            {
                for (int i = 0; i < userList.Items.Count; i++)
                {
                    userList.SetItemChecked(i, false);
                }
            }
            else
            {
                for (int i = 0; i < userList.Items.Count; i++)
                {
                    userList.SetItemChecked(i, true);
                }
            }
        }

        public int RetrieveCurrentUsersSettings()
        {
            var currentUserSettings = Service.RetrieveMultiple(
                new QueryExpression("usersettings")
                {
                    ColumnSet = new ColumnSet("localeid", "timezonecode"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("systemuserid", ConditionOperator.EqualUserId)
                        }
                    }
                }).Entities[0].ToEntity<Entity>();

            return (int)currentUserSettings.Attributes["timezonecode"];       
        }

        public List<timeZone> getTimeZones()
        {
            timeZonesBox.Items.Clear();

            string fetchxml = "<fetch>" +
                "  <entity name='timezonedefinition' >" +
                "    <attribute name='userinterfacename' />" +
                "    <attribute name='timezonecode' />" +
                "    <order attribute='timezonecode' />" +
                "  </entity>" +
                "</fetch>";

            EntityCollection result = Service.RetrieveMultiple(new FetchExpression(fetchxml));

            foreach (var c in result.Entities)
            {
                var name = (string)c.Attributes["userinterfacename"];
                var code = (int)c.Attributes["timezonecode"];
                //timeZonesList.Add(new timeZone { Name = name, Code = code });
                timeZonesBox.Items.Add(new timeZone { Name = name, Code = code });
                timeZonesBox.DisplayMember = Name;
            }
            timeZonesBox.ResetText();

            return timeZonesList;
        }

        private void setWorkHours_Click(object sender, EventArgs e)
        {
            if (userList.CheckedItems.Count != 0)
            { 
                if (calendarTypesBox.SelectedItem != null)
                {
                    if (timeZonesBox.SelectedItem != null)
                    {
                        if (sameSchedule.Checked == true)
                        {
                            if (startDatePicker.Value <= endDatePicker.Value || noEndDate.Checked == true)
                            {
                                if (startTimePicker.Value <= endTimePicker.Value)
                                {
                                    createPattern();
                                    if (WeekDays.Count != 0)
                                    {
                                        WorkAsync(new WorkAsyncInfo
                                        {
                                            Message = "Updating Work Hours...",
                                            Work = (w, z) =>
                                            {
                                                foreach (object item in userList.CheckedItems.OfType<BookableResourceInfo>())
                                                {
                                                    var bookinfo = (BookableResourceInfo)item;

                                                    ClearCalenderRules(Service, bookinfo.CalendarID);
                                                    AddCalenderRules(Service, bookinfo.BookableGUID, varyDays, varyStartTimes, Duration);
                                                }
                                            },
                                        });
                                    }
                                    else
                                    {
                                        MessageBox.Show("You have not selected any days");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The Start Time should not be greater than the End Time");
                                }
                            }
                            else
                            {
                                MessageBox.Show("The Start Date should not be greater than the End Date");
                            }
                        }
                        else if (varySchedule.Checked == true)
                        {
                            if (startDatePicker.Value <= endDatePicker.Value || noEndDate.Checked == true)
                            {
                                /*
                                if (startTimePicker.Value <= endTimePicker.Value)
                                {
                                */
                                if (vMon.Checked == false && vTue.Checked == false && vWed.Checked == false && vThu.Checked == false
                                    && vFri.Checked == false && vSat.Checked == false && vSun.Checked == false)
                                {
                                    MessageBox.Show("You have not selected any days");
                                }
                                else
                                {
                                    WorkAsync(new WorkAsyncInfo
                                    {
                                        Message = "Updating Work Hours...",
                                        Work = (w, z) =>
                                        {
                                            foreach (object item in userList.CheckedItems.OfType<BookableResourceInfo>())
                                            {
                                                var bookinfo = (BookableResourceInfo)item;
                                                createVaryPattern(Service, bookinfo.BookableGUID, bookinfo.CalendarID);
                                            }
                                        },
                                    });
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Start Date should not be greater than the End Date");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have not selected a TimeZone");
                    }
                }
                else
                {
                    MessageBox.Show("You have not selected a Calendar Type");
                }
            }
            else
            {
                MessageBox.Show("You have not selected any Resources to update Work Hours");
            }
        }

        private void noEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (noEndDate.Checked == true)
            {
                endDatePicker.Visible = false;
                endDateLabel.Visible = false;
                //everyXWeeksLabel.Visible = true;
                //everyXWeeks.Visible = true;
                //everyXWeeks.Value= 0;
            }
            else if (noEndDate.Checked == false)
            {
                endDatePicker.Visible = true;
                endDateLabel.Visible = true;
                //everyXWeeksLabel.Visible = false;
                //everyXWeeks.Visible = false;
                everyXWeeks.Value = 0;
            }
        }

        private void sameSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (sameSchedule.Checked == true)
            {
                varySchedule.Checked = false;
                varyByDayBox.Visible = false;
                workDayBox.Visible = true;
                workHours.Visible = true;
            }
        }

        private void varySchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (varySchedule.Checked == true)
            {
                sameSchedule.Checked = false;
                varyByDayBox.Visible = true;
                workDayBox.Visible = false;
                workHours.Visible = false;
            }
        }

        private void vSun_CheckedChanged(object sender, EventArgs e)
        {
            if (vSun.Checked == true)
            {
                vSunStartLabel.Visible = true;
                vSunEndLabel.Visible = true;
                vSunStartTimePicker.Visible = true;
                vSunEndTimePicker.Visible = true;
            }
            else
            {
                vSunStartLabel.Visible = false;
                vSunEndLabel.Visible = false;
                vSunStartTimePicker.Visible = false;
                vSunEndTimePicker.Visible = false;
            }
        }

        private void vMon_CheckedChanged(object sender, EventArgs e)
        {
            if (vMon.Checked == true)
            {
                vMonStartLabel.Visible = true;
                vMonEndLabel.Visible = true;
                vMonStartTimePicker.Visible = true;
                vMonEndTimePicker.Visible = true;
            }
            else
            {
                vMonStartLabel.Visible = false;
                vMonEndLabel.Visible = false;
                vMonStartTimePicker.Visible = false;
                vMonEndTimePicker.Visible = false;
            }
        }

        private void vTue_CheckedChanged(object sender, EventArgs e)
        {
            if (vTue.Checked == true)
            {
                vTueStartLabel.Visible = true;
                vTueEndLabel.Visible = true;
                vTueStartTimePicker.Visible = true;
                vTueEndTimePicker.Visible = true;
            }
            else
            {
                vTueStartLabel.Visible = false;
                vTueEndLabel.Visible = false;
                vTueStartTimePicker.Visible = false;
                vTueEndTimePicker.Visible = false;
            }
        }

        private void vWed_CheckedChanged(object sender, EventArgs e)
        {
            if (vWed.Checked == true)
            {
                vWedStartLabel.Visible = true;
                vWedEndLabel.Visible = true;
                vWedStartTimePicker.Visible = true;
                vWedEndTimePicker.Visible = true;
            }
            else
            {
                vWedStartLabel.Visible = false;
                vWedEndLabel.Visible = false;
                vWedStartTimePicker.Visible = false;
                vWedEndTimePicker.Visible = false;
            }
        }

        private void vThu_CheckedChanged(object sender, EventArgs e)
        {
            if (vThu.Checked == true)
            {
                vThuStartLabel.Visible = true;
                vThuEndLabel.Visible = true;
                vThuStartTimePicker.Visible = true;
                vThuEndTimePicker.Visible = true;
            }
            else
            {
                vThuStartLabel.Visible = false;
                vThuEndLabel.Visible = false;
                vThuStartTimePicker.Visible = false;
                vThuEndTimePicker.Visible = false;
            }
        }

        private void vFri_CheckedChanged(object sender, EventArgs e)
        {
            if (vFri.Checked == true)
            {
                vFriStartLabel.Visible = true;
                vFriEndLabel.Visible = true;
                vFriStartTimePicker.Visible = true;
                vFriEndTimePicker.Visible = true;
            }
            else
            {
                vFriStartLabel.Visible = false;
                vFriEndLabel.Visible = false;
                vFriStartTimePicker.Visible = false;
                vFriEndTimePicker.Visible = false;
            }
        }

        private void vSat_CheckedChanged(object sender, EventArgs e)
        {
            if (vSat.Checked == true)
            {
                vSatStartLabel.Visible = true;
                vSatEndLabel.Visible = true;
                vSatStartTimePicker.Visible = true;
                vSatEndTimePicker.Visible = true;
            }
            else
            {
                vSatStartLabel.Visible = false;
                vSatEndLabel.Visible = false;
                vSatStartTimePicker.Visible = false;
                vSatEndTimePicker.Visible = false;
            }
        }

        private void calendarTypesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (calendarTypesBox.SelectedItem.ToString())
            {
                case "Working":
                    capacityLabel.Visible = true;
                    capacityValue.Visible = true;
                    break;
                case "Non Working":
                    capacityLabel.Visible = false;
                    capacityValue.Visible = false;
                    capacityValue.Value = 1;
                    break;
                case "Time Off":
                    capacityLabel.Visible = false;
                    capacityValue.Visible = false;
                    capacityValue.Value = 1;
                    break;
            }
        }
    }
}
