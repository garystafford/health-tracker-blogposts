using System.Runtime.Serialization;
using System.ServiceModel;

namespace HealthTracker.WcfService
{
    [ServiceContract]
    public interface IHealthTrackerService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        bool CreatePerson(string newName);

        [OperationContract]
        int FindPerson(string newName);

        [OperationContract]
        bool CreateActivity(int personId);

        [OperationContract]
        bool CreateMeals(int personId);

        [OperationContract]
        bool UpdateOrAddHydration(int personId);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfHealthTracker.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
