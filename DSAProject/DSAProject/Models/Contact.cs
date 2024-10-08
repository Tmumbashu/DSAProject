namespace DSAProject.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Comnstructor to initialize a contact
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Constructor to initialize a contact with name and phone number
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public void UpdatePhone(string newPhone)
        {
            Phone = newPhone;
            UpdatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Name} : {Phone}";
        }
    }
}
