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


namespace API.Models {
    /// <summary>
    /// A configuration document for workflow TaskConfigs. Workflows are comprised of TaskConfig objects, which are stored in a Workflow object&#39;s \\\&quot;TaskConfigs\\\&quot; map.
    /// </summary>
    [DataContract]
    public partial class TaskConfig: IEquatable<TaskConfig> {
        /// <summary>
        /// Uniquely identifies a TaskConfigConfig.
        /// </summary>
        /// <value>Uniquely identifies a TaskConfigConfig.</value>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The display name of the TaskConfigConfig.
        /// </summary>
        /// <value>The display name of the TaskConfigConfig.</value>
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Describes a TaskConfig&#39;s purpose.
        /// </summary>
        /// <value>Describes a TaskConfig&#39;s purpose.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// uri of markdown document
        /// </summary>
        /// <value>uri of markdown document</value>
        [DataMember(Name = "employeeInstructions")]
        public string EmployeeInstructions { get; set; }

        /// <summary>
        /// uri of markdown document
        /// </summary>
        /// <value>uri of markdown document</value>
        [DataMember(Name = "managerInstructions")]
        public string ManagerInstructions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("class TaskConfig {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EmployeeInstructions: ").Append(EmployeeInstructions).Append("\n");
            sb.Append("  ManagerInstructions: ").Append(ManagerInstructions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj) {
            if(ReferenceEquals(null, obj))
                return false;
            if(ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((TaskConfig)obj);
        }

        /// <summary>
        /// Returns true if TaskConfig instances are equal
        /// </summary>
        /// <param name="other">Instance of TaskConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskConfig other) {
            if(ReferenceEquals(null, other))
                return false;
            if(ReferenceEquals(this, other))
                return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) &&
                (
                    EmployeeInstructions == other.EmployeeInstructions ||
                    EmployeeInstructions != null &&
                    EmployeeInstructions.Equals(other.EmployeeInstructions)
                ) &&
                (
                    ManagerInstructions == other.ManagerInstructions ||
                    ManagerInstructions != null &&
                    ManagerInstructions.Equals(other.ManagerInstructions)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if(Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if(Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if(Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if(EmployeeInstructions != null)
                    hashCode = hashCode * 59 + EmployeeInstructions.GetHashCode();
                if(ManagerInstructions != null)
                    hashCode = hashCode * 59 + ManagerInstructions.GetHashCode();
                return hashCode;
            }
        }
        

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(TaskConfig left, TaskConfig right) {
            return Equals(left, right);
        }

        public static bool operator !=(TaskConfig left, TaskConfig right) {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}