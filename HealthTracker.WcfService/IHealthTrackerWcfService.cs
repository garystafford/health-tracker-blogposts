using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using HealthTracker.DataAccess.DbFirst;

namespace HealthTracker.WcfService
{
    [ServiceContract]
    public interface IHealthTrackerWcfService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetPersonId?name={personName}",
            Method = "GET")]
        int GetPersonId(string personName);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetPeople",
            Method = "GET")]
        List<Person> GetPeople();

        [OperationContract]
        [WebInvoke(UriTemplate = "GetPersonSummaryStoredProc?id={personId}",
            Method = "GET")]
        List<GetPersonSummary_Result> GetPersonSummaryStoredProc(int personId);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertPerson",
            Method = "POST")]
        bool InsertPerson(Person person);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePerson",
            Method = "PUT")]
        bool UpdatePerson(Person person);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeletePerson?id={personId}",
            Method = "DELETE")]
        bool DeletePerson(int personId);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateOrInsertHydration?id={personId}",
            Method = "POST")]
        bool UpdateOrInsertHydration(int personId);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertActivity",
            Method = "POST")]
        bool InsertActivity(Activity activity);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteActivity?id={activityId}",
            Method = "DELETE")]
        bool DeleteActivity(int activityId);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetActivities?id={personId}",
            Method = "GET")]
        List<ActivityDetail> GetActivities(int personId);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertMeal",
            Method = "POST")]
        bool InsertMeal(Meal meal);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteMeal?id={mealId}",
            Method = "DELETE")]
        bool DeleteMeal(int mealId);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetMeals?id={personId}",
            Method = "GET")]
        List<MealDetail> GetMeals(int personId);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetPersonSummaryView?id={personId}",
            Method = "GET")]
        List<PersonSummaryView> GetPersonSummaryView(int personId);
    }
}