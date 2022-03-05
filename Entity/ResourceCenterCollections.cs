using System;
using System.Data.SqlClient;
using Arena.Core;
using Arena.Custom.SALC.ResourceCenter.DataLayer;

namespace Arena.Custom.SALC.ResourceCenter.Entity
{

    [Serializable]
    public class ResourceCenterPersonCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterPerson this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterPerson)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterPersonCollection()
        {
        }

        public ResourceCenterPersonCollection(int personId)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetResourceCenterPersonByID(personId);
            while (reader.Read())
                this.Add(new ResourceCenterPerson(reader));
            reader.Close();
        }

        public ResourceCenterPersonCollection(int orgId, int personId)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetFamily(orgId, personId);
            while (reader.Read())
                this.Add(new ResourceCenterPerson(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterPerson item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterPerson item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods
        public static ResourceCenterPersonCollection LoadAll(int orgId, bool all)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetAllResourceCenterPersons(orgId);
            ResourceCenterPersonCollection collection = new ResourceCenterPersonCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterPerson(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterPersonCollection LoadAll(int orgId, string firstName, string lastName, string phone)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetAllResourceCenterPersons(orgId, firstName, lastName, phone, "", "");
            ResourceCenterPersonCollection collection = new ResourceCenterPersonCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterPerson(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterPersonCollection LoadAll(int orgId, string firstName, string lastName, string phone, string street, string zipCode)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetAllResourceCenterPersons(orgId, firstName, lastName, phone, street, zipCode);
            ResourceCenterPersonCollection collection = new ResourceCenterPersonCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterPerson(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterPersonCollection LoadAll(int orgId, string firstName, string lastName, string phone, string street, string zipCode, int helpIdExclude)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetAllResourceCenterPersons(orgId, firstName, lastName, phone, street, zipCode, helpIdExclude);
            ResourceCenterPersonCollection collection = new ResourceCenterPersonCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterPerson(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterPersonCollection LoadAll(int orgId, int personId)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetFamily(orgId, personId);
            ResourceCenterPersonCollection collection = new ResourceCenterPersonCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterPerson(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterPersonCollection LoadAll(int helpId)
        {
            SqlDataReader reader = new ResourceCenterPersonData().GetHelpList( helpId);
            ResourceCenterPersonCollection collection = new ResourceCenterPersonCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterPerson(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterEventCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterEvent this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterEvent)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterEventCollection()
        {
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterEvent item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterEvent item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterEventCollection LoadAll(int orgId, DateTime startDate, DateTime endDate, int personId, int helpId)
        {
            SqlDataReader reader = new ResourceCenterEventData().GetAllResourceCenterEvents(orgId, startDate, endDate, personId, helpId);
            ResourceCenterEventCollection collection = new ResourceCenterEventCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterEvent(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterHelpCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterHelp this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterHelp)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterHelpCollection()
        {
        }

        public ResourceCenterHelpCollection(int orgId, int personId)
        {
            SqlDataReader reader = new ResourceCenterHelpData().GetAllResourceCenterHelps(orgId, personId);
            while (reader.Read())
                this.Add(new ResourceCenterHelp(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterHelp item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterHelp item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterHelpCollection LoadAll(int orgId, int personId)
        {
            SqlDataReader reader = new ResourceCenterHelpData().GetAllResourceCenterHelps(orgId, personId);
            ResourceCenterHelpCollection collection = new ResourceCenterHelpCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterHelp(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterHelpSubTypeCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterHelpSubType this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterHelpSubType)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterHelpSubTypeCollection()
        {
        }

        public ResourceCenterHelpSubTypeCollection(int orgId)
        {
            SqlDataReader reader = new ResourceCenterHelpSubTypeData().GetAllResourceCenterHelpSubTypes(orgId);
            while (reader.Read())
                this.Add(new ResourceCenterHelpSubType(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterHelpSubType item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterHelpSubType item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterHelpSubTypeCollection LoadAll(int orgId)
        {
            SqlDataReader reader = new ResourceCenterHelpSubTypeData().GetAllResourceCenterHelpSubTypes(orgId);
            ResourceCenterHelpSubTypeCollection collection = new ResourceCenterHelpSubTypeCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterHelpSubType(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterAccountCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterAccount this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterAccount)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterAccountCollection()
        {
        }

        public ResourceCenterAccountCollection(int Id)
        {
            SqlDataReader reader = new ResourceCenterAccountData().GetResourceCenterAccountByID(Id);
            while (reader.Read())
                this.Add(new ResourceCenterAccount(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterAccount item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterAccount item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterAccountCollection LoadAll(int helpId)
        {
            SqlDataReader reader = new ResourceCenterAccountData().GetAllResourceCenterAccounts(helpId);
            ResourceCenterAccountCollection collection = new ResourceCenterAccountCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterAccount(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterMealCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterMeal this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterMeal)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterMealCollection()
        {
        }

        public ResourceCenterMealCollection(int mealId)
        {
            SqlDataReader reader = new ResourceCenterMealData().GetResourceCenterMealByID(mealId);
            while (reader.Read())
                this.Add(new ResourceCenterMeal(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterMeal item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterMeal item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterMealCollection LoadAll(int orgId)
        {
            SqlDataReader reader = new ResourceCenterMealData().GetAllResourceCenterMeals(orgId);
            ResourceCenterMealCollection collection = new ResourceCenterMealCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterMeal(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterMealCollection LoadAll(DateTime startDate, DateTime endDate, int orgId)
        {
            SqlDataReader reader = new ResourceCenterMealData().GetAllResourceCenterMeals(startDate, endDate, orgId);
            ResourceCenterMealCollection collection = new ResourceCenterMealCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterMeal(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterCallCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterCall this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterCall)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterCallCollection()
        {
        }

        public ResourceCenterCallCollection(int personId)
        {
            SqlDataReader reader = new ResourceCenterCallData().GetAllResourceCenterCalls(personId);
            while (reader.Read())
                this.Add(new ResourceCenterCall(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterCall item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterCall item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterCallCollection LoadAll(int status, int orgId)
        {
            SqlDataReader reader = new ResourceCenterCallData().GetAllResourceCenterCalls(Convert.ToDateTime("1/1/1901"), Convert.ToDateTime("12/31/2199"),
                "%", "%", status, orgId);
            ResourceCenterCallCollection collection = new ResourceCenterCallCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterCall(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterCallCollection LoadAll(DateTime startDate, DateTime endDate, string messageFor, string search, int status, int orgId)
        {
            DateTime newEndDate = DateTime.MinValue;
            if (startDate == endDate)
            {
                newEndDate = startDate.AddHours(23.9);
            }
            else
            {
                newEndDate = endDate;
            }
            string newSearch = string.Empty;
            if (search == "")
            {
                newSearch = "%";
            }
            else
            {
                newSearch = search;
            }
            SqlDataReader reader = new ResourceCenterCallData().GetAllResourceCenterCalls(startDate, newEndDate, messageFor, newSearch, status, orgId);
            ResourceCenterCallCollection collection = new ResourceCenterCallCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterCall(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterDonationCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterDonation this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterDonation)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterDonationCollection()
        {
        }

        public ResourceCenterDonationCollection(int Id)
        {
            SqlDataReader reader = new ResourceCenterDonationData().GetResourceCenterDonationByID(Id);
            while (reader.Read())
                this.Add(new ResourceCenterDonation(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterDonation item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterDonation item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterDonationCollection LoadAll(int orgId, DateTime startDate, DateTime endDate, string firstName, string lastName, int type)
        {
            SqlDataReader reader = new ResourceCenterDonationData().GetAllResourceCenterDonations(orgId, startDate, endDate, firstName, lastName, type);
            ResourceCenterDonationCollection collection = new ResourceCenterDonationCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterDonation(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterDonationCollection LoadAll(int orgId)
        {
            SqlDataReader reader = new ResourceCenterDonationData().GetAllResourceCenterDonations(orgId, Convert.ToDateTime("1/1/1901"), Convert.ToDateTime("12/31/2199"), "%", "%", 0);
            ResourceCenterDonationCollection collection = new ResourceCenterDonationCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterDonation(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterDonationTypeCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterHelpSubType this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterHelpSubType)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterDonationTypeCollection()
        {
        }

        public ResourceCenterDonationTypeCollection(int orgId)
        {
            this.Add(new ResourceCenterHelpSubType(orgId, 0, "Monitary", "", false, true));
            SqlDataReader reader = new ResourceCenterHelpSubTypeData().GetAllResourceCenterHelpSubTypes(orgId);
            while (reader.Read())
                this.Add(new ResourceCenterHelpSubType(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterHelpSubType item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterHelpSubType item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterDonationTypeCollection LoadAll(int orgId)
        {
            SqlDataReader reader = new ResourceCenterHelpSubTypeData().GetAllResourceCenterHelpSubTypes(orgId);
            ResourceCenterDonationTypeCollection collection = new ResourceCenterDonationTypeCollection();
            collection.Add(new ResourceCenterHelpSubType(orgId, 0, "Monitary", "", false, true));
            while (reader.Read())
            {
                collection.Add(new ResourceCenterHelpSubType(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterDonationTypeCollection LoadAllWithBlank(int orgId)
        {
            SqlDataReader reader = new ResourceCenterHelpSubTypeData().GetAllResourceCenterHelpSubTypes(orgId);
            ResourceCenterDonationTypeCollection collection = new ResourceCenterDonationTypeCollection();
            collection.Add(new ResourceCenterHelpSubType(orgId, -1, "", "", false, false));
            collection.Add(new ResourceCenterHelpSubType(orgId, 0, "Monitary", "", false, true));
            while (reader.Read())
            {
                collection.Add(new ResourceCenterHelpSubType(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterOfferCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterOffer this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterOffer)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterOfferCollection()
        {
        }

        public ResourceCenterOfferCollection(int Id)
        {
            SqlDataReader reader = new ResourceCenterOfferData().GetResourceCenterOfferByID(Id);
            while (reader.Read())
                this.Add(new ResourceCenterOffer(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterOffer item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterOffer item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterOfferCollection LoadAll(int orgId, int personId)
        {
            SqlDataReader reader = new ResourceCenterOfferData().GetAllResourceCenterOffers(orgId, new DateTime(1901, 1, 1), new DateTime(2199, 12, 31), "%", "%", -1, personId, 0, 0);
            ResourceCenterOfferCollection collection = new ResourceCenterOfferCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterOffer(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterOfferCollection LoadAll(int orgId, DateTime startDate, DateTime endDate, string firstName, string lastName, int type, int status)
        {
            SqlDataReader reader = new ResourceCenterOfferData().GetAllResourceCenterOffers(orgId, startDate, endDate, firstName, lastName, type, 0, 0, status);
            ResourceCenterOfferCollection collection = new ResourceCenterOfferCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterOffer(reader));
            }
            reader.Close();
            return collection;
        }

        public static ResourceCenterOfferCollection LoadAll(int orgId)
        {
            SqlDataReader reader = new ResourceCenterOfferData().GetAllResourceCenterOffers(orgId, Convert.ToDateTime("1/1/1901"), Convert.ToDateTime("12/31/2199"), "%", "%", 0, 0, 0, 0);
            ResourceCenterOfferCollection collection = new ResourceCenterOfferCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterOffer(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

    [Serializable]
    public class ResourceCenterDocumentCollection : ArenaCollectionBase
    {
        #region Class Indexers

        public new ResourceCenterDocument this[int index]
        {
            get
            {
                if (this.List.Count > 0)
                {
                    return (ResourceCenterDocument)this.List[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.List[index] = value;
            }
        }

        #endregion

        #region Constructors

        public ResourceCenterDocumentCollection()
        {
        }

        public ResourceCenterDocumentCollection(int DocumentId)
        {
            SqlDataReader reader = new ResourceCenterDocumentData().GetResourceCenterDocumentByID(DocumentId);
            while (reader.Read())
                this.Add(new ResourceCenterDocument(reader));
            reader.Close();
        }

        #endregion

        #region Public Methods

        public void Add(ResourceCenterDocument item)
        {
            this.List.Add(item);
        }

        public void Insert(int index, ResourceCenterDocument item)
        {
            this.List.Insert(index, item);
        }

        #endregion

        #region Static Methods

        public static ResourceCenterDocumentCollection LoadAll(int parent, int parentId)
        {
            SqlDataReader reader = new ResourceCenterDocumentData().GetAllResourceCenterDocuments(parent, parentId);
            ResourceCenterDocumentCollection collection = new ResourceCenterDocumentCollection();
            while (reader.Read())
            {
                collection.Add(new ResourceCenterDocument(reader));
            }
            reader.Close();
            return collection;
        }

        #endregion
    }

}