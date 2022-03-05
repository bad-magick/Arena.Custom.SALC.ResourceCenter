using System;
using System.Data.SqlClient;
using Arena.Core;
using Arena.Custom.SALC.ResourceCenter.DataLayer;

namespace Arena.Custom.SALC.ResourceCenter.Entity
{
	[Serializable]
	public class ResourceCenterPerson : ArenaObjectBase
	{
		#region Private Members

		private int _Id = -1;
        //private Person _person = null;
        private int _personId = -1;
        private int _numAdults = 0;
        private int _numChildren = 0;
        private string _county = string.Empty;
        private int _helpRequested = 0;
        private string _notes = string.Empty;
        private DateTime _dateCreated = DateTime.MinValue;
        private DateTime _dateUpdated = DateTime.MinValue;
        private string _createdBy = string.Empty;
        private string _updatedBy = string.Empty;

        private string _nickName = string.Empty;
        private string _firstName = string.Empty;
        private string _middleName = string.Empty;
        private string _lastName = string.Empty;
        private string _suffix = string.Empty;
        private DateTime _birthday = DateTime.MinValue;
        private string _gender = "U";
        private string _email = string.Empty;
        private string _streetAddress = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _postalCode = string.Empty;
        private string _ssn = string.Empty;

        private string _schoolDistrict = string.Empty;
        private decimal _incomeEmployment = 0;
        private decimal _incomeMFIP = 0;
        private decimal _incomeMA = 0;
        private decimal _incomeChildSupport = 0;
        private decimal _incomeUnemployment = 0;
        private decimal _incomeSSISSDI = 0;
        private decimal _incomeOther = 0;
        private decimal _cashOnHand = 0;
        private int _issuesOfNote = 0;
        private DateTime _lastDateWorked = DateTime.MinValue;

        private int _mstatus = 0;
        private int _dlicense = 0;
        private int _ebt = 0;
        private decimal _foodSupport = 0;
        private DateTime _assistanceApplied = DateTime.MinValue;
        private string _foodShelf = string.Empty;
        private DateTime _foodShelfVisit = DateTime.MinValue;
        private string _casemgr1Name = string.Empty;
        private string _casemgr1Agency = string.Empty;
        private string _casemgr1Phone = string.Empty;
        private string _casemgr1notes = string.Empty;
        private string _casemgr2Name = string.Empty;
        private string _casemgr2Agency = string.Empty;
        private string _casemgr2Phone = string.Empty;
        private string _casemgr2notes = string.Empty;
        private string _emgassist1Angency = string.Empty;
        private string _emgassist1Casemgr = string.Empty;
        private string _emgassist1Phone = string.Empty;
        private DateTime _emgassist1Date = DateTime.MinValue;
        private decimal _emgassist1Amount = 0;
        private int _emgassist1Status = 0;
        private string _emgassist2Angency = string.Empty;
        private string _emgassist2Casemgr = string.Empty;
        private string _emgassist2Phone = string.Empty;
        private DateTime _emgassist2Date = DateTime.MinValue;
        private decimal _emgassist2Amount = 0;
        private int _emgassist2Status = 0;
        private int _pastShelter = 0;
        private DateTime _pastShelterDate = DateTime.MinValue;
        private int _pastUnsheltered = 0;
        private DateTime _pastUnshelteredDate = DateTime.MinValue;
        private int _pastChemical = 0;
        private DateTime _pastChemicalDate = DateTime.MinValue;
        private int _pastTransitional = 0;
        private DateTime _pastTransitionalDate = DateTime.MinValue;
        private int _pastDoubled = 0;
        private DateTime _pastDoubledDate = DateTime.MinValue;
        private int _pastEviction = 0;
        private DateTime _pastEvictionDate = DateTime.MinValue;
        private int _pastForeclosure = 0;
        private DateTime _pastForeclosureDate = DateTime.MinValue;
        private string _phoneHome = string.Empty;
        private string _phoneWork = string.Empty;
        private string _phoneMobile = string.Empty;
        private string _phoneOther = string.Empty;
        private int _empFreq = 7;
        private DateTime _empDate = DateTime.MinValue;
        private int _mfipDay = 1;
        private DateTime _childsupportDate = DateTime.MinValue;
        private DateTime _otherincomeDate = DateTime.MinValue;
        private string _message = string.Empty;
        private int _flag = 0;

        private DateTime _lastShelter = DateTime.MinValue;
        private DateTime _lastShelterExit = DateTime.MinValue;

		#endregion

		#region Public Properties

		public int Id
		{
			get { return _Id; }
			//set { _Id = value; }
		}

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

        /*public Person Person
        {
            get { if (_person == null) { _person = new Person(_personId); } return _person; }
            set { _personId = value.PersonID; _person = null; }
        }*/

        public int NumAdults
        {
            get { return _numAdults; }
            set { _numAdults = value; }
        }

        public int NumChildren
        {
            get { return _numChildren; }
            set { _numChildren = value; }
        }

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }


        public int HelpRequested
        {
            get { return _helpRequested; }
            set { _helpRequested = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
        }

        public string SchoolDistrict
        {
            get { return _schoolDistrict; }
            set { _schoolDistrict = value; }
        }

        public decimal IncomeEmployment
        {
            get { return _incomeEmployment; }
            set { _incomeEmployment = value; }
        }

        public decimal IncomeMFIP
        {
            get { return _incomeMFIP; }
            set { _incomeMFIP = value; }
        }

        public decimal IncomeMA
        {
            get { return _incomeMA; }
            set { _incomeMA = value; }
        }

        public decimal IncomeChildSupport
        {
            get { return _incomeChildSupport; }
            set { _incomeChildSupport = value; }
        }

        public decimal IncomeUnemployment
        {
            get { return _incomeUnemployment; }
            set { _incomeUnemployment = value; }
        }

        public decimal IncomeSSISSDI
        {
            get { return _incomeSSISSDI; }
            set { _incomeSSISSDI = value; }
        }

        public decimal IncomeOther
        {
            get { return _incomeOther; }
            set { _incomeOther = value; }
        }

        public decimal CashOnHand
        {
            get { return _cashOnHand; }
            set { _cashOnHand = value; }
        }

        public int IssuesOfNote
        {
            get { return _issuesOfNote; }
            set { _issuesOfNote = value; }
        }

        public DateTime LastDateWorked
        {
            get { return _lastDateWorked; }
            set { _lastDateWorked = value; }
        }

        public int MaritalStatus
        {
            get { return _mstatus; }
            set { _mstatus = value; }
        }

        public int DriversLicense
        {
            get { return _dlicense; }
            set { _dlicense = value; }
        }

        public int EBT
        {
            get { return _ebt; }
            set { _ebt = value; }
        }

        public decimal FoodSupport
        {
            get { return _foodSupport; }
            set { _foodSupport = value; }
        }

        public DateTime AssistanceApplied
        {
            get { return _assistanceApplied; }
            set { _assistanceApplied = value; }
        }

        public string FoodShelf
        {
            get { return _foodShelf; }
            set { _foodShelf = value; }
        }

        public DateTime FoodShelfVisit
        {
            get { return _foodShelfVisit; }
            set { _foodShelfVisit = value; }
        }

        public string CaseMgr1Name
        {
            get { return _casemgr1Name; }
            set { _casemgr1Name = value; }
        }

        public string CaseMgr1Agency
        {
            get { return _casemgr1Agency; }
            set { _casemgr1Agency = value; }
        }

        public string CaseMgr1Phone
        {
            get { return _casemgr1Phone; }
            set { _casemgr1Phone = value; }
        }

        public string CaseMgr1Notes
        {
            get { return _casemgr1notes; }
            set { _casemgr1notes = value; }
        }

        public string CaseMgr2Name
        {
            get { return _casemgr2Name; }
            set { _casemgr2Name = value; }
        }

        public string CaseMgr2Agency
        {
            get { return _casemgr2Agency; }
            set { _casemgr2Agency = value; }
        }

        public string CaseMgr2Phone
        {
            get { return _casemgr2Phone; }
            set { _casemgr2Phone = value; }
        }

        public string CaseMgr2Notes
        {
            get { return _casemgr2notes; }
            set { _casemgr2notes = value; }
        }

        public string EmgAssist1Agency
        {
            get { return _emgassist1Angency; }
            set { _emgassist1Angency = value; }
        }

        public string EmgAssist1CaseMgr
        {
            get { return _emgassist1Casemgr; }
            set { _emgassist1Casemgr = value; }
        }

        public string EmgAssist1Phone
        {
            get { return _emgassist1Phone; }
            set { _emgassist1Phone = value; }
        }

        public DateTime EmgAssist1Date
        {
            get { return _emgassist1Date; }
            set { _emgassist1Date = value; }
        }

        public decimal EmgAssist1Amount
        {
            get { return _emgassist1Amount; }
            set { _emgassist1Amount = value; }
        }

        public int EmgAssist1Status
        {
            get { return _emgassist1Status; }
            set { _emgassist1Status = value; }
        }

        public string EmgAssist2Agency
        {
            get { return _emgassist2Angency; }
            set { _emgassist2Angency = value; }
        }

        public string EmgAssist2CaseMgr
        {
            get { return _emgassist2Casemgr; }
            set { _emgassist2Casemgr = value; }
        }

        public string EmgAssist2Phone
        {
            get { return _emgassist2Phone; }
            set { _emgassist2Phone = value; }
        }

        public DateTime EmgAssist2Date
        {
            get { return _emgassist2Date; }
            set { _emgassist2Date = value; }
        }

        public decimal EmgAssist2Amount
        {
            get { return _emgassist2Amount; }
            set { _emgassist2Amount = value; }
        }

        public int EmgAssist2Status
        {
            get { return _emgassist2Status; }
            set { _emgassist2Status = value; }
        }

        public int PastShelter
        {
            get { return _pastShelter; }
            set { _pastShelter = value; }
        }

        public DateTime PastShelterDate
        {
            get { return _pastShelterDate; }
            set { _pastShelterDate = value; }
        }

        public int PastUnsheltered
        {
            get { return _pastUnsheltered; }
            set { _pastUnsheltered = value; }
        }

        public DateTime PastUnshelteredDate
        {
            get { return _pastUnshelteredDate; }
            set { _pastUnshelteredDate = value; }
        }

        public int PastChemical
        {
            get { return _pastChemical; }
            set { _pastChemical = value; }
        }

        public DateTime PastChemicalDate
        {
            get { return _pastChemicalDate; }
            set { _pastChemicalDate = value; }
        }

        public int PastTransitional
        {
            get { return _pastTransitional; }
            set { _pastTransitional = value; }
        }

        public DateTime PastTransitionalDate
        {
            get { return _pastTransitionalDate; }
            set { _pastTransitionalDate = value; }
        }

        public int PastDoubled
        {
            get { return _pastDoubled; }
            set { _pastDoubled = value; }
        }

        public DateTime PastDoubledDate
        {
            get { return _pastDoubledDate; }
            set { _pastDoubledDate = value; }
        }

        public int PastEviction
        {
            get { return _pastEviction; }
            set { _pastEviction = value; }
        }

        public DateTime PastEvictionDate
        {
            get { return _pastEvictionDate; }
            set { _pastEvictionDate = value; }
        }

        public int PastForeclosure
        {
            get { return _pastForeclosure; }
            set { _pastForeclosure = value; }
        }

        public DateTime PastForeclosureDate
        {
            get { return _pastForeclosureDate; }
            set { _pastForeclosureDate = value; }
        }

        public string PhoneHome
        {
            get { return _phoneHome; }
            set { _phoneHome = value; }
        }

        public string PhoneWork
        {
            get { return _phoneWork; }
            set { _phoneWork = value; }
        }

        public string PhoneMobile
        {
            get { return _phoneMobile; }
            set { _phoneMobile = value; }
        }

        public string PhoneOther
        {
            get { return _phoneOther; }
            set { _phoneOther = value; }
        }

        public DateTime LastShelter
        {
            get { return _lastShelter; }
        }

        public DateTime LastShelterExit
        {
            get { return _lastShelterExit; }
        }

        public int EmploymentFrequency
        {
            get { return _empFreq; }
            set { _empFreq = value; }
        }

        public DateTime EmploymentDate
        {
            get { return _empDate; }
            set { _empDate = value; }
        }

        public int MFIPDay
        {
            get { return _mfipDay; }
            set { _mfipDay = value; }
        }

        public DateTime ChildSupportDate
        {
            get { return _childsupportDate; }
            set { _childsupportDate = value; }
        }

        public DateTime OtherSourcesDate
        {
            get { return _otherincomeDate; }
            set { _otherincomeDate = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        #endregion

		#region Public Methods

		public void Save(int orgId, string userId)
		{
			SavePerson(orgId, userId);
		}

		public static void Delete(int Id)
		{
			new ResourceCenterPersonData().DeleteResourceCenterPerson(Id);
		}

		public void Delete()
		{

			// delete record
			ResourceCenterPersonData PersonData = new ResourceCenterPersonData();
			PersonData.DeleteResourceCenterPerson(_Id);

			_Id = -1;
		}

        public void BulkChangeAddress(int personId, string userId)
        {
            new ResourceCenterPersonData().BulkChangeAddress(personId, _streetAddress, _city, _postalCode, _state, _county, userId);
        }

        public int CountSimilars(string firstName, string lastName, string street, string zipCode, int excludeID)
        {
            return new ResourceCenterPersonData().CountSimilars(firstName, lastName, street, zipCode, excludeID);
        }

		#endregion

		#region Private Methods

		private void SavePerson(int orgId, string userId)
		{
			_Id = new ResourceCenterPersonData().SaveResourceCenterPerson(
                orgId,
				_personId,
                _numAdults,
                _numChildren,
                _county,
                _helpRequested,
                _notes,
				userId,
                _nickName,
                _firstName,
                _middleName,
                _lastName,
                _suffix,
                _birthday,
                _gender,
                _email,
                _streetAddress,
                _city,
                _state,
                _postalCode,
                _ssn,
                _schoolDistrict,
                _incomeEmployment,
                _incomeUnemployment,
                _incomeMFIP,
                _incomeChildSupport,
                _incomeMA,
                _incomeSSISSDI,
                _incomeOther,
                _cashOnHand,
                _issuesOfNote,
                _lastDateWorked,
                _mstatus,
                _dlicense,
                _ebt,
                _foodSupport,
                _assistanceApplied,
                _foodShelf,
                _foodShelfVisit,
                _casemgr1Name,
                _casemgr1Agency,
                _casemgr1Phone,
                _casemgr2Name,
                _casemgr2Agency,
                _casemgr2Phone,
                _emgassist1Angency,
                _emgassist1Casemgr,
                _emgassist1Phone,
                _emgassist1Date,
                _emgassist1Amount,
                _emgassist1Status,
                _emgassist2Angency,
                _emgassist2Casemgr,
                _emgassist2Phone,
                _emgassist2Date,
                _emgassist2Amount,
                _emgassist2Status,
                _pastShelter,
                _pastShelterDate,
                _pastUnsheltered,
                _pastUnshelteredDate,
                _pastChemical,
                _pastChemicalDate,
                _pastTransitional,
                _pastTransitionalDate,
                _pastDoubled,
                _pastDoubledDate,
                _pastEviction,
                _pastEvictionDate,
                _pastForeclosure,
                _pastForeclosureDate,
                _phoneHome,
                _phoneWork,
                _phoneMobile,
                _phoneOther,
                _casemgr1notes,
                _casemgr2notes,
                _empFreq,
                _empDate,
                _mfipDay,
                _childsupportDate,
                _otherincomeDate,
                _message,
                _flag
                );
		}

		private void LoadPerson(SqlDataReader reader)
		{
            if (!reader.IsDBNull(reader.GetOrdinal("Last_Shelter")))
                _lastShelter = (DateTime)reader["Last_Shelter"];

            if (!reader.IsDBNull(reader.GetOrdinal("Last_Shelter_Exit")))
                _lastShelterExit = (DateTime)reader["Last_Shelter_Exit"];

            if (!reader.IsDBNull(reader.GetOrdinal("id")))
				_personId = (int)reader["id"];

			if (!reader.IsDBNull(reader.GetOrdinal("date_created")))
				_dateCreated = (DateTime)reader["date_created"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_updated")))
                _dateUpdated = (DateTime)reader["date_updated"];

            _createdBy = reader["created_by"].ToString();

            _updatedBy = reader["updated_by"].ToString();

            //if (!reader.IsDBNull(reader.GetOrdinal("person_id")))
            //    _personId = (int)reader["person_id"];

            if (!reader.IsDBNull(reader.GetOrdinal("num_adults")))
                _numAdults = (int)reader["num_adults"];

            if (!reader.IsDBNull(reader.GetOrdinal("num_children")))
                _numChildren = (int)reader["num_children"];

            _county = reader["county_of_origin"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("help_requested")))
                _helpRequested = (int)reader["help_requested"];

            _notes = reader["notes"].ToString();

            _nickName = reader["nick_name"].ToString();

            _firstName = reader["first_name"].ToString();

            _middleName = reader["middle_name"].ToString();

            _lastName = reader["last_name"].ToString();

            _suffix = reader["suffix"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("birthday")))
                _birthday = (DateTime)reader["birthday"];

            _gender = reader["gender"].ToString();

            _email = reader["email"].ToString();

            _streetAddress = reader["street_address"].ToString();

            _city = reader["city"].ToString();

            _state = reader["state"].ToString();

            _postalCode = reader["postal_code"].ToString();

            _ssn = reader["ssn"].ToString();

            _schoolDistrict = reader["school_district"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("income_employment")))
                _incomeEmployment = (decimal)reader["income_employment"];

            if (!reader.IsDBNull(reader.GetOrdinal("income_unemployment")))
                _incomeUnemployment = (decimal)reader["income_unemployment"];

            if (!reader.IsDBNull(reader.GetOrdinal("income_mfip")))
                _incomeMFIP = (decimal)reader["income_mfip"];

            if (!reader.IsDBNull(reader.GetOrdinal("income_ma")))
                _incomeMA = (decimal)reader["income_ma"];

            if (!reader.IsDBNull(reader.GetOrdinal("income_childsupport")))
                _incomeChildSupport = (decimal)reader["income_childsupport"];

            if (!reader.IsDBNull(reader.GetOrdinal("income_ssissdi")))
                _incomeSSISSDI = (decimal)reader["income_ssissdi"];

            if (!reader.IsDBNull(reader.GetOrdinal("income_other")))
                _incomeOther = (decimal)reader["income_other"];

            if (!reader.IsDBNull(reader.GetOrdinal("cash_on_hand")))
                _cashOnHand = (decimal)reader["cash_on_hand"];

            if (!reader.IsDBNull(reader.GetOrdinal("issues")))
                _issuesOfNote = (int)reader["issues"];

            if (!reader.IsDBNull(reader.GetOrdinal("last_date_worked")))
                _lastDateWorked = (DateTime)reader["last_date_worked"];

            if (!reader.IsDBNull(reader.GetOrdinal("mstatus")))
                _mstatus = (int)reader["mstatus"];

            if (!reader.IsDBNull(reader.GetOrdinal("dlicense")))
                _dlicense = (int)reader["dlicense"];

            if (!reader.IsDBNull(reader.GetOrdinal("ebt")))
                _ebt = (int)reader["ebt"];

            if (!reader.IsDBNull(reader.GetOrdinal("food_support")))
                _foodSupport = (decimal)reader["food_support"];

            if (!reader.IsDBNull(reader.GetOrdinal("applied_assistance")))
                _assistanceApplied = (DateTime)reader["applied_assistance"];

            _foodShelf = reader["food_shelf"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("food_shelf_visit")))
                _foodShelfVisit = (DateTime)reader["food_shelf_visit"];

            _casemgr1Name = reader["casemgr_1_name"].ToString();
            _casemgr1Agency = reader["casemgr_1_agency"].ToString();
            _casemgr1Phone = reader["casemgr_1_phone"].ToString();
            _casemgr1notes = reader["casemgr_1_notes"].ToString();

            _casemgr2Name = reader["casemgr_2_name"].ToString();
            _casemgr2Agency = reader["casemgr_2_agency"].ToString();
            _casemgr2Phone = reader["casemgr_2_phone"].ToString();
            _casemgr2notes = reader["casemgr_2_notes"].ToString();

            _emgassist1Angency = reader["emgassist_1_agency"].ToString();
            _emgassist1Casemgr = reader["emgassist_1_casemgr"].ToString();
            _emgassist1Phone = reader["emgassist_1_phone"].ToString();
            if (!reader.IsDBNull(reader.GetOrdinal("emgassist_1_date")))
                _emgassist1Date = (DateTime)reader["emgassist_1_date"];
            if (!reader.IsDBNull(reader.GetOrdinal("emgassist_1_amount")))
                _emgassist1Amount = (decimal)reader["emgassist_1_amount"];
            if (!reader.IsDBNull(reader.GetOrdinal("emgassist_1_status")))
                _emgassist1Status = (int)reader["emgassist_1_status"];

            _emgassist2Angency = reader["emgassist_2_agency"].ToString();
            _emgassist2Casemgr = reader["emgassist_2_casemgr"].ToString();
            _emgassist2Phone = reader["emgassist_2_phone"].ToString();
            if (!reader.IsDBNull(reader.GetOrdinal("emgassist_2_date")))
                _emgassist2Date = (DateTime)reader["emgassist_2_date"];
            if (!reader.IsDBNull(reader.GetOrdinal("emgassist_2_amount")))
                _emgassist2Amount = (decimal)reader["emgassist_2_amount"];
            if (!reader.IsDBNull(reader.GetOrdinal("emgassist_2_status")))
                _emgassist2Status = (int)reader["emgassist_2_status"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_shelter")))
                _pastShelter = (int)reader["past_shelter"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_shelter_date")))
                _pastShelterDate = (DateTime)reader["past_shelter_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_unsheltered")))
                _pastUnsheltered = (int)reader["past_unsheltered"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_unsheltered_date")))
                _pastUnshelteredDate = (DateTime)reader["past_unsheltered_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_chemical")))
                _pastChemical = (int)reader["past_chemical"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_chemical_date")))
                _pastChemicalDate = (DateTime)reader["past_chemical_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_transitional")))
                _pastTransitional = (int)reader["past_transitional"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_transitional_date")))
                _pastTransitionalDate = (DateTime)reader["past_transitional_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_doubled")))
                _pastDoubled = (int)reader["past_doubled"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_doubled_date")))
                _pastDoubledDate = (DateTime)reader["past_doubled_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_eviction")))
                _pastEviction = (int)reader["past_eviction"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_eviction_date")))
                _pastEvictionDate = (DateTime)reader["past_eviction_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("past_foreclosure")))
                _pastForeclosure = (int)reader["past_foreclosure"];
            if (!reader.IsDBNull(reader.GetOrdinal("past_foreclosure_date")))
                _pastForeclosureDate = (DateTime)reader["past_foreclosure_date"];

            _phoneHome = reader["phone_home"].ToString();
            _phoneWork = reader["phone_work"].ToString();
            _phoneMobile = reader["phone_mobile"].ToString();
            _phoneOther = reader["phone_other"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("employment_frequency")))
                _empFreq = (int)reader["employment_frequency"];

            if (!reader.IsDBNull(reader.GetOrdinal("employment_date")))
                _empDate = (DateTime)reader["employment_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("mfip_day")))
                _mfipDay = (int)reader["mfip_day"];

            if (!reader.IsDBNull(reader.GetOrdinal("childsupport_date")))
                _childsupportDate = (DateTime)reader["childsupport_date"];

            if (!reader.IsDBNull(reader.GetOrdinal("othersources_date")))
                _otherincomeDate = (DateTime)reader["othersources_date"];

            _message = reader["message"].ToString();
            if (!reader.IsDBNull(reader.GetOrdinal("flag")))
                _flag = (int)reader["flag"];

        }

		#endregion

		#region Static Methods
		#endregion

		#region Constructors

		public ResourceCenterPerson()
		{

		}

		public ResourceCenterPerson(int personId)
		{
            SqlDataReader reader = new ResourceCenterPersonData().GetResourceCenterPersonByID(personId);
			if (reader.Read())
				LoadPerson(reader);
			reader.Close();
		}

		public ResourceCenterPerson(SqlDataReader reader)
		{
			LoadPerson(reader);
		}

		#endregion
	}

    [Serializable]
    public class ResourceCenterEvent : ArenaObjectBase
    {
        #region Private Members

        private int ipersonId = -1;
        private DateTime dtDate = DateTime.MinValue;
        private string sName = string.Empty;
        private decimal dAmount = 0;
        private string sSource = string.Empty;

        #endregion

        #region Public Properties

        public int PersonID
        {
            get { return ipersonId; }
        }

        public DateTime Date
        {
            get { return dtDate; }
        }

        public string Name
        {
            get { return sName; }
        }

        public decimal Amount
        {
            get { return dAmount; }
        }

        public string Source
        {
            get { return sSource; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void LoadEvent(SqlDataReader reader)
        {
            ipersonId = (int)reader["person_id"];
            dtDate = (DateTime)reader["Date"];
            sName = reader["Name"].ToString();
            dAmount = (decimal)reader["Amount"];
            sSource = reader["Type"].ToString();
        }

        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterEvent()
        {

        }

        public ResourceCenterEvent(int personId, DateTime date, string name, decimal amount, string source)
        {
            ipersonId = personId;
            dtDate = date;
            sName = name;
            dAmount = amount;
            sSource = source;
        }

        public ResourceCenterEvent(SqlDataReader reader)
        {
            LoadEvent(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterHelp : ArenaObjectBase
	{
		#region Private Members
            
		private int _Id = -1;                                   //General
        private DateTime _date = DateTime.MinValue;             //General
        private int _type = 0;                                  //General
        private decimal _amount = 0;                            //Value
        private int _size = 0;                                  //Value
        private string _description = string.Empty;             //General
        private int _subsidized = 0;                            //Sub
        private decimal _subAmountReceived = 0;                 //Sub
        private string _subSource = String.Empty;               //Sub
        private string _vendor = string.Empty;                  //Value
        private string _complete = string.Empty;                //General
        private string _assistant = string.Empty;               //General
        private DateTime _completedDate = DateTime.MinValue;    //General
        private string _resolution = string.Empty;              //General
        private int _subType = 0;                               //General
        private string _notes = string.Empty;                   //Specifics
        private DateTime _dateCreated = DateTime.MinValue;      //General
        private DateTime _dateUpdated = DateTime.MinValue;      //General
        private string _createdBy = string.Empty;               //General
        private string _updatedBy = string.Empty;               //General

        private string _address = string.Empty;
        private string _city = string.Empty;
        private string _zip = string.Empty;
        private string _state = string.Empty;
        private string _county = string.Empty;

        private bool _erased = false;

		#endregion

		#region Public Properties

		public int Id
		{
			get { return _Id; }
			//set { _Id = value; }
		}

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Subsidized
        {
            get { return _subsidized; }
            set { _subsidized = value; }
        }

        public decimal SubAmountReceived
        {
            get { return _subAmountReceived; }
            set { _subAmountReceived = value; }
        }

        public string SubSource
        {
            get { return _subSource; }
            set { _subSource = value; }
        }

        public string Vendor
        {
            get { return _vendor; }
            set { _vendor = value; }
        }

        public string Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }

        public string Assistant
        {
            get { return _assistant; }
            set { _assistant = value; }
        }

        public DateTime DateCompleted
        {
            get { return _completedDate; }
            set { _completedDate = value; }
        }

        public string Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        public int SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public string Street
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public bool Erased
        {
            get { return _erased; }
        }

		#endregion

		#region Public Methods

		public void Save(string userId, int prototypeId)
		{
			SaveHelp(userId, prototypeId);
		}

		public void Delete(int helpId, int personId)
		{
			ResourceCenterHelpData help = new ResourceCenterHelpData();
            if (help.DeleteResourceCenterHelp(helpId, personId) == 0)
            {
                _erased = true;
            }
            else
            {
                _erased = false;
            }
		}

		public void Delete(int personId)
		{

			// delete record
			ResourceCenterHelpData HelpData = new ResourceCenterHelpData();
            if (HelpData.DeleteResourceCenterHelp(_Id, personId) == 0)
            {
                _erased = true;
            }
            else
            {
                _erased = false;
            }

			_Id = -1;
		}

        public void AddLink(int helpId, int personId)
        {
            new ResourceCenterHelpData().AddNewLink(helpId, personId);
        }

		#endregion

		#region Private Methods

		private void SaveHelp(string userId, int prototypeId)
		{
			_Id = new ResourceCenterHelpData().SaveResourceCenterHelp(_Id, _date, _type, _amount, _size, _description, _subsidized,
                _subAmountReceived, _subSource, _vendor, _complete, _assistant, _completedDate, _resolution, _subType, _notes, userId,
                _address, _city, _zip, _state, _county, prototypeId);
		}

		private void LoadHelp(SqlDataReader reader)
		{
			if (!reader.IsDBNull(reader.GetOrdinal("id")))
				_Id = (int)reader["id"];

			if (!reader.IsDBNull(reader.GetOrdinal("date_created")))
				_dateCreated = (DateTime)reader["date_created"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_updated")))
                _dateUpdated = (DateTime)reader["date_updated"];

            _createdBy = reader["created_by"].ToString();

            _updatedBy = reader["updated_by"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("date")))
                _date = (DateTime)reader["date"];

            if (!reader.IsDBNull(reader.GetOrdinal("type")))
                _type = (int)reader["type"];

            if (!reader.IsDBNull(reader.GetOrdinal("size")))
                _size = (int)reader["size"];

            if (!reader.IsDBNull(reader.GetOrdinal("amount")))
                _amount = (decimal)reader["amount"];

            _description = reader["description"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("sub")))
                _subsidized = (int)reader["sub"];

            if (!reader.IsDBNull(reader.GetOrdinal("sub_recieved")))
                _subAmountReceived = (decimal)reader["sub_recieved"];

            _subSource = reader["sub_source"].ToString();

            _vendor = reader["vendor"].ToString();

            _complete = reader["complete"].ToString();

            _assistant = reader["assistant"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("completed_on")))
                _completedDate = (DateTime)reader["completed_on"];

            _resolution = reader["resolution"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("sub_type")))
                _subType = (int)reader["sub_type"];

            _notes = reader["notes"].ToString();

            _address = reader["address"].ToString();
            _city = reader["city"].ToString();
            _zip = reader["zip"].ToString();
            _state = reader["state"].ToString();
            _county = reader["county"].ToString();

		}


		#endregion

        #region Static Methods

        public static string GetTypeNameById(int typeId)
        {
            string s = string.Empty;
            switch (typeId)
            {
                case 1:
                    s = "Computer";
                    break;
                case 2:
                    s = "Food";
                    break;
                case 4:
                    s = "Holiday";
                    break;
                case 8:
                    s = "Housing";
                    break;
                case 16:
                    s = "Internet";
                    break;
                case 32:
                    s = "Job Related";
                    break;
                case 64:
                    s = "Other";
                    break;
                case 128:
                    s = "Basic Needs";
                    break;
                case 256:
                    s = "Tax";
                    break;
                case 512:
                    s = "School Supplies";
                    break;
                case 1024:
                    s = "Coat/Jacket";
                    break;
                case 2048:
                    s = "Shelter";
                    break;
                default:
                    s = "Unknown";
                    break;
            }
            return s;
        }

        public static string GetSubtypeNameById(int subtypeId)
        {
            return GetSubtypeDisplayById(subtypeId).Name;
        }

        public static ResourceCenterHelpSubType GetSubtypeDisplayById(int subtypeId)
        {
            return new ResourceCenterHelpSubType(subtypeId);
            /*string n = string.Empty;
            string st = string.Empty;
            bool q = false;
            bool v = false;
            switch (subtypeId)
            {
                case 1:
                    n = "Household Basic";
                    st = "of Items"; //Household Basic
                    q = true;
                    v = false;
                    break;
                case 2:
                    n = "Furniture";
                    st = "of Items"; //Furniture
                    q = true;
                    v = false;
                    break;
                case 3:
                    n = "Transportation";
                    st = ""; //Transportation
                    q = false;
                    v = false;
                    break;
                case 4:
                    n = "Gas Card";
                    st = "of Gas Card"; //Gas Card
                    q = false;
                    v = true;
                    break;
                case 5:
                    n = "Clothing";
                    st = "of Items"; //Clothing
                    q = true;
                    v = false;
                    break;
                case 6:
                    n = "Legal Fees";
                    st = "of Check"; //Legal Fees
                    q = false;
                    v = true;
                    break;
                case 7:
                    n = "Child Care";
                    st = "";  //Child Care
                    q = true;
                    v = true;
                    break;
                case 8:
                    n = "Food";
                    st = "of Pounds"; //Food
                    q = true;
                    v = false;
                    break;
                case 9:
                    n = "Negotation";
                    st = "of Minutes"; //"Negotation";
                    q = true;
                    v = false;
                    break;
                case 10:
                    n = "Coat/Jacket";
                    st = "of Coats/Jackets"; //"Coat/Jacket";
                    q = true;
                    v = false;
                    break;
                case 11:
                    n = "Computer Use";
                    st = ""; //"Computer Use";
                    q = false;
                    v = false;
                    break;
                case 12:
                    n = "Personal Care Items";
                    st = "of Personal Care Kits"; //"Personal Care Items";
                    q = true;
                    v = false;
                    break;
                case 13:
                    n = "Other";
                    st = ""; //"Other";
                    q = true;
                    v = true;
                    break;
                case 14:
                    n = "Shelter";
                    st = ""; //"Shelter";
                    q = false;
                    v = false;
                    break;
                case 15:
                    n = "Rental Assistance";
                    st = "of Check"; //"Rental Assistance";
                    q = false;
                    v = true;
                    break;
                case 16:
                    n = "Shelter Kit";
                    st = "of Kits"; //"Shelter Kit";
                    q = true;
                    v = false;
                    break;
                case 17:
                    n = "Bedding Items";
                    st = "of Bedding Items"; //"Bedding";
                    q = true;
                    v = false;
                    break;
                case 18:
                    n = "Voucher";
                    st = "of Voucher"; //"Voucher";
                    q = false;
                    v = true;
                    break;
                case 19:
                    n = "School Supplies";
                    st = ""; //"School Supplies";
                    q = false;
                    v = false;
                    break;
                case 20:
                    n = "Holiday Help";
                    st = ""; //"Holiday Help";
                    q = false;
                    v = false;
                    break;
                case 21:
                    n = "Case Management";
                    st = "of minutes"; //"Case Management";
                    q = true;
                    v = false;
                    break;
                case 22:
                    n = "\"Welcome Home\" Kit";
                    st = "of Kits"; //"\"Welcome Home\" Kit";
                    q = true;
                    v = false;
                    break;
                case 23:
                    n = "Bikes";
                    st = "of Bikes"; //"Bikes";
                    q = true;
                    v = false;
                    break;
                case 24:
                    n = "Seasonal Food Program";
                    st = "of Pounds"; //"Seasonal Food Program";
                    q = true;
                    v = false;
                    break;
                case 25:
                    n = "Utility";
                    st = "of Check"; //"Utility";
                    q = false;
                    v = true;
                    break;
                case 26:
                    n = "Church Ride Request";
                    st = "";
                    q = false;
                    v = false;
                    break;
                default:
                    n = "Unknown (" + subtypeId.ToString() + ")";
                    st = "";
                    q = true;
                    v = true;
                    break;
            }
            ResourceCenterHelpSubType id = new ResourceCenterHelpSubType(1, n, st, q, v);
            return id;*/
        }

		#endregion

		#region Constructors

		public ResourceCenterHelp()
		{

		}

		public ResourceCenterHelp(int Id)
		{
            SqlDataReader reader = new ResourceCenterHelpData().GetResourceCenterHelpByID(Id);
			if (reader.Read())
				LoadHelp(reader);
			reader.Close();
		}

		public ResourceCenterHelp(SqlDataReader reader)
		{
			LoadHelp(reader);
		}

		#endregion
	}

    [Serializable]
    public class ResourceCenterHelpSubType : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private string _name = string.Empty;
        private string _text = string.Empty;
        private int _quantity = 0;
        private int _amount = 0;
        private int _organizationId = 1;
        private int _enabled = 0;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public bool IsQuantity
        {
            get { return (_quantity > 0); }
            set { if (value) _quantity = 1; else _quantity = 0; }
        }

        public bool IsAmount
        {
            get { return (_amount > 0); }
            set { if (value) _amount = 1; else _amount = 0; }
        }

        public int OrganizationId
        {
            get { return _organizationId; }
            set { _organizationId = value; }
        }

        public bool Enabled
        {
            get { return (_enabled > 0); }
            set { if (value) _enabled = 1; else _enabled = 0; }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            SaveHelpSubType();
        }

        public static void Delete(int Id)
        {
            new ResourceCenterHelpSubTypeData().DeleteResourceCenterHelpSubType(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterHelpSubTypeData HelpSubTypeData = new ResourceCenterHelpSubTypeData();
            HelpSubTypeData.DeleteResourceCenterHelpSubType(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveHelpSubType()
        {
            _Id = new ResourceCenterHelpSubTypeData().SaveResourceCenterHelpSubType(_organizationId, _Id, _name, _text, _quantity, _amount, _enabled > 0);
        }

        private void LoadHelpSubType(SqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("id")))
                _Id = (int)reader["id"];

            _name = reader["name"].ToString();
            _text = reader["text"].ToString();
            _quantity = (int)reader["quantity"];
            _amount = (int)reader["amount"];
            _organizationId = (int)reader["organization_id"];
        }


        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterHelpSubType()
        {
        }

        public ResourceCenterHelpSubType(int orgId, int id, string name, string text, bool quantity, bool amount)
        {
            _Id = id;
            _organizationId = orgId;
            _name = name;
            _text = text;
            _quantity = quantity ? 1 : 0;
            _amount = amount ? 1 : 0;
        }

        public ResourceCenterHelpSubType(int Id)
        {
            SqlDataReader reader = new ResourceCenterHelpSubTypeData().GetResourceCenterHelpSubTypeByID(Id);
            if (reader.Read())
                LoadHelpSubType(reader);
            reader.Close();
        }

        public ResourceCenterHelpSubType(SqlDataReader reader)
        {
            LoadHelpSubType(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterAccount : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private int _helpId = 0;
        private decimal _amount = 0;
        private DateTime _date = DateTime.MinValue;
        private string _note = string.Empty;
        private int _organizationId = 1;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public int HelpId
        {
            get { return _helpId; }
            set { _helpId = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public int OrganizationId
        {
            get { return _organizationId; }
            set { _organizationId = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            SaveAccount();
        }

        public static void Delete(int Id)
        {
            new ResourceCenterAccountData().DeleteResourceCenterAccount(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterAccountData AccountData = new ResourceCenterAccountData();
            AccountData.DeleteResourceCenterAccount(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveAccount()
        {
            _Id = new ResourceCenterAccountData().SaveResourceCenterAccount(_organizationId, _Id, _helpId, _amount, _date, _note);
        }

        private void LoadAccount(SqlDataReader reader)
        {
            _Id = (int)reader["id"];
            _helpId = (int)reader["help_id"];
            _amount = (decimal)reader["amount"];
            _date = (DateTime)reader["date"];
            _note = reader["note"].ToString();
            _organizationId = (int)reader["organization_id"];
        }

        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterAccount()
        {

        }

        public ResourceCenterAccount(int Id)
        {
            SqlDataReader reader = new ResourceCenterAccountData().GetResourceCenterAccountByID(Id);
            if (reader.Read())
                LoadAccount(reader);
            reader.Close();
        }

        public ResourceCenterAccount(SqlDataReader reader)
        {
            LoadAccount(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterAddress : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;                                   //General

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            SaveAddress();
        }

        public static void Delete(int Id)
        {
            new ResourceCenterAddressData().DeleteResourceCenterAddress(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterAddressData AddressData = new ResourceCenterAddressData();
            AddressData.DeleteResourceCenterAddress(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveAddress()
        {
            _Id = new ResourceCenterAddressData().SaveResourceCenterAddress(_Id);
        }

        private void LoadAddress(SqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("id")))
                _Id = (int)reader["id"];

        }


        #endregion

        #region Static Methods
        /*public static ResourceCenterPerson GetFirstByPersonId(int personId)
		{
			ResourceCenterPerson person = new ResourceCenterPerson();
			SqlDataReader reader = new ResouceCenterPersonData().GetFirstResourceCenterPersonByPersonId(personId);
			if (reader.Read())
			{
				person.LoadPerson(reader);
			}
			reader.Close();
			return person;
		}

		public static ResourceCenterPerson GetLastByPersonId(int personId)
		{
			ResourceCenterPerson foodbag = new ResourceCenterPerson();
			SqlDataReader reader = new ResouceCenterPersonData().GetLastResourceCenterPersonByPersonId(personId);
			if ( reader.Read() )
			{
				foodbag.LoadPerson(reader);
			}				
			reader.Close();
			return foodbag;
		}*/
        #endregion

        #region Constructors

        public ResourceCenterAddress()
        {

        }

        public ResourceCenterAddress(int Id)
        {
            SqlDataReader reader = new ResourceCenterHelpData().GetResourceCenterHelpByID(Id);
            if (reader.Read())
                LoadAddress(reader);
            reader.Close();
        }

        public ResourceCenterAddress(SqlDataReader reader)
        {
            LoadAddress(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterMeal : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private DateTime _date = DateTime.MinValue;
        private int _served = 0;
        private int _meals = 0;
        private int _dist = 0;
        private int _pounds = 0;

        private DateTime _dateCreated = DateTime.MinValue;      //General
        private DateTime _dateUpdated = DateTime.MinValue;      //General
        private string _createdBy = string.Empty;               //General
        private string _updatedBy = string.Empty;               //General

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Served
        {
            get { return _served; }
            set { _served = value; }
        }

        public int Meals
        {
            get { return _meals; }
            set { _meals = value; }
        }

        public int Dist
        {
            get { return _dist; }
            set { _dist = value; }
        }

        public int Pounds
        {
            get { return _pounds; }
            set { _pounds = value; }
        }

        #endregion

        #region Public Methods

        public void Save(string userId)
        {
            SaveMeal(userId);
        }

        public static void Delete(int Id)
        {
            new ResourceCenterMealData().DeleteResourceCenterMeal(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterMealData MealData = new ResourceCenterMealData();
            MealData.DeleteResourceCenterMeal(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveMeal(string userId)
        {
            _Id = new ResourceCenterMealData().SaveResourceCenterMeal(_Id, userId, _date, _served, _meals, _dist, _pounds);
        }

        private void LoadMeal(SqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("id")))
                _Id = (int)reader["id"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_created")))
                _dateCreated = (DateTime)reader["date_created"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_updated")))
                _dateUpdated = (DateTime)reader["date_updated"];

            _createdBy = reader["created_by"].ToString();

            _updatedBy = reader["updated_by"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("date")))
                _date = (DateTime)reader["date"];

            if (!reader.IsDBNull(reader.GetOrdinal("served")))
                _served = (int)reader["served"];

            if (!reader.IsDBNull(reader.GetOrdinal("meals")))
                _meals = (int)reader["meals"];

            if (!reader.IsDBNull(reader.GetOrdinal("dist")))
                _dist = (int)reader["dist"];

            if (!reader.IsDBNull(reader.GetOrdinal("pounds")))
                _pounds = (int)reader["pounds"];

        }


        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterMeal()
        {

        }

        public ResourceCenterMeal(int Id)
        {
            SqlDataReader reader = new ResourceCenterMealData().GetResourceCenterMealByID(Id);
            if (reader.Read())
                LoadMeal(reader);
            reader.Close();
        }

        public ResourceCenterMeal(SqlDataReader reader)
        {
            LoadMeal(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterCall : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private DateTime _date = DateTime.MinValue;
        private string _name = string.Empty;
        private string _phone = string.Empty;
        private string _county = string.Empty;
        private string _msgFor = string.Empty;
        private int _hh = 1;
        private int _recieve = 0;
        private int _callType = 0;
        private int _reqFood = 0;
        private int _reqShelter = 0;
        private int _reqRent = 0;
        private int _reqUtility = 0;
        private int _reqFurn = 0;
        private int _reqOther = 0;
        private string _notes = string.Empty;
        private int _completed = 0;
        private int _personId = 0;
        private int _orgId = 1;

        private DateTime _dateCreated = DateTime.MinValue;      //General
        private DateTime _dateUpdated = DateTime.MinValue;      //General
        private string _createdBy = string.Empty;               //General
        private string _updatedBy = string.Empty;               //General

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public String County
        {
            get { return _county; }
            set { _county = value; }
        }

        public String MessageFor
        {
            get { return _msgFor; }
            set { _msgFor = value; }
        }

        public int HH
        {
            get { return _hh; }
            set { _hh = value; }
        }

        public int Recieve
        {
            get { return _recieve; }
            set { _recieve = value; }
        }

        public int CallType
        {
            get { return _callType; }
            set { _callType = value; }
        }

        public int ReqFood
        {
            get { return _reqFood; }
            set { _reqFood = value; }
        }

        public int ReqShelter
        {
            get { return _reqShelter; }
            set { _reqShelter = value; }
        }

        public int ReqRent
        {
            get { return _reqRent; }
            set { _reqRent = value; }
        }

        public int ReqUtility
        {
            get { return _reqUtility; }
            set { _reqUtility = value; }
        }

        public int ReqFurn
        {
            get { return _reqFurn; }
            set { _reqFurn = value; }
        }

        public int ReqOther
        {
            get { return _reqOther; }
            set { _reqOther = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public int Completed
        {
            get { return _completed; }
            set { _completed = value; }
        }

        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

        public int OrganizationId
        {
            get { return _orgId; }
            set { _orgId = value; }
        }

        public string FullName
        {
            get
            {
                if (_personId > 0)
                {
                    ResourceCenterPerson p = new ResourceCenterPerson(_personId);
                    return p.FirstName + " " + p.LastName;
                }
                else
                {
                    return _name;
                }
            }
        }

        #endregion

        #region Public Methods

        public void Save(string userId)
        {
            SaveCall(userId);
        }

        public static void Delete(int Id)
        {
            new ResourceCenterCallData().DeleteResourceCenterCall(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterCallData CallData = new ResourceCenterCallData();
            CallData.DeleteResourceCenterCall(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveCall(string userId)
        {
            _Id = new ResourceCenterCallData().SaveResourceCenterCall(_orgId, _Id, userId, _date, _name, _phone, _county, _msgFor, _hh, _recieve, _callType,
                _reqFood, _reqShelter, _reqRent, _reqUtility, _reqFurn, _reqOther, _notes, _completed, _personId);
        }

        private void LoadCall(SqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("id")))
                _Id = (int)reader["id"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_created")))
                _dateCreated = (DateTime)reader["date_created"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_updated")))
                _dateUpdated = (DateTime)reader["date_updated"];

            _createdBy = reader["created_by"].ToString();

            _updatedBy = reader["updated_by"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("date")))
                _date = (DateTime)reader["date"];

            _name = reader["name"].ToString();
            _phone = reader["phone"].ToString();
            _county = reader["county"].ToString();
            _msgFor = reader["msg_for"].ToString();
            _hh = (int)reader["hh"];
            _recieve = (int)reader["recieve"];
            _callType = (int)reader["call_type"];
            _reqFood = (int)reader["req_food"];
            _reqShelter = (int)reader["req_shelter"];
            _reqRent = (int)reader["req_rent"];
            _reqUtility = (int)reader["req_utility"];
            _reqFurn = (int)reader["req_furn"];
            _reqOther = (int)reader["req_other"];
            _notes = reader["notes"].ToString();
            _completed = (int)reader["completed"];

            if (!reader.IsDBNull(reader.GetOrdinal("person_id")))
                _personId = (int)reader["person_id"];

            if (!reader.IsDBNull(reader.GetOrdinal("organization_id")))
                _orgId = (int)reader["organization_id"];
        }


        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterCall()
        {

        }

        public ResourceCenterCall(int Id)
        {
            SqlDataReader reader = new ResourceCenterCallData().GetResourceCenterCallByID(Id);
            if (reader.Read())
                LoadCall(reader);
            reader.Close();
        }

        public ResourceCenterCall(SqlDataReader reader)
        {
            LoadCall(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterDonation : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private int _personId = -1;
        private DateTime _date = DateTime.MinValue;
        private int _type = 0;
        private string _description = string.Empty;
        private int _size = 0;
        private decimal _amount = 0;
        private string _notes = string.Empty;

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _middleName = string.Empty;
        private string _nickName = string.Empty;
        private string _guid = string.Empty;
        private string _fullName = string.Empty;

        private DateTime _dateCreated = DateTime.MinValue;      //General
        private DateTime _dateUpdated = DateTime.MinValue;      //General
        private string _createdBy = string.Empty;               //General
        private string _updatedBy = string.Empty;               //General

        private int organizationId = 1;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string MiddleName
        {
            get { return _middleName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string NickName
        {
            get { return _nickName; }
        }

        public string FullName
        {
            get { return _fullName; }
        }

        public string GUID
        {
            get { return _guid; }
        }

        public int OrganizationId
        {
            get { return organizationId; }
            set { organizationId = value; }
        }

        #endregion

        #region Public Methods

        public void Save(int orgId, string userId)
        {
            SaveDonation(orgId, userId);
        }

        public static void Delete(int Id)
        {
            new ResourceCenterDonationData().DeleteResourceCenterDonation(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterDonationData DonationData = new ResourceCenterDonationData();
            DonationData.DeleteResourceCenterDonation(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveDonation(int orgId, string userId)
        {
            _Id = new ResourceCenterDonationData().SaveResourceCenterDonation(orgId, _Id, userId, _personId, _date, _type, _description, _size, _amount, _notes);
        }

        private void LoadDonation(SqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("id")))
                _Id = (int)reader["id"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_created")))
                _dateCreated = (DateTime)reader["date_created"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_updated")))
                _dateUpdated = (DateTime)reader["date_updated"];

            _createdBy = reader["created_by"].ToString();
            _updatedBy = reader["updated_by"].ToString();
            _personId = (int)reader["person_id"];
            if (_personId > 0)
            {
                Person p = new Person(_personId);
                _firstName = p.FirstName;
                _middleName = p.MiddleName;
                _lastName = p.LastName;
                _nickName = p.NickName;
                _fullName = p.FullName;
                _guid = p.PersonGUID.ToString();
            }

            _date = (DateTime)reader["date"];
            _type = (int)reader["type"];

            if (!reader.IsDBNull(reader.GetOrdinal("description")))
                _description = reader["description"].ToString();
            if (!reader.IsDBNull(reader.GetOrdinal("size")))
                _size = (int)reader["size"];
            if (!reader.IsDBNull(reader.GetOrdinal("amount")))
                _amount = (decimal)reader["amount"];
            if (!reader.IsDBNull(reader.GetOrdinal("notes")))
                _notes = reader["notes"].ToString();
        }


        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterDonation()
        {

        }

        public ResourceCenterDonation(int Id)
        {
            SqlDataReader reader = new ResourceCenterDonationData().GetResourceCenterDonationByID(Id);
            if (reader.Read())
                LoadDonation(reader);
            reader.Close();
        }

        public ResourceCenterDonation(SqlDataReader reader)
        {
            LoadDonation(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterOffer : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private int _personId = -1;
        private DateTime _date = DateTime.MinValue;
        private int _type = 0;
        private string _description = string.Empty;
        private int _size = 0;
        private decimal _amount = 0;
        private string _notes = string.Empty;

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _middleName = string.Empty;
        private string _nickName = string.Empty;
        private string _guid = string.Empty;
        private string _fullName = string.Empty;

        private int _givenTo = 0;
        private int _callId = 0;
        private int _status = 0;

        private string _name = string.Empty;
        private string _phone = string.Empty;

        private DateTime _dateCreated = DateTime.MinValue;      //General
        private DateTime _dateUpdated = DateTime.MinValue;      //General
        private string _createdBy = string.Empty;               //General
        private string _updatedBy = string.Empty;               //General

        private int organizationId = 1;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string MiddleName
        {
            get { return _middleName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string NickName
        {
            get { return _nickName; }
        }

        public string FullName
        {
            get { return _fullName; }
        }

        public string GUID
        {
            get { return _guid; }
        }

        public int OrganizationId
        {
            get { return organizationId; }
            set { organizationId = value; }
        }

        public int ClientId
        {
            get { return _givenTo; }
            set { _givenTo = value; }
        }

        public int CallId
        {
            get { return _callId; }
            set { _callId = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        #endregion

        #region Public Methods

        public void Save(int orgId, string userId)
        {
            SaveOffer(orgId, userId);
        }

        public static void Delete(int Id)
        {
            new ResourceCenterOfferData().DeleteResourceCenterOffer(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterOfferData OfferData = new ResourceCenterOfferData();
            OfferData.DeleteResourceCenterOffer(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveOffer(int orgId, string userId)
        {
            _Id = new ResourceCenterOfferData().SaveResourceCenterOffer(orgId, _Id, userId, _personId, _date, _type, _description, _size, _amount, _notes, _givenTo, _callId, _status, _name, _phone);
        }

        private void LoadOffer(SqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("id")))
                _Id = (int)reader["id"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_created")))
                _dateCreated = (DateTime)reader["date_created"];

            if (!reader.IsDBNull(reader.GetOrdinal("date_updated")))
                _dateUpdated = (DateTime)reader["date_updated"];

            _createdBy = reader["created_by"].ToString();
            _updatedBy = reader["updated_by"].ToString();
            _personId = (int)reader["person_id"];
            if (_personId > 0)
            {
                Person p = new Person(_personId);
                _firstName = p.FirstName;
                _middleName = p.MiddleName;
                _lastName = p.LastName;
                _nickName = p.NickName;
                _fullName = p.FullName;
                _guid = p.PersonGUID.ToString();
            }

            _date = (DateTime)reader["date"];
            _type = (int)reader["type"];

            if (!reader.IsDBNull(reader.GetOrdinal("description")))
                _description = reader["description"].ToString();
            if (!reader.IsDBNull(reader.GetOrdinal("size")))
                _size = (int)reader["size"];
            if (!reader.IsDBNull(reader.GetOrdinal("amount")))
                _amount = (decimal)reader["amount"];
            if (!reader.IsDBNull(reader.GetOrdinal("notes")))
                _notes = reader["notes"].ToString();

            _givenTo = (int)reader["givento_id"];
            _callId = (int)reader["call_id"];
            _status = (int)reader["status"];

            _name = reader["name"].ToString();
            _phone = reader["phone"].ToString();
        }


        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterOffer()
        {

        }

        public ResourceCenterOffer(int Id)
        {
            SqlDataReader reader = new ResourceCenterOfferData().GetResourceCenterOfferByID(Id);
            if (reader.Read())
                LoadOffer(reader);
            reader.Close();
        }

        public ResourceCenterOffer(SqlDataReader reader)
        {
            LoadOffer(reader);
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterDocument : ArenaObjectBase
    {
        #region Private Members

        private int _Id = -1;
        private int _parent = 0;
        private int _parentId = 0;
        private string _name = string.Empty;
        private string _mime = string.Empty;
        private int _size = 0;
        private byte[] _data;

        private DateTime _dateCreated = DateTime.MinValue;      //General
        private DateTime _dateUpdated = DateTime.MinValue;      //General
        private string _createdBy = string.Empty;               //General
        private string _updatedBy = string.Empty;               //General

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            //set { _Id = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            //set { _dateCreated = value; }
        }

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            //set { _dateUpdated = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            //set { _updatedBy = value; }
        }

        public int Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Mime
        {
            get { return _mime; }
            set { _mime = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion

        #region Public Methods

        public void Save(int orgId, string userId, bool family)
        {
            SaveDocument(orgId, userId, family);
        }

        public static void Delete(int Id)
        {
            new ResourceCenterDocumentData().DeleteResourceCenterDocument(Id);
        }

        public void Delete()
        {

            // delete record
            ResourceCenterDocumentData DocumentData = new ResourceCenterDocumentData();
            DocumentData.DeleteResourceCenterDocument(_Id);

            _Id = -1;
        }

        #endregion

        #region Private Methods

        private void SaveDocument(int orgId, string userId, bool family)
        {
            _Id = new ResourceCenterDocumentData().SaveResourceCenterDocument(orgId, _Id, userId, _parent, _parentId, _name, _mime, _size, _data, family);
        }

        private void LoadDocument(SqlDataReader reader, bool readData)
        {
            _Id = (int)reader["id"];
            _dateCreated = (DateTime)reader["date_created"];
            _dateUpdated = (DateTime)reader["date_updated"];
            _createdBy = reader["created_by"].ToString();
            _updatedBy = reader["updated_by"].ToString();
            _parent = (int)reader["parent"];
            _parentId = (int)reader["parent_id"];
            _name = reader["name"].ToString();
            _size = (int)reader["size"];
            _mime = reader["mime"].ToString();

            if (readData)
            {
                if (!reader.IsDBNull(reader.GetOrdinal("data")))
                {
                    _data = new byte[_size];
                    reader.GetBytes(reader.GetOrdinal("data"), 0, _data, 0, _size);
                }
            }
        }


        #endregion

        #region Static Methods
        #endregion

        #region Constructors

        public ResourceCenterDocument()
        {

        }

        public ResourceCenterDocument(int Id)
        {
            SqlDataReader reader = new ResourceCenterDocumentData().GetResourceCenterDocumentByID(Id);
            if (reader.Read())
                LoadDocument(reader, true);
            reader.Close();
        }

        public ResourceCenterDocument(SqlDataReader reader)
        {
            LoadDocument(reader, false);
        }

        #endregion
    }

}
