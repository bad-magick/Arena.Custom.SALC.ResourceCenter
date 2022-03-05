using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Arena.DataLib;
using Arena.Custom.SALC.ResourceCenter.Entity;

namespace Arena.Custom.SALC.ResourceCenter.DataLayer

{

    public class ResourceCenterPersonData : SqlData
	{
		/// <summary>
		/// Class constructor.
		/// </summary>
		public ResourceCenterPersonData()
		{
		}

		/// <summary>
		/// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
		/// containing the FoodBag with the ID specified
		/// </summary>
		/// <param name="foodBagID">FoodBag ID</param>
		/// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
		public SqlDataReader GetResourceCenterPersonByID(int Id)
		{
			ArrayList lst = new ArrayList();

			lst.Add(new SqlParameter("@PersonId", Id));

			try
			{
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_client", lst);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				lst = null;
			}
		}
		
		public SqlDataReader GetResourceCenterPersonByPersonId(int personId)
		{
			ArrayList lst = new ArrayList();

			lst.Add(new SqlParameter("@PersonId", personId));

			try
			{
				return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_client", lst);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				lst = null;
			}
		}
		
		public SqlDataReader GetAllResourceCenterPersons(int orgId)
		{
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@FirstName", ""));
            lst.Add(new SqlParameter("@LastName", ""));
            lst.Add(new SqlParameter("@Phone", ""));
            lst.Add(new SqlParameter("@Street", ""));
            lst.Add(new SqlParameter("@ZipCode", ""));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_client", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
		}

        public SqlDataReader GetAllResourceCenterPersons(int orgId, string firstName, string lastName, string phone, string street, string zipCode)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@FirstName", firstName));
            lst.Add(new SqlParameter("@LastName", lastName));
            lst.Add(new SqlParameter("@Phone", phone));
            lst.Add(new SqlParameter("@Street", street));
            lst.Add(new SqlParameter("@ZipCode", zipCode));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_client", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetAllResourceCenterPersons(int orgId, string firstName, string lastName, string phone, string street, string zipCode, int helpIdExclude)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@FirstName", firstName));
            lst.Add(new SqlParameter("@LastName", lastName));
            lst.Add(new SqlParameter("@Phone", phone));
            lst.Add(new SqlParameter("@Street", street));
            lst.Add(new SqlParameter("@ZipCode", zipCode));
            lst.Add(new SqlParameter("@HelpIdExclude", helpIdExclude));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_client", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetFamily(int orgId, int personId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_misc_getfamilylist", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetHelpList(int helpId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@HelpId", helpId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_misc_getclientsonhelp", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int CountSimilars(string firstName, string lastName, string street, string zipCode, int excludeID)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@FirstName", firstName));
            lst.Add(new SqlParameter("@LastName", lastName));
            lst.Add(new SqlParameter("@Street", street));
            lst.Add(new SqlParameter("@ZipCode", zipCode));
            lst.Add(new SqlParameter("@Exclude", excludeID));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@COUNT";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteSqlDataReader("cust_sp_salc_rc_misc_clientcount", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
		
		/// <summary>
		/// deletes a FoodBag record.
		/// </summary>
		/// <param name="roleID">The poll_id key to delete.</param>
		public void DeleteResourceCenterPerson(int Id)
		{
			ArrayList lst = new ArrayList();

			lst.Add(new SqlParameter("@Id", Id));

			try
			{
				this.ExecuteNonQuery("cust_sp_salc_rc_del_client", lst);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				lst = null;
			}

		}

        public void BulkChangeAddress(int personId, string street, string city, string zip, string state, string county, string userId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@UserId", userId));
            lst.Add(new SqlParameter("@Street", street));
            lst.Add(new SqlParameter("@City", city));
            lst.Add(new SqlParameter("@Zip", zip));
            lst.Add(new SqlParameter("@State", state));
            lst.Add(new SqlParameter("@County", county));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_misc_bulkchangeaddress", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

		/// <summary>
		/// saves FoodBag record
		/// </summary>
		/// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
		public int SaveResourceCenterPerson(int orgId, int personId, int numAdults, int numChildren, string county, int helpRequested, string notes, string userId, string nickName, string firstName, string middleName, string lastName, string suffix, DateTime birthday, string gender, string email, string streetAddress, string city, string state, string postalCode, string ssn, string schoolDistrict, decimal incomeEmployment, decimal incomeUnemployment, decimal incomeMFIP, decimal incomeChildSupport, decimal incomeMA, decimal incomeSSISSDI, decimal incomeOther, decimal cashOnHand, decimal issuesOfNote, DateTime lasteDateWorked,
            int mstatus, int dlicense, int ebt, decimal foodSupport, DateTime assistanceApplied, string foodShelf, DateTime foodShelfVisit, string caseMgr1Name, string caseMgr1Agency, string caseMgr1Phone, string caseMgr2Name, string caseMgr2Agency, string caseMgr2Phone,
            string emgAssist1Agency, string emgAssist1CaseMgr, string emgAssist1Phone, DateTime emgAssist1Date, decimal emgAssist1Amount, int emgAssist1Status,
            string emgAssist2Agency, string emgAssist2CaseMgr, string emgAssist2Phone, DateTime emgAssist2Date, decimal emgAssist2Amount, int emgAssist2Status,
            int pastShelter, DateTime pastShelterDate, int pastUnsheltered, DateTime pastUnshelteredDate, int pastChemical, DateTime pastChemicalDate, int pastTransitional, DateTime pastTransitionalDate,
            int pastDoubled, DateTime pastDoubledDate, int pastEviction, DateTime pastEvictionDate, int pastForeclosure, DateTime pastForeclosureDate,
            string phoneHome, string phoneWork, string phoneMobile, string phoneOther, string caseMgr1Notes, string caseMgr2Notes, int empFreq, DateTime empDate,
            int mfipDay, DateTime childsupportDate, DateTime otherincomeDate, string message, int flag)
		{
			ArrayList lst = new ArrayList();
			
			//lst.Add(new SqlParameter("@id", Id));
			lst.Add(new SqlParameter("@ClientId", personId));
			lst.Add(new SqlParameter("@UserID", userId));
            lst.Add(new SqlParameter("@NumAdults", numAdults));         //used for 3rd party status
            lst.Add(new SqlParameter("@NumChildren", numChildren));
            lst.Add(new SqlParameter("@County", county));
            lst.Add(new SqlParameter("@HelpRequested", helpRequested));
            lst.Add(new SqlParameter("@Notes", notes));
            lst.Add(new SqlParameter("@NickName", nickName));
            lst.Add(new SqlParameter("@FirstName", firstName));
            lst.Add(new SqlParameter("@MiddleName", middleName));
            lst.Add(new SqlParameter("@LastName", lastName));
            lst.Add(new SqlParameter("@Suffix", suffix));
            lst.Add(new SqlParameter("@Birthday", birthday));
            lst.Add(new SqlParameter("@Gender", gender));
            lst.Add(new SqlParameter("@Email", email));
            lst.Add(new SqlParameter("@Street", streetAddress));
            lst.Add(new SqlParameter("@City", city));
            lst.Add(new SqlParameter("@State", state));
            lst.Add(new SqlParameter("@PostalCode", postalCode));
            lst.Add(new SqlParameter("@SSN", ssn));
            lst.Add(new SqlParameter("@SchoolDistrict", schoolDistrict));
            lst.Add(new SqlParameter("@IncomeEmployment", incomeEmployment));
            lst.Add(new SqlParameter("@IncomeMFIP", incomeMFIP));
            lst.Add(new SqlParameter("@IncomeMA", incomeMA));
            lst.Add(new SqlParameter("@IncomeChildSupport", incomeChildSupport));
            lst.Add(new SqlParameter("@IncomeUnemployment", incomeUnemployment));
            lst.Add(new SqlParameter("@IncomeSSISSDI", incomeSSISSDI));
            lst.Add(new SqlParameter("@IncomeOther", incomeOther));
            lst.Add(new SqlParameter("@CashOnHand", cashOnHand));
            lst.Add(new SqlParameter("@IssuesOfNote", issuesOfNote));
            lst.Add(new SqlParameter("@LastDateWorked", lasteDateWorked));
            lst.Add(new SqlParameter("@MaritalStatus", mstatus));
            lst.Add(new SqlParameter("@DriversLicense", dlicense));
            lst.Add(new SqlParameter("@EBT", ebt));
            lst.Add(new SqlParameter("@FoodSupport", foodSupport));
            lst.Add(new SqlParameter("@AssistanceApplied", assistanceApplied));
            lst.Add(new SqlParameter("@FoodShelf", foodShelf));
            lst.Add(new SqlParameter("@FoodShelfVisit", foodShelfVisit));
            lst.Add(new SqlParameter("@CaseMgr1Name", caseMgr1Name));
            lst.Add(new SqlParameter("@CaseMgr1Agency", caseMgr1Agency));
            lst.Add(new SqlParameter("@CaseMgr1Phone", caseMgr1Phone));
            lst.Add(new SqlParameter("@CaseMgr1Notes", caseMgr1Notes));
            lst.Add(new SqlParameter("@CaseMgr2Name", caseMgr2Name));
            lst.Add(new SqlParameter("@CaseMgr2Agency", caseMgr2Agency));
            lst.Add(new SqlParameter("@CaseMgr2Phone", caseMgr2Phone));
            lst.Add(new SqlParameter("@CaseMgr2Notes", caseMgr2Notes));
            lst.Add(new SqlParameter("@EmgAssist1Agency", emgAssist1Agency));
            lst.Add(new SqlParameter("@EmgAssist1CaseMgr", emgAssist1CaseMgr));
            lst.Add(new SqlParameter("@EmgAssist1Phone", emgAssist1Phone));
            lst.Add(new SqlParameter("@EmgAssist1Date", emgAssist1Date));
            lst.Add(new SqlParameter("@EmgAssist1Amount", emgAssist1Amount));
            lst.Add(new SqlParameter("@EmgAssist1Status", emgAssist1Status));
            lst.Add(new SqlParameter("@EmgAssist2Agency", emgAssist2Agency));
            lst.Add(new SqlParameter("@EmgAssist2CaseMgr", emgAssist2CaseMgr));
            lst.Add(new SqlParameter("@EmgAssist2Phone", emgAssist2Phone));
            lst.Add(new SqlParameter("@EmgAssist2Date", emgAssist2Date));
            lst.Add(new SqlParameter("@EmgAssist2Amount", emgAssist2Amount));
            lst.Add(new SqlParameter("@EmgAssist2Status", emgAssist2Status));
            lst.Add(new SqlParameter("@PastShelter", pastShelter));
            lst.Add(new SqlParameter("@PastShelterDate", pastShelterDate));
            lst.Add(new SqlParameter("@PastUnsheltered", pastUnsheltered));
            lst.Add(new SqlParameter("@PastUnshelteredDate", pastUnshelteredDate));
            lst.Add(new SqlParameter("@PastChemical", pastChemical));
            lst.Add(new SqlParameter("@PastChemicalDate", pastChemicalDate));
            lst.Add(new SqlParameter("@PastTransitional", pastTransitional));
            lst.Add(new SqlParameter("@PastTransitionalDate", pastTransitionalDate));
            lst.Add(new SqlParameter("@PastDoubled", pastDoubled));
            lst.Add(new SqlParameter("@PastDoubledDate", pastDoubledDate));
            lst.Add(new SqlParameter("@PastEviction", pastEviction));
            lst.Add(new SqlParameter("@PastEvictionDate", pastEvictionDate));
            lst.Add(new SqlParameter("@PastForeclosure", pastForeclosure));
            lst.Add(new SqlParameter("@PastForeclosureDate", pastForeclosureDate));
            lst.Add(new SqlParameter("@PhoneHome", phoneHome));
            lst.Add(new SqlParameter("@PhoneWork", phoneWork));
            lst.Add(new SqlParameter("@PhoneMobile", phoneMobile));
            lst.Add(new SqlParameter("@PhoneOther", phoneOther));
            lst.Add(new SqlParameter("@EmpFreq", empFreq));
            lst.Add(new SqlParameter("@EmpDate", empDate));
            lst.Add(new SqlParameter("@MFIPDay", mfipDay));
            lst.Add(new SqlParameter("@ChildSupportDate", childsupportDate));
            lst.Add(new SqlParameter("@OtherSourcesDate", otherincomeDate));
            lst.Add(new SqlParameter("@Message", message));
            lst.Add(new SqlParameter("@Flag", flag));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

			SqlParameter paramOut = new SqlParameter();
			paramOut.ParameterName = "@ID";
			paramOut.Direction = ParameterDirection.Output;
			paramOut.SqlDbType = SqlDbType.Int;
			lst.Add(paramOut);
			
			try
			{
				this.ExecuteNonQuery("cust_sp_salc_rc_save_client", lst);
				//return (int)((SqlParameter)(lst[lst.Count - 1])).Value;
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627) //Unique Key Violation
					return -1;
				else
					throw ex;
			}
			finally
			{
				lst = null;
			}
		}
	}

    public class ResourceCenterEventData : SqlData
    {
        public ResourceCenterEventData()
        {
        }

        public SqlDataReader GetAllResourceCenterEvents(int orgId, DateTime startDate, DateTime endDate, int personId, int helpId)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@StartDate", startDate));
            lst.Add(new SqlParameter("@EndDate", endDate));
            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@HelpSubTypeId", helpId));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_event", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }

    public class ResourceCenterHelpData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterHelpData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterHelpByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_help", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterHelps(int orgId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@PersonId", 0));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_help", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetAllResourceCenterHelps(int orgId, int personId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_help", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DeleteResourceCenterHelp(int helpId, int personId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@helpId", helpId));
            lst.Add(new SqlParameter("@personId", personId));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@CODE";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_help", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        public void AddNewLink(int helpId, int personId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@helpId", helpId));
            lst.Add(new SqlParameter("@personId", personId));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_create_helplink", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterHelp(int helpId, DateTime date, int type, Decimal amount, int size, string description, int subsedized, decimal subAmount, string subSource,
            string vendor, string complete, string assistedBy, DateTime dateCompleted, string resolution, int subType, string notes, string userId, string address, string city, string zip,
            string state, string county, int prototypeId)
        {
            ArrayList lst = new ArrayList();
            int iNewId = 0;

            lst.Add(new SqlParameter("@HelpId", helpId));
            lst.Add(new SqlParameter("@UserId", userId));
            lst.Add(new SqlParameter("@Date", date));
            lst.Add(new SqlParameter("@Type", type));
            lst.Add(new SqlParameter("@Amount", amount));
            lst.Add(new SqlParameter("@Size", size));
            lst.Add(new SqlParameter("@Description", description));
            lst.Add(new SqlParameter("@Subsidized", subsedized));
            lst.Add(new SqlParameter("@SubAmount", subAmount));
            lst.Add(new SqlParameter("@SubSource", subSource));
            lst.Add(new SqlParameter("@Vendor", vendor));
            lst.Add(new SqlParameter("@Complete", complete));
            lst.Add(new SqlParameter("@Assistant", assistedBy));
            lst.Add(new SqlParameter("@DateCompleted", dateCompleted));
            lst.Add(new SqlParameter("@Resolution", resolution));
            lst.Add(new SqlParameter("@SubType", subType));
            lst.Add(new SqlParameter("@Notes", notes));
            lst.Add(new SqlParameter("@Address", address));
            lst.Add(new SqlParameter("@City", city));
            lst.Add(new SqlParameter("@Zip", zip));
            lst.Add(new SqlParameter("@State", state));
            lst.Add(new SqlParameter("@County", county));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_help", lst);
                iNewId = Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }

            //If the helpId returned from SQL is not the same the one supplied to this function...
            //then a new record was created. In that case, generate the default help links, adding all
            //clients that have the same address on file. (Hackish method)
            if (iNewId != helpId) //We should also check to see if the prototypeId is valid, but we'll play this one fast and loose...
            {
                lst = new ArrayList();
                lst.Add(new SqlParameter("@helpid", iNewId));
                lst.Add(new SqlParameter("@personid", prototypeId));

                try
                {
                    //All we can do is hope for the best here
                    this.ExecuteNonQuery("cust_sp_salc_rc_misc_generatehelplinks", lst);
                }
                catch (SqlException ex)
                {
                    //A unique key violation should never happen since the SQL stored procedure should be able to detect this...
                    //If this error (#2627) ever comes up, something has gone very VERY wrong...
                    if (ex.Number == 2627) //Unique Key Violation
                        //Return the new ID anyway... it will show no one attached... allow the user to figure it out from here...
                        return iNewId;
                    else
                        throw ex;
                }
                finally
                {
                    lst = null;
                }
            }
            return iNewId;

            //We have no way of returning an error condition here since the only value passed back is the current helpId...
            //... hope and pray... fast and loose
            
            //If the second stored procedure fails to generate links, then we'll have an orphaned help entry...
            //Not a big deal so long as we INNER JOIN all SELECT statements for reports to cust_salc_rclients_help_links
        }
    }

    public class ResourceCenterHelpSubTypeData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterHelpSubTypeData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterHelpSubTypeByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_assistance", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterHelpSubTypes(int orgId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@Enabled", 1));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_assistance", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetAllResourceCenterHelpSubTypes(int orgId, bool includingDisabled)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@Enabled", includingDisabled ? 0 : 1));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_assistance", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterHelpSubType(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@SubTypeId", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_assistance", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterHelpSubType(int orgId, int subtypeId, string name, string units, int quantity, int amount, bool enabled)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@SubTypeId", subtypeId));
            lst.Add(new SqlParameter("@Name", name));
            lst.Add(new SqlParameter("@Units", units));
            lst.Add(new SqlParameter("@Quantity", quantity));
            lst.Add(new SqlParameter("@Amount", amount));
            lst.Add(new SqlParameter("@Enabled", enabled ? 1 : 0));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_assistance", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }

    public class ResourceCenterAccountData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterAccountData()
        {
        }

        public SqlDataReader GetResourceCenterAccountByID(int id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_account", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterAccounts(int helpId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@HelpId", helpId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_account", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterAccount(int id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@AccountId", id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_account", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        public int SaveResourceCenterAccount(int orgId, int accountId, int helpId, decimal amount, DateTime date, string note)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@AccountId", accountId));
            lst.Add(new SqlParameter("@HelpId", helpId));
            lst.Add(new SqlParameter("@Amount", amount));
            lst.Add(new SqlParameter("@Date", date));
            lst.Add(new SqlParameter("@Note", note));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_account", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }

    public class ResourceCenterAddressData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterAddressData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterHelpByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_address", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterAddresses()
        {
            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_address");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterAddress(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@Id", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_address", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterAddress(int addressId)
        {
            ArrayList lst = new ArrayList();

            //lst.Add(new SqlParameter("@id", Id));
            lst.Add(new SqlParameter("@Id", addressId));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_address", lst);
                //return (int)((SqlParameter)(lst[lst.Count - 1])).Value;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
            return 0;
        }
    }

    public class ResourceCenterMealData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterMealData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterMealByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_meal", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterMeals(int orgId)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@StartDate", new DateTime(1901, 1, 1)));
            lst.Add(new SqlParameter("@EndDate", new DateTime(2199, 12, 31)));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_meal");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetAllResourceCenterMeals(DateTime startDate, DateTime endDate, int orgId)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@StartDate", startDate));
            lst.Add(new SqlParameter("@EndDate", endDate));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_meal", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterMeal(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@MealId", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_meal", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterMeal(int mealId, string userId, DateTime date, int served, int meals, int dist, int pounds)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@MealId", mealId));
            lst.Add(new SqlParameter("@UserId", userId));
            lst.Add(new SqlParameter("@Date", date));
            lst.Add(new SqlParameter("@Served", served));
            lst.Add(new SqlParameter("@Meals", meals));
            lst.Add(new SqlParameter("@Dist", dist));
            lst.Add(new SqlParameter("@Pounds", pounds));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_meal", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }

    public class ResourceCenterCallData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterCallData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterCallByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_call", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterCalls(int personId)
        {
            ArrayList lst = new ArrayList();

            int zero = 0;
            lst.Add(new SqlParameter("@StartDate", new DateTime(1901, 1, 1)));
            lst.Add(new SqlParameter("@EndDate", new DateTime(2199, 1, 1)));
            lst.Add(new SqlParameter("@MessageFor", ""));
            lst.Add(new SqlParameter("@Search", ""));
            lst.Add(new SqlParameter("@Status", zero)); //reused for completed
            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@OrganizationId", zero));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_call", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetAllResourceCenterCalls(DateTime startDate, DateTime endDate, string messageFor, string search, int status, int orgId)
        {
            ArrayList lst = new ArrayList();

            int zero = 0;
            lst.Add(new SqlParameter("@StartDate", startDate));
            lst.Add(new SqlParameter("@EndDate", endDate));
            lst.Add(new SqlParameter("@MessageFor", messageFor));
            lst.Add(new SqlParameter("@Search", search));
            lst.Add(new SqlParameter("@Status", status)); //reused for completed
            lst.Add(new SqlParameter("@PersonId", zero));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_call", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterCall(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@CallId", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_call", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterCall(int orgId, int mealId, string userId, DateTime date, string name, string phone, string county, string msgFor, int hh,
            int recieve, int callType, int reqFood, int reqShelter, int reqRent, int reqUtility, int reqFurn, int reqOther, string notes, int completed, int personId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@CallId", mealId));
            lst.Add(new SqlParameter("@UserId", userId));
            lst.Add(new SqlParameter("@Date", date));
            lst.Add(new SqlParameter("@Name", name));
            lst.Add(new SqlParameter("@Phone", phone));
            lst.Add(new SqlParameter("@County", county));
            lst.Add(new SqlParameter("@MessageFor", msgFor));
            lst.Add(new SqlParameter("@HH", hh));
            lst.Add(new SqlParameter("@Recieve", recieve));
            lst.Add(new SqlParameter("@CallType", callType));
            lst.Add(new SqlParameter("@ReqFood", reqFood));
            lst.Add(new SqlParameter("@ReqShelter", reqShelter));
            lst.Add(new SqlParameter("@ReqRent", reqRent));
            lst.Add(new SqlParameter("@ReqUtility", reqUtility));
            lst.Add(new SqlParameter("@ReqFurn", reqFurn));
            lst.Add(new SqlParameter("@ReqOther", reqOther));
            lst.Add(new SqlParameter("@Notes", notes));
            lst.Add(new SqlParameter("@Status", completed));
            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_call", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }

    public class ResourceCenterDonationData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterDonationData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterDonationByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_donation", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterDonations(int orgId, DateTime startDate, DateTime endDate, string firstName, string lastName, int type)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@StartDate", startDate));
            lst.Add(new SqlParameter("@EndDate", endDate));
            lst.Add(new SqlParameter("@FirstName", firstName));
            lst.Add(new SqlParameter("@LastName", lastName));
            lst.Add(new SqlParameter("@Type", type));
            lst.Add(new SqlParameter("@OrganizationId", orgId));
            
            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_donation", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterDonation(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@DonationId", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_donation", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterDonation(int orgId, int mealId, string userId, int personId, DateTime date, int type, string description, int size, decimal amount, string notes)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@DonationId", mealId));
            lst.Add(new SqlParameter("@UserId", userId));
            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@Date", date));
            lst.Add(new SqlParameter("@Type", type));
            lst.Add(new SqlParameter("@Description", description));
            lst.Add(new SqlParameter("@Size", size));
            lst.Add(new SqlParameter("@Amount", amount));
            lst.Add(new SqlParameter("@Notes", notes));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_donation", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }

    public class ResourceCenterOfferData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterOfferData()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see> object
        /// containing the FoodBag with the ID specified
        /// </summary>
        /// <param name="foodBagID">FoodBag ID</param>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public SqlDataReader GetResourceCenterOfferByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_offer", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterOffers(int orgId, DateTime startDate, DateTime endDate, string firstName, string lastName, int type, int clientId, int callId, int status)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@StartDate", startDate));
            lst.Add(new SqlParameter("@EndDate", endDate));
            lst.Add(new SqlParameter("@FirstName", firstName));
            lst.Add(new SqlParameter("@LastName", lastName));
            lst.Add(new SqlParameter("@Type", type));
            lst.Add(new SqlParameter("@ClientId", clientId));
            lst.Add(new SqlParameter("@CallId", callId));
            lst.Add(new SqlParameter("@Status", status));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_offer", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterOffer(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@OfferId", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_offer", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterOffer(int orgId, int mealId, string userId, int personId, DateTime date, int type, string description, int size, decimal amount, string notes, int clientId, int callId, int status, string name, string phone)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@OfferId", mealId));
            lst.Add(new SqlParameter("@UserId", userId));
            lst.Add(new SqlParameter("@PersonId", personId));
            lst.Add(new SqlParameter("@GivenToId", clientId));
            lst.Add(new SqlParameter("@CallId", callId));
            lst.Add(new SqlParameter("@Date", date));
            lst.Add(new SqlParameter("@Type", type));
            lst.Add(new SqlParameter("@Description", description));
            lst.Add(new SqlParameter("@Size", size));
            lst.Add(new SqlParameter("@Amount", amount));
            lst.Add(new SqlParameter("@Status", status));
            lst.Add(new SqlParameter("@Name", name));
            lst.Add(new SqlParameter("@Phone", phone));
            lst.Add(new SqlParameter("@Notes", notes));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            SqlParameter paramOut = new SqlParameter();
            paramOut.ParameterName = "@ID";
            paramOut.Direction = ParameterDirection.Output;
            paramOut.SqlDbType = SqlDbType.Int;
            lst.Add(paramOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_save_offer", lst);
                return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Unique Key Violation
                    return -1;
                else
                    throw ex;
            }
            finally
            {
                lst = null;
            }
        }
    }

    public class ResourceCenterDocumentData : SqlData
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public ResourceCenterDocumentData()
        {
        }

        public SqlDataReader GetResourceCenterDocumentByID(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@id", Id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getbyid_document", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }
        }

        public SqlDataReader GetAllResourceCenterDocuments(int parent, int parentId)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@Parent", parent));
            lst.Add(new SqlParameter("@ParentId", parentId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_rc_getall_document", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// deletes a FoodBag record.
        /// </summary>
        /// <param name="roleID">The poll_id key to delete.</param>
        public void DeleteResourceCenterDocument(int Id)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@DocumentId", Id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_rc_del_document", lst);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                lst = null;
            }

        }

        /// <summary>
        /// saves FoodBag record
        /// </summary>
        /// <returns><see cref="System.Data.SqlClient.SqlDataReader">SqlDataReader</see></returns>
        public int SaveResourceCenterDocument(int orgId, int DocumentId, string userId, int parent, int parentId, string name, string mime, int size, byte[] data, bool family)
        {
            if (!family)
            {
                ArrayList lst = new ArrayList();
                lst.Add(new SqlParameter("@DocumentId", DocumentId));
                lst.Add(new SqlParameter("@Parent", parent));
                lst.Add(new SqlParameter("@ParentId", parentId));
                lst.Add(new SqlParameter("@Name", name));
                lst.Add(new SqlParameter("@Mime", mime));
                lst.Add(new SqlParameter("@Size", data.Length));
                SqlParameter spData = new SqlParameter("@Data", SqlDbType.VarBinary, -1);
                spData.Value = data;
                lst.Add(spData);
                lst.Add(new SqlParameter("@UserId", userId));

                SqlParameter paramOut = new SqlParameter();
                paramOut.ParameterName = "@ID";
                paramOut.Direction = ParameterDirection.Output;
                paramOut.SqlDbType = SqlDbType.Int;
                lst.Add(paramOut);

                try
                {
                    this.ExecuteNonQuery("cust_sp_salc_rc_save_document", lst);
                    return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) //Unique Key Violation
                        return -1;
                    else
                        throw ex;
                }
                finally
                {
                    lst = null;
                }
            }
            else
            {
                foreach (ResourceCenterPerson p in ResourceCenterPersonCollection.LoadAll(orgId, parentId))
                {
                    ArrayList lst = new ArrayList();
                    int iId = 0;
                    lst.Add(new SqlParameter("@DocumentId", iId));
                    lst.Add(new SqlParameter("@Parent", parent));
                    lst.Add(new SqlParameter("@ParentId", p.PersonId));
                    lst.Add(new SqlParameter("@Name", name));
                    lst.Add(new SqlParameter("@Mime", mime));
                    lst.Add(new SqlParameter("@Size", data.Length));
                    SqlParameter spData = new SqlParameter("@Data", SqlDbType.VarBinary, -1);
                    spData.Value = data;
                    lst.Add(spData);
                    lst.Add(new SqlParameter("@UserId", userId));

                    SqlParameter paramOut = new SqlParameter();
                    paramOut.ParameterName = "@ID";
                    paramOut.Direction = ParameterDirection.Output;
                    paramOut.SqlDbType = SqlDbType.Int;
                    lst.Add(paramOut);

                    try
                    {
                        this.ExecuteNonQuery("cust_sp_salc_rc_save_document", lst);
                        //return Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) //Unique Key Violation
                            return -1;
                        else
                            throw ex;
                    }
                    finally
                    {
                        lst = null;
                    }
                }
                return this.SaveResourceCenterDocument(orgId, 0, userId, parent, parentId, name, mime, size, data, false);
            }
        }
    }

}


