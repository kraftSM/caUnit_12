using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caU12Hw1
{
    public class User
    {
        //public int UserId { get; set; }        
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }
        public User(string login, string name, bool isPremium)
        {
            Login = login;
            Name = name;
            IsPremium = isPremium;

        }
        public override string ToString()
        {
            return "Login: " + Login + "   Name: " + Name
                + "   IsPremium: " + IsPremium;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            User objAsPart = obj as User;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        //public override int GetHashCode()
        //{
        //    return UserId;
        //}
        public bool Equals(User other)
        {
            if (other == null) return false;
            //return (this.UserId.Equals(other.UserId)); // ?? по ID как по первичному ключу??
            return (this.Login.Equals(other.Login));
        }

    }

}
