using Doosy.Domain.Enum;
using Doosy.Framework.Domain;

namespace Doosy.Domain.Entities
{
    public class Person:Entity
    {
         Person()
        {

        }

        public static Person Create(string userId,string firstName,string surname, Gender gender, string createdBy)
        {
            var newperson=new Person();

            newperson.Id = userId;
            newperson.Firstname = firstName;
            newperson.Surname = surname;
            newperson.Gender = gender;
            newperson.CreatedBy = createdBy;

            return newperson;
        }

        public void UpdateFirstName(string firstname) {
            this.Firstname = firstname;
        }
        public void UpdateSurname(string surname)
        {
            this.Surname = surname;
        }

        public void UpdateGender(Gender gender)
        {
            this.Gender = gender;
        }

        public void UpdateStatus(EntityStatus status)
        {
            this.Status = status;
        }

        public string Id { get; private set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
    }
}
