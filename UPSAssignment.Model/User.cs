using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace UPSAssignment.Model
{
    public class User
    {
        public enum SexOfPerson
        {
            Male,
            Female,
            NA
        }

        public enum UserStatus
        {
            Active,
            Inactive,
            NA
        }
        private string _name;

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                    Console.WriteLine("Error! Name must be less than 51 characters!");
                else
                    _name = value;
            }
        }



        private int _id;
        [JsonProperty("id")]
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private string _email;
        [JsonProperty("email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private SexOfPerson _gender;
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SexOfPerson Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private UserStatus _status;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _created_at;
        [JsonProperty("created_at")]
        public DateTime Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        private DateTime _updated_at;
        [JsonProperty("updated_at")]
        public DateTime Updated_At
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }


        public User(string name, int id, string email, SexOfPerson sex, UserStatus status)
        {
            ID = id;
            Name = name;
            Email = email;
            Gender = sex;
            Status = status;
        }

        public User(string name, int id, string email, SexOfPerson sex, UserStatus status,DateTime created_at,DateTime updated_at)
        {
            ID = id;
            Name = name;
            Email = email;
            Gender = sex;
            Status = status;
            Created_At = created_at;
            Updated_At = updated_at;

        }
    }

}
