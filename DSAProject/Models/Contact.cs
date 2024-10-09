using System.ComponentModel.DataAnnotations;

namespace DSAProject.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^0\d{4}$", ErrorMessage = "Phone number must start with '0' and be exactly 5 digits.")]
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
