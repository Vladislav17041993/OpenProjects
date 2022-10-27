using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PetStore3.SupportLibrary.Core.RestSharpClient.Models.StoreModels
{
    public class Order
    {
        private long? id;
        private long? petId;
        private int? quantity;
        private string? shipDate;
        private OrderStatus? status;
        private bool? complete;

        public Order()
        {
            OrderSerializeRules = new OrderSerializeRules();
        }

        [JsonProperty("id")]
        public long? Id
        {
            get => id;
            set { OrderSerializeRules.SerializeId = true; id = value; }
        }

        [JsonProperty("petId")]
        public long? PetId
        {
            get => petId;
            set { OrderSerializeRules.SerializePetId = true; petId = value; }
        }

        [JsonProperty("quantity")]
        public int? Quantity
        {
            get => quantity;
            set { OrderSerializeRules.SerializeQuantity = true; quantity = value; }
        }

        [JsonProperty("shipDate")]
        public string? ShipDate
        {
            get => shipDate;
            set { OrderSerializeRules.SerializeShipDate = true; shipDate = value; }
        }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus? Status
        {
            get => status;
            set { OrderSerializeRules.SerializeStatus = true; status = value; }
        }

        [JsonProperty("complete")]
        public bool? Complete
        {
            get => complete;
            set { OrderSerializeRules.SerializeComplete = true; complete = value; }
        }

        #region Serialization rules
        [JsonIgnore]
        public OrderSerializeRules OrderSerializeRules;

        public bool ShouldSerializeId() { return OrderSerializeRules.SerializeId; }
        public bool ShouldSerializePetId() { return OrderSerializeRules.SerializePetId; }
        public bool ShouldSerializeQuantity() { return OrderSerializeRules.SerializeQuantity; }
        public bool ShouldSerializeShipDate() { return OrderSerializeRules.SerializeShipDate; }
        public bool ShouldSerializeStatus() { return OrderSerializeRules.SerializeStatus; }
        public bool ShouldSerializeComplete() { return OrderSerializeRules.SerializeComplete; }
        #endregion

        #region Deserialization rules

        #endregion
    }   

    public class OrderSerializeRules
    {
        public bool SerializeId { get; set; }
        public bool SerializePetId { get; set; }
        public bool SerializeQuantity { get; set; }
        public bool SerializeShipDate { get; set; }
        public bool SerializeStatus { get; set; }
        public bool SerializeComplete { get; set; }

        public OrderSerializeRules()
        {
            SerializeId = false;
            SerializePetId = false;
            SerializeQuantity = false;
            SerializeShipDate = false;
            SerializeStatus = false;
            SerializeComplete = false;
        }
    }

    public enum OrderStatus
    {

        [EnumMember(Value = "placed")]
        Placed = 0,

        [EnumMember(Value = "approved")]
        Approved = 1,

        [EnumMember(Value = "delivered")]
        Delivered = 2,

        [EnumMember(Value = "notExist")]
        NotExistStatus = 97,

        [EnumMember(Value = "")]
        EmptyStatus = 98,

        [EnumMember(Value = null)]
        NullStatus = 99,
    }
}
