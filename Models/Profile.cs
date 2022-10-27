namespace spw_first_webapp.Model
{
    public class MyProfile
    {
       public Profile ProfileEN { get; set; }
       public Profile ProfileTH { get; set; }
    }

    public class Profile
    {
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }

    public class Contact
    {
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }

    public class Address
    {
        public string HouseNo { get; set; }
        public string RoomNo { get; set; }
        public string Building { get; set; }
        public string MooNo { get; set; }
        public string Village { get; set; }
        public string SubLane { get; set; }
        public string Lane { get; set; }
        public string Road { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string FullAddress { get; set; }
    }
}
