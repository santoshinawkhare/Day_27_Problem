using System;
using System.Linq;

namespace Day_27_Problem
{
    class Program
    {
        static string fName, lName, state, city, address, zip, phone, email;
        static string Add, Edit;
        static void Main(string[] args)
        {
            ContactPerson contact = new ContactPerson(fName, lName, state, city, address, zip, phone, email);

            Console.WriteLine("Welcome to Address Book Program\n");
            Console.WriteLine("Please select following options\n");
            Console.WriteLine(" 1.UC_1\n 2.UC_2\n 3.UC_3\n 4.UC_4\n 5.UC_8\n 6.UC_9\n 7.UC_10\n 8.UC_11\n 9.UC_13\n");
            int Option = Convert.ToInt32(Console.ReadLine());

            switch (Option)
            {
                case 1:
                    var newContact = AddNewContact(contact);
                    contact.AddContact(newContact);
                    contact.DisplayAddressBook();
                    goto case 2;

                case 2:
                    do
                    {
                        Console.WriteLine("Would you like to add a new contact (Y/N)");
                        Add = Convert.ToString(Console.ReadLine());
                        if (Add.ToUpper() == "Y")
                        {
                            Console.WriteLine("Enter contact first name");
                            string firstName = Convert.ToString(Console.ReadLine());
                            var findContact = contact.addressBookList.Find(x => x.FirstName == firstName);
                            if (findContact != null)
                            {
                                Console.WriteLine("First Name you have entered is already exist");
                                Console.WriteLine("Please try with differe first name");
                            }
                            else
                            {
                                Console.WriteLine("First name you have entered does not exist continue");
                                contact.AddContact(AddNewContact(contact));
                            }
                        }
                    } while (Add.ToUpper() == "Y");

                    contact.DisplayAddressBook();
                    goto case 3;

                case 3:
                    do
                    {
                        Console.WriteLine("Would you like to edit a contact (Y/N)");
                        Edit = Convert.ToString(Console.ReadLine());
                        if (Edit.ToUpper() == "Y")
                        {
                            Console.WriteLine("Enter contact first name");
                            string firstName1 = Convert.ToString(Console.ReadLine());
                            var editContact = contact.addressBookList.Find(x => x.FirstName == firstName1);
                            if (editContact != null)
                            {
                                contact.editContact(editContact);
                            }
                            else
                            {
                                Console.Write("Invalid Input");
                            }
                        }
                    } while (Edit.ToUpper() == "Y");

                    contact.DisplayAddressBook();
                    goto case 4;

                case 4:
                    contact.DeleteContact();
                    contact.DisplayAddressBook();
                    goto case 5;

                case 5:
                    Console.WriteLine("Please enter the first name the person you want to search");
                    string firstName2 = Console.ReadLine();
                    var searchContact = contact.CityBook.Values.FirstOrDefault(f => f.FirstName == firstName2);
                    if (searchContact != null)
                    {
                        Console.WriteLine("Contact from CityAddressBook is: \n");
                        Console.WriteLine(" {0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n",
                        searchContact.FirstName, searchContact.LastName, searchContact.State, searchContact.
                        City, searchContact.Address, searchContact.Zip, searchContact.PhoneNo, searchContact.Email);

                        var search = contact.StateAddress.Values.FirstOrDefault(f => f.FirstName == firstName2);
                        Console.WriteLine("Contact from StateAddressBook is: \n");
                        Console.WriteLine(" {0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n",
                        search.FirstName, search.LastName, search.State, search.
                        City, search.Address, search.Zip, search.PhoneNo, search.Email);
                    }
                    else
                    {
                        Console.WriteLine("First Name you have entered is does not exist");
                    }
                    goto case 6;

                case 6:
                    Console.WriteLine("please ener city name to view contacts");
                    string cityName = Console.ReadLine();
                    var cityPersons = contact.CityBook.Values.ToList().FindAll(x => x.City == cityName);

                    if (cityPersons != null)
                    {
                        foreach (var person in cityPersons)
                        {
                            Console.WriteLine(" {0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n",
                            person.FirstName, person.LastName, person.State, person.
                            City, person.Address, person.Zip, person.PhoneNo, person.Email);
                        }

                        Console.WriteLine("please ener state name to view contacts");
                        string stateName = Console.ReadLine();

                        var statePersons = contact.CityBook.Values.ToList().FindAll(x => x.State == stateName);
                        foreach (var person in statePersons)
                        {
                            Console.WriteLine(" {0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n",
                            person.FirstName, person.LastName, person.State, person.
                            City, person.Address, person.Zip, person.PhoneNo, person.Email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    goto case 7;

                case 7:
                    Console.WriteLine("please ener city name to find count");
                    string Name = Console.ReadLine();
                    var cityPerson = contact.CityBook.Values.ToList().FindAll(x => x.City == Name);

                    if (cityPerson != null)
                    {
                        Console.WriteLine("City name count is {0}", cityPerson.Count);
                        Console.WriteLine("please ener state name to find count");
                        string stateName = Console.ReadLine();
                        var statePerson = contact.CityBook.Values.ToList().FindAll(x => x.State == stateName);
                        Console.WriteLine("State name count is {0}", statePerson.Count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    goto case 8;

                case 8:
                    Console.WriteLine("Soterd Data according to alphabetical oredr is");
                    contact.sortedData();
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        static ContactPerson AddNewContact(ContactPerson person)
        {
            Console.WriteLine("Please enter your first name");
            fName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            lName = Console.ReadLine();
            Console.WriteLine("Please enter your state");
            state = Console.ReadLine();
            Console.WriteLine("Please enter your city");
            city = Console.ReadLine();
            Console.WriteLine("Please enter your address");
            address = Console.ReadLine();
            Console.WriteLine("Please enter your zip");
            zip = Console.ReadLine();
            Console.WriteLine("Please enter your phone number");
            phone = Console.ReadLine();
            Console.WriteLine("Please enter your email");
            email = Console.ReadLine();

            person = new ContactPerson(fName, lName, state, city, address, zip, phone, email);

            return person;
        }
    }
}
