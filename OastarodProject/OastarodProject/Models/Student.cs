using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace OastarodProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrolmentDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Enrolment> Enrolments { get; set; }
    }
}