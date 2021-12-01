
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_27_Problem
{
     public class ContactPerson
    {
        public string FirstName;
        public string LastName;
        public string PhoneNo;
        public string Email;
        public string State;
        public string City;
        public string Address;
        public string Zip;
        public string Filepath = @"C:\Users\MY PC\Desktop\BridgeLabz\Day_27_Problem\AddressBook.txt";

        public List<ContactPerson> addressBookList = new List<ContactPerson>();
        public Dictionary<string, ContactPerson> AddressBook = new Dictionary<string, ContactPerson>();
        public Dictionary<string, ContactPerson> CityBook = new Dictionary<string, ContactPerson>();
        public Dictionary<string, ContactPerson> StateAddress = new Dictionary<string, ContactPerson>();
        

        
        public ContactPerson(string firstname, string lastname, string phoneno, string email,  string state, string city, string address, string zip)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNo = phoneno;
            this.Email = email;
            this.State = state;
            this.City = city;
            this.Address = address;
            this.Zip = zip;
        }
        public void AddContact(ContactPerson contactperson)
        {
            addressBookList.Add(contactperson);
            AddressBook.Add(contactperson.FirstName, contactperson);
            CityBook.Add(contactperson.FirstName, contactperson);
            StateAddress.Add(contactperson.FirstName, contactperson);

            using (StreamWriter write = File.AppendText(Filepath))
            {
                for (int i=0; i < addressBookList.Count; i++)
                {
                    write.WriteLine(addressBookList[i].FirstName);
                    write.WriteLine(addressBookList[i].LastName);
                    write.WriteLine(addressBookList[i].PhoneNo);
                    write.WriteLine(addressBookList[i].Email);
                    write.WriteLine(addressBookList[i].State);
                    write.WriteLine(addressBookList[i].City);
                    write.WriteLine(addressBookList[i].Address);
                    write.WriteLine(addressBookList[i].Zip);
                    write.WriteLine("******************************************");
                }
                write.Close();
                Console.WriteLine("All Data Is Added To AddressBook Text File");
                string allText = File.ReadAllText(Filepath);
                Console.WriteLine("All Data In AddressBook Text File");
            }
        }
        public void editContact(ContactPerson contactperson)
        {
            Console.WriteLine("Please Select Follwing Option To Change \n");
            Console.WriteLine(" 1.Firs tName \n 2.Last Name \n 3.Phone No \n 4.Email");
            int ChooseOption = Convert.ToInt32(Console.ReadLine());
            switch (ChooseOption)
            {
                case 1:
                    Console.WriteLine("Please enter first name");
                    contactperson.FirstName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Please enter last name");
                    contactperson.LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Please enter phone number");
                    contactperson.PhoneNo = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Please enter email");
                    contactperson .Email = Console.ReadLine();
                    break;
            }
        }
        public void DeleteContact()
        {
            string Delete;
            do
            {
                Console.WriteLine("Would you like tyo delete a contact (Y/N)");
                Delete = Convert.ToString(Console.ReadLine());
                if (Delete.ToUpper() == "Y")
                {
                    Console.WriteLine("Enter contact first Name");
                    string firstname = Convert.ToString(Console.ReadLine());
                    var findcontact = addressBookList.Find(x => x.FirstName == firstname);
                    if (findcontact != null)
                    {
                        addressBookList.Remove(findcontact);
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid");
                    }
                }
            }
            while (Delete.ToUpper() == "Y");
        }
        public void DisplayAddressBook()
        {
            Console.WriteLine("your addressbokk contact list are \n");

            foreach(ContactPerson contactList in addressBookList)
            {
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n",
                contactList.FirstName, contactList.LastName, contactList.State, contactList.City, contactList.Address, contactList.Zip, contactList.PhoneNo, contactList.Email);
            }
        }

        public void sortedData()
        {
            AddressBookComparer bookComparer = new AddressBookComparer(AddressBookComparer.SortByField.FirstNmae);
            addressBookList.Sort(bookComparer);

            foreach(var list in addressBookList)
            {
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n",
                     list.FirstName, list.LastName, list.State, list.City, list.Address, list.Zip, list.PhoneNo, list.Email);
            }
        }
    }
}
