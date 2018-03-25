using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
//using API;
//using TaskManagement.DAL;
using MongoDB.Bson;
 


namespace API.Models
{
    /// <summary>
    /// user class
    /// </summary>
    [DataContract]
    public partial class User 
    {
        
        [BsonId]
        public ObjectId Id { get; set; }

        
        [Required]
        [BsonElement("UserName")]
        public string UserName { get; set; }

         
        [Required]
        [BsonElement("FirstName")]
        public string FirstName { get; set; }

         
        [Required]
        [BsonElement("LastName")]
        public string LastName { get; set; }

        
        [BsonElement("Email")]
        public string Email { get; set; }

         
        [BsonElement("Phone")]
        public string Phone { get; set; }
        

        public enum TypeEnum
        {
            
            [BsonElement("Employee")]
            EmployeeEnum = 1,
             
            [BsonElement("manager")]
            ManagerEnum = 2
        }

        
        [BsonElement("Type")]
        public TypeEnum? Type { get; set; }

        ///// <summary>
        ///// Returns the string presentation of the object
        ///// </summary>
        ///// <returns>String presentation of the object</returns>
        //public override string ToString()
        //{
        //    var sb = new StringBuilder();
        //    sb.Append("class User {\n");
        //    sb.Append("  UserName: ").Append(UserName).Append("\n");
        //    sb.Append("  FirstName: ").Append(FirstName).Append("\n");
        //    sb.Append("  LastName: ").Append(LastName).Append("\n");
        //    sb.Append("  Email: ").Append(Email).Append("\n");
        //    sb.Append("  Phone: ").Append(Phone).Append("\n");
        //    sb.Append("  Type: ").Append(Type).Append("\n");
        //    sb.Append("}\n");
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Returns the JSON string presentation of the object
        ///// </summary>
        ///// <returns>JSON string presentation of the object</returns>
        //public string ToJson()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}

        ///// <summary>
        ///// Returns true if objects are equal
        ///// </summary>
        ///// <param name="obj">Object to be compared</param>
        ///// <returns>Boolean</returns>
        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj))
        //        return false;
        //    if (ReferenceEquals(this, obj))
        //        return true;
        //    return obj.GetType() == GetType() && Equals((User)obj);
        //}

        ///// <summary>
        ///// Returns true if User instances are equal
        ///// </summary>
        ///// <param name="other">Instance of User to be compared</param>
        ///// <returns>Boolean</returns>
        //public bool Equals(User other)
        //{
        //    if (ReferenceEquals(null, other))
        //        return false;
        //    if (ReferenceEquals(this, other))
        //        return true;

        //    return
        //        (
        //            UserName == other.UserName ||
        //            UserName != null &&
        //            UserName.Equals(other.UserName)
        //        ) &&
        //        (
        //            FirstName == other.FirstName ||
        //            FirstName != null &&
        //            FirstName.Equals(other.FirstName)
        //        ) &&
        //        (
        //            LastName == other.LastName ||
        //            LastName != null &&
        //            LastName.Equals(other.LastName)
        //        ) &&
        //        (
        //            Email == other.Email ||
        //            Email != null &&
        //            Email.Equals(other.Email)
        //        ) &&
        //        (
        //            Phone == other.Phone ||
        //            Phone != null &&
        //            Phone.Equals(other.Phone)
        //        ) &&
        //        (
        //            Type == other.Type ||
        //            Type != null &&
        //            Type.Equals(other.Type)
        //        );
        //}

        ///// <summary>
        ///// Gets the hash code
        ///// </summary>
        ///// <returns>Hash code</returns>
        //public override int GetHashCode()
        //{
        //    unchecked // Overflow is fine, just wrap
        //    {
        //        var hashCode = 41;
        //        // Suitable nullity checks etc, of course :)
        //        if (UserName != null)
        //            hashCode = hashCode * 59 + UserName.GetHashCode();
        //        if (FirstName != null)
        //            hashCode = hashCode * 59 + FirstName.GetHashCode();
        //        if (LastName != null)
        //            hashCode = hashCode * 59 + LastName.GetHashCode();
        //        if (Email != null)
        //            hashCode = hashCode * 59 + Email.GetHashCode();
        //        if (Phone != null)
        //            hashCode = hashCode * 59 + Phone.GetHashCode();
        //        if (Type != null)
        //            hashCode = hashCode * 59 + Type.GetHashCode();
        //        return hashCode;
        //    }
        //}

 

        //public static bool operator ==(User left, User right)
        //{
        //    return Equals(left, right);
        //}

        //public static bool operator !=(User left, User right)
        //{
        //    return !Equals(left, right);
        //}

 
    }
}